using System;
using System.Data.Common;
using System.Data.OleDb;

namespace J.SLS.Database.DBAccess
{
    [Serializable]
    internal class LHDBOleDB : LHDBAccess
    {
        public LHDBOleDB(string constr) : base(constr) { }

        protected override DbProviderFactory Factory
        {
            get { return OleDbFactory.Instance; }
        }

        protected override string GetParamPlaceHolder(int paramindex)
        {
            return "?";
        }
    }
}
