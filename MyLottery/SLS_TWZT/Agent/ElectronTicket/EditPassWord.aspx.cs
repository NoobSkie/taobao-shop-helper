using ASP;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Agent_ElectronTicket_EditPassWord : ElectronTicketAgentsPageBase, IRequiresSessionState
{


    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.tbOldPassWord.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入密码。");
        }
        else if (this.tbNewPassWord.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入新密码。");
        }
        else if (PF.EncryptPassword(this.tbOldPassWord.Text.Trim()) != base._ElectronTicketAgents.Password)
        {
            JavaScript.Alert(this.Page, "密码有误，请重新输入。");
        }
        else if (this.tbRePassWord.Text.Trim() != this.tbNewPassWord.Text.Trim())
        {
            JavaScript.Alert(this.Page, "两次输入的密码不相同。");
        }
        else
        {
            ElectronTicketAgents electronTicketAgents = new ElectronTicketAgents();
            base._ElectronTicketAgents.Clone(electronTicketAgents);
            base._ElectronTicketAgents.Password = PF.EncryptPassword(this.tbNewPassWord.Text.Trim());
            string returnDescription = "";
            if (base._ElectronTicketAgents.EditByID(ref returnDescription) < 0)
            {
                electronTicketAgents.Clone(base._ElectronTicketAgents);
                JavaScript.Alert(this.Page, returnDescription);
            }
            else
            {
                JavaScript.Alert(this.Page, "用户密码已经保存成功。");
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
    }

}

