using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Domain;
using J.SLS.Common;
using J.SLS.Database.DBAccess;
using J.SLS.Common.Logs;
using J.SLS.Common.Exceptions;
using J.SLS.Common.Xml;
using HPGatewayModels;
using System.Configuration;

namespace J.SLS.Facade
{
    public class TicketFacade : BaseFacade
    {
        public HPResponseInfo DoBuy(UserInfo user, string gameName, string issueNumber
            , BuyType buyType, List<string> anteCodes, decimal money, int multiple)
        {
            try
            {
                HPBuyRequestInfo requestInfo = new HPBuyRequestInfo();
                string messengerId = GetAgenceAccountUserName();
                string userPassword = GetAgenceAccountPassword();
                string messageId = messengerId + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

                IssueMappingInfo issueInfo = new IssueMappingInfo();
                issueInfo.GameName = gameName;
                issueInfo.Number = issueNumber;

                TicketMappingInfo ticket = new TicketMappingInfo();
                ticket.TicketId = messengerId + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                ticket.BuyType = buyType;
                ticket.Money = money;
                ticket.Amount = multiple;
                ticket.AnteCodes = anteCodes;
                ticket.IssueInfo = issueInfo;
                ticket.UserProfile = GetAgencyUserProfileInfo();

                HPBuyRequestInfo.Body requestBody = new HPBuyRequestInfo.Body();
                requestBody._Request = new HPBuyRequestInfo.Body.Request();
                requestBody._Request.TicketList = new XmlMappingList<TicketMappingInfo>();
                requestBody._Request.TicketList.Add(ticket);

                string bodyXml = requestBody.ToXmlString("body");

                CommunicationObject.RequestHeaderObject requestHeader = new CommunicationObject.RequestHeaderObject();
                requestHeader.MessengerId = GetAgenceAccountUserName();
                requestHeader.Timestamp = timestamp;
                requestHeader.TransactionType = TranType.Request103;
                requestHeader.Digest = PostManager.MD5(messageId + timestamp + userPassword + bodyXml, "gb2312");

                string headerXml = requestHeader.ToXmlString("header");
                string requestXml = "<?xml version=\"1.0\" encoding=\"GBK\"?><message version=\"1.0\" id=\"" + messageId + "\">" + headerXml + bodyXml + "</message>";
                string requestText = "transType=" + (int)TranType.Request103 + "&transMessage=" + requestXml;

                BuyTicket(ticket, user);
                string xml = PostManager.Post(GateWayManager.HPIssueQuery_GateWay, requestText, 1200);
                HPResponseInfo info = XmlAnalyzer.AnalyseResponse<HPResponseInfo>(xml);
                UpdateTicketStatus(ticket, user, info);

                return info;
            }
            catch (Exception ex)
            {
                throw HandleException(LogCategory.Ticket, "认购失败！", ex);
            }
        }

        private UserMappingInfo GetAgencyUserProfileInfo()
        {
            UserMappingInfo userProfile = new UserMappingInfo();
            userProfile.UserName = "200021";
            userProfile.CardType = J.SLS.Common.CardType.IdCard;
            userProfile.CardNumber = "200021";
            userProfile.Mail = "zhongjy_001@163.com";
            userProfile.Mobile = "15902307117";
            userProfile.RealName = "200021";
            userProfile.BonusPhone = "15902307117";
            return userProfile;
        }

        private string GetAgenceAccountUserName()
        {
            if (ConfigurationManager.AppSettings["AgenceAccount"] == null)
            {
                throw new ArgumentNullException("未配置代理商账号！");
            }
            return ConfigurationManager.AppSettings["AgenceAccount"];
        }

        private string GetAgenceAccountPassword()
        {
            if (ConfigurationManager.AppSettings["AgencePassword"] == null)
            {
                throw new ArgumentNullException("未配置代理商账号！");
            }
            return ConfigurationManager.AppSettings["AgencePassword"];
        }

        /// <summary>
        /// 投注购票
        /// </summary>
        public void BuyTicket(TicketMappingInfo ticket, UserInfo user)
        {
            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    UserManager userManager = new UserManager(tran);
                    TicketManager ticketManager = new TicketManager(tran);

                    UserBalanceEntity balance = userManager.GetBalance(user.UserId);
                    if (balance == null)
                    {
                        throw new FacadeException("帐户不存在，请先充值！");
                    }
                    decimal balanceMoney = balance.Balance.HasValue ? balance.Balance.Value : 0;
                    decimal freezeMoney = balance.Freeze.HasValue ? balance.Freeze.Value : 0;
                    decimal enableMoney = balanceMoney - freezeMoney;
                    if (enableMoney < ticket.Money)
                    {
                        throw new FacadeException("帐户余额不足，请先充值！");
                    }

                    TicketDetailEntity detail = new TicketDetailEntity();
                    detail.UserId = user.UserId;
                    detail.TicketId = ticket.TicketId;
                    detail.BalanceBefore = balanceMoney;
                    detail.FreezeBefore = freezeMoney;
                    detail.PayMoney = ticket.Money;
                    detail.BalanceAfter = balanceMoney;
                    detail.FreezeAfter = freezeMoney + ticket.Money;
                    detail.Status = (int)TicketStatus.Requesting;
                    detail.Message = "投注 - 冻结金额" + ticket.Money;
                    detail.CurrentTime = DateTime.Now;
                    // 添加彩票购买明细日志记录 - 状态为请求中
                    ticketManager.AddTicketDetail(detail);
                    // 更新用户余额 - 冻结金额
                    balance.Freeze += ticket.Money;
                    userManager.ModifyBalance(balance);

                    TicketEntity entity = new TicketEntity();
                    entity.TicketId = ticket.TicketId;
                    entity.BuyType = (int)ticket.BuyType;
                    entity.Amount = ticket.Amount;
                    entity.Money = ticket.Money;
                    entity.UserId = user.UserId;
                    entity.GameName = ticket.IssueInfo.GameName;
                    entity.IssuseNumber = ticket.IssueInfo.Number;
                    entity.Status = (int)TicketStatus.Requesting;
                    entity.RequestTime = DateTime.Now;
                    ticketManager.AddTicket(entity);
                    foreach (string code in ticket.AnteCodes)
                    {
                        TicketAnteCodeEntity anteCode = new TicketAnteCodeEntity();
                        anteCode.TicketId = ticket.TicketId;
                        anteCode.AnteCode = code;
                        ticketManager.AddAnteCode(anteCode);
                    }
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                throw HandleException(LogCategory.Ticket, "投注购票失败！", ex, ticket, user);
            }
        }

        /// <summary>
        /// 更新投注响应状态
        /// </summary>
        public void UpdateTicketStatus(TicketMappingInfo ticket, UserInfo user, HPResponseInfo response)
        {
            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    UserManager userManager = new UserManager(tran);
                    TicketManager ticketManager = new TicketManager(tran);

                    TicketDetailEntity tmp = ticketManager.GetFreezeTicketDetail(ticket.TicketId, user.UserId);
                    if (tmp == null || tmp.Status != (int)TicketStatus.Requesting)
                    {
                        throw new FacadeException("帐户数据错误，请联系系统管理员！");
                    }
                    UserBalanceEntity balance = userManager.GetBalance(user.UserId);
                    if (balance == null)
                    {
                        throw new FacadeException("帐户不存在，请先充值！");
                    }
                    TicketEntity entity = ticketManager.GetTicket(ticket.TicketId);
                    if (entity == null)
                    {
                        throw new FacadeException("出票数据错误，请联系管理员！");
                    }
                    if (response.Code == "0000")
                    {
                        entity.Status = (int)TicketStatus.Determinate;

                        TicketDetailEntity detail = new TicketDetailEntity();
                        detail.UserId = user.UserId;
                        detail.TicketId = ticket.TicketId;
                        detail.BalanceBefore = tmp.BalanceAfter;
                        detail.FreezeBefore = tmp.FreezeAfter;
                        detail.PayMoney = tmp.PayMoney;
                        detail.BalanceAfter = tmp.BalanceAfter - tmp.PayMoney;
                        detail.FreezeAfter = tmp.FreezeAfter - tmp.PayMoney;
                        detail.Status = (int)TicketStatus.Determinate;
                        detail.Message = "落地 - 更新金额并解冻" + tmp.PayMoney;
                        detail.CurrentTime = DateTime.Now;
                        // 添加彩票购买明细日志记录 - 状态为落地
                        ticketManager.AddTicketDetail(detail);

                        balance.Balance -= tmp.PayMoney;
                        balance.Freeze -= tmp.PayMoney;
                        userManager.ModifyBalance(balance);
                    }
                    else
                    {
                        entity.Status = (int)TicketStatus.Error;

                        TicketDetailEntity detail = new TicketDetailEntity();
                        detail.UserId = user.UserId;
                        detail.TicketId = ticket.TicketId;
                        detail.BalanceBefore = tmp.BalanceAfter;
                        detail.FreezeBefore = tmp.FreezeAfter;
                        detail.PayMoney = tmp.PayMoney;
                        detail.BalanceAfter = tmp.BalanceAfter;
                        detail.FreezeAfter = tmp.FreezeAfter - tmp.PayMoney;
                        detail.Status = (int)TicketStatus.Error;
                        detail.Message = "错误 - " + response.Message + " - 恢复冻结金额" + ticket.Money;
                        detail.CurrentTime = DateTime.Now;
                        // 添加彩票购买明细日志记录 - 状态为错误
                        ticketManager.AddTicketDetail(detail);

                        balance.Freeze -= tmp.PayMoney;
                        userManager.ModifyBalance(balance);
                    }
                    entity.ResponseCode = response.Code;
                    entity.ResponseMessage = response.Message;
                    entity.ResponseTime = DateTime.Now;

                    ticketManager.ModifyTicket(entity);
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                throw HandleException(LogCategory.Ticket, "更新投注状态失败！ - " + ex.Message, ex, ticket, response);
            }
        }

        public void ChaseTicket(IList<ChaseAddInfo> chaseList)
        {
            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    UserManager userManager = new UserManager(tran);
                    TicketManager ticketManager = new TicketManager(tran);

                    foreach (ChaseAddInfo chase in chaseList)
                    {
                        ChaseEntity chaseEntity = new ChaseEntity();
                        chaseEntity.TicketId = chase.TicketId;
                        chaseEntity.GameName = chase.GameName;
                        chaseEntity.IssuseNumber = chase.IssuseNumber;
                        chaseEntity.Amount = chase.Amount;
                        chaseEntity.Money = chase.Money;
                        chaseEntity.UserId = chase.UserId;
                        chaseEntity.Status = (int)ChaseStatus.Chasing;
                        ticketManager.AddTicketChase(chaseEntity);

                        UserBalanceEntity balance = userManager.GetBalance(chase.UserId);
                        if (balance == null)
                        {
                            throw new FacadeException("帐户不存在，请先充值！");
                        }
                        decimal balanceMoney = balance.Balance.HasValue ? balance.Balance.Value : 0;
                        decimal freezeMoney = balance.Freeze.HasValue ? balance.Freeze.Value : 0;
                        decimal enableMoney = balanceMoney - freezeMoney;
                        if (enableMoney < chase.Money)
                        {
                            throw new FacadeException("帐户余额不足，请先充值！");
                        }
                        // 更新用户余额 - 冻结金额
                        balance.Freeze += chase.Money;
                        userManager.ModifyBalance(balance);
                    }
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                throw HandleException(LogCategory.Ticket, "添加追号失败！", ex);
            }
        }

        public void AutoBuyChaseTicket(string gameName, string issueNumber)
        {
            TicketManager ticketManager = new TicketManager(DbAccess);
            UserManager userManager = new UserManager(DbAccess);
            IList<ChaseEntity> chaseList = ticketManager.GetChaseListByIssue(gameName, issueNumber, (int)ChaseStatus.Chasing);
            foreach (ChaseEntity chase in chaseList)
            {
                try
                {
                    UserFacade userFacade = new UserFacade();
                    UserInfo user = userFacade.GetUserInfo(chase.UserId);
                    if (user == null)
                    {
                        throw new Exception("用户不存在 - " + chase.UserId);
                    }
                    UserBalanceEntity balance = userManager.GetBalance(chase.UserId);
                    if (balance == null)
                    {
                        throw new Exception("用户帐户不存在 - " + chase.UserId);
                    }
                    TicketEntity ticket = ticketManager.GetTicket(chase.TicketId);
                    if (ticket == null)
                    {
                        throw new Exception("追号的票不存在 - " + chase.TicketId);
                    }
                    IList<TicketAnteCodeEntity> anteCodeList = ticketManager.GetAnteCodeListByTicket(chase.TicketId);
                    List<string> codes = new List<string>();
                    foreach (TicketAnteCodeEntity anteCodeEntity in anteCodeList)
                    {
                        codes.Add(anteCodeEntity.AnteCode);
                    }
                    balance.Freeze -= chase.Money;
                    userManager.ModifyBalance(balance);
                    HPResponseInfo response = DoBuy(user, gameName, issueNumber, (BuyType)ticket.BuyType, codes, chase.Money, chase.Amount);
                    if (response.Code == "0000")
                    {
                        chase.Status = (int)ChaseStatus.Finished;
                    }
                    else
                    {
                        chase.Status = (int)ChaseStatus.Error;
                    }
                    chase.ResponseCode = response.Code;
                    chase.ResponseMessage = response.Message;
                    ticketManager.ModifyChaseStatus(chase);
                }
                catch (Exception ex)
                {
                    chase.Status = (int)ChaseStatus.Error;
                    chase.ResponseCode = "9999";
                    chase.ResponseMessage = "未知异常 - " + ex.Message;
                    ticketManager.ModifyChaseStatus(chase);

                    HandleException(LogCategory.Ticket, "自动认购追号失败！", ex, chase);
                }
            }
        }
    }
}
