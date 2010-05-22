using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_SchemeList : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.listIsuse.Items.Count >= 1)
        {
            int num = 1;
            try
            {
                num = int.Parse(this.ViewState["Admin_SchemeList_Type"].ToString());
            }
            catch
            {
                num = 1;
            }
            if ((num < 1) || (num > 7))
            {
                PF.GoError(1, "参数错误", "Admin_SchemeList");
            }
            else
            {
                DataTable dt = null;
                string str = " SiteID = " + base._Site.ID.ToString() + " and IsuseID = " + this.listIsuse.SelectedValue;
                if (this.ddlUser.Enabled && (int.Parse(this.ddlUser.SelectedValue) >= 0))
                {
                    str = str + " and BuyOperatorID = " + this.ddlUser.SelectedValue;
                }
                switch (num)
                {
                    case 1:
                        dt = MSSQL.Select("select * from V_SchemeSchedulesWithQuashed with (nolock) where " + str + " order by  [DateTime] desc", new MSSQL.Parameter[0]);
                        break;

                    case 2:
                        dt = MSSQL.Select("select * from V_SchemeSchedulesWithQuashed with (nolock) where " + str + " and Buyed=1 order by [Money] desc", new MSSQL.Parameter[0]);
                        break;

                    case 3:
                        dt = MSSQL.Select("select * from V_SchemeSchedulesWithQuashed with (nolock) where " + str + " and Buyed=0 order by [DateTime] desc", new MSSQL.Parameter[0]);
                        break;

                    case 4:
                        dt = MSSQL.Select("select * from V_SchemeSchedulesWithQuashed with (nolock) where " + str + " and QuashStatus<>0 order by [DateTime] desc", new MSSQL.Parameter[0]);
                        break;

                    case 5:
                        dt = MSSQL.Select("select * from V_SchemeSchedulesWithQuashed with (nolock) where " + str + " and QuashStatus = 2 order by [DateTime] desc", new MSSQL.Parameter[0]);
                        break;

                    case 6:
                        dt = MSSQL.Select("select * from V_SchemeSchedulesWithQuashed with (nolock) where " + str + " and WinMoney > 0 and Buyed=1 order by [DateTime] desc", new MSSQL.Parameter[0]);
                        break;

                    case 7:
                        dt = MSSQL.Select("select * from V_SchemeSchedulesWithQuashed with (nolock) where " + str + " and WinMoney > 0 and Buyed=0 order by [DateTime] desc", new MSSQL.Parameter[0]);
                        break;
                }
                if (dt == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeList");
                }
                else
                {
                    PF.DataGridBindData(this.g, dt, this.gPager);
                }
            }
        }
    }

    private void BindDataForIsuse()
    {
        if (this.listLottery.Items.Count >= 1)
        {
            DataTable dt = new Tables.T_Isuses().Open("", "StartTime < GetDate() and LotteryID = " + Utility.FilteSqlInfusion(this.listLottery.SelectedValue), "EndTime desc");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeList");
            }
            else
            {
                this.listIsuse.Items.Clear();
                ControlExt.FillListBox(this.listIsuse, dt, "Name", "ID");
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeList");
        }
        else
        {
            ControlExt.FillListBox(this.listLottery, dt, "Name", "ID");
        }
    }

    private void BindDataForUser()
    {
        DataTable table = new Tables.T_Users().Open("[ID], [Name]", "SiteID = " + base._Site.ID.ToString() + " and [ID] in (select distinct UserID from T_CompetencesOfUsers union all select distinct UserID from T_UserInGroups)", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeList");
        }
        else
        {
            this.ddlUser.Items.Add(new ListItem("全部操作员", "-1"));
            foreach (DataRow row in table.Rows)
            {
                this.ddlUser.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
            }
            this.ddlUser.SelectedIndex = 0;
        }
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForIsuse();
        this.BindData();
    }

    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Attributes["onmouseover"] = "this.name=this.style.backgroundColor;this.style.backgroundColor='MistyRose'";
            e.Item.Attributes["onmouseout"] = "this.style.backgroundColor=this.name;";
            e.Item.Cells[1].Text = "<a href='../Home/Room/Scheme.aspx?id=" + e.Item.Cells[11].Text + "' target='_blank'>" + e.Item.Cells[1].Text + "</a>";
            e.Item.Cells[2].Text = "<a href='../Score.aspx?id=" + e.Item.Cells[12].Text + "&LotteryID=" + this.listLottery.SelectedValue + "' target='_blank'>" + e.Item.Cells[2].Text + "</a>";
            if (_Convert.StrToDouble(e.Item.Cells[10].Text, 0.0) > 0.0)
            {
                TableCell cell1 = e.Item.Cells[2];
                cell1.Text = cell1.Text + "<font color='red'>(保)</font>";
            }
            double num = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num == 0.0) ? "" : num.ToString("N");
            e.Item.ToolTip = e.Item.Cells[5].Text.Trim();
            string text = e.Item.Cells[5].Text;
            e.Item.Cells[5].Text = "";
            if (new Lottery.ZCDC().CheckPlayType(_Convert.StrToInt(e.Item.Cells[14].Text, -1)))
            {
                string vote = "";
                DataTable table = PF.GetZCDCBuyContent(text, _Convert.StrToLong(e.Item.Cells[11].Text, -1L), ref vote);
                if (table == null)
                {
                    PF.GoError(4, "数据访问错误", base.GetType().BaseType.FullName);
                    return;
                }
                foreach (DataRow row in table.Rows)
                {
                    if (e.Item.Cells[5].Text == "")
                    {
                        TableCell cell2 = e.Item.Cells[5];
                        string str3 = cell2.Text;
                        cell2.Text = str3 + row["No"].ToString() + " " + row["LeagueTypeName"].ToString() + " " + row["HostTeam"].ToString() + " VS " + row["QuestTeam"].ToString() + " " + row["Content"].ToString() + " " + row["LotteryResult"].ToString();
                    }
                    else
                    {
                        TableCell cell3 = e.Item.Cells[5];
                        string str4 = cell3.Text;
                        cell3.Text = str4 + "<br />" + row["No"].ToString() + " " + row["LeagueTypeName"].ToString() + " " + row["HostTeam"].ToString() + " VS " + row["QuestTeam"].ToString() + " " + row["Content"].ToString() + " " + row["LotteryResult"].ToString();
                    }
                }
                TableCell cell4 = e.Item.Cells[5];
                cell4.Text = cell4.Text + "<br /><font color='red'>" + vote + "</font>";
            }
            else
            {
                e.Item.Cells[5].Text = text;
                if (_String.StringAt(text, '\n') >= base._Site.SiteOptions["Opt_MaxShowLotteryNumberRows"].ToShort(0))
                {
                    e.Item.Cells[5].Text = "<a href='../DownLoadSchemeFile.aspx?id=" + e.Item.Cells[11].Text + "' target='_blank'>下载方案</a>";
                }
                else
                {
                    text = e.Item.Cells[5].Text.Replace("\r\n", ", ");
                    if (text.Length > 0x19)
                    {
                        text = text.Substring(0, 0x17) + "..";
                    }
                    e.Item.Cells[5].Text = text;
                }
            }
            int num2 = _Convert.StrToInt(e.Item.Cells[6].Text, 1);
            e.Item.Cells[7].Text = Math.Round((double)(num / ((double)num2)), 2).ToString("N");
            TableCell cell5 = e.Item.Cells[8];
            cell5.Text = cell5.Text + "%";
            switch (_Convert.StrToShort(e.Item.Cells[13].Text, 0))
            {
                case 2:
                    e.Item.Cells[9].Text = "<font color='blue'>系统撤单</font>";
                    return;

                case 1:
                    e.Item.Cells[9].Text = "已撤单";
                    return;
            }
            if (_Convert.StrToBool(e.Item.Cells[0x10].Text, false))
            {
                e.Item.Cells[9].Text = "<Font color='Red'>已成功</font>";
            }
            else if (e.Item.Cells[8].Text == "100%")
            {
                e.Item.Cells[9].Text = "<Font color='Red'>满员</font>";
            }
            else
            {
                e.Item.Cells[9].Text = "未满";
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

    protected void listIsuse_SelectedIndexChanged(object sender, EventArgs e)
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
            this.BindDataForUser();
            this.BindDataForLottery();
            this.BindDataForIsuse();
        }
    }

    protected void RadTypeClick(object sender, EventArgs e)
    {
        int num = _Convert.StrToInt(((RadioButton)sender).ID.Substring(8, 1), 1);
        this.ViewState["Admin_SchemeList_Type"] = num;
        this.ddlUser.Enabled = num == 2;
        this.BindData();
    }
}

