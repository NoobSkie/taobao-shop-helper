using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// Video视频结构
    /// </summary>
    [TOPDataMappingAttribute("video")]
    public class Video : TOPDataItem
    {
        /// <summary>
        /// 视频记录的id，和商品相对应 
        /// </summary>
        [TOPDataMappingAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// video的id，对应于视频的存储记录 
        /// </summary>
        [TOPDataMappingAttribute("video_id")]
        public string VideoId { get; set; }

        /// <summary>
        /// video的url连接地址 
        /// </summary>
        [TOPDataMappingAttribute("url")]
        public string Url { get; set; }

        /// <summary>
        /// 视频创建时间（格式：yyyy-MM-dd HH:mm:ss） 
        /// </summary>
        [TOPDataMappingAttribute("created")]
        public string CreatedDate { get; set; }

        /// <summary>
        /// 视频修改时间（格式：yyyy-MM-dd HH:mm:ss）  
        /// </summary>
        [TOPDataMappingAttribute("modified")]
        public string ModifiedDate { get; set; }
    }
}
