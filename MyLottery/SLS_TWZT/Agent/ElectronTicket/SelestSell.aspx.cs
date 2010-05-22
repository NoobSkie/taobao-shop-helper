using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Agent_ElectronTicket_SelestSell : ElectronTicketAgentsPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.lbElectronTicketID.Text = base._ElectronTicketAgents.ID.ToString();
        this.lbName.Text = base._ElectronTicketAgents.Name;
        this.lbState.Text = "暂未开通";
        if (base._ElectronTicketAgents.State == 1)
        {
            this.lbState.Text = "开通";
        }
        this.lbBalance.Text = base._ElectronTicketAgents.Balance.ToString("N");
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

