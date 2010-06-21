using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Domain;
using J.SLS.Common;
using J.SLS.Database.DBAccess;
using J.SLS.Common.Logs;
using J.SLS.Common.Exceptions;

namespace J.SLS.Facade
{
    public class TicketFacade : BaseFacade
    {
        /// <summary>
        /// 投注购票
        /// </summary>
        public void BuyTicket(TicketInfo ticket, UserInfo user)
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
        public void UpdateTicketStatus(TicketInfo ticket, UserInfo user, HPResponseInfo response)
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
            IList<ChaseEntity> chaseList = ticketManager.GetChaseListByIssue(gameName, issueNumber, (int)ChaseStatus.Chasing);
            foreach (ChaseEntity chase in chaseList)
            {

            }
        }
    }
}
