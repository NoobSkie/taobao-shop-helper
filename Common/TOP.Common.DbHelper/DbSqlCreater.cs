using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.DbHelper
{
    public abstract class DbSqlCreater : ISqlCreater
    {
        public static DbSqlCreater GetDbSqlCreater(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.MSSqlServer2005:
                    return new MSSql2005Creater();
                default:
                    throw new ArgumentException("不支持此数据库类型。 - " + dbType.ToString());
            }
        }

        #region ISqlCreater Members

        public abstract string GenerateCreateTableSql(Type entityType);

        public abstract string GenerateDropTableSql(Type entityType);

        public abstract string GenerateInsertSql(DbEntity entity);

        public abstract string GenerateDeleteSql(DbEntity entity);

        public abstract string GenerateUpdateSql(DbEntity entity);

        #endregion
    }
}
