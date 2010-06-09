using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.DBAccess;
using J.SLS.Database.ORM;
using J.SLS.Common;
using J.SLS.Common.Exceptions;

namespace J.SkyMusic.DbFacade.Domain
{
    public class LogManager
    {
        private readonly ObjectPersistence persistence = null;
        public LogManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void AddLog(LogEntity log)
        {
            log.WriteTime = DateTime.Now;
            persistence.Add(log);
        }

        public void AddLogDetail(LogDetailEntity logDetail)
        {
            persistence.Add(logDetail);
        }
    }
}
