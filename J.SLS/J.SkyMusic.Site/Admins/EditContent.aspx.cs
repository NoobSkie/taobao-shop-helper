using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Admins_EditContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        string name1 = txtName.Text.Trim();
        string name2 = txtListName.Text.Trim();
        if (string.IsNullOrEmpty(name2))
        {
            name2 = name1;
        }
        string title = txtTitle.Text.Trim();
        if (string.IsNullOrEmpty(title))
        {
            title = name1;
        }
        string content = txtContent.Text;
        HtmlItem html = new HtmlItem();
        html.Id = Guid.NewGuid().ToString("N").ToUpper();
        html.Name = name1;
        html.ListName = name2;
        html.Title = title;
        html.Content = content;
        PageFacade facade = PageHelper.GetPageFacade(this.Page);
        facade.AddContent(html);
    }
}
