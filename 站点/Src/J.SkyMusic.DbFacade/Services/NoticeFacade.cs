using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SkyMusic.DbFacade.Domains;
using J.SLS.Database.DBAccess;

namespace J.SkyMusic.DbFacade.Services
{
    public class NoticeFacade : BaseFacade
    {
        public void AddNotice(NoticeInfo noticeInfo)
        {
            NoticeEntity entity = new NoticeEntity();
            entity.Id = Guid.NewGuid().ToString("N");
            entity.Name = noticeInfo.Name;
            entity.Title = noticeInfo.Title;
            entity.IsHasDetail = noticeInfo.IsHasDetail;
            entity.Message = noticeInfo.Message;
            entity.IsForeRed = noticeInfo.IsForeRed;
            entity.IsForeBold = noticeInfo.IsForeBold;
            entity.StartTime = noticeInfo.StartTime;
            entity.EndTime = noticeInfo.EndTime;
            entity.IsEnd = noticeInfo.IsEnd;
            NoticeManager manager = new NoticeManager(DbAccess);
            manager.AddNotice(entity);
            noticeInfo.Id = entity.Id;
        }

        public void ModifyNotice(NoticeInfo noticeInfo)
        {
            using (ILHDBTran tran = BeginTran())
            {
                NoticeManager manager = new NoticeManager(tran);

                NoticeEntity entity = manager.GetNotice(noticeInfo.Id);
                if (entity == null)
                {
                    throw new ArgumentNullException("通知数据不存在！！");
                }
                entity.Name = noticeInfo.Name;
                entity.Title = noticeInfo.Title;
                entity.IsHasDetail = noticeInfo.IsHasDetail;
                entity.Message = noticeInfo.Message;
                entity.IsForeRed = noticeInfo.IsForeRed;
                entity.IsForeBold = noticeInfo.IsForeBold;
                entity.StartTime = noticeInfo.StartTime;
                entity.EndTime = noticeInfo.EndTime;
                entity.IsEnd = noticeInfo.IsEnd;
                manager.ModifyNotice(entity);
                tran.Commit();
            }
        }

        public void DeleteNotice(string id)
        {
            NoticeManager manager = new NoticeManager(DbAccess);
            manager.DeleteNotice(id);
        }

        public IList<NoticeInfo> GetCurrentNoticeList()
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("IsEnd", false));
            cri.Add(Expression.GreaterThanEqual("EndTime", DateTime.Now));
            cri.Add(Expression.LessThanEqual("StartTime", DateTime.Now));
            return persistence.GetList<NoticeInfo>(cri, new SortInfo("UpdateTime", SortDirection.Desc));
        }

        public IList<NoticeInfo> GetAllNoticeList()
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetAll<NoticeInfo>(new SortInfo("UpdateTime", SortDirection.Desc));
        }

        public NoticeInfo GetNoticeMessage(string noticeId)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            NoticeInfo notice = persistence.GetByKey<NoticeInfo>(noticeId);
            string sql = "SELECT [Message] FROM [T_Notice_List] WHERE [Id] = {0}";
            notice.Message = (string)DbAccess.GetRC1BySQL(sql, noticeId);
            return notice;
        }
    }
}
