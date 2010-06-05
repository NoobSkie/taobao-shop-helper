using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

public partial class HP_TestRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string str = "transType=101&transMessage=<?xml version=\"1.0\" encoding=\"GBK\"?> <message version=\"1.0\" id=\"2000212010060418663512\"><header><messengerID>200021</messengerID><timestamp>20100604142338</timestamp><transactionType>101</transactionType><digest>2a18c23517606f318f8838ad593ca71a</digest></header><body><issueNotify><issue gameName=\"ssq\" number=\"2010193\" startTime=\"2010-06-04 13:48:00\" stopTime=\"2010-06-05 13:48:00\" status=\"3\" bonusCode=\"\" salesMoney=\"-1.0\" bonusMoney=\"-1.0\"/></issueNotify></body></message>";
        //str = Server.UrlDecode(str);
        //lblMessage.Text = str;

        string body = "transType=101&transMessage=<?xml version=\"1.0\" encoding=\"GBK\"?> <message version=\"1.0\" id=\"2000212010060518672983\"><header><messengerID>200021</messengerID><timestamp>20100605152812</timestamp><transactionType>101</transactionType><digest>5a2791e03d5fa9d9ae80c80c8a4444b9</digest></header><body><issueNotify><issue gameName=\"ssl\" number=\"2010060511\" startTime=\"2010-06-05 14:58:00\" stopTime=\"2010-06-05 15:28:00\" status=\"3\" bonusCode=\"\" salesMoney=\"-1.0\" bonusMoney=\"-1.0\"/></issueNotify></body></message>";
        body = Server.UrlEncode(body);
        string r = Post("http://localhost:47599/J.SLS.Site/HP_Recevie.aspx", body, 5000);
        // string r = Post("http://222.186.12.129:8099/HP_Recevie.aspx", body, 5000);
        lblMessage.Text = "<span>OK<span><br />" + Server.UrlDecode(r);
    }

    public string Post(string Url, string RequestString, int TimeoutSeconds)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        if (TimeoutSeconds > 0)
        {
            request.Timeout = 0x3e8 * TimeoutSeconds;
        }
        request.Method = "POST";
        request.AllowAutoRedirect = true;
        request.ContentType = "application/x-www-form-urlencoded";
        byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(RequestString);
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
        return reader.ReadToEnd();
    }
}
