using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 投注的票
    /// </summary>
    public class Ticket
    {
        string _ticketId;
        /// <summary>
        /// 票号
        /// 票ID生成规则为(agentID+8位时间戳YYYYMMDD+10位递增流水号),最大长度24位
        /// </summary>
        public string TicketId
        {
            get { return _ticketId; }
            set { _ticketId = value; }
        }

        PlayType _playTypeInfo;
        /// <summary>
        /// 投注方式
        /// 如：单式、复式、胆拖
        /// </summary>
        public PlayType PlayTypeInfo
        {
            get { return _playTypeInfo; }
            set { _playTypeInfo = value; }
        }

        string _amount="1";
        /// <summary>
        /// 该票的倍投数, 默认为1 倍。
        /// </summary>
        public string Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }


        string _money;
        /// <summary>
        /// 当前票的购买金额。
        /// </summary>
        public string Money
        {
            get { return _money; }
            set { _money = value; }
        }


        Issue _issueInfo;
        /// <summary>
        /// 奖期信息
        /// </summary>
        public Issue IssueInfo
        {
            get { return _issueInfo; }
            set { _issueInfo = value; }
        }

        UserProfile _userProfile;
        /// <summary>
        /// 购彩用户信息
        /// </summary>
        public UserProfile UserProfile
        {
            get { return _userProfile; }
            set { _userProfile = value; }
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
