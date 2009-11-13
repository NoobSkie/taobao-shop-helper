using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.DbHelper
{
    public abstract class DbEntityManager<T>
        where T : DbEntity
    {
        protected readonly DbSqlCreater sqlHelper = new MSSql2005Creater();

        public virtual string GetCreateSql(T entity)
        {
            return sqlHelper.GenerateInsertSql(entity);
        }

        public virtual string GetUpdateSql(T entity, params string[] fieldsNeedUpdate)
        {
            return sqlHelper.GenerateUpdateSql(entity, fieldsNeedUpdate);
        }

        public virtual string GetDeleteSql(T entity)
        {
            return sqlHelper.GenerateDeleteSql(entity);
        }
    }
}
