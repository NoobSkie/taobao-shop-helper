using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 恒朋，交易类型集合
    /// </summary>
    public class TransactionTypeManager
    {
        public List<TransactionType> TransTypes = new List<TransactionType>();

        public TransactionTypeManager(LotteryType lotteryType)
        {
            this.TransTypes.Clear();
            this.CreateTransactionTypes(lotteryType);
        }

        /// <summary>
        /// 根据彩票种类创建该类彩票的交易类型集合
        /// </summary>
        /// <param name="lotteryType">彩票种类(如：上海福彩，重庆福彩，江西福彩，山东体彩)</param>
        private void CreateTransactionTypes(LotteryType lotteryType)
        {
            if (lotteryType == LotteryType.ShangHaiWelfareLottery)
            {
                TransactionType transT = new TransactionType("101", "奖期通知请求",lotteryType);
                this.TransTypes.Add(transT);

                #region 请求的交易类型
                transT = new TransactionType("102", "奖期查询请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("103", "投注请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("104", "投注结果通知请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("105", "票查询请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("106", "返奖查询请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("107", "销量查询请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("108", "返奖通知请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("109", "充值结果通知", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("110", "充值查询请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("111", "提款请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("112", "提款结果通知", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("113", "提款查询请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("114", "赠送彩金请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("115", "赠金查询请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("116", "帐户查询请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("117", "电话投注卡充值请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("130", "帐户注册请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("131", "帐户更新请求", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("134", "风险控制查询请求", lotteryType);
                this.TransTypes.Add(transT);
                #endregion

                transT = new TransactionType("599", "不支持的交易类型", lotteryType);
                this.TransTypes.Add(transT);

                #region 响应的交易类型
                transT = new TransactionType("501", "奖期通知响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("502", "奖期查询响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("503", "投注响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("504", "投注结果通知响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("505", "票查询响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("506", "返奖查询响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("507", "销量查询响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("508", "返奖通知请求响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("509", "充值结果通知响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("510", "充值查询请求响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("511", "提款响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("512", "提款结果通知响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("513", "提款查询响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("514", "赠送彩金请求响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("515", "赠金查询请求响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("516", "帐户查询请求响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("517", "电话投注卡充值响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("530", "帐户注册响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("531", "帐户更新响应", lotteryType);
                this.TransTypes.Add(transT);

                transT = new TransactionType("534", "风险控制查询响应", lotteryType);
                this.TransTypes.Add(transT);
                #endregion
            }
        }

        /// <summary>
        /// 根据彩票类型和交易类型编号得到交易类型对象
        /// </summary>
        /// <param name="lotterType">彩票种类(如：上海福彩，重庆福彩，江西福彩，山东体彩)</param>
        /// <param name="typeCode">交易类型编号</param>
        /// <returns>交易类型</returns>
        public TransactionType GetTransactionTypeByTypeCode(LotteryType lotterType, string typeCode)
        {
            foreach (TransactionType transType in this.TransTypes)
            {
                if (transType.LotteryType == lotterType && transType.TypeCode == typeCode)
                    return transType;
            }

            return null;
        }

        /// <summary>
        /// 根据彩票类型和交易类型描述得到交易类型对象
        /// </summary>
        /// <param name="lotterType">彩票种类(如：上海福彩，重庆福彩，江西福彩，山东体彩)</param>
        /// <param name="typeCode">交易类型描述</param>
        /// <returns>交易类型</returns>
        public TransactionType GetTransactionTypeByDesc(LotteryType lotterType, string desc)
        {
            foreach (TransactionType transType in this.TransTypes)
            {
                if (transType.LotteryType == lotterType && transType.Description == desc)
                    return transType;
            }

            return null;
        }
    }
}
 