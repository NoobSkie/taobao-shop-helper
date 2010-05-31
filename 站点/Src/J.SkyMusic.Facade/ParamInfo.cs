using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SkyMusic.Domain;

namespace J.SkyMusic.Facade
{
    [EntityMappingTable("T_System_Param", ReadOnly = true)]
    public class ParamInfo : ParamEntity
    {
    }
}
