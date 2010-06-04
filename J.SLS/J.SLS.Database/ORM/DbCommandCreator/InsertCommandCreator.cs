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
    /// 得到新增数据库对象的DbCommand
    /// </summary>
    internal class InsertCommandCreator : DbCommandCreator
    {
        /// <summary>
        /// 需要修改的实体对象，不能为空
        /// </summary>
        public object Entity { get; set; }

        /// <summary>
        /// 初始化ModifyCommandCreator，dbAccess不能为空
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 传入的dbAccess为空，引发此异常
        /// </exception>
        /// <param name="dbAccess">数据库访问接口</param>
        public InsertCommandCreator(IDBAccess dbAccess)
        {
            DbAccess = dbAccess;
        }

        /// <summary>
        /// 得到新增数据库中某一对象的DbCommand，modifyCommandCreator的属性Entity不能为空
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.CommandTextIsEmpty - 0x00010102)">
        /// 属性Entity为null时，引发此异常
        /// </exception>
        /// <returns>新增数据库中某一对象的DbCommand，DbCommand的参数为所传入的Entity的属性</returns>
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