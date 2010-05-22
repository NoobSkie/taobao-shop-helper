using ASP;
using DAL;
using Shove;
using Shove._Security;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using Shove._Web;


public partial class Home_Room_OnlinePay_ZhiFuKa_Receive : RoomPageBase, IRequiresSessionState
{
    private long buyId;
    private string cardno = "";
    private string customerid = "";
    private string key = "";
    private string mark = "";
    private string noticeurl = (Utility.GetUrl() + "/Home/Room/OnlinePay/ZhiFuKa/Receive.aspx");
    private double ordermoney;
    public const int PAYERROR = 2;
    public const int PAYMD5ERROR = 4;
    public const int PAYOK = 1;
    public const int PAYSPERROR = 3;
    private string sd51no = "";
    private string sdcustomno = "";
    private SystemOptions so = new SystemOptions();
    private int state = 2;
    private long userId = -1L;

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

    private string GetMD5(string encypStr)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
        return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "").ToUpper();
    }

    private string GetPayResultSign()
    {
        string encypStr = "customerid=" + this.customerid + "&sd51no=" + this.sd51no + "&sdcustomno=" + this.sdcustomno + "&mark=" + this.mark + "&key=" + this.key;
        return this.GetMD5(encypStr);
    }

    private bool GetPayValueFromUrl(NameValueCollection querystring, out string errmsg)
    {
        if ((querystring == null) || (querystring.Count == 0))
        {
            errmsg = "参数为空";
            return false;
        }
        if (querystring["state"] == null)
        {
            errmsg = "没有state参数或state参数不正确";
            return false;
        }
        if (querystring["customerid"] == null)
        {
            errmsg = "没有customerid参数";
            return false;
        }
        if (querystring["sd51no"] == null)
        {
            errmsg = "没有sd51no参数";
            return false;
        }
        if (querystring["sdcustomno"] == null)
        {
            errmsg = "没有sdcustomno参数";
            return false;
        }
        if (querystring["ordermoney"] == null)
        {
            errmsg = "没有ordermoney参数";
            return false;
        }
        if (querystring["cardno"] == null)
        {
            errmsg = "没有cardno参数";
            return false;
        }
        if (querystring["mark"] == null)
        {
            errmsg = "没有mark参数";
            return false;
        }
        if (querystring["sign"] == null)
        {
            errmsg = "没有sign参数";
            return false;
        }
        errmsg = "";
        try
        {
            this.state = _Convert.StrToInt(querystring["state"].Trim(), 2);
            this.sd51no = querystring["sd51no"];
            this.sdcustomno = querystring["sdcustomno"];
            this.ordermoney = _Convert.StrToDouble(querystring["ordermoney"], 0.0);
            this.cardno = querystring["cardno"];
            this.mark = querystring["mark"];
            this.userId = _Convert.StrToLong(Encrypt.UnEncryptString(PF.GetCallCert(), this.mark).Split(new char[] { '|' })[0], -1L);
            this.buyId = _Convert.StrToLong(Encrypt.UnEncryptString(PF.GetCallCert(), this.mark).Split(new char[] { '|' })[1], -1L);
            if (querystring["customerid"] != this.customerid)
            {
                this.state = 3;
                return true;
            }
            string str = querystring["sign"];
            if (this.GetPayResultSign() != str)
            {
                this.state = 4;
            }
            return true;
        }
        catch (Exception exception)
        {
            errmsg = "解析参数出错:" + exception.Message;
            return false;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = false;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string errmsg = "";
            this.key = this.so["OnlinePay_ZhiFuKa_MD5Key"].Value.ToString();
            this.customerid = this.so["OnlinePay_ZhiFuKa_UserNumber"].Value.ToString();
            if (this.GetPayValueFromUrl(base.Request.QueryString, out errmsg))
            {
                if ((this.state == 1) || (this.state == 2))
                {
                    Users users = new Users(base._Site.ID)[base._Site.ID, this.userId];
                    if (users == null)
                    {
                        errmsg = "在线支付：充值未完成。错误描述：异常用户数据！ 支付号：" + this.sdcustomno;
                        base.Response.Write(errmsg + "<br/>");
                    }
                    else
                    {
                        if (base._User == null)
                        {
                            base._User = new Users(base._Site.ID)[base._Site.ID, users.ID];
                            string returnDescription = "";
                            base._User.LoginDirect(ref returnDescription);
                        }
                        if (this.state == 1)
                        {
                            if (this.WriteUserAccount("系统交易号：" + this.sdcustomno + " 51支付交易号：" + this.sd51no))
                            {
                                this.ReturnResult("1");
                            }
                            else
                            {
                                this.ReturnResult("1001");
                            }
                        }
                        else
                        {
                            this.ReturnResult("1");
                        }
                    }
                }
                else
                {
                    this.ReturnResult("3001");
                }
            }
            else
            {
                this.ReturnResult("3001");
            }
        }
        catch
        {
            this.ReturnResult("5001");
        }
    }

    private void ReturnResult(string resultCode)
    {
        base.Response.Write("<result>" + resultCode + "</result>");
    }

    private bool WriteUserAccount(string Memo)
    {
        double num = this.so["OnlinePay_ZhiFuKa_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
        double formalitiesFees = Math.Round((double)(this.ordermoney * num), 2);
        this.ordermoney -= formalitiesFees;
        string returnDescription = "";
        bool flag = base._User.AddUserBalance(this.ordermoney, formalitiesFees, this.sdcustomno, this.getBankName(this.cardno), Memo, ref returnDescription) == 0;
        if (flag)
        {
            return flag;
        }
        DataTable table = new Tables.T_UserPayDetails().Open("Result", "[id] = " + _Convert.StrToLong(this.sdcustomno, 0L).ToString(), "");
        if ((table == null) || (table.Rows.Count == 0))
        {
            return false;
        }
        return (_Convert.StrToInt(table.Rows[0][0].ToString(), 0) == 1);
    }
}

