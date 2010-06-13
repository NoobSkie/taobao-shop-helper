using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;
using J.SLS.Database.Configuration;
using J.SLS.Common.Logs;
using J.SLS.Common.Exceptions;

namespace J.SLS.Facade
{
    public abstract class BaseFacade
    {
        public BaseFacade()
        {
        }

        protected ObjectPersistence GetPersistence(IDBAccess dbAccess)
        {
            return new ObjectPersistence(dbAccess);
        }

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
                            config = ConnectionConfiguration.GetConfiguration("J.SLS.Conn");
                        }
                    }
                }
                return config;
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

        protected FacadeException HandleException(string category, string errMsg, Exception innerException, params object[] objs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(errMsg);
            if (objs != null && objs.Length > 0)
            {
                foreach (object obj in objs)
                {
                    sb.AppendLine(ORMHelper.GetEntityInfoMessage(objs[0]));
                    sb.AppendLine();
                }
            }
            FacadeException ex = new FacadeException(sb.ToString(), innerException);
            if (LogWriter != null)
            {
                LogWriter.Write(category, errMsg, ex);
            }
            return ex;
        }
    }
}
