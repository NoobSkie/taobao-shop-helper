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

public partial class Agent_ElectronTicket_AgentQueryBet : ElectronTicketAgentsPageBase, IRequiresSessionState
{

    private void BindData()
    {
        string condition = "1=1";
        if (!string.IsNullOrEmpty(this.tbIsuseName.Text.Trim()))
        {
            condition = condition + " and  IsuseName= '" + Utility.FilteSqlInfusion(this.tbIsuseName.Text.Trim()) + "'";
        }
        if (int.Parse(this.ddlLottery.SelectedItem.Value) > 0)
        {
            condition = condition + " and LotteryID= " + this.ddlLottery.SelectedItem.Value;
        }
        if (int.Parse(this.ddlState.SelectedItem.Value) > 0)
        {
            if (int.Parse(this.ddlState.SelectedItem.Value) == 2)
            {
                condition = condition + " and state > 1";
            }
            else
            {
                condition = condition + " and state = 1";
            }
        }
        if (!string.IsNullOrEmpty(this.tbStartTime.Text.Trim()))
        {
            DateTime.Parse("1981-01-01");
            try
            {
                DateTime.Parse(this.tbStartTime.Text.Trim());
            }
            catch
            {
                JavaScript.Alert(this.Page, "时间格式填写有错误！");
                return;
            }
            condition = condition + " and DateTime > '" + this.tbStartTime.Text.Trim() + "'";
        }
        if (!string.IsNullOrEmpty(this.tbEndTime.Text.Trim()))
        {
            DateTime.Parse("1981-01-01");
            try
            {
                DateTime.Parse(this.tbEndTime.Text.Trim());
            }
            catch
            {
                JavaScript.Alert(this.Page, "时间格式填写有错误！");
                return;
            }
            condition = condition + " and DateTime < '" + this.tbEndTime.Text.Trim() + "'";
        }
        if (!string.IsNullOrEmpty(this.tbSchemeNumber.Text.Trim()))
        {
            condition = "SchemeNumber= '" + Utility.FilteSqlInfusion(this.tbSchemeNumber.Text.Trim()) + "'";
        }
        DataTable dt = new Views.V_ElectronTicketAgentSchemes().Open("ID, DateTime, SchemeNumber, Amount, LotteryName, PlayTypeName, State, Identifiers", condition, "DateTime");
        if (dt != null)
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
        }
        else
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeAtTop");
        }
    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    private void dataBindLottery()
    {
        this.ddlLottery.Items.Clear();
        this.ddlLottery.Items.Add(new ListItem("------------请选择------------", "-1"));
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(base._ElectronTicketAgents.ID.ToString() + "Agent_ElectronTicket_AgentQueryBet_dtLotterys");
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + base._ElectronTicketAgents.UseLotteryList + ")", "[Order]");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Room_FrameLeft");
                return;
            }
            Shove._Web.Cache.SetCache(base._ElectronTicketAgents.ID.ToString() + "Agent_ElectronTicket_AgentQueryBet_dtLotterys", cacheAsDataTable);
        }
        for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
        {
            this.ddlLottery.Items.Add(new ListItem(cacheAsDataTable.Rows[i]["Name"].ToString(), cacheAsDataTable.Rows[i]["ID"].ToString()));
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[2].Text = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0).ToString("N");
            if (e.Item.Cells[5].Text == "1")
            {
                e.Item.Cells[5].Text = "成功";
            }
            else
            {
                e.Item.Cells[5].Text = "失败";
            }
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
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
            this.dataBindLottery();
        }
    }

 
}

