using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Web_ShowNews : SitePageBase, IRequiresSessionState
{

    private void BindComments(DataTable dt)
    {
        if ((dt == null) || (dt.Rows.Count == 0))
        {
            this.NoNewsComments.Visible = true;
        }
        else
        {
            this.labNewsComments.Text = dt.Rows.Count.ToString();
            this.rptNewsComments.DataSource = dt;
            this.rptNewsComments.DataBind();
        }
    }

    private void BindData()
    {
        long newsID = _Convert.StrToLong(this.hID.Value, -1L);
        if (newsID < 0L)
        {
            PF.GoError(1, "您访问的数据不存在，可能是参数错误或内容已经被删除！", base.GetType().BaseType.FullName);
        }
        else
        {
            string key = "NewsDetail" + newsID.ToString();
            DataSet cacheAsDataSet = Shove._Web.Cache.GetCacheAsDataSet(key);
            if (cacheAsDataSet == null)
            {
                int returnValue = -1;
                string returnDescription = "";
                if (Procedures.P_NewsRead(ref cacheAsDataSet, base._Site.ID, newsID, ref returnValue, ref returnDescription) < 0)
                {
                    PF.GoError(1, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                    return;
                }
                if (((returnValue < 0) || (cacheAsDataSet == null)) || (cacheAsDataSet.Tables.Count == 0))
                {
                    PF.GoError(1, "您访问的数据不存在，可能是参数错误或内容已经被删除！", base.GetType().BaseType.FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataSet);
            }
            this.BindNewsDetail(cacheAsDataSet.Tables[0].Rows[0]);
            if (cacheAsDataSet.Tables.Count > 1)
            {
                this.BindComments(cacheAsDataSet.Tables[1]);
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

    private void BindNewsDetail(DataRow dr)
    {
        this.hlNewsType.Text = dr["TypeName"].ToString();
        if (dr["ImageUrl"].ToString() == "")
        {
            this.ImgUrl.Visible = false;
        }
        else
        {
            this.ImgUrl.ImageUrl = "../../Private/" + base._Site.ID.ToString() + "/NewsImages/" + dr["ImageUrl"].ToString();
        }
        this.lbTitle.Text = dr["Title"].ToString();
        this.lbCount.Text = dr["ReadCount"].ToString();
        this.lbDateTime.Text = _Convert.StrToDateTime(dr["DateTime"].ToString(), DateTime.Now.ToString()).ToString("yyyy-MM-dd hh:mm:ss");
        this.lbContent.Text = dr["Content"].ToString();
        if (!_Convert.StrToBool(dr["isCanComments"].ToString(), false))
        {
            this.ShowInfo.Visible = false;
            this.CommentContents.Visible = false;
            this.Comments.Visible = false;
        }
    }

    protected void btnComments_Click(object sender, EventArgs e)
    {
        Thread.Sleep(500);
        if (this.tbCommentserName.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入您的姓名！");
        }
        else if (this.tbContent.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "您的评论内容！");
        }
        else
        {
            long commentserID = -1L;
            if (base._User != null)
            {
                commentserID = base._User.ID;
            }
            long newNewsCommentsID = -1L;
            string returnDescription = "";
            if (Procedures.P_NewsAddComments(base._Site.ID, _Convert.StrToLong(this.hID.Value, 0L), DateTime.Now, commentserID, this.tbCommentserName.Text.Trim(), this.tbContent.Text.Trim(), true, ref newNewsCommentsID, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else if (newNewsCommentsID < 0L)
            {
                JavaScript.Alert(this.Page, returnDescription);
            }
            else
            {
                JavaScript.Alert(this.Page, "您的评论已提交成功！");
                Shove._Web.Cache.ClearCache("NewsDetail" + this.hID.Value);
                this.BindData();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.hID.Value = _Convert.StrToLong(Utility.GetRequest("id"), -1L).ToString();
            this.BindData();
            this.BindDataForAnalysisAndTerminologyAndSkills();
            this.ShowInfo.Visible = false;
            this.CommentContents.Visible = false;
            this.Comments.Visible = false;
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

