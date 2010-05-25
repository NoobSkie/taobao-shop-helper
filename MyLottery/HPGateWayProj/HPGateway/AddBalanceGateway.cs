using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHPGateway;
using HPGatewayModels;
using System.Net;
using System.IO;


namespace HPGatewayRealization
{
    public class AddBalanceGateway:IAddBalanceGateway
    {
        #region IAddBalanceGateway 成员
        /// <summary>
        /// 充值网关
        /// </summary>
        public string GatewayUrl
        {
            get { return GateWayManager.HPAddBalance_GateWay; }
        }

        /// <summary>
        /// 向恒朋提交充值请求
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="alipayProviderType">支付提供商类型</param>
        /// <param name="userProfile">要充值的用户</param>
        /// <param name="money">充值金额</param>
        /// <param name="pageReturnUrl">恒朋系统会向代理商系统提供的充值请求的pageReturnUrl地址发送支付结果信息</param>
        public void PostAddBalance(AccountNumber accountNo, AlipayProviderType alipayProviderType, UserProfile userProfile, string money, string pageReturnUrl)
        {
            DateTime now = DateTime.Now;
           
            string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
            //MD5,摘要的内容为代理商编号(agentID)+代理商密码(agentPasswd)＋代理商充值流水号(id)＋登录名(userName)＋充值金额(money)
            string digest = PostManager.MD5(accountNo.UserName + accountNo.UserPassword + messageId + userProfile.UserName + money, "gb2312");

            string paras = "agentID=" +  accountNo.UserName + 
                "&id=" + messageId + 
                "&providerID=" + alipayProviderType.Number +
                "&userName=" + userProfile.UserName + 
                "&realName=" + userProfile.RealName + 
                "&idCard=" + userProfile.CardNumber + 
                "&cardType=" + (int)userProfile.CardTypeInfo + 
                "&money=" + money + 
                "&digest=" + digest + 
                "&pageReturnUrl=" + pageReturnUrl;

            Console.WriteLine("充值请求消息：" + this.GatewayUrl + "?" + paras);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.GatewayUrl);
            request.Timeout = 0x3e8 * 120;

            request.Method = "POST";
            request.AllowAutoRedirect = true;
           
            byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(paras);
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
        }

        /// <summary>
        /// 充值查询
        /// 查询某笔（单次最多20笔）充值交易的明细情况
        /// transType=110
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：110</param>
        /// <param name="filles">要查询的充值集合</param>
        /// <returns></returns>
        public string FillQuery(AccountNumber accountNo,TransactionType transType,List<Fill> filles)
        {
            if (transType.TypeCode.Trim() != "110")
                throw new Exception("交易类型和充值查询的交易类型不匹配。");

            if (filles.Count >= 1 && filles.Count <= 20)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string body = "<body><fillQuery>";

                    foreach (Fill fill in filles)
                        body = body + "<fill id=\"" + fill.Id + "\" />";

                    body = body + "</fillQuery></body>";
                    string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                    string requestMessage = "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");
                    Console.WriteLine("充值查询传递的消息：\n" + requestMessage);

                    string responseMessage = PostManager.Post(GatewayUrl, requestMessage, 120);
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("充值查询的个数超过了单次能查询的数目（必须为1~20）。");
        }

        /// <summary>
        /// 电话投注卡充值
        /// transType="117"
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型</param>
        /// <param name="userProfile">要充值的用户账户</param>
        /// <param name="cardFill">充值数据对象</param>
        /// <returns></returns>
        public string AnteCardFill(AccountNumber accountNo, TransactionType transType,UserProfile userProfile,Fill cardFill)
        {
            if (transType.TypeCode.Trim() != "117")
                throw new Exception("交易类型和电话投注卡充值的交易类型不匹配。");

            if (userProfile!=null && cardFill!=null && userProfile.UserName==cardFill.UserName)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string body = "<body><anteCardFill>";

                    body = body + "<fill agentID=\"" + accountNo.UserName + "\" ";
                    string id = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    body = "id=\"" + id + "\" ";
                    body = "userName=\"" + userProfile.UserName + "\" ";
                    body = "realName=\"" + userProfile.RealName + "\" ";
                    body = "idCard=\"" + userProfile.CardNumber + "\" ";
                    body = "cardType=\"" + (int)userProfile.CardTypeInfo + "\" ";
                    body = "money=\"" + cardFill.CardFillMoney + "\" ";
                    body = "cardNo=\"" + cardFill.CardNo + "\" ";
                    body = "password=\"" + PostManager.MD5(cardFill.Password,"gb2312") + "\" />";

                    body = body + "</anteCardFill></body>";
                    string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                    string requestMessage = "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");
                    string responseMessage = PostManager.Post(GatewayUrl, requestMessage, 120);
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("电话投注卡充值对象或者用户账号信息不能为空。");
        }


        #endregion
    }
}
