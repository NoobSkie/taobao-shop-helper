using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Common.Xml;
using J.SLS.Common;

namespace J.SLS.Facade
{
    public class TicketInfo : XmlMappingObject
    {
        public TicketInfo()
        {
            Amount = "1";
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
        public string Amount { get; set; }

        /// <summary>
        /// 当前票的购买金额。
        /// </summary>
        [XmlMapping("money", 4, MappingType = MappingType.Attribute)]
        public string Money { get; set; }

        /// <summary>
        /// 奖期信息
        /// </summary>
        [XmlMapping("issue", 5)]
        public IssueInfo IssueInfo { get; set; }

        /// <summary>
        /// 购彩用户信息
        /// </summary>
        [XmlMapping("userProfile", 6)]
        public UserProfileInfo UserProfile { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        [XmlMapping("anteCode", 7, ObjectType = XmlObjectType.List)]
        public List<string> AnteCodes { get; set; }
    }

    public class IssueInfo : XmlMappingObject
    {
        /// <summary>
        /// 游戏名称。如 ssq
        /// </summary>
        [XmlMapping("gameName", 1, MappingType = MappingType.Attribute)]
        public string GameName { get; set; }

        /// <summary>
        /// 奖期编号。例如2007051012,表示时时彩2007年5月10日第12期
        /// </summary>
        [XmlMapping("number", 2, MappingType = MappingType.Attribute)]
        public string Number { get; set; }
    }

    public class UserProfileInfo : XmlMappingObject
    {
        /// <summary>
        /// 彩民用户在代理商系统的登录名。最大长度20
        /// </summary>
        [XmlMapping("userName", 1, MappingType = MappingType.Attribute)]
        public string UserName { get; set; }

        /// <summary>
        /// 用户证件类型
        /// </summary>
        [XmlMapping("cardType", 2, MappingType = MappingType.Attribute)]
        public CardType CardType { get; set; }

        /// <summary>
        /// 用户证件号码。用户的证件号码是必须填写的。最大长度20
        /// </summary>
        [XmlMapping("cardNumber", 3, MappingType = MappingType.Attribute)]
        public string CardNumber { get; set; }

        /// <summary>
        /// 用户手机号码。(无纸化彩票中大奖的凭证之一)最大长度11
        /// </summary>
        [XmlMapping("mobile", 4, MappingType = MappingType.Attribute)]
        public string Mobile { get; set; }

        /// <summary>
        /// 用户的邮箱地址，格式为”邮箱名@域名”。最大长度20
        /// </summary>
        [XmlMapping("mail", 5, MappingType = MappingType.Attribute)]
        public string Mail { get; set; }

        /// <summary>
        /// 用户的真实姓名。最大长度10
        /// </summary>
        [XmlMapping("realName", 6, MappingType = MappingType.Attribute)]
        public string RealName { get; set; }

        /// <summary>
        /// 用户的大奖通知电话。最大长度15
        /// </summary>
        [XmlMapping("bonusPhone", 7, MappingType = MappingType.Attribute)]
        public string BonusPhone { get; set; }
    }
}
