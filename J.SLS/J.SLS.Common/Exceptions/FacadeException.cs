using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common.Exceptions
{
    public class FacadeException : Exception
    {
        public FacadeException() : base() { }

        public FacadeException(string message) : base(message) { }

        public FacadeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
