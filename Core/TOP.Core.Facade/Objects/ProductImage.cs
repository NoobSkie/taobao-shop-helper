using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 产品的子图片.
    /// </summary>
    [TOPDataMappingAttribute("product_img")]
    public class ProductImage : TOPDataItem
    {
        /// <summary>
        /// 产品图片ID 
        /// </summary>
        [TOPDataMappingAttribute("pic_id")]
        public string PictureId { get; set; }

        /// <summary>
        /// 图片所属产品的ID 
        /// </summary>
        [TOPDataMappingAttribute("product_id")]
        public string ProductId { get; set; }

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
