using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;

namespace TOP.Management.Domain
{
    /// <summary>
    /// 商品后台类目结构(ItemCat)
    /// </summary>
    [DbTable(DbTableName = "ItemCategory", DbObjectType = DbObjectType.Table)]
    public class ItemCategory : DbEntity
    {
        /// <summary>
        /// 商品所属类目ID  
        /// </summary>
        [DbField(DbFieldName = "CategoryId", DbFieldType = DbDataType.NVARCHAR, Length = 50)]
        public string CategoryId { get; set; }

        /// <summary>
        /// 父类目ID=0时，代表的是一级的类目
        /// </summary>
        [DbField(DbFieldName = "ParentId", DbFieldType = DbDataType.NVARCHAR, Length = 50)]
        public string ParentId { get; set; }

        /// <summary>
        /// 类目名称 
        /// </summary>
        [DbField(DbFieldName = "Name", DbFieldType = DbDataType.NVARCHAR, Length = 100)]
        public string Name { get; set; }

        /// <summary>
        /// 该类目是否为父类目(即：该类目是否还有子类目) 
        /// </summary>
        [DbField(DbFieldName = "IsParent", DbFieldType = DbDataType.BIT)]
        public bool IsParent { get; set; }

        /// <summary>
        /// 状态。可选值:normal(正常),deleted(删除) 
        /// </summary>
        [DbField(DbFieldName = "Status", DbFieldType = DbDataType.NVARCHAR, Length = 20)]
        public string Status { get; set; }

        /// <summary>
        /// 排列序号，表示同级类目的展现次序，如数值相等则按名称次序排列。取值范围:大于零的整数 
        /// </summary>
        [DbField(DbFieldName = "SortOrder", DbFieldType = DbDataType.INT)]
        public int SortOrder { get; set; }
    }
}
