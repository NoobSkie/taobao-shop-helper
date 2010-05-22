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

public partial class Admin_Experts : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable dt = new Views.V_Experts().Open("", "SiteID = " + base._Site.ID.ToString() + ((this.ddlLottery.SelectedValue == "0") ? "" : (" and LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue))), "");
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

    private void BindDataForLottery()
    {
        DataTable table = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[Order]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
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
        if (e.CommandName == "Edit")
        {
            long expertsID = _Convert.StrToLong(e.Item.Cells[12].Text, -1L);
            if (expertsID < 1L)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                string description = ((TextBox)e.Item.Cells[4].FindControl("tbDescription")).Text.Trim();
                if (description == "")
                {
                    JavaScript.Alert(this.Page, "请输入专家描述。");
                }
                else
                {
                    double maxPrice = _Convert.StrToDouble(((TextBox)e.Item.Cells[5].FindControl("tbMaxPrice")).Text, -1.0);
                    if (maxPrice < 0.0)
                    {
                        JavaScript.Alert(this.Page, "请输入正确的最大单价。");
                    }
                    else
                    {
                        double bonusScale = _Convert.StrToDouble(((TextBox)e.Item.Cells[6].FindControl("tbBonusScale")).Text, -1.0);
                        if ((bonusScale < 0.0) || (bonusScale > 1.0))
                        {
                            JavaScript.Alert(this.Page, "请输入正确的所得佣金比例。");
                        }
                        else
                        {
                            int readCount = _Convert.StrToInt(((TextBox)e.Item.Cells[7].FindControl("tbReadCount")).Text, -1);
                            if (readCount < 0)
                            {
                                JavaScript.Alert(this.Page, "请输入正确的人气指数。");
                            }
                            else
                            {
                                int returnValue = -1;
                                string returnDescription = "";
                                if (Procedures.P_ExpertsEdit(base._Site.ID, expertsID, description, maxPrice, bonusScale, ((CheckBox)e.Item.Cells[7].FindControl("cbON")).Checked, ((CheckBox)e.Item.Cells[8].FindControl("cbisCommend")).Checked, readCount, ref returnValue, ref returnDescription) < 0)
                                {
                                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                                }
                                else if (returnValue < 0)
                                {
                                    JavaScript.Alert(this.Page, returnDescription);
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (e.CommandName == "Del")
        {
            long num7 = _Convert.StrToLong(e.Item.Cells[12].Text, -1L);
            if (num7 < 1L)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                int num8 = -1;
                string str3 = "";
                if (Procedures.P_ExpertsDelete(base._Site.ID, num7, ref num8, ref str3) < 0)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                }
                else if (num8 < 0)
                {
                    PF.GoError(1, str3, base.GetType().BaseType.FullName);
                }
                else
                {
                    this.BindData();
                }
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            ((TextBox)e.Item.Cells[4].FindControl("tbDescription")).Text = e.Item.Cells[13].Text;
            ((TextBox)e.Item.Cells[5].FindControl("tbMaxPrice")).Text = e.Item.Cells[14].Text;
            ((TextBox)e.Item.Cells[6].FindControl("tbBonusScale")).Text = e.Item.Cells[15].Text;
            ((TextBox)e.Item.Cells[7].FindControl("tbReadCount")).Text = e.Item.Cells[0x12].Text;
            ((CheckBox)e.Item.Cells[8].FindControl("cbON")).Checked = _Convert.StrToBool(e.Item.Cells[0x10].Text, true);
            ((CheckBox)e.Item.Cells[9].FindControl("cbisCommend")).Checked = _Convert.StrToBool(e.Item.Cells[0x11].Text, true);
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
            this.g.Columns[10].Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "MemberManagement" }));
        }
    }

  
}

