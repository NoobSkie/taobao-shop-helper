using ASP;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_FollowFriendScheme : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        long iD = -1L;
        if (base._User != null)
        {
            iD = base._User.ID;
        }
        string str = "SELECT ID,[NAME],[Level],MaxFollowNumber FROM dbo.T_Users ";
        string str2 = Utility.FilteSqlInfusion(this.TxtName.Text.Trim());
        if ((str2 != "") && (str2 != "输入用户名"))
        {
            string str3 = str;
            str = str3 + " WHERE [Name] LIKE '%" + str2 + "%' and ID not in (select FollowUserID from T_CustomFriendFollowSchemes where UserID = " + iD.ToString() + " and LotteryID  in (-1," + this.HidLotteryID.Value + "))";
        }
        else
        {
            str = str + " WHERE 0=1";
        }
        if (iD > 0L)
        {
            str = str + " and ID <> " + iD.ToString();
        }
        DataTable dt = MSSQL.Select(str + " and ID <> 132011", new MSSQL.Parameter[0]);
        if (dt == null)
        {
            PF.GoError(1, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
            this.gPager.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            if (base._User == null)
            {
                JavaScript.Alert(this, "已退出登陆，请重新登陆", base.Request.Url.AbsoluteUri);
            }
            else
            {
                int num = _Convert.StrToInt(e.Item.Cells[6].Text, -1);
                if (num < 0)
                {
                    JavaScript.Alert(this, "取消定制失败！");
                }
                else if (MSSQL.ExecuteNonQuery("delete from T_CustomFriendFollowSchemes where FollowUserID = " + num.ToString() + " and UserID = " + base._User.ID.ToString(), new MSSQL.Parameter[0]) < 0)
                {
                    JavaScript.Alert(this, "取消定制失败！");
                }
                else
                {
                    Shove._Web.Cache.ClearCache("T_CustomFriendFollowSchemes" + this.HidLotteryID.Value);
                    this.BindData();
                    JavaScript.Alert(this, "取消定制成功！");
                }
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            DataRow row = dataItem.Row;
            if (row != null)
            {
                TableCell cell = e.Item.Cells[1];
                cell.CssClass = "blue12";
                if (row["Level"].ToString() == "0")
                {
                    cell.Text = "<a href='../Web/Score.aspx?id=" + row["ID"].ToString() + "&LotteryID=" + this.HidLotteryID.Value + "' title='点击查看' target='_blank'>-</a>";
                }
                else
                {
                    int num = _Convert.StrToInt(row["Level"].ToString(), 0);
                    string str = "";
                    for (int i = 1; i <= num; i++)
                    {
                        str = str + "<img src='Images/gold.gif'/>";
                    }
                    cell.Text = "<a href='../Web/Score.aspx?id=" + row["ID"].ToString() + "&LotteryID=" + this.HidLotteryID.Value + "' title='点击查看' target='_blank'>" + str + "</a>";
                }
                TableCell cell2 = e.Item.Cells[2];
                string key = "T_CustomFriendFollowSchemes" + this.HidLotteryID.Value;
                DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
                if (cacheAsDataTable == null)
                {
                    cacheAsDataTable = MSSQL.Select("select * from T_CustomFriendFollowSchemes where LotteryID in (-1," + this.HidLotteryID.Value + ")", new MSSQL.Parameter[0]);
                    if ((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0))
                    {
                        Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
                    }
                }
                int length = 0;
                if ((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0))
                {
                    length = cacheAsDataTable.Select("FollowUserID = " + row["ID"].ToString()).Length;
                }
                cell2.Text = length.ToString() + "/" + row["MaxFollowNumber"].ToString();
                TableCell cell3 = e.Item.Cells[3];
                if (length > 0)
                {
                    cell3.CssClass = "blue12";
                    cell3.Text = "<a href='javascript:;' onclick=\"showDialog('FollowFriendView.aspx?ID=" + row["ID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(row["Name"].ToString()) + "');\">查看</a>";
                }
                else
                {
                    cell3.Text = "-";
                }
                TableCell cell4 = e.Item.Cells[4];
                int num4 = -1;
                if (base._User == null)
                {
                    cell4.Text = "未知";
                }
                else if (cacheAsDataTable.Select("UserID = " + base._User.ID.ToString() + " and FollowUserID = " + row["ID"].ToString()).Length > 0)
                {
                    cell4.Text = "已定制";
                    num4 = 1;
                }
                else
                {
                    cell4.Text = "未定制";
                    num4 = 0;
                }
                TableCell cell5 = e.Item.Cells[5];
                if (num4 == -1)
                {
                    cell5.Text = "-";
                }
                else
                {
                    Label label = (Label)cell5.FindControl("lbEdit");
                    LinkButton button = (LinkButton)cell5.FindControl("Cancel");
                    button.Visible = false;
                    cell5.CssClass = "blue12";
                    switch (num4)
                    {
                        case 0:
                            if (length >= _Convert.StrToInt(row["MaxFollowNumber"].ToString(), 200))
                            {
                                cell5.Text = "已满额";
                            }
                            else
                            {
                                cell5.Text = "<a href='FollowFriendSchemeAdd.aspx?FollowUserID=" + row["ID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(row["Name"].ToString()) + "&LotteryID=" + this.HidLotteryID.Value + "&Number=" + this.HidNumber.Value + "'>定制</a>";
                            }
                            button.Visible = false;
                            return;

                        case 1:
                            label.Text = "<script>var e_script_" + row["ID"].ToString() + "=\"parent.iframeFollowScheme.showDialog('FollowFriendSchemeEdit.aspx?FollowUserID=" + row["ID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(row["Name"].ToString()) + "&&UserID=" + base._User.ID.ToString() + "&Number=" + this.HidNumber.Value + "')\";</script><a href='javascript:;' onclick=\"if(parent.CreateLogin(e_script_" + row["ID"].ToString() + ")){showDialog('FollowFriendSchemeEdit.aspx?FollowUserID=" + row["ID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(row["Name"].ToString()) + "&UserID=" + base._User.ID.ToString() + "&Number=" + this.HidNumber.Value + "');}\">修改</a>";
                            button.Visible = true;
                            break;
                    }
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
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.HidLotteryID.Value = Utility.GetRequest("LotteryID");
            this.HidNumber.Value = Utility.GetRequest("Number");
            this.hlCancel.NavigateUrl = "FollowScheme.aspx?LotteryID=" + this.HidLotteryID.Value + "&Number=" + this.HidNumber.Value;
            this.BindData();
        }
    }
}

