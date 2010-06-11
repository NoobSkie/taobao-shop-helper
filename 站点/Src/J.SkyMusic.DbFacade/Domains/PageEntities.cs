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

        [EntityMappingField("CreateTime", NeedUpdate = false)]
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
        [EntityMappingField("TitleHtml")]
        public string Title { get; set; }

        [EntityMappingField("ContentHtml")]
        public string Content { get; set; }

        [EntityMappingField("ParentListId", NeedUpdate = false)]
        public string ItsListId { get; set; }
    }

    [EntityMappingTable("T_Page_Menus")]
    public class MenuItemEntity : PageEntityBase
    {
        [EntityMappingField("PIndex")]
        public int Index { get; set; }

        [EntityMappingField("IsInner")]
        public bool IsInner { get; set; }

        [EntityMappingField("IsListType")]
        public bool IsListType { get; set; }

        [EntityMappingField("InnerItemId")]
        public string InnerId { get; set; }

        [EntityMappingField("OuterUrl")]
        public string OuterUrl { get; set; }

        [EntityMappingField("ParentId")]
        public string ParentId { get; set; }

        [EntityMappingField("IsNewWindow")]
        public bool IsOpenNewWindow { get; set; }

        [EntityMappingField("PLevel")]
        public int Level { get; set; }
    }
}
