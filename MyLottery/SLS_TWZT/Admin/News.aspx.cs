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

public partial class Admin_News : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.tv.Nodes.Count >= 1)
        {
            string selectedValue = this.tv.SelectedValue;
            if (selectedValue == "")
            {
                selectedValue = this.tv.Nodes[0].Value;
            }
            DataTable dt = new Tables.T_News().Open("", "SiteID = " + base._Site.ID.ToString() + " and TypeID = " + Utility.FilteSqlInfusion(selectedValue), "[DateTime] desc");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                PF.DataGridBindData(this.g, dt, this.gPager);
            }
        }
    }

    private void BindDataForType()
    {
        DataTable table = new Tables.T_NewsTypes().Open("", "SiteID = " + base._Site.ID.ToString(), "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            this.tv.DataTable = table;
            this.tv.DataBind();
            foreach (TreeNode node in this.tv.Nodes)
            {
                node.NavigateUrl = "";
                foreach (TreeNode node2 in node.ChildNodes)
                {
                    node2.NavigateUrl = "";
                }
            }
            string str = _Convert.StrToLong(Utility.GetRequest("TypeID"), -1L).ToString();
            if (str != "-1")
            {
                ControlExt.SetTreeViewSelectedFromValue(this.tv, str);
            }
            else if (this.tv.Nodes.Count > 0)
            {
                this.tv.Nodes[0].Select();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("NewsAdd.aspx?TypeID=" + this.tv.SelectedValue, true);
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            base.Response.Redirect("NewsEdit.aspx?TypeID=" + this.tv.SelectedValue + "&ID=" + e.Item.Cells[8].Text, true);
        }
        else if (e.CommandName == "Del")
        {
            int returnValue = -1;
            string returnDescription = "";
            if (Procedures.P_NewsDelete(base._Site.ID, long.Parse(e.Item.Cells[8].Text), ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else if (returnValue < 0)
            {
                PF.GoError(1, returnDescription, base.GetType().BaseType.FullName);
            }
            else
            {
                if (this.tv.SelectedNode.Text == "时时乐资讯")
                {
                    Shove._Web.Cache.ClearCache(DataCache.LotteryNews + "29");
                }
                if (this.tv.SelectedNode.Text == "十一运夺金资讯")
                {
                    Shove._Web.Cache.ClearCache(DataCache.LotteryNews + "62");
                }
                if (this.tv.SelectedNode.Text == "热门人物追踪")
                {
                    Shove._Web.Cache.ClearCache("Home_Room_JoinAllBuy_BindNews");
                }
                string str2 = this.tv.SelectedNode.Text.Trim();
                switch (str2)
                {
                    case "福彩资讯":
                    case "体彩资讯":
                    case "足彩资讯":
                        Shove._Web.Cache.ClearCache("Default_GetNews");
                        break;
                }
                if (str2.Contains("3D"))
                {
                    Shove._Web.Cache.ClearCache("Home_Room_Buy_BindNewsForLottery6");
                }
                if (str2.Contains("双色球"))
                {
                    Shove._Web.Cache.ClearCache("Home_Room_Buy_BindNewsForLottery5");
                }
                if (str2.Contains("玩法攻略"))
                {
                    Shove._Web.Cache.ClearCache("Default_BindWFGL");
                }
                this.BindData();
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[2].FindControl("cbisShow");
            box.Checked = _Convert.StrToBool(e.Item.Cells[9].Text, true);
            box = (CheckBox)e.Item.Cells[3].FindControl("cbisHasImage");
            box.Checked = _Convert.StrToBool(e.Item.Cells[10].Text, true);
            box = (CheckBox)e.Item.Cells[4].FindControl("cbisCommend");
            box.Checked = _Convert.StrToBool(e.Item.Cells[11].Text, true);
            box = (CheckBox)e.Item.Cells[5].FindControl("cbisHot");
            box.Checked = _Convert.StrToBool(e.Item.Cells[12].Text, true);
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
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "EditNews", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForType();
            this.BindData();
            this.btnAdd.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "EditNews" }));
            this.g.Columns[7].Visible = this.btnAdd.Visible;
        }
    }

    protected void tv_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.BindData();
    }


}

