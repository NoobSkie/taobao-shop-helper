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

public partial class Hoom_Room_DistillBybank : RoomPageBase, IRequiresSessionState
{
    private void bindBankCard()
    {
        string bankTypeName = "";
        string bankName = "";
        string bankCardNumber = "";
        string bankInProvinceName = "";
        string bankInCityName = "";
        string bankUserName = "";
        int returnValue = 0;
        string returnDescription = "";
        if (Procedures.P_GetUserBankDetail(base._Site.ID, base._User.ID, ref bankTypeName, ref bankName, ref bankCardNumber, ref bankInProvinceName, ref bankInCityName, ref bankUserName, ref returnValue, ref returnDescription) < 0)
        {
            base.Response.Write("<script type='text/javascript'>alert('出错!');</script>");
        }
        else if (returnValue != 0)
        {
            base.Response.Write("<script type='text/javascript'>alert('出错!');</script>");
        }
        else
        {
            if (!_String.Valid.isBankCardNumber(bankCardNumber))
            {
                string str8 = "（需更改绑定银行卡账号，请根据“<a href='BindBankCard.aspx?FromUrl=Distill.aspx?Type=2&IsCps=" + this.HidIsCps.Value + "' target='_parent'><span class='blue12_2'>修改绑定银行卡账号</span></a>”流程处理。）";
                this.labBindState.InnerHtml = str8;
                this.trBankCardRealityName.Visible = false;
                this.trBankName.Visible = false;
            }
            else
            {
                this.lbBankNo.Text = "************" + bankCardNumber.Substring(bankCardNumber.Length - 4, 4);
                this.lbBankCardRealityName.Text = "*".PadLeft(bankUserName.Length - 1, '*') + bankUserName.Substring(bankUserName.Length - 1);
                this.lbBankInProvince.Text = bankInProvinceName;
                this.lbBankInCity.Text = bankInCityName;
                this.lbBankTypeName.Text = bankTypeName;
                this.lbBankName.Text = (bankName.Length <= 4) ? bankName : ("*".PadLeft(bankName.Length - 4, '*') + bankName.Substring(bankName.Length - 4));
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
    }

    private void bindSafeSet()
    {
        this.ddlQuestion.DataSource = DataCache.SecurityQuestions;
        this.ddlQuestion.DataBind();
        if (base._User.SecurityQuestion == "")
        {
            this.trOldAns.Visible = false;
            this.trOldQue.Visible = false;
        }
        else
        {
            this.lbOQuestion.Text = base._User.SecurityQuestion;
            this.trOldAns.Visible = true;
            this.trOldQue.Visible = true;
        }
    }

    private void bindUserInfo()
    {
        if (base._User.RealityName != "")
        {
            this.tbRealityName.Visible = false;
            this.lbRealityName.Visible = true;
            this.lbRealityName.Text = "***";
            this.lbIsRealityNameValided.Text = "已绑定";
        }
        else
        {
            this.tbRealityName.Visible = true;
            this.lbRealityName.Visible = false;
            this.tbRealityName.Text = "";
            this.lbIsRealityNameValided.Text = "未绑定";
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
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            if (base._User.RealityName == "")
            {
                base.Response.Write("<script type='text/javascript'>alert('请完善您的基本资料，真实姓名不能为空，谢谢！');parent.window.location='UserEdit.aspx?FromUrl=Distill.aspx&Type=2&IsCps=" + this.HidIsCps.Value + "'</script>");
            }
            string bankTypeName = "";
            string bankName = "";
            string bankCardNumber = "";
            string bankInProvinceName = "";
            string bankInCityName = "";
            string bankUserName = "";
            int returnValue = 0;
            string returnDescription = "";
            if (Procedures.P_GetUserBankDetail(base._Site.ID, base._User.ID, ref bankTypeName, ref bankName, ref bankCardNumber, ref bankInProvinceName, ref bankInCityName, ref bankUserName, ref returnValue, ref returnDescription) < 0)
            {
                JavaScript.Alert(this.Page, "获取用户绑定分行信息出错");
            }
            else
            {
                if (((string.IsNullOrEmpty(bankTypeName) || string.IsNullOrEmpty(bankName)) || (string.IsNullOrEmpty(bankCardNumber) || string.IsNullOrEmpty(bankInProvinceName))) || (string.IsNullOrEmpty(bankInCityName) || string.IsNullOrEmpty(bankUserName)))
                {
                    base.Response.Write("<script type='text/javascript'>alert('请先绑定您的银行卡帐号,并完善填写相关资料，谢谢！');parent.window.location='BindBankCard.aspx?FromUrl=Distill.aspx&Type=2&IsCps=" + this.HidIsCps.Value + "'</script>");
                }
                if (this.lbQuestion.Text == "")
                {
                    base.Response.Write("<script type='text/javascript'>alert('为了您的账户安全，请先设置安全保护问题，谢谢！');parent.window.location='SafeSet.aspx?FromUrl=Distill.aspx&Type=2&IsCps=" + this.HidIsCps.Value + "';</script>");
                }
                else
                {
                    double num2 = _Convert.StrToDouble(this.lbMoney.Text, 0.0);
                    double num3 = _Convert.StrToDouble(this.tbMoney.Text, 0.0);
                    if ((num3 <= 0.0) || (num3 > num2))
                    {
                        JavaScript.Alert(this.Page, "请输入正确的提款金额， 您的可提金额为：" + num2 + "元。谢谢！");
                    }
                    else if (num3 > 500000.0)
                    {
                        JavaScript.Alert(this.Page, "500000以上的提款请联系客服人员。谢谢！");
                    }
                    else if (this.tbName.Text != base._User.RealityName)
                    {
                        JavaScript.Alert(this.Page, "请检查您的真实姓名是否填写正确，谢谢！");
                    }
                    else if (this.tbMyA.Text.Trim() != base._User.SecurityAnswer)
                    {
                        JavaScript.Alert(this.Page, "安全保护问题回答错误。");
                    }
                    else
                    {
                        this.lblDistillMoney.Text = num3.ToString();
                        this.lblLastMoney.Text = (num2 - num3).ToString();
                        this.pnlFirst.Visible = false;
                        this.pnlNext.Visible = true;
                    }
                }
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            string bankTypeName = "";
            string bankName = "";
            string bankCardNumber = "";
            string bankInProvinceName = "";
            string bankInCityName = "";
            string bankUserName = "";
            int returnValue = 0;
            string returnDescription = "";
            if (Procedures.P_GetUserBankDetail(base._Site.ID, base._User.ID, ref bankTypeName, ref bankName, ref bankCardNumber, ref bankInProvinceName, ref bankInCityName, ref bankUserName, ref returnValue, ref returnDescription) < 0)
            {
                base.Response.Write("<script type='text/javascript'>alert('出错!');</script>");
            }
            else if (returnValue != 0)
            {
                base.Response.Write("<script type='text/javascript'>alert('出错!');</script>");
            }
            else
            {
                string str8 = "";
                double distillMoney = _Convert.StrToDouble(this.lblDistillMoney.Text, 0.0);
                double formalitiesFees = CalculateDistillFormalitiesFees(distillMoney);
                if (formalitiesFees >= distillMoney)
                {
                    JavaScript.Alert(this.Page, "提款失败:所需手续费大于或等于提款金额,实付金额 = 提款金额- 手续费.");
                }
                else
                {
                    bool isCps = false;
                    if (this.HidIsCps.Value == "1")
                    {
                        isCps = true;
                    }
                    if (base._User.Distill(2, distillMoney, formalitiesFees, this.tbName.Text.Trim(), base._User.BankName, base._User.BankCardNumber, "", "", "银行卡提款", isCps, ref str8) < 0)
                    {
                        JavaScript.Alert(this.Page, "申请提款失败。");
                    }
                    else
                    {
                        this.btnOK.Enabled = false;
                        Shove._Web.Cache.ClearCache("Home_Room_DistillDetail_" + base._User.ID.ToString());
                        base.Response.Write("<script type='text/javascript'>alert('申请提款成功。');parent.clickLottery(parent.document.getElementById('PayDistill'));</script>");
                    }
                }
            }
        }
    }

    protected void btnSafeSetNext_Click(object sender, EventArgs e)
    {
        string selectedValue = this.ddlQuestion.SelectedValue;
        if (this.tbOAnswer.Text.Trim() != base._User.SecurityAnswer)
        {
            JavaScript.Alert(this.Page, "原安全问题回答错误");
        }
        else
        {
            if (selectedValue == "自定义问题")
            {
                selectedValue = Utility.FilteSqlInfusion(this.tbMyQuestion.Text.Trim());
                if (selectedValue == "")
                {
                    JavaScript.Alert(this.Page, "请输入安全问题");
                    return;
                }
                selectedValue = "自定义问题|" + selectedValue;
            }
            else
            {
                selectedValue = this.ddlQuestion.SelectedValue;
            }
            string str2 = Utility.FilteSqlInfusion(this.tbAnswer.Text.Trim());
            if (str2 == "")
            {
                JavaScript.Alert(this.Page, "请输入答案");
            }
            else if (new Tables.T_Users { SecurityQuestion = { Value = selectedValue }, SecurityAnswer = { Value = str2 } }.Update("ID=" + base._User.ID.ToString()) < 0L)
            {
                JavaScript.Alert(this.Page, "设置安全问题失败");
            }
            else
            {
                base.Response.Write("<script type='text/javascript'>alert('设置安全问题成功。请注意安全保护问题是最重要的安全凭证，为了您的安全，请牢牢记住您的安全保护问题。');</script>");
                this.ShowOrHiddenPanel(2);
            }
        }
    }

    protected void btnUserEditNext_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            if ((base._User.RealityName == "") && (this.tbRealityName.Text.Trim() == ""))
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
                Users user = new Users(base._Site.ID);
                base._User.Clone(user);
                if (this.tbRealityName.Visible)
                {
                    base._User.RealityName = Utility.FilteSqlInfusion(this.tbRealityName.Text);
                }
                if (this.tbIdIDCardNumber.Visible)
                {
                    base._User.IDCardNumber = Utility.FilteSqlInfusion(this.tbIdIDCardNumber.Text);
                }
                string returnDescription = "";
                if (base._User.EditByID(ref returnDescription) < 0)
                {
                    user.Clone(base._User);
                    JavaScript.Alert(this.Page, returnDescription);
                }
                else
                {
                    if (this.tbRealityName.Visible && this.tbIdIDCardNumber.Visible)
                    {
                        base.Response.Write("<script type='text/javascript'>alert('完善会员资料成功！');</script>");
                    }
                    this.ShowOrHiddenPanel(3);
                }
            }
        }
    }

    protected static double CalculateDistillFormalitiesFees(double DistillMoney)
    {
        double num = 0.0;
        if (DistillMoney < 500.0)
        {
            return 1.0;
        }
        if ((DistillMoney >= 500.0) && (DistillMoney <= 50000.0))
        {
            return 5.0;
        }
        if ((DistillMoney > 50000.0) && (DistillMoney <= 200000.0))
        {
            return 10.0;
        }
        if ((DistillMoney > 200000.0) && (DistillMoney <= 500000.0))
        {
            return 20.0;
        }
        if (DistillMoney > 500000.0)
        {
            num = DistillMoney * 0.01;
        }
        return num;
    }

    protected bool CheckUserBindBank(ref string OutputSystemError)
    {
        string bankTypeName = "";
        string bankName = "";
        string bankCardNumber = "";
        string bankInProvinceName = "";
        string bankInCityName = "";
        string bankUserName = "";
        int returnValue = 0;
        string returnDescription = "";
        if (Procedures.P_GetUserBankDetail(base._Site.ID, base._User.ID, ref bankTypeName, ref bankName, ref bankCardNumber, ref bankInProvinceName, ref bankInCityName, ref bankUserName, ref returnValue, ref returnDescription) < 0)
        {
            OutputSystemError = "获取用户绑定分行信息出错";
            return false;
        }
        if (returnValue != 0)
        {
            OutputSystemError = returnDescription;
            return false;
        }
        if (((string.IsNullOrEmpty(bankTypeName) || string.IsNullOrEmpty(bankName)) || (string.IsNullOrEmpty(bankCardNumber) || string.IsNullOrEmpty(bankInProvinceName))) || (string.IsNullOrEmpty(bankInCityName) || string.IsNullOrEmpty(bankUserName)))
        {
            return false;
        }
        if (!_String.Valid.isBankCardNumber(bankCardNumber))
        {
            return false;
        }
        return true;
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

    private bool IsFirstDistill()
    {
        if (base._User == null)
        {
            return false;
        }
        string text1 = "Room_UserDistills_" + base._User.ID.ToString();
        DataTable table = new Views.V_UserDistills().Open("ID,[DateTime],[Money],FormalitiesFees,Result,Memo", "[UserID] = " + base._User.ID.ToString(), "[DateTime] desc, [ID]");
        if ((table != null) && (table.Rows.Count > 0))
        {
            return false;
        }
        return true;
    }

    protected void lbReturn_Click(object sender, EventArgs e)
    {
        this.ShowOrHiddenPanel(3);
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            string outputSystemError = "";
            if (!this.CheckUserBindBank(ref outputSystemError))
            {
                if (outputSystemError != "")
                {
                    base.Response.Write("<script type='text/javascript'>alert('" + outputSystemError + "');</script>");
                    this.form1.Visible = false;
                }
                else
                {
                    base.Response.Write("<script type='text/javascript'>alert('请完善您的绑定银行卡资料，谢谢！');parent.window.location='BindBankCard.aspx'</script>");
                }
            }
            else if (base._User != null)
            {
                this.HidIsCps.Value = Utility.GetRequest("IsCps");
                if (string.IsNullOrEmpty(this.HidIsCps.Value))
                {
                    this.HidIsCps.Value = "0";
                }
                if (this.HidIsCps.Value == "1")
                {
                    DataTable table = MSSQL.Select("select BonusAllow from T_Users where ID = " + base._User.ID.ToString(), new MSSQL.Parameter[0]);
                    if ((table == null) || (table.Rows.Count == 0))
                    {
                        return;
                    }
                    this.lbMoney.Text = table.Rows[0]["BonusAllow"].ToString();
                }
                else
                {
                    this.lbMoney.Text = base._User.Balance.ToString();
                }
                if (Utility.GetRequest("Step") == "3")
                {
                    this.ShowOrHiddenPanel(3);
                }
                else if (this.IsFirstDistill())
                {
                    this.ShowOrHiddenPanel(1);
                }
                else
                {
                    this.ShowOrHiddenPanel(3);
                }
            }
        }
    }

    private void ShowOrHiddenPanel(int step)
    {
        switch (step)
        {
            case 1:
                this.pnlSafeSet.Visible = true;
                this.pnlUserEdit.Visible = false;
                this.pnlFirst.Visible = false;
                this.pnlNext.Visible = false;
                this.bindSafeSet();
                return;

            case 2:
                this.pnlSafeSet.Visible = false;
                this.pnlUserEdit.Visible = true;
                this.pnlFirst.Visible = false;
                this.pnlNext.Visible = false;
                this.bindUserInfo();
                return;

            case 3:
                this.pnlSafeSet.Visible = false;
                this.pnlUserEdit.Visible = false;
                this.pnlFirst.Visible = true;
                this.pnlNext.Visible = false;
                this.bindBankCard();
                return;

            case 4:
                this.pnlSafeSet.Visible = false;
                this.pnlUserEdit.Visible = false;
                this.pnlFirst.Visible = false;
                this.pnlNext.Visible = true;
                return;
        }
    }
}

