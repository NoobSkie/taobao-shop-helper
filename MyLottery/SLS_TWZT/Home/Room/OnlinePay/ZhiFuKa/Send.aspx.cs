using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Xml;

public partial class Home_Room_OnlinePay_ZhiFuKa_Send : RoomPageBase, IRequiresSessionState
{
    private string cardno = "";
    private string cardnum = "";
    private string cardpass = "";
    private string customerid = "";
    private string errcode = "0000";
    private string errmsg = "0000";
    private string faceno = "";
    private string key = "";
    private string mark = "";
    private string noticeurl = (Utility.GetUrl() + "/Home/Room/OnlinePay/ZhiFuKa/Receive.aspx");
    private double ordermoney;
    private string paygateurl = "http://202.75.218.94/gateway/zfgateway.asp";
    private string remarks = "3gcpw";
    private string sdcustomno = "";
    private SystemOptions so = new SystemOptions();
    private string state = "0000";

    public string GetHtml(string Url, string encodeing, int TimeoutSeconds)
    {
        HttpWebRequest request = null;
        HttpWebResponse response = null;
        StreamReader reader = null;
        try
        {
            request = (HttpWebRequest)WebRequest.Create(Url);
            request.UserAgent = "www.svnhost.cn";
            if (TimeoutSeconds > 0)
            {
                request.Timeout = 0x3e8 * TimeoutSeconds;
            }
            request.AllowAutoRedirect = false;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodeing));
                return reader.ReadToEnd();
            }
            return "";
        }
        catch (SystemException)
        {
            return "";
        }
    }

    private string GetMD5(string encypStr)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
        return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "").ToUpper();
    }

    private string GetPaySign()
    {
        string encypStr = "customerid=" + this.customerid + "&sdcustomno=" + this.sdcustomno + "&noticeurl=" + this.noticeurl + "&mark=" + this.mark + "&key=" + this.key;
        return this.GetMD5(encypStr);
    }

    private bool GetPayUrl(out string url)
    {
        try
        {
            string paySign = this.GetPaySign();
            url = string.Concat(new object[] { 
                this.paygateurl, "?customerid=", this.customerid, "&sdcustomno=", this.sdcustomno, "&ordermoney=", this.ordermoney, "&cardno=", this.cardno, "&faceno=", this.faceno, "&cardnum=", this.cardnum, "&cardpass=", this.cardpass, "&noticeurl=", 
                this.noticeurl, "&remarks=", this.remarks, "&mark=", this.mark, "&sign=", paySign
             });
            return true;
        }
        catch (Exception exception)
        {
            url = "创建URL时出错,错误信息:" + exception.Message;
            return false;
        }
    }

    private void GetResponseContents(string messageXml)
    {
        XmlDocument document = new XmlDocument();
        XmlNodeList elementsByTagName = null;
        try
        {
            document.Load(new StringReader(messageXml));
            elementsByTagName = document.GetElementsByTagName("item");
        }
        catch
        {
        }
        if ((elementsByTagName != null) && (elementsByTagName.Count > 0))
        {
            foreach (XmlNode node in elementsByTagName)
            {
                string str;
                if ((node.Attributes["name"] != null) && ((str = node.Attributes["name"].Value) != null))
                {
                    if (!(str == "state"))
                    {
                        if (str == "errcode")
                        {
                            goto Label_00F0;
                        }
                        if (str == "errmsg")
                        {
                            goto Label_0110;
                        }
                        if (str == "mark")
                        {
                            goto Label_0130;
                        }
                    }
                    else
                    {
                        this.state = node.Attributes["value"].Value;
                    }
                }
                continue;
            Label_00F0:
                this.errcode = node.Attributes["value"].Value;
                continue;
            Label_0110:
                this.errmsg = node.Attributes["value"].Value;
                continue;
            Label_0130:
                this.mark = node.Attributes["value"].Value;
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.so["OnlinePay_ZhiFuKa_Status_ON"].ToBoolean(false);
        this.ordermoney = _Convert.StrToDouble(Utility.GetRequest("ordermoney"), 0.0);
        this.cardno = Utility.GetRequest("cardno");
        this.faceno = Utility.GetRequest("faceno");
        this.cardnum = Utility.GetRequest("cardnum");
        this.cardpass = Utility.GetRequest("cardpass");
        string str = "";
        if (!base.IsPostBack)
        {
            this.customerid = this.so["OnlinePay_ZhiFuKa_UserNumber"].Value.ToString();
            this.key = this.so["OnlinePay_ZhiFuKa_MD5Key"].Value.ToString();
            this.mark = Encrypt.EncryptString(PF.GetCallCert(), base._User.ID.ToString() + "|" + Utility.GetRequest("BuyID"));
            long newPayNumber = -1L;
            string returnDescription = "";
            try
            {
                if (Procedures.P_GetNewPayNumber(base._Site.ID, base._User.ID, "51ZFK_" + this.cardno, this.ordermoney, 0.0, ref newPayNumber, ref returnDescription) < 0)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                }
                else if ((newPayNumber < 0L) || (returnDescription != ""))
                {
                    PF.GoError(1, returnDescription, base.GetType().BaseType.FullName);
                }
                else
                {
                    this.sdcustomno = newPayNumber.ToString();
                    if (((string.IsNullOrEmpty(this.cardno) || string.IsNullOrEmpty(this.remarks)) || (string.IsNullOrEmpty(this.customerid) || string.IsNullOrEmpty(this.sdcustomno))) || (((string.IsNullOrEmpty(this.mark) || string.IsNullOrEmpty(this.noticeurl)) || (string.IsNullOrEmpty(this.key) || string.IsNullOrEmpty(this.cardnum))) || (string.IsNullOrEmpty(this.cardpass) || string.IsNullOrEmpty(this.faceno))))
                    {
                        str = "参数不齐全，无法充值！";
                        base.Response.Write("<script type=\"text/javascript\"> window.top.location.href='" + Utility.GetUrl() + "/Home/Room/OnlinePay/Fail.aspx?errMsg=" + str + "';</script>");
                    }
                    else
                    {
                        string url = "";
                        if (!this.GetPayUrl(out url))
                        {
                            str = url;
                            base.Response.Write("<script type=\"text/javascript\"> window.top.location.href='" + Utility.GetUrl() + "/Home/Room/OnlinePay/Fail.aspx?errMsg=" + str + "';</script>");
                        }
                        else
                        {
                            this.GetResponseContents(this.GetHtml(url, "GB2312", 200));
                            if (this.state == "1")
                            {
                                new Log("OnlinePay").Write("在线支付：充值申请已经提交，等待结果通知！支付号：" + this.sdcustomno);
                                str = "在线支付：充值申请已经提交，等待结果通知！支付号：" + this.sdcustomno;
                                base.Response.Write("<script type=\"text/javascript\"> window.top.location.href='" + Utility.GetUrl() + "/Home/Room/OnlinePay/OK.aspx?errMsg=" + str + "';</script>");
                            }
                            else
                            {
                                new Log("OnlinePay").Write("在线支付：充值申请提交失败！描述：code=" + this.errcode + "； msg=" + this.errmsg + "； 支付号：" + this.sdcustomno);
                                str = "在线支付：充值申请提交失败！描述：code=" + this.errcode + "； msg=" + this.errmsg + "； 支付号：" + this.sdcustomno + "！";
                                base.Response.Write("<script type=\"text/javascript\"> window.top.location.href='" + Utility.GetUrl() + "/Home/Room/OnlinePay/Fail.aspx?errMsg=" + str + "';</script>");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                new Log("OnlinePay").Write(exception.Message);
                PF.GoError(1, returnDescription, base.GetType().BaseType.FullName);
            }
        }
    }
}

