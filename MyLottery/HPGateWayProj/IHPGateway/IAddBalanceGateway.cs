using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HPGatewayModels;


namespace IHPGateway
{
    /// <summary>
    /// 充值接口
    /// </summary>
    public interface IAddBalanceGateway
    {
        /// <summary>
        /// 充值的网关地址
        /// </summary>
        string GatewayUrl
        {
            get;
        }

        /// <summary>
        /// 提交充值指令
        /// </summary>
        void PostAddBalance(AccountNumber accountNo, AlipayProviderType alipayProviderType, UserProfile userProfile, string money, string pageReturnUrl);

        /// <summary>
        /// 充值查询
        /// 统查询某笔（单次最多20笔）充值交易的明细情况
        /// transType=110
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：110</param>
        /// <param name="filles">要查询的充值集合</param>
        /// <returns></returns>
        string FillQuery(AccountNumber accountNo, TransactionType transType, List<Fill> filles);



    }
}
