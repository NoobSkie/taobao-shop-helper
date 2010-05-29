using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common.Logs
{
    public interface ILogWriter
    {
        void Write(string category, string source, LogType logType, string logMsg, string detail);

        void Write(string category, string source, Exception exception);
    }
}
