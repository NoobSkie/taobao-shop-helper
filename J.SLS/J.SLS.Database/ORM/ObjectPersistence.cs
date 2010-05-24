using System;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using LHBIS.Database.DBAccess;
using LHBIS.Common;
using System.Linq;
using System.Text;


namespace LHBIS.Database.ORM
{
    public class ObjectPersistence
    {
        private readonly IDBAccess dbAccess;

        public ObjectPersistence(IDBAccess dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        /// <summary>
        /// 通过主键和指定类型从数据库获取对象
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="keyValue">主键值（通常为Guid），不能为空</param>
        /// <returns>从数据库中得到的对象,如果数据库中没找到对象会返回一个空对象</returns>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// 参数错误异常
        /// 当传入的主键值为null或者为空字符串(RErrorCode.ArgmentesError -0x00000014)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ResultNotUnique - 0x00010110">
        /// 查询结果错误异常,通过主键查找到得对象不唯一时会抛出该异常
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  获取对象数据失败时会引发该异常，引发该异常的异常都包含在InnerException中
        /// </exception>
        /// 前置条件
        /// 1.keyValue不能为空
        /// 2.传入的对象T只能有一个主键
        public T GetByKey<T>(object keyValue)
            where T : new()
        {
            //断言参入的参数为null或者空字符串（RErrorCode.ArgmentesError - 0x00000014）
            PreconditionAssert.IsNotNull(keyValue, ErrorMessages.NullReferenceException);
            PreconditionAssert.IsStringEmpty(keyValue, ErrorMessages.NullReferenceException);
            PreconditionAssert.EntityIsMappingDatabase(typeof(T), ErrorMessages.EntityMappingError);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.ObjectType = typeof(T);
                dbCommandCreator.KeyValue = keyValue;
                dbCommandCreator.SelectType = SelectType.GetOneByKeyValue;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                DataTable dt = dbAccess.GetDataTableByCommand(dbCommand);

                if (dt.Rows.Count == 0)
                {
                    return default(T);
                }
                else if (dt.Rows.Count == 1)
                {
                    return ORMHelper.ConvertDataRowToEntity<T>(dt.Rows[0]);
                }
                else
                {
                    //引发数据获取结果错误
                    throw new RException(DatabaseErrorCode.ResultNotUnique, ErrorMessages.ResultNotUniqueMessage);
                }
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case RErrorCode.ArgmentesError:
                    case DatabaseErrorCode.ConnectDbServerError: //连接数据库服务器失败
                    case DatabaseErrorCode.ResultNotUnique:
                        throw ex;
                    default:
                        //其他未处理的异常
                        throw new RException(DatabaseErrorCode.SelectEntityError, "Get object by key error - " + keyValue, ex);
                }
            }
            catch (Exception ex)
            {
                //其他未处理的异常
                throw new RException(DatabaseErrorCode.SelectEntityError, "Get object by key error - " + keyValue, ex);
            }
        }

        /// <summary>
        /// 通过对象已有的主键值（可以多个主键）和指定类型从数据库获取对象
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="entity">外部构造的对象，不能为空</param>
        /// <returns>从数据库中得到的对象,如果数据库中没找到对象会返回一个空对象</returns>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// 参数错误异常
        /// 当传入的主键值为null或者为空字符串(RErrorCode.ArgmentesError -0x00000014)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ResultNotUnique - 0x00010110">
        /// 查询结果错误异常,通过主键查找到得对象不唯一时会抛出该异常
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  获取对象数据失败时会引发该异常，引发该异常的异常都包含在InnerException中
        /// </exception>
        /// 前置条件
        /// 传入的entity对象不能为空
        public T GetByKeys<T>(T entity) where T : new()
        {
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            PreconditionAssert.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            try
            {
                ORMHelper.CheckEntityKey(entity);
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.Entity = entity;
                dbCommandCreator.SelectType = SelectType.GetOneByEntityKey;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                DataTable dt = dbAccess.GetDataTableByCommand(dbCommand);
                if (dt.Rows.Count == 0)
                {
                    return default(T);
                }
                else if (dt.Rows.Count == 1)
                {
                    return ORMHelper.ConvertDataRowToEntity<T>(dt.Rows[0]);
                }
                else
                {
                    throw new RException(DatabaseErrorCode.ResultNotUnique, ErrorMessages.ResultNotUniqueMessage);
                }
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case RErrorCode.ArgmentesError:
                    case DatabaseErrorCode.ConnectDbServerError: //连接数据库服务器失败
                    case DatabaseErrorCode.ResultNotUnique:
                        throw ex;
                    default:
                        throw new RException(DatabaseErrorCode.SelectEntityError, "Get object by keys error, keys value:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
                }
            }
            catch (Exception ex)
            {
                throw new RException(DatabaseErrorCode.SelectEntityError, "Get object by keys error, keys value:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        /// <summary>
        /// 新增一个实体对象到数据库中
        /// </summary>
        /// <param name="entity">需要保存的实体对象</param>
        /// <exception cref="DatabaseErrorCode.AddEntityError - 0x00010003">
        /// 添加实体对象失败,以下几种情况会引发该异常，并会包含在InnerException中
        /// 连接数据库服务失败时（DatabaseErrorCode.ConnectDbServerError - 0x00010001）
        /// 执行SQL语句或命令失败时(DatabaseErrorCode.ExecDbCommandError - 0x00010002)
        /// </exception>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// 参数错误异常,以下几种情况会引发该异常，并会包含在InnerException中
        /// 传入的参数为null或空串时（RErrorCode.NullReference - 0x00000001）
        /// </exception>
        /// 前置条件:
        /// 1.参数entity不允许为空
        public void Add(object entity)
        {
            //断言参入的参数为null或者空字符串（RErrorCode.NullReference - 0x00000001）
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            PreconditionAssert.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            PreconditionAssert.CheckEntityIsNotReadOnly(entity.GetType(), ErrorMessages.EntityReadOnly);

            try
            {
                InsertCommandCreator icc = new InsertCommandCreator(dbAccess);
                icc.Entity = entity;
                DbCommand dbCommand = icc.GetDbCommand();
                dbAccess.ExecCommand(dbCommand);
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case DatabaseErrorCode.PrimaryKeyConflict:
                    case DatabaseErrorCode.IndexConflict:
                    case DatabaseErrorCode.ConnectDbServerError:
                    case RErrorCode.ArgmentesError:
                    case DatabaseErrorCode.EntityReadOnly:
                        throw ex;
                    default:
                        throw new RException(DatabaseErrorCode.AddEntityError, "Add entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
                }
            }
            catch (Exception ex)
            {
                //未处理的异常
                throw new RException(DatabaseErrorCode.AddEntityError, "Add entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        /// <summary>
        /// 修改一个数据库中已有的对象，该对象的主键必须有值
        /// 该对象为空或主键为空或修改失败会抛出异常
        /// </summary>
        /// <param name="entity">需要修改的实体对象</param>
        /// <exception cref="DatabaseErrorCode.UpdateEntityError - 0x00010004">
        /// 修改实体对象失败,以下几种情况会引发该异常，并会包含在InnerException中
        /// 连接数据库服务失败时（DatabaseErrorCode.ConnectDbServerError - 0x00010001）
        /// 执行SQL语句或命令失败时(DatabaseErrorCode.ExecDbCommandError - 0x00010002)
        /// </exception>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// 参数错误异常,以下几种情况会引发该异常，并会包含在InnerException中
        /// 传入的参数为null或空串时（RErrorCode.NullReference - 0x00000001)
        /// </exception>
        /// 前置条件
        /// 参数entity不允许为空
        public void Modify(object entity)
        {
            //断言参入的参数为null或者空字符串（RErrorCode.NullReference - 0x00000001）
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            PreconditionAssert.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            PreconditionAssert.CheckEntityIsNotReadOnly(entity.GetType(), ErrorMessages.EntityReadOnly);

            try
            {
                ModifyCommandCreator mcc = new ModifyCommandCreator(dbAccess);
                mcc.Entity = entity;
                DbCommand dbCommand = mcc.GetDbCommand();
                dbAccess.ExecCommand(dbCommand);
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case DatabaseErrorCode.PrimaryKeyConflict:
                    case DatabaseErrorCode.IndexConflict:
                    case DatabaseErrorCode.EntityReadOnly:
                        throw ex;
                    default:
                        throw new RException(DatabaseErrorCode.UpdateEntityError, "Update entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
                }
            }
            catch (Exception ex)
            {
                throw new RException(DatabaseErrorCode.UpdateEntityError, "Update entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        /// <summary>
        /// 删除一个数据库中已有的对象，该对象的主键必须有值
        /// 该对象为空或主键为空或删除失败会抛出异常
        /// </summary>
        /// <param name="entity">需要删除的实体</param>
        /// <exception cref="DatabaseErrorCode.DeleteEntityError - 0x00010005">
        /// 删除实体对象失败,以下几种情况会引发该异常，并会包含在InnerException中
        /// 连接数据库服务失败时（ConnectDbServerError - 0x00010001）
        /// 执行SQL语句或命令失败时(DatabaseErrorCode.ExecDbCommandError - 0x00010002)
        /// </exception>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// 参数错误异常,以下几种情况会引发该异常，并会包含在InnerException中
        /// 传入的参数为null或空串时（RErrorCode.NullReference - 0x00000001）
        /// </exception>
        /// 前置条件
        /// 参数entity不允许为空
        public void Delete(object entity)
        {
            //断言参入的参数为null或者空字符串（RErrorCode.NullReference - 0x00000001）
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            PreconditionAssert.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            PreconditionAssert.CheckEntityIsNotReadOnly(entity.GetType(), ErrorMessages.EntityReadOnly);

            try
            {
                DeleteCommandCreator dcc = new DeleteCommandCreator(dbAccess);

                dcc.Entity = entity;
                DbCommand dbCommand = dcc.GetDbCommand();
                dbAccess.ExecCommand(dbCommand);
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case RErrorCode.ArgmentesError:
                    case DatabaseErrorCode.EntityReadOnly:
                        // 引发删除实体错误异常
                        throw ex;
                    default:
                        //其他类型
                        throw new RException(DatabaseErrorCode.DeleteEntityError, "delete entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
                }
            }
            catch (Exception ex)
            {
                throw new RException(DatabaseErrorCode.DeleteEntityError, "delete entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        /// <summary>
        /// 获取数据表中的所有数据集合，并按指定排序方式进行排序
        /// </summary>
        /// <typeparam name="T">指定的类型</typeparam>
        /// <param name="orderBy">排序方式</param>
        /// <returns>数据表中的所有数据集合</returns>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  获取所有数据集合失败时会引发该异常，引发该异常的异常都包含在InnerException中
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   未处理异常
        /// </exception>
        /// 前置条件
        /// 传入的orderBy对象可以为空，为空的时候则不进行排序
        public IList<T> GetAll<T>(params SortInfo[] orderBy) where T : new()
        {
            PreconditionAssert.IsNotNull(orderBy, ErrorMessages.NullReferenceException);
            PreconditionAssert.EntityIsMappingDatabase(typeof(T), ErrorMessages.EntityMappingError);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.ObjectType = typeof(T);
                dbCommandCreator.OrderBy = orderBy;
                dbCommandCreator.SelectType = SelectType.GetAll;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();

                DataTable dt = dbAccess.GetDataTableByCommand(dbCommand);
                return ORMHelper.DataTableToList<T>(dt);
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case RErrorCode.ArgmentesError:
                    case DatabaseErrorCode.ConnectDbServerError: //连接数据库服务器失败
                        throw ex;
                    default:
                        throw new RException(DatabaseErrorCode.SelectEntityError, "Get all object list error, detail:\n\t" + ORMHelper.GetOrderInfoMessage(orderBy), ex);
                }
            }
            catch (Exception ex)
            {
                throw new RException(DatabaseErrorCode.SelectEntityError, "Get all object list error, detail:\n\t" + ORMHelper.GetOrderInfoMessage(orderBy), ex);
            }
        }

        /// <summary>
        /// 通过指定类型,过滤条件和排序方式从数据库中获取该指定类型的数据集合
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="entity">实体对象</param>
        /// <param name="filterProterties">字段名称，可包含多个</param>
        /// <param name="orderBy">排序方式</param>
        /// <returns>指定类型的数据集合</returns>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// 参数错误异常，以下情况会引发该异常,并会包含在InnerException中
        /// 传入的entity对象为null，出现空引用异常（RErrorCode.NullReference - 0x00000001）
        /// 传入的filterProterties为null或者为空字符串时，出现sql语句错误异常(DatabaseErrorCode.CommandTextIsError - 0x00010105)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  获取指定类型的数据集合失败时会引发该异常，引发该异常的异常都包含在InnerException中
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   未处理异常
        /// </exception>
        /// 前置条件
        /// 传入的参数entity，filterProterties不允许为空
        /// orderBy可以为空，如果为空则不进行排序
        public IList<T> GetList<T>(T entity, string[] filterProterties, params SortInfo[] orderBy)
            where T : new()
        {
            //断言传入的entity对象为null或者为空字符串，出现空引用异常
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            PreconditionAssert.IsNotNull(filterProterties, ErrorMessages.NullReferenceException);
            //断言传入的filterProterties为null或者为空字符串时，出现sql语句错误异常
            PreconditionAssert.IsFalse(string.IsNullOrEmpty(filterProterties.ToString()), ErrorMessages.CommandTextIsErrorMessage);
            PreconditionAssert.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.Entity = entity;
                dbCommandCreator.FilterProterties = filterProterties;
                dbCommandCreator.OrderBy = orderBy;
                dbCommandCreator.SelectType = SelectType.GetList;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                DataTable dt = dbAccess.GetDataTableByCommand(dbCommand);
                return ORMHelper.DataTableToList<T>(dt);
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case RErrorCode.ArgmentesError:
                    case DatabaseErrorCode.ConnectDbServerError: //连接数据库服务器失败
                        throw ex;
                    default:
                        StringBuilder errMsgBuilder = new StringBuilder();
                        errMsgBuilder.AppendLine("Entity Info:\n\t" + ORMHelper.GetEntityInfoMessage(entity));
                        errMsgBuilder.AppendLine("Filter Proterties:\n\t" + string.Join(",", filterProterties));
                        errMsgBuilder.AppendLine("Sort Info:\n\t" + ORMHelper.GetOrderInfoMessage(orderBy));
                        throw new RException(DatabaseErrorCode.SelectEntityError, "Select object list by entity error, detail:\n\t" + errMsgBuilder, ex);
                }
            }
            catch (Exception ex)
            {
                StringBuilder errMsgBuilder = new StringBuilder();
                errMsgBuilder.AppendLine("Entity Info:\n\t" + ORMHelper.GetEntityInfoMessage(entity));
                errMsgBuilder.AppendLine("Filter Proterties:\n\t" + string.Join(",", filterProterties));
                errMsgBuilder.AppendLine("Sort Info:\n\t" + ORMHelper.GetOrderInfoMessage(orderBy));
                throw new RException(DatabaseErrorCode.SelectEntityError, "Select object list by entity error, detail:\n\t" + errMsgBuilder, ex);
            }
        }

        /// <summary>
        /// 根据表达式，查询对象集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="criteria">表达式</param>
        /// <param name="orderBy">排序</param>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// 参数错误异常，以下情况会引发该异常,并会包含在InnerException中
        /// 传入的entity对象为null，出现空引用异常（RErrorCode.NullReference - 0x00000001）
        /// 传入的filterProterties为null或者为空字符串时，出现sql语句错误异常(DatabaseErrorCode.CommandTextIsError - 0x00010105)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  获取指定类型的数据集合失败时会引发该异常，引发该异常的异常都包含在InnerException中
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   未处理异常
        /// </exception>
        /// <returns>指定类型的数据集合</returns>
        public IList<T> GetList<T>(Criteria criteria, params SortInfo[] orderBy)
            where T : new()
        {
            PreconditionAssert.IsNotNull(criteria, ErrorMessages.NullReferenceException);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.OrderBy = orderBy;
                dbCommandCreator.ObjectType = typeof(T);
                dbCommandCreator.Cri = criteria;
                dbCommandCreator.SelectType = SelectType.GetListByExpression;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                DataTable dt = dbAccess.GetDataTableByCommand(dbCommand);
                return ORMHelper.DataTableToList<T>(dt);
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case RErrorCode.ArgmentesError:
                    case DatabaseErrorCode.ConnectDbServerError: //连接数据库服务器失败
                        throw ex;
                    default:
                        StringBuilder errMsgBuilder = new StringBuilder();
                        errMsgBuilder.AppendLine("Select object list by criteria error, detail:");
                        errMsgBuilder.AppendLine("Criteria Info:");
                        errMsgBuilder.AppendLine(ORMHelper.GetCriteriaMessage(criteria));
                        errMsgBuilder.AppendLine("Sort Info:");
                        errMsgBuilder.AppendLine(ORMHelper.GetOrderInfoMessage(orderBy));
                        throw new RException(DatabaseErrorCode.SelectEntityError, errMsgBuilder.ToString(), ex);
                }
            }
            catch (Exception ex)
            {
                StringBuilder errMsgBuilder = new StringBuilder();
                errMsgBuilder.AppendLine("Select object list by criteria error, detail:");
                errMsgBuilder.AppendLine("Criteria Info:");
                errMsgBuilder.AppendLine(ORMHelper.GetCriteriaMessage(criteria));
                errMsgBuilder.AppendLine("Sort Info:");
                errMsgBuilder.AppendLine(ORMHelper.GetOrderInfoMessage(orderBy));
                throw new RException(DatabaseErrorCode.SelectEntityError, errMsgBuilder.ToString(), ex);
            }
        }
        /// <summary>
        /// 通过指定类型,过滤条件和排序方式从数据库中获取该指定类型的数据条数
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="entity">实体对象</param>
        /// <param name="filterProterties">过滤条件</param>
        /// <param name="orderBy">排序方式</param>
        /// <returns>指定类型的数据条数</returns>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// 参数错误异常，以下情况会引发该异常,并会包含在InnerException中
        /// 传入的entity对象为null或者为空字符串，出现空引用异常（RErrorCode.NullReference - 0x00000001）
        /// 传入的filterProterties为null或者为空字符串时，出现sql语句错误异常(DatabaseErrorCode.CommandTextIsError - 0x00010105)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  获取指定类型的数据集合失败时会引发该异常，引发该异常的异常都包含在InnerException中
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   未处理异常
        /// </exception>
        /// 前置条件
        /// 传入的参数entity不允许为空
        /// filterProterties,orderBy可以为空，如果为空则没有where条件查询和不进行排序
        public int GetCount(object entity, string[] filterProterties)
        {
            //断言传入的entity对象为null或者为空字符串，出现空引用异常
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            PreconditionAssert.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.Entity = entity;
                dbCommandCreator.FilterProterties = filterProterties;
                dbCommandCreator.SelectType = SelectType.GetCount;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                return (int)dbAccess.GetRC1ByCommand(dbCommand);
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case DatabaseErrorCode.ConnectDbServerError:    // 连接数据库服务器失败
                    case DatabaseErrorCode.ExecDbCommandError:      // 执行SQL语句或命令失败
                        // 引发查询实体错误异常(DatabaseErrorCode.SelectEntityError)
                        throw new RException(DatabaseErrorCode.ExecDbCommandError, ErrorMessages.ExecDbCommandErrorMessage, ex);
                    default:
                        StringBuilder errMsgBuilder = new StringBuilder();
                        errMsgBuilder.AppendLine("Entity Info:\n\t" + ORMHelper.GetEntityInfoMessage(entity));
                        errMsgBuilder.AppendLine("Filter Proterties:\n\t" + string.Join(",", filterProterties));
                        throw new RException(DatabaseErrorCode.SelectEntityError, "Get object count by entity error, detail:\n\t" + errMsgBuilder, ex);
                }
            }
            catch (Exception ex)
            {
                StringBuilder errMsgBuilder = new StringBuilder();
                errMsgBuilder.AppendLine("Entity Info:\n\t" + ORMHelper.GetEntityInfoMessage(entity));
                errMsgBuilder.AppendLine("Filter Proterties:\n\t" + string.Join(",", filterProterties));
                throw new RException(DatabaseErrorCode.SelectEntityError, "Get object count by entity error, detail:\n\t" + errMsgBuilder, ex);
            }
        }

        /// <summary>
        /// 获取数据库中所有的数据总数
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <returns>数据总数</returns>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  获取指定类型的数据总数失败时会引发该异常，引发该异常的异常都包含在InnerException中
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   未处理异常
        /// </exception>
        public int GetAllCount<T>()
        {
            PreconditionAssert.EntityIsMappingDatabase(typeof(T), ErrorMessages.EntityMappingError);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.ObjectType = typeof(T);
                dbCommandCreator.SelectType = SelectType.GetAllCount;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                return (int)dbAccess.GetRC1ByCommand(dbCommand);
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case DatabaseErrorCode.ConnectDbServerError:    // 连接数据库服务器失败
                    case DatabaseErrorCode.ExecDbCommandError:      // 执行SQL语句或命令失败
                        // 引发查询实体错误异常(DatabaseErrorCode.SelectEntityError)
                        throw new RException(DatabaseErrorCode.ExecDbCommandError, ErrorMessages.ExecDbCommandErrorMessage, ex);
                    default:
                        throw new RException(DatabaseErrorCode.SelectEntityError, "Get object all count error, detail:\n\t" + ex.Message, ex);
                }
            }
            catch (Exception ex)
            {
                throw new RException(DatabaseErrorCode.SelectEntityError, "Get object all count error, detail:\n\t" + ex.Message, ex);
            }
        }
    }

    /// <summary>
    /// 排序信息
    /// </summary>
    public class SortInfo
    {
        /// <summary>
        /// 通过传入的字段名确定要排序的列,初始化排序对象实例
        /// </summary>
        /// <param name="propertyName">指定的要排序的属性名称，不允许为null或空串</param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常：
        /// 1.传入的propertyName为null或空串时。
        /// </exception>
        public SortInfo(string propertyName)
            : this(propertyName, SortDirection.Asc)
        {
        }

        /// <summary>
        /// 通过传入的字段名称和排序方式确定要排序的列和排序的方式,初始化排序对象实例
        /// </summary>
        /// <param name="propertyName">要排序的属性名称，不允许为null或空串</param>
        /// <param name="direction">排序方向</param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常：
        /// 1.传入的propertyName为null或空串时。
        /// </exception>
        public SortInfo(string propertyName, SortDirection direction)
        {
            PropertyName = propertyName;
            Direction = direction;
        }

        /// <summary>
        /// 要排序的属性名称
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public SortDirection Direction { get; set; }
    }

    /// <summary>
    /// 排序方向
    /// </summary>
    public enum SortDirection : int
    {
        /// <summary>
        /// 升序
        /// </summary>
        Asc,
        /// <summary>
        /// 降序
        /// </summary>
        Desc
    }
}