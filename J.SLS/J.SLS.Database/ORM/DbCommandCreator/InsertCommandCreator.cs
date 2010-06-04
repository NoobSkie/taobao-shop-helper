using System;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using J.SLS.Database.DBAccess;
using J.SLS.Common;

namespace J.SLS.Database.ORM
{
    /// <summary>
    /// �õ��������ݿ�����DbCommand
    /// </summary>
    internal class InsertCommandCreator : DbCommandCreator
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
        public InsertCommandCreator(IDBAccess dbAccess)
        {
            DbAccess = dbAccess;
        }

        /// <summary>
        /// �õ��������ݿ���ĳһ�����DbCommand��modifyCommandCreator������Entity����Ϊ��
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.CommandTextIsEmpty - 0x00010102)">
        /// ����EntityΪnullʱ���������쳣
        /// </exception>
        /// <returns>�������ݿ���ĳһ�����DbCommand��DbCommand�Ĳ���Ϊ�������Entity������</returns>
        public override DbCommand GetDbCommand()
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(Entity.GetType());
            List<PropertyInfo> fieldPropertyList = null;
            string sqlInsert = string.Format("INSERT INTO {0} {1}"
                , GetQuotedName(entityInfo.MappingTableAttribute.TableName)
                , GetInsertStatement(entityInfo, out fieldPropertyList));

            DbCommand dbCommand = GetDbCommandByEntity(fieldPropertyList, this.Entity);
            dbCommand.CommandText = sqlInsert;
            return dbCommand;
        }

        private string GetInsertStatement(TypeSchema entityInfo, out List<PropertyInfo> fieldPropertyList)
        {
            string fields = "", values = "";
            fieldPropertyList = new List<PropertyInfo>();
            foreach (SchemaItem mfi in entityInfo.GetAllFieldInfos())
            {
                if (mfi.MappingFieldAttribute.IsAutoField) continue;

                if (fields != "") fields += ",";
                if (values != "") values += ",";
                fields += GetQuotedName(mfi.MappingFieldAttribute.FieldName);
                values += "@" + mfi.ProInfo.Name;

                fieldPropertyList.Add(mfi.ProInfo);
            }
            return string.Format("({0}) VALUES ({1})", fields, values);
        }
    }
}