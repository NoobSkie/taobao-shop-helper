using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using System.Xml;

namespace J.SkyMusic.DbFacade.Domain
{
    [EntityMappingTable("T_System_Params")]
    public class ParamEntity
    {
        [EntityMappingField("ParamKey", IsKey = true)]
        public string Key { get; set; }

        [EntityMappingField("ParamValue")]
        public string Value { get; set; }
    }
}
