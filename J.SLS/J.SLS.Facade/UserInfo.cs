using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SLS.Facade
{
    [EntityMappingTable("T_User_List", ReadOnly = true)]
    public class LoginInfo
    {
        [EntityMappingField("UserId", IsKey = true)]
        public int UserId { get; set; }

        [EntityMappingField("Name")]
        public string Name { get; set; }
    }
}
