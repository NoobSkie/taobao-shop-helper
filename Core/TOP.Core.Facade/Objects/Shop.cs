using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 店铺信息(Shop)
    /// </summary>
    [TOPDataMappingAttribute("shop")]
    public class Shop : TOPDataItem
    {
        /// <summary>
        /// 类目ID。  
        /// </summary>
        [TOPDataMappingAttribute("sid")]
        public string Id { get; set; }

        /// <summary>
        /// 店铺所属的类目ID。 
        /// </summary>
        [TOPDataMappingAttribute("cid")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 卖家昵称。
        /// </summary>
        [TOPDataMappingAttribute("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 店铺标题。 
        /// </summary>
        [TOPDataMappingAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// 店铺描述。 
        /// </summary>
        [TOPDataMappingAttribute("desc")]
        public string Description { get; set; }

        /// <summary>
        /// 店铺公告。 
        /// </summary>
        [TOPDataMappingAttribute("bulletin")]
        public string Bulletin { get; set; }

        /// <summary>
        /// 店标地址。返回相对路径，可以用"http://logo.taobao.com/shop-logo/"来拼接成绝对路径。 
        /// </summary>
        [TOPDataMappingAttribute("pic_path")]
        public string PicturePath { get; set; }

        /// <summary>
        /// 开店时间。格式：yyyy-MM-dd HH:mm:ss。 
        /// </summary>
        [TOPDataMappingAttribute("created")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 最后修改时间。格式：yyyy-MM-dd HH:mm:ss。 
        /// </summary>
        [TOPDataMappingAttribute("modified")]
        public DateTime ModifiedTime { get; set; }
    }
}
