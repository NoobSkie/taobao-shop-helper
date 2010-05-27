using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException() : base() { }

        public LoginException(LoginErrorType type)
            : base()
        {
            LoginErrorType = type;
        }

        public LoginException(string message) : base(message) { }

        public LoginException(LoginErrorType type, string message)
            : base(message)
        {
            LoginErrorType = type;
        }

        public LoginException(LoginErrorType type, string message, Exception innerException)
            : base(message, innerException)
        {
            LoginErrorType = type;
        }

        public LoginErrorType LoginErrorType { get; set; }
    }
}
