using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.Common;
using LHBIS.Database.DBAccess;

namespace LHBIS.Database.ORM
{
    internal class OrExpression : ExpressionCollection
    {
        public OrExpression(params Expression[] expressions)
            : base("OR",expressions)
        {
        }
    }

    internal class AndExpression : ExpressionCollection
    {
        public AndExpression(params Expression[] expressions)
            : base("AND",expressions)
        {
        }
    }
}
