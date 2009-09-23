using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.DbHelper
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class DbTableAttribute : Attribute
    {
        public string DbTableName { get; set; }

        public DbObjectType DbObjectType { get; set; }
    }
}
