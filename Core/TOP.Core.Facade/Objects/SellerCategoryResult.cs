using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 操作卖家自定义类目的服务器返回结果。用于新增、更新等操作。
    /// </summary>
    [TOPDataMappingAttribute("seller_cat")]
    public class SellerCategoryResult : TOPDataItem
    {
        /// <summary>
        /// 卖家自定义类目ID。 
        /// </summary>
        [TOPDataMappingAttribute("cid")]
        public string CategoryId { get; set; }
    }
}
