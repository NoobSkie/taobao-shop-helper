using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 状态定义
    /// 
    /// * 当奖期状态为1的时候，表示电话投注系统已经创建了一个
    ///新的奖期，但是不表示接入系统已经可以接受该奖期的投注
    ///数据，只有在当前时间已经过了issue.startTime之后，电话投
    ///注系统才会接受代理商的投注数据。
    ///* 当奖期状态为5的时候，电话投注系统不会主动下发状态为
    ///5的奖期通知，而是在下发一个返奖通知（transactionType =
    ///108）。但是代理商通过奖期查询可以查询到5的状态。
    /// </summary>
    public enum StatusType
    {
        /// <summary>
        /// 创建新奖期
        /// </summary>
        CreateNewIssue = 1,
        /// <summary>
        /// 暂停奖期
        /// </summary>
        PauseIssue = 2,
        /// <summary>
        /// 奖期截止
        /// </summary>
        IssueCutoff = 3,
        /// <summary>
        /// 完成期结，可以执行销量查询
        /// </summary>
        CompleteIssueEnd = 4,
        /// <summary>
        /// 完成兑奖，可以执行返奖查询
        /// </summary>
        CompleteCashAward = 5,
        /// <summary>
        /// 摇出开奖号码
        /// </summary>
        OpenWinNumber = 6,
        /// <summary>
        /// 完成期结和返奖,可执行返奖，销量查询
        /// </summary>
        CompleteIssueEndAndReward = 7
    }
}
