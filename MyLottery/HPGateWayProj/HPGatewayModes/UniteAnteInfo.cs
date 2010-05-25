using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 联合购买方案信息
    /// </summary>
    public class UniteAnteInfo
    {
        string _counterAnteId;
        /// <summary>
        /// 联合购买方案编号。
        /// 生成规则为（agentID+8位时间戳YYYYMMDD+8位递增流水号）
        /// </summary>
        public string CounterAnteId
        {
            get { return _counterAnteId; }
            set { _counterAnteId = value; }
        }

        string _anteName;
        /// <summary>
        /// 联合购买方案名称
        /// </summary>
        public string AnteName
        {
            get { return _anteName; }
            set { _anteName = value; }
        }

        string _totalTicket;
        /// <summary>
        /// 联合购买方案的总票数
        /// </summary>
        public string TotalTicket
        {
            get { return _totalTicket; }
            set { _totalTicket = value; }
        }

        string _totalAnteMoney;
        /// <summary>
        /// 联合购买方案的总金额
        /// </summary>
        public string TotalAnteMoney
        {
            get { return _totalAnteMoney; }
            set { _totalAnteMoney = value; }
        }

        string _totalDeal;
        /// <summary>
        /// 联合购买方案的总份数
        /// </summary>
        public string TotalDeal
        {
            get { return _totalDeal; }
            set { _totalDeal = value; }
        }

        string _perDeal;
        /// <summary>
        /// 联合购买方案每份的金额
        /// </summary>
        public string PerDeal
        {
            get { return _perDeal; }
            set { _perDeal = value; }
        }

        string _userName;
        /// <summary>
        /// 联合购买方案的发起人用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
    }
}
