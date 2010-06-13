using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SLS.Facade
{
    [EntityMappingTable("V_User_Detail", ReadOnly = true)]
    public class UserInfo
    {
        [EntityMappingField("UserId", IsKey = true)]
        public string UserId { get; set; }

        [EntityMappingField("UserName")]
        public string UserName { get; set; }

        [EntityMappingField("IsCanLogin")]
        public bool IsCanLogin { get; set; }

        [EntityMappingField("RegisterTime")]
        public DateTime RegisterTime { get; set; }

        [EntityMappingField("Email")]
        public string Email { get; set; }

        [EntityMappingField("RealName")]
        public string RealName { get; set; }

        [EntityMappingField("CardType")]
        public int CardType { get; set; }

        [EntityMappingField("CardNumber")]
        public string CardNumber { get; set; }

        [EntityMappingField("Mobile")]
        public string Mobile { get; set; }

        [EntityMappingField("Balance")]
        public decimal? Balance { get; set; }

        [EntityMappingField("Freeze")]
        public decimal? Freeze { get; set; }

        public decimal EnableMoney
        {
            get
            {
                if (Balance.HasValue)
                {
                    if (Freeze.HasValue)
                    {
                        return Balance.Value - Freeze.Value;
                    }
                    else
                    {
                        return Balance.Value;
                    }
                }
                return 0;
            }
        }
    }
}
