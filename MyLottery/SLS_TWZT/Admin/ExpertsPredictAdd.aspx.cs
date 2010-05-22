using ASP;
using DAL;
using Shove._IO;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ExpertsPredictAdd : AdminPageBase, IRequiresSessionState
{
    private void BindData()
    {
        this.ddlImage.Items.Clear();
        this.ddlImage.Items.Add("--选择图片--");
        string path = base.Server.MapPath("../Private/" + base._Site.ID.ToString() + "/ExpertsImages");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else
        {
            string[] fileList = Shove._IO.File.GetFileList(path);
            if (fileList != null)
            {
                for (int i = 0; i < fileList.Length; i++)
                {
                    this.ddlImage.Items.Add(fileList[i]);
                }
            }
        }
    }

    private void BindLotteryType()
    {
        DataTable table = new Tables.T_Lotteries().Open("[ID], [Name], [Code]", "[ID] in(" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-46)");
        }
        else
        {
            this.ddlLotteries.DataSource = table;
            this.ddlLotteries.DataTextField = "Name";
            this.ddlLotteries.DataValueField = "ID";
            this.ddlLotteries.DataBind();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string str = this.tbName.Text.Trim();
        if (str == "")
        {
            JavaScript.Alert(this.Page, "请输入专家姓名！");
        }
        else if (new Tables.T_Users().GetCount("Name='" + this.tbName.Text.Trim() + "'") == 0L)
        {
            JavaScript.Alert(this.Page, "用户名不存在！");
        }
        else
        {
            string text = "";
            if (this.ddlImage.SelectedIndex > 0)
            {
                text = this.ddlImage.SelectedItem.Text;
            }
            string str3 = this.tbDescription.Text.Trim();
            if (str3 == "")
            {
                JavaScript.Alert(this.Page, "请输入专家描述！");
            }
            else if (new Tables.T_ExpertsPredict { ON = { Value = this.cbisShow.Checked }, Name = { Value = str }, LotteryID = { Value = this.ddlLotteries.SelectedValue }, URL = { Value = text }, Description = { Value = str3 } }.Insert() < 0L)
            {
                JavaScript.Alert(this, "添加失败");
            }
            else
            {
                Shove._Web.Cache.ClearCache("Default_GetExpertsPredict");
                JavaScript.Alert(this, "添加成功", "ExpertsPredict.aspx");
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("ExpertsPredict.aspx", true);
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
            this.BindLotteryType();
            this.BindData();
        }
    }


}

