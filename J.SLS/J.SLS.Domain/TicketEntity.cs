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
        [EntityMappingField("BuyType")]
        public int BuyType { get; set; }

        /// <summary>
        /// 该票的倍投数, 默认为1 倍。
        /// </summary>
        [EntityMappingField("Amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 当前票的购买金额。
        /// </summary>
        [EntityMappingField("Money")]
        public decimal Money { get; set; }

        /// <summary>
        /// 购彩用户信息
        /// </summary>
        [EntityMappingField("UserId")]
        public string UserId { get; set; }

        [EntityMappingField("GameName")]
        public string GameName { get; set; }

        [EntityMappingField("IssuseNumber")]
        public string IssuseNumber { get; set; }
    }

    [EntityMappingTable("T_Ticket_AnteCodes")]
    public class TicketAnteCode
    {
        [EntityMappingField("TicketId", IsKey = true)]
        public string TicketId { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        [EntityMappingField("AnteCode", IsKey = true)]
        public string AnteCode { get; set; }
    }
}
