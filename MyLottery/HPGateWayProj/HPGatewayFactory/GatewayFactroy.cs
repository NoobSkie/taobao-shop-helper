using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHPGateway;
using HPGatewayModels;
using HPGatewayRealization;

namespace HPGatewayFactory
{
    /// <summary>
    /// 投注、查询工厂
    /// </summary>
    public class GatewayFactroy
    {
        /// <summary>
        /// 投注/查询工厂
        /// </summary>
        /// <param name="lotterType"></param>
        /// <returns></returns>
        public static IHPGateway.IIssueQueryGateway CreateIssueQueryGatewayFactory(LotteryType lotterType)
        {
            try
            {
                if (lotterType == LotteryType.ShangHaiWelfareLottery)
                {
                    IssueQueryGateway gateway = new IssueQueryGateway();
                    return gateway;
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }

            return null;
        }

        /// <summary>
        /// 充值工厂
        /// </summary>
        /// <param name="lotterType"></param>
        /// <returns></returns>
        public static IHPGateway.IAddBalanceGateway CreateAddBalanceGatewayFactory(LotteryType lotterType)
        {
            try
            {
                if (lotterType == LotteryType.ShangHaiWelfareLottery)
                {
                    IAddBalanceGateway gateway = new AddBalanceGateway();
                    return gateway;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        /// <summary>
        /// 提款工厂
        /// </summary>
        /// <param name="lotterType"></param>
        /// <returns></returns>
        public static IHPGateway.IDrawingGateway CreateDrawingGatewayFactory(LotteryType lotterType)
        {
            try
            {
                if (lotterType == LotteryType.ShangHaiWelfareLottery)
                {
                    IDrawingGateway gateway = new DrawingGateway();
                    return gateway;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}
