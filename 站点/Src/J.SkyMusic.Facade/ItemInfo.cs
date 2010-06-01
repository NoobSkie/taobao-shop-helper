using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.Facade
{
    [EntityMappingTable("V_Item_List", ReadOnly = true)]
    public class ItemInfo
    {
        [EntityMappingField("Id", IsKey = true)]
        public Guid Id { get; set; }

        [EntityMappingField("ItemName")]
        public string ItemName { get; set; }

        [EntityMappingField("TypeId")]
        public Guid TypeId { get; set; }

        [EntityMappingField("TypeName")]
        public string TypeName { get; set; }

        [EntityMappingField("HasSub")]
        public bool HasSub { get; set; }

        [EntityMappingField("TypeCode")]
        public short TypeCode { get; set; }
    }

    public class ItemBase
    {
        [EntityMappingField("Id", IsKey = true)]
        public Guid Id { get; set; }

        [EntityMappingField("Name")]
        public string Name { get; set; }
    }

    [EntityMappingTable("T_Item_Collection", ReadOnly = true)]
    public class ItemCollectionInfo : ItemBase
    {
        public Guid? ParentId { get; set; }
    }

    [EntityMappingTable("T_Item_Html", ReadOnly = true)]
    public class ItemHtmlInfo : ItemBase
    {
        [EntityMappingField("TitleHtml")]
        public string TitleHtml { get; set; }

        [EntityMappingField("SummaryHtml")]
        public string SummaryHtml { get; set; }

        [EntityMappingField("ContentHtml")]
        public string AllHtml { get; set; }

        [EntityMappingField("PublishDate")]
        public DateTime PublishDate { get; set; }

        [EntityMappingField("LastUpdateDate")]
        public DateTime LastUpdateDate { get; set; }
    }

    [EntityMappingTable("T_Item_Detail", ReadOnly = true)]
    public class ItemDetailInfo : ItemHtmlInfo
    {
        [EntityMappingField("ParentId")]
        public Guid ItsCollectionId { get; set; }
    }
}
