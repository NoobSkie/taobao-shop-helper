using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_ShowNews : SitePageBase, IRequiresSessionState
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
                int returnValue = 0;
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

    private void BindFocusNews()
    {
        string key = "Home_Room_ZCDC_FocusNews";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Views.V_News().Open("top 5 ID,Title", "isShow = 1 and SiteID = " + base._Site.ID.ToString() + " and [TypeName] = '足彩资讯'", "isCommend,DateTime desc");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            if (cacheAsDataTable.Rows.Count < 1)
            {
                try
                {
                    Shove._Web.Cache.ClearCache(key);
                }
                catch
                {
                }
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable);
        }
        this.rptNews.DataSource = cacheAsDataTable;
        this.rptNews.DataBind();
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
            long newNewsCommentsID = 0L;
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
            this.hID.Value = Utility.GetRequest("id");
            this.BindData();
            this.BindFocusNews();
        }
    }

    protected void rptNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            DataRow row = dataItem.Row;
            HyperLink link = (HyperLink)e.Item.FindControl("hlNewsTitle");
            string input = row["Title"].ToString();
            link.Text = "<u>" + _String.HtmlTextCut(input, 8) + "</u>";
            link.NavigateUrl = row["Content"].ToString();
        }
    }
}

