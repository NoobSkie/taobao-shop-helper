using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.DbFacade.Domains
{
    [EntityMappingTable("T_Notice_List")]
    public class NoticeEntity
    {
        [EntityMappingField("Id", IsKey = true, IsAutoField = true)]
        public long Id { get; set; }

        [EntityMappingField("Title")]
        public string Title { get; set; }

        [EntityMappingField("IsHasDetail")]
        public bool IsHasDetail { get; set; }

        [EntityMappingField("Message")]
        public string Message { get; set; }

        [EntityMappingField("IsForeRed")]
        public bool IsForeRed { get; set; }

        [EntityMappingField("IsForeBold")]
        public bool IsForeBold { get; set; }

        [EntityMappingField("StartTime")]
        public DateTime StartTime { get; set; }

        [EntityMappingField("EndTime")]
        public DateTime EndTime { get; set; }

        [EntityMappingField("CreateTime")]
        public DateTime CreateTime { get; set; }

        [EntityMappingField("UpdateTime")]
        public DateTime UpdateTime { get; set; }

        [EntityMappingField("IsEnd")]
        public bool IsEnd { get; set; }
    }
}
