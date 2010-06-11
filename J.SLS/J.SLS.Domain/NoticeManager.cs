using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;

namespace J.SLS.Domain
{
    public class NoticeManager
    {
        private readonly ObjectPersistence persistence = null;
        public NoticeManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void AddNotice(NoticeEntity entity)
        {
            entity.NotifyTime = DateTime.Now;
            persistence.Add(entity);
        }

        public void AddNoticeResponse(NoticeResponseEntity entity)
        {
            entity.ResponseTime = DateTime.Now;
            persistence.Add(entity);
        }

        public IList<NoticeEntity> GetNoticeListFrom(DateTime fromTime)
        {
            Criteria cri = new Criteria();
            cri.Add(Expression.GreaterThanEqual("NotifyTime", fromTime));
            return persistence.GetList<NoticeEntity>(cri, new SortInfo("NotifyTime"));
        }
    }
}
