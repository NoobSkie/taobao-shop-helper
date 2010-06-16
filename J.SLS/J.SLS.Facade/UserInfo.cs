using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Common;

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
        public int IdCardType { get; set; }

        [EntityMappingField("CardNumber")]
        public string IdCardNumber { get; set; }

        [EntityMappingField("BankType")]
        public int BankType { get; set; }

        [EntityMappingField("BankName")]
        public string BankName { get; set; }

        [EntityMappingField("BankCardNumber")]
        public string BankCardNumber { get; set; }

        [EntityMappingField("Mobile")]
        public string Mobile { get; set; }

        [EntityMappingField("Balance")]
        public decimal? Balance { get; set; }

        [EntityMappingField("Freeze")]
        public decimal? Freeze { get; set; }

        [EntityMappingField("RoleType")]
        public UserRoleType UserRole { get; set; }

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

    [EntityMappingTable("V_Money_RequestGet", ReadOnly = true)]
    public class RequestGetMoneyInfo
    {
        [EntityMappingField("Id", IsKey = true)]
        public long Id { get; set; }

        [EntityMappingField("UserId")]
        public string UserId { get; set; }

        [EntityMappingField("RealName")]
        public string UserName { get; set; }

        [EntityMappingField("BankType")]
        public int BankType { get; set; }

        [EntityMappingField("BankName")]
        public string BankName { get; set; }

        [EntityMappingField("BankCardNumber")]
        public string BankCardNumber { get; set; }

        [EntityMappingField("RequestMoney")]
        public decimal RequestMoney { get; set; }

        [EntityMappingField("RequestTime")]
        public DateTime RequestTime { get; set; }

        [EntityMappingField("Status")]
        public MoneyGetStatus Status { get; set; }

        [EntityMappingField("ResponseMoney")]
        public decimal? ResponseMoney { get; set; }

        [EntityMappingField("ResponseTime")]
        public DateTime? ResponseTime { get; set; }

        [EntityMappingField("ResponseMessage")]
        public string ResponseMessage { get; set; }

        [EntityMappingField("ResponseUserId")]
        public string ResponseUserId { get; set; }

        [EntityMappingField("ResponseUserName")]
        public string ResponseUserName { get; set; }
    }
}
