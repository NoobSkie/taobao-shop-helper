using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;
using System.Configuration;

public partial class Admins_FileManagement : BaseAdminPage
{
    protected string CanUploadImageExtension = "";
    protected string CanUploadScriptExtension = "";
    protected string CanUploadStyleExtension = "";

    protected string AllowFileExtensions
    {
        get
        {
            List<string> list = new List<string>();
            list.AddRange(CanUploadImageExtension.Split(new char[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries));
            list.AddRange(CanUploadScriptExtension.Split(new char[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries));
            list.AddRange(CanUploadStyleExtension.Split(new char[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries));
            return string.Join(",", list.ToArray());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CanUploadImageExtension = ConfigurationManager.AppSettings["CanUploadImageExtension"].ToLower();
            CanUploadScriptExtension = ConfigurationManager.AppSettings["CanUploadScriptExtension"].ToLower();
            CanUploadStyleExtension = ConfigurationManager.AppSettings["CanUploadStyleExtension"].ToLower();

            ResFileFacade facade = PageHelper.GetResFileFacade(this.Page);
            IList<ResFileInfo> list = facade.GetImageFileList(".jpg", ".gif", ".png", ".tiff");
            rptFileList.DataSource = list;
            rptFileList.DataBind();
        }
    }

    protected void lbtnUpload_Click(object sender, EventArgs e)
    {
        string fileName = Server.MapPath("~/UploadFiles/Inner/a.jpg");
        fuFile.PostedFile.SaveAs(fileName);
        RedirectToUrl("FileManagement.aspx");
    }
}
