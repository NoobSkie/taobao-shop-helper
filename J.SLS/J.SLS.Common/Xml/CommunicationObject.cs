using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common.Xml
{
    public class CommunicationObject : XmlMappingObject
    {
        public string XmlHeader { get; set; }

        public class RequestHeaderObject : XmlMappingObject
        {
            [XmlMapping("messengerID", 1)]
            public string MessengerId { get; set; }
            [XmlMapping("timestamp", 2)]
            public string Timestamp { get; set; }
            [XmlMapping("transactionType", 3)]
            public TranType TransactionType { get; set; }
            [XmlMapping("digest", 4)]
            public string Digest { get; set; }
        }

        [XmlMapping("id", 1, MappingType.Attribute)]
        public string Id { get; set; }
        [XmlMapping("version", 2, MappingType.Attribute)]
        public string Version { get; set; }

        [XmlMapping("header", 3)]
        public RequestHeaderObject _Header { get; set; }
        public string MessengerId { get { return _Header.MessengerId; } }
        public string Timestamp { get { return _Header.Timestamp; } }
        public TranType TransactionType { get { return _Header.TransactionType; } }
        public string Digest { get { return _Header.Digest; } }

        public virtual string ToXmlString()
        {
            return XmlHeader + base.ToXmlString("message");
        }
    }
}
