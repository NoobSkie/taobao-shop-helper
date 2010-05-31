using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.Domain
{
    [EntityMappingTable("T_Page_Blocks")]
    public class PageBlockEntity
    {
        [EntityMappingField("Id", IsKey = true)]
        public Guid Id { get; set; }

        [EntityMappingField("XIndex")]
        public int XIndex { get; set; }

        [EntityMappingField("YIndex")]
        public int YIndex { get; set; }

        [EntityMappingField("Name")]
        public string Name { get; set; }

        [EntityMappingField("ContentId")]
        public Guid ContentId { get; set; }
    }
}
