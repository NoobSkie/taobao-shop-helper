using ASP;
using DAL;
using Shove;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_Tenpay_QueryResult : RoomPageBase, IRequiresSessionState
{
    private string attach = "";
    private string bargainor_id = "";
    private string date = "";
    private int fee_type;
    private string key = "";
    private int pay_result;
    private string payerrmsg = "";
    public const int PAYERROR = 3;
    public const int PAYMD5ERROR = 2;
    public const int PAYOK = 0;
    public const int PAYSPERROR = 1;
    private const int querycmdno = 2;
    private SystemOptions so = new SystemOptions();
    private string sp_billno = "";
    private long total_fee;
    private string transaction_id = "";

    private string getBankName(string bankCode)
    {
        switch (bankCode.ToLower())
        {
            case "0":
                return "财付通";

            case "1001":
                return "招商银行";

            case "1002":
                return "中国工商银行";

            case "1003":
                return "中国建设银行";

            case "1004":
                return "上海浦东发展银行";

            case "1005":
                return "中国农业银行";

            case "1006":
                return "中国民生银行";

            case "1008":
                return "深圳发展银行";

            case "1009":
                return "兴业银行";

            case "1028":
                return "广州银联";

            case "1032":
                return "   北京银行";

            case "1020":
                return "   中国交通银行";

            case "1022":
                return "   中国光大银行";
        }
        return "财付通";
    }

    private string GetMD5(string encypStr)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
        return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "").ToUpper();
    }

    private string GetQueryResultSign()
    {
        string encypStr = string.Concat(new object[] { 
            "cmdno=", 2, "&pay_result=", this.pay_result, "&date=", this.date, "&transaction_id=", this.transaction_id, "&sp_billno=", this.sp_billno, "&total_fee=", this.total_fee, "&fee_type=", this.fee_type, "&attach=", this.attach, 
            "&key=", this.key
         });
        return this.GetMD5(encypStr);
    }

    public bool GetQueryValueFromUrl(NameValueCollection querystring, out string errmsg)
    {
        if ((querystring == null) || (querystring.Count == 0))
        {
            errmsg = "参数为空";
            return false;
        }
        if (querystring["cmdno"] != null)
        {
            int num = 2;
            if (!(querystring["cmdno"].ToString().Trim() != num.ToString()))
            {
                goto Label_005B;
            }
        }
        errmsg = "没有cmdno参数或cmdno参数不正确";
        return false;
    Label_005B:
        if (querystring["pay_result"] == null)
        {
            errmsg = "没有pay_result参数";
            return false;
        }
        if (querystring["date"] == null)
        {
            errmsg = "没有date参数";
            return false;
        }
        if (querystring["pay_info"] == null)
        {
            errmsg = "没有pay_info参数";
            return false;
        }
        if (querystring["bargainor_id"] == null)
        {
            errmsg = "没有bargainor_id参数";
            return false;
        }
        if (querystring["transaction_id"] == null)
        {
            errmsg = "没有transaction_id参数";
            return false;
        }
        if (querystring["sp_billno"] == null)
        {
            errmsg = "没有sp_billno参数";
            return false;
        }
        if (querystring["total_fee"] == null)
        {
            errmsg = "没有total_fee参数";
            return false;
        }
        if (querystring["fee_type"] == null)
        {
            errmsg = "没有fee_type参数";
            return false;
        }
        if (querystring["attach"] == null)
        {
            errmsg = "没有attach参数";
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
            this.pay_result = int.Parse(querystring["pay_result"].Trim());
            this.payerrmsg = UrlDecode(querystring["pay_info"].Trim());
            this.date = querystring["date"];
            this.transaction_id = querystring["transaction_id"];
            this.sp_billno = querystring["sp_billno"];
            this.total_fee = long.Parse(querystring["total_fee"]);
            this.fee_type = int.Parse(querystring["fee_type"]);
            this.attach = querystring["attach"];
            if (querystring["bargainor_id"] != this.bargainor_id)
            {
                this.pay_result = 1;
                return true;
            }
            string str = querystring["sign"];
            if (this.GetQueryResultSign() != str)
            {
                this.pay_result = 2;
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

    private void Page_Load(object sender, EventArgs e)
    {
        string errmsg = "";
        this.key = this.so["OnlinePay_Tenpay_MD5Key"].Value.ToString();
        this.bargainor_id = this.so["OnlinePay_Tenpay_UserNumber"].Value.ToString();
        if (this.GetQueryValueFromUrl(base.Request.QueryString, out errmsg))
        {
            if (this.pay_result != 0)
            {
                base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sp_billno + " 的支付记录没有充值成功，描述：" + this.payerrmsg + "\");</script>");
            }
            else
            {
                try
                {
                    string memo = "系统交易号：" + this.sp_billno + ",财付通交易号：" + this.transaction_id;
                    int returnValue = -1;
                    string returnDescription = "";
                    DataTable table = new Tables.T_UserPayDetails().Open("", "ID=" + this.sp_billno, "");
                    if ((table == null) || (table.Rows.Count <= 0))
                    {
                        base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sp_billno + " 的支付记录没有充值成功，描述：充值处理失败，本条数据丢失。\");</script>");
                    }
                    else
                    {
                        double money = _Convert.StrToDouble(table.Rows[0]["Money"].ToString(), 0.0);
                        long userID = _Convert.StrToLong(table.Rows[0]["UserID"].ToString(), 0L);
                        double formalitiesFees = _Convert.StrToDouble(table.Rows[0]["FormalitiesFees"].ToString(), 0.0);
                        string[] strArray = table.Rows[0]["PayType"].ToString().Split(new char[] { '_' });
                        string bankCode = (strArray.Length < 2) ? "" : strArray[1];
                        if (Procedures.P_UserAddMoney(base._Site.ID, userID, money, formalitiesFees, this.sp_billno, this.getBankName(bankCode), memo, ref returnValue, ref returnDescription) < 0)
                        {
                            base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sp_billno + " 的支付记录没有充值成功，描述：数据库读写错误\");</script>");
                        }
                        else if (returnValue < 0)
                        {
                            base.Response.Write("<script type=\"text/javascript\">alert(\"" + returnDescription + "\");</script>");
                        }
                        else
                        {
                            base.Response.Write("<script type=\"text/javascript\">alert(\"此笔充值记录已到帐并已处理成功！\");</script>");
                        }
                    }
                }
                catch
                {
                    base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sp_billno + " 的支付记录没有充值成功，描述：查询失败，可能是网络通讯故障。请重试一次。\");</script>");
                }
            }
        }
        else
        {
            errmsg = "认证签名失败";
            base.Response.Write("<script type=\"text/javascript\">alert(\"支付号为 " + this.sp_billno + " 的支付记录没有充值成功，描述：" + errmsg + "\");</script>");
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

