using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Common;

namespace J.SLS.Facade
{
    [EntityMappingTable("T_User_Login", ReadOnly = true)]
    public class LogInfo
    {
        [EntityMappingField("Id", IsKey = true)]
        public Guid Id { get; set; }

        [EntityMappingField("UserName")]
        public string Category { get; set; }

        [EntityMappingField("Source")]
        public string Source { get; set; }

        [EntityMappingField("LogIndex")]
        public long Index { get; set; }

        [EntityMappingField("LogType")]
        public LogType Type { get; set; }

        [EntityMappingField("LogMessage")]
        public string Message { get; set; }

        [EntityMappingField("LogTime")]
        public DateTime WriteTime { get; set; }

        internal bool isDetailLoaded = false;
        public string LogDetail { get; set; }
    }
}
