using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HPGatewayModels;

namespace IHPGateway
{
    /// <summary>
    /// 提款接口
    /// </summary>
    public interface IDrawingGateway
    {
        /// <summary>
        /// 提款的网关地址
        /// </summary>
        string GatewayUrl
        {
            get;
        }

        /// <summary>
        /// 提款
        /// transType=111
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：111</param>
        /// <param name="drawing"></param>
        /// <returns></returns>
        string DrawingRequest(AccountNumber accountNo, TransactionType transType, Drawing drawing);

        /// <summary>
        /// 提款查询
        /// transType=113
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：113</param>
        /// <param name="drawings"></param>
        /// <returns></returns>
        string DrawingQuery(AccountNumber accountNo, TransactionType transType, List<Drawing> drawings);
    }
}
