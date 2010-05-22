using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Xml;

public partial class Home_Room_OnlinePay_ZhiFuKa_PayQuery : RoomPageBase, IRequiresSessionState
{
    private string customerid = "";
    private string key = "";
    private string mark = "";
    private double ordermoney = -1.0;
    private string querygateurl = "http://202.75.218.94/gateway/orderquery.asp";
    private string sd51no = "";
    private string sdcustomno = "";
    private SystemOptions so = new SystemOptions();
    private string state = "0000";

    private string getBankName(string bankCode)
    {
        string str = "神州行充值卡";
        string str2 = bankCode.ToLower();
        if (str2 == null)
        {
            return str;
        }
        if (!(str2 == "szx"))
        {
            if (str2 != "zfk")
            {
                return str;
            }
        }
        else
        {
            return "神州行充值卡";
        }
        return "51支付卡";
    }

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
        string encypStr = "customerid=" + this.customerid + "&sdcustomno=" + this.sdcustomno + "&mark=" + this.mark + "&key=" + this.key;
        return this.GetMD5(encypStr);
    }

    private bool GetQueryUrl(out string url)
    {
        try
        {
            string paySign = this.GetPaySign();
            url = this.querygateurl + "?customerid=" + this.customerid + "&sdcustomno=" + this.sdcustomno + "&mark=" + this.mark + "&sign=" + paySign;
            return true;
        }
        catch (Exception exception)
        {
            url = "创建URL时出错,错误信息:" + exception.Message;
            return false;
        }
    }

    private bool GetResponseContents(string messageXml, out string sus_Msg)
    {
        bool flag = false;
        sus_Msg = "";
        if (string.IsNullOrEmpty(messageXml))
        {
            flag = true;
            sus_Msg = "不存在的充值记录！";
            return flag;
        }
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
                        if (str == "sd51no")
                        {
                            goto Label_0113;
                        }
                        if (str == "ordermoney")
                        {
                            goto Label_0134;
                        }
                        if (str == "mark")
                        {
                            goto Label_0163;
                        }
                    }
                    else
                    {
                        this.state = node.Attributes["value"].Value;
                    }
                }
                continue;
            Label_0113:
                this.sd51no = node.Attributes["value"].Value;
                continue;
            Label_0134:
                this.ordermoney = _Convert.StrToDouble(node.Attributes["value"].Value, -1.0);
                continue;
            Label_0163:
                this.mark = node.Attributes["value"].Value;
            }
        }
        else
        {
            flag = true;
            sus_Msg = "不存在的充值记录！";
            return flag;
        }
        if (this.state == "0")
        {
            flag = true;
            sus_Msg = "正在处理中……！";
            return flag;
        }
        if (this.state == "2")
        {
            flag = true;
            sus_Msg = "充值失败！";
            return flag;
        }
        return flag;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = false;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.customerid = this.so["OnlinePay_ZhiFuKa_UserNumber"].Value.ToString();
        this.key = this.so["OnlinePay_ZhiFuKa_MD5Key"].Value.ToString();
        this.sdcustomno = Utility.GetRequest("sdcustomno");
        if ((string.IsNullOrEmpty(this.sdcustomno) || string.IsNullOrEmpty(this.customerid)) || string.IsNullOrEmpty(this.key))
        {
            base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sdcustomno + " 的支付记录没有充值成功，描述：参数不齐全，无法提交查询！\"); window.location.href='';</script>");
        }
        else
        {
            string url = "";
            if (!this.GetQueryUrl(out url))
            {
                base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sdcustomno + " 的支付记录没有充值成功，描述：" + url + "！\");window.location.href='';</script>");
            }
            else
            {
                string str2 = "";
                if (this.GetResponseContents(this.GetHtml(url, "GB2312", 200), out str2))
                {
                    base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sdcustomno + " 的支付记录没有充值成功，描述：" + str2 + "！\"); window.location.href='';</script>");
                }
                else
                {
                    try
                    {
                        string memo = "系统交易号：" + this.sdcustomno + ",51支付交易号：" + this.sd51no;
                        int returnValue = -1;
                        string returnDescription = "";
                        DataTable table = new Tables.T_UserPayDetails().Open("", "ID=" + this.sdcustomno, "");
                        if ((table == null) || (table.Rows.Count <= 0))
                        {
                            JavaScript.Alert(this.Page, "支付号为 " + this.sdcustomno + " 的支付记录没有充值成功，描述：充值处理失败，本条数据丢失。");
                        }
                        else
                        {
                            double money = (this.ordermoney == -1.0) ? this.ordermoney : _Convert.StrToDouble(table.Rows[0]["Money"].ToString(), 0.0);
                            long userID = _Convert.StrToLong(table.Rows[0]["UserID"].ToString(), 0L);
                            double formalitiesFees = _Convert.StrToDouble(table.Rows[0]["FormalitiesFees"].ToString(), 0.0);
                            string[] strArray3 = table.Rows[0]["PayType"].ToString().Split(new char[] { '_' });
                            string bankCode = (strArray3.Length < 2) ? "" : strArray3[1];
                            if (Procedures.P_UserAddMoney(base._Site.ID, userID, money, formalitiesFees, this.sdcustomno, this.getBankName(bankCode), memo, ref returnValue, ref returnDescription) < 0)
                            {
                                JavaScript.Alert(this.Page, "支付号为 " + this.sdcustomno + " 的支付记录没有充值成功，描述：数据库读写错误");
                            }
                            else if (returnValue < 0)
                            {
                                JavaScript.Alert(this.Page, returnDescription);
                            }
                            else
                            {
                                JavaScript.Alert(this.Page, "此笔充值记录已到帐并已处理成功！");
                            }
                        }
                    }
                    catch
                    {
                        JavaScript.Alert(this.Page, "支付号为 " + this.sdcustomno + " 的支付记录没有充值成功，描述：查询失败，可能是网络通讯故障。请重试一次。");
                    }
                }
            }
        }
    }
}

