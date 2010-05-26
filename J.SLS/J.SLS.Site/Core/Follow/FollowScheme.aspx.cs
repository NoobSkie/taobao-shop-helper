using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shove._Web;
using Shove.Database;
using System.Data;
using Shove;
using Shove.Web.UI;

public partial class Core_Follow_FollowScheme : System.Web.UI.Page
{
    private void BindData()
    {
        long iD = -1L;
        //if (base._User != null)
        //{
        //    iD = base._User.ID;
        //}
        this.hlAdd.NavigateUrl = "FollowFriendScheme.aspx?LotteryID=" + this.tbLotteryID.Value + "&Number=" + this.tbNumber.Value;
        string commandText = "SELECT ID,[Name],[Level],MaxFollowNumber FROM dbo.T_Users ";
        if (iD > 0L)
        {
            string str2 = commandText;
            commandText = str2 + " WHERE ID in (select FollowUserID from T_CustomFriendFollowSchemes where UserID = " + iD.ToString() + " and LotteryID in (-1," + this.tbLotteryID.Value + "))   and ID <> " + iD.ToString();
        }
        else
        {
            commandText = commandText + " WHERE 0=1";
        }
        string str3 = Utility.FilteSqlInfusion(this.Name.Text.Trim());
        if ((str3 != "") && (str3 != "输入用户名"))
        {
            commandText = commandText + " and [Name] LIKE '%" + str3 + "%'";
        }
        DataTable dt = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
        if (dt == null)
        {
            PageHelper.GoError(1, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            PageHelper.DataGridBindData(this.g, dt, this.gPager);
            this.gPager.Visible = true;
        }
    }

    protected void btnList_Click(object sender, EventArgs e)
    {
        this.Name.Text = "";
        this.BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
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
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.tbLotteryID.Value = Utility.GetRequest("LotteryID");
            this.tbNumber.Value = Utility.GetRequest("Number");
            this.BindData();
        }
    }
}
