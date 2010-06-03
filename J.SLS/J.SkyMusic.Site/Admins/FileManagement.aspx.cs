using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Admins_FileManagement : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ResFileFacade facade = PageHelper.GetResFileFacade(this.Page);
            IList<ResFileInfo> list = facade.GetImageFileList(".jpg", ".gif", ".png", ".tiff");
            rptFileList.DataSource = list;
            rptFileList.DataBind();
        }
    }
}
