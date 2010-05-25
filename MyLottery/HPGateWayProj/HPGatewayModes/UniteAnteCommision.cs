using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 联合购买方案佣金规则信息
    /// </summary>
    public class UniteAnteCommision
    {
        int _minMoney;
        /// <summary>
        /// 奖金下限。上限总是大于前一佣金规则的上限
        /// </summary>
        public int MinMoney
        {
            get { return _minMoney; }
            set { _minMoney = value; }
        }
        int _maxMoney;
        /// <summary>
        /// 奖金上限，不设上限为-1
        /// </summary>
        public int MaxMoney
        {
            get { return _maxMoney; }
            set { _maxMoney = value; }
        }
        int _rate;
        /// <summary>
        /// 佣金比例。1代表佣金为奖金总额的1%，最高不得超过300
        /// </summary>
        public int Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
    }
}
