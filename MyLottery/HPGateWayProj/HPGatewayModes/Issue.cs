using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 奖期信息
    /// </summary>
    public class Issue
    {
        private PlayMethod _playMethodInfo;
        /// <summary>
        /// 玩法的编号
        /// </summary>
        public PlayMethod PlayMethodInfo
        {
            get { return _playMethodInfo; }
            set { _playMethodInfo = value; }
        }

        private string _number;
        /// <summary>
        /// 奖期编号。例如2007051012,表示时时彩2007年5月10日第12期
        /// </summary>
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private string _startTime;
        /// <summary>
        /// 奖期开启时间，格式与消息头中的timestamp子元素一样， 为
        /// yyyy-MM-dd HH:mm:ss.S，示例： 2007-05-10 08:00:00.0表
        /// 示2007年5月10日上午8：00
        /// </summary>
        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private string _stopTime;
        /// <summary>
        /// 奖期截止时间，格式同startTime
        /// </summary>
        public string StopTime
        {
            get { return _stopTime; }
            set { _stopTime = value; }
        }

        private StatusType _statusTypeInfo;
        /// <summary>
        /// 奖期状态
        /// </summary>
        public StatusType StatusTypeInfo
        {
            get { return _statusTypeInfo; }
            set { _statusTypeInfo = value; }
        }

        private string _bonusCode;
        /// <summary>
        /// 奖期的开奖号码
        /// </summary>
        public string BonusCode
        {
            get { return _bonusCode; }
            set { _bonusCode = value; }
        }

        private string _salesMoney;
        /// <summary>
        /// 销售金额。期结之后才有销售金额,期结前的销售金额为-1
        /// </summary>
        public string SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        private string _bonusMoney;
        /// <summary>
        /// 返奖金额。返奖之后才有返奖金额。返奖之前的返奖金额为-1
        /// </summary>
        public string BonusMoney
        {
            get { return _bonusMoney; }
            set { _bonusMoney = value; }
        }
    }
}
