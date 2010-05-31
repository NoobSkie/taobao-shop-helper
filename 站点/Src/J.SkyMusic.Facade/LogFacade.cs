using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Common;
using J.SLS.Common.Exceptions;
using J.SLS.Common.Logs;
using J.SLS.Database.DBAccess;
using J.SkyMusic.Domain;

namespace J.SkyMusic.Facade
{
    public class LogFacade : BaseFacade, ILogWriter
    {
        public void Write(string category, string source, LogType logType, string logMsg, string detail)
        {
            Guid id = Guid.NewGuid();

            LogEntity log = new LogEntity();
            log.Id = id;
            log.Category = category;
            log.Source = source;
            log.Type = (short)logType;
            log.Message = logMsg;

            LogDetailEntity logDetail = new LogDetailEntity();
            logDetail.Id = id;
            logDetail.LogDetail = detail;

            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    LogManager manager = new LogManager(tran);
                    manager.AddLog(log);
                    manager.AddLogDetail(logDetail);
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                FileLogWriter writer = new FileLogWriter();
                writer.Write(LogCategory.LogWrite, "Write log to database", ex);
                writer.Write(category, source, logType, logMsg, detail);
            }
        }

        public void Write(string category, string source, Exception exception)
        {
            if (exception == null)
            {
                return;
            }
            Guid id = Guid.NewGuid();

            LogEntity log = new LogEntity();
            log.Id = id;
            log.Category = category;
            log.Source = source;
            log.Type = (short)LogType.Error;
            log.Message = exception.Message;

            LogDetailEntity logDetail = new LogDetailEntity();
            logDetail.Id = id;
            logDetail.LogDetail = LogHelper.GetExceptionMessage(exception);

            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    LogManager manager = new LogManager(tran);
                    manager.AddLog(log);
                    manager.AddLogDetail(logDetail);
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                FileLogWriter writer = new FileLogWriter();
                writer.Write(LogCategory.LogWrite, "Write log to database", ex);
                writer.Write(category, source, exception);
            }
        }
    }
}
