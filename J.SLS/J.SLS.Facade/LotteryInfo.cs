using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Common;

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

    [EntityMappingTable("T_Issuses", ReadOnly = true)]
    public class IssuseInfo
    {
        [EntityMappingField("Id", IsKey = true, IsAutoField = true)]
        public long Id { get; set; }

        [EntityMappingField("GameName")]
        public string GameName { get; set; }

        [EntityMappingField("IssuseNumber")]
        public string IssuseNumber { get; set; }

        [EntityMappingField("StartTime")]
        public DateTime StartTime { get; set; }

        [EntityMappingField("StopTime")]
        public DateTime StopTime { get; set; }

        [EntityMappingField("Status")]
        public IssueStatus Status { get; set; }

        [EntityMappingField("BonusCode")]
        public string BonusCode { get; set; }

        [EntityMappingField("SalesMoney")]
        public decimal SalesMoney { get; set; }

        [EntityMappingField("BonusMoney")]
        public decimal BonusMoney { get; set; }

        [EntityMappingField("NoticeId")]
        public string NoticeId { get; set; }
    }

    /// <summary>
    /// 用戶截至投注、撤單時間提前分鐘數
    /// </summary>
    [EntityMappingTable("T_Lottery_PlayTypes", ReadOnly = true)]
    public class EndAheadMinuteInfo
    {
        /// <summary>
        /// 游戏名称
        /// </summary>
        [EntityMappingField("GameName")]
        public string GameName { get; set; }

        /// <summary>
        /// 用戶截至投注、撤單時間提前分鐘數。超過這個時間，進行系統處理：保底滿員，未滿撤單。
        /// </summary>
        [EntityMappingField("SystemEndAheadMinute")]
        public int SystemEndAheadMinute { get; set; }
    }

    ///// <summary>
    ///// 玩法类型。单式，复式
    ///// </summary>
    //[EntityMappingTable("T_Lottery_PlayTypes", ReadOnly = true)]
    //public class PlayTypeInfo
    //{
    //    /// <summary>
    //    /// 类型编号
    //    /// </summary>
    //    [EntityMappingField("Id", IsKey = true)]
    //    public int Id { get; set; }

    //    /// <summary>
    //    /// 彩票ID
    //    /// </summary>
    //    [EntityMappingField("LotteryId")]
    //    public int LotteryId { get; set; }

    //    /// <summary>
    //    /// 玩法名称
    //    /// </summary>
    //    [EntityMappingField("Name")]
    //    public string Name { get; set; }

    //    /// <summary>
    //    /// 用戶截至投注、撤單時間提前分鐘數。超過這個時間，進行系統處理：保底滿員，未滿撤單。
    //    /// </summary>
    //    [EntityMappingField("SystemEndAheadMinute")]
    //    public int SystemEndAheadMinute { get; set; }

    //    /// <summary>
    //    /// 单注价格
    //    /// </summary>
    //    [EntityMappingField("Price")]
    //    public decimal Price { get; set; }

    //    /// <summary>
    //    /// 此賣法的文件名
    //    /// </summary>
    //    [EntityMappingField("BuyFileName")]
    //    public string BuyFileName { get; set; }

    //    /// <summary>
    //    /// 最大允许的跟单人数
    //    /// </summary>
    //    [EntityMappingField("MaxFollowSchemeNumberOf")]
    //    public int MaxFollowSchemeNumberOf { get; set; }

    //    /// <summary>
    //    /// 能投注的最大倍数
    //    /// </summary>
    //    [EntityMappingField("MaxMultiple")]
    //    public int MaxMultiple { get; set; }
    //}
}
