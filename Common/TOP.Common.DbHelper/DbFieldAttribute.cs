using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.DbHelper
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DbFieldAttribute : Attribute
    {
        public DbFieldAttribute() : this(false) { }

        internal DbFieldAttribute(bool isKey)
        {
            IsKey = isKey;
        }

        public string DbFieldName { get; set; }

        private bool _isKey = false;
        public bool IsKey
        {
            get
            {
                return _isKey;
            }
            private set
            {
                if (value)
                {
                    DbFieldType = DbDataType.UNIQUEIDENTIFIER;
                    IsNotNull = true;
                    DefaultValue = "NEWID()";
                }
                _isKey = value;
            }
        }

        public bool IsNotNull { get; set; }

        public DbDataType DbFieldType { get; set; }

        public int Length { get; set; }

        public string DefaultValue { get; set; }
    }
}
