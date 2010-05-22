using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ChaseList : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        string key = (("Admin_ChaseList_BindData_" + this.ddlType.SelectedValue) == "1") ? this.tbID.Text : this.ddlIsuses.SelectedValue;
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select '我的追号' as Type,ID,Name,DateTime,LotteryName,Title,SumMoney,SumIsuseNum,BuyedIsuseNum,QuashedIsuseNum,QuashStatus,2 as StopType,StopWhenWinMoney  from V_ChaseTasksTotal ");
            if (this.ddlType.SelectedValue == "1")
            {
                builder.Append("where UserID=" + Utility.FilteSqlInfusion(this.tbID.Text.Trim()) + " ");
            }
            else
            {
                builder.Append("where ID in(select ChaseTaskID from T_ChaseTaskDetails where IsuseID = " + this.ddlIsuses.SelectedValue + ") ");
            }
            builder.Append(" union  select '追号套餐' as Type,a.ID,d.Name,DateTime,b.Name,Title,IsuseCount*Multiple*Nums*Price as SumMoney,IsuseCount,ExecutedCount,").Append(" IsuseCount-ExecutedCount as NoExecutedCount,QuashStatus,StopTypeWhenWin,StopTypeWhenWinMoney from T_Chases a inner join T_Lotteries b ").Append(" on a.LotteryID = b.ID ");
            if (this.ddlType.SelectedValue == "1")
            {
                builder.Append("and UserID=" + Utility.FilteSqlInfusion(this.tbID.Text.Trim()) + " ");
            }
            else
            {
                builder.Append("and (a.ID in (select ChaseID from T_ExecutedChases where SchemeID in(select ID from T_Schemes where IsuseID = " + this.ddlIsuses.SelectedValue + ")) ");
                if (new Tables.T_Isuses().GetCount("ID=" + this.ddlIsuses.SelectedValue + " and getdate() between StartTime and EndTime") > 0L)
                {
                    builder.Append("or a.ID in (select ChaseID from T_ExecutedChases where QuashStatus = 0 and Money > 0 and LotteryID=" + this.ddlLottery.SelectedValue + "))");
                }
                else
                {
                    builder.Append(")");
                }
            }
            builder.Append("left join T_Users d on a.UserID = d.ID  ");
            builder.Append(" left join (select ChaseID,count(SchemeID) as ExecutedCount from  T_ExecutedChases group by ChaseID)c on a.ID = c.ChaseID");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_ChaseList");
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable);
        }
        PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ") and ID not in(1,2,15)", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_ChaseList");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
        }
    }

    protected void btnRead_Click(object sender, EventArgs e)
    {
        if (this.ddlType.SelectedValue == "1")
        {
            if (this.tbUserName.Text.Trim() == "")
            {
                JavaScript.Alert(this.Page, "请输入用户名。");
                return;
            }
            Users users = new Users(base._Site.ID)[base._Site.ID, this.tbUserName.Text.Trim()];
            if (users == null)
            {
                JavaScript.Alert(this.Page, "用户名不存在。");
                return;
            }
            this.tbID.Text = users.ID.ToString();
        }
        else if (this.ddlIsuses.Items.Count == 0)
        {
            JavaScript.Alert(this.Page, "请选择期号。");
            return;
        }
        this.BindData();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new Tables.T_Isuses().Open("ID,Name", "LotteryID=" + this.ddlLottery.SelectedValue + " and  getdate()>StartTime", "EndTime desc");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_ChaseList");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlIsuses, dt, "Name", "ID");
        }
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlType.SelectedValue == "1")
        {
            this.tdUserName.Visible = true;
            this.tdIsuses.Visible = false;
        }
        else
        {
            this.tdUserName.Visible = false;
            this.tdIsuses.Visible = true;
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            string str = e.Item.Cells[4].Text.Trim();
            if (str.Length > 8)
            {
                str = str.Substring(0, 7) + "..";
            }
            string text = e.Item.Cells[1].Text;
            if (text == "我的追号")
            {
                e.Item.Cells[3].Text = "<a href='ChaseDetail.aspx?id=" + e.Item.Cells[10].Text + "'><font color=\"#330099\">" + e.Item.Cells[3].Text + "</Font></a>";
                e.Item.Cells[4].Text = "<a href='ChaseDetail.aspx?id=" + e.Item.Cells[10].Text + "'><font color=\"#330099\">" + str + "</Font></a>";
            }
            else
            {
                e.Item.Cells[3].Text = "<a href='ChaseDetails.aspx?id=" + e.Item.Cells[10].Text + "'><font color=\"#330099\">" + e.Item.Cells[3].Text + "</Font></a>";
                e.Item.Cells[4].Text = "<a href='ChaseDetails.aspx?id=" + e.Item.Cells[10].Text + "'><font color=\"#330099\">" + str + "</Font></a>";
            }
            double num = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            e.Item.Cells[5].Text = (num == 0.0) ? "" : num.ToString("N");
            int num2 = _Convert.StrToInt(e.Item.Cells[6].Text, 0);
            int num3 = _Convert.StrToInt(e.Item.Cells[7].Text, 0);
            int num4 = _Convert.StrToInt(e.Item.Cells[13].Text, 0);
            int num5 = _Convert.StrToInt(e.Item.Cells[11].Text, 0);
            if (text == "我的追号")
            {
                e.Item.Cells[9].Text = (num2 > (num3 + num4)) ? "<Font color='Red'>进行中</font>" : "已终止";
            }
            else
            {
                e.Item.Cells[9].Text = (num5 == 1) ? "已终止" : ((num2 == num3) ? "已完成" : "<Font color='Red'>进行中</font>");
            }
            int num6 = _Convert.StrToInt(e.Item.Cells[12].Text, 1);
            double num7 = _Convert.StrToDouble(e.Item.Cells[8].Text, 0.0);
            if ((num6 == 1) || (num7 == 0.0))
            {
                e.Item.Cells[8].Text = "完成方案";
            }
            else
            {
                e.Item.Cells[8].Text = "单期中奖金额达到" + num7.ToString("N") + "元";
            }
            if ((this.tdIsuses.Visible && (e.Item.Cells[9].Text != "已终止")) && (e.Item.Cells[9].Text != "已完成"))
            {
                if (e.Item.Cells[1].Text == "我的追号")
                {
                    DataTable table = new Tables.T_ChaseTaskDetails().Open("Executed", "ChaseTaskID=" + e.Item.Cells[10].Text + " and IsuseID=" + this.ddlIsuses.SelectedValue, "");
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        if (_Convert.StrToBool(table.Rows[0]["Executed"].ToString(), false))
                        {
                            e.Item.Cells[9].Text = "已执行";
                        }
                        else
                        {
                            e.Item.Cells[9].Text = "未执行";
                        }
                    }
                }
                else if (new Tables.T_ExecutedChases().GetCount("ChaseID=" + e.Item.Cells[10].Text + " and SchemeID in (select ID from T_Schemes where IsuseID=" + this.ddlIsuses.SelectedValue + ")") > 0L)
                {
                    e.Item.Cells[9].Text = "已执行";
                }
                else
                {
                    e.Item.Cells[9].Text = "未执行";
                }
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
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.ddlLottery_SelectedIndexChanged(this.ddlLottery, new EventArgs());
        }
    }


}

