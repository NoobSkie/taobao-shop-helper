using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 账户查询元素
    /// </summary>
    public class AccountQuery
    {
        string _userName;
        /// <summary>
        /// 彩民的用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        string _realName;
        /// <summary>
        /// 彩民真实姓名
        /// </summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }
        double _baseMoney;
        /// <summary>
        /// 本金,即彩民通过网银充值的金额
        /// </summary>
        public double BaseMoney
        {
            get { return _baseMoney; }
            set { _baseMoney = value; }
        }
        double _bonusMoney;
        /// <summary>
        /// 奖金,即彩民中奖的金额
        /// </summary>
        public double BonusMoney
        {
            get { return _bonusMoney; }
            set { _bonusMoney = value; }
        }
        double _presentMoney;
        /// <summary>
        /// 赠金
        /// </summary>
        public double PresentMoney
        {
            get { return _presentMoney; }
            set { _presentMoney = value; }
        }
        double _freezeMoney;
        /// <summary>
        /// 冻结的金额
        /// </summary>
        public double FreezeMoney
        {
            get { return _freezeMoney; }
            set { _freezeMoney = value; }
        }
        string _status;
        /// <summary>
        /// 0000代表查询成功，其他请查看响应状态码说明
        /// </summary>
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
