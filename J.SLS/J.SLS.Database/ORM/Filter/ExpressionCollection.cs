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
    public abstract class ExpressionCollection : Expression
    {
        internal List<Expression> _expressionList;
        private readonly string _contactChar;
        private Type _objectType;

        internal ExpressionCollection(string contactChar, params Expression[] initExpressionArray)
        {
            _contactChar = contactChar;
            _expressionList = new List<Expression>(initExpressionArray);
        }

        protected void Add(Expression expression)
        {
            this._expressionList.Add(expression);
        }

        internal override void Init(Type objectType, IDBAccess dbAccess)
        {
            this._objectType = objectType;
            this._dbAccess = dbAccess;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < _expressionList.Count; i++)
            {
                _expressionList[i].Init(this._objectType, this._dbAccess);
                sb.Append(_expressionList[i].GenerateSQL(ref parameters, ref index));
                if (i == _expressionList.Count - 1)
                {
                    sb.Append(")");
                }
                else
                {
                    sb.Append(" " + _contactChar + " ");
                }
            }
            return sb.ToString();
        }

        internal override string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < _expressionList.Count; i++)
            {
                sb.Append(_expressionList[i].GetDescription());
                if (i == _expressionList.Count - 1)
                {
                    sb.Append(")");
                }
                else
                {
                    sb.Append(" " + _contactChar + " ");
                }
            }
            return sb.ToString();
        }
    }
}
