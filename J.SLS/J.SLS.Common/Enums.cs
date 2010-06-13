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
        /// 摇出开奖号码
        /// </summary>
        Awarded = 6,
        /// <summary>
        /// 完成期结和返奖,可执行返奖，销量查询
        /// </summary>
        Complete = 7,
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
        Request101 = 101,
        /// <summary>
        /// 奖期查询请求
        /// </summary>
        Request102 = 102,
        /// <summary>
        /// 投注请求 
        /// </summary>
        Request103 = 103,
        /// <summary>
        /// 投注结果通知请求
        /// </summary>
        Request104 = 104,
        /// <summary>
        /// 票查询请求
        /// </summary>
        Request105 = 105,
        /// <summary>
        /// 返奖查询请求
        /// </summary>
        Request106 = 106,
        /// <summary>
        /// 销量查询请求
        /// </summary>
        Request107 = 107,
        /// <summary>
        /// 返奖通知请求
        /// </summary>
        Request108 = 108,
        /// <summary>
        /// 充值结果通知
        /// </summary>
        Request109 = 109,
        /// <summary>
        /// 充值查询请求 
        /// </summary>
        Request110 = 110,
        /// <summary>
        /// 提款请求 
        /// </summary>
        Request111 = 111,
        /// <summary>
        /// 提款结果通知 
        /// </summary>
        Request112 = 112,
        /// <summary>
        /// 提款查询请求 
        /// </summary>
        Request113 = 113,
        /// <summary>
        /// 赠送彩金请求
        /// </summary>
        Request114 = 114,
        /// <summary>
        /// 赠金查询请求 
        /// </summary>
        Request115 = 115,
        /// <summary>
        /// 帐户查询请求 
        /// </summary>
        Request116 = 116,
        /// <summary>
        /// 电话投注卡充值请求
        /// </summary>
        Request117 = 117,
        /// <summary>
        /// 帐户注册请求
        /// </summary>
        Request130 = 130,
        /// <summary>
        /// 帐户更新请求
        /// </summary>
        Request131 = 131,
        /// <summary>
        /// 风险控制查询请求 
        /// </summary>
        Request134 = 134,
        /// <summary>
        /// 奖期通知响应
        /// </summary>
        Response501 = 501,
        /// <summary>
        /// 奖期查询响应
        /// </summary>
        Response502 = 502,
        /// <summary>
        /// 投注响应
        /// </summary>
        Response503 = 503,
        /// <summary>
        /// 投注结果通知响应
        /// </summary>
        Response504 = 504,
        /// <summary>
        /// 票查询响应
        /// </summary>
        Response505 = 505,
        /// <summary>
        /// 返奖查询响应
        /// </summary>
        Response506 = 506,
        /// <summary>
        /// 销量查询响应
        /// </summary>
        Response507 = 507,
        /// <summary>
        /// 返奖通知请求响应
        /// </summary>
        Response508 = 508,
        /// <summary>
        /// 充值结果通知响应
        /// </summary>
        Response509 = 509,
        /// <summary>
        /// 充值查询请求响应
        /// </summary>
        Response510 = 510,
        /// <summary>
        /// 提款响应
        /// </summary>
        Response511 = 511,
        /// <summary>
        /// 提款结果通知响应
        /// </summary>
        Response512 = 512,
        /// <summary>
        /// 提款查询响应
        /// </summary>
        Response513 = 513,
        /// <summary>
        /// 赠送彩金请求响应
        /// </summary>
        Response514 = 514,
        /// <summary>
        /// 赠金查询请求响应
        /// </summary>
        Response515 = 515,
        /// <summary>
        /// 帐户查询请求响应
        /// </summary>
        Response516 = 516,
        /// <summary>
        /// 电话投注卡充值响应
        /// </summary>
        Response517 = 517,
        /// <summary>
        /// 帐户注册响应
        /// </summary>
        Response530 = 530,
        /// <summary>
        /// 帐户更新响应
        /// </summary>
        Response531 = 531,
        /// <summary>
        /// 风险控制查询响应
        /// </summary>
        Response534 = 534,
        /// <summary>
        /// 不支持的交易类型
        /// </summary>
        Error599 = 599,
    }

    /// <summary>
    /// 用户证件类型
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// 身份证
        /// </summary>
        IdCard = 1,
        /// <summary>
        /// 军官证
        /// </summary>
        ArmyIdentityCard = 2,
        /// <summary>
        /// 护照
        /// </summary>
        Passport = 3
    }

    /// <summary>
    /// 投注玩法类型
    /// </summary>
    public enum BuyType
    {
        /// <summary>
        /// 单式投注(101)
        /// </summary>
        A101 = 101,
        /// <summary>
        /// 复式投注(102)
        /// </summary>
        A102 = 102,
        /// <summary>
        /// 胆拖投注(103)
        /// </summary>
        A103 = 103,
        /// <summary>
        /// 直选投注(201)
        /// </summary>
        B201 = 201,
        /// <summary>
        /// 组选投注(202)
        /// </summary>
        B202 = 202,
        /// <summary>
        /// 直选和值(204)
        /// </summary>
        B204 = 204,
        /// <summary>
        /// 直选按位包号(208)
        /// </summary>
        B208 = 208,
        /// <summary>
        /// 组选按位包号(230)
        /// </summary>
        B230 = 230,
    }

    /// <summary>
    /// 投注票的状态
    /// </summary>
    public enum TicketStatus
    {
        /// <summary>
        /// 发请求中
        /// </summary>
        Requesting = 0,
        /// <summary>
        /// 确定落地
        /// </summary>
        Determinate = 1,
        /// <summary>
        /// 有错误发生的
        /// </summary>
        Error = 2,
    }
}
