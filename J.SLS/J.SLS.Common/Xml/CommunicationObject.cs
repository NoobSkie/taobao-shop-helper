using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common.Xml
{
    public abstract class CommunicationObject : XmlMappingObject
    {
        protected class RequestHeaderObject : XmlMappingObject
        {
            [XmlMapping("messengerID")]
            public string MessengerId { get; set; }
            [XmlMapping("timestamp")]
            public string Timestamp { get; set; }
            [XmlMapping("transactionType")]
            public TranType TransactionType { get; set; }
            [XmlMapping("digest")]
            public string Digest { get; set; }
        }

        [XmlMapping("id", MappingType.Attribute)]
        public string Id { get; set; }
        [XmlMapping("version", MappingType.Attribute)]
        public string Version { get; set; }

        [XmlMapping("header")]
        protected RequestHeaderObject _Header { get; set; }
        public string MessengerId { get { return _Header.MessengerId; } }
        public string Timestamp { get { return _Header.Timestamp; } }
        public TranType TransactionType { get { return _Header.TransactionType; } }
        public string Digest { get { return _Header.Digest; } }
    }
}
