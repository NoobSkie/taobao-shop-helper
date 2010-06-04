using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using J.SLS.Common;
using J.SLS.Database.ORM;

namespace J.SLS.Domain
{
    [EntityMappingTable("T_Issuses")]
    public class IssueEntity
    {
        [EntityMappingField("Id", IsKey = true, IsAutoField = true)]
        public long Id { get; set; }

        [EntityMappingField("GameName")]
        public string GameName { get; set; }

        [EntityMappingField("IssuseNumber")]
        public string IssuseNumber { get; set; }

        [EntityMappingField("StartTime")]
        public DateTime StartTime { get; set; }

        [EntityMappingField("StopTime")]
        public DateTime StopTime { get; set; }

        [EntityMappingField("Status")]
        public int Status { get; set; }

        [EntityMappingField("BonusCode")]
        public string BonusCode { get; set; }

        [EntityMappingField("SalesMoney")]
        public decimal SalesMoney { get; set; }

        [EntityMappingField("BonusMoney")]
        public decimal BonusMoney { get; set; }

        [EntityMappingField("NoticeId")]
        public string NoticeId { get; set; }
    }
}
