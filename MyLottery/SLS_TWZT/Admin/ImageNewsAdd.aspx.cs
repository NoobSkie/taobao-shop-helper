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

public partial class Admin_ImageNewsAdd : AdminPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindData();
        }
    }

    #region Web 窗体设计器生成的代码

    protected override void OnLoad(EventArgs e)
    {
        RequestLoginPage = this.Request.Url.AbsoluteUri;

        RequestCompetences = Competences.BuildCompetencesList(Competences.EditNews);

        base.OnLoad(e);
    }

    #endregion

    private void BindData()
    {
        ddlImage.Items.Clear();
        ddlImage.Items.Add("--选择图片--");

        string UploadPath = this.Server.MapPath("../Private/" + _Site.ID.ToString() + "/NewsImages");

        if (!System.IO.Directory.Exists(UploadPath))
        {
            System.IO.Directory.CreateDirectory(UploadPath);
        }
        else
        {
            string[] FileList = Shove._IO.File.GetFileList(UploadPath);

            if (FileList != null)
            {
                for (int i = 0; i < FileList.Length; i++)
                {
                    ddlImage.Items.Add(FileList[i]);
                }
            }
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

        string Image = "";

        if (tbImage.Value.Trim() != "")
        {
            string UploadPath = this.Server.MapPath("../Private/" + _Site.ID.ToString() + "/NewsImages");

            if (!System.IO.Directory.Exists(UploadPath))
            {
                System.IO.Directory.CreateDirectory(UploadPath);
            }

            if (Shove._IO.File.UploadFile(this.Page, tbImage, "../Private/" + _Site.ID.ToString() + "/NewsImages/", ref Image, true, "image") != 0)
            {
                Shove._Web.JavaScript.Alert(this.Page, "图片文件上传错误！");

                return;
            }
        }
        else
        {
            if (ddlImage.SelectedIndex > 0)
            {
                Image = ddlImage.SelectedItem.Text;
            }
        }
    
        string UC = tbContent.Text.Trim();

        Regex regex = new Regex(@"([\w-]+\.)+[\w-]+.([^a-z])(/[\w- ./?%&=]*)?|[a-zA-Z0-9\-\.][\w-]+.([^a-z])(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        Match m = regex.Match(UC);

        if (!m.Success)
        {
            Shove._Web.JavaScript.Alert(this, "地址格式错误，请仔细检查。");

            return;
        }

        DAL.Tables.T_FocusImageNews f = new DAL.Tables.T_FocusImageNews();

        f.Title.Value = Title;
        f.Url.Value = UC;
        f.ImageUrl.Value = Image;
        f.IsBig.Value = cbIsBig.Checked;

        f.Insert();

        Shove._Web.Cache.ClearCache("Home_Room_UserControls_Index_banner_ImagePlay");

        Response.Redirect("ImageNews.aspx");
    }
}
