using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.DbFacade.Domains
{
    public class PageEntityBase
    {
        [EntityMappingField("Id", IsKey = true)]
        public string Id { get; internal set; }

        [EntityMappingField("Name")]
        public string Name { get; set; }

        [EntityMappingField("CreateTime")]
        public DateTime CreateTime { get; internal set; }

        [EntityMappingField("LastUpdateTime")]
        public DateTime LastUpdateTime { get; internal set; }
    }

    [EntityMappingTable("T_Page_List")]
    public class ListItemEntity : PageEntityBase
    {
    }

    [EntityMappingTable("T_Page_Html")]
    public class HtmlItemEntity : PageEntityBase
    {
        public string ListName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ItsListId { get; set; }
    }

    [EntityMappingTable("T_Page_Menus")]
    public class MenuItemEntity : PageEntityBase
    {
        public int Index { get; set; }

        public bool IsInner { get; set; }

        public bool IsListType { get; set; }

        public string InnerId { get; set; }

        public string OuterUrl { get; set; }

        public string ParentId { get; set; }

        public bool IsOpenNewWindow { get; set; }

        public int Level { get; set; }
    }
}
