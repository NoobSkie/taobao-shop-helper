using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHPGateway;
using HPGatewayModels;

namespace HPGatewayRealization
{
    public class CheckTicketGateway:ICheckTicket
    {
        #region ICheckTicket 成员

        public string GetCheckTicketUrl(AccountNumber accountNo, TransactionType transType, Ticket ticket)
        {
            try
            {
                DateTime now = DateTime.Now;
                //代理商Id
                string agentId = accountNo.UserName;
                //票流水号。ID生成规则为（agentID+8位时间戳YYYYMMDD+8位递增流水号）
                string ticketId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                //消息加密字符串。使用MD5加密，原文为代理商编号（agentID）＋代理商密码＋代理商票号（ticketId）
                string digest = PostManager.MD5(agentId + accountNo.UserPassword + ticket.TicketId, "gb2312");

                string url = GateWayManager.HPTicketVerification_GateWay + "?agentId=\"" + agentId + "\" ticketId=\"" + ticketId + "\" digest=\"" + digest + "\"";
                return url;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
