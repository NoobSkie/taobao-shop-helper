using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_SafeSet : RoomPageBase, IRequiresSessionState
{
    private string key = "";

    private void BindData()
    {
        this.tbName.Text = base._User.Name;
        string request = Utility.GetRequest("FromUrl");
        this.hdFromUrl.Value = request;
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

    protected void btnGoEmail_Click(object sender, EventArgs e)
    {
        string input = Utility.FilteSqlInfusion(this.tbPassWord.Text.ToString());
        string email = base._User.Email;
        string str3 = Utility.FilteSqlInfusion(this.tbRealityName.Text.ToString());
        string securityQuestion = base._User.SecurityQuestion;
        string securityAnswer = base._User.SecurityAnswer;
        string name = base._User.Name;
        int num = 0;
        if (str3 == "")
        {
            JavaScript.Alert(this.Page, "请输入真实姓名。");
        }
        else if (str3 != base._User.RealityName)
        {
            JavaScript.Alert(this.Page, "真实姓名输入有误,请核实。");
        }
        else if (input == "")
        {
            JavaScript.Alert(this.Page, "请输入密码。");
        }
        else if (PF.EncryptPassword(input) != base._User.Password)
        {
            JavaScript.Alert(this.Page, "您输入的密码有误,请核实。");
        }
        else if ((securityQuestion == "") || (securityAnswer == ""))
        {
            JavaScript.Alert(this.Page, "您还未设置安全问题,无需重置。");
        }
        else
        {
            DataTable table = new Tables.T_UserEditQuestionAnswer().Open("", "UserID=" + base._User.ID, "");
            Tables.T_UserEditQuestionAnswer answer = new Tables.T_UserEditQuestionAnswer();
            string tip = "";
            if (table.Rows.Count > 0)
            {
                if (_Convert.StrToDateTime(table.Rows[0]["DateTime"].ToString(), "0000-00-00").ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"))
                {
                    if (table.Rows[0]["ValidedCount"].ToString() == "2")
                    {
                        JavaScript.Alert(this.Page, "您今天已重置两次安全问题了,请明天再来吧", "AccountDetail.aspx");
                        return;
                    }
                    num = _Convert.StrToInt(table.Rows[0]["ValidedCount"].ToString(), 1) + 1;
                }
                else
                {
                    num = 1;
                }
                answer.ValidedCount.Value = num;
                answer.QuestionAnswerState.Value = 0;
                if (answer.Update("UserID=" + base._User.ID) < 0L)
                {
                    PF.GoError(-1, tip, base.GetType().FullName);
                    return;
                }
            }
            else
            {
                answer.UserID.Value = base._User.ID;
                answer.QuestionAnswerState.Value = 0;
                answer.ValidedCount.Value = 1;
                if (answer.Insert() < 0L)
                {
                    PF.GoError(-1, tip, base.GetType().FullName);
                    return;
                }
            }
            string s = Encrypt.EncryptString(PF.GetCallCert(), string.Concat(new object[] { base._User.ID.ToString(), ",", DateTime.Now.ToString(), ",", securityQuestion, ",", securityAnswer, ",", name, ",", answer.QuestionAnswerState.Value }));
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            string str9 = BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "");
            s = str9.Substring(0, 0x10) + s + str9.Substring(0x10, 0x10);
            string str10 = Utility.GetUrl() + "/Home/Room/SafeSet.aspx?Qkey=" + s;
            StringBuilder builder = new StringBuilder();
            builder.Append("<div style='font-weight:bold;'>尊敬的" + base._Site.Name + "客户(").Append(base._User.Name).Append("):</div>").Append("<div>您好!</div>").Append("<div>系统已收到您的安全问题重置，请点击链接<a href='").Append(str10).Append("' target='_top'>").Append(str10).Append("</a>校验您的身份。</div>").Append("<div>为了您的安全，该邮件通知地址将在 24 小时后失效，谢谢合作。</div>").Append("<div>此邮件由系统发出，请勿直接回复!</div>").Append("<div>上海福彩投诉电话：021-64175077</div>").Append("<div>意见收集与提交：BD@handtouchworld.com</div>").Append("<div>").Append(Utility.GetUrlWithoutHttp()).Append(" 版权所有(C) 2008-2009</div>");
            if (PF.SendEmail(base._Site, email, "安全问题找回", builder.ToString()) == 0)
            {
                this.tbPassWord.Enabled = false;
                this.tbRealityName.Enabled = false;
                this.btnGoEmail.Enabled = false;
                this.lblTips.Text = "&nbsp;&nbsp;&nbsp;&nbsp;您好，系统已经发送一封验证邮件您的邮箱，请到您的信箱确认。";
            }
            else
            {
                new Log("System").Write(base.GetType().FullName + "发送邮件失败");
            }
        }
    }

    protected void btnGoReset_Click(object sender, EventArgs e)
    {
        if (!base._User.isEmailValided)
        {
            JavaScript.Alert(this.Page, "您还绑定邮箱,请绑定后在进行安全问题的重置。", "UserEmailBind.aspx");
        }
        else
        {
            this.ShowGoEmail();
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string selectedValue = this.ddlQuestion.SelectedValue;
        if (this.trOldQue.Visible && (this.tbOAnswer.Text.Trim() != base._User.SecurityAnswer))
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
                Tables.T_UserEditQuestionAnswer answer = new Tables.T_UserEditQuestionAnswer();
                string tip = "";
                answer.QuestionAnswerState.Value = 1;
                if (answer.Update("UserID=" + base._User.ID) < 0L)
                {
                    PF.GoError(-1, tip, base.GetType().FullName);
                }
                else
                {
                    base.Response.Write("<script type='text/javascript'>alert('设置安全问题成功。请注意安全保护问题是最重要的安全凭证，为了您的安全，请牢牢记住您的安全保护问题。');window.location='" + this.hdFromUrl.Value + "'</script>");
                    base.Response.End();
                }
            }
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        if (!this.btnGoEmail.Enabled)
        {
            base.Response.Redirect("AccountDetail.aspx");
        }
        this.ShowEditQF();
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

    private void GetUserQuestionAnswer()
    {
        Thread.Sleep(500);
        if ((this.key == "") || (this.key.Length <= 0x20))
        {
            JavaScript.Alert(this.Page, "链接地址不合法,请核实.", "AccountDetail.aspx");
        }
        else
        {
            string str = this.key.Substring(0, 0x10) + this.key.Substring(this.key.Length - 0x10, 0x10);
            this.key = this.key.Substring(0x10, this.key.Length - 0x20);
            try
            {
                if (str != BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(this.key))).Replace("-", ""))
                {
                    JavaScript.Alert(this.Page, "链接地址不合法,请核实", "AccountDetail.aspx");
                }
                else
                {
                    this.key = Encrypt.UnEncryptString(PF.GetCallCert(), this.key);
                    long num = -1L;
                    DateTime time2 = DateTime.Now.AddYears(-1);
                    string str2 = "";
                    int num2 = 1;
                    try
                    {
                        num = _Convert.StrToLong(this.key.Split(new char[] { ',' })[0], 0L);
                        time2 = Convert.ToDateTime(this.key.Split(new char[] { ',' })[1]);
                        string text1 = this.key.Split(new char[] { ',' })[2];
                        string text2 = this.key.Split(new char[] { ',' })[3];
                        str2 = this.key.Split(new char[] { ',' })[4];
                        num2 = _Convert.StrToInt(this.key.Split(new char[] { ',' })[5], 1);
                    }
                    catch
                    {
                    }
                    if ((num != base._User.ID) || (str2 != base._User.Name))
                    {
                        JavaScript.Alert(this.Page, "登陆账号与所申请的账号不一致,请核实.", "../../UserLogin.aspx");
                    }
                    else if (num2 != 0)
                    {
                        JavaScript.Alert(this.Page, "该地址已过期.", "AccountDetail.aspx");
                    }
                    else
                    {
                        DataTable table = new Tables.T_UserEditQuestionAnswer().Open("QuestionAnswerState", "UserID = " + base._User.ID, "");
                        if (table.Rows.Count == 0)
                        {
                            JavaScript.Alert(this.Page, "该地址已过期.", "AccountDetail.aspx");
                        }
                        else if (table.Rows[0][0].ToString() != "0")
                        {
                            JavaScript.Alert(this.Page, "该地址已过期.", "AccountDetail.aspx");
                        }
                        else if (time2.AddDays(1.0).CompareTo(DateTime.Now) < 0)
                        {
                            JavaScript.Alert(this.Page, "该地址已过期.", "AccountDetail.aspx");
                        }
                        else if (num <= 0L)
                        {
                            JavaScript.Alert(this.Page, "非法访问", "../../UserLogin.aspx");
                        }
                        else
                        {
                            this.ShowEditQF2();
                        }
                    }
                }
            }
            catch
            {
                JavaScript.Alert(this.Page, "非法访问。", "../../UserLogin.aspx");
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.ddlQuestion.DataSource = DataCache.SecurityQuestions;
            this.ddlQuestion.DataBind();
            this.ShowEditQF();
            this.key = Utility.GetRequest("Qkey").Trim();
            if (this.key != "")
            {
                this.GetUserQuestionAnswer();
            }
        }
    }

    private void ShowEditQF()
    {
        this.tbOldQF.Visible = true;
        this.tbNewQF.Visible = true;
        this.Panel1.Visible = true;
        this.Panel2.Visible = false;
        this.tbUserRName.Visible = false;
    }

    private void ShowEditQF2()
    {
        this.trOldQue.Visible = false;
        this.tbOldQF.Visible = false;
        this.tbNewQF.Visible = true;
        this.Panel1.Visible = true;
        this.Panel2.Visible = false;
        this.tbUserRName.Visible = false;
    }

    private void ShowGoEmail()
    {
        this.tbOldQF.Visible = false;
        this.tbNewQF.Visible = false;
        this.Panel1.Visible = false;
        this.Panel2.Visible = true;
        this.tbUserRName.Visible = true;
    }
}

