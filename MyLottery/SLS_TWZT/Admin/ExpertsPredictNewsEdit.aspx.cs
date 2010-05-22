using ASP;
using DAL;
using FreeTextBoxControls;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ExpertsPredictNewsEdit : AdminPageBase, IRequiresSessionState
{

    private void BindExpertsNewInfo()
    {
        DataTable table = new Tables.T_ExpertsPredictNews().Open("", "ID=" + Utility.FilteSqlInfusion(this.hidID.Value), "");
        if ((table == null) || (table.Rows.Count == 0))
        {
            JavaScript.Alert(this.Page, "记录不存在！");
        }
        else
        {
            this.cbisShow.Checked = _Convert.StrToBool(table.Rows[0]["ON"].ToString(), true);
            this.tbContent.Text = table.Rows[0]["Url"].ToString();
            this.tbDescription.Text = table.Rows[0]["Description"].ToString();
            this.ddlExpertsPredictNews.SelectedValue = table.Rows[0]["ExpertsPredictID"].ToString();
        }
    }

    private void BindExpertsPredict()
    {
        DataTable table = new Tables.T_ExpertsPredict().Open("", "", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-40)");
        }
        else
        {
            this.ddlExpertsPredictNews.DataSource = table;
            this.ddlExpertsPredictNews.DataTextField = "Name";
            this.ddlExpertsPredictNews.DataValueField = "ID";
            this.ddlExpertsPredictNews.DataBind();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string str = this.tbContent.Text.Trim();
        if (string.IsNullOrEmpty(str))
        {
            JavaScript.Alert(this.Page, "请输入内容！");
        }
        else
        {
            string str2 = this.tbDescription.Text.Trim();
            if (str2 == "")
            {
                JavaScript.Alert(this.Page, "请输入文字描述！");
            }
            else if (new Tables.T_ExpertsPredictNews { ON = { Value = this.cbisShow.Checked }, URL = { Value = str }, Description = { Value = str2 }, ExpertsPredictID = { Value = this.ddlExpertsPredictNews.SelectedValue }, isWinning = { Value = this.cbisWinning.Checked } }.Update("ID=" + Utility.FilteSqlInfusion(this.hidID.Value)) < 0L)
            {
                JavaScript.Alert(this, "修改失败");
            }
            else
            {
                Shove._Web.Cache.ClearCache("ExpertsPredictNews");
                Shove._Web.Cache.ClearCache("Default_GetExpertsPredictNews");
                JavaScript.Alert(this, "修改成功", "ExpertsPredictNews.aspx");
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("ExpertsPredictNews.aspx", true);
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.hidID.Value = _Convert.StrToLong(Utility.GetRequest("ID"), -1L).ToString();
            this.BindExpertsPredict();
            this.BindExpertsNewInfo();
        }
    }


}

