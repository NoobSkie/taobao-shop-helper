using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using J.SLS.Common.Xml;
using J.SLS.Facade;
using System.Xml;

public partial class HP_TestRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Guid.NewGuid().ToString("N"));
        //string str = "transType=101&transMessage=<?xml version=\"1.0\" encoding=\"GBK\"?> <message version=\"1.0\" id=\"2000212010060418663512\"><header><messengerID>200021</messengerID><timestamp>20100604142338</timestamp><transactionType>101</transactionType><digest>2a18c23517606f318f8838ad593ca71a</digest></header><body><issueNotify><issue gameName=\"ssq\" number=\"2010193\" startTime=\"2010-06-04 13:48:00\" stopTime=\"2010-06-05 13:48:00\" status=\"3\" bonusCode=\"\" salesMoney=\"-1.0\" bonusMoney=\"-1.0\"/></issueNotify></body></message>";
        //str = Server.UrlDecode(str);
        //lblMessage.Text = str;

        //string body = "%3C%3Fxml+version%3D%221.0%22+encoding%3D%22GBK%22%3F%3E%0A%3Cmessage+version%3D%221.0%22+id%3D%222000212010060418672717%22%3E%3Cheader%3E%3CmessengerID%3E200021%3C%2FmessengerID%3E%3Ctimestamp%3E20100604205812%3C%2Ftimestamp%3E%3CtransactionType%3E101%3C%2FtransactionType%3E%3Cdigest%3E93cc489a4093dc54f1777d5106cfe87a%3C%2Fdigest%3E%3C%2Fheader%3E%3Cbody%3E%3CissueNotify%3E%3Cissue+gameName%3D%22ssl%22+number%3D%222010060422%22+startTime%3D%222010-06-04+20%3A28%3A00%22+stopTime%3D%222010-06-04+20%3A58%3A00%22+status%3D%223%22+bonusCode%3D%22%22+salesMoney%3D%22-1.0%22+bonusMoney%3D%22-1.0%22%2F%3E%3C%2FissueNotify%3E%3C%2Fbody%3E%3C%2Fmessage%3E";
        //// string body = "transType=101&transMessage=<?xml version=\"1.0\" encoding=\"GBK\"?> <message version=\"1.0\" id=\"2000212010060518672983\"><header><messengerID>200021</messengerID><timestamp>20100605152812</timestamp><transactionType>101</transactionType><digest>5a2791e03d5fa9d9ae80c80c8a4444b9</digest></header><body><issueNotify><issue gameName=\"ssl\" number=\"2010060511\" startTime=\"2010-06-05 14:58:00\" stopTime=\"2010-06-05 15:28:00\" status=\"3\" bonusCode=\"\" salesMoney=\"-1.0\" bonusMoney=\"-1.0\"/></issueNotify></body></message>";
        //body = Server.UrlDecode(body);
        //Response.Write(body);
        //string r = Post("http://localhost:47599/J.SLS.Site/HP_Recevie.aspx", body, 5000);
        //// string r = Post("http://222.186.12.129:8099/HP_Recevie.aspx", body, 5000);
        //lblMessage.Text = "<span>OK<span><br />" + Server.UrlDecode(r);
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
