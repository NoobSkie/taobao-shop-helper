using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.Domain
{
    [EntityMappingTable("T_Menu_List")]
    public class MenuEntity
    {
        [EntityMappingField("Id", IsKey = true)]
        public Guid Id { get; set; }

        [EntityMappingField("Name")]
        public string Name { get; set; }

        [EntityMappingField("PIndex")]
        public int Index { get; set; }

        [EntityMappingField("Url")]
        public string Url { get; set; }

        [EntityMappingField("ParentId")]
        public Guid? ParentId { get; set; }

        [EntityMappingField("IsNewWindow")]
        public bool IsNewWindow { get; set; }
    }
}
