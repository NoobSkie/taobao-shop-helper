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
    /// <summary>
    /// DbCommand�������ĳ����࣬��������DbCommand���ࡣ
    /// �����ṩ������DbCommand�Ļ���������
    /// </summary>
    /// <remarks>Craeted by HQ, 2010/3/8</remarks>
    internal abstract class DbCommandCreator
    {
        protected IDBAccess DbAccess { get; set; }

        public abstract DbCommand GetDbCommand();

        protected DbCommand GetDbCommandByKeyValue(TypeSchema entityInfo, object keyValue)
        {
            DbCommand dbCommand = DbAccess.CreateDbCommand();

            foreach (SchemaItem mfi in entityInfo.GetKeyFieldInfos())
            {
                Type type = mfi.ProInfo.PropertyType;
                type = Nullable.GetUnderlyingType(type) ?? type;
                DbType dbType = ORMHelper.GetDbTypeByName(type.Name);
                DbParameter parameter = DbAccess.CreateDbParameter();
                parameter.ParameterName = "@" + mfi.ProInfo.Name;
                parameter.DbType = dbType;

                //parameter.Value = Convert.ChangeType(keyValue, fieldProperty.PropertyType);
                parameter.Value = Convert.ChangeType(keyValue, type);
                dbCommand.Parameters.Add(parameter);
            }
            return dbCommand;
        }

        protected DbCommand GetDbCommandByEntity(List<PropertyInfo> fieldPropertyList, object entity)
        {
            DbCommand dbCommand = DbAccess.CreateDbCommand();

            foreach (PropertyInfo fieldProperty in fieldPropertyList)
            {
                DbParameter parameter = GetDbParameter(fieldProperty, entity);
                dbCommand.Parameters.Add(parameter);
            }
            return dbCommand;
        }

        protected DbParameter GetDbParameter(PropertyInfo fieldProperty, object entity)
        {
            DbParameter parameter = DbAccess.CreateDbParameter();
            Type tempType = fieldProperty.PropertyType;

            if (Nullable.GetUnderlyingType(tempType) != null)//����� int? ��������д��� 
            {
                tempType = Nullable.GetUnderlyingType(tempType);
            }

            parameter.ParameterName = "@" + fieldProperty.Name;
            parameter.DbType = ORMHelper.GetDbTypeByName(tempType.Name);

            if (fieldProperty.GetValue(entity, null) == null)//������������Ϊnull����Ѵ˲�������ΪDBNull
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = fieldProperty.GetValue(entity, null);
            }

            return parameter;
        }

        protected string GetQuotedName(string objName)
        {
            // ���磺[TableName]
            return DbAccess.GetDbObjectName(objName);
        }
    }
}