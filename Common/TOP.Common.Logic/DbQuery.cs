using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;
using System.IO;
using System.Reflection;

namespace TOP.Common.Logic
{
    public abstract class DbQuery : IQuery
    {
        public static DbQuery GetDbQuery(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.MSSqlServer2005:
                    return new MSSql2005Query();
                default:
                    throw new ArgumentException("不支持此数据库类型。 - " + dbType.ToString());
            }
        }

        public abstract string GenerateCreateViewSql(Type infoType, string baseDir);

        public abstract string GenerateDropViewSql(Type infoType, string baseDir);

        public abstract string GenerateSelectViewSql(Type infoType);

        public abstract string GenerateCountViewSql(Type infoType);
    }
}
