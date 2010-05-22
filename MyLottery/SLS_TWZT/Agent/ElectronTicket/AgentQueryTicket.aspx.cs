using ASP;
using DAL;
using Shove;
using Shove._Web;
using SLS;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Agent_ElectronTicket_AgentQueryTicket : ElectronTicketAgentsPageBase, IRequiresSessionState
{

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        DataTable table = new Views.V_ElectronTicketAgentSchemesElectronTickets().Open("LotteryID, IsuseID, PlayTypeID, Ticket, SchemeNumber, WinLotteryNumber, DateTime, Money, Multiple", "Identifiers='" + this.tbTicket.Text.Trim() + "'", "");
        if (table == null)
        {
            JavaScript.Alert(this.Page, "数据库读写错误！");
        }
        else if (table.Rows.Count < 1)
        {
            JavaScript.Alert(this.Page, "没有找到此票标识！");
        }
        else
        {
            DataTable table2 = new Tables.T_WinTypes().Open("", "LotteryID=" + table.Rows[0]["LotteryID"].ToString(), "");
            if ((table2 == null) || (table2.Rows.Count < 1))
            {
                JavaScript.Alert(this.Page, "数据库读写错误！");
            }
            else
            {
                double[] winMoneyList = new double[table2.Rows.Count * 2];
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    winMoneyList[i * 2] = _Convert.StrToDouble(table2.Rows[i]["defaultMoney"].ToString(), 0.0);
                    winMoneyList[(i * 2) + 1] = _Convert.StrToDouble(table2.Rows[i]["DefaultMoneyNoWithTax"].ToString(), 0.0);
                    if (winMoneyList[i * 2] < 0.0)
                    {
                        JavaScript.Alert(this.Page, "数据库读写错误！");
                        return;
                    }
                    if (winMoneyList[i * 2] < winMoneyList[(i * 2) + 1])
                    {
                        JavaScript.Alert(this.Page, "数据库读写错误！");
                        return;
                    }
                }
                string number = table.Rows[0]["Ticket"].ToString();
                string ticketNumber = "";
                int num2 = _Convert.StrToInt(table.Rows[0]["LotteryID"].ToString(), 0);
                int playTypeID = _Convert.StrToInt(table.Rows[0]["PlayTypeID"].ToString(), 0);
                string winNumber = table.Rows[0]["WinLotteryNumber"].ToString();
                try
                {
                    new Lottery()[num2].HPSH_ToElectronicTicket(playTypeID, number, ref ticketNumber, ref playTypeID);
                }
                catch
                {
                }
                string description = "";
                double winMoneyNoWithTax = 0.0;
                double num5 = 0.0;
                try
                {
                    num5 = new Lottery()[num2].ComputeWin(ticketNumber, winNumber, ref description, ref winMoneyNoWithTax, playTypeID, winMoneyList);
                }
                catch
                {
                }
                this.lbDescription.Text = "";
                if (!string.IsNullOrEmpty(description.Trim()))
                {
                    this.lbDescription.Text = description;
                }
                this.lbSchemeNumber.Text = table.Rows[0]["SchemeNumber"].ToString();
                this.lbDateTime.Text = table.Rows[0]["DateTime"].ToString();
                this.lbAmount.Text = table.Rows[0]["Money"].ToString();
                this.lbMultiple.Text = table.Rows[0]["Multiple"].ToString();
                if (num5 > 0.0)
                {
                    this.lbWinMoney.Text = num5.ToString();
                }
                else
                {
                    this.lbWinMoney.Text = "<color='red'>" + num5 + "</color>";
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.div_Ticket.Visible = this.tbTicket.Text.Trim() != "";
    }

}

