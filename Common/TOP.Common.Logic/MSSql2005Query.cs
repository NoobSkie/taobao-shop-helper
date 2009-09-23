using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;
using System.IO;
using System.Reflection;

namespace TOP.Common.Logic
{
    public class MSSql2005Query : DbQuery
    {
        public override string GenerateCreateViewSql(Type infoType, string baseDir)
        {
            if (!infoType.IsSubclassOf(typeof(FacadeInfoBase)))
            {
                throw new ArgumentException("必须是TOP.Common.Logic.FacadeBase类型的对象才能执行此操作。 - " + infoType.FullName);
            }
            DbTableAttribute[] attrs = (DbTableAttribute[])infoType.GetCustomAttributes(typeof(DbTableAttribute), true);
            if (attrs.Length == 0)
            {
                return string.Empty;
            }
            if (attrs[0].DbObjectType == DbObjectType.View)
            {
                if (string.IsNullOrEmpty(baseDir))
                {
                    baseDir = Directory.GetCurrentDirectory();
                }
                string sqlScriptFilePath = string.Format(@"{0}\Views\MSSqlServer2005\V_Create_{1}.sql", baseDir, attrs[0].DbTableName);
                if (File.Exists(sqlScriptFilePath))
                {
                    using (StreamReader reader = new StreamReader(sqlScriptFilePath))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                throw new ArgumentException("必须是视图类型的数据库对象才能执行此操作。 - " + attrs[0].DbObjectType.ToString());
            }
        }

        public override string GenerateDropViewSql(Type infoType, string baseDir)
        {
            if (!infoType.IsSubclassOf(typeof(FacadeInfoBase)))
            {
                throw new ArgumentException("必须是TOP.Common.Logic.FacadeBase类型的对象才能执行此操作。 - " + infoType.FullName);
            }
            DbTableAttribute[] attrs = (DbTableAttribute[])infoType.GetCustomAttributes(typeof(DbTableAttribute), true);
            if (attrs.Length == 0)
            {
                return string.Empty;
            }
            if (attrs[0].DbObjectType == DbObjectType.View)
            {
                if (string.IsNullOrEmpty(baseDir))
                {
                    baseDir = Directory.GetCurrentDirectory();
                }
                string sqlScriptFilePath = string.Format(@"{0}\Views\MSSqlServer2005\V_Drop_{1}.sql", baseDir, attrs[0].DbTableName);
                if (File.Exists(sqlScriptFilePath))
                {
                    using (StreamReader reader = new StreamReader(sqlScriptFilePath))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                throw new ArgumentException("必须是视图类型的数据库对象才能执行此操作。 - " + attrs[0].DbObjectType.ToString());
            }
        }

        public override string GenerateSelectViewSql(Type infoType)
        {
            if (!infoType.IsSubclassOf(typeof(FacadeInfoBase)))
            {
                throw new ArgumentException("必须是TOP.Common.Logic.FacadeBase类型的对象才能执行此操作。 - " + infoType.FullName);
            }
            DbTableAttribute[] attrs = (DbTableAttribute[])infoType.GetCustomAttributes(typeof(DbTableAttribute), true);
            if (attrs.Length == 0)
            {
                return string.Empty;
            }
            if (attrs[0].DbObjectType == DbObjectType.View)
            {
                string tableName = attrs[0].DbTableName;
                string keyFieldName = string.Empty;
                StringBuilder sqlSelect = new StringBuilder();
                sqlSelect.AppendLine("SELECT 'ViewRow' AS [RowType]");
                foreach (PropertyInfo prop in infoType.GetProperties())
                {
                    foreach (DbFieldAttribute attr in prop.GetCustomAttributes(typeof(DbFieldAttribute), true))
                    {
                        sqlSelect.AppendLine(string.Format(", [{0}]", attr.DbFieldName));
                    }
                }
                sqlSelect.AppendLine(string.Format("FROM [{0}]", tableName));

                return sqlSelect.ToString();
            }
            else
            {
                throw new ArgumentException("必须是视图类型的数据库对象才能执行此操作。 - " + attrs[0].DbObjectType.ToString());
            }
        }

        public override string GenerateCountViewSql(Type infoType)
        {
            if (!infoType.IsSubclassOf(typeof(FacadeInfoBase)))
            {
                throw new ArgumentException("必须是TOP.Common.Logic.FacadeBase类型的对象才能执行此操作。 - " + infoType.FullName);
            }
            DbTableAttribute[] attrs = (DbTableAttribute[])infoType.GetCustomAttributes(typeof(DbTableAttribute), true);
            if (attrs.Length == 0)
            {
                return string.Empty;
            }
            if (attrs[0].DbObjectType == DbObjectType.View)
            {
                string tableName = attrs[0].DbTableName;
                return string.Format("SELECT COUNT(1) AS [RowCount] FROM [{0}] ", tableName);
            }
            else
            {
                throw new ArgumentException("必须是视图类型的数据库对象才能执行此操作。 - " + attrs[0].DbObjectType.ToString());
            }
        }
    }
}
