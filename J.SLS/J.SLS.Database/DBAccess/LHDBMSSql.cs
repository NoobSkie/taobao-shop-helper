using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using J.SLS.Common;

namespace J.SLS.Database.DBAccess
{
    [Serializable]
    internal class LHDBMSSql : LHDBAccess
    {
        public LHDBMSSql(string constr) : base(constr) { }

        protected override DbProviderFactory Factory
        {
            get { return SqlClientFactory.Instance; }
        }

        protected override string GetParamPlaceHolder(int paramindex)
        {
            return "@p" + paramindex.ToString();
        }
    }
}
