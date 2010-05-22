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

public partial class Home_Room_QuestionList : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        string str = "1";
        try
        {
            str = this.ViewState["MemberQuestionList_Type"].ToString();
        }
        catch
        {
        }
        int type = _Convert.StrToInt(str, 1);
        if ((type < 1) || (type > 3))
        {
            type = 1;
        }
        this.BindData(type);
    }

    private void BindData(int Type)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("MemberQuestionList_" + Type.ToString() + "_" + base._User.ID.ToString());
        if (cacheAsDataTable == null)
        {
            switch (Type)
            {
                case 1:
                    cacheAsDataTable = new Views.V_Questions().Open("", "SiteID = " + base._Site.ID.ToString() + " and UserID = " + base._User.ID.ToString() + " and UseType = 1", "[DateTime] desc");
                    break;

                case 2:
                    cacheAsDataTable = new Views.V_Questions().Open("", "SiteID = " + base._Site.ID.ToString() + " and UserID = " + base._User.ID.ToString() + " and UseType = 1 and AnswerStatus = 0", "[DateTime] desc");
                    break;

                case 3:
                    cacheAsDataTable = new Views.V_Questions().Open("", "SiteID = " + base._Site.ID.ToString() + " and UserID = " + base._User.ID.ToString() + " and UseType = 1 and AnswerStatus = 1", "[DateTime] desc");
                    break;
            }
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache("MemberQuestionList_" + Type.ToString() + "_" + base._User.ID.ToString(), cacheAsDataTable);
        }
        PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
    }

    protected void btnType_1_Click(object sender, EventArgs e)
    {
        int type = _Convert.StrToInt(((LinkButton)sender).ID.Substring(8, 1), 1);
        this.ViewState["MemberQuestionList_Type"] = type;
        this.BindData(type);
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[2].Text = "<a href='QuestionList.aspx?id=" + e.Item.Cells[4].Text + "'><font color=\"#330099\">" + e.Item.Cells[2].Text + "</Font></a>";
            switch (_Convert.StrToShort(e.Item.Cells[5].Text, 0))
            {
                case 0:
                    e.Item.Cells[3].Text = "未答复";
                    return;

                case 1:
                    e.Item.Cells[3].Text = "处理中";
                    return;
            }
            e.Item.Cells[3].Text = "<font color='red'>已答复</font>";
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
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
        if (base.IsPostBack)
        {
            return;
        }
        this.labUserName.Text = base._User.Name;
        long num = _Convert.StrToLong(Utility.GetRequest("id"), 0L);
        if (num > 0L)
        {
            DataTable table = new Views.V_Questions().Open("", "id = " + num.ToString(), "");
            if ((table == null) || (table.Rows.Count == 0))
            {
                PF.GoError(4, "数据库繁忙，请重试", "Room_QuestionList");
                return;
            }
            if (table.Rows.Count > 0)
            {
                this.labContent.Text = table.Rows[0]["Content"].ToString();
                this.labAnswer.Text = table.Rows[0]["Answer"].ToString();
                switch (_Convert.StrToShort(table.Rows[0]["AnswerStatus"].ToString(), 0))
                {
                    case 0:
                        this.labAnswerDateTime.Text = "未答复";
                        goto Label_0173;

                    case 1:
                        this.labAnswerDateTime.Text = "处理中";
                        goto Label_0173;
                }
                this.labAnswerDateTime.Text = "(答复时间：" + table.Rows[0]["AnswerDateTime"].ToString() + ")";
            }
        }
    Label_0173:
        this.btnType_1_Click(this.btnType_1, e);
    }
}

