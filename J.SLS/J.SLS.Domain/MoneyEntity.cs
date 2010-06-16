using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using J.SLS.Common;
using J.SLS.Database.ORM;

namespace J.SLS.Domain
{
    [EntityMappingTable("T_Money_GetDetail")]
    public class MoneyGetDetailEntity
    {
        [EntityMappingField("Id", IsKey = true, IsAutoField = true)]
        public long Id { get; set; }

        [EntityMappingField("UserId", NeedUpdate = false)]
        public string UserId { get; set; }

        [EntityMappingField("BankType", NeedUpdate = false)]
        public int BankType { get; set; }

        [EntityMappingField("BankName", NeedUpdate = false)]
        public string BankName { get; set; }

        [EntityMappingField("BankCardNumber", NeedUpdate = false)]
        public string BankCardNumber { get; set; }

        [EntityMappingField("RequestMoney", NeedUpdate = false)]
        public decimal RequestMoney { get; set; }

        [EntityMappingField("RequestTime", NeedUpdate = false)]
        public DateTime RequestTime { get; set; }

        [EntityMappingField("Status")]
        public int Status { get; set; }

        [EntityMappingField("ResponseMoney")]
        public decimal? ResponseMoney { get; set; }

        [EntityMappingField("ResponseTime")]
        public DateTime? ResponseTime { get; set; }

        [EntityMappingField("ResponseMessage")]
        public string ResponseMessage { get; set; }

        [EntityMappingField("ResponseUserId")]
        public string ResponseUserId { get; set; }
    }
}
