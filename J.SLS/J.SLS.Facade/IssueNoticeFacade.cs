using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Common.Xml;
using J.SLS.Common;
using J.SLS.Common.Logs;
using J.SLS.Domain;
using J.SLS.Database.DBAccess;

namespace J.SLS.Facade
{
    public class IssueNoticeFacade : BaseFacade
    {
        public void HandleNotice(string response)
        {
            try
            {
                Dictionary<string, string> parameters = XmlAnalyzer.GetParameters(response);
                TranType type = (TranType)Enum.Parse(typeof(TranType), parameters["transType"]);
                switch (type)
                {
                    case TranType.IssueNotifyRequest:  // 奖期通知请求
                        AddIssuseNotify(parameters["transMessage"]);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("不支持的通知类型 - " + type);
                }
            }
            catch (Exception ex)
            {
                string errMsg = "处理通知失败！" + response;
                throw HandleException(LogCategory.Notice, errMsg, ex);
            }
        }

        public void AddIssuseNotify(string xml)
        {
            IssueNoticeInfo info = XmlAnalyzer.AnalyseXml<IssueNoticeInfo>(xml);

            NoticeEntity noticeEntity = new NoticeEntity();
            noticeEntity.NoticeId = info.Id;
            noticeEntity.NoticeVersion = info.Version;
            noticeEntity.MessengerId = info.MessengerId;
            noticeEntity.Timestamp = info.Timestamp;
            noticeEntity.TranType = (int)info.TransactionType;
            noticeEntity.Digest = info.Digest;
            noticeEntity.ResponseText = xml;
            noticeEntity.NotifyTime = DateTime.Now;

            IssueEntity issueEntity = new IssueEntity();
            issueEntity.GameName = info.GameName;
            issueEntity.IssuseNumber = info.Number;
            issueEntity.StartTime = info.StartTime;
            issueEntity.StopTime = info.StopTime;
            issueEntity.Status = (int)info.Status;
            issueEntity.BonusCode = info.BonusCode;
            issueEntity.SalesMoney = info.SalesMoney;
            issueEntity.BonusMoney = info.BonusMoney;
            issueEntity.NoticeId = info.Id;

            using (ILHDBTran tran = BeginTran())
            {
                NoticeManager noticeManager = new NoticeManager(tran);
                noticeManager.AddNotice(noticeEntity);

                IssuseManager issuseManager = new IssuseManager(tran);
                issuseManager.SaveIssue(issueEntity);

                tran.Commit();
            }
        }
    }
}
