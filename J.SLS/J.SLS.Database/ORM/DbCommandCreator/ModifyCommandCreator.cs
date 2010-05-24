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
    /// �õ��޸����ݿ�����DbCommand
    /// </summary>
    internal class ModifyCommandCreator : DbCommandCreator
    {
        /// <summary>
        /// ��Ҫ�޸ĵ�ʵ����󣬲���Ϊ��
        /// </summary>
        public object Entity { get; set; }

        /// <summary>
        /// ��ʼ��ModifyCommandCreator��dbAccess����Ϊ��
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// �����dbAccessΪ�գ��������쳣
        /// </exception>
        /// <param name="dbAccess">���ݿ���ʽӿ�</param>
        public ModifyCommandCreator(IDBAccess dbAccess)
        {
            DbAccess = dbAccess;
        }

        /// <summary>
        /// �õ��޸����ݿ���ĳһ�����DbCommand��modifyCommandCreator������Entity����Ϊ��
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.CommandTextIsEmpty - 0x00010102)">
        /// ����EntityΪnullʱ���������쳣
        /// </exception>
        /// <returns>�޸����ݿ���ĳһ�����DbCommand��DbCommand�Ĳ���Ϊ�������Entity������</returns>
        public override DbCommand GetDbCommand()
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(Entity.GetType());
            List<PropertyInfo> fieldPropertyList = null;

            string sqlUpdate = string.Format("UPDATE {0} SET {1}"
                , GetQuotedName(entityInfo.MappingTableAttribute.TableName)
                , GetUpdateStatement(entityInfo, out fieldPropertyList));

            DbCommand dbCommand = GetDbCommandByEntity(fieldPropertyList, Entity);
            dbCommand.CommandText = sqlUpdate;
            return dbCommand;
        }

        private string GetUpdateStatement(TypeSchema entityInfo,out List<PropertyInfo> fieldPropertyList)
        {
            fieldPropertyList = new List<PropertyInfo>();
            string sets = "";
            string query = "";
            foreach (SchemaItem mfi in entityInfo.GetKeyFieldInfos())
            {
                if (query != "") query += " AND ";
                query += GetQuotedName(mfi.MappingFieldAttribute.FieldName) + "=@" + mfi.ProInfo.Name;
                fieldPropertyList.Add(mfi.ProInfo);
            }
            foreach (SchemaItem mfi in entityInfo.GetNeedUpdateFieldInfos())
            {
                if (sets != "") sets += ",";
                sets += GetQuotedName(mfi.MappingFieldAttribute.FieldName) + "=@" + mfi.ProInfo.Name;
                fieldPropertyList.Add(mfi.ProInfo);
            }
            return string.Format("{0} WHERE {1}", sets, query);
        }
    }
}