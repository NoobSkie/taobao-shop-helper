using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace J.SLS.Database.DBAccess
{
    public class SqlParameterNotMatchException : Exception
    {
        public SqlParameterNotMatchException(string sql, string message, Exception innerException, params object[] values)
            : base(message, innerException)
        {
            SqlString = SqlString;
            ValueList = new List<object>();
            if (values != null && values.Length > 0)
            {
                ValueList.AddRange(values);
            }
        }

        public string SqlString { get; set; }

        public List<object> ValueList { get; set; }

        public override string Message
        {
            get
            {
                StringBuilder errorMsgBuilder = new StringBuilder();
                if (!string.IsNullOrEmpty(base.Message))
                {
                    errorMsgBuilder.AppendLine(base.Message);
                }
                errorMsgBuilder.AppendLine(SqlString);
                if (ValueList != null && ValueList.Count > 0)
                {
                    for (int i = 0; i < ValueList.Count; i++)
                    {
                        object o = ValueList[i];
                        errorMsgBuilder.Append("[p" + i + "]" + "");
                        if (o != null)
                        {
                            errorMsgBuilder.AppendLine(o.ToString());
                        }
                        else
                        {
                            errorMsgBuilder.AppendLine("null");
                        }
                    }
                }
                else
                {
                    errorMsgBuilder.AppendLine("Parameters: None");
                }
                return errorMsgBuilder.ToString();
            }
        }
    }
}
