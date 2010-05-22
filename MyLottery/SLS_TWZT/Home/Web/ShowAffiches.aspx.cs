using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Web_ShowAffiches : SitePageBase, IRequiresSessionState
{

    private void BindData()
    {
        long num = _Convert.StrToLong(Utility.GetRequest("id"), -1L);
        if (num < 0L)
        {
            PF.GoError(1, "您访问的数据不存在，可能是参数错误或内容已经被删除！", base.GetType().BaseType.FullName);
        }
        else
        {
            DataTable table;
            table = table = new Tables.T_SiteAffiches().Open("", "ID=" + num.ToString(), "");
            if (table == null)
            {
                PF.GoError(1, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else if (table.Rows.Count < 0)
            {
                PF.GoError(1, "您访问的数据不存在，可能是参数错误或内容已经被删除！", base.GetType().BaseType.FullName);
            }
            else
            {
                DataRow row = table.Rows[0];
                this.lbTitle.Text = row["Title"].ToString();
                this.lbDateTime.Text = _Convert.StrToDateTime(row["DateTime"].ToString(), DateTime.Now.ToString()).ToString("yyyy-MM-dd hh:mm:ss");
                this.lbContent.Text = row["Content"].ToString();
            }
        }
    }

    private void BindDataForAnalysisAndTerminologyAndSkills()
    {
        string key = "Default_GetNews";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            string commandText = "select * from\r\n                                (select top 6 ID,Title,TypeName from V_News where isShow = 1  and [TypeName] = '推荐分析'\r\n                                order by isCommend,ID desc)a\r\n                            union\r\n                            select * from\r\n                                (select top 6 ID,Title,TypeName from V_News where isShow = 1  and [TypeName] = '投注技巧'\r\n                                order by isCommend,ID desc)b\r\n                            union\r\n                            select * from\r\n                                (select top 6 ID,Title,TypeName from V_News where isShow = 1  and [TypeName] = '中奖故事'\r\n                                order by isCommend,ID desc)c\r\n                             union\r\n                            select * from\r\n                                (select top 5 ID,Title,TypeName from V_News where isShow = 1  and [TypeName] = '中奖公告'\r\n                                order by isCommend,ID desc)d\r\n                             union\r\n                            select * from\r\n                                (select top 7 ID,Title,TypeName from V_News where isShow = 1  and [TypeName] = '精彩活动'\r\n                                order by isCommend,ID desc)e";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        DataTable table2 = cacheAsDataTable.Clone();
        DataTable table3 = cacheAsDataTable.Clone();
        if (cacheAsDataTable.Rows.Count > 0)
        {
            foreach (DataRow row in cacheAsDataTable.Rows)
            {
                string str3 = row["TypeName"].ToString();
                if (str3 != null)
                {
                    if (!(str3 == "推荐分析"))
                    {
                        if (str3 == "投注技巧")
                        {
                            goto Label_00E1;
                        }
                    }
                    else
                    {
                        table2.Rows.Add(row.ItemArray);
                    }
                }
                continue;
            Label_00E1:
                table3.Rows.Add(row.ItemArray);
            }
        }
        this.rptRecommendAnalysis.DataSource = table2;
        this.rptRecommendAnalysis.DataBind();
        this.rptSkills.DataSource = table3;
        this.rptSkills.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.BindDataForAnalysisAndTerminologyAndSkills();
        }
    }

    protected void rptRecommendAnalysis_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            DataRow dataItem = e.Item.DataItem as DataRow;
            HyperLink link = e.Item.FindControl("hlAnalysisTitle") as HyperLink;
            string input = dataItem["Title"].ToString();
            link.Text = _String.HtmlTextCut(input, 10);
            link.NavigateUrl = dataItem["Content"].ToString();
        }
    }

    protected void rptSkills_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.EditItem)) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            DataRow dataItem = e.Item.DataItem as DataRow;
            HyperLink link = e.Item.FindControl("hlSkills") as HyperLink;
            string input = dataItem["Title"].ToString();
            link.Text = _String.HtmlTextCut(input, 10);
            link.NavigateUrl = dataItem["Content"].ToString();
        }
    }
}

