using System;
using J.SLS.Facade;
using System.IO;
using System.Text;
using System.Collections.Generic;
using J.SLS.Common;
using J.SLS.Common.Xml;
using J.SLS.Common.Logs;
using HPGatewayModels;

public partial class HP_Recevie : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string r;
        string srcStr = GetRequestMessage();
        try
        {
            string requestString = Server.UrlDecode(srcStr);
            Dictionary<string, string> parameters = XmlAnalyzer.GetParameters(requestString);
            TranType type = (TranType)Enum.Parse(typeof(TranType), parameters["transType"]);
            IssueNoticeFacade facade = new IssueNoticeFacade();
            IssueNoticeInfo noticeInfo;
            switch (type)
            {
                case TranType.Request101:  // 奖期通知请求
                    noticeInfo = facade.AddIssuseNotify(parameters["transMessage"]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("不支持的通知类型 - " + type);
            }
            string accountUserName = GetAgenceAccountUserName();
            string accountPassword = GetAgenceAccountPassword();
            // 响应的交易类型，如请求奖期通知101，则响应为501.
            TranType returnType = (TranType)((int)type + 400);
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string body = "<body><response code=\"0000\" /></body>";
            string digest = PostManager.MD5(noticeInfo.Id + timestamp + accountPassword + body, "gb2312");

            StringBuilder sb = new StringBuilder();
            // <?xml version=\"1.0\" encoding=\"GBK\"?>
            sb.Append(noticeInfo.XmlHeader);
            // <message version=\"1.0\" id=\"6000012007111300000231\">
            sb.AppendFormat("<message version=\"{0}\" id=\"{1}\">", noticeInfo.Version, noticeInfo.Id);
            // <header><messengerID>{0}</messengerID><timestamp>20071113092456</timestamp><transactionType>501</transactionType><digest>8123f913e123e123990028d9c72e0dfgds</digest></header>
            sb.AppendFormat("<header><messengerID>{0}</messengerID><timestamp>{1}</timestamp><transactionType>{2}</transactionType><digest>{3}</digest></header>"
                , accountUserName
                , timestamp
                , (int)returnType
                , digest);
            sb.Append(body);
            sb.Append("</message>");

            r = sb.ToString();
        }
        catch (Exception ex)
        {
            Exception ext = new Exception("处理通知发生未知异常 - " + srcStr, ex);
            LogWriter.Write(LogCategory.Notice, "处理通知失败", ext);
            r = "<body><response code=\"9999\" message=\"失败," + ex.Message + "\"/></body>";
        }

        byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(Server.UrlEncode(r));
        Response.OutputStream.Write(bytes, 0, bytes.Length);
    }

    private string GetRequestMessage()
    {
        using (StreamReader reader = new StreamReader(Request.InputStream))
        {
            return reader.ReadToEnd();
        }
    }
}
