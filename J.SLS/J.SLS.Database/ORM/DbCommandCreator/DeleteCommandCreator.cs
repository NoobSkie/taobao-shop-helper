using System;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using J.SLS.Database.DBAccess;
using J.SLS.Common;
using System.Linq;

namespace J.SLS.Database.ORM
{
    /// <summary>
    /// �õ�ɾ�����ݿ�����DbCommand
    /// </summary>
    internal class DeleteCommandCreator : DbCommandCreator
    {

        /// <summary>
        /// ��Ҫ�޸ĵ�ʵ����󣬲���Ϊ��
        /// </summary>
        public object Entity { get; set; }


        /// <summary>
        /// ��ʼ��DeleteCommandCreator��dbAccess����Ϊ��
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// �����dbAccessΪ�գ��������쳣
        /// </exception>
        /// <param name="dbAccess">���ݿ���ʽӿ�</param>
        public DeleteCommandCreator(IDBAccess dbAccess)
        {
            DbAccess = dbAccess;
        }

        /// <summary>
        /// ɾ�����ݿ���ĳһ�����DbCommand��deleteCommandCreator������Entity����Ϊ��
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.CommandTextIsEmpty - 0x00010102)">
        /// ����EntityΪnullʱ���������쳣
        /// </exception>
        /// <returns>ɾ�����ݿ���ĳһ�����DbCommand��DbCommand�Ĳ���Ϊ�������Entity������</returns>
        public override DbCommand GetDbCommand()
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(Entity.GetType());
            List<PropertyInfo> fieldPropertyList = null;
            string sqlDelete = string.Format("DELETE FROM {0} {1}"
                , GetQuotedName(entityInfo.MappingTableAttribute.TableName)
                , GetDeleteStatement(entityInfo,out fieldPropertyList));
            DbCommand dbCommand = GetDbCommandByEntity(fieldPropertyList, Entity);
            dbCommand.CommandText = sqlDelete;
            return dbCommand;
        }

        private string GetDeleteStatement(TypeSchema entityInfo,out List<PropertyInfo> fieldPropertyList)
        {
            string query = "";
            fieldPropertyList = new List<PropertyInfo>();
            foreach (SchemaItem mfi in entityInfo.GetKeyFieldInfos())
            {
                if (query != "") query += " AND ";
                query += GetQuotedName(mfi.MappingFieldAttribute.FieldName) + "=@" + mfi.ProInfo.Name;
                fieldPropertyList.Add(mfi.ProInfo);
            }
            return string.Format("WHERE {0}", query);
        }

    }
}