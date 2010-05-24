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
        /// ͨ��������ָ�����ʹ����ݿ��ȡ����
        /// </summary>
        /// <typeparam name="T">ָ������</typeparam>
        /// <param name="keyValue">����ֵ��ͨ��ΪGuid��������Ϊ��</param>
        /// <returns>�����ݿ��еõ��Ķ���,������ݿ���û�ҵ�����᷵��һ���ն���</returns>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// ���������쳣
        /// �����������ֵΪnull����Ϊ���ַ���(RErrorCode.ArgmentesError -0x00000014)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ResultNotUnique - 0x00010110">
        /// ��ѯ��������쳣,ͨ���������ҵ��ö���Ψһʱ���׳����쳣
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  ��ȡ��������ʧ��ʱ���������쳣���������쳣���쳣��������InnerException��
        /// </exception>
        /// ǰ������
        /// 1.keyValue����Ϊ��
        /// 2.����Ķ���Tֻ����һ������
        public T GetByKey<T>(object keyValue)
            where T : new()
        {
            //���Բ���Ĳ���Ϊnull���߿��ַ�����RErrorCode.ArgmentesError - 0x00000014��
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
                    //�������ݻ�ȡ�������
                    throw new RException(DatabaseErrorCode.ResultNotUnique, ErrorMessages.ResultNotUniqueMessage);
                }
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case RErrorCode.ArgmentesError:
                    case DatabaseErrorCode.ConnectDbServerError: //�������ݿ������ʧ��
                    case DatabaseErrorCode.ResultNotUnique:
                        throw ex;
                    default:
                        //����δ������쳣
                        throw new RException(DatabaseErrorCode.SelectEntityError, "Get object by key error - " + keyValue, ex);
                }
            }
            catch (Exception ex)
            {
                //����δ������쳣
                throw new RException(DatabaseErrorCode.SelectEntityError, "Get object by key error - " + keyValue, ex);
            }
        }

        /// <summary>
        /// ͨ���������е�����ֵ�����Զ����������ָ�����ʹ����ݿ��ȡ����
        /// </summary>
        /// <typeparam name="T">ָ������</typeparam>
        /// <param name="entity">�ⲿ����Ķ��󣬲���Ϊ��</param>
        /// <returns>�����ݿ��еõ��Ķ���,������ݿ���û�ҵ�����᷵��һ���ն���</returns>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// ���������쳣
        /// �����������ֵΪnull����Ϊ���ַ���(RErrorCode.ArgmentesError -0x00000014)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ResultNotUnique - 0x00010110">
        /// ��ѯ��������쳣,ͨ���������ҵ��ö���Ψһʱ���׳����쳣
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  ��ȡ��������ʧ��ʱ���������쳣���������쳣���쳣��������InnerException��
        /// </exception>
        /// ǰ������
        /// �����entity������Ϊ��
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
                    case DatabaseErrorCode.ConnectDbServerError: //�������ݿ������ʧ��
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
        /// ����һ��ʵ��������ݿ���
        /// </summary>
        /// <param name="entity">��Ҫ�����ʵ�����</param>
        /// <exception cref="DatabaseErrorCode.AddEntityError - 0x00010003">
        /// ���ʵ�����ʧ��,���¼���������������쳣�����������InnerException��
        /// �������ݿ����ʧ��ʱ��DatabaseErrorCode.ConnectDbServerError - 0x00010001��
        /// ִ��SQL��������ʧ��ʱ(DatabaseErrorCode.ExecDbCommandError - 0x00010002)
        /// </exception>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// ���������쳣,���¼���������������쳣�����������InnerException��
        /// ����Ĳ���Ϊnull��մ�ʱ��RErrorCode.NullReference - 0x00000001��
        /// </exception>
        /// ǰ������:
        /// 1.����entity������Ϊ��
        public void Add(object entity)
        {
            //���Բ���Ĳ���Ϊnull���߿��ַ�����RErrorCode.NullReference - 0x00000001��
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
                //δ������쳣
                throw new RException(DatabaseErrorCode.AddEntityError, "Add entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        /// <summary>
        /// �޸�һ�����ݿ������еĶ��󣬸ö��������������ֵ
        /// �ö���Ϊ�ջ�����Ϊ�ջ��޸�ʧ�ܻ��׳��쳣
        /// </summary>
        /// <param name="entity">��Ҫ�޸ĵ�ʵ�����</param>
        /// <exception cref="DatabaseErrorCode.UpdateEntityError - 0x00010004">
        /// �޸�ʵ�����ʧ��,���¼���������������쳣�����������InnerException��
        /// �������ݿ����ʧ��ʱ��DatabaseErrorCode.ConnectDbServerError - 0x00010001��
        /// ִ��SQL��������ʧ��ʱ(DatabaseErrorCode.ExecDbCommandError - 0x00010002)
        /// </exception>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// ���������쳣,���¼���������������쳣�����������InnerException��
        /// ����Ĳ���Ϊnull��մ�ʱ��RErrorCode.NullReference - 0x00000001)
        /// </exception>
        /// ǰ������
        /// ����entity������Ϊ��
        public void Modify(object entity)
        {
            //���Բ���Ĳ���Ϊnull���߿��ַ�����RErrorCode.NullReference - 0x00000001��
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
        /// ɾ��һ�����ݿ������еĶ��󣬸ö��������������ֵ
        /// �ö���Ϊ�ջ�����Ϊ�ջ�ɾ��ʧ�ܻ��׳��쳣
        /// </summary>
        /// <param name="entity">��Ҫɾ����ʵ��</param>
        /// <exception cref="DatabaseErrorCode.DeleteEntityError - 0x00010005">
        /// ɾ��ʵ�����ʧ��,���¼���������������쳣�����������InnerException��
        /// �������ݿ����ʧ��ʱ��ConnectDbServerError - 0x00010001��
        /// ִ��SQL��������ʧ��ʱ(DatabaseErrorCode.ExecDbCommandError - 0x00010002)
        /// </exception>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// ���������쳣,���¼���������������쳣�����������InnerException��
        /// ����Ĳ���Ϊnull��մ�ʱ��RErrorCode.NullReference - 0x00000001��
        /// </exception>
        /// ǰ������
        /// ����entity������Ϊ��
        public void Delete(object entity)
        {
            //���Բ���Ĳ���Ϊnull���߿��ַ�����RErrorCode.NullReference - 0x00000001��
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
                        // ����ɾ��ʵ������쳣
                        throw ex;
                    default:
                        //��������
                        throw new RException(DatabaseErrorCode.DeleteEntityError, "delete entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
                }
            }
            catch (Exception ex)
            {
                throw new RException(DatabaseErrorCode.DeleteEntityError, "delete entity failed, detail:\n\t" + ORMHelper.GetEntityInfoMessage(entity), ex);
            }
        }

        /// <summary>
        /// ��ȡ���ݱ��е��������ݼ��ϣ�����ָ������ʽ��������
        /// </summary>
        /// <typeparam name="T">ָ��������</typeparam>
        /// <param name="orderBy">����ʽ</param>
        /// <returns>���ݱ��е��������ݼ���</returns>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  ��ȡ�������ݼ���ʧ��ʱ���������쳣���������쳣���쳣��������InnerException��
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   δ�����쳣
        /// </exception>
        /// ǰ������
        /// �����orderBy�������Ϊ�գ�Ϊ�յ�ʱ���򲻽�������
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
                    case DatabaseErrorCode.ConnectDbServerError: //�������ݿ������ʧ��
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
        /// ͨ��ָ������,��������������ʽ�����ݿ��л�ȡ��ָ�����͵����ݼ���
        /// </summary>
        /// <typeparam name="T">ָ������</typeparam>
        /// <param name="entity">ʵ�����</param>
        /// <param name="filterProterties">�ֶ����ƣ��ɰ������</param>
        /// <param name="orderBy">����ʽ</param>
        /// <returns>ָ�����͵����ݼ���</returns>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// ���������쳣������������������쳣,���������InnerException��
        /// �����entity����Ϊnull�����ֿ������쳣��RErrorCode.NullReference - 0x00000001��
        /// �����filterProtertiesΪnull����Ϊ���ַ���ʱ������sql�������쳣(DatabaseErrorCode.CommandTextIsError - 0x00010105)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  ��ȡָ�����͵����ݼ���ʧ��ʱ���������쳣���������쳣���쳣��������InnerException��
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   δ�����쳣
        /// </exception>
        /// ǰ������
        /// ����Ĳ���entity��filterProterties������Ϊ��
        /// orderBy����Ϊ�գ����Ϊ���򲻽�������
        public IList<T> GetList<T>(T entity, string[] filterProterties, params SortInfo[] orderBy)
            where T : new()
        {
            //���Դ����entity����Ϊnull����Ϊ���ַ��������ֿ������쳣
            PreconditionAssert.IsNotNull(entity, ErrorMessages.NullReferenceException);
            PreconditionAssert.IsNotNull(filterProterties, ErrorMessages.NullReferenceException);
            //���Դ����filterProtertiesΪnull����Ϊ���ַ���ʱ������sql�������쳣
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
                    case DatabaseErrorCode.ConnectDbServerError: //�������ݿ������ʧ��
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
        /// ���ݱ��ʽ����ѯ���󼯺�
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="criteria">���ʽ</param>
        /// <param name="orderBy">����</param>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// ���������쳣������������������쳣,���������InnerException��
        /// �����entity����Ϊnull�����ֿ������쳣��RErrorCode.NullReference - 0x00000001��
        /// �����filterProtertiesΪnull����Ϊ���ַ���ʱ������sql�������쳣(DatabaseErrorCode.CommandTextIsError - 0x00010105)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  ��ȡָ�����͵����ݼ���ʧ��ʱ���������쳣���������쳣���쳣��������InnerException��
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   δ�����쳣
        /// </exception>
        /// <returns>ָ�����͵����ݼ���</returns>
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
                    case DatabaseErrorCode.ConnectDbServerError: //�������ݿ������ʧ��
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
        /// ͨ��ָ������,��������������ʽ�����ݿ��л�ȡ��ָ�����͵���������
        /// </summary>
        /// <typeparam name="T">ָ������</typeparam>
        /// <param name="entity">ʵ�����</param>
        /// <param name="filterProterties">��������</param>
        /// <param name="orderBy">����ʽ</param>
        /// <returns>ָ�����͵���������</returns>
        /// <exception cref="RErrorCode.ArgmentesError - 0x00000014">
        /// ���������쳣������������������쳣,���������InnerException��
        /// �����entity����Ϊnull����Ϊ���ַ��������ֿ������쳣��RErrorCode.NullReference - 0x00000001��
        /// �����filterProtertiesΪnull����Ϊ���ַ���ʱ������sql�������쳣(DatabaseErrorCode.CommandTextIsError - 0x00010105)
        /// </exception>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  ��ȡָ�����͵����ݼ���ʧ��ʱ���������쳣���������쳣���쳣��������InnerException��
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   δ�����쳣
        /// </exception>
        /// ǰ������
        /// ����Ĳ���entity������Ϊ��
        /// filterProterties,orderBy����Ϊ�գ����Ϊ����û��where������ѯ�Ͳ���������
        public int GetCount(object entity, string[] filterProterties)
        {
            //���Դ����entity����Ϊnull����Ϊ���ַ��������ֿ������쳣
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
                    case DatabaseErrorCode.ConnectDbServerError:    // �������ݿ������ʧ��
                    case DatabaseErrorCode.ExecDbCommandError:      // ִ��SQL��������ʧ��
                        // ������ѯʵ������쳣(DatabaseErrorCode.SelectEntityError)
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
        /// ��ȡ���ݿ������е���������
        /// </summary>
        /// <typeparam name="T">ָ������</typeparam>
        /// <returns>��������</returns>
        /// <exception cref="DatabaseErrorCode.ExecDbCommandError - 0x00010002">
        ///  ��ȡָ�����͵���������ʧ��ʱ���������쳣���������쳣���쳣��������InnerException��
        /// </exception>
        /// <exception cref="RErrorCode.None">
        ///   δ�����쳣
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
                    case DatabaseErrorCode.ConnectDbServerError:    // �������ݿ������ʧ��
                    case DatabaseErrorCode.ExecDbCommandError:      // ִ��SQL��������ʧ��
                        // ������ѯʵ������쳣(DatabaseErrorCode.SelectEntityError)
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
    /// ������Ϣ
    /// </summary>
    public class SortInfo
    {
        /// <summary>
        /// ͨ��������ֶ���ȷ��Ҫ�������,��ʼ���������ʵ��
        /// </summary>
        /// <param name="propertyName">ָ����Ҫ������������ƣ�������Ϊnull��մ�</param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// ���¼���������������쳣��
        /// 1.�����propertyNameΪnull��մ�ʱ��
        /// </exception>
        public SortInfo(string propertyName)
            : this(propertyName, SortDirection.Asc)
        {
        }

        /// <summary>
        /// ͨ��������ֶ����ƺ�����ʽȷ��Ҫ������к�����ķ�ʽ,��ʼ���������ʵ��
        /// </summary>
        /// <param name="propertyName">Ҫ������������ƣ�������Ϊnull��մ�</param>
        /// <param name="direction">������</param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// ���¼���������������쳣��
        /// 1.�����propertyNameΪnull��մ�ʱ��
        /// </exception>
        public SortInfo(string propertyName, SortDirection direction)
        {
            PropertyName = propertyName;
            Direction = direction;
        }

        /// <summary>
        /// Ҫ�������������
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public SortDirection Direction { get; set; }
    }

    /// <summary>
    /// ������
    /// </summary>
    public enum SortDirection : int
    {
        /// <summary>
        /// ����
        /// </summary>
        Asc,
        /// <summary>
        /// ����
        /// </summary>
        Desc
    }
}