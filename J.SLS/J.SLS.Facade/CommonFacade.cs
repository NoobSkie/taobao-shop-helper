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
    public class CommonFacade : BaseFacade
    {
        public DateTime GetCurrentTime()
        {
            try
            {
                string sql = "SELECT GETDATE()";
                return (DateTime)DbAccess.GetRC1BySQL(sql);
            }
            catch (Exception ex)
            {
                string errMsg = "获取服务器时间失败！";
                throw HandleException(LogCategory.Common, "Get current server time", errMsg, ex);
            }
        }
    }
}
