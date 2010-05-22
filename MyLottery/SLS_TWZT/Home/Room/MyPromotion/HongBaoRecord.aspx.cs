using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_MyPromotion_HongBaoRecord : RoomPageBase, IRequiresSessionState
{


    private void BindData()
    {
        string key = "Home_Room_MyPromotion_HongBaoRecord_BindData" + base._User.ID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = MSSQL.Select("select a.*,Name as UserName from T_UserHongbaoPromotion a left join  T_Users b on a.AcceptUserID = b.ID where UserID = " + base._User.ID.ToString() + " order by CreateDate desc", new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable);
        }
        DataTable dt = cacheAsDataTable.Clone();
        DataRow[] rowArray = cacheAsDataTable.Select(this.GetCondition());
        for (int i = 0; i < rowArray.Length; i++)
        {
            dt.Rows.Add(rowArray[i].ItemArray);
        }
        PF.DataGridBindData(this.g, dt, this.gPager);
        if ((this.rblType.SelectedValue == "1") || (this.rblType.SelectedValue == "3"))
        {
            this.g.Columns[6].Visible = true;
        }
        else
        {
            this.g.Columns[6].Visible = false;
        }
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            new Tables.T_UserHongbaoPromotion().Delete("ID=" + e.Item.Cells[7].Text);
            Shove._Web.Cache.ClearCache("Home_Room_MyPromotion_HongBaoRecord" + base._User.ID.ToString());
            this.BindData();
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.EditItem)) || (e.Item.ItemType == ListItemType.Item))
        {
            ShoveLinkButton button = e.Item.FindControl("btnCopy") as ShoveLinkButton;
            string text = e.Item.Cells[5].Text;
            button.Attributes.Add("onclick", "copy('" + text + "')");
            e.Item.Cells[5].Text = _String.Cut(text, 30);
            ShoveLinkButton button2 = e.Item.FindControl("btnDelete") as ShoveLinkButton;
            if (e.Item.Cells[8].Text != "-1")
            {
                button2.Visible = false;
            }
        }
    }

    private string GetCondition()
    {
        string str2 = DateTime.Now.ToString();
        switch (this.rblType.SelectedValue)
        {
            case "2":
                return "AcceptUserID<>-1";

            case "4":
                return ("AcceptUserID=-1 and ExpiryDate<'" + str2 + "'");

            case "3":
                return ("AcceptUserID=-1 and ExpiryDate>='" + str2 + "'");
        }
        return "1=1";
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
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }

    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

   
}

