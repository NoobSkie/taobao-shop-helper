using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Common;

namespace J.SkyMusic.Domain
{
    [EntityMappingTable("T_Log_List")]
    public class LogEntity
    {
        [EntityMappingField("Id", IsKey = true)]
        public Guid Id { get; set; }

        [EntityMappingField("Category")]
        public string Category { get; set; }

        [EntityMappingField("Source")]
        public string Source { get; set; }

        [EntityMappingField("LogType")]
        public short Type { get; set; }

        [EntityMappingField("LogMessage")]
        public string Message { get; set; }

        [EntityMappingField("LogTime")]
        public DateTime WriteTime { get; set; }
    }

    [EntityMappingTable("T_Log_Detail")]
    public class LogDetailEntity
    {
        [EntityMappingField("Id", IsKey = true)]
        public Guid Id { get; set; }

        [EntityMappingField("LogDetail")]
        public string LogDetail { get; set; }
    }
}
