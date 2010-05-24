using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace J.SLS.Common
{
    /// <summary>
    /// 前置条件断言，辅助类
    /// </summary>
    public static class PreconditionAssert
    {
        public static void IsNotNull(object value, string message)
        {
            if (value == null)
            {
                throw new PreconditionException("IsNotNull", message);
            }
        }

        public static void IsNotNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new PreconditionException("IsNotNullOrEmpty", message);
            }
        }

        public static void IsTrue(bool condition, string message)
        {
            if (!condition)
            {
                throw new PreconditionException("IsTrue", message);
            }
        }

        public static void IsFalse(bool condition, string message)
        {
            if (condition)
            {
                throw new PreconditionException("IsFalse", message);
            }
        }
    }
}
