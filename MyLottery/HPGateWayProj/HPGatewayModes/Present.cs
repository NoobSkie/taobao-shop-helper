using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    /// <summary>
    /// 赠送彩金元素
    /// </summary>
    public class Present
    {
        string _id;
        /// <summary>
        /// ID生成规则为(agentID+8位时间戳YYYYMMDD+8位递增流水号)
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
        string _realName;
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }
        string _idCard;
        /// <summary>
        /// 彩民的证件号码
        /// </summary>
        public string IdCard
        {
            get { return _idCard; }
            set { _idCard = value; }
        }
        CardType _cardTypeInfo;
        /// <summary>
        /// 彩民的证件类型
        /// </summary>
        public CardType CardTypeInfo
        {
            get { return _cardTypeInfo; }
            set { _cardTypeInfo = value; }
        }
        double _money;
        /// <summary>
        /// Money描述了投注代理商赠送彩金的金额
        /// </summary>
        public double Money
        {
            get { return _money; }
            set { _money = value; }
        }
        string _status;
        /// <summary>
        /// 赠送状态。0000表示赠送成功，其他失败
        /// </summary>
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
