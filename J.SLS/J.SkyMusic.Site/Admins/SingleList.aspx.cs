using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class Admins_SingleList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            IList<HtmlItemInfo> list = facade.GetHtmlItemsByParent(null);
            rptHtmlList.DataSource = list;
            rptHtmlList.DataBind();
            hlnkAddSub.NavigateUrl = "EditContent.aspx";
        }
    }
}
