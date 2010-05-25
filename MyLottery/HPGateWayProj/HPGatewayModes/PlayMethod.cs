using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 上海福彩,附录A 玩法参数说明
    /// </summary>
    public class PlayMethod
    {
        string _playName;

        /// <summary>
        /// 玩法名称
        /// </summary>
        public string PlayName
        {
            get { return _playName; }
            set { _playName = value; }
        }


        string _area;
        /// <summary>
        /// 销售区域
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }


        string _gameName;
        /// <summary>
        /// 玩法编号
        /// </summary>
        public string GameName
        {
            get { return _gameName; }
            set { _gameName = value; }
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


        List<PlayType> _PlayTypes=new List<PlayType>();
        /// <summary>
        /// 投注方式
        /// 如：单式、复式、胆拖
        /// </summary>
        public List<PlayType> PlayTypes
        {
            get { return _PlayTypes; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playName">玩法名称</param>
        /// <param name="area">区域</param>
        /// <param name="gameName">玩法编号</param>
        /// <param name="lotteryType">彩票种类,如：上海福彩，重庆福彩，江西福彩，山东体彩</param>
        public PlayMethod(string playName, string area, string gameName, LotteryType lotteryType)
        {
            this.PlayName = playName;
            this.Area = area;
            this.GameName = gameName;
            this.LotteryType = lotteryType;

            this.PlayTypes.Clear();
            PlayType pType = null;
            switch (gameName.ToLower())
            {
                case "ssq"://双色球(ssq)
                case "601"://华东六省联销6+1(601)
                    pType = new PlayType("101", "单式投注", "");
                    this.PlayTypes.Add(pType);
                    pType = new PlayType("102", "复式投注", "");
                    this.PlayTypes.Add(pType);
                    break;
                case "307"://七乐彩(307)
                case "155"://15选5(155)
                    pType = new PlayType("101", "单式投注", "");
                    this.PlayTypes.Add(pType);
                    pType = new PlayType("102", "复式投注", "");
                    this.PlayTypes.Add(pType);
                    pType = new PlayType("103", "胆拖投注", "");
                    this.PlayTypes.Add(pType);
                    break;
                case "3d"://3D(3d)
                    pType = new PlayType("201", "直选投注", "");
                    this.PlayTypes.Add(pType);
                    pType = new PlayType("202", "组选投注", "");
                    this.PlayTypes.Add(pType);
                    pType = new PlayType("204", "直选和值", "");
                    this.PlayTypes.Add(pType);
                    pType = new PlayType("208", "直选按位包号", "");
                    this.PlayTypes.Add(pType);
                    break;
                case "4d"://天天彩4（4d）
                case "ssl"://时时乐(ssl)
                    pType = new PlayType("201", "直选投注", "");
                    this.PlayTypes.Add(pType);
                    pType = new PlayType("202", "组选投注", "");
                    this.PlayTypes.Add(pType);
                    pType = new PlayType("208", "直选按位包号", "");
                    this.PlayTypes.Add(pType);
                    pType = new PlayType("230", "组选按位包号", "");
                    this.PlayTypes.Add(pType);
                    break;
            }
        }
    }
}
