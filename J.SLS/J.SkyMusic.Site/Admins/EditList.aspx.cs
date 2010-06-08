using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Admins_EditList : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            if (!IsAdd)
            {
                lblNameTag.Visible = false;
                string id = Request["id"];
                J.SkyMusic.Facade.ListItem listItem = facade.GetListItemById(id);
                if (listItem != null)
                {
                    txtName.Text = listItem.Name;
                    IList<HtmlItem> list = facade.GetHtmlItemsByParent(listItem.SubDbFileName, 0, 10);
                    rptHtmlList.DataSource = list;
                    rptHtmlList.DataBind();
                }
            }
        }
    }

    private bool IsAdd
    {
        get
        {
            return string.IsNullOrEmpty(Request["id"]);
        }
    }

    protected void lbtnSave_Click(object sender, EventArgs e)
    {

    }
}
