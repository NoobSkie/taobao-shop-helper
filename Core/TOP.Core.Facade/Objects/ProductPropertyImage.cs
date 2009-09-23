using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 产品的属性图片.比如说黄色对应的产品图片,绿色对应的产品图片 
    /// </summary>
    [TOPDataMappingAttribute("product_prop_img")]
    public class ProductPropertyImage : TOPDataItem
    {
        /// <summary>
        /// 产品属性图片ID  
        /// </summary>
        [TOPDataMappingAttribute("pic_id")]
        public string PictureId { get; set; }

        /// <summary>
        /// 图片所属产品的ID 
        /// </summary>
        [TOPDataMappingAttribute("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// 属性串(pid:vid),目前只有颜色属性.如:颜色:红色表示为　1627207:28326 
        /// </summary>
        [TOPDataMappingAttribute("props")]
        public string Properties { get; set; }

        /// <summary>
        /// 图片地址.(绝对地址,格式:http://host/image_path) 
        /// </summary>
        [TOPDataMappingAttribute("url")]
        public string PictureUrl { get; set; }

        /// <summary>
        /// 图片序号
        /// </summary>
        [TOPDataMappingAttribute("position")]
        public int Position { get; set; }
    }
}
