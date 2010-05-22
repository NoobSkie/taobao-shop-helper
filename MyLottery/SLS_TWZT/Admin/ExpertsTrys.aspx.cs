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

public partial class Admin_ExpertsTrys : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            string[] strArray = new string[] { "SiteID = ", base._Site.ID.ToString(), (this.ddlLottery.SelectedValue == "0") ? "" : (" and LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue)), " and HandleResult = ", ((short)0).ToString() };
            DataTable dt = new Views.V_ExpertsTrys().Open("", string.Concat(strArray), "");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_ExpertsTrys");
            }
            else
            {
                PF.DataGridBindData(this.g, dt, this.gPager);
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable table = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[Order]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_ExpertsTrys");
        }
        else
        {
            this.ddlLottery.Items.Clear();
            this.ddlLottery.Items.Add(new ListItem("所有彩种", "0"));
            foreach (DataRow row in table.Rows)
            {
                this.ddlLottery.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
            }
        }
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Accept")
        {
            long expertsTryID = _Convert.StrToLong(e.Item.Cells[10].Text, -1L);
            if (expertsTryID < 1L)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_ExpertsTrys");
                return;
            }
            string description = ((TextBox)e.Item.Cells[4].FindControl("tbDescription")).Text.Trim();
            if (description == "")
            {
                JavaScript.Alert(this.Page, "请输入超级发起人描述。");
                return;
            }
            double maxPrice = _Convert.StrToDouble(((TextBox)e.Item.Cells[5].FindControl("tbMaxPrice")).Text, -1.0);
            if (maxPrice < 0.0)
            {
                JavaScript.Alert(this.Page, "请输入正确的最大单价。");
                return;
            }
            double bonusScale = _Convert.StrToDouble(((TextBox)e.Item.Cells[6].FindControl("tbBonusScale")).Text, -1.0);
            if ((bonusScale < 0.0) || (bonusScale > 1.0))
            {
                JavaScript.Alert(this.Page, "请输入正确的所得佣金比例。");
                return;
            }
            CheckBox box = (CheckBox)e.Item.Cells[7].FindControl("cbisCommend");
            bool isCommend = box.Checked;
            int returnValue = -1;
            string returnDescription = "";
            if (Procedures.P_ExpertsTryHandle(base._Site.ID, expertsTryID, 1, description, maxPrice, bonusScale, isCommend, ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_ExpertsTrys");
                return;
            }
            if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
                return;
            }
            this.BindData();
        }
        if (e.CommandName == "NoAccept")
        {
            long num6 = _Convert.StrToLong(e.Item.Cells[9].Text, -1L);
            if (num6 < 1L)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_ExpertsTrys");
                return;
            }
            int num7 = -1;
            string str3 = "";
            if (Procedures.P_ExpertsTryHandle(base._Site.ID, num6, -1, "", 0.0, 0.0, false, ref num7, ref str3) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_ExpertsTrys");
                return;
            }
            if (num7 < 0)
            {
                PF.GoError(1, str3, "Admin_ExpertsTrys");
                return;
            }
        }
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            ((TextBox)e.Item.Cells[4].FindControl("tbDescription")).Text = e.Item.Cells[11].Text;
            ((TextBox)e.Item.Cells[5].FindControl("tbMaxPrice")).Text = e.Item.Cells[12].Text;
            ((TextBox)e.Item.Cells[6].FindControl("tbBonusScale")).Text = e.Item.Cells[13].Text;
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
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "MemberManagement", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.BindData();
            this.g.Columns[7].Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "MemberManagement" }));
        }
    }


}

