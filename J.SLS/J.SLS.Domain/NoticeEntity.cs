using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SLS.Domain
{
    [EntityMappingTable("T_Notice_List")]
    public class NoticeEntity
    {
        [EntityMappingField("Id", IsKey = true, IsAutoField = true)]
        public long Id { get; set; }

        [EntityMappingField("NoticeId")]
        public string NoticeId { get; set; }

        [EntityMappingField("NoticeVersion")]
        public string NoticeVersion { get; set; }

        [EntityMappingField("MessengerId")]
        public string MessengerId { get; set; }

        [EntityMappingField("Timestamp")]
        public string Timestamp { get; set; }

        [EntityMappingField("TranType")]
        public int TranType { get; set; }

        [EntityMappingField("Digest")]
        public string Digest { get; set; }

        [EntityMappingField("NotifyTime")]
        public DateTime NotifyTime { get; set; }

        [EntityMappingField("ResponseText")]
        public string ResponseText { get; set; }

        [EntityMappingField("XmlHeader")]
        public string XmlHeader { get; set; }
    }
}
