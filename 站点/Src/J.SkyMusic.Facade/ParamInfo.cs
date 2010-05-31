using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SkyMusic.Domain;

namespace J.SkyMusic.Facade
{
    [EntityMappingTable("T_System_Params", ReadOnly = true)]
    public class ParamInfo
    {
        [EntityMappingField("ParamKey", IsKey = true)]
        public string Key { get; set; }

        [EntityMappingField("ParamValue")]
        public string Value { get; set; }
    }
}
