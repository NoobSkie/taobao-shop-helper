using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class ShowContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            string htmlId = Request["id"];
            if (!string.IsNullOrEmpty(htmlId))
            {
                HtmlItemFullInfo htmlInfo = facade.GetHtmlItemById(htmlId);
                if (htmlInfo != null)
                {
                    lblTitle.Text = htmlInfo.Title;
                    lblContent.Text = htmlInfo.Content;
                    lblCreateTime.Text = htmlInfo.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    lblUpdateTime.Text = htmlInfo.LastUpdateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }
    }
}
