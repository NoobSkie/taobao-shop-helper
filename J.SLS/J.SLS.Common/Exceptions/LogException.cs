using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common.Exceptions
{
    public class LogException : Exception
    {
        public LogException() : base() { }

        public LogException(string message) : base(message) { }

        public LogException(string message, Exception innerException) : base(message, innerException) { }
    }
}
