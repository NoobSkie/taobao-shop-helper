using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Common.Xml;
using J.SLS.Common;

namespace J.SLS.Facade
{
    public class IssueMappingInfo : XmlMappingObject
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

    public class UserMappingInfo : XmlMappingObject
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

    /// <summary>
    /// 返奖对象信息
    /// </summary>
    public class BonusMappingInfo : XmlMappingObject
    {
        public class BonusItem : XmlMappingObject
        {
            [XmlMapping("playType", 0, MappingType.Attribute)]
            public BuyType PlayType { get; set; }

            /// <summary>
            /// 用户投注的中奖金额，如果是大奖，那么金额为0 。
            /// </summary>
            [XmlMapping("money", 1, MappingType.Attribute)]
            public decimal Money { get; set; }

            /// <summary>
            /// 是否为大奖中奖记录，其中：true表示是大奖，false表示不是大奖。
            /// </summary>
            [XmlMapping("isBombBonus", 2, MappingType.Attribute)]
            public bool IsBombBonus { get; set; }

            [XmlMapping("bonusLevel", 3, MappingType.Attribute)]
            public int BonusLevel { get; set; }

            /// <summary>
            /// 某一票中奖中的某个特定奖等个数，比如中了5个二等奖。
            /// </summary>
            [XmlMapping("size", 4, MappingType.Attribute)]
            public int Size { get; set; }

            [XmlMapping("ticketID", 5, MappingType.Attribute)]
            public string TicketId { get; set; }
        }

        [XmlMapping("bonusNumber", 0, MappingType.Attribute)]
        public string BonusNumber { get; set; }

        [XmlMapping("totalItems", 1, MappingType.Attribute)]
        public int TotalItems { get; set; }

        [XmlMapping("totalMoney", 2, MappingType.Attribute)]
        public decimal TotalMoney { get; set; }

        [XmlMapping("issue", 3)]
        public IssueMappingInfo _Issue { get; set; }

        [XmlMapping("bonusItem", 4, ObjectType = XmlObjectType.List)]
        public XmlMappingList<BonusItem> _BonusItemList { get; set; }
    }
}
