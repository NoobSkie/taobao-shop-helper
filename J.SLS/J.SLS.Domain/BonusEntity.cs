using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using J.SLS.Common;
using J.SLS.Database.ORM;

namespace J.SLS.Domain
{
    [EntityMappingTable("T_Bonus_List")]
    public class BonusEntity
    {
        [EntityMappingField("GameName", IsKey = true)]
        public string GameName { get; set; }

        [EntityMappingField("IssuseNumber", IsKey = true)]
        public string IssuseNumber { get; set; }

        [EntityMappingField("BonusNumber", NeedUpdate = false)]
        public string BonusNumber { get; set; }

        [EntityMappingField("TotalItems", NeedUpdate = false)]
        public int TotalItems { get; set; }

        [EntityMappingField("TotalMoney", NeedUpdate = false)]
        public decimal TotalMoney { get; set; }

        [EntityMappingField("NoticeId", NeedUpdate = false)]
        public string NoticeId { get; set; }

        [EntityMappingField("BonusTime", NeedUpdate = false)]
        public DateTime BonusTime { get; set; }

        [EntityMappingField("IsDistributed")]
        public bool IsDistributed { get; set; }

        [EntityMappingField("DistributeTime")]
        public DateTime? DistributeTime { get; set; }
    }

    [EntityMappingTable("T_Bonus_Detail")]
    public class BonusDetailEntity
    {
        [EntityMappingField("TicketId", IsKey = true)]
        public string TicketId { get; set; }

        [EntityMappingField("BonusLevel", IsKey = true)]
        public int BonusLevel { get; set; }

        [EntityMappingField("PlayType")]
        public int PlayType { get; set; }

        [EntityMappingField("Money")]
        public decimal Money { get; set; }

        [EntityMappingField("IsBombBonus")]
        public bool IsBombBonus { get; set; }

        [EntityMappingField("Size")]
        public int Size { get; set; }

        [EntityMappingField("GameName")]
        public string GameName { get; set; }

        [EntityMappingField("IssuseNumber")]
        public string IssuseNumber { get; set; }
    }

    [EntityMappingTable("T_Bonus_Distribute")]
    public class BonusDistributeEntity
    {
        [EntityMappingField("TicketId", IsKey = true)]
        public string TicketId { get; set; }

        [EntityMappingField("BonusLevel", IsKey = true)]
        public int BonusLevel { get; set; }

        [EntityMappingField("UserId")]
        public string UserId { get; set; }

        [EntityMappingField("GameName")]
        public string GameName { get; set; }

        [EntityMappingField("IssuseNumber")]
        public string IssuseNumber { get; set; }

        [EntityMappingField("PlayType")]
        public int PlayType { get; set; }

        [EntityMappingField("IsBombBonus")]
        public bool IsBombBonus { get; set; }

        [EntityMappingField("BonusSize")]
        public int BonusSize { get; set; }

        [EntityMappingField("Money")]
        public decimal Money { get; set; }

        [EntityMappingField("DistributeTime")]
        public DateTime DistributeTime { get; set; }
    }
}
