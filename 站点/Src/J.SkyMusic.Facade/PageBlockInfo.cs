using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.Facade
{
    [EntityMappingTable("T_Block_List")]
    public class PageBlockInfo
    {
        [EntityMappingField("Id", IsKey = true)]
        public Guid Id { get; set; }

        [EntityMappingField("XIndex")]
        public int XIndex { get; set; }

        [EntityMappingField("YIndex")]
        public int YIndex { get; set; }

        [EntityMappingField("ToItemId")]
        public Guid ContentId { get; set; }

        public ItemBase ContentItem { get; set; }

        [EntityMappingField("StyleId")]
        public Guid StyleId { get; set; }

        [EntityMappingField("DisplayCount")]
        public int DisplayCount { get; set; }

        [EntityMappingField("OrderBy")]
        public string OrderBy { get; set; }

        [EntityMappingField("Direction")]
        public int Direction { get; set; }
    }
}
