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

using Shove.Database;
using System.Text.RegularExpressions;

public partial class Admin_ImageNewsEdit : AdminPageBase
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

        RequestCompetences = Competences.BuildCompetencesList(Competences.EditNews);

        base.OnInit(e);
    }

    #endregion

    private void BindData()
    {
        long NewsID = Shove._Convert.StrToInt(Shove._Web.Utility.GetRequest("ID"), -1);

        if (NewsID < 0)
        {
            PF.GoError(ErrorNumber.Unknow, "参数错误", this.GetType().BaseType.FullName);

            return;
        }

        tbID.Value = NewsID.ToString();

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

        DataTable dt = new DAL.Tables.T_FocusImageNews().Open("", "[ID] = " + NewsID.ToString(), "");

        if (dt == null)
        {
            PF.GoError(ErrorNumber.DataReadWrite, "数据库繁忙，请重试", this.GetType().BaseType.FullName);

            return;
        }

        if (dt.Rows.Count > 0)
        {
            tbTitle.Text = dt.Rows[0]["Title"].ToString();
            tbContent.Text = dt.Rows[0]["Url"].ToString();
            cbIsBig.Checked = Shove._Convert.StrToBool(dt.Rows[0]["IsBig"].ToString(), false);

            Shove.ControlExt.SetDownListBoxText(ddlImage, dt.Rows[0]["ImageUrl"].ToString());
            tbOldImage.Text = dt.Rows[0]["ImageUrl"].ToString().Trim();

            if (dt.Rows[0]["ImageUrl"].ToString().Trim() == "")
            {
                cbNoEditImage.Checked = false;
                cbNoEditImage.Visible = false;
            }
        }
    }
    protected void btnSave_Click(object sender, System.EventArgs e)
    {
        string Title = tbTitle.Text.Trim();

        if (Title == "")
        {
            Shove._Web.JavaScript.Alert(this.Page, "请输入标题。");

            return;
        }

        string Image = "";

        if (cbNoEditImage.Checked)
        {
            Image = tbOldImage.Text;
        }
        else
        {
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

        f.Update("ID="+tbID.Value);

        Shove._Web.Cache.ClearCache("Home_Room_UserControls_Index_banner_ImagePlay");

        Response.Redirect("ImageNews.aspx");
    }
}
