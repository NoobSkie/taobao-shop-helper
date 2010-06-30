using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using J.SLS.Database.DBAccess;

namespace J.SLS.TestTool
{
    public class DataInitHelper
    {
        public delegate int ActionSql(string sql, params string[] args);

        public static void InitTestData(string fileName, IDBAccess dbAccess)
        {
            ForeachSQLFromFile(fileName, dbAccess.ExecSQL);
        }

        public static void ForeachSQLFromFile(string fileName, ActionSql action)
        {
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                string baseDir = Path.GetDirectoryName(fileName);
                string sql = sr.ReadLine().Trim();
                StringBuilder sbuilder = new StringBuilder();
                string separator = "\\N";
                while (sql != null)
                {
                    sql = sql.Trim();
                    if (sql.Length > 0)
                    {
                        if (sql.StartsWith("#split<", StringComparison.OrdinalIgnoreCase)
                            && sql.EndsWith(">"))
                        {
                            DoActionSql(ref sbuilder, action);
                            separator = sql.Substring("#split<".Length, sql.Length - "#split<".Length - 1);
                        }
                        else if (sql.StartsWith("#include<", StringComparison.OrdinalIgnoreCase)
                            && sql.EndsWith(">"))
                        {
                            DoActionSql(ref sbuilder, action);
                            string subFileName = sql.Substring("#include<".Length, sql.Length - "#include<".Length - 1);
                            ForeachSQLFromFile(Path.Combine(baseDir, subFileName), action);
                        }
                        else
                        {
                            if (separator.Equals("\\N", StringComparison.OrdinalIgnoreCase))
                            {
                                sbuilder.AppendLine(sql);
                                DoActionSql(ref sbuilder, action);
                            }
                            else
                            {
                                if (!sql.Equals(separator, StringComparison.OrdinalIgnoreCase))
                                {
                                    sbuilder.AppendLine(sql);
                                }
                                else
                                {
                                    DoActionSql(ref sbuilder, action);
                                }
                            }
                        }
                    }
                    sql = sr.ReadLine();
                }
                DoActionSql(ref sbuilder, action);
            }
        }

        private static void DoActionSql(ref StringBuilder sqlBuilder, ActionSql action)
        {
            if (sqlBuilder.ToString().Length > 0)
            {
                action(sqlBuilder.ToString());
                sqlBuilder = new StringBuilder();
            }
        }
    }
}
