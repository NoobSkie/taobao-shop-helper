using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HPGatewayModels;

namespace IHPGateway
{
    /// <summary>
    /// 票验证接口
    /// </summary>
    public interface ICheckTicket
    {
        string GetCheckTicketUrl(AccountNumber accountNo, TransactionType transType,Ticket ticket);
    }
}
