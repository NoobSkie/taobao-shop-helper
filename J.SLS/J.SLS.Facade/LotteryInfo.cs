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

    /// <summary>
    /// 奖期信息
    /// </summary>
    [EntityMappingTable("T_Lottery_Isuses", ReadOnly = true)]
    public class IsuseInfo
    {
        /// <summary>
        /// 期号ID
        /// </summary>
        [EntityMappingField("Id", IsKey = true)]
        public int Id { get; set; }

        /// <summary>
        /// 彩票ID
        /// </summary>
        [EntityMappingField("LotteryId")]
        public int LotteryId { get; set; }

        /// <summary>
        /// 期号名称
        /// </summary>
        [EntityMappingField("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 开始投注时间
        /// </summary>
        [EntityMappingField("StartTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        [EntityMappingField("EndTime")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 追号任务是否执行了
        /// </summary>
        [EntityMappingField("ChaseExecuted")]
        public bool ChaseExecuted { get; set; }

        /// <summary>
        /// 是否开奖了
        /// </summary>
        [EntityMappingField("IsOpened")]
        public bool IsOpened { get; set; }

        /// <summary>
        /// 开奖号码
        /// </summary>
        [EntityMappingField("WinLotteryNumber")]
        public string WinLotteryNumber { get; set; }

        /// <summary>
        /// 开奖操作员ID
        /// </summary>
        [EntityMappingField("WinLotteryNumber")]
        public string OpenOperatorID { get; set; }

        /// <summary>
        /// 奖期状态：0 未开启 1 开始 2 暂停 3 截止 4 期结 5 返奖 6 返奖结束
        /// </summary>
        [EntityMappingField("WinLotteryNumber")]
        public short State { get; set; }

        /// <summary>
        /// 奖期状态的更新时间
        /// </summary>
        [EntityMappingField("StateUpdateTime")]
        public DateTime StateUpdateTime { get; set; }
    }

    /// <summary>
    /// 用戶截至投注、撤單時間提前分鐘數
    /// </summary>
    [EntityMappingTable("T_PlayTypes", ReadOnly = true)]
    public class EndAheadMinuteInfo
    {
        /// <summary>
        /// 彩票ID
        /// </summary>
        [EntityMappingField("LotteryId")]
        public int LotteryId { get; set; }

        /// <summary>
        /// 用戶截至投注、撤單時間提前分鐘數。超過這個時間，進行系統處理：保底滿員，未滿撤單。
        /// </summary>
        [EntityMappingField("SystemEndAheadMinute")]
        public int SystemEndAheadMinute { get; set; }
    }

    /// <summary>
    /// 玩法类型。单式，复式
    /// </summary>
    [EntityMappingTable("T_PlayTypes", ReadOnly = true)]
    public class PlayType
    {
        /// <summary>
        /// 类型编号
        /// </summary>
        [EntityMappingField("Id", IsKey = true)]
        public int Id { get; set; }

        /// <summary>
        /// 彩票ID
        /// </summary>
        [EntityMappingField("LotteryId")]
        public int LotteryId { get; set; }

        /// <summary>
        /// 玩法名称
        /// </summary>
        [EntityMappingField("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 用戶截至投注、撤單時間提前分鐘數。超過這個時間，進行系統處理：保底滿員，未滿撤單。
        /// </summary>
        [EntityMappingField("SystemEndAheadMinute")]
        public int SystemEndAheadMinute { get; set; }

        /// <summary>
        /// 单注价格
        /// </summary>
        [EntityMappingField("Price")]
        public decimal Price { get; set; }

        /// <summary>
        /// 此賣法的文件名
        /// </summary>
        [EntityMappingField("BuyFileName")]
        public string BuyFileName { get; set; }

        /// <summary>
        /// 最大允许的跟单人数
        /// </summary>
        [EntityMappingField("MaxFollowSchemeNumberOf")]
        public int MaxFollowSchemeNumberOf { get; set; }

        /// <summary>
        /// 能投注的最大倍数
        /// </summary>
        [EntityMappingField("MaxMultiple")]
        public int MaxMultiple { get; set; }
    }
}
