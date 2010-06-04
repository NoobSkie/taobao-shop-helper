using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Domain;
using J.SLS.Common;
using J.SLS.Common.Exceptions;
using J.SLS.Common.Logs;
using J.SLS.Database.DBAccess;

namespace J.SLS.Facade
{
    public class XmlNoticeFacade : BaseFacade
    {
        public void AddNotice(XmlNoticeInfo notice)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                persistence.Add(notice);
            }
            catch (Exception ex)
            {
                string errMsg = "添加通知失败";
                throw HandleException(LogCategory.Notice, errMsg, ex);
            }
        }
    }
}
