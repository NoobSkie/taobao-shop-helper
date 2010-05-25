using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 投注方式
    /// </summary>
    public class PlayType
    {
        /// <summary>
        /// 投注方式编号
        /// </summary>
        public string ID;
        /// <summary>
        /// 投注方式名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 号码格式正则表达式字符串
        /// </summary>
        public string ValidationExpressionString;

        public PlayType(string id, string name,string expressionString)
        {
            this.ID = id;
            this.Name = name;
            this.ValidationExpressionString = expressionString;
        }
    }
}
