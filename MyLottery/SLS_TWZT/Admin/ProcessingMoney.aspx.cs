using Alipay.Gateway;
using ASP;
using DAL;
using Interface99Bill;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ProcessingMoney : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        DateTime now = DateTime.Now;
        DateTime result = DateTime.Now;
        if (!DateTime.TryParse(this.tbBeginTime.Text, out now) || !DateTime.TryParse(this.tbEndTime.Text, out result))
        {
            JavaScript.Alert(this.Page, "请输入正确的日期范围!");
        }
        else
        {
            string commandText = "SELECT a.ID,a.SiteID,a.UserID,a.[DateTime], a.PayType,a.[Money],a.FormalitiesFees,a.Result, \r\n\t\t\t                        b.Name, b.RealityName, b.Sex, b.IDCardNumber, b.[Address], b.Email, b.QQ, b.Telephone, b.Mobile\r\n                        FROM dbo.T_UserPayDetails a INNER JOIN dbo.T_Users b ON a.UserID = b.ID \r\n                        where  a.[DateTime]>=@fromDate and a.[DateTime]<=@toDate ";
            MSSQL.Parameter[] paras = new MSSQL.Parameter[3];
            paras[0] = new MSSQL.Parameter("@fromDate", SqlDbType.DateTime, 8, ParameterDirection.Input, now);
            paras[1] = new MSSQL.Parameter("@toDate", SqlDbType.DateTime, 8, ParameterDirection.Input, result);
            DataTable dt = null;
            if (!string.IsNullOrEmpty(this.tbName.Text.Trim()))
            {
                dt = MSSQL.Select(commandText + " and Name like '%" + Shove._Web.Utility.FilteSqlInfusion(this.tbName.Text.Trim()) + "%'", paras);
            }
            else
            {
                dt = MSSQL.Select(commandText, paras);
            }
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_UserForInitiateFollowSchemeTrys");
            }
            else
            {
                PF.DataGridBindData(this.g, dt, this.gPager);
            }
        }
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        if ((this.tbBeginTime.Text.Trim() != "") && (this.tbEndTime.Text.Trim() != ""))
        {
            DateTime now = DateTime.Now;
            DateTime result = DateTime.Now;
            if (!DateTime.TryParse(this.tbBeginTime.Text, out now) && !DateTime.TryParse(this.tbEndTime.Text, out result))
            {
                JavaScript.Alert(this.Page, "请输入正确的日期格式:2008-8-8");
                return;
            }
        }
        this.BindData();
    }

    protected bool Check99BillPay(long payNumber, ref string DealID, ref string ErrorMessage)
    {
        SystemOptions options = new SystemOptions();
        string str = options["OnlinePay_99Bill_QueryMD5Key"].Value.ToString();
        string str2 = options["OnlinePay_99Bill_UserNumber"].Value.ToString();
        GatewayOrderQueryRequest request = new GatewayOrderQueryRequest
        {
            inputCharset = "1",
            version = "v2.0",
            signType = 1,
            merchantAcctId = str2,
            queryType = 0,
            queryMode = 1,
            requestPage = "1",
            orderId = payNumber.ToString()
        };
        string dataStr = string.Concat(new object[] { 
            "inputCharset=", request.inputCharset, "&version=", request.version, "&signType=", request.signType, "&merchantAcctId=", request.merchantAcctId, "&queryType=", request.queryType, "&queryMode=", request.queryMode, "&requestPage=", request.requestPage, "&orderId=", request.orderId, 
            "&key=", str
         });
        request.signMsg = GetMD5(dataStr, "utf-8").ToUpper();
        GatewayOrderQueryResponse response = new GatewayOrderQueryService().gatewayOrderQuery(request);
        bool flag1 = response.errCode != "";
        if (response != null)
        {
            string str4 = "";
            if (GetMD5(((((((str4 + "version=" + response.version) + "&signType=" + response.signType) + "&merchantAcctId=" + response.merchantAcctId) + (string.IsNullOrEmpty(response.errCode) ? "" : ("&errCode=" + response.errCode))) + (string.IsNullOrEmpty(response.currentPage) ? "" : ("&currentPage=" + response.currentPage)) + (string.IsNullOrEmpty(response.pageCount) ? "" : ("&pageCount=" + response.pageCount))) + (string.IsNullOrEmpty(response.pageSize) ? "" : ("&pageSize=" + response.pageSize)) + (string.IsNullOrEmpty(response.recordCount) ? "" : ("&recordCount=" + response.recordCount))) + "&key=" + str, "utf-8").ToUpper() != response.signMsg)
            {
                ErrorMessage = "[快钱]查询结果数据签名验证失败.";
                return false;
            }
            if ((response.orders == null) || (response.orders.Length == 0))
            {
                ErrorMessage = "[快钱]没有此支付成功记录.";
                return false;
            }
            if (response.orders.Length == 1)
            {
                string str6 = "";
                str6 = (((((((((str6 + "orderId=" + response.orders[0].orderId) + "&orderAmount=" + response.orders[0].orderAmount) + "&orderTime=" + response.orders[0].orderTime) + "&dealTime=" + response.orders[0].dealTime) + "&payResult=" + response.orders[0].payResult) + "&payType=" + response.orders[0].payType) + "&payAmount=" + response.orders[0].payAmount) + "&fee=" + response.orders[0].fee) + "&dealId=" + response.orders[0].dealId) + "&key=" + str;
                if (GetMD5(str6, "utf-8").ToUpper() != response.orders[0].signInfo)
                {
                    ErrorMessage = "[快钱]查询支付记录的签名验证失败." + str6;
                    return false;
                }
                if (response.orders[0].orderId != payNumber.ToString())
                {
                    ErrorMessage = "[快钱]返回的订单号不一致." + str6;
                    return false;
                }
                if (response.orders[0].payResult != "10")
                {
                    ErrorMessage = "[快钱]此支付记录没有成功.";
                    return false;
                }
                DealID = response.orders[0].dealId;
                return true;
            }
        }
        ErrorMessage = "[快钱]未知原因";
        return false;
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            string str6;
            int num = -9999;
            long userID = _Convert.StrToLong(e.Item.Cells[9].Text, 0L);
            string text = e.Item.Cells[10].Text;
            double money = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            double formalitiesFees = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            string paymentNumber = e.Item.Cells[8].Text;
            string payBank = this.getBankName(text);
            _Convert.StrToDateTime(e.Item.Cells[2].Text, DateTime.Now.ToString("yyyyMMdd"));
            string str4 = _Convert.StrToDateTime(e.Item.Cells[2].Text, DateTime.Now.ToString("yyyyMMdd")).ToString("yyyyMMdd");
            int returnValue = -1;
            string returnDescription = "";
            if ((e.CommandName == "Query") && ((str6 = text.Split(new char[] { '_' })[0].ToUpper()) != null))
            {
                if (str6 == "ALIPAY")
                {
                    string alipayPaymentNumber = "";
                    OnlinePay pay = new OnlinePay();
                    try
                    {
                        num = pay.Query(e.Item.Cells[10].Text.Trim(), paymentNumber, ref alipayPaymentNumber, ref returnDescription);
                    }
                    catch
                    {
                        JavaScript.Alert(this.Page, "查询失败，可能是网络通讯故障。请重试一次。");
                        return;
                    }
                    if (num < 0)
                    {
                        JavaScript.Alert(this.Page, "支付号为 " + paymentNumber + " 的支付记录没有充值成功，描述：" + returnDescription);
                        return;
                    }
                    string memo = "系统交易号：" + paymentNumber + ",支付宝交易号：" + alipayPaymentNumber;
                    returnDescription = "";
                    if (Procedures.P_UserAddMoney(base._Site.ID, userID, money, formalitiesFees, paymentNumber, payBank, memo, ref returnValue, ref returnDescription) < 0)
                    {
                        JavaScript.Alert(this.Page, "数据库读写错误");
                        return;
                    }
                    if (returnValue < 0)
                    {
                        JavaScript.Alert(this.Page, returnDescription);
                        return;
                    }
                    JavaScript.Alert(this.Page, "此笔充值记录已到帐并已处理成功！");
                }
                else if (str6 == "51ZFK")
                {
                    this.frmmain.Attributes.Add("src", "../Home/Room/OnlinePay/ZhiFuKa/PayQuery.aspx?sdcustomno=" + paymentNumber);
                }
                else if (str6 == "TENPAY")
                {
                    this.frmmain.Attributes.Add("src", "../Home/Room/OnlinePay/Tenpay/PayQuery.aspx?sp_billno=" + paymentNumber + "&date=" + str4);
                }
                else if (str6 == "007KA")
                {
                    this.frmmain.Attributes.Add("src", "../Home/Room/OnlinePay/007ka/PayQuery.aspx?OrderID=" + paymentNumber);
                }
                else if (str6 == "99BILL")
                {
                    string dealID = "";
                    string errorMessage = "";
                    if (this.Check99BillPay(long.Parse(paymentNumber), ref dealID, ref errorMessage) && (errorMessage == ""))
                    {
                        string str11 = "系统交易号：" + paymentNumber + ",快钱交易号：" + dealID;
                        returnDescription = "";
                        returnValue = -1;
                        if (Procedures.P_UserAddMoney(base._Site.ID, userID, money, formalitiesFees, paymentNumber, payBank, str11, ref returnValue, ref returnDescription) < 0)
                        {
                            JavaScript.Alert(this.Page, string.Concat(new object[] { "数据库读写错误:", base._Site.ID, " , ", userID, " , ", money, " , ", formalitiesFees, " , ", paymentNumber, " , ", payBank, " , ", str11 }));
                            return;
                        }
                        if (returnValue < 0)
                        {
                            JavaScript.Alert(this.Page, returnDescription);
                            return;
                        }
                        JavaScript.Alert(this.Page, "此笔充值记录已到帐并已处理成功！");
                        this.BindData();
                    }
                    else
                    {
                        JavaScript.Alert(this.Page, errorMessage);
                    }
                }
            }
            if (e.CommandName == "Accept")
            {
                string str12 = "手动处理充值" + ((TextBox)e.Item.Cells[4].FindControl("tbDescription")).Text.Trim();
                num = -1;
                if (Procedures.P_UserAddMoney(base._Site.ID, userID, money, formalitiesFees, paymentNumber, payBank, str12, ref returnValue, ref returnDescription) < 0)
                {
                    returnDescription = "数据库读写错误";
                    return;
                }
                if (returnValue < 0)
                {
                    JavaScript.Alert(this.Page, returnDescription);
                }
                JavaScript.Alert(this.Page, "此笔充值处理成功！");
            }
            if (e.CommandName == "Del")
            {
                try
                {
                    new Tables.T_UserPayDetails().Delete("ID=" + paymentNumber + " and Result = 0");
                }
                catch
                {
                    JavaScript.Alert(this.Page, "此笔充值删除失败！");
                }
                JavaScript.Alert(this.Page, "此笔充值删除成功！");
            }
            this.BindData();
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[4].Text = this.getBankName(e.Item.Cells[10].Text);
            e.Item.Cells[3].Text = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0).ToString("N");
            e.Item.Cells[5].Text = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0).ToString("N");
        }
    }

    private string getBankName(string bankCode)
    {
        string str = "";
        string[] strArray = bankCode.Split(new char[] { '_' });
        if (strArray.Length < 2)
        {
            return "未知银行";
        }
        if (strArray[0].ToUpper() == "ALIPAY")
        {
            switch (strArray[1].ToUpper())
            {
                case "ALIPAY":
                    return "支付宝";

                case "ICBCB2C":
                    return "中国工商银行";

                case "GDB":
                    return "广东发展银行";

                case "CEBBANK":
                    return "中国光大银行";

                case "CCB":
                    return "中国建设银行";

                case "COMM":
                    return "中国交通银行";

                case "ABC":
                    return "中国农业银行";

                case "SPDB":
                    return "上海浦发银行";

                case "SDB":
                    return "深圳发展银行";

                case "CIB":
                    return "兴业银行";

                case "HZCBB2C":
                    return "杭州银行";

                case "CMBC":
                    return "杭州银行";

                case "BOCB2C":
                    return "中国银行";

                case "CMB":
                    return "中国招商银行";

                case "CITIC":
                    return "中信银行";
            }
            return "支付宝";
        }
        if (strArray[0].ToUpper() == "TENPAY")
        {
            switch (strArray[1].ToUpper())
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
        if (strArray[0].ToUpper() == "51ZFK")
        {
            switch (strArray[1].ToUpper())
            {
                case "SZX":
                    return "神州行充值卡";

                case "ZFK":
                    return "51支付卡";
            }
            return "神州行充值卡";
        }
        if (strArray[0].ToUpper() == "007KA")
        {
            return "007KA支付";
        }
        if (strArray[0].ToUpper() == "99BILL")
        {
            str = "快钱支付";
        }
        return str;
    }

    private static string GetMD5(string dataStr, string codeType)
    {
        byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(codeType).GetBytes(dataStr));
        StringBuilder builder = new StringBuilder(0x20);
        for (int i = 0; i < buffer.Length; i++)
        {
            builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
        }
        return builder.ToString();
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = "Admin/ProcessingMoney.aspx";
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "MemberManagement" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.frmmain.Attributes.Add("src", "");
        if (!base.IsPostBack)
        {
            this.tbBeginTime.Text = DateTime.Now.AddDays(-1.0).ToString("yyyy-MM-dd HH:mm:ss");
            this.tbEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.BindData();
        }
    }

}

