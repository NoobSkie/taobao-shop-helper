using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 商品列表中的商品项。仅包含基础项。
    /// </summary>
    [TOPDataMappingAttribute("item")]
    public class SampleListItem : TOPDataItem
    {
        /// <summary>
        /// 商品id 
        /// </summary>
        [TOPDataMappingAttribute("iid")]
        public string Id { get; set; }

        /// <summary>
        /// 商品标题,不能超过60字节 
        /// </summary>
        [TOPDataMappingAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// 卖家昵称 
        /// </summary>
        [TOPDataMappingAttribute("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 商品主图片地址 
        /// </summary>
        [TOPDataMappingAttribute("pic_path")]
        public string PicPath { get; set; }

        /// <summary>
        /// 商品价格，格式：5.00；单位：元；精确到：分 
        /// </summary>
        [TOPDataMappingAttribute("price")]
        public string Price { get; set; }

        /// <summary>
        /// 商品所在地
        /// </summary>
        [TOPDataMappingAttribute("location")]
        public string Location { get; set; }
    }
}
