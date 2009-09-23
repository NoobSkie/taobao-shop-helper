using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 对应到淘宝，SKU指销售属性的组合，表示一组最小销售单位。如颜色：金色;套餐：单电单充，描述手机销售时实物特征。
    /// </summary>
    /// <example>1627207:3232483;21921:44886 这个销售属性的PID和VID组合，对应的是，颜色:军绿色;运动鞋尺码:27.5 </example>
    [TOPDataMappingAttribute("sku")]
    public class Sku : TOPDataItem
    {
        /// <summary>
        /// sku的id 
        /// </summary>
        [TOPDataMappingAttribute("sku_id")]
        public string Id { get; set; }

        /// <summary>
        /// sku所属商品id 
        /// </summary>
        [TOPDataMappingAttribute("iid")]
        public string ItemId { get; set; }

        /// <summary>
        /// sku的销售属性组合字符串（颜色，大小，等等，可通过类目API获取某类目下的销售属性）,格式是p1:v1;p2:v2 
        /// </summary>
        [TOPDataMappingAttribute("properties")]
        public string Properties { get; set; }

        /// <summary>
        /// 属于这个sku的商品的数量
        /// </summary>
        [TOPDataMappingAttribute("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 属于这个sku的商品的价格 取值范围:0-100000000;精确到2位小数;单位:元。如:200.07，表示:200元7分。 
        /// </summary>
        [TOPDataMappingAttribute("price")]
        public string Price { get; set; }

        /// <summary>
        /// 商家设置的外部id 
        /// </summary>
        [TOPDataMappingAttribute("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// sku创建日期 时间格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        [TOPDataMappingAttribute("created")]
        public string CreateTime { get; set; }

        /// <summary>
        /// sku最后修改日期 时间格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        [TOPDataMappingAttribute("modified")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// sku状态。 normal:正常 ；delete:删除 
        /// </summary>
        [TOPDataMappingAttribute("status")]
        public string Status { get; set; }
    }
}
