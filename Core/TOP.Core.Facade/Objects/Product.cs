using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// Product(产品结构)
    /// <remarks>
    /// 淘宝标准化产品，由类目+关键属性唯一确定。如：手机类目，关键属性是品牌和型号，Nokia N95就是一个产品,nokia是品牌，N95是型号。
    /// 产品除了关键属性还包括一般信息、销售属性和非关键属性。 
    /// </remarks>
    /// <example>
    /// 如"诺基亚N95"就是一个产品。通过类目的关键属性组合来确定唯一的产品。 
    /// 后台标准类目叶子节点下，一组共同特征商品的组合（例如：化妆品+雅芳+保湿单品+容量），属于同一个产品的商品可以认为对消费者的效用及使用感受是没有差别的。 
    /// </example>
    /// </summary>
    [TOPDataMappingAttribute("product")]
    public class Product : TOPDataItem
    {
        /// <summary>
        /// 产品ID 
        /// </summary>
        [TOPDataMappingAttribute("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// 外部产品ID
        /// 外部网店自己的产品id，可供外店自己查询或定位。 
        /// </summary>
        [TOPDataMappingAttribute("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// 淘宝标准产品编码
        /// 系统自动生成. 注:目前新生成的产品才会具有此编码.老的产品没有此数据. 
        /// </summary>
        [TOPDataMappingAttribute("tsc")]
        public string Tsc { get; set; }

        /// <summary>
        /// 商品类目ID.必须是叶子类目ID 
        /// </summary>
        [TOPDataMappingAttribute("cid")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 商品类目名称 
        /// </summary>
        [TOPDataMappingAttribute("cat_name")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 产品的关键属性列表.格式：pid:vid;pid:vid . 
        /// </summary>
        [TOPDataMappingAttribute("props")]
        public string Properties { get; set; }

        /// <summary>
        /// 产品的关键属性字符串列表.比如:品牌:诺基亚;型号:N73 
        /// </summary>
        [TOPDataMappingAttribute("props_str")]
        public string PropertiesString { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [TOPDataMappingAttribute("name")]
        public string ProductName { get; set; }

        /// <summary>
        /// 产品的非关键属性列表.格式:pid:vid;pid:vid. 
        /// </summary>
        [TOPDataMappingAttribute("binds")]
        public string Binds { get; set; }

        /// <summary>
        /// 产品的非关键属性字符串列表.格式同props_str 
        /// </summary>
        [TOPDataMappingAttribute("binds_str")]
        public string BindsString { get; set; }

        /// <summary>
        /// 产品的销售属性列表.格式:pid:vid;pid:vid 
        /// </summary>
        [TOPDataMappingAttribute("sale_props")]
        public string SaleProperties { get; set; }

        /// <summary>
        /// 产品的销售属性字符串列表.格式同props_str 
        /// </summary>
        [TOPDataMappingAttribute("sale_props_str")]
        public string SalePropertiesString { get; set; }

        /// <summary>
        /// 产品的市场价.单位为元.精确到2位小数;如:200.07 
        /// </summary>
        [TOPDataMappingAttribute("price")]
        public string Price { get; set; }

        /// <summary>
        /// 产品的描述.最大25000个字节 
        /// </summary>
        [TOPDataMappingAttribute("desc")]
        public string Description { get; set; }

        /// <summary>
        /// 产品的主图片地址.(绝对地址,格式:http://host/image_path) 
        /// </summary>
        [TOPDataMappingAttribute("pic_path")]
        public string PicturePath { get; set; }

        /// <summary>
        /// 产品的子图片.目前最多支持4张 
        /// </summary>
        [TOPDataMappingAttribute("product_img", "product_imgs")]
        public TOPDataList<ProductImage> ProductImageList { get; set; }

        /// <summary>
        /// 产品的属性图片.比如说黄色对应的产品图片,绿色对应的产品图片 
        /// </summary>
        [TOPDataMappingAttribute("product_prop_img", "product_prop_imgs")]
        public TOPDataList<ProductPropertyImage> ProductPropertyImageList { get; set; }

        /// <summary>
        /// 创建时间.格式:yyyy-mm-dd hh:mm:ss
        /// </summary>
        [TOPDataMappingAttribute("created")]
        public string CreatedDate { get; set; }

        /// <summary>
        /// 修改时间.格式:yyyy-mm-dd hh:mm:ss 
        /// </summary>
        [TOPDataMappingAttribute("modified")]
        public string ModifiedDate { get; set; }
    }
}
