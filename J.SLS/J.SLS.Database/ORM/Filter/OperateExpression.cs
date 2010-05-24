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
    internal class EqualExpression : Expression
    {
        private object _value;

        public EqualExpression(string propertyName, object value)
        {
            this._propertyName = propertyName;
            this._value = value;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            string pName = GetParameterName(++index);

            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append("=")
                .Append(pName);

            DbParameter parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pName;
            parameter.Value = this._value;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} = {2}"
                , _propertyName
                , _dbType
                , _value);
        }
    }

    internal class NotEqualExpression : Expression
    {
        private object _value;

        public NotEqualExpression(string propertyName, object value)
        {
            this._propertyName = propertyName;
            this._value = value;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            string pName = GetParameterName(++index);

            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append("<>")
                .Append(pName);

            DbParameter parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pName;
            parameter.Value = this._value;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} <> {2}"
                , _propertyName
                , _dbType
                , _value);
        }
    }

    internal class LikeExpression : Expression
    {
        private object _value;
        public LikeExpression(string propertyName, object value)
        {
            this._propertyName = propertyName;
            this._value = value;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            string pName = GetParameterName(++index);

            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append(" LIKE ")
                .Append(pName);

            DbParameter parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pName;
            parameter.Value = this._value;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} LIKE {2}"
                , _propertyName
                , _dbType
                , _value);
        }
    }

    internal class NotLikeExpression : Expression
    {
        private object _value;
        public NotLikeExpression(string propertyName, object value)
        {
            this._propertyName = propertyName;
            this._value = value;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            string pName = GetParameterName(++index);

            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append(" NOT LIKE ")
                .Append(pName);

            DbParameter parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pName;
            parameter.Value = this._value;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} NOT LIKE {2}"
                , _propertyName
                , _dbType
                , _value);
        }
    }

    internal class GreaterThanExpression : Expression
    {
        private object _value;
        public GreaterThanExpression(string propertyName, object value)
        {
            this._propertyName = propertyName;
            this._value = value;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            string pName = GetParameterName(++index);

            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append(">")
                .Append(pName);

            DbParameter parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pName;
            parameter.Value = this._value;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} > {2}"
                , _propertyName
                , _dbType
                , _value);
        }
    }

    internal class GreaterThanEqualExpression : Expression
    {
        private object _value;
        public GreaterThanEqualExpression(string propertyName, object value)
        {
            this._propertyName = propertyName;
            this._value = value;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            string pName = GetParameterName(++index);

            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append(">=")
                .Append(pName);

            DbParameter parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pName;
            parameter.Value = this._value;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} >= {2}"
                , _propertyName
                , _dbType
                , _value);
        }
    }

    internal class LessThanExpression : Expression
    {
        private object _value;
        public LessThanExpression(string propertyName, object value)
        {
            this._propertyName = propertyName;
            this._value = value;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            string pName = GetParameterName(++index);

            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append("<")
                .Append(pName);

            DbParameter parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pName;
            parameter.Value = this._value;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} < {2}"
                , _propertyName
                , _dbType
                , _value);
        }
    }

    internal class LessThanEqualExpression : Expression
    {
        private object _value;
        public LessThanEqualExpression(string propertyName, object value)
        {
            this._propertyName = propertyName;
            this._value = value;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            string pName = GetParameterName(++index);

            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append("<=")
                .Append(pName);

            DbParameter parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pName;
            parameter.Value = this._value;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} <= {2}"
                , _propertyName
                , _dbType
                , _value);
        }
    }

    internal class BetweenExpression : Expression
    {
        private object _minValue;
        private object _maxValue;

        public BetweenExpression(string propertyName, object minValue, object maxValue)
        {
            this._propertyName = propertyName;
            this._minValue = minValue;
            this._maxValue = maxValue;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            string pNameMin = GetParameterName(++index);
            string pNameMax = GetParameterName(++index);

            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append(" BETWEEN ")
                .Append(pNameMin)
                .Append(" AND ")
                .Append(pNameMax);

            DbParameter parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pNameMin;
            parameter.Value = this._minValue;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            parameter = this._dbAccess.CreateDbParameter();
            parameter.ParameterName = pNameMax;
            parameter.Value = this._maxValue;
            parameter.DbType = this._dbType;
            parameters.Add(parameter);

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} Between ({2} AND {3})"
                , _propertyName
                , _dbType
                , _minValue
                , _maxValue);
        }
    }

    internal class InExpression : Expression
    {
        private object[] _values;

        public InExpression(string propertyName, params object[] values)
        {
            this._propertyName = propertyName;
            this._values = values;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append(" IN (");

            string pName = null;
            DbParameter parameter = null;

            for (int i = 0; i < this._values.Length; i++)
            {
                pName = GetParameterName(++index);
                sb.Append(pName);

                if (i == this._values.Length - 1)
                {
                    sb.Append(")");
                }
                else
                {
                    sb.Append(" , ");
                }

                parameter = this._dbAccess.CreateDbParameter();
                parameter.ParameterName = pName;
                parameter.Value = this._values[i];
                parameter.DbType = this._dbType;
                parameters.Add(parameter);
            }
            return sb.ToString();
        }

        internal override string GetDescription()
        {
            string[] desc = new string[_values.Length];
            for (int i = 0; i < desc.Length; i++)
            {
                desc[i] = _values[i].ToString();
            }
            return string.Format("{0} IN ({2})"
                , _propertyName
                , _dbType
                , string.Join(", ", desc));
        }
    }

    internal class NotInExpression : Expression
    {
        private object[] _values;

        public NotInExpression(string propertyName, params object[] values)
        {
            this._propertyName = propertyName;
            this._values = values;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append(" NOT IN (");

            string pName = null;
            DbParameter parameter = null;

            for (int i = 0; i < this._values.Length; i++)
            {
                pName = GetParameterName(++index);
                sb.Append(pName);

                if (i == this._values.Length - 1)
                {
                    sb.Append(")");
                }
                else
                {
                    sb.Append(" , ");
                }

                parameter = this._dbAccess.CreateDbParameter();
                parameter.ParameterName = pName;
                parameter.Value = this._values[i];
                parameter.DbType = this._dbType;
                parameters.Add(parameter);
            }
            return sb.ToString();
        }

        internal override string GetDescription()
        {
            string[] desc = new string[_values.Length];
            for (int i = 0; i < desc.Length; i++)
            {
                desc[i] = _values[i].ToString();
            }
            return string.Format("{0} NOT IN ({2})"
                , _propertyName
                , _dbType
                , string.Join(", ", desc));
        }
    }

    internal class IsNullExpression : Expression
    {
        public IsNullExpression(string propertyName)
        {
            this._propertyName = propertyName;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append(" IS NULL ");

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} IS NULL"
                , _propertyName
                , _dbType);
        }
    }

    internal class IsNotNullExpression : Expression
    {
        public IsNotNullExpression(string propertyName)
        {
            this._propertyName = propertyName;
        }

        internal override string GenerateSQL(ref List<DbParameter> parameters, ref int index)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this._dbAccess.GetDbObjectName(this._fieldName))
                .Append(" IS NOT NULL ");

            return sb.ToString();
        }

        internal override string GetDescription()
        {
            return string.Format("{0} IS NOT NULL"
                , _propertyName
                , _dbType);
        }
    }
}
