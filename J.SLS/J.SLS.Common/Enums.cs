using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common
{
    public enum LoginErrorType
    {
        UserIdOrPasswordError = 1,
        UserCannotLogin = 2,
    }

    public enum LogType : short
    {
        Information = 0,
        Warning = 1,
        Error = 2,
    }

    /// <summary>
    /// 奖期状态
    /// </summary>
    public enum IssueStatus
    {
        /// <summary>
        /// 未开启
        /// </summary>
        Waitting = 0,
        /// <summary>
        /// 开始 
        /// </summary>
        Started = 1,
        /// <summary>
        /// 暂停 
        /// </summary>
        Paused = 2,
        /// <summary>
        /// 截止
        /// </summary>
        Stopped = 3,
        /// <summary>
        /// 期结
        /// </summary>
        Finished = 4,
        /// <summary>
        /// 返奖
        /// </summary>
        Awarding = 5,
        /// <summary>
        /// 返奖结束
        /// </summary>
        Awarded = 6,
    }

    public enum MappingType
    {
        Element = 0,
        Attribute = 1,
    }

    public enum XmlObjectType
    {
        Item = 0,
        List = 1,
    }

    public enum TranType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unkown = 0,
        /// <summary>
        /// 奖期通知请求
        /// </summary>
        IssueNotifyRequest = 101,
        /// <summary>
        /// 奖期通知响应
        /// </summary>
        IssueNotifyResponse = 501,
    }
}
