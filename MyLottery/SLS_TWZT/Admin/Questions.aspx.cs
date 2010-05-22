using ASP;
using DAL;
using Shove;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Questions : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        string str = "select * from V_Questions";
        bool flag = false;
        if (this.rb2.Checked)
        {
            str = str + " where AnswerStatus = " + ((short)2).ToString();
            flag = true;
        }
        if (this.rb3.Checked)
        {
            str = str + " where AnswerStatus = " + ((short)0).ToString();
            flag = true;
        }
        if (this.ddlType.SelectedIndex > 0)
        {
            if (!flag)
            {
                str = str + " where ";
            }
            else
            {
                str = str + " and ";
            }
            str = str + " TypeID = " + this.ddlType.SelectedValue;
        }
        DataTable dt = MSSQL.Select(str + " order by UserID, [DateTime]", new MSSQL.Parameter[0]);
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_Questions");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
        }
    }

    private void BindDataForType()
    {
        DataTable table = new Tables.T_QuestionTypes().Open("", "UseType = 1", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_Questions");
        }
        else
        {
            this.ddlType.Items.Clear();
            this.ddlType.Items.Add(new ListItem("--选择问题类型--", "-1"));
            foreach (DataRow row in table.Rows)
            {
                this.ddlType.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
            }
        }
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Answer")
        {
            base.Response.Redirect("QuestionAnswer.aspx?ID=" + e.Item.Cells[6].Text + "&UserID=" + e.Item.Cells[7].Text, true);
        }
        else if (e.CommandName == "Del")
        {
            int returnValue = -1;
            string returnDescription = "";
            if (Procedures.P_QuestionsDelete(base._Site.ID, long.Parse(e.Item.Cells[6].Text), ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_Questions");
            }
            else if (returnValue < 0)
            {
                PF.GoError(1, returnDescription, "Admin_Questions");
            }
            else
            {
                this.BindData();
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[4].FindControl("cbAnswered");
            box.Checked = _Convert.StrToShort(e.Item.Cells[8].Text, -1) == 2;
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

    protected override void OnLoad(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "MemberService", "QueryData" });
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForType();
            this.BindData();
            this.g.Columns[5].Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "MemberService" }));
        }
    }

    protected void rb1_CheckedChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

 
}

