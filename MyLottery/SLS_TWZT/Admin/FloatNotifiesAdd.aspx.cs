using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Text.RegularExpressions;

public partial class Admin_FloatNotifiesAdd : AdminPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        RequestLoginPage = this.Request.Url.AbsoluteUri;

        RequestCompetences = Competences.BuildCompetencesList(Competences.FillContent);

        base.OnInit(e);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string Title = tbName.Text.Trim();

        if (Title == "")
        {
            Shove._Web.JavaScript.Alert(this.Page, "请输入广告标题！");

            return;
        }

        string Url = tbUrl.Text.Trim();

        Regex regex = new Regex(@"([\w-]+\.)+[\w-]+.([^a-z])(/[\w- ./?%&=]*)?|[a-zA-Z0-9\-\.][\w-]+.([^a-z])(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        Match m = regex.Match(Url);

        if (!m.Success)
        {
            Shove._Web.JavaScript.Alert(this, "输入的URL地址格式错误，请仔细检查。");

            return;
        }

        int order = Shove._Convert.StrToInt(tbOrder.Text.Trim(), -1);

        if (order < 0)
        {
            Shove._Web.JavaScript.Alert(this.Page, "顺序输入非法！");

            return;
        }

        DAL.Tables.T_FloatNotify fn = new DAL.Tables.T_FloatNotify();

        string color = Shove._Web.Utility.GetRequest("highlight_color");

        if (color == "")
        {
            color = "#000000";
        }

        fn.Order.Value = order;
        fn.Url.Value = Url;
        fn.Title.Value = Title;
        fn.Color.Value = color;

        long Result = fn.Insert();

        if (Result > 0)
        {
            //清除缓存
            string CacheKey = "FloatNotifyContent";
            Shove._Web.Cache.ClearCache(CacheKey);

            Shove._Web.JavaScript.Alert(this, "添加成功", "FloatNotifies.aspx");
        }
        else
        {
            Shove._Web.JavaScript.Alert(this, "添加失败");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("FloatNotifies.aspx", true);
    }
}
