using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.Logic
{
    public class FacadeException : Exception
    {
        public FacadeException()
            : base()
        {
        }

        public FacadeException(string message)
            : base(message)
        {
        }

        public FacadeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
