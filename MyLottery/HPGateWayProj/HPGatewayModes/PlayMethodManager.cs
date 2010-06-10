using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 玩法集合
    /// </summary>
    public class PlayMethodManager
    {
        public List<PlayMethod> MethodTypes = new List<PlayMethod>();

        /// <summary>
        /// 根据彩票种类(如：上海福彩，重庆福彩，江西福彩，山东体彩)，得到该类彩票玩法
        /// </summary>
        /// <param name="lotteryType">彩票种类</param>
        public PlayMethodManager(LotteryType lotteryType)
        {
            this.MethodTypes.Clear();
            this.CreatePlayMethods(lotteryType);
        }


        /// <summary>
        /// 根据彩票种类(如：上海福彩，重庆福彩，江西福彩，山东体彩)，创建彩票玩法
        /// </summary>
        /// <param name="lotteryType">彩票种类</param>
        private void CreatePlayMethods(LotteryType lotteryType)
        {
            this.MethodTypes.Clear();
            if (lotteryType == LotteryType.ShangHaiWelfareLottery)
            {
                PlayMethod type = new PlayMethod("15选5", "华东六省联销", "155", lotteryType);
                MethodTypes.Add(type);

                type = new PlayMethod("3D", "全国", "3d", lotteryType);//需要
                MethodTypes.Add(type);

                type = new PlayMethod("双色球", "全国", "ssq", lotteryType);//需要
                MethodTypes.Add(type);

                type = new PlayMethod("七乐彩", "全国", "307", lotteryType);
                MethodTypes.Add(type);

                type = new PlayMethod("6+1", "华东六省联销", "601", lotteryType);
                MethodTypes.Add(type);

                type = new PlayMethod("天天彩4", "上海", "4d", lotteryType);
                MethodTypes.Add(type);

                type = new PlayMethod("时时乐", "上海", "ssl", lotteryType);//需要
                MethodTypes.Add(type);
            }
        }


        /// <summary>
        /// 根据彩票种类和玩法名称得到玩法对象
        /// </summary>
        /// <param name="lotteryType">彩票种类(如：上海福彩，重庆福彩，江西福彩，山东体彩)，得到该类彩票玩法</param>
        /// <param name="playName">玩法名称</param>
        /// <returns>玩法对象</returns>
        public PlayMethod GetMethodType(LotteryType lotteryType, string playName)
        {
            playName = playName.ToUpper();
            foreach (PlayMethod methodType in this.MethodTypes)
            {
                if (methodType.LotteryType == lotteryType && (methodType.PlayName == playName || methodType.GameName.Equals(playName, StringComparison.OrdinalIgnoreCase)))
                    return methodType;
            }

            return null;
        }
    }
}
