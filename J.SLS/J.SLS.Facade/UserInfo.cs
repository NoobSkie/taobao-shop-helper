using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SLS.Facade
{
    [EntityMappingTable("T_User_Login", ReadOnly = true)]
    public class LoginInfo
    {
        [EntityMappingField("UserId", IsKey = true)]
        public string UserId { get; set; }

        [EntityMappingField("UserName")]
        public string UserName { get; set; }

        [EntityMappingField("RegisterTime")]
        public DateTime RegisterTime { get; set; }
    }

    [EntityMappingTable("T_User_BaseInfo", ReadOnly = true)]
    public class UserInfo : LoginInfo
    {
        [EntityMappingField("Email", IsKey = true)]
        public string Email { get; set; }

        [EntityMappingField("RealName")]
        public string RealName { get; set; }
    }
}
