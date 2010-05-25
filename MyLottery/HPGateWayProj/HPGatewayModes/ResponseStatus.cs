using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    public class ResponseStatus
    {
        string _statusCode;

        /// <summary>
        /// 状态码
        /// </summary>
        public string StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }
        string _description;

        /// <summary>
        /// 说明
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        LotteryType _lotteryType;
        /// <summary>
        /// 彩票种类
        /// <example>如：上海福彩，重庆福彩，江西福彩，山东体彩</example>
        /// </summary>
        public LotteryType LotteryType
        {
            get { return _lotteryType; }
            set { _lotteryType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <param name="description">说明</param>
        /// <param name="lotteryType">彩票种类。如：上海福彩，重庆福彩，江西福彩，山东体彩</param>
        public ResponseStatus(string statusCode,string description,LotteryType lotteryType)
        {
            this.StatusCode = statusCode;
            this.Description = description;
            this.LotteryType = lotteryType;
        }
    }
}
