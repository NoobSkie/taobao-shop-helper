using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 商品属性图片
    /// </summary>
    [TOPDataMappingAttribute("propimg")]
    public class PropImg : TOPDataItem
    {
        /// <summary>
        /// 属性图片的id 
        /// </summary>
        [TOPDataMappingAttribute("itemimg_id")]
        public string ItemImgId { get; set; }

        /// <summary>
        /// 图片链接地址
        /// </summary>
        [TOPDataMappingAttribute("url")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 图片所对应的属性组合的字符串 
        /// </summary>
        [TOPDataMappingAttribute("properties")]
        public string Properties { get; set; }

        /// <summary>
        /// 图片放在第几张（多图时可设置） 
        /// </summary>
        [TOPDataMappingAttribute("position")]
        public string Position { get; set; }
    }
}
