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
    public class NoticeFacade : BaseFacade
    {
        public DateTime GetCurrentUpdateTime()
        {
            string sql = "SELECT * FROM [T_Temp_UpdateTime]";
            return (DateTime)DbAccess.GetRC1BySQL(sql);
        }

        public void ModifyCurrentUpdateTime(DateTime time)
        {
            string sql = "UPDATE [T_Temp_UpdateTime] SET [CurrentUpdateTime] = '" + time.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            DbAccess.ExecSQL(sql);
        }

        public IList<string> GetRequestTextList(DateTime fromTime)
        {
            NoticeManager noticeManager = new NoticeManager(DbAccess);
            IList<NoticeEntity> list = noticeManager.GetNoticeListFrom(fromTime);
            IList<string> rtn = new List<string>();
            foreach (NoticeEntity entity in list)
            {
                rtn.Add("transType=" + entity.TranType + "&transMessage=" + entity.ResponseText);
            }
            return rtn;
        }

        public CommunicationObject HandleNotice(string response)
        {
            try
            {
                Dictionary<string, string> parameters = XmlAnalyzer.GetParameters(response);
                CommunicationObject notice = AddNotify(parameters["transMessage"]);
                TranType type = (TranType)Enum.Parse(typeof(TranType), parameters["transType"]);
                switch (type)
                {
                    case TranType.Request101:   // 奖期通知请求
                        AddIssuseNotify(parameters["transMessage"]);
                        break;
                    case TranType.Request108:   // 返奖通知请求
                        // 添加返奖通知
                        BonusNoticeInfo bonusNotice = AddBonusNotify(parameters["transMessage"]);
                        // 派奖
                        string gameName = bonusNotice._Body._BonusInfo._Issue.GameName;
                        string issueNumber = bonusNotice._Body._BonusInfo._Issue.Number;
                        DistributeBonus(gameName, issueNumber);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("不支持的通知类型 - " + type);
                }
                return notice;
            }
            catch (Exception ex)
            {
                string errMsg = "处理通知失败！" + response;
                throw HandleException(LogCategory.Notice, errMsg, ex);
            }
        }

        public void AddNotifyResponse(CommunicationObject notifyInfo, string fullResponse, string responseXml)
        {
            try
            {
                NoticeResponseEntity entity = new NoticeResponseEntity();
                entity.NoticeId = notifyInfo.Id;
                entity.NoticeVersion = notifyInfo.Version;
                entity.MessengerId = notifyInfo.MessengerId;
                entity.Timestamp = notifyInfo.Timestamp;
                entity.TranType = (int)notifyInfo.TransactionType;
                entity.FullResponseText = fullResponse;
                entity.ResponseXml = responseXml;
                NoticeManager noticeManager = new NoticeManager(DbAccess);
                noticeManager.AddNoticeResponse(entity);
            }
            catch (Exception ex)
            {
                string errMsg = "添加响应到数据库失败！" + responseXml;
                throw HandleException(LogCategory.Notice, errMsg, ex);
            }
        }

        public CommunicationObject AddNotify(string xml)
        {
            try
            {
                CommunicationObject notifyInfo = XmlAnalyzer.AnalyseXmlToCommunicationObject<CommunicationObject>(xml);
                NoticeEntity noticeEntity = new NoticeEntity();
                noticeEntity.NoticeId = notifyInfo.Id;
                noticeEntity.NoticeVersion = notifyInfo.Version;
                noticeEntity.MessengerId = notifyInfo.MessengerId;
                noticeEntity.Timestamp = notifyInfo.Timestamp;
                noticeEntity.TranType = (int)notifyInfo.TransactionType;
                noticeEntity.Digest = notifyInfo.Digest;
                noticeEntity.ResponseText = xml;
                noticeEntity.NotifyTime = DateTime.Now;
                noticeEntity.XmlHeader = notifyInfo.XmlHeader;
                NoticeManager noticeManager = new NoticeManager(DbAccess);
                noticeManager.AddNotice(noticeEntity);

                return notifyInfo;
            }
            catch (Exception ex)
            {
                string errMsg = "添加通知XML到数据库失败！" + xml;
                throw HandleException(LogCategory.Notice, errMsg, ex);
            }
        }

        public IssueNoticeInfo AddIssuseNotify(string xml)
        {
            IssueNoticeInfo info = XmlAnalyzer.AnalyseXmlToCommunicationObject<IssueNoticeInfo>(xml);
            try
            {
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
                IssuseManager issuseManager = new IssuseManager(DbAccess);
                issuseManager.SaveIssue(issueEntity);

                return info;
            }
            catch (Exception ex)
            {
                string errMsg = "添加奖期通知失败！" + xml;
                throw HandleException(LogCategory.Notice, errMsg, ex);
            }
        }

        public BonusNoticeInfo AddBonusNotify(string xml)
        {
            BonusNoticeInfo info = XmlAnalyzer.AnalyseXmlToCommunicationObject<BonusNoticeInfo>(xml);
            try
            {
                BonusEntity bonusEntity = new BonusEntity();
                bonusEntity.GameName = info._Body._BonusInfo._Issue.GameName;
                bonusEntity.IssuseNumber = info._Body._BonusInfo._Issue.Number;
                bonusEntity.BonusNumber = info._Body._BonusInfo.BonusNumber;
                bonusEntity.TotalItems = info._Body._BonusInfo.TotalItems;
                bonusEntity.TotalMoney = info._Body._BonusInfo.TotalMoney;
                bonusEntity.NoticeId = info.Id;
                bonusEntity.IsDistributed = false;
                using (ILHDBTran tran = BeginTran())
                {
                    BonusManager bonusManager = new BonusManager(tran);
                    bonusManager.AddBonus(bonusEntity);
                    List<BonusDetailEntity> bonusDetailList = new List<BonusDetailEntity>();
                    foreach (BonusMappingInfo.BonusItem bonusItem in info._Body._BonusInfo._BonusItemList)
                    {
                        BonusDetailEntity detail = new BonusDetailEntity();
                        detail.TicketId = bonusItem.TicketId;
                        detail.BonusLevel = bonusItem.BonusLevel;
                        detail.PlayType = (int)bonusItem.PlayType;
                        detail.Money = bonusItem.Money;
                        detail.IsBombBonus = bonusItem.IsBombBonus;
                        detail.Size = bonusItem.Size;
                        detail.GameName = bonusEntity.GameName;
                        detail.IssuseNumber = bonusEntity.IssuseNumber;
                        bonusManager.AddBonusDetail(detail);
                    }
                    tran.Commit();
                }
                return info;
            }
            catch (Exception ex)
            {
                string errMsg = "添加返奖通知失败！" + xml;
                throw HandleException(LogCategory.Notice, errMsg, ex);
            }
        }

        public void DistributeBonus(string gameName, string issueNumber)
        {
            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    BonusManager bonusManger = new BonusManager(tran);
                    UserManager userManager = new UserManager(tran);

                    BonusEntity bonusEntity = bonusManger.GetBonus(gameName, issueNumber);
                    if (bonusEntity == null)
                    {
                        throw new Exception("要分派的奖期信息不存在 - " + gameName + ":" + issueNumber);
                    }
                    if (bonusEntity.IsDistributed)
                    {
                        throw new Exception("此奖期已经派奖 - " + gameName + ":" + issueNumber);
                    }
                    IList<BonusDetailEntity> bonusDetailList = bonusManger.GetBonusDetailList(gameName, issueNumber);
                    TicketManager ticketManager = new TicketManager(tran);
                    foreach (BonusDetailEntity bonusDetail in bonusDetailList)
                    {
                        TicketEntity ticket = ticketManager.GetTicket(bonusDetail.TicketId);
                        if (ticket != null)
                        {
                            BonusDistributeEntity bonusDistribute = new BonusDistributeEntity();
                            bonusDistribute.TicketId = bonusDetail.TicketId;
                            bonusDistribute.BonusLevel = bonusDetail.BonusLevel;
                            bonusDistribute.UserId = ticket.UserId;
                            bonusDistribute.GameName = bonusDetail.GameName;
                            bonusDistribute.IssuseNumber = bonusDetail.IssuseNumber;
                            bonusDistribute.PlayType = bonusDetail.PlayType;
                            bonusDistribute.IsBombBonus = bonusDetail.IsBombBonus;
                            bonusDistribute.BonusSize = bonusDetail.Size;
                            bonusDistribute.Money = bonusDetail.Money;

                            bonusManger.AddBonusDistribute(bonusDistribute);

                            UserBalanceEntity balanceEntity = userManager.GetBalance(ticket.UserId);
                            if (balanceEntity == null)
                            {
                                throw new Exception("异常 - 彩民的账户不存在 - " + ticket.UserId);
                            }
                            if (!balanceEntity.Balance.HasValue)
                            {
                                throw new Exception("异常 - 彩民的账户为空 - " + ticket.UserId);
                            }
                            balanceEntity.Balance += bonusDetail.Money;
                            userManager.ModifyBalance(balanceEntity);
                        }
                    }
                    bonusEntity.IsDistributed = true;
                    bonusManger.ModifyBonusDistrbite(bonusEntity);

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                string errMsg = "派奖失败 - " + gameName + ":" + issueNumber;
                throw HandleException(LogCategory.Distribute, errMsg, ex);
            }
        }
    }
}
