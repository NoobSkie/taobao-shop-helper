using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.Facade
{
    [EntityMappingTable("V_Block_List", ReadOnly = true)]
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

        [EntityMappingField("StyleId")]
        public Guid StyleId { get; set; }

        [EntityMappingField("DisplayCount")]
        public int DisplayCount { get; set; }

        [EntityMappingField("OrderBy")]
        public string OrderBy { get; set; }

        [EntityMappingField("Direction")]
        public int Direction { get; set; }

        [EntityMappingField("BlockName")]
        public string BlockName { get; set; }

        [EntityMappingField("TypeId")]
        public Guid TypeId { get; set; }

        [EntityMappingField("TypeName")]
        public string TypeName { get; set; }

        [EntityMappingField("TypeHasSub")]
        public bool TypeHasSub { get; set; }

        [EntityMappingField("TypeCode")]
        public short TypeCode { get; set; }

        [EntityMappingField("ToItemName")]
        public string ToItemName { get; set; }

        [EntityMappingField("ToItemTypeId")]
        public Guid ToItemTypeId { get; set; }

        [EntityMappingField("ToItemTypeName")]
        public string ToItemTypeName { get; set; }

        [EntityMappingField("ToItemTypeHasSub")]
        public bool ToItemTypeHasSub { get; set; }

        [EntityMappingField("ToItemTypeCode")]
        public short ToItemTypeCode { get; set; }
    }
}
