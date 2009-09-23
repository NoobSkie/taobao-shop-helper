using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 商品明细信息
    /// </summary>
    [TOPDataMappingAttribute("item")]
    public class ItemDetail : TOPDataItem
    {
        /// <summary>
        /// 商品id 
        /// </summary>
        [TOPDataMappingAttribute("iid")]
        public string Id { get; set; }

        /// <summary>
        /// 商品数量 
        /// </summary>
        [TOPDataMappingAttribute("num")]
        public string Number { get; set; }

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
        /// 有效期,7或者14（默认是14天） 
        /// </summary>
        [TOPDataMappingAttribute("valid_thru")]
        public string ValidateDate { get; set; }

        /// <summary>
        /// 支持会员打折,true/false 
        /// </summary>
        [TOPDataMappingAttribute("has_discount")]
        public string HasDiscount { get; set; }

        /// <summary>
        /// 是否有发票,true/false 
        /// </summary>
        [TOPDataMappingAttribute("has_invoice")]
        public string HasInvoice { get; set; }

        /// <summary>
        /// 是否有保修,true/false 
        /// </summary>
        [TOPDataMappingAttribute("has_warranty")]
        public string HasWarranty { get; set; }

        /// <summary>
        /// 橱窗推荐,true/false 
        /// </summary>
        [TOPDataMappingAttribute("has_showcase")]
        public string HasShowCase { get; set; }

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
        public Location Location { get; set; }

        /// <summary>
        /// 商品新旧程度(全新:new，闲置:unused，二手：second) 
        /// </summary>
        [TOPDataMappingAttribute("stuff_status")]
        public string StuffStatus { get; set; }

        /// <summary>
        /// 商品上传后的状态。onsale出售中，instock库中 
        /// </summary>
        [TOPDataMappingAttribute("approve_status")]
        public string ApproveStatus { get; set; }

        /// <summary>
        /// 上架时间（格式：yyyy-MM-dd HH:mm:ss） 
        /// </summary>
        [TOPDataMappingAttribute("list_time")]
        public string ListTime { get; set; }

        /// <summary>
        /// 下架时间（格式：yyyy-MM-dd HH:mm:ss） 
        /// </summary>
        [TOPDataMappingAttribute("delist_time")]
        public string DelistTime { get; set; }

        /// <summary>
        /// 商品所属的店铺内卖家自定义类目列表 
        /// </summary>
        [TOPDataMappingAttribute("seller_cids")]
        public string SellerCids { get; set; }

        /// <summary>
        /// 用户自行输入的类目属性ID串。结构："pid1,pid2,pid3"，如："20000"（表示品牌） 注：通常一个类目下用户可输入的关键属性不超过1个。 
        /// </summary>
        [TOPDataMappingAttribute("input_pids")]
        public string InputPids { get; set; }

        /// <summary>
        /// 用户自行输入的子属性名和属性值，
        /// 结构:"父属性值;一级子属性名;一级子属性值;二级子属性名;自定义输入值,....",
        /// 如：“耐克;耐克系列;科比系列;科比系列;2K5”，input_str需要与input_pids一一对应，
        /// 注：通常一个类目下用户可输入的关键属性不超过1个。所有属性别名加起来不能超过 3999字节。  
        /// </summary>
        [TOPDataMappingAttribute("input_str")]
        public string InputStr { get; set; }

        /// <summary>
        /// 商品描述, 字数要大于5个字节，小于25000个字节 
        /// </summary>
        [TOPDataMappingAttribute("desc")]
        public string Description { get; set; }

        /// <summary>
        /// 商品修改时间（格式：yyyy-MM-dd HH:mm:ss） 
        /// </summary>
        [TOPDataMappingAttribute("modified")]
        public string ModifiedDate { get; set; }

        /// <summary>
        /// 加价幅度。如果为0，代表系统代理幅度
        /// </summary>
        [TOPDataMappingAttribute("increment")]
        public string Increment { get; set; }

        /// <summary>
        /// 自动重发,true/false 
        /// </summary>
        [TOPDataMappingAttribute("auto_repost")]
        public string AutoRepost { get; set; }

        /// <summary>
        /// 宝贝所属的运费模板ID，如果没有返回则说明没有使用运费模板 
        /// </summary>
        [TOPDataMappingAttribute("postage_id")]
        public string PostageId { get; set; }

        /// <summary>
        /// 宝贝所属产品的id(可能为空). 该字段可以通过taobao.products.search 得到 
        /// </summary>
        [TOPDataMappingAttribute("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// 返点比例
        /// </summary>
        [TOPDataMappingAttribute("auction_point")]
        public string AuctionPoint { get; set; }

        /// <summary>
        /// 商家外部编码(可与商家外部系统对接) 
        /// </summary>
        [TOPDataMappingAttribute("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// 虚拟商品的状态字段
        /// </summary>
        [TOPDataMappingAttribute("is_virtural")]
        public string IsVirtural { get; set; }

        /// <summary>
        /// 是否在淘宝显示 
        /// </summary>
        [TOPDataMappingAttribute("is_taobao")]
        public string IsTaobao { get; set; }

        /// <summary>
        /// 是否在外部网店显示 
        /// </summary>
        [TOPDataMappingAttribute("is_ex")]
        public string IsExtension { get; set; }

        /// <summary>
        /// 商品图片列表(包括主图)  
        /// </summary>
        [TOPDataMappingAttribute("itemimg", "itemimgs")]
        public TOPDataList<ItemImg> ItemImgList { get; set; }

        /// <summary>
        /// 商品属性图片列表 
        /// </summary>
        [TOPDataMappingAttribute("propimg", "propimgs")]
        public TOPDataList<PropImg> PropImgList { get; set; }

        /// <summary>
        /// SKU列表 
        /// </summary>
        [TOPDataMappingAttribute("sku", "skus")]
        public TOPDataList<Sku> SkuList { get; set; }

        /// <summary>
        /// SKU列表 
        /// </summary>
        [TOPDataMappingAttribute("video", "videos")]
        public TOPDataList<Video> VideoList { get; set; }
    }
}
