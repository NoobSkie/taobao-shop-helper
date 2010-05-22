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

public partial class Admin_FocusNewsAdd : AdminPageBase
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
        hID.Value = Shove._Web.Utility.GetRequest("ID");

        if (hID.Value != "")
        {
            DataTable dt = new DAL.Tables.T_FocusNews().Open("", "ID=" + hID.Value, "");

            if (dt == null || dt.Rows.Count == 0)
            {
                PF.GoError(ErrorNumber.NoData, "数据不存在或已被删除！", this.GetType().BaseType.FullName);

                return;
            }

            tbTitle.Text = dt.Rows[0]["Title"].ToString();
            tbContent.Text = dt.Rows[0]["Url"].ToString();
            tbOrder.Text = dt.Rows[0]["Order"].ToString();
            cbIsMaster.Checked = Shove._Convert.StrToBool(dt.Rows[0]["IsMaster"].ToString(), false);
        }
    }

    protected void btnAdd_Click(object sender, System.EventArgs e)
    {
        string Title = tbTitle.Text.Trim();

        if (Title == "")
        {
            Shove._Web.JavaScript.Alert(this.Page, "请输入标题。");

            return;
        }

        string UC = tbContent.Text.Trim();

        Regex regex = new Regex(@"([\w-]+\.)+[\w-]+.([^a-z])(/[\w- ./?%&=]*)?|[a-zA-Z0-9\-\.][\w-]+.([^a-z])(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        Match m = regex.Match(UC);

        if (!m.Success)
        {
            Shove._Web.JavaScript.Alert(this, "地址格式错误，请仔细检查。");

            return;
        }

        short order = Shove._Convert.StrToShort(tbOrder.Text.Trim(), 0);

        if (order < 1)
        {
            Shove._Web.JavaScript.Alert(this.Page, "排序只能是整数！");

            return;
        }

        DAL.Tables.T_FocusNews f = new DAL.Tables.T_FocusNews();

        f.Title.Value = Title;
        f.Url.Value = UC;
        f.Order.Value = tbOrder.Text;
        f.IsMaster.Value = cbIsMaster.Checked;
        long count = 0;

        if (hID.Value == "")
        {
            count = f.GetCount("IsMaster=1");

            if ((!cbIsMaster.Checked && count < 1) || (cbIsMaster.Checked && count > 0))
            {
                Shove._Web.JavaScript.Alert(this.Page, "有且只能有一个主标题！");

                return;
            }

            f.Insert();
        }
        else
        {
            count = f.GetCount("IsMaster=1 and ID<>" + hID.Value + "");

            if ((!cbIsMaster.Checked && count < 1) || (cbIsMaster.Checked && count > 0))
            {
                Shove._Web.JavaScript.Alert(this.Page, "有且只能有一个主标题！");

                return;
            }

            f.Update("ID="+hID.Value);
        }

        Shove._Web.Cache.ClearCache("Default_GetFocusNews");

        this.Response.Redirect("FocusNews.aspx", true);
    }

}
