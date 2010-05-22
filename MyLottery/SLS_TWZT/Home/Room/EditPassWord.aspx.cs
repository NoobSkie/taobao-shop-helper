using ASP;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_EditPassWord : RoomPageBase, IRequiresSessionState
{
    private void BindData()
    {
        this.tbName.Text = base._User.Name;
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
        if (this.lbQuestion.Text == "")
        {
            base.Response.Write("<script type='text/javascript'>alert('为了您的账户安全，请先设置安全保护问题，谢谢！');window.location='SafeSet.aspx?FromUrl=EditPassWord.aspx';</script>");
        }
        else if (this.tbOldPassWord.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入密码。");
        }
        else if (this.tbNewPassWord.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入新密码。");
        }
        else if (PF.EncryptPassword(this.tbOldPassWord.Text.Trim()) != base._User.Password)
        {
            JavaScript.Alert(this.Page, "密码有误，请重新输入。");
        }
        else if (this.tbRePassWord.Text.Trim() != this.tbNewPassWord.Text.Trim())
        {
            JavaScript.Alert(this.Page, "两次输入的密码不相同。");
        }
        else if (this.tbMyA.Text.Trim() != base._User.SecurityAnswer)
        {
            JavaScript.Alert(this.Page, "安全保护问题回答错误。");
        }
        else
        {
            Users user = new Users(base._Site.ID);
            base._User.Clone(user);
            base._User.Name = this.tbName.Text.Trim();
            base._User.Password = this.tbNewPassWord.Text.Trim();
            string returnDescription = "";
            if (base._User.EditByID(ref returnDescription) < 0)
            {
                user.Clone(base._User);
                new Log("Users").Write("会员修改密码失败：" + returnDescription);
                JavaScript.Alert(this.Page, returnDescription);
            }
            else
            {
                string request = Utility.GetRequest("FromUrl");
                if (request == "")
                {
                    request = "EditPassWord.aspx";
                }
                JavaScript.Alert(this.Page, "用户密码已经保存成功。", request);
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
        }
    }
}

