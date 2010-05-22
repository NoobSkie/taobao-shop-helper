using ASP;
using Shove._Web;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web;

public partial class Home_Room_OnlinePay_Tenpay_PayQuery : RoomPageBase, IRequiresSessionState
{
    private string attach = UrlEncode(HttpUtility.UrlEncode("充值查询", Encoding.GetEncoding("GBK")));
    private string bargainor_id = "";
    private const int cmdno = 2;
    private string date = "";
    private string key = "";
    private string querygateurl = "http://mch.tenpay.com/cgi-bin/cfbi_query_order.cgi";
    private string queryreturn_url = (Utility.GetUrl() + "/Home/Room/OnlinePay/Tenpay/QueryResult.aspx");
    private SystemOptions so = new SystemOptions();
    private string sp_billno = "";
    private string transaction_id = "";

    private string CreatePayNumber(string Number)
    {
        string str = Number.PadLeft(10, '0');
        str = str.Substring(str.Length - 10);
        return (this.bargainor_id + this.date + str);
    }

    private string GetMD5(string encypStr)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
        return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "").ToUpper();
    }

    private string GetQuerySign()
    {
        string encypStr = string.Concat(new object[] { "cmdno=", 2, "&date=", this.date, "&bargainor_id=", this.bargainor_id, "&transaction_id=", this.transaction_id, "&sp_billno=", this.sp_billno, "&return_url=", this.queryreturn_url, "&attach=", UrlDecode(this.attach), "&key=", this.key });
        return this.GetMD5(encypStr);
    }

    private bool GetQueryUrl(out string url)
    {
        try
        {
            string querySign = this.GetQuerySign();
            url = string.Concat(new object[] { 
                this.querygateurl, "?cmdno=", 2, "&date=", this.date, "&bargainor_id=", this.bargainor_id, "&transaction_id=", this.transaction_id, "&sp_billno=", this.sp_billno, "&return_url=", this.queryreturn_url, "&attach=", this.attach, "&sign=", 
                querySign
             });
            return true;
        }
        catch (Exception exception)
        {
            url = "创建URL时出错,错误信息:" + exception.Message;
            return false;
        }
    }

    private bool GetSus_Msg(string url, out string sus_Msg)
    {
        sus_Msg = url;
        if (url.IndexOf("QueryResult.aspx") < 0)
        {
            string[] strArray = url.Split(new char[] { '&' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].IndexOf("suc_msg=") >= 0)
                {
                    sus_Msg = strArray[i].Substring(8);
                    return true;
                }
            }
        }
        return false;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = false;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.bargainor_id = this.so["OnlinePay_Tenpay_UserNumber"].Value.ToString();
        this.key = this.so["OnlinePay_Tenpay_MD5Key"].Value.ToString();
        this.date = Utility.GetRequest("date");
        this.sp_billno = Utility.GetRequest("sp_billno");
        if ((string.IsNullOrEmpty(this.date) || string.IsNullOrEmpty(this.sp_billno)) || (string.IsNullOrEmpty(this.bargainor_id) || string.IsNullOrEmpty(this.key)))
        {
            base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sp_billno + " 的支付记录没有充值成功，描述：参数不齐全，无法提交查询！\"); window.location.href='';</script>");
        }
        else
        {
            this.transaction_id = this.CreatePayNumber(this.sp_billno);
            string url = "";
            if (!this.GetQueryUrl(out url))
            {
                base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sp_billno + " 的支付记录没有充值成功，描述：" + url + "！\");window.location.href='';</script>");
            }
            else
            {
                string str2 = "";
                if (this.GetSus_Msg(PF.GetHtml(url, "GBK", 120), out str2))
                {
                    base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sp_billno + " 的支付记录没有充值成功，描述：" + str2 + "！\"); window.location.href='';</script>");
                }
                else
                {
                    base.Response.Write(str2);
                }
            }
        }
    }

    private static string UrlDecode(string instr)
    {
        if ((instr != null) && !(instr.Trim() == ""))
        {
            return instr.Replace("%3d", "=").Replace("%26", "&").Replace("%22", "\"").Replace("%3f", "?").Replace("%27", "'").Replace("%20", " ").Replace("%25", "%");
        }
        return "";
    }

    private static string UrlEncode(string instr)
    {
        if ((instr != null) && !(instr.Trim() == ""))
        {
            return instr.Replace("%", "%25").Replace("=", "%3d").Replace("&", "%26").Replace("\"", "%22").Replace("?", "%3f").Replace("'", "%27").Replace(" ", "%20");
        }
        return "";
    }
}

