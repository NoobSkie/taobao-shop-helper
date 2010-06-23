using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Common;

namespace J.SLS.Domain
{
    [EntityMappingTable("T_Ticket_List")]
    public class TicketEntity
    {
        /// <summary>
        /// 票号。票ID生成规则为(agentID+8位时间戳YYYYMMDD+10位递增流水号),最大长度24位
        /// </summary>
        [EntityMappingField("TicketId", IsKey = true)]
        public string TicketId { get; set; }

        /// <summary>
        /// 投注方式。如：单式、复式、胆拖
        /// </summary>
        [EntityMappingField("BuyType", NeedUpdate = false)]
        public int BuyType { get; set; }

        /// <summary>
        /// 该票的倍投数, 默认为1 倍。
        /// </summary>
        [EntityMappingField("Amount", NeedUpdate = false)]
        public int Amount { get; set; }

        /// <summary>
        /// 当前票的购买金额。
        /// </summary>
        [EntityMappingField("Money", NeedUpdate = false)]
        public decimal Money { get; set; }

        /// <summary>
        /// 购彩用户信息
        /// </summary>
        [EntityMappingField("UserId", NeedUpdate = false)]
        public string UserId { get; set; }

        [EntityMappingField("GameName", NeedUpdate = false)]
        public string GameName { get; set; }

        [EntityMappingField("IssuseNumber", NeedUpdate = false)]
        public string IssuseNumber { get; set; }

        [EntityMappingField("RequestTime", NeedUpdate = false)]
        public DateTime RequestTime { get; set; }

        [EntityMappingField("Status")]
        public int Status { get; set; }

        [EntityMappingField("ResponseCode")]
        public string ResponseCode { get; set; }

        [EntityMappingField("ResponseMessage")]
        public string ResponseMessage { get; set; }

        [EntityMappingField("ResponseTime")]
        public DateTime? ResponseTime { get; set; }
    }

    [EntityMappingTable("T_Ticket_AnteCodes")]
    public class TicketAnteCodeEntity
    {
        [EntityMappingField("Id", IsKey = true, IsAutoField = true)]
        public long Id { get; set; }

        [EntityMappingField("TicketId", NeedUpdate = false)]
        public string TicketId { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        [EntityMappingField("AnteCode", NeedUpdate = false)]
        public string AnteCode { get; set; }
    }

    [EntityMappingTable("T_Ticket_Detail")]
    public class TicketDetailEntity
    {
        [EntityMappingField("Id", IsKey = true, IsAutoField = true)]
        public long Id { get; set; }

        [EntityMappingField("UserId", NeedUpdate = false)]
        public string UserId { get; set; }

        [EntityMappingField("TicketId", NeedUpdate = false)]
        public string TicketId { get; set; }

        [EntityMappingField("Balance_Before", NeedUpdate = false)]
        public decimal BalanceBefore { get; set; }

        [EntityMappingField("Freeze_Before", NeedUpdate = false)]
        public decimal FreezeBefore { get; set; }

        [EntityMappingField("PayMoney", NeedUpdate = false)]
        public decimal PayMoney { get; set; }

        [EntityMappingField("Balance_After", NeedUpdate = false)]
        public decimal BalanceAfter { get; set; }

        [EntityMappingField("Freeze_After", NeedUpdate = false)]
        public decimal FreezeAfter { get; set; }

        [EntityMappingField("Status", NeedUpdate = false)]
        public int Status { get; set; }

        [EntityMappingField("Message", NeedUpdate = false)]
        public string Message { get; set; }

        [EntityMappingField("CurrentTime", NeedUpdate = false)]
        public DateTime CurrentTime { get; set; }
    }

    [EntityMappingTable("T_Chase_List")]
    public class ChaseEntity
    {
        [EntityMappingField("TicketId", IsKey = true)]
        public string TicketId { get; set; }

        [EntityMappingField("GameName", IsKey = true)]
        public string GameName { get; set; }

        [EntityMappingField("IssuseNumber", IsKey = true)]
        public string IssuseNumber { get; set; }

        [EntityMappingField("Amount", NeedUpdate = false)]
        public int Amount { get; set; }

        [EntityMappingField("Money", NeedUpdate = false)]
        public decimal Money { get; set; }

        [EntityMappingField("UserId", NeedUpdate = false)]
        public string UserId { get; set; }

        [EntityMappingField("Status")]
        public int Status { get; set; }

        [EntityMappingField("ChaseTicketId")]
        public string ChaseTicketId { get; set; }

        [EntityMappingField("ResponseTime")]
        public DateTime? ResponseTime { get; set; }

        [EntityMappingField("ResponseCode")]
        public string ResponseCode { get; set; }

        [EntityMappingField("ResponseMessage")]
        public string ResponseMessage { get; set; }
    }
}
