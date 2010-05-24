using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.Common;
using J.SLS.Database.DBAccess;

namespace J.SLS.Database.ORM
{

    public class Criteria : ExpressionCollection
    {
        public Criteria() : base("AND") { }

        public Criteria Add(Expression expression)
        {
            base.Add(expression);
            return this;
        }

        internal string GenerateExpression(Type type, out List<DbParameter> parameters, IDBAccess dbAccess)
        {
            this.Init(type, dbAccess);
            parameters = new List<DbParameter>();
            int i = 0;
            return " AND " + this.GenerateSQL(ref parameters, ref i);
        }
    }
}
