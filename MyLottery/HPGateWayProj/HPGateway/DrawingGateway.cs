using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHPGateway;
using HPGatewayModels;

namespace HPGatewayRealization
{
    /// <summary>
    /// 提款
    /// </summary>
    public class DrawingGateway:IDrawingGateway
    {
        #region IDrawingGateway 成员
        /// <summary>
        /// 提款的网关地址
        /// </summary>
        public string GatewayUrl
        {
            get { return GateWayManager.HPDistill_GateWay; }
        }

        /// <summary>
        /// 提款
        /// transType=111
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：111</param>
        /// <param name="drawing"></param>
        /// <returns></returns>
        public string DrawingRequest(AccountNumber accountNo, TransactionType transType, Drawing drawing)
        {
            if (transType.TypeCode.Trim() != "111")
            {
                throw new Exception("提款请求对应的交易类型错误。");
            }

            if (drawing != null && drawing.User != null)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    string body = "<body><drawingRequest><drawing ";
                    body += "id=\"" + drawing.Id + "\" ";
                    body += "userName=\"" + drawing.User.UserName + "\" ";
                    body += "realName=\"" + drawing.User.RealName + "\" ";
                    body += "cardType=\"" + (int)drawing.User.CardTypeInfo + "\" ";
                    body += "idCard=\"" + drawing.User.CardNumber + "\" ";
                    body += "bankCard=\"" + drawing.BankCard + "\" ";
                    body += "bankName=\"" + drawing.BankName + "\" ";
                    body += "province=\"" + drawing.Province + "\" ";
                    body += "city=\"" + drawing.City + "\" ";
                    body += "branch=\"" + drawing.Branch + "\" ";
                    body += "money=\"" + drawing.Money + "\" ";
                    body += "/></drawingRequest></body>";
                    string messageId = accountNo.UserName + now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
                    string requestMessage = "transType=" + transType.TypeCode + "&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>");

                    Console.WriteLine("提款请求消息：\n" + requestMessage);

                    string responseMessage = PostManager.Post(GatewayUrl, requestMessage, 120);
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("提款信息为空或者提款信息部完整。");
        }

        /// <summary>
        /// 提款查询
        /// transType=113
        /// </summary>
        /// <param name="accountNo">代理商账号</param>
        /// <param name="transType">交易类型编号，如：113</param>
        /// <param name="drawings"></param>
        /// <returns></returns>
        public string DrawingQuery(AccountNumber accountNo, TransactionType transType, List<Drawing> drawings)
        {
            if (transType.TypeCode.Trim() != "113")
            {
                throw new Exception("提款查询请求对应的交易类型错误。");
            }

            if (drawings.Count >= 1 && drawings.Count <= 20)
            {
                try
                {
                    int timeoutSeconds = 120;
                    string body = "<body><drawingQuery>";

                    foreach (Drawing drawing in drawings)
                    {
                        body += "<drawing id=\"" + drawing.Id + "\"/>";
                    }

                    body +=  "</drawingQuery></body>";
                    string messageId = accountNo.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
                    string timestamp = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
                    string requestMessage = "<?xml version=\"1.0\" encoding=\"GBK\"?>";
                    requestMessage = (((((((requestMessage + "<message version=\"1.0\" id=\"" + messageId + "\">") + "<header>") + "<messengerID>" + accountNo.UserName + "</messengerID>") + "<timestamp>" + timestamp + "</timestamp>") + "<transactionType>" + transType.TypeCode + "</transactionType>") + "<digest>" + PostManager.MD5(messageId + timestamp + accountNo.UserPassword + body, "gb2312") + "</digest>") + "</header>") + body + "</message>";

                    Console.WriteLine("提款查询请求的消息：\n" + "transType=" + transType.TypeCode + "&transMessage=" + requestMessage);

                    string responseMessage = PostManager.Post(GatewayUrl, "transType=" + transType.TypeCode + "&transMessage=" + requestMessage, timeoutSeconds);
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("提款查询的个数超过了单次能查询的数目（必须为1~20）。");
        }
        #endregion
    }
}
