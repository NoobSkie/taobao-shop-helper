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
                    [XmlMapping("gameName", 1, MappingType.Attribute)]
                    public string GameName { get; set; }
                    [XmlMapping("number", 2, MappingType.Attribute)]
                    public string Number { get; set; }
                    [XmlMapping("startTime", 3, MappingType.Attribute)]
                    public DateTime StartTime { get; set; }
                    [XmlMapping("stopTime", 4, MappingType.Attribute)]
                    public DateTime StopTime { get; set; }
                    [XmlMapping("status", 5, MappingType.Attribute)]
                    public IssueStatus Status { get; set; }
                    [XmlMapping("bonusCode", 6, MappingType.Attribute)]
                    public string BonusCode { get; set; }
                    [XmlMapping("salesMoney", 7, MappingType.Attribute)]
                    public decimal SalesMoney { get; set; }
                    [XmlMapping("bonusMoney", 8, MappingType.Attribute)]
                    public decimal BonusMoney { get; set; }
                }

                [XmlMapping("issue", 1)]
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

            [XmlMapping("issueNotify", 1)]
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

        [XmlMapping("body", 2)]
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

    public class BonusNoticeInfo : CommunicationObject
    {
        public class Body : XmlMappingObject
        {
            [XmlMapping("bonusNotify", 1)]
            public BonusInfo _BonusInfo { get; set; }
        }

        [XmlMapping("body", 2)]
        public Body _Body { get; set; }
    }

    public class HPResponseInfo : CommunicationObject
    {
        public class Body : XmlMappingObject
        {
            public class Response : XmlMappingObject
            {
                [XmlMapping("code", 1, MappingType.Attribute)]
                public string Code { get; set; }
                [XmlMapping("message", 2, MappingType.Attribute)]
                public string Message { get; set; }
            }

            [XmlMapping("response", 1)]
            public Response _Response { get; set; }
            public string Code { get { return _Response.Code; } }
            public string Message { get { return _Response.Message; } }
        }

        [XmlMapping("body", 2)]
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
                [XmlMapping("ticket", 1, ObjectType = XmlObjectType.List)]
                public XmlMappingList<TicketInfo> TicketList { get; set; }
            }

            [XmlMapping("lotteryRequest", 1)]
            public Request _Request { get; set; }

            public XmlMappingList<TicketInfo> TicketList { get { return _Request.TicketList; } }
        }

        [XmlMapping("body", 2)]
        public Body _Body { get; set; }

        public XmlMappingList<TicketInfo> TicketList { get { return _Body.TicketList; } }
    }
}
