using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Database.ORM
{
    public class ORMException : Exception
    {
        public ORMException() : base() { }

        public ORMException(string message) : base(message) { }

        public ORMException(string message, Exception innerException) : base(message, innerException) { }
    }
}
