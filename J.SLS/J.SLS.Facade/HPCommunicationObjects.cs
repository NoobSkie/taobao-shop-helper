using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Common.Xml;
using J.SLS.Common;

namespace J.SLS.Facade
{
    public class IssueNoticeInfo : CommunicationObject
    {
        public class Body : XmlMappingObject
        {
            public class IssueNotify : XmlMappingObject
            {
                public class Issue : XmlMappingObject
                {
                    [XmlMapping("gameName", MappingType.Attribute)]
                    public string GameName { get; set; }
                    [XmlMapping("number", MappingType.Attribute)]
                    public string Number { get; set; }
                    [XmlMapping("startTime", MappingType.Attribute)]
                    public DateTime StartTime { get; set; }
                    [XmlMapping("stopTime", MappingType.Attribute)]
                    public DateTime StopTime { get; set; }
                    [XmlMapping("status", MappingType.Attribute)]
                    public IssueStatus Status { get; set; }
                    [XmlMapping("bonusCode", MappingType.Attribute)]
                    public string BonusCode { get; set; }
                    [XmlMapping("salesMoney", MappingType.Attribute)]
                    public decimal SalesMoney { get; set; }
                    [XmlMapping("bonusMoney", MappingType.Attribute)]
                    public decimal BonusMoney { get; set; }
                }

                [XmlMapping("issue")]
                public Issue _Issue { get; set; }
                public string GameName { get { return _Issue.GameName; } }
                public string Number { get { return _Issue.Number; } }
                public DateTime StartTime { get { return _Issue.StartTime; } }
                public DateTime StopTime { get { return _Issue.StopTime; } }
                public IssueStatus Status { get { return _Issue.Status; } }
                public string BonusCode { get { return _Issue.BonusCode; } }
                public decimal SalesMoney { get { return _Issue.SalesMoney; } }
                public decimal BonusMoney { get { return _Issue.BonusMoney; } }
            }

            [XmlMapping("issueNotify")]
            public IssueNotify _IssueNotify { get; set; }
            public string GameName { get { return _IssueNotify.GameName; } }
            public string Number { get { return _IssueNotify.Number; } }
            public DateTime StartTime { get { return _IssueNotify.StartTime; } }
            public DateTime StopTime { get { return _IssueNotify.StopTime; } }
            public IssueStatus Status { get { return _IssueNotify.Status; } }
            public string BonusCode { get { return _IssueNotify.BonusCode; } }
            public decimal SalesMoney { get { return _IssueNotify.SalesMoney; } }
            public decimal BonusMoney { get { return _IssueNotify.BonusMoney; } }
        }

        [XmlMapping("body")]
        public Body _Body { get; set; }
        public string GameName { get { return _Body.GameName; } }
        public string Number { get { return _Body.Number; } }
        public DateTime StartTime { get { return _Body.StartTime; } }
        public DateTime StopTime { get { return _Body.StopTime; } }
        public IssueStatus Status { get { return _Body.Status; } }
        public string BonusCode { get { return _Body.BonusCode; } }
        public decimal SalesMoney { get { return _Body.SalesMoney; } }
        public decimal BonusMoney { get { return _Body.BonusMoney; } }
    }

    public class HPResponseInfo : CommunicationObject
    {
        public class Body : XmlMappingObject
        {
            public class Response : XmlMappingObject
            {
                [XmlMapping("code", MappingType.Attribute)]
                public string Code { get; set; }
                [XmlMapping("message", MappingType.Attribute)]
                public string Message { get; set; }
            }

            [XmlMapping("response")]
            public Response _Response { get; set; }
            public string Code { get { return _Response.Code; } }
            public string Message { get { return _Response.Message; } }
        }

        [XmlMapping("body")]
        public Body _Body { get; set; }
        public string Code { get { return _Body.Code; } }
        public string Message { get { return _Body.Message; } }
    }

    public class HPBuyRequestInfo : CommunicationObject
    {
        public class Body : XmlMappingObject
        {
            public class Request : XmlMappingObject
            {
                [XmlMapping("ticket", ObjectType = XmlObjectType.List)]
                public XmlMappingList<TicketInfo> TicketList { get; set; }
            }

            [XmlMapping("lotteryRequest")]
            public Request _Request { get; set; }

            public XmlMappingList<TicketInfo> TicketList { get { return _Request.TicketList; } }
        }

        [XmlMapping("body")]
        public Body _Body { get; set; }

        public XmlMappingList<TicketInfo> TicketList { get { return _Body.TicketList; } }
    }

    public class TicketInfo : XmlMappingObject
    {
        public TicketInfo()
        {
            Amount = "1";
        }

        /// <summary>
        /// 票号。票ID生成规则为(agentID+8位时间戳YYYYMMDD+10位递增流水号),最大长度24位
        /// </summary>
        [XmlMapping("id", MappingType = MappingType.Attribute)]
        public string TicketId { get; set; }

        /// <summary>
        /// 投注方式。如：单式、复式、胆拖
        /// </summary>
        [XmlMapping("playType", MappingType = MappingType.Attribute)]
        public BuyType BuyType { get; set; }

        /// <summary>
        /// 该票的倍投数, 默认为1 倍。
        /// </summary>
        [XmlMapping("amount", MappingType = MappingType.Attribute)]
        public string Amount { get; set; }

        /// <summary>
        /// 当前票的购买金额。
        /// </summary>
        [XmlMapping("money", MappingType = MappingType.Attribute)]
        public string Money { get; set; }

        /// <summary>
        /// 奖期信息
        /// </summary>
        [XmlMapping("issue")]
        public IssueInfo IssueInfo { get; set; }

        /// <summary>
        /// 购彩用户信息
        /// </summary>
        [XmlMapping("userProfile")]
        public UserProfileInfo UserProfile { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        [XmlMapping("anteCode", ObjectType = XmlObjectType.List)]
        public List<string> AnteCodes { get; set; }
    }

    /// <summary>
    /// 奖期信息
    /// </summary>
    public class IssueInfo : XmlMappingObject
    {
        /// <summary>
        /// 游戏名称。如 ssq
        /// </summary>
        [XmlMapping("gameName", MappingType = MappingType.Attribute)]
        public string GameName { get; set; }

        /// <summary>
        /// 奖期编号。例如2007051012,表示时时彩2007年5月10日第12期
        /// </summary>
        [XmlMapping("number", MappingType = MappingType.Attribute)]
        public string Number { get; set; }
    }

    public class UserProfileInfo : XmlMappingObject
    {
        /// <summary>
        /// 彩民用户在代理商系统的登录名。最大长度20
        /// </summary>
        [XmlMapping("userName", MappingType = MappingType.Attribute)]
        public string UserName { get; set; }

        /// <summary>
        /// 用户证件类型
        /// </summary>
        [XmlMapping("cardType", MappingType = MappingType.Attribute)]
        public CardType CardType { get; set; }

        /// <summary>
        /// 用户证件号码。用户的证件号码是必须填写的。最大长度20
        /// </summary>
        [XmlMapping("cardNumber", MappingType = MappingType.Attribute)]
        public string CardNumber { get; set; }

        /// <summary>
        /// 用户手机号码。(无纸化彩票中大奖的凭证之一)最大长度11
        /// </summary>
        [XmlMapping("mobile", MappingType = MappingType.Attribute)]
        public string Mobile { get; set; }

        /// <summary>
        /// 用户的邮箱地址，格式为”邮箱名@域名”。最大长度20
        /// </summary>
        [XmlMapping("mail", MappingType = MappingType.Attribute)]
        public string Mail { get; set; }

        /// <summary>
        /// 用户的真实姓名。最大长度10
        /// </summary>
        [XmlMapping("realName", MappingType = MappingType.Attribute)]
        public string RealName { get; set; }

        /// <summary>
        /// 用户的大奖通知电话。最大长度15
        /// </summary>
        [XmlMapping("bonusPhone", MappingType = MappingType.Attribute)]
        public string BonusPhone { get; set; }
    }
}
