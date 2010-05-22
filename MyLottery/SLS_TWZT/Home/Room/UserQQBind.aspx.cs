using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_UserQQBind : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.lbName.Text = base._User.Name;
        this.labName.Text = base._User.Name;
        DataTable table = new Tables.T_Users().Open("IsQQValided", "ID=" + base._User.ID.ToString(), "");
        if ((table != null) && (table.Rows.Count != 0))
        {
            if (_Convert.StrToBool(table.Rows[0]["IsQQValided"].ToString(), false))
            {
                this.labQQ.Text = (base._User.QQ.Length > 3) ? (base._User.QQ.Substring(0, 3) + "********") : base._User.QQ;
                this.lbStatus.Text = "您已经绑定";
            }
            else
            {
                this.labBindState.Text = "(未绑定)";
                this.lbStatus.Text = "您一旦绑定";
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

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            if (base._User.RealityName == "")
            {
                base.Response.Write("<script type='text/javascript'>alert('请完善您的基本资料，真实姓名不能为空，谢谢！');window.location='UserEdit.aspx?FromUrl=UserQQBind.aspx';</script>");
            }
            if (this.lbQuestion.Text == "")
            {
                base.Response.Write("<script type='text/javascript'>alert('为了您的账户安全，请先设置安全保护问题，谢谢！');window.location='SafeSet.aspx?FromUrl=UserQQBind.aspx';</script>");
            }
            if (this.tbRealityName.Text != base._User.RealityName)
            {
                JavaScript.Alert(this.Page, "请核实您的真实姓名，谢谢！");
            }
            else if (this.tbMyA.Text.Trim() != base._User.SecurityAnswer)
            {
                JavaScript.Alert(this.Page, "安全保护问题回答错误。");
            }
            else
            {
                Shove._Web.Cache.SetCache("UserQQBind_" + base._User.ID.ToString(), base._User.ID.ToString());
                base.Response.Redirect("TencentLogin.aspx");
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

