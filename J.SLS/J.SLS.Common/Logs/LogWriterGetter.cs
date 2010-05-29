using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System;

namespace J.SLS.Common.Logs
{
    public static class LogWriterGetter
    {
        public static ILogWriter GetLogWriter()
        {
            string needLog = ConfigurationManager.AppSettings["NeedLog"];
            if (string.IsNullOrEmpty(needLog)
                || needLog == "1"
                || needLog.ToLower() == "true")
            {
                string writer = ConfigurationManager.AppSettings["LogWriter"];
                if (string.IsNullOrEmpty(writer))
                {
                    return new FileLogWriter();
                }
                Type writerType = Type.GetType(writer, true, true);
                return writerType.GetConstructor(Type.EmptyTypes).Invoke(new object[0]) as ILogWriter;
            }
            return null;
        }
    }
}

