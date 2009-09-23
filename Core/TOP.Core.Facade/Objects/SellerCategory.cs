using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 店铺内卖家自定义类目(SellerCat)
    /// </summary>
    [TOPDataMappingAttribute("seller_cat")]
    public class SellerCategory : TOPDataItem
    {
        /// <summary>
        /// 卖家自定义类目ID。 
        /// </summary>
        [TOPDataMappingAttribute("cid")]
        public string Id { get; set; }

        /// <summary>
        /// 父类目cid，值等于0：表示此类目为店铺下的一级类目，值不等于0：表示此类目有父类目 
        /// </summary>
        [TOPDataMappingAttribute("parent_cid")]
        public string ParentId { get; set; }

        /// <summary>
        /// 卖家自定义类目名称。 
        /// </summary>
        [TOPDataMappingAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// 链接图片地址。 
        /// </summary>
        [TOPDataMappingAttribute("pict_url")]
        public string PictureUrl { get; set; }

        /// <summary>
        /// 该类目在页面上的排序位置。
        /// </summary>
        [TOPDataMappingAttribute("sort_order")]
        public int SortOrder { get; set; }
    }
}
