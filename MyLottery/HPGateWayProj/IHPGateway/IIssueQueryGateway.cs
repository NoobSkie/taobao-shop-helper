using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HPGatewayModels;

namespace IHPGateway
{
    public interface IIssueQueryGateway
    {
        string GatewayUrl
        {
            get;
        }

        //恒朋投注系统向本地系统发送的“奖期通知”
        //    1）用奖期查询，来代替。改变本地系统奖期状态，可能需要轮讯
        //暂时不考虑

        /// <summary>
        /// 发送响应信息到恒朋电话投注系统
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型 </param>
        /// <param name="messageID">消息ID</param>
        /// <param name="resStatus">返回恒朋系统的响应状态</param>
        void ResponseNotice(AccountNumber accountNo, TransactionType transType, string messageID, ResponseStatus resStatus);

        ///<summary>
        /// 奖期查询
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号</param>
        /// <param name="issue">奖期信息</param>
        /// <returns></returns>
        string IssueQuery(AccountNumber accountNo, TransactionType transType, Issue issue);

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型</param>
        /// <param name="tickets">要进行投注的彩票集合</param>
        /// <returns></returns>
        string LotteryRequest(AccountNumber accountNo, TransactionType transType, List<Ticket> tickets);


        /// <summary>
        /// 票查询
        /// </summary>
        /// <param name="AccountNo">代理商账号</param>
        /// <param name="tickets">要进行票查询的彩票集合</param>
        /// <returns></returns>
        string TicketQuery(AccountNumber accountNo, TransactionType transType, List<Ticket> tickets);


        /// <summary>
        /// 返奖查询
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型</param>
        /// <param name="issue">要查询返奖信息的奖期对象</param>
        /// <returns></returns>
        string BonusQuery(AccountNumber accountNo, TransactionType transType,Issue issue);  

        /// <summary>
        /// 销量查询
        /// transType="107"
        /// 代理商在收到恒朋电话投注系统发送的“完成期结”奖期通知或者
        /// 代理商查询到恒朋电话投注系统奖期状态为“完成期结”，才能发起销量查询。
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型</param>
        /// <param name="issue">要查询返奖信息的奖期对象</param>
        /// <returns></returns>
        string BalanceQuery(AccountNumber accountNo, TransactionType transType, Issue issue);

        /// <summary>
        /// 帐户查询
        /// transType=116
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：116</param>
        /// <param name="accounts"></param>
        /// <returns></returns>
        string AccountQuery(AccountNumber accountNo, TransactionType transType, List<AccountQuery> accounts);
    }
}
