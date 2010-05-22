using ASP;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class BottomNavigationPages_FriendLink : SitePageBase, IRequiresSessionState
{

    private void GetFriendLinks()
    {
        new StringBuilder();
        string key = "T_FriendshipLinks_Links";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = MSSQL.Select("select LinkName,Url,LogoUrl from T_FriendshipLinks where SiteID = @SiteID order by [Order] asc ", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
        }
        if (cacheAsDataTable == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            if (cacheAsDataTable.Rows.Count > 0)
            {
                Shove._Web.Cache.SetCache("T_FriendshipLinks_Links", cacheAsDataTable);
            }
            DataTable table2 = cacheAsDataTable.Clone();
            DataRow[] rowArray = cacheAsDataTable.Select("LogoUrl <> ''");
            int length = rowArray.Length;
            for (int i = 0; i < length; i++)
            {
                table2.Rows.Add(rowArray[i].ItemArray);
            }
            this.dlFriendLinks.DataSource = table2;
            this.dlFriendLinks.DataBind();
            DataTable table3 = cacheAsDataTable.Clone();
            rowArray = cacheAsDataTable.Select("LogoUrl = ''");
            length = rowArray.Length;
            for (int j = 0; j < length; j++)
            {
                table3.Rows.Add(rowArray[j].ItemArray);
            }
            this.dlFrindLinksNoImg.DataSource = table3;
            this.dlFrindLinksNoImg.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GetFriendLinks();
        }
    }


}

