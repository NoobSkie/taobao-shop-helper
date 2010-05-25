using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 恒朋，交易类型
    /// </summary>
    public class TransactionType
    {
        string _typeCode;
        /// <summary>
        /// 交易类型编号
        /// </summary>
        public string TypeCode
        {
            get { return _typeCode; }
            set { _typeCode = value; }
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
        /// 交易类型默认构造
        /// </summary>
        public TransactionType()
        { 
        
        }

        /// <summary>
        /// 交易类型带参构造
        /// </summary>
        /// <param name="typeCode">交易类型编号</param>
        /// <param name="desc">说明</param>
        public TransactionType(string typeCode, string desc,LotteryType lotteryType)
        {
            this.TypeCode = typeCode;
            this.Description = desc;
            this.LotteryType = lotteryType;
        }
    }
}
