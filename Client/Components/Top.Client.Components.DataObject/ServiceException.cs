using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text;

namespace Top.Client.Components.DataObject
{
    public delegate string GetText(string key);

    public class ServiceException : Exception
    {
        // Fields
        private string[] _args;
        private string _code;
        private string _module;
        public static GetText GetErrorText = null;

        // Methods
        public ServiceException(string module, string code, params string[] args)
        {
            this._module = module;
            this._code = code;
            this._args = args;
        }

        public ServiceException(string module, string code, Exception innerException, params string[] args)
            : base(module + code, innerException)
        {
            this._module = module;
            this._code = code;
            this._args = args;
        }

        // Properties
        public string[] Args
        {
            get
            {
                return this._args;
            }
        }

        public string Code
        {
            get
            {
                return this._code;
            }
        }

        public override string Message
        {
            get
            {
                string key = this._module + "." + this._code;
                if (GetErrorText != null)
                {
                    string str2 = GetErrorText(key);
                    if (!string.IsNullOrEmpty(str2))
                    {
                        if ((this._args != null) && (this._args.Length > 0))
                        {
                            return string.Format(str2, (object[])this._args);
                        }
                        return str2;
                    }
                }
                StringBuilder builder = new StringBuilder();
                builder.Append("Unknown Error:").Append(key);
                if (this._args != null)
                {
                    int index = 0;
                    int length = this._args.Length;
                    while (index < length)
                    {
                        builder.Append("\r\nargs[").Append(index).Append("]:").Append(this._args[index]);
                        index++;
                    }
                }
                return builder.ToString();
            }
        }

        public string Module
        {
            get
            {
                return this._module;
            }
        }
    }
}
