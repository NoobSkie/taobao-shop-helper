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

public partial class Admin_WinList : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        DataTable dt = new Views.V_Schemes().Open("", "[IsuseID] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and QuashStatus = 0 and Buyed = 1 and WinMoney <> 0", "[ID]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_WinList");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
        }
    }

    private void BindDataForIsuse()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable dt = new Tables.T_Isuses().Open("[ID], [Name]", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + " and EndTime < GetDate() and isOpened = 1", "EndTime desc");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_WinList");
            }
            else
            {
                ControlExt.FillDropDownList(this.ddlIsuse, dt, "Name", "ID");
                if (this.ddlIsuse.Items.Count > 0)
                {
                    this.BindData();
                }
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_WinList");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForIsuse();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            e.Item.Cells[2].Text = num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = num.ToString("N");
            e.Item.Cells[5].Text = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0).ToString("N");
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.BindDataForIsuse();
        }
    }


}

