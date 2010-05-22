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
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_UserDetail : AdminPageBase, IRequiresSessionState
{
    private void BindData()
    {
        long siteid = _Convert.StrToLong(Shove._Web.Utility.GetRequest("SiteID"), -1L);
        long userID = _Convert.StrToLong(Shove._Web.Utility.GetRequest("id"), -1L);
        if ((siteid < 1L) || (userID < 1L))
        {
            base.Response.Redirect("Users.aspx", true);
        }
        else
        {
            DataTable table = new Views.V_Users().Open("", "SiteID = " + siteid.ToString() + " and [ID] = " + userID.ToString(), "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_UserDetail");
            }
            else if (table.Rows.Count < 1)
            {
                PF.GoError(1, "用户不存在", "Admin_UserDetail");
            }
            else
            {
                this.tbSiteID.Text = siteid.ToString();
                this.tbUserID.Text = userID.ToString();
                Users users = new Users(siteid)[siteid, userID];
                if (users.ID < 1L)
                {
                    PF.GoError(1, "用户不存在", "Admin_UserDetail");
                }
                else
                {
                    this.tbUserName.Text = users.Name;
                    this.tbUserEmail.Text = users.Email;
                    if (users.UserType == 1)
                    {
                        this.rbUserType1.Checked = true;
                    }
                    else if (users.UserType == 2)
                    {
                        this.rbUserType2.Checked = true;
                    }
                    else if (users.UserType == 3)
                    {
                        this.rbUserType3.Checked = true;
                    }
                    this.tbUserRealityName.Text = users.RealityName;
                    this.tbUserIDCardNumber.Text = _Convert.ToDBC(users.IDCardNumber);
                    this.ddlUserCity.City_id = users.CityID;
                    this.tbUserTelephone.Text = _Convert.ToDBC(users.Telephone);
                    this.tbUserMobile.Text = _Convert.ToDBC(users.Mobile);
                    this.cbUserMobileValid.Checked = users.isMobileValided && (users.Mobile != "");
                    this.tbUserEmail.Text = users.Email;
                    this.tbUserQQ.Text = _Convert.ToDBC(users.QQ);
                    this.tbUserAddress.Text = users.Address;
                    if (users.Sex == "男")
                    {
                        this.rbUserSexM.Checked = true;
                    }
                    else if (users.Sex == "女")
                    {
                        this.rbUserSexW.Checked = true;
                    }
                    this.tbUserBirthDay.Text = users.BirthDay.ToShortDateString();
                    this.tbUserBankCardNumber.Text = _Convert.ToDBC(users.BankCardNumber).Trim();
                    this.tbScoringOfSelfBuy.Text = users.ScoringOfSelfBuy.ToString();
                    this.tbScoringOfCommendBuy.Text = users.ScoringOfCommendBuy.ToString();
                    this.cbPrivacy.Checked = users.isPrivacy;
                    this.cbisCanLogin.Checked = users.isCanLogin;
                    string bankTypeName = "";
                    string bankName = "";
                    string bankCardNumber = "";
                    string bankInProvinceName = "";
                    string bankInCityName = "";
                    string bankUserName = "";
                    int returnValue = -1;
                    string returnDescription = "";
                    if (Procedures.P_GetUserBankDetail(siteid, userID, ref bankTypeName, ref bankName, ref bankCardNumber, ref bankInProvinceName, ref bankInCityName, ref bankUserName, ref returnValue, ref returnDescription) < 0)
                    {
                        JavaScript.Alert(this.Page, returnDescription);
                    }
                    else
                    {
                        this.tbUserCradName.Text = bankUserName;
                        this.tbUserBankCardNumber.Text = bankCardNumber;
                        this.hfBankInProvince.Value = bankInProvinceName;
                        this.hfBankInCity.Value = bankInCityName;
                        this.hfBankTypeName.Value = bankTypeName;
                        this.hfBankName.Value = bankName;
                        this.btnResetPassword.Enabled = base._User.Competences.IsOwnedCompetences("Administrator");
                    }
                }
            }
        }
    }

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        long siteid = _Convert.StrToLong(this.tbSiteID.Text, -1L);
        long num2 = _Convert.StrToLong(this.tbUserID.Text, -1L);
        if ((siteid < 1L) || (num2 < 1L))
        {
            PF.GoError(1, "参数错误", "Admin_UserDetail");
        }
        else
        {
            Users users = new Users(siteid)[siteid, num2];
            if (users.ID < 1L)
            {
                PF.GoError(1, "用户不存在", "Admin_UserDetail");
            }
            else
            {
                string randPassword = this.GetRandPassword();
                users.Password = randPassword;
                users.PasswordAdv = randPassword;
                string returnDescription = "";
                if (users.EditByID(ref returnDescription) < 0)
                {
                    JavaScript.Alert(this.Page, returnDescription);
                }
                else
                {
                    JavaScript.Alert(this.Page, "用户密码已经被重置为：" + randPassword + "，请牢记。");
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        long siteid = _Convert.StrToLong(this.tbSiteID.Text, -1L);
        long userID = _Convert.StrToLong(this.tbUserID.Text, -1L);
        string bankInProvinceName = (base.Request.Form["selProvince"] == null) ? "" : base.Request.Form["selProvince"].ToString();
        string bankInCityName = (base.Request.Form["selCity"] == null) ? "" : base.Request.Form["selCity"].ToString();
        string bankTypeName = (base.Request.Form["selBankTypeName"] == null) ? "" : base.Request.Form["selBankTypeName"].ToString();
        string bankName = (base.Request.Form["selBankName"] == null) ? "" : base.Request.Form["selBankName"].ToString();
        string bankCardNumber = this.tbUserBankCardNumber.Text.Trim();
        string bankUserName = Shove._Web.Utility.FilteSqlInfusion(this.tbUserCradName.Text.Trim());
        bool flag = ((((bankInProvinceName != "") || (bankInCityName != "")) || ((bankTypeName != "") || (bankName != ""))) || (bankCardNumber != "")) || (bankUserName != "");
        if ((siteid < 1L) || (userID < 1L))
        {
            PF.GoError(1, "参数错误", "Admin_UserDetail");
        }
        else
        {
            Users users = new Users(siteid)[siteid, userID];
            if (users.ID < 1L)
            {
                PF.GoError(1, "用户不存在", "Admin_UserDetail");
            }
            else if (this.tbUserEmail.Text.Trim() == "")
            {
                JavaScript.Alert(this.Page, "请输入电子邮件地址。");
            }
            else if (!_String.Valid.isEmail(this.tbUserEmail.Text.Trim()))
            {
                JavaScript.Alert(this.Page, "电子邮件地址格式不正确。");
            }
            else
            {
                if (this.rbUserType2.Checked)
                {
                    if (this.tbUserRealityName.Text.Trim() == "")
                    {
                        JavaScript.Alert(this.Page, "请输入真实姓名。");
                        return;
                    }
                    if (this.tbUserIDCardNumber.Text.Trim() == "")
                    {
                        JavaScript.Alert(this.Page, "请输入身份证号。");
                        return;
                    }
                    if (((!_String.Valid.isIDCardNumber(this.tbUserIDCardNumber.Text.Trim()) && !_String.Valid.isIDCardNumber_Hongkong(this.tbUserIDCardNumber.Text.Trim())) && (!_String.Valid.isIDCardNumber_Macau(this.tbUserIDCardNumber.Text.Trim()) && !_String.Valid.isIDCardNumber_Singapore(this.tbUserIDCardNumber.Text.Trim()))) && !_String.Valid.isIDCardNumber_Taiwan(this.tbUserIDCardNumber.Text.Trim()))
                    {
                        JavaScript.Alert(this.Page, "身份证号格式不正确。");
                        return;
                    }
                    try
                    {
                        DateTime.Parse(this.tbUserBirthDay.Text.Trim());
                    }
                    catch
                    {
                        JavaScript.Alert(this.Page, "请输入正确的生日。");
                        return;
                    }
                    if (flag)
                    {
                        if (bankName == "")
                        {
                            JavaScript.Alert(this.Page, "请输入开户银行。");
                            return;
                        }
                        if (bankCardNumber == "")
                        {
                            JavaScript.Alert(this.Page, "请输入银行卡号。");
                            return;
                        }
                        if (!_String.Valid.isBankCardNumber(bankCardNumber))
                        {
                            JavaScript.Alert(this.Page, "银行卡号格式不正确。");
                            return;
                        }
                        if (bankUserName == "")
                        {
                            JavaScript.Alert(this.Page, "请输入持卡人姓名。");
                            return;
                        }
                    }
                    if (_Convert.StrToDouble(this.tbScoringOfSelfBuy.Text, -1.0) < 0.0)
                    {
                        JavaScript.Alert(this.Page, "请输入正确的购彩积分比例。");
                        return;
                    }
                    if (_Convert.StrToDouble(this.tbScoringOfCommendBuy.Text, -1.0) < 0.0)
                    {
                        JavaScript.Alert(this.Page, "请输入正确的下级购彩积分比例。");
                        return;
                    }
                }
                users.UserType = this.rbUserType2.Checked ? ((short)2) : (this.rbUserType3.Checked ? ((short)3) : ((short)1));
                users.Email = this.tbUserEmail.Text.Trim();
                users.RealityName = this.tbUserRealityName.Text.Trim();
                users.IDCardNumber = _Convert.ToDBC(this.tbUserIDCardNumber.Text.Trim()).Trim();
                users.CityID = this.ddlUserCity.City_id;
                users.Telephone = _Convert.ToDBC(this.tbUserTelephone.Text.Trim()).Trim();
                users.Mobile = _Convert.ToDBC(this.tbUserMobile.Text.Trim()).Trim();
                users.isMobileValided = this.cbUserMobileValid.Checked && (users.Mobile != "");
                users.QQ = _Convert.ToDBC(this.tbUserQQ.Text.Trim()).Trim();
                users.Address = this.tbUserAddress.Text.Trim();
                users.Sex = this.rbUserSexM.Checked ? "男" : (this.rbUserSexW.Checked ? "女" : "");
                users.BirthDay = DateTime.Parse(this.tbUserBirthDay.Text.Trim());
                users.BankName = bankName;
                users.BankCardNumber = _Convert.ToDBC(this.tbUserBankCardNumber.Text.Trim()).Trim();
                users.ScoringOfSelfBuy = _Convert.StrToDouble(this.tbScoringOfSelfBuy.Text, 0.0);
                users.ScoringOfCommendBuy = _Convert.StrToDouble(this.tbScoringOfCommendBuy.Text, 0.0);
                users.isPrivacy = this.cbPrivacy.Checked;
                users.isCanLogin = this.cbisCanLogin.Checked;
                string returnDescription = "";
                int returnValue = -1;
                if (users.EditByID(ref returnDescription) < 0)
                {
                    JavaScript.Alert(this.Page, returnDescription);
                }
                else
                {
                    if (flag)
                    {
                        if (Procedures.P_UserBankDetailEdit(siteid, userID, bankTypeName, bankName, bankCardNumber, bankInProvinceName, bankInCityName, bankUserName, ref returnValue, ref returnDescription) < 0)
                        {
                            users.Clone(base._User);
                            JavaScript.Alert(this.Page, returnDescription);
                            return;
                        }
                        this.hfBankInProvince.Value = bankInProvinceName;
                        this.hfBankInCity.Value = bankInCityName;
                        this.hfBankTypeName.Value = bankTypeName;
                        this.hfBankName.Value = bankName;
                    }
                    JavaScript.Alert(this.Page, "用户资料已经保存成功。");
                }
            }
        }
    }

    protected void btnUserAccount_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("UserAccountDetail.aspx?SiteID=" + this.tbSiteID.Text + "&ID=" + this.tbUserID.Text);
    }

    protected void EmptyQuestn_Click(object sender, EventArgs e)
    {
        long siteid = _Convert.StrToLong(this.tbSiteID.Text, -1L);
        long num2 = _Convert.StrToLong(this.tbUserID.Text, -1L);
        if ((siteid < 1L) || (num2 < 1L))
        {
            PF.GoError(1, "参数错误", "Admin_UserDetail");
        }
        else
        {
            Users users = new Users(siteid)[siteid, num2];
            if (users.ID < 1L)
            {
                PF.GoError(1, "用户不存在", "Admin_UserDetail");
            }
            else if (new Tables.T_Users { SecurityQuestion = { Value = "" }, SecurityAnswer = { Value = "" } }.Update("ID=" + num2) < 0L)
            {
                JavaScript.Alert(this.Page, "清空安全问题失败");
            }
            else
            {
                JavaScript.Alert(this.Page, "清空安全问题成功");
            }
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

    private void GetEnableCompetence()
    {
        DataTable table = MSSQL.Select("select * from T_UserInGroups  where GroupID =1 and UserID=" + base._User.ID + " ", new MSSQL.Parameter[0]);
        if ((table != null) && (table.Rows.Count > 0))
        {
            this.btnSave.Visible = true;
            this.EmptyQuestn.Visible = true;
            this.btnResetPassword.Visible = true;
        }
        else
        {
            this.btnSave.Visible = false;
            this.EmptyQuestn.Visible = false;
            this.btnResetPassword.Visible = false;
        }
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

    private string GetRandPassword()
    {
        string str = "0123456789";
        string str2 = "";
        Random random = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < 6; i++)
        {
            str2 = str2 + str[random.Next(0, 9)].ToString();
        }
        return str2;
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "MemberManagement", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Admin_UserDetail), this.Page);
        if (!base.IsPostBack)
        {
            this.BindData();
            this.GetEnableCompetence();
        }
    }
}

