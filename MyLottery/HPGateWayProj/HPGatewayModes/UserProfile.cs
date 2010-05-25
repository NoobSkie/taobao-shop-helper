using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 购彩用户信息
    /// </summary>
    public class UserProfile
    {
        private string _userName;
        /// <summary>
        /// 彩民用户在代理商系统的登录名
        /// 最大长度20
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private CardType _cardTypeInfo;
        /// <summary>
        /// 用户证件类型
        /// </summary>
        public CardType CardTypeInfo
        {
            get { return _cardTypeInfo; }
            set { _cardTypeInfo = value; }
        }

        private string _cardNumber;
        /// <summary>
        /// 用户证件号码。用户的证件号码是必须填写的。
        /// 最大长度20
        /// </summary>
        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        private string _mobile;
        /// <summary>
        /// 用户手机号码。(无纸化彩票中大奖的凭证之一)
        /// 最大长度11
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }


        private string _mail;
        /// <summary>
        /// 用户的邮箱地址，格式为”邮箱名@域名”
        /// 最大长度20
        /// </summary>
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        private string _realName;
        /// <summary>
        /// 用户的真实姓名
        /// 最大长度10
        /// </summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        private string _bonusPhone;
        /// <summary>
        /// 用户的大奖通知电话
        /// 最大长度15
        /// </summary>
        public string BonusPhone
        {
            get { return _bonusPhone; }
            set { _bonusPhone = value; }
        }
    }
}
