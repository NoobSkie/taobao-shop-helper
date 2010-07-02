using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.DbFacade.Services
{
    public class NoticeFacade : BaseFacade
    {
        public IList<NoticeInfo> GetCurrentNoticeList()
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("IsEnd", false));
            cri.Add(Expression.GreaterThanEqual("EndTime", DateTime.Now));
            cri.Add(Expression.LessThanEqual("StartTime", DateTime.Now));
            return persistence.GetList<NoticeInfo>(cri, new SortInfo("UpdateTime", SortDirection.Desc));
        }

        public NoticeInfo GetNoticeMessage(long noticeId)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            NoticeInfo notice = persistence.GetByKey<NoticeInfo>(noticeId);
            string sql = "SELECT [Message] FROM [T_Notice_List] WHERE [Id] = {0}";
            notice.Message = (string)DbAccess.GetRC1BySQL(sql, noticeId);
            return notice;
        }
    }
}
