using ASP;
using DAL;
using Shove;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ElectronTicketLog : AdminPageBase, IRequiresSessionState
{


    protected void btnOK_Click(object sender, EventArgs e)
    {
        DateTime time3 = _Convert.StrToDateTime(this.tbFrom.Text, DateTime.Now.Date.ToString());
        DateTime time7 = _Convert.StrToDateTime(this.tbTo.Text, DateTime.Now.AddDays(1.0).Date.ToString());
        DataTable table = new Tables.T_ElectronTicketLog().Open("[ID], TransType, [datetime], Send", "[datetime] between '" + time3.ToString() + "' and '" + time7.ToString() + "'", "send, [datetime] desc");
        this.dlList.DataSource = table;
        this.dlList.DataBind();
    }

    protected void dlList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "btnLook")
        {
            HtmlInputHidden hidden = (HtmlInputHidden)e.Item.FindControl("tbID");
            if (hidden == null)
            {
                this.tbDetail.Text = "读 Log 数据异常 1。";
            }
            else
            {
                long num = _Convert.StrToLong(hidden.Value, -1L);
                if (num < 0L)
                {
                    this.tbDetail.Text = "读 Log 数据异常 2。";
                }
                else
                {
                    DataTable table = new Tables.T_ElectronTicketLog().Open("TransMessage", "[ID] = " + num.ToString(), "");
                    if ((table == null) || (table.Rows.Count < 1))
                    {
                        this.tbDetail.Text = "读 Log 数据异常 3。";
                    }
                    else
                    {
                        this.tbDetail.Text = table.Rows[0]["TransMessage"].ToString();
                    }
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Administrator", "Options" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

}

