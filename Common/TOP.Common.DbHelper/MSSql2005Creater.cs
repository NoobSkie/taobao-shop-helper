using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TOP.Common.DbHelper
{
    public class MSSql2005Creater : DbSqlCreater
    {
        public override string GenerateCreateTableSql(Type entityType)
        {
            if (!entityType.IsSubclassOf(typeof(DbEntity)))
            {
                throw new ArgumentException("必须是TOP.Common.DbHelper.DbEntity类型的对象才能执行此操作。 - " + entityType.FullName);
            }
            DbTableAttribute[] attrs = (DbTableAttribute[])entityType.GetCustomAttributes(typeof(DbTableAttribute), true);
            if (attrs.Length == 0)
            {
                return string.Empty;
            }
            if (attrs[0].DbObjectType == DbObjectType.Table)
            {
                string tableName = attrs[0].DbTableName;
                string keyFieldName = string.Empty;
                StringBuilder sqlFields = new StringBuilder();
                foreach (PropertyInfo prop in entityType.GetProperties())
                {
                    foreach (DbFieldAttribute attr in prop.GetCustomAttributes(typeof(DbFieldAttribute), true))
                    {
                        if (attr.IsKey)
                        {
                            keyFieldName = prop.Name;
                            sqlFields.AppendLine(string.Format("[{1}] [{2}] ROWGUIDCOL NOT NULL CONSTRAINT [DF_{0}_{1}] DEFAULT({3}),", tableName, attr.DbFieldName, attr.DbFieldType.ToString(), attr.DefaultValue));
                        }
                        else
                        {
                            sqlFields.Append(string.Format("[{0}] ", attr.DbFieldName));
                            sqlFields.Append(string.Format("[{0}] ", attr.DbFieldType.ToString()));
                            if (attr.DbFieldType == DbDataType.NVARCHAR)
                            {
                                if (attr.Length == 0)
                                {
                                    sqlFields.Append("(MAX) ");
                                }
                                else
                                {
                                    sqlFields.Append(string.Format("({0}) ", attr.Length));
                                }
                            }
                            if (attr.IsNotNull)
                            {
                                sqlFields.Append("NOT ");
                            }
                            sqlFields.Append("NULL ");
                            if (!string.IsNullOrEmpty(attr.DefaultValue))
                            {
                                if (attr.DbFieldType == DbDataType.NVARCHAR)
                                {
                                    sqlFields.Append(string.Format("DEFAULT('{0}') ", attr.DefaultValue));
                                }
                                else
                                {
                                    sqlFields.Append(string.Format("DEFAULT({0}) ", attr.DefaultValue));
                                }
                            }
                            sqlFields.AppendLine(",");
                        }
                    }
                }

                StringBuilder sqlCreate = new StringBuilder();
                sqlCreate.AppendLine(string.Format("CREATE TABLE [{0}]", tableName));
                sqlCreate.AppendLine("(");
                sqlCreate.Append(sqlFields.ToString());
                sqlCreate.AppendLine(string.Format("CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED", tableName));
                sqlCreate.AppendLine("(");
                sqlCreate.AppendLine(string.Format("[{0}] ASC", keyFieldName));
                sqlCreate.AppendLine(")");
                sqlCreate.AppendLine(")");

                return sqlCreate.ToString();
            }
            else
            {
                throw new ArgumentException("必须是表类型的数据库对象才能执行此操作。 - " + attrs[0].DbObjectType.ToString());
            }
        }

        public override string GenerateDropTableSql(Type entityType)
        {
            if (!entityType.IsSubclassOf(typeof(DbEntity)))
            {
                throw new ArgumentException("必须是TOP.Common.DbHelper.DbEntity类型的对象才能执行此操作。 - " + entityType.FullName);
            }
            DbTableAttribute[] attrs = (DbTableAttribute[])entityType.GetCustomAttributes(typeof(DbTableAttribute), true);
            if (attrs.Length == 0)
            {
                return string.Empty;
            }
            if (attrs[0].DbObjectType == DbObjectType.Table)
            {
                string tableName = attrs[0].DbTableName;

                StringBuilder sqlDrop = new StringBuilder();
                sqlDrop.AppendLine(string.Format("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U'))", tableName));
                sqlDrop.AppendLine(string.Format("DROP TABLE [{0}]", tableName));

                return sqlDrop.ToString();
            }
            else
            {
                throw new ArgumentException("必须是表类型的数据库对象才能执行此操作。 - " + attrs[0].DbObjectType.ToString());
            }
        }

        public override string GenerateInsertSql(DbEntity entity)
        {
            Type entityType = entity.GetType();
            if (!entityType.IsSubclassOf(typeof(DbEntity)))
            {
                throw new ArgumentException("必须是TOP.Common.DbHelper.DbEntity类型的对象才能执行此操作。 - " + entityType.FullName);
            }
            DbTableAttribute[] attrs = (DbTableAttribute[])entityType.GetCustomAttributes(typeof(DbTableAttribute), true);
            if (attrs.Length == 0)
            {
                return string.Empty;
            }
            if (attrs[0].DbObjectType == DbObjectType.Table)
            {
                string tableName = attrs[0].DbTableName;

                StringBuilder sqlInsert = new StringBuilder();
                sqlInsert.AppendLine(string.Format("INSERT INTO [{0}]", tableName));
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (PropertyInfo prop in entityType.GetProperties())
                {
                    if (prop.Name.Equals("CreateDate", StringComparison.OrdinalIgnoreCase))
                    {
                        values.Add("CreateDate", "GetDate()");
                        continue;
                    }
                    else if (prop.Name.Equals("LastUpdateDate", StringComparison.OrdinalIgnoreCase))
                    {
                        values.Add("LastUpdateDate", "GetDate()");
                        continue;
                    }
                    else if (prop.Name.Equals("CurrentVersion", StringComparison.OrdinalIgnoreCase))
                    {
                        values.Add("CurrentVersion", "1");
                        continue;
                    }
                    foreach (DbFieldAttribute attr in prop.GetCustomAttributes(typeof(DbFieldAttribute), true))
                    {
                        object value = prop.GetValue(entity, null);
                        if (attr.IsKey)
                        {
                            if (value != null && !string.IsNullOrEmpty(value.ToString()) && value.ToString() != Guid.Empty.ToString())
                            {
                                values.Add(attr.DbFieldName, "N'" + value.ToString() + "'");
                            }
                            else
                            {
                                values.Add(attr.DbFieldName, "N'" + Guid.NewGuid().ToString() + "'");
                            }
                        }
                        else
                        {
                            if (value == null)
                            {
                                values.Add(attr.DbFieldName, "NULL");
                            }
                            else
                            {
                                switch (attr.DbFieldType)
                                {
                                    case DbDataType.UNIQUEIDENTIFIER:
                                        values.Add(attr.DbFieldName, "N'" + value.ToString() + "'");
                                        break;
                                    case DbDataType.NVARCHAR:
                                        values.Add(attr.DbFieldName, "N'" + value.ToString().Replace("'", "''") + "'");
                                        break;
                                    case DbDataType.DATETIME:
                                        values.Add(attr.DbFieldName, "'" + value.ToString() + "'");
                                        break;
                                    case DbDataType.INT:
                                        values.Add(attr.DbFieldName, ((int)value).ToString());
                                        break;
                                    case DbDataType.BIT:
                                        values.Add(attr.DbFieldName, "'" + value.ToString() + "'");
                                        break;
                                    default:
                                        throw new ArgumentException("未能处理该类型的字段。 - " + attr.DbFieldType.ToString());
                                }
                            }
                        }
                    }
                }

                string fields = string.Empty;
                string sets = string.Empty;
                foreach (KeyValuePair<string, string> value in values)
                {
                    fields += value.Key + ",";
                    sets += value.Value + ",";
                }
                fields = fields.TrimEnd(',');
                sets = sets.TrimEnd(',');

                sqlInsert.AppendLine("(" + fields + ")");
                sqlInsert.Append("VALUES(" + sets + ")");

                return sqlInsert.ToString();
            }
            else
            {
                throw new ArgumentException("必须是表类型的数据库对象才能执行此操作。 - " + attrs[0].DbObjectType.ToString());
            }
        }

        public override string GenerateDeleteSql(DbEntity entity)
        {
            Type entityType = entity.GetType();
            if (!entityType.IsSubclassOf(typeof(DbEntity)))
            {
                throw new ArgumentException("必须是TOP.Common.DbHelper.DbEntity类型的对象才能执行此操作。 - " + entityType.FullName);
            }
            DbTableAttribute[] attrs = (DbTableAttribute[])entityType.GetCustomAttributes(typeof(DbTableAttribute), true);
            if (attrs.Length == 0)
            {
                return string.Empty;
            }
            if (attrs[0].DbObjectType == DbObjectType.Table)
            {
                string tableName = attrs[0].DbTableName;
                return string.Format("UPDATE [{0}] SET [CurrentVersion] = 0, [LastUpdateDate] = GetDate(), [LastUpdateUserId] = '{1}' WHERE [Id] = '{2}' AND [CurrentVersion] = {3}"
                    , tableName
                    , entity.LastUpdateUserId
                    , entity.Id
                    , entity.CurrentVersion);
            }
            else
            {
                throw new ArgumentException("必须是表类型的数据库对象才能执行此操作。 - " + attrs[0].DbObjectType.ToString());
            }
        }

        public override string GenerateUpdateSql(DbEntity entity, params string[] fieldsNeedUpdate)
        {
            Type entityType = entity.GetType();
            if (!entityType.IsSubclassOf(typeof(DbEntity)))
            {
                throw new ArgumentException("必须是TOP.Common.DbHelper.DbEntity类型的对象才能执行此操作。 - " + entityType.FullName);
            }
            DbTableAttribute[] attrs = (DbTableAttribute[])entityType.GetCustomAttributes(typeof(DbTableAttribute), true);
            if (attrs.Length == 0)
            {
                return string.Empty;
            }
            if (attrs[0].DbObjectType == DbObjectType.Table)
            {
                string tableName = attrs[0].DbTableName;

                StringBuilder sqlUpdate = new StringBuilder();
                sqlUpdate.AppendLine(string.Format("UPDATE [{0}]", tableName));
                sqlUpdate.AppendLine("SET [CreateDate] = [CreateDate]");
                foreach (PropertyInfo prop in entityType.GetProperties())
                {
                    if (prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    else if (prop.Name.Equals("CreateDate", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    else if (prop.Name.Equals("CreateUserId", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    else if (prop.Name.Equals("LastUpdateDate", StringComparison.OrdinalIgnoreCase))
                    {
                        sqlUpdate.AppendLine(", [LastUpdateDate] = GetDate()");
                        continue;
                    }
                    else if (prop.Name.Equals("CurrentVersion", StringComparison.OrdinalIgnoreCase))
                    {
                        sqlUpdate.AppendLine(", [CurrentVersion] = [CurrentVersion] + 1");
                        continue;
                    }
                    foreach (DbFieldAttribute attr in prop.GetCustomAttributes(typeof(DbFieldAttribute), true))
                    {
                        if (!attr.IsKey)
                        {
                            if (fieldsNeedUpdate != null && fieldsNeedUpdate.Length > 0)
                            {
                                if (!prop.Name.Equals("LastUpdateUserId") && !fieldsNeedUpdate.Contains(prop.Name))
                                {
                                    continue;
                                }
                            }
                            object value = prop.GetValue(entity, null);
                            if (value != null)
                            {
                                if (value.ToString().Equals("null", StringComparison.OrdinalIgnoreCase))
                                {
                                    sqlUpdate.AppendLine(string.Format(", [{0}] = NULL", attr.DbFieldName));
                                }
                                else
                                {
                                    switch (attr.DbFieldType)
                                    {
                                        case DbDataType.UNIQUEIDENTIFIER:
                                            sqlUpdate.AppendLine(string.Format(", [{0}] = N'{1}'", attr.DbFieldName, value.ToString()));
                                            break;
                                        case DbDataType.NVARCHAR:
                                            sqlUpdate.AppendLine(string.Format(", [{0}] = N'{1}'", attr.DbFieldName, value.ToString().Replace("'", "''")));
                                            break;
                                        case DbDataType.DATETIME:
                                            sqlUpdate.AppendLine(string.Format(", [{0}] = N'{1}'", attr.DbFieldName, value.ToString()));
                                            break;
                                        case DbDataType.INT:
                                            sqlUpdate.AppendLine(string.Format(", [{0}] = {1}", attr.DbFieldName, ((int)value).ToString()));
                                            break;
                                        case DbDataType.BIT:
                                            sqlUpdate.AppendLine(string.Format(", [{0}] = N'{1}'", attr.DbFieldName, value.ToString()));
                                            break;
                                        default:
                                            throw new ArgumentException("未能处理该类型的字段。 - " + attr.DbFieldType.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                sqlUpdate.AppendLine(string.Format("WHERE [Id] = '{0}' AND [CurrentVersion] = {1}", entity.Id, entity.CurrentVersion));

                return sqlUpdate.ToString();
            }
            else
            {
                throw new ArgumentException("必须是表类型的数据库对象才能执行此操作。 - " + attrs[0].DbObjectType.ToString());
            }
        }
    }
}
