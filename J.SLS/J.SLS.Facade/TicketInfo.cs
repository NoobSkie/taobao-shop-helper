using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Common.Xml;
using J.SLS.Common;

namespace J.SLS.Facade
{
    public class TicketMappingInfo : XmlMappingObject
    {
        public TicketMappingInfo()
        {
            Amount = 1;
        }

        /// <summary>
        /// 票号。票ID生成规则为(agentID+8位时间戳YYYYMMDD+10位递增流水号),最大长度24位
        /// </summary>
        [XmlMapping("id", 1, MappingType = MappingType.Attribute)]
        public string TicketId { get; set; }

        /// <summary>
        /// 投注方式。如：单式、复式、胆拖
        /// </summary>
        [XmlMapping("playType", 2, MappingType = MappingType.Attribute)]
        public BuyType BuyType { get; set; }

        /// <summary>
        /// 该票的倍投数, 默认为1 倍。
        /// </summary>
        [XmlMapping("amount", 3, MappingType = MappingType.Attribute)]
        public int Amount { get; set; }

        /// <summary>
        /// 当前票的购买金额。
        /// </summary>
        [XmlMapping("money", 4, MappingType = MappingType.Attribute)]
        public decimal Money { get; set; }

        /// <summary>
        /// 奖期信息
        /// </summary>
        [XmlMapping("issue", 5)]
        public IssueMappingInfo IssueInfo { get; set; }

        /// <summary>
        /// 购彩用户信息
        /// </summary>
        [XmlMapping("userProfile", 6)]
        public UserMappingInfo UserProfile { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        [XmlMapping("anteCode", 7, ObjectType = XmlObjectType.List)]
        public List<string> AnteCodes { get; set; }
    }

    public class ChaseAddInfo
    {
        public string TicketId { get; set; }

        public string GameName { get; set; }

        public string IssuseNumber { get; set; }

        public int Amount { get; set; }

        public decimal Money { get; set; }

        public string UserId { get; set; }
    }
}
