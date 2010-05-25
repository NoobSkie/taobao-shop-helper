using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 充值元素
    /// </summary>
    public class Fill
    {
        string _id;
        /// <summary>
        /// ID生成规则为（agentID+8位时间戳YYYYMMDD+8位递增流水号）
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _userName;
        /// <summary>
        /// 彩民的用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        double _money;
        /// <summary>
        /// 充值金额
        /// </summary>
        public double Money
        {
            get { return _money; }
            set { _money = value; }
        }
        int _status;

        /// <summary>
        /// 充值响应状态
        /// 0  充值处理中
        /// 1  充值成功
        /// -1 充值失败
        /// 2  该笔充值交易不存在
        /// </summary>
        public string Status
        {
            get 
            {
                if(_status>=-1 && _status<=2)
                    return _status.ToString();
                throw new Exception("充值状态值异常。");
            }

            set 
            { 
                if(value=="-1" || value=="0" || value=="1" || value=="2")
                   _status = int.Parse(value);
                throw new Exception("充值状态值错误。");
            }
        }

        string _errMsg;
        /// <summary>
        /// 充值响应错误消息
        /// </summary>
        public string ErrMsg
        {
            get { return _errMsg; }
            set { _errMsg = value; }
        }

     

        double _cardFillMoney;
        /// <summary>
        /// 电话投注充值卡的面值
        /// </summary>
        public double CardFillMoney
        {
            get { return _cardFillMoney; }
            set { _cardFillMoney = value; }
        }
        string _cardNo;
        /// <summary>
        /// 电话投注充值卡卡号
        /// </summary>
        public string CardNo
        {
            get { return _cardNo; }
            set { _cardNo = value; }
        }

        string _password;
        /// <summary>
        /// 电话投注充值卡密码。必须进行MD5加密
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        string _cardFillSatus;
        /// <summary>
        /// 电话投注充值响应状态码
        /// 0000 成功,系统处理正常
        /// </summary>
        public string CardFillSatus
        {
            get { return _cardFillSatus; }
            set { _cardFillSatus = value; }
        }
    }
}
