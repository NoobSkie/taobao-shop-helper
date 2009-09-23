using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 商品列表中的商品项
    /// </summary>
    [TOPDataMappingAttribute("item")]
    public class ItemListItem : TOPDataItem
    {
        /// <summary>
        /// 商品id 
        /// </summary>
        [TOPDataMappingAttribute("iid")]
        public string Id { get; set; }

        /// <summary>
        /// 商品url 
        /// </summary>
        [TOPDataMappingAttribute("detail_url")]
        public string DetailUrl { get; set; }

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
        /// 商品类型(fixed:一口价;auction:拍卖)注：取消团购 
        /// </summary>
        [TOPDataMappingAttribute("type")]
        public string ItemType { get; set; }

        /// <summary>
        /// 商品所属的叶子类目 id 
        /// </summary>
        [TOPDataMappingAttribute("cid")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 商品属性 格式：pid:vid;pid:vid 
        /// </summary>
        [TOPDataMappingAttribute("props")]
        public string Properties { get; set; }

        /// <summary>
        /// 属性值别名
        /// </summary>
        [TOPDataMappingAttribute("property_alias")]
        public string PropertyAlias { get; set; }

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
        /// 平邮费用,格式：5.00；单位：元；精确到：分 
        /// </summary>
        [TOPDataMappingAttribute("post_fee")]
        public string FeePost { get; set; }

        /// <summary>
        /// 快递费用,格式：5.00；单位：元；精确到：分 
        /// </summary>
        [TOPDataMappingAttribute("express_fee")]
        public string FeeExpress { get; set; }

        /// <summary>
        /// ems费用,格式：5.00；单位：元；精确到：分 
        /// </summary>
        [TOPDataMappingAttribute("ems_fee")]
        public string FeeEms { get; set; }

        /// <summary>
        /// 运费承担方式,seller（卖家承担），buyer(买家承担） 
        /// </summary>
        [TOPDataMappingAttribute("freight_payer")]
        public string FreightPayer { get; set; }

        /// <summary>
        /// 商品所在地
        /// </summary>
        [TOPDataMappingAttribute("location")]
        public string Location { get; set; }

        /// <summary>
        /// 商品新旧程度(全新:new，闲置:unused，二手：second) 
        /// </summary>
        [TOPDataMappingAttribute("stuff_status")]
        public string StuffStatus { get; set; }
    }
}
