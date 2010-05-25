using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 联合购买方案认购主体的明细信息
    /// </summary>
    public class UniteAnteBuy
    {
        string _userName;
        /// <summary>
        /// 彩民用户在代理商系统的登录名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        CardType _cardType;
        /// <summary>
        /// 证件类型
        /// </summary>
        public CardType CardType
        {
            get { return _cardType; }
            set { _cardType = value; }
        }
        string _cardNumber;
        /// <summary>
        /// 用户证件号码。用户的证件号码是必须填写的
        /// </summary>
        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }
        string _mobile;
        /// <summary>
        /// 用户手机号码。(无纸化彩票中大奖的凭证之一)
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        string _mail;
        /// <summary>
        /// 用户的邮箱地址，格式为”邮箱名@域名”。
        /// </summary>
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        string _realName;
        /// <summary>
        /// 用户的真实姓名。
        /// </summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }
        string _bonusPhone;
        /// <summary>
        /// 用户的大奖通知电话。
        /// </summary>
        public string BonusPhone
        {
            get { return _bonusPhone; }
            set { _bonusPhone = value; }
        }
        int _buyDeal;
        /// <summary>
        /// 购买的份数
        /// </summary>
        public int BuyDeal
        {
            get { return _buyDeal; }
            set { _buyDeal = value; }
        }
        double _buyMoney;
        /// <summary>
        /// 购买的金额
        /// </summary>
        public double BuyMoney
        {
            get { return _buyMoney; }
            set { _buyMoney = value; }
        }
    }
}
