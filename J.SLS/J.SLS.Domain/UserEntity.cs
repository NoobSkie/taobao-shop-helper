using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SLS.Domain
{
    [EntityMappingTable("T_User_Login")]
    public class UserEntity
    {
        [EntityMappingField("UserId", IsKey = true)]
        public string UserId { get; set; }

        [EntityMappingField("UserName")]
        public string UserName { get; set; }

        [EntityMappingField("IsCanLogin")]
        public bool IsCanLogin { get; set; }

        [EntityMappingField("RegisterTime")]
        public DateTime RegisterTime { get; set; }
    }
}
