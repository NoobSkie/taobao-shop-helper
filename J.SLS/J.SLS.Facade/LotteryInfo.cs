using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SLS.Facade
{
    [EntityMappingTable("T_Lottery_List", ReadOnly = true)]
    public class LotteryInfoBase
    {
        [EntityMappingField("ID", IsKey = true)]
        public int Id { get; set; }

        [EntityMappingField("Name")]
        public string Name { get; set; }

        [EntityMappingField("Code")]
        public string Code { get; set; }

        [EntityMappingField("IsUsed")]
        public bool IsUsed { get; set; }
    }

    public class LotterySimpleInfo : LotteryInfoBase
    {
    }

    public class LotteryFullInfo : LotteryInfoBase
    {
    }
}
