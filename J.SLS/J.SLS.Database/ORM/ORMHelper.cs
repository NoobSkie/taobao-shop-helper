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
    public class ORMHelper
    {
        internal static DbType GetDbTypeByName(string typeName)
        {
            DbType dbType;
            // 根据数据的数据类型，获取对应数据库字段类型
            switch (typeName)
            {
                case "Byte[]":
                    dbType = DbType.Binary;
                    break;
                default:
                    dbType = (DbType)Enum.Parse(typeof(DbType), typeName, true);
                    break;
            }
            return dbType;
        }

        internal static void CheckEntityKey(object entity)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(entity.GetType());
            foreach (SchemaItem mfi in entityInfo.GetKeyFieldInfos())
            {
                if (mfi.ProInfo.GetValue(entity, null) == null)
                {
                    throw new ORMException(ErrorMessages.PrimaryKeyIsNull);
                }
            }
        }

        internal static string GetEntityInfoMessage(object entity)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(entity.GetType());
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.AppendLine("Entity Type: " + entity.GetType().FullName);
            foreach (SchemaItem mfi in entityInfo.GetAllFieldInfos())
            {
                PropertyInfo property = mfi.ProInfo;
                infoBuilder.AppendLine("[" + property.Name + "]: " + property.GetValue(entity, null));
            }
            return infoBuilder.ToString();
        }

        internal static string GetOrderInfoMessage(SortInfo[] orderBy)
        {
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.AppendLine("Order Field Number: " + (orderBy == null ? "0" : orderBy.Length.ToString()));
            if (orderBy != null)
            {
                foreach (SortInfo sort in orderBy)
                {
                    if (sort == null)
                    {
                        infoBuilder.AppendLine("null");
                    }
                    else
                    {
                        infoBuilder.AppendLine(sort.PropertyName + "[" + sort.Direction.ToString() + "]");
                    }
                }
            }
            return infoBuilder.ToString();
        }

        internal static string GetCriteriaMessage(Criteria criteria)
        {
            StringBuilder infoBuilder = new StringBuilder();
            foreach (Expression exp in criteria._expressionList)
            {
                if (exp == null)
                {
                    infoBuilder.AppendLine("null");
                }
                else
                {
                    infoBuilder.AppendLine(exp.GetDescription());
                }
            }
            return infoBuilder.ToString();
        }

        public static IList<T> DataTableToList<T>(DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T t = ConvertDataRowToEntity<T>(dataTable.Rows[i]);
                list.Add(t);
            }
            return list;
        }

        public static T ConvertDataRowToEntity<T>(DataRow dataRow) where T : new()
        {
            PreconditionAssert.IsNotNull(dataRow, ErrorMessages.NullReferenceException);

            T tempT = new T();
            Type entityType = typeof(T);
            string fieldName;
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(entityType);
            foreach (SchemaItem mfi in entityInfo.GetAllFieldInfos())
            {
                fieldName = mfi.MappingFieldAttribute.FieldName;
                if (string.IsNullOrEmpty(fieldName))
                    continue;

                if (dataRow.Table.Columns.Contains(fieldName))
                {
                    if (dataRow[fieldName].Equals(DBNull.Value))
                    {
                        mfi.ProInfo.SetValue(tempT, null, null);
                    }
                    else
                    {
                        Type type = Nullable.GetUnderlyingType(mfi.ProInfo.PropertyType) ?? mfi.ProInfo.PropertyType;
                        mfi.ProInfo.SetValue(tempT, Convert.ChangeType(dataRow[fieldName], type), null);
                    }
                }
            }
            return tempT;
        }

        internal static void EntityIsMappingDatabase(Type type, string message)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(type);

            if (entityInfo.MappingTableAttribute == null)
            {
                throw new ORMException(message);
            }

            if (entityInfo.GetKeyFieldInfos() == null || entityInfo.GetKeyFieldInfos().Count == 0)
            {
                throw new ORMException(message);
            }
        }

        internal static void CheckEntityIsNotReadOnly(Type type, string message)
        {
            object[] tableAttr = type.GetCustomAttributes(typeof(EntityMappingTableAttribute), true);
            EntityMappingTableAttribute attr = tableAttr[0] as EntityMappingTableAttribute;
            if (attr == null || attr.ReadOnly == true)
            {
                throw new ORMException(message);
            }
        }
    }
}