using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 店铺类目(ShopCat)
    /// </summary>
    [TOPDataMappingAttribute("shop_cat")]
    public class ShopCategory : TOPDataItem
    {
        /// <summary>
        /// 类目ID。  
        /// </summary>
        [TOPDataMappingAttribute("cid")]
        public string Id { get; set; }

        /// <summary>
        /// 注：此类目指前台类目，值等于0：表示此类目为一级类目，值不等于0：表示此类目有父类目 
        /// </summary>
        [TOPDataMappingAttribute("parent_cid")]
        public string ParentId { get; set; }

        /// <summary>
        /// 类目名称。
        /// </summary>
        [TOPDataMappingAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// 该类目是否为父类目。即：该类目是否还有子类目。  
        /// </summary>
        [TOPDataMappingAttribute("is_parent")]
        public bool IsParent { get; set; }
    }
}
