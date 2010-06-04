using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using J.SLS.Common;
using J.SLS.Common.Xml;

namespace J.SLS.Facade
{
    public class IssueNoticeInfo : CommunicationObject
    {
        private class Body : XmlMappingObject
        {
            private class IssueNotify : XmlMappingObject
            {
                private class Issue : XmlMappingObject
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
                private Issue _Issue { get; set; }
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
            private IssueNotify _IssueNotify { get; set; }
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
        private Body _Body { get; set; }
        public string GameName { get { return _Body.GameName; } }
        public string Number { get { return _Body.Number; } }
        public DateTime StartTime { get { return _Body.StartTime; } }
        public DateTime StopTime { get { return _Body.StopTime; } }
        public IssueStatus Status { get { return _Body.Status; } }
        public string BonusCode { get { return _Body.BonusCode; } }
        public decimal SalesMoney { get { return _Body.SalesMoney; } }
        public decimal BonusMoney { get { return _Body.BonusMoney; } }
    }
}
