using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_BindBankCard : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.Label1.Text = base._User.Name;
        this.labName.Text = base._User.Name;
        string str = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        string str5 = "";
        string str6 = "";
        StringBuilder builder = new StringBuilder();
        builder.Append("select BankTypeName,BankName, BankCardNumber, BankInProvinceName, BankInCityName, BankUserName from  T_userBankBindDetails  ").Append(" where  UserID = " + base._User.ID.ToString() + " ");
        DataTable table = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
        if ((table != null) && (table.Rows.Count > 0))
        {
            str2 = table.Rows[0]["BankName"].ToString().Trim();
            str3 = table.Rows[0]["BankCardNumber"].ToString().Trim();
            str6 = table.Rows[0]["BankUserName"].ToString().Trim();
            str = table.Rows[0]["BankTypeName"].ToString().Trim();
            this.tbBankCardNumber.Text = str3;
            this.tbBankCardNumberOK.Text = str3;
            this.tbBankCardRealityName.Text = str6;
            this.HidBankName.Value = str2;
            str4 = table.Rows[0]["BankInProvinceName"].ToString().Trim();
            str5 = table.Rows[0]["BankInCityName"].ToString().Trim();
            this.hfBankInProvince.Value = table.Rows[0]["BankInProvinceName"].ToString().Trim();
            this.hfBankInCity.Value = table.Rows[0]["BankInCityName"].ToString().Trim();
            this.hfBankTypeName.Value = table.Rows[0]["BankTypeName"].ToString().Trim();
            this.hfBankName.Value = table.Rows[0]["BankName"].ToString().Trim();
        }
        if (str3.Trim() == "")
        {
            this.lbBankCardNumber.Text = base._User.BankCardNumber;
            this.lbBankCardNumberOK.Text = base._User.BankCardNumber;
        }
        else
        {
            this.lbBankCardNumber.Text = (str3.Length > 4) ? ("************" + str3.Substring(str3.Length - 4, 4)) : str3;
            this.lbBankCardNumberOK.Text = (str3.Length > 4) ? ("************" + str3.Substring(str3.Length - 4, 4)) : str3;
        }
        if (str6.Length > 1)
        {
            this.lbBankCardRealityName.Text = "*".PadLeft(str6.Length - 1, '*') + str6.Substring(str6.Length - 1);
        }
        if ((((str3 != "") && (str6 != "")) && ((str != "") && (str2 != ""))) && ((str4 != "") && (str5 != "")))
        {
            this.hfIsBindFlag.Value = "true";
            this.labBindState.Text = "已绑定";
            this.lbStatus.Text = "您已经绑定";
            this.showTxtOrLbl(2);
        }
        else
        {
            this.hfIsBindFlag.Value = "false";
            this.labBindState.Text = "未绑定";
            this.lbStatus.Text = "您一旦绑定";
            this.tbBankCardNumber.Text = base._User.BankCardNumber;
            this.showTxtOrLbl(1);
        }
        if (base._User.SecurityQuestion.StartsWith("自定义问题|"))
        {
            this.lbQuestion.Text = base._User.SecurityQuestion.Remove(0, 6);
        }
        else
        {
            this.lbQuestion.Text = base._User.SecurityQuestion;
        }
        if (this.lbQuestion.Text == "")
        {
            this.lbQuestionInfo.Text = "设置安全保护问题";
        }
        else
        {
            this.lbQuestionInfo.Text = "修改安全保护问题";
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            string bankInProvinceName = (base.Request.Form["selProvince"] == null) ? "" : base.Request.Form["selProvince"].ToString();
            string bankInCityName = (base.Request.Form["selCity"] == null) ? "" : base.Request.Form["selCity"].ToString();
            string bankTypeName = (base.Request.Form["selBankTypeName"] == null) ? "" : base.Request.Form["selBankTypeName"].ToString();
            string bankName = (base.Request.Form["selBankName"] == null) ? "" : base.Request.Form["selBankName"].ToString();
            string bankCardNumber = Shove._Web.Utility.FilteSqlInfusion(this.tbBankCardNumber.Text.Trim());
            string bankUserName = Shove._Web.Utility.FilteSqlInfusion(this.tbBankCardRealityName.Text.Trim());
            string str7 = Shove._Web.Utility.FilteSqlInfusion(this.tbBankCardNumberOK.Text.Trim());
            if (base._User.RealityName == "")
            {
                base.Response.Write("<script type='text/javascript'>alert('请完善您的基本资料，真实姓名不能为空，谢谢！');window.location='UserEdit.aspx?FromUrl=BindBankCard.aspx'</script>");
            }
            if (this.lbQuestion.Visible && (this.lbQuestion.Text == ""))
            {
                JavaScript.Alert(this.Page, "为了您的账户安全，请先设置安全保护问题，谢谢！");
            }
            else if (bankInProvinceName == "")
            {
                JavaScript.Alert(this.Page, "请输入银行卡开户银行所在的省份！");
            }
            else if (bankInCityName == "")
            {
                JavaScript.Alert(this.Page, "请输入银行卡开户银行所在的城市！");
            }
            else if (bankTypeName == "")
            {
                JavaScript.Alert(this.Page, "请输入银行卡开户银行类型！");
            }
            else if (bankName == "")
            {
                JavaScript.Alert(this.Page, "请输入银行卡开户银行支行名称！");
            }
            else if (bankCardNumber == "")
            {
                JavaScript.Alert(this.Page, "请输入收款银行卡号！");
            }
            else if (!_String.Valid.isBankCardNumber(bankCardNumber))
            {
                JavaScript.Alert(this.Page, "银行卡号输入有误！");
            }
            else if (bankCardNumber != str7)
            {
                JavaScript.Alert(this.Page, "两次输入的银行卡号不一致，请确认后提交，谢谢！");
            }
            else if (bankUserName == "")
            {
                JavaScript.Alert(this.Page, "请输入持卡人真实姓名！");
            }
            else if (bankUserName != base._User.RealityName)
            {
                JavaScript.Alert(this.Page, base._Site.Name + "目前不支持设置非自己本人开户的银行卡帐户进行提款！");
            }
            else if (this.tbRealityName.Text.Trim() != base._User.RealityName)
            {
                JavaScript.Alert(this.Page, "请核实您的真实姓名，谢谢！");
            }
            else if (this.tbMyA.Text.Trim() != base._User.SecurityAnswer)
            {
                JavaScript.Alert(this.Page, "安全保护问题回答错误。");
            }
            else if (this.tbNewQF.Visible && (Shove._Web.Utility.FilteSqlInfusion(this.tbAnswer.Text).Trim() == ""))
            {
                JavaScript.Alert(this.Page, "请输入安全问题，谢谢！");
            }
            else
            {
                Thread.Sleep(500);
                Users user = new Users(base._Site.ID);
                base._User.Clone(user);
                base._User.BankName = bankName;
                base._User.BankCardNumber = bankCardNumber;
                if (this.tbNewQF.Visible)
                {
                    base._User.SecurityQuestion = this.ddlQuestion.SelectedItem.Text.ToString().Trim();
                    base._User.SecurityAnswer = this.tbAnswer.Text.Trim();
                    if (MSSQL.ExecuteNonQuery("update T_Users set SecurityQuestion='" + this.ddlQuestion.SelectedItem.Text.ToString().Trim() + "' , SecurityAnswer='" + Shove._Web.Utility.FilteSqlInfusion(this.tbAnswer.Text.Trim()) + "' where ID=" + base._User.ID.ToString(), new MSSQL.Parameter[0]) == 0)
                    {
                        return;
                    }
                }
                int returnValue = 0;
                string returnDescription = "";
                if (base._User.EditByID(ref returnDescription) < 0)
                {
                    user.Clone(base._User);
                    JavaScript.Alert(this.Page, returnDescription);
                }
                else if ((bankName == "") || ((this.HidBankName1.Value != bankName) && (bankName.IndexOf("*") > -1)))
                {
                    JavaScript.Alert(this.Page, "请输入正确的银行格式！");
                }
                else
                {
                    if (this.HidBankName1.Value == bankName)
                    {
                        bankName = this.HidBankName.Value;
                    }
                    if (Procedures.P_UserBankDetailEdit(base._Site.ID, base._User.ID, bankTypeName, bankName, bankCardNumber, bankInProvinceName, bankInCityName, bankUserName, ref returnValue, ref returnDescription) < 0)
                    {
                        user.Clone(base._User);
                        JavaScript.Alert(this.Page, returnDescription);
                    }
                    else if (returnValue < 0)
                    {
                        user.Clone(base._User);
                        JavaScript.Alert(this.Page, returnDescription);
                    }
                    else
                    {
                        this.hfBankInProvince.Value = bankInProvinceName;
                        this.hfBankInCity.Value = bankInCityName;
                        this.hfBankTypeName.Value = bankTypeName;
                        this.hfBankName.Value = bankName;
                        string request = Shove._Web.Utility.GetRequest("FromUrl");
                        if (request == "")
                        {
                            request = "BindBankCard.aspx";
                        }
                        else if (Shove._Web.Utility.GetRequest("Type") != "")
                        {
                            request = request + "?Type=2";
                        }
                        JavaScript.Alert(this.Page, "银行卡绑定成功。", request);
                    }
                }
            }
        }
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void ddlQuestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlQuestion.SelectedValue == "自定义问题")
        {
            this.trMQ.Visible = true;
        }
        else
        {
            this.trMQ.Visible = false;
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string GetBankBranchNameList(string cityName, string bankTypeName)
    {
        string key = "Home_Room_BindBankCard_GetBankBranchNameList_" + cityName + "_" + bankTypeName;
        string cacheAsString = Shove._Web.Cache.GetCacheAsString(key, "");
        if (string.IsNullOrEmpty(cacheAsString))
        {
            DataTable table = MSSQL.Select("select   BankName  from T_BankDetails where BankTypeName='" + bankTypeName + "' and CityName='" + cityName + "'   order by BankName ", new MSSQL.Parameter[0]);
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                builder.Append(row["BankName"].ToString() + "|");
            }
            cacheAsString = builder.ToString();
            Shove._Web.Cache.SetCache(key, cacheAsString, 600);
        }
        return cacheAsString;
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string GetBankTypeList()
    {
        string key = "Home_Room_BindBankCard_GetBankTypeList";
        string cacheAsString = Shove._Web.Cache.GetCacheAsString(key, "");
        if (string.IsNullOrEmpty(cacheAsString))
        {
            DataTable table = MSSQL.Select("select distinct  BankTypeName  from T_BankDetails order by BankTypeName ", new MSSQL.Parameter[0]);
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                builder.Append(row["BankTypeName"].ToString() + "|");
            }
            cacheAsString = builder.ToString();
            Shove._Web.Cache.SetCache(key, cacheAsString, 600);
        }
        return cacheAsString;
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string GetCityList(string ProvinceName)
    {
        string key = "BANK_PROVINCE_CITY_LIST" + ProvinceName;
        string cacheAsString = Shove._Web.Cache.GetCacheAsString(key, "");
        if (string.IsNullOrEmpty(cacheAsString))
        {
            DataTable table = MSSQL.Select("select distinct CityName from T_BankDetails where ProvinceName='" + Shove._Web.Utility.FilteSqlInfusion(ProvinceName) + "' order by CityName ", new MSSQL.Parameter[0]);
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                builder.Append(row["CityName"].ToString() + "|");
            }
            cacheAsString = builder.ToString();
            Shove._Web.Cache.SetCache(key, cacheAsString);
        }
        return cacheAsString;
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string GetProvinceList()
    {
        string key = "Home_Room_BindBankCard_BankInProvince";
        string cacheAsString = Shove._Web.Cache.GetCacheAsString(key, "");
        if (string.IsNullOrEmpty(cacheAsString))
        {
            DataTable table = MSSQL.Select("select distinct ProvinceName from T_BankDetails order by ProvinceName ", new MSSQL.Parameter[0]);
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                builder.Append(row["ProvinceName"].ToString() + "|");
            }
            cacheAsString = builder.ToString();
            Shove._Web.Cache.SetCache(key, cacheAsString);
        }
        return cacheAsString;
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_BindBankCard), this.Page);
        if (!base.IsPostBack)
        {
            if (base.User != null)
            {
                DataTable table = new Tables.T_Users().Open("SecurityQuestion ,SecurityAnswer", "SiteID = " + base._Site.ID.ToString() + " and  ID=" + base._User.ID.ToString(), "");
                if ((table == null) || string.IsNullOrEmpty(table.Rows[0]["SecurityQuestion"].ToString()))
                {
                    this.tbNewQF.Visible = true;
                    this.divAnswer.Visible = false;
                }
                else
                {
                    this.tbNewQF.Visible = false;
                    this.divAnswer.Visible = true;
                }
            }
            this.BindData();
            this.ddlQuestion.DataSource = DataCache.SecurityQuestions;
            this.ddlQuestion.DataBind();
        }
    }

    private void showTxtOrLbl(int type)
    {
        if (type == 1)
        {
            this.tbBankCardNumber.Visible = true;
            this.tbBankCardNumberOK.Visible = true;
            this.tbBankCardRealityName.Visible = true;
            this.lbBankCardNumber.Visible = false;
            this.lbBankCardNumberOK.Visible = false;
            this.lbBankCardRealityName.Visible = false;
        }
        else
        {
            this.tbBankCardNumber.Visible = false;
            this.tbBankCardNumberOK.Visible = false;
            this.tbBankCardRealityName.Visible = false;
            this.lbBankCardNumber.Visible = true;
            this.lbBankCardNumberOK.Visible = true;
            this.lbBankCardRealityName.Visible = true;
        }
    }
}

