using System;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using J.SLS.Database.DBAccess;
using J.SLS.Common;
using System.Linq;
using System.Text;

namespace J.SLS.Database.ORM
{
    public class ObjectPersistence
    {
        private readonly IDBAccess dbAccess;

        public ObjectPersistence(IDBAccess dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        public T GetByKey<T>(object keyValue)
            where T : new()
        {
            //断言参入的参数为null或者空字符串（RErrorCode.ArgmentesError - 0x00000014）
            PreconditionAssert.IsNotNull(keyValue, ErrorMessages.NullReferenceException);
            PreconditionAssert.IsNotNullOrEmpty(keyValue.ToString(), ErrorMessages.NullReferenceException);
            ORMHelper.EntityIsMappingDatabase(typeof(T), ErrorMessages.EntityMappingError);
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
                    throw new ORMException(ErrorMessages.ResultNotUniqueMessage);
                }
            }
            catch (Exception ex)
            {
                //其他未处理的异常
                throw new ORMException("Get object by key error - " + keyValue, ex);
            }
        }

        public T GetByKeys<T>(T entity) where T : new()
        {
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            ORMHelper.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
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
                    throw new ORMException(ErrorMessages.ResultNotUniqueMessage);
                }
            }
            catch (Exception ex)
            {
                throw new ORMException("Get object by keys error, keys value:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        public void Add(object entity)
        {
            //断言参入的参数为null或者空字符串（RErrorCode.NullReference - 0x00000001）
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            ORMHelper.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            ORMHelper.CheckEntityIsNotReadOnly(entity.GetType(), ErrorMessages.EntityReadOnly);
            try
            {
                InsertCommandCreator icc = new InsertCommandCreator(dbAccess);
                icc.Entity = entity;
                DbCommand dbCommand = icc.GetDbCommand();
                dbAccess.ExecCommand(dbCommand);
            }
            catch (Exception ex)
            {
                throw new ORMException("Add entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        public void Modify(object entity)
        {
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            ORMHelper.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            ORMHelper.CheckEntityIsNotReadOnly(entity.GetType(), ErrorMessages.EntityReadOnly);

            try
            {
                ModifyCommandCreator mcc = new ModifyCommandCreator(dbAccess);
                mcc.Entity = entity;
                DbCommand dbCommand = mcc.GetDbCommand();
                dbAccess.ExecCommand(dbCommand);
            }
            catch (Exception ex)
            {
                throw new ORMException("Update entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        public void Delete(object entity)
        {
            //断言参入的参数为null或者空字符串（RErrorCode.NullReference - 0x00000001）
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            ORMHelper.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            ORMHelper.CheckEntityIsNotReadOnly(entity.GetType(), ErrorMessages.EntityReadOnly);

            try
            {
                DeleteCommandCreator dcc = new DeleteCommandCreator(dbAccess);

                dcc.Entity = entity;
                DbCommand dbCommand = dcc.GetDbCommand();
                dbAccess.ExecCommand(dbCommand);
            }
            catch (Exception ex)
            {
                throw new ORMException("delete entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        public IList<T> GetAll<T>(params SortInfo[] orderBy) where T : new()
        {
            PreconditionAssert.IsNotNull(orderBy, ErrorMessages.NullReferenceException);
            ORMHelper.EntityIsMappingDatabase(typeof(T), ErrorMessages.EntityMappingError);
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
            catch (Exception ex)
            {
                throw new ORMException("Get all object list error, detail:\n\t" + ORMHelper.GetOrderInfoMessage(orderBy), ex);
            }
        }

        public IList<T> GetAll<T>(int pageIndex, int pageSize, out int totalCount, params SortInfo[] orderBy) where T : new()
        {
            PreconditionAssert.IsNotNull(orderBy, ErrorMessages.NullReferenceException);
            ORMHelper.EntityIsMappingDatabase(typeof(T), ErrorMessages.EntityMappingError);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.ObjectType = typeof(T);
                dbCommandCreator.OrderBy = orderBy;
                dbCommandCreator.SelectType = SelectType.GetAll;
                dbCommandCreator.NeedPaged = true;
                dbCommandCreator.PageIndex = pageIndex + 1;
                dbCommandCreator.PageSize = pageSize;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                DataTable dt = dbAccess.GetDataTableByCommand(dbCommand);
                if (dt.Rows.Count > 0)
                {
                    totalCount = (int)dt.Rows[0]["TotalCount"];
                }
                else
                {
                    totalCount = 0;
                }
                return ORMHelper.DataTableToList<T>(dt);
            }
            catch (Exception ex)
            {
                throw new ORMException("Get all object list error, detail:\n\t" + ORMHelper.GetOrderInfoMessage(orderBy), ex);
            }
        }

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
                dbCommandCreator.SelectType = SelectType.GetList;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                DataTable dt = dbAccess.GetDataTableByCommand(dbCommand);
                return ORMHelper.DataTableToList<T>(dt);
            }
            catch (Exception ex)
            {
                StringBuilder errMsgBuilder = new StringBuilder();
                errMsgBuilder.AppendLine("Select object list by criteria error, detail:");
                errMsgBuilder.AppendLine("Criteria Info:");
                errMsgBuilder.AppendLine(ORMHelper.GetCriteriaMessage(criteria));
                errMsgBuilder.AppendLine("Sort Info:");
                errMsgBuilder.AppendLine(ORMHelper.GetOrderInfoMessage(orderBy));
                throw new ORMException(errMsgBuilder.ToString(), ex);
            }
        }

        public IList<T> GetList<T>(Criteria criteria, int pageIndex, int pageSize, out int totalCount, params SortInfo[] orderBy)
            where T : new()
        {
            PreconditionAssert.IsNotNull(criteria, ErrorMessages.NullReferenceException);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.OrderBy = orderBy;
                dbCommandCreator.ObjectType = typeof(T);
                dbCommandCreator.Cri = criteria;
                dbCommandCreator.SelectType = SelectType.GetList;
                dbCommandCreator.NeedPaged = true;
                dbCommandCreator.PageIndex = pageIndex + 1;
                dbCommandCreator.PageSize = pageSize;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                DataTable dt = dbAccess.GetDataTableByCommand(dbCommand);
                if (dt.Rows.Count > 0)
                {
                    totalCount = (int)dt.Rows[0]["TotalCount"];
                }
                else
                {
                    totalCount = 0;
                }
                return ORMHelper.DataTableToList<T>(dt);
            }
            catch (Exception ex)
            {
                StringBuilder errMsgBuilder = new StringBuilder();
                errMsgBuilder.AppendLine("Select object list by criteria error with page, detail:");
                errMsgBuilder.AppendLine("Criteria Info:");
                errMsgBuilder.AppendLine(ORMHelper.GetCriteriaMessage(criteria));
                errMsgBuilder.AppendLine("Page Info:");
                errMsgBuilder.AppendLine("PageIndex:" + pageIndex + "; PageSize:" + pageSize);
                errMsgBuilder.AppendLine("Sort Info:");
                errMsgBuilder.AppendLine(ORMHelper.GetOrderInfoMessage(orderBy));
                throw new ORMException(errMsgBuilder.ToString(), ex);
            }
        }

        public int GetCount(object entity, string[] filterProterties)
        {
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            ORMHelper.EntityIsMappingDatabase(entity.GetType(), ErrorMessages.EntityMappingError);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.Entity = entity;
                dbCommandCreator.FilterProterties = filterProterties;
                dbCommandCreator.SelectType = SelectType.GetCount;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                return (int)dbAccess.GetRC1ByCommand(dbCommand);
            }
            catch (Exception ex)
            {
                StringBuilder errMsgBuilder = new StringBuilder();
                errMsgBuilder.AppendLine("Get object count by entity error, detail:");
                errMsgBuilder.AppendLine("Entity Info:");
                errMsgBuilder.AppendLine(ORMHelper.GetEntityInfoMessage(entity));
                errMsgBuilder.AppendLine("Filter Proterties:");
                errMsgBuilder.AppendLine(string.Join(",", filterProterties));
                throw new ORMException(errMsgBuilder.ToString(), ex);
            }
        }

        public int GetAllCount<T>()
        {
            ORMHelper.EntityIsMappingDatabase(typeof(T), ErrorMessages.EntityMappingError);
            try
            {
                SelectCommandCreator dbCommandCreator = new SelectCommandCreator(dbAccess);
                dbCommandCreator.ObjectType = typeof(T);
                dbCommandCreator.SelectType = SelectType.GetAllCount;
                DbCommand dbCommand = dbCommandCreator.GetDbCommand();
                return (int)dbAccess.GetRC1ByCommand(dbCommand);
            }
            catch (Exception ex)
            {
                throw new ORMException("Get object all count error.", ex);
            }
        }
    }

    public class SortInfo
    {
        public SortInfo(string propertyName)
            : this(propertyName, SortDirection.Asc)
        {
        }

        public SortInfo(string propertyName, SortDirection direction)
        {
            PropertyName = propertyName;
            Direction = direction;
        }

        public string PropertyName { get; set; }
        public SortDirection Direction { get; set; }
    }

    public enum SortDirection : int
    {
        Asc,
        Desc
    }
}