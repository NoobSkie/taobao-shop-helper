using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 属性值(PropValue)
    /// </summary>
    [TOPDataMappingAttribute("prop_value")]
    public class ItemPropValue : TOPDataItem
    {
        /// <summary>
        /// 类目ID 
        /// </summary>
        [TOPDataMappingAttribute("cid")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 属性 ID。属性：描述特征含义的名字。比如颜色、容量、样式、型号
        /// </summary>
        [TOPDataMappingAttribute("pid")]
        public string PropertyId { get; set; }

        /// <summary>
        /// 属性名 
        /// </summary>
        [TOPDataMappingAttribute("prop_name")]
        public string PropertyName { get; set; }

        /// <summary>
        /// 属性值ID 
        /// </summary>
        [TOPDataMappingAttribute("vid")]
        public string ValueId { get; set; }

        /// <summary>
        /// 属性值：具体的一个特征的描述值。例如：红色（对颜色属性的一个描述） 
        /// </summary>
        [TOPDataMappingAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// 属性值别名 
        /// </summary>
        [TOPDataMappingAttribute("name_alias")]
        public string NameAlias { get; set; }

        /// <summary>
        /// 是否为父类目属性 
        /// </summary>
        [TOPDataMappingAttribute("is_parent")]
        public bool IsParent { get; set; }

        /// <summary>
        /// 状态。可选值:normal(正常),deleted(删除) 
        /// </summary>
        [TOPDataMappingAttribute("status")]
        public string Status { get; set; }

        /// <summary>
        /// 排列序号。取值范围:大于零的整数 
        /// </summary>
        [TOPDataMappingAttribute("sort_order")]
        public int SortOrder { get; set; }
    }
}
