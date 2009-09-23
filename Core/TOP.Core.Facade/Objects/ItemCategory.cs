using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 商品后台类目结构(ItemCat)
    /// </summary>
    [TOPDataMappingAttribute("item_cat")]
    public class ItemCategory : TOPDataItem
    {
        /// <summary>
        /// 商品所属类目ID  
        /// </summary>
        [TOPDataMappingAttribute("cid")]
        public string Id { get; set; }

        /// <summary>
        /// 父类目ID=0时，代表的是一级的类目
        /// </summary>
        [TOPDataMappingAttribute("parent_cid")]
        public string ParentId { get; set; }

        /// <summary>
        /// 类目名称 
        /// </summary>
        [TOPDataMappingAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// 该类目是否为父类目(即：该类目是否还有子类目) 
        /// </summary>
        [TOPDataMappingAttribute("is_parent")]
        public bool IsParent { get; set; }

        /// <summary>
        /// 状态。可选值:normal(正常),deleted(删除) 
        /// </summary>
        [TOPDataMappingAttribute("status")]
        public string Status { get; set; }

        /// <summary>
        /// 排列序号，表示同级类目的展现次序，如数值相等则按名称次序排列。取值范围:大于零的整数 
        /// </summary>
        [TOPDataMappingAttribute("sort_order")]
        public int SortOrder { get; set; }
    }
}
