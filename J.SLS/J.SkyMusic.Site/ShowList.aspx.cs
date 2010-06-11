using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class ShowList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            string listId = Request["id"];
            if (!string.IsNullOrEmpty(listId))
            {
                IList<HtmlItemInfo> htmlList = facade.GetHtmlItemsByParent(listId);
                rptList.DataSource = htmlList;
                rptList.DataBind();
            }
        }
    }

    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlItemInfo htmlItem = e.Item.DataItem as HtmlItemInfo;
            HyperLink hlnkName = e.Item.FindControl("hlnkName") as HyperLink;
            Image imgNew = e.Item.FindControl("imgNew") as Image;
            Label lblUpdateTime = e.Item.FindControl("lblUpdateTime") as Label;
            hlnkName.Text = htmlItem.Name;
            string p = "";
            if (!string.IsNullOrEmpty(Request["m1"]))
            {
                p += "&m1=" + Request["m1"];
            }
            if (!string.IsNullOrEmpty(Request["m2"]))
            {
                p += "&m2=" + Request["m2"];
            }
            hlnkName.NavigateUrl = string.Format("ShowContent.aspx?id={0}{1}", htmlItem.Id, p);
            if (htmlItem.LastUpdateTime.AddDays(7) > DateTime.Now)
            {
                imgNew.ToolTip = "new";
                imgNew.ImageUrl = "Images/new.gif";
            }
            else
            {
                imgNew.Visible = false;
            }
            lblUpdateTime.Text = htmlItem.LastUpdateTime.ToString("(yyyy-MM-dd HH:mm:ss)");
        }
    }
}
