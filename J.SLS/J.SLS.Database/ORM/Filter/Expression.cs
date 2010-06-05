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
    public abstract class Expression
    {
        protected const string _flag = "_EXP";

        internal protected string _propertyName = "";
        internal protected string _fieldName = "";
        protected IDBAccess _dbAccess;
        internal protected DbType _dbType = DbType.AnsiString;

        internal virtual void Init(Type objectType, IDBAccess dbAccess)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(objectType);
            SchemaItem fieldInfo = entityInfo.GetFieldInfoByPropertyName(this._propertyName);
            if (fieldInfo == null)
            {
                throw new ArgumentException(string.Format("{0} - Property \"{1}\" not define a mapping field.", this.GetType(), _propertyName));
            }
            Type type = fieldInfo.ProInfo.PropertyType;
            type = Nullable.GetUnderlyingType(type) ?? type;
            this._dbType = ORMHelper.GetDbTypeByName(type);
            this._fieldName = fieldInfo.MappingFieldAttribute.FieldName;
            this._dbAccess = dbAccess;
        }

        protected string GetParameterName(int i)
        {
            return "@P" + i + _flag;
        }

        internal abstract string GenerateSQL(ref List<DbParameter> parameters, ref int index);

        internal abstract string GetDescription();

        #region OperateExpression

        public static Expression Equal(string propertyName, object value)
        {
            return new EqualExpression(propertyName, value);
        }

        public static Expression NotEqual(string propertyName, object value)
        {
            return new NotEqualExpression(propertyName, value);
        }

        public static Expression Like(string propertyName, object value)
        {
            return new LikeExpression(propertyName, value);
        }

        public static Expression NotLike(string propertyName, object value)
        {
            return new NotLikeExpression(propertyName, value);
        }

        public static Expression GreaterThan(string propertyName, object value)
        {
            return new GreaterThanExpression(propertyName, value);
        }

        public static Expression GreaterThanEqual(string propertyName, object value)
        {
            return new GreaterThanEqualExpression(propertyName, value);
        }

        public static Expression LessThan(string propertyName, object value)
        {
            return new LessThanExpression(propertyName, value);
        }

        public static Expression LessThanEqual(string propertyName, object value)
        {
            return new LessThanEqualExpression(propertyName, value);
        }

        public static Expression Between(string propertyName, object minValue, object maxValue)
        {
            return new BetweenExpression(propertyName, minValue, maxValue);
        }

        public static Expression In(string propertyName, params object[] values)
        {
            return new InExpression(propertyName, values);
        }

        public static Expression NotIn(string propertyName, params object[] values)
        {
            return new NotInExpression(propertyName, values);
        }

        public static Expression IsNull(string propertyName)
        {
            return new IsNullExpression(propertyName);
        }

        public static Expression IsNotNull(string propertyName)
        {
            return new IsNotNullExpression(propertyName);
        }

        #endregion

        #region LogicExpression

        public static Expression Or(params Expression[] expressions)
        {
            return new OrExpression(expressions);
        }

        public static Expression And(params Expression[] expressions)
        {
            return new AndExpression(expressions);
        }

        #endregion
    }
}
