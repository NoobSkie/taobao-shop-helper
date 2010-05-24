using System;
using J.SLS.Common;

namespace J.SLS.Database.DBAccess
{
    public static class LHDBFactory
    {
        public static ILHDBTran BeginTransaction(RDatabaseType dbtype, string constr)
        {
            PreconditionAssert.IsNotNullOrEmpty(constr, ErrorMessages.DBConnectionStringIsNullOrEmpty);
            LHDBAccess dbAccess = GetLHDBAccess(dbtype, constr);
            return new LHDBTran(dbAccess);
        }

        public static ILHDBAccess CreateDBAccessInstance(RDatabaseType dbtype, string constr)
        {
            PreconditionAssert.IsNotNullOrEmpty(constr, ErrorMessages.DBConnectionStringIsNullOrEmpty);
            LHDBAccess dbAccess = GetLHDBAccess(dbtype, constr);
            return dbAccess;
        }

        private static LHDBAccess GetLHDBAccess(RDatabaseType dbtype, string constr)
        {
            switch (dbtype)
            {
                case RDatabaseType.MSSQL:
                    return new LHDBMSSql(constr);
                default:
                    throw new ArgumentException(ErrorMessages.NotSupportedDatabaseType + " - " + dbtype.ToString());
            }
        }
    }
}
