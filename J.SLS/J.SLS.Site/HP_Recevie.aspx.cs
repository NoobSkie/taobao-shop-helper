using System;
using J.SLS.Facade;
using System.IO;
using System.Text;
using System.Collections.Generic;
using J.SLS.Common;
using J.SLS.Common.Xml;
using J.SLS.Common.Logs;

public partial class HP_Recevie : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string r;
        try
        {
            string body = GetRequestMessage();
            Dictionary<string, string> parameters = XmlAnalyzer.GetParameters(body);
            TranType type = (TranType)Enum.Parse(typeof(TranType), parameters["transType"]);
            IssueNoticeFacade facade = new IssueNoticeFacade();
            TranType returnType = TranType.Unkown;
            switch (type)
            {
                case TranType.IssueNotifyRequest:  // 奖期通知请求
                    facade.AddIssuseNotify(parameters["transMessage"]);
                    returnType = TranType.IssueNotifyResponse;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("不支持的通知类型 - " + type);
            }
            r = "<header><messengerID>600001</messengerID><timestamp>20071113092456</timestamp><transactionType>501</transactionType><digest>8123f913e123e123990028d9c72e0dfgds</digest></header>";
            r = "<body><response code=\"0000\" message=\"成功,系统处理正常\"/></body>";
        }
        catch (Exception ex)
        {
            LogWriter.Write(LogCategory.Notice, "处理通知失败", ex);
            r = "<body><response code=\"9999\" message=\"失败," + ex.Message + "\"/></body>";
        }

        byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(Server.UrlEncode(r));
        Response.OutputStream.Write(bytes, 0, bytes.Length);
        //string response;
        //try
        //{
        //    string body = GetRequestMessage();
        //    body = Server.UrlDecode(body);
        //    XmlNoticeFacade facade = new XmlNoticeFacade();
        //    XmlNoticeInfo notice = new XmlNoticeInfo();
        //    notice.RecevieTime = DateTime.Now;
        //    notice.XmlBody = body;
        //    facade.AddNotice(notice);

        //    response = "<body><response code=\"0000\" message=\"成功,系统处理正常\"/></body>";
        //}
        //catch (Exception ex)
        //{
        //    LogWriter.Write("Page", "HP_Recevie", J.SLS.Common.LogType.Warning, "接收通知失败", ex.ToString());
        //    response = "<body><response code=\"9999\" message=\"失败," + ex.Message + "\"/></body>";
        //}
        //byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(Server.UrlEncode(response));
        //Response.OutputStream.Write(bytes, 0, bytes.Length);
    }

    //private void HandleNotice(string response)
    //{
    //    string r;
    //    try
    //    {
    //        IssueNoticeFacade facade = new IssueNoticeFacade();
    //        Dictionary<string, string> parameters = XmlAnalyzer.GetParameters(response);
    //        TranType type = (TranType)Enum.Parse(typeof(TranType), parameters["transType"]);
    //        switch (type)
    //        {
    //            case TranType.IssueNotify:  // 奖期通知请求
    //                facade.AddIssuseNotify(parameters["transMessage"]);
    //                break;
    //            default:
    //                throw new ArgumentOutOfRangeException("不支持的通知类型 - " + type);
    //        }
    //        r = "<body><response code=\"0000\" message=\"成功,系统处理正常\"/></body>";
    //    }
    //    catch (Exception ex)
    //    {
    //        LogWriter.Write(LogCategory.Notice, "处理通知失败", ex);
    //        r = "<body><response code=\"9999\" message=\"失败," + ex.Message + "\"/></body>";
    //    }

    //    byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(Server.UrlEncode(r));
    //    Response.OutputStream.Write(bytes, 0, bytes.Length);
    //}

    private string GetRequestMessage()
    {
        using (StreamReader reader = new StreamReader(Request.InputStream))
        {
            return reader.ReadToEnd();
        }
    }
}
