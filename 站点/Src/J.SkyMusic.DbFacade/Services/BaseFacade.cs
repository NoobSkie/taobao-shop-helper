using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Common.Exceptions;
using J.SLS.Common.Logs;
using J.SLS.Database.DBAccess;
using J.SLS.Database.Configuration;

namespace J.SkyMusic.DbFacade.Services
{
    public abstract class BaseFacade
    {
        protected ILHDBAccess DbAccess
        {
            get
            {
                return CurrentConfig.DbAccess;
            }
        }

        protected ILHDBTran BeginTran()
        {
            return CurrentConfig.BeginTran();
        }

        private static ConnectionConfiguration config = null;
        private object lockObj = new object();
        private ConnectionConfiguration CurrentConfig
        {
            get
            {
                if (config == null)
                {
                    lock (lockObj)
                    {
                        if (config == null)
                        {
                            config = ConnectionConfiguration.GetConfiguration("J.SkyMusic.Conn");
                        }
                    }
                }
                return config;
            }
        }

        [ThreadStatic]
        protected static ILogWriter _logWriter;
        protected ILogWriter LogWriter
        {
            get
            {
                if (_logWriter == null)
                {
                    _logWriter = LogWriterGetter.GetLogWriter();
                }
                return _logWriter;
            }
        }

        protected FacadeException HandleException(string category, string source, string errMsg, Exception innerException)
        {
            FacadeException ex = new FacadeException(errMsg, innerException);
            if (LogWriter != null)
            {
                LogWriter.Write(category, source, ex);
            }
            return ex;
        }

        protected FacadeException HandleException(string category, string errMsg, Exception innerException)
        {
            FacadeException ex = new FacadeException(errMsg, innerException);
            if (LogWriter != null)
            {
                LogWriter.Write(category, category, ex);
            }
            return ex;
        }
    }
}
