using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Agent_ElectronTicket_Scheme : ElectronTicketAgentsPageBase, IRequiresSessionState
{

    private void BindData(long SchemeID)
    {
        DataTable table = new Tables.T_ElectronTicketAgentSchemes().Open("SchemeNumber, DateTime, Amount, LotteryNumber, Multiple, state", " ID =" + SchemeID.ToString(), "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            PF.GoError(1, "参数错误", "Agent_ElectronTicket_Scheme");
        }
        else
        {
            table.Rows[0]["LotteryNumber"].ToString();
            this.lbSchemeNumber.Text = table.Rows[0]["SchemeNumber"].ToString();
            this.lbDateTime.Text = table.Rows[0]["DateTime"].ToString();
            this.lbAmount.Text = table.Rows[0]["Amount"].ToString();
            this.lbMultiple.Text = table.Rows[0]["Multiple"].ToString();
            string str = table.Rows[0]["state"].ToString();
            this.lbState.Text = "失败";
            if (str == "1")
            {
                this.lbState.Text = "成功";
            }
            DataTable table2 = new Tables.T_ElectronTicketAgentSchemesElectronTickets().Open("Ticket, identifiers", " SchemeID=" + SchemeID.ToString(), "");
            if ((table2 == null) || (table2.Rows.Count < 1))
            {
                table2 = new Tables.T_ElectronTicketAgentSchemesElectronTickets().Open("Ticket, identifiers", " SchemeID=" + SchemeID.ToString(), "");
                if ((table2 == null) || (table2.Rows.Count < 1))
                {
                    return;
                }
            }
            table2.Columns.Add("count", typeof(string));
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                table2.Rows[i]["count"] = (i + 1).ToString();
                table2.AcceptChanges();
            }
            this.RpElectronTicket.DataSource = table2;
            this.RpElectronTicket.DataBind();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isAtFramePageLogin = true;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            long schemeID = _Convert.StrToLong(Utility.GetRequest("id"), -1L);
            if (schemeID < 1L)
            {
                PF.GoError(1, "参数错误", "Agent_ElectronTicket_Scheme");
            }
            else
            {
                this.BindData(schemeID);
            }
        }
    }


}

