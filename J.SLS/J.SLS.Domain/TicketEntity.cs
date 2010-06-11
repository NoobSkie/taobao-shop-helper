using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Common;

namespace J.SLS.Domain
{
    public class TicketEntity
    {
        [EntityMappingField("Id", IsKey = true, IsAutoField = true)]
        public long Id { get; set; }

        /// <summary>
        /// 票号。票ID生成规则为(agentID+8位时间戳YYYYMMDD+10位递增流水号),最大长度24位
        /// </summary>
        public string TicketId { get; set; }

        /// <summary>
        /// 投注方式。如：单式、复式、胆拖
        /// </summary>
        public int BuyType { get; set; }

        /// <summary>
        /// 该票的倍投数, 默认为1 倍。
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 当前票的购买金额。
        /// </summary>
        public string Money { get; set; }

        /// <summary>
        /// 奖期信息
        /// </summary>
        public long IssueId { get; set; }

        /// <summary>
        /// 购彩用户信息
        /// </summary>
        public string UserId { get; set; }
    }

    [EntityMappingTable("T_Buy_AnteCodes")]
    public class TicketAnteCode
    {
        [EntityMappingField("TicketId", IsKey = true)]
        public long TicketId { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        [EntityMappingField("AnteCode", IsKey = true)]
        public string AnteCode { get; set; }
    }
}
