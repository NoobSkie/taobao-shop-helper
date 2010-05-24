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
    internal static class PreconditionAssert
    {
        internal static void IsNotNull(object value, string message)
        {
            if (value == null)
            {
                throw new PreconditionException("IsNotNull", message);
            }
        }

        internal static void IsNotNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new PreconditionException("IsNotNullOrEmpty", message);
            }
        }

        internal static void IsTrue(bool condition, string message)
        {
            if (!condition)
            {
                throw new PreconditionException("IsTrue", message);
            }
        }

        internal static void IsFalse(bool condition, string message)
        {
            if (condition)
            {
                throw new PreconditionException("IsFalse", message);
            }
        }

        internal static void CanFormatString(string formatedString, object[] values, string message)
        {
            try
            {
                string.Format(formatedString, values);
            }
            catch (Exception ex)
            {
                throw new PreconditionException("CanFormatString", message, ex);
            }
        }
    }
}
