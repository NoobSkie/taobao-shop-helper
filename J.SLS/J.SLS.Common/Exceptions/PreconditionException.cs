using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common.Exceptions
{
    public class PreconditionException : Exception
    {
        public PreconditionException() : base() { }

        public PreconditionException(string message) : base(message) { }

        public PreconditionException(string category, string message)
            : base(message)
        {
            Category = category;
        }

        public PreconditionException(string category, string message, Exception innerException)
            : base(message, innerException)
        {
            Category = category;
        }

        public string Category { get; set; }
    }
}
