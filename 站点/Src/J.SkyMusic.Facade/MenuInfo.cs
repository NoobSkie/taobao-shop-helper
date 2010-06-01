using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.Facade
{
    [EntityMappingTable("T_Menu_List", ReadOnly = true)]
    public class MenuInfo
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

        public MenuInfo Parent { get; set; }

        public IList<MenuInfo> Children { get; set; }
    }
}
