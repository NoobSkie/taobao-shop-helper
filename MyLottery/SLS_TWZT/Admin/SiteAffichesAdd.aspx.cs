using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class Admin_SiteAffichesAdd : AdminPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindData();
        }
    }

    #region Web 窗体设计器生成的代码

    override protected void OnInit(EventArgs e)
    {
        RequestLoginPage = this.Request.Url.AbsoluteUri;

        RequestCompetences = Competences.BuildCompetencesList(Competences.FillContent);

        base.OnInit(e);
    }

    #endregion

    private void BindData()
    {
        tbDateTime.Text = System.DateTime.Now.ToString();
    }

    protected void btnAdd_Click(object sender, System.EventArgs e)
    {
        DateTime dt = System.DateTime.Now;

        try
        {
            dt = System.DateTime.Parse(tbDateTime.Text);
        }
        catch
        {
            Shove._Web.JavaScript.Alert(this.Page, "时间格式错误，请输入如“" + dt.ToString() + "”的时间格式。");

            return;
        }

        string Title = tbTitle.Text.Trim();

        if (Title == "")
        {
            Shove._Web.JavaScript.Alert(this.Page, "请输入标题。");

            return;
        }

        long SiteAfficheID = -1;
        string ReturnDescription = "";
        string UC = tbContent.Text.Trim();

        Regex regex = new Regex(@"([\w-]+\.)+[\w-]+.([^a-z])(/[\w- ./?%&=]*)?|[a-zA-Z0-9\-\.][\w-]+.([^a-z])(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        Match m = regex.Match(UC);

        //if (!m.Success)
        //{
        //    Shove._Web.JavaScript.Alert(this, "地址格式错误，请仔细检查。");

        //    return;
        //}

        if (cbTitleRed.Checked)
        {
            Title = "<font class='red12'>" + Title + "</font>";
        }

        if (Shove._String.GetLength(Title) > 100)
        {
            Shove._Web.JavaScript.Alert(this.Page, "标题长度超过限制！");

            return;
        }

        int Results = -1;
        Results = DAL.Procedures.P_SiteAfficheAdd(_Site.ID, dt, Title, UC, cbisShow.Checked, cbisCommend.Checked, ref SiteAfficheID, ref ReturnDescription);
        if (Results < 0)
        {
            PF.GoError(ErrorNumber.DataReadWrite, "数据库繁忙，请重试", "Admin_SiteAffichesAdd");

            return;
        }

        if (SiteAfficheID < 0)
        {
            Shove._Web.JavaScript.Alert(this.Page, ReturnDescription);

            return;
        }
        Shove._Web.Cache.ClearCache(CacheKey.SiteAffiches);
        Shove._Web.Cache.ClearCache("Default_GetSiteAffiches");

        this.Response.Redirect("SiteAffiches.aspx", true);
    }

    //protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rblType.SelectedValue == "1")
    //    {
    //        trUrl.Visible = true;
    //        trContent.Visible = false;
    //    }
    //    else
    //    {
    //        trUrl.Visible = false;
    //        trContent.Visible = true;
    //    }
    //}

}
