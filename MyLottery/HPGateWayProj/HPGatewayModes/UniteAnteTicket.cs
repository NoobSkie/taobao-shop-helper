using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 联合购买方案投注票明细信息
    /// </summary>
    public class UniteAnteTicket
    {
        string _ticketId;
        /// <summary>
        /// 票号。生成规则为（agentID+8位时间戳YYYYMMDD+8位递增流水号）
        /// </summary>
        public string TicketId
        {
            get { return _ticketId; }
            set { _ticketId = value; }
        }
        int _amount;
        /// <summary>
        /// 票的倍数
        /// </summary>
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        PlayType _playTypeInfo;
        /// <summary>
        /// 投注方式
        /// </summary>
        public PlayType PlayTypeInfo
        {
            get { return _playTypeInfo; }
            set { _playTypeInfo = value; }
        }
        double _money;
        /// <summary>
        /// 单票金额
        /// </summary>
        public double Money
        {
            get { return _money; }
            set { _money = value; }
        }
        string _message;
        /// <summary>
        /// 投注状态消息
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        int _status;
        /// <summary>
        /// 投注的状态。0—委托失败 1—委托成功
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        string anteCodes;
        /// <summary>
        /// 投注号码
        /// </summary>
        public string AnteCodes
        {
            get { return anteCodes; }
            set { anteCodes = value; }
        }
    }
}
