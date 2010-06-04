using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SLS.Facade
{
    [EntityMappingTable("T_Notice_Temp")]
    public class XmlNoticeInfo
    {
        [EntityMappingField("Id", IsKey = true, IsAutoField = true)]
        public long Id { get; set; }

        [EntityMappingField("RecevieTime")]
        public DateTime RecevieTime { get; set; }

        [EntityMappingField("XmlBody")]
        public string XmlBody { get; set; }
    }
}
