using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using J.SLS.Common.Exceptions;
using System.Collections;

namespace J.SLS.Common.Logs
{
    public static class LogHelper
    {
        public static string GetLogMessage(string category, string source, LogType logType, string logMsg, string detail)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************** " + DateTime.Now + " ******************");
            sb.AppendLine("Category: " + category);
            sb.AppendLine("Source: " + source);
            sb.AppendLine("Type: " + logType.ToString());
            sb.AppendLine("Message: " + logMsg);
            sb.AppendLine("Detail:" + detail);
            sb.AppendLine(detail ?? "null");
            sb.AppendLine("*****************END*******************");
            sb.AppendLine();
            return sb.ToString();
        }

        public static string GetLogMessage(string category, string source, Exception exception)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************** " + DateTime.Now + " ******************");
            sb.AppendLine("Category: " + category);
            sb.AppendLine("Source: " + source);
            sb.AppendLine("Type: " + LogType.Error);
            sb.AppendLine();
            sb.AppendLine(GetExceptionMessage(exception));
            sb.AppendLine("*****************END*******************");
            sb.AppendLine();
            return sb.ToString();
        }

        public static string GetExceptionMessage(Exception exception)
        {
            return GetExceptionMessage(exception, "");
        }

        private static string GetExceptionMessage(Exception exception, string space)
        {
            if (exception == null)
            {
                return space + "null";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(space + "Exception Type: " + exception.GetType().FullName);
            sb.AppendLine(space + "Exception Source: " + exception.Source);
            sb.AppendLine(space + "Exception TargetSite: " + exception.TargetSite);
            sb.AppendLine(space + "Exception Message: " + exception.Message);
            sb.AppendLine(space + "Exception Data: ");
            if (exception.Data == null || exception.Data.Count == 0)
            {
                sb.AppendLine(space + "null");
            }
            else
            {
                foreach (DictionaryEntry item in exception.Data)
                {
                    sb.AppendLine(string.Format(space + "{0}={1}", item.Key, item.Value));
                }
            }
            sb.AppendLine(space + "Stack Trace: ");
            sb.AppendLine(space + exception.StackTrace ?? "null");
            sb.AppendLine(GetExceptionMessage(exception.InnerException, space + "    "));
            return sb.ToString();
        }
    }

    public static class LogCategory
    {
        public const string Common = "Common";
        public const string Login = "Login";
        public const string Register = "Register";
        public const string SearchUser = "Search user";
        public const string LogWrite = "Write log";
        public const string Application = "Application error";
        public const string Lottery = "Lottery";
    }
}
