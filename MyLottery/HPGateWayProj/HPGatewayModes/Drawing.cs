using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 提款元素
    /// </summary>
    public class Drawing
    {
        string _id;
        /// <summary>
        /// agentID+8位时间戳YYYYMMDD+8位递增流水号
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        UserProfile _user;
        /// <summary>
        /// 提款用户信息
        /// </summary>
        public UserProfile User
        {
            get { return _user; }
            set { _user = value; }
        }

        string _bankCard;
        /// <summary>
        /// 银行帐号，例如:5000 1013 5000 5020 202
        /// </summary>
        public string BankCard
        {
            get { return _bankCard; }
            set { _bankCard = value; }
        }

        string _bankName;
        /// <summary>
        /// 开户行信息,例如建设银行
        /// </summary>
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        string _province;
        /// <summary>
        /// 开户行所在省或直辖市
        /// </summary>
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        string _city;
        /// <summary>
        /// 开户行所在城市
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        string _branch;
        /// <summary>
        /// 分行或支行、分理处
        /// </summary>
        public string Branch
        {
            get { return _branch; }
            set { _branch = value; }
        }

        double _money;
        /// <summary>
        /// Money描述了投注代理商提款请求的金额
        /// </summary>
        public double Money
        {
            get { return _money; }
            set { _money = value; }
        }

        int _status;

        /// <summary>
        /// 提款响应状态
        /// 0  未处理提款单
        /// 1  已处理提款单
        /// -1 无法转到银行卡
        /// -2 已经退单
        /// 2  已转到银行卡
        /// 3  提款ID不存在
        /// </summary>
        public string Status
        {
            get
            {
                if (_status >= -2 && _status <= 3)
                    return _status.ToString();
                throw new Exception("提款状态值异常。");
            }

            set
            {
                if (value == "-2" || value == "-1" || value == "0" || value == "1" || value == "2" || value == "3")
                    _status = int.Parse(value);
                throw new Exception("提款状态值错误。");
            }
        }

        string _errMsg;
        /// <summary>
        /// 提款响应错误消息
        /// </summary>
        public string ErrMsg
        {
            get { return _errMsg; }
            set { _errMsg = value; }
        }
    }
}
