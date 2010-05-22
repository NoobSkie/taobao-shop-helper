using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_UserEdit : RoomPageBase, IRequiresSessionState
{
    private void BindData()
    {
        this.lbUserName.Text = "*".PadLeft(base._User.Name.Length - 1, '*') + base._User.Name.Substring(base._User.Name.Length - 1);
        if (base._User.RealityName != "")
        {
            this.tbRealityName.Visible = false;
            this.lbRealityName.Visible = true;
            this.lbRealityName.Text = "*".PadLeft(base._User.RealityName.Length - 1, '*') + base._User.RealityName.Substring(base._User.RealityName.Length - 1);
            this.lbIsRealityNameValided.Text = "已绑定";
        }
        else
        {
            this.tbRealityName.Visible = true;
            this.lbRealityName.Visible = false;
            this.tbRealityName.Text = "***";
            this.lbIsRealityNameValided.Text = "未绑定";
        }
        this.ddlCity.City_id = base._User.CityID;
        this.rbSexM.Checked = base._User.Sex == "男";
        this.rbSexW.Checked = base._User.Sex != "男";
        this.tbBirthday.Text = base._User.BirthDay.ToShortDateString();
        this.tbAddress.Text = base._User.Address;
        this.tbEmail.Text = base._User.Email;
        try
        {
            if (base._User.isMobileValided)
            {
                this.lbMobile.Text = base._User.Mobile.Substring(0, 3) + "*****" + base._User.Mobile.Substring(8, 3);
            }
        }
        catch
        {
        }
        DataTable table = new Tables.T_Users().Open("IsQQValided", "ID=" + base._User.ID.ToString(), "");
        if ((table != null) && (table.Rows.Count != 0))
        {
            bool flag = _Convert.StrToBool(table.Rows[0]["IsQQValided"].ToString(), false);
            if (flag)
            {
                this.lbQQ.Text = (base._User.QQ.Length > 3) ? (base._User.QQ.Substring(0, 3) + "********") : base._User.QQ;
            }
            this.lbIsEmailValided.Text = (base._User.isEmailValided ? "<font color='red'>已激活</font>" : "未激活") + "&nbsp;&nbsp;<a href='UserEmailBind.aspx'>申请激活或修改激活</a>";
            this.labIsMobileVailded.Text = (base._User.isMobileValided ? "<font color='red'>已绑定</font>" : "未绑定") + "&nbsp;&nbsp;<a href='UserMobileBind.aspx'>申请绑定或修改绑定</a>";
            this.lbQQValided.Text = (flag ? "<font color='red'>已绑定</font>" : "未绑定") + "&nbsp;&nbsp;<a href='UserQQBind.aspx'>申请绑定或修改绑定</a>";
            table = new Tables.T_Banks().Open("", "", "[Order]");
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
            try
            {
                if (base._User.IDCardNumber.Length == 15)
                {
                    this.lbIdCardNumber.Visible = true;
                    this.tbIdIDCardNumber.Visible = false;
                    this.lbIdCardNumber.Text = base._User.IDCardNumber.Substring(0, 6) + "*****" + base._User.IDCardNumber.Substring(10, 4);
                    this.lbIsIdCardNumberValided.Text = "已绑定";
                }
                else
                {
                    this.lbIdCardNumber.Visible = true;
                    this.tbIdIDCardNumber.Visible = false;
                    this.lbIdCardNumber.Text = base._User.IDCardNumber.Substring(0, 6) + "********" + base._User.IDCardNumber.Substring(14, 4);
                    this.lbIsIdCardNumberValided.Text = "已绑定";
                }
            }
            catch
            {
                this.lbIdCardNumber.Visible = false;
                this.tbIdIDCardNumber.Visible = true;
                this.lbIdCardNumber.Text = "";
                this.lbIsIdCardNumberValided.Text = "未绑定";
            }
            this.hdIDCardNumber.Value = this.lbIdCardNumber.Text;
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            if (this.lbQuestion.Visible && (this.lbQuestion.Text == ""))
            {
                base.Response.Write("<script type='text/javascript'>alert('为了您的账户安全，请先设置安全保护问题，谢谢！');window.location='SafeSet.aspx?FromUrl=UserEdit.aspx';</script>");
            }
            else if ((base._User.RealityName == "") && (this.tbRealityName.Text.Trim() == ""))
            {
                JavaScript.Alert(this.Page, "请输入真实姓名。");
            }
            else
            {
                if (this.tbIdIDCardNumber.Visible)
                {
                    string text = this.tbIdIDCardNumber.Text;
                    if (((!_String.Valid.isIDCardNumber(text) && !_String.Valid.isIDCardNumber_Hongkong(text)) && (!_String.Valid.isIDCardNumber_Macau(text) && !_String.Valid.isIDCardNumber_Singapore(text))) && !_String.Valid.isIDCardNumber_Taiwan(text))
                    {
                        JavaScript.Alert(this.Page, "身份证号码输入有误！");
                        return;
                    }
                }
                if (this.tbEmail.Text.Trim() == "")
                {
                    JavaScript.Alert(this.Page, "请输入电子邮件地址。");
                    this.tbEmail.Focus();
                }
                else if (!_String.Valid.isEmail(this.tbEmail.Text.Trim()))
                {
                    JavaScript.Alert(this.Page, "电子邮件地址格式不正确。");
                    this.tbEmail.Focus();
                }
                else if (this.tbMyA.Text.Trim() != base._User.SecurityAnswer)
                {
                    JavaScript.Alert(this.Page, "安全保护问题回答错误。");
                }
                else if (this.divNewQF.Visible && (Shove._Web.Utility.FilteSqlInfusion(this.tbAnswer.Text).Trim() == ""))
                {
                    JavaScript.Alert(this.Page, "请输入安全问题，谢谢！");
                }
                else
                {
                    Users user = new Users(base._Site.ID);
                    base._User.Clone(user);
                    if (this.tbRealityName.Visible)
                    {
                        base._User.RealityName = Shove._Web.Utility.FilteSqlInfusion(this.tbRealityName.Text);
                    }
                    if (this.divNewQF.Visible)
                    {
                        base._User.SecurityQuestion = this.ddlQuestion.SelectedItem.Text.ToString().Trim();
                        base._User.SecurityAnswer = this.tbAnswer.Text.Trim();
                        if (MSSQL.ExecuteNonQuery("update T_Users set SecurityQuestion='" + this.ddlQuestion.SelectedItem.Text.ToString().Trim() + "' , SecurityAnswer='" + Shove._Web.Utility.FilteSqlInfusion(this.tbAnswer.Text.Trim()) + "' where ID=" + base._User.ID.ToString(), new MSSQL.Parameter[0]) == 0)
                        {
                            return;
                        }
                    }
                    if (this.tbIdIDCardNumber.Visible)
                    {
                        base._User.IDCardNumber = Shove._Web.Utility.FilteSqlInfusion(this.tbIdIDCardNumber.Text);
                        if (((this.tbIdIDCardNumber.Text.Trim() != "") && (MSSQL.ExecuteScalar("select 1 from T_Users where IDCardNumber='" + Shove._Web.Utility.FilteSqlInfusion(this.tbIdIDCardNumber.Text) + "' and CpsID=839 ", new MSSQL.Parameter[0]) != null)) && (base._User.CpsID != 0x347L))
                        {
                            base._User.CpsID = 0x347L;
                        }
                    }
                    base._User.CityID = this.ddlCity.City_id;
                    base._User.Sex = this.rbSexM.Checked ? "男" : (this.rbSexW.Checked ? "女" : "");
                    base._User.BirthDay = _Convert.StrToDateTime(this.tbBirthday.Text.Trim(), "1980-1-1");
                    base._User.Address = this.tbAddress.Text.Trim();
                    if (base._User.Email != _Convert.ToDBC(this.tbEmail.Text).Trim())
                    {
                        base._User.isEmailValided = false;
                    }
                    base._User.Email = _Convert.ToDBC(this.tbEmail.Text).Trim();
                    string returnDescription = "";
                    if (base._User.EditByID(ref returnDescription) < 0)
                    {
                        new Log("Users").Write("修改用户基本资料失败：" + returnDescription);
                        user.Clone(base._User);
                        JavaScript.Alert(this.Page, returnDescription);
                    }
                    else
                    {
                        string request = Shove._Web.Utility.GetRequest("FromUrl");
                        if (request == "")
                        {
                            request = "UserEdit.aspx";
                        }
                        JavaScript.Alert(this.Page, "用户资料已经保存成功。", request);
                    }
                }
            }
        }
    }

    private int CheckUserName(string name)
    {
        if (!PF.CheckUserName(name))
        {
            return -1;
        }
        DataTable table = new Tables.T_Users().Open("ID", "Name = '" + Shove._Web.Utility.FilteSqlInfusion(name) + "'", "");
        if ((table != null) && (table.Rows.Count > 0))
        {
            return -2;
        }
        if ((_String.GetLength(name) >= 5) && (_String.GetLength(name) <= 0x10))
        {
            return 0;
        }
        return -3;
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public int CheckUserNameAjax(string name)
    {
        if (!PF.CheckUserName(name))
        {
            return -1;
        }
        DataTable table = new Tables.T_Users().Open("ID", "Name = '" + Shove._Web.Utility.FilteSqlInfusion(name) + "'", "");
        if ((table != null) && (table.Rows.Count > 0))
        {
            return -2;
        }
        if ((_String.GetLength(name) >= 5) && (_String.GetLength(name) <= 0x10))
        {
            return 0;
        }
        return -3;
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

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_UserEdit), this.Page);
        if (!base.IsPostBack)
        {
            if (base.User != null)
            {
                if (base._User.SecurityQuestion == "")
                {
                    this.divNewQF.Visible = true;
                    this.divAnswer.Visible = false;
                }
                else
                {
                    this.divNewQF.Visible = false;
                    this.divAnswer.Visible = true;
                }
            }
            this.BindData();
            this.ddlQuestion.DataSource = DataCache.SecurityQuestions;
            this.ddlQuestion.DataBind();
        }
    }
}

