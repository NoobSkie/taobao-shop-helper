using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.DbFacade.Services
{
    public class PageItemInfo
    {
        [EntityMappingField("Id", IsKey = true)]
        public string Id { get; set; }

        [EntityMappingField("Name")]
        public string Name { get; set; }

        [EntityMappingField("CreateTime")]
        public DateTime CreateTime { get; internal set; }

        [EntityMappingField("LastUpdateTime")]
        public DateTime LastUpdateTime { get; internal set; }
    }

    [EntityMappingTable("T_Page_List")]
    public class ListItemInfo : PageItemInfo
    {
    }

    [EntityMappingTable("T_Page_Html")]
    public class HtmlItemInfo : PageItemInfo
    {
        [EntityMappingField("ParentListId")]
        public string ItsListId { get; set; }
    }

    [EntityMappingTable("T_Page_Html")]
    public class HtmlItemFullInfo : HtmlItemInfo
    {
        [EntityMappingField("TitleHtml")]
        public string Title { get; set; }

        [EntityMappingField("ContentHtml")]
        public string Content { get; set; }
    }

    [EntityMappingTable("T_Page_Menus")]
    public class MenuItemInfo : PageItemInfo
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
