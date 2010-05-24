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
    /// 得到修改数据库对象的DbCommand
    /// </summary>
    internal class ModifyCommandCreator : DbCommandCreator
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
        public ModifyCommandCreator(IDBAccess dbAccess)
        {
            DbAccess = dbAccess;
        }

        /// <summary>
        /// 得到修改数据库中某一对象的DbCommand，modifyCommandCreator的属性Entity不能为空
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.CommandTextIsEmpty - 0x00010102)">
        /// 属性Entity为null时，引发此异常
        /// </exception>
        /// <returns>修改数据库中某一对象的DbCommand，DbCommand的参数为所传入的Entity的属性</returns>
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