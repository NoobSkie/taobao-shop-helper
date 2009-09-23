using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.DbHelper
{
    public interface ISqlCreater
    {
        string GenerateCreateTableSql(Type entityType);

        string GenerateDropTableSql(Type entityType);

        string GenerateInsertSql(DbEntity entity);

        string GenerateDeleteSql(DbEntity entity);

        string GenerateUpdateSql(DbEntity entity);
    }
}
