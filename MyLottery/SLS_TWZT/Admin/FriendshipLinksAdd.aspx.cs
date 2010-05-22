using ASP;
using DAL;
using Shove;
using Shove._IO;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_FriendshipLinksAdd : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.ddlImage.Items.Clear();
        this.ddlImage.Items.Add("--选择图片--");
        string path = base.Server.MapPath("../Private/" + base._Site.ID.ToString() + "/FriendshipLinks");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else
        {
            string[] fileList = Shove._IO.File.GetFileList(path);
            if (fileList != null)
            {
                for (int i = 0; i < fileList.Length; i++)
                {
                    this.ddlImage.Items.Add(fileList[i]);
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string linkName = this.tbName.Text.Trim();
        if (linkName == "")
        {
            JavaScript.Alert(this.Page, "请输入友情链接名称。");
        }
        else
        {
            string url = this.tbUrl.Text.Trim();
            if (url == "")
            {
                JavaScript.Alert(this.Page, "请输入友情链接网址。");
            }
            else
            {
                int order = _Convert.StrToInt(this.tbOrder.Text, 0);
                string shortFileName = "";
                if (this.tbImage.Value.Trim() != "")
                {
                    string path = base.Server.MapPath("../Private/" + base._Site.ID.ToString() + "/FriendshipLinks");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (Shove._IO.File.UploadFile(this.Page, this.tbImage, "../Private/" + base._Site.ID.ToString() + "/FriendshipLinks/", ref shortFileName, true, "image") != 0)
                    {
                        JavaScript.Alert(this.Page, "图片文件上传错误！");
                        return;
                    }
                }
                else if (this.ddlImage.SelectedIndex > 0)
                {
                    shortFileName = this.ddlImage.SelectedItem.Text;
                }
                long newFriendshipLinkID = -1L;
                string returnDescription = "";
                if (Procedures.P_FriendshipLinkAdd(base._Site.ID, linkName, shortFileName, url, order, this.cbisShow.Checked, ref newFriendshipLinkID, ref returnDescription) < 0)
                {
                    PF.GoError(4, "数据库繁忙，请重试", "Admin_FriendshipLinks");
                }
                else if (newFriendshipLinkID < 0L)
                {
                    JavaScript.Alert(this.Page, returnDescription);
                }
                else
                {
                    Shove._Web.Cache.ClearCache("T_FriendshipLinks_Default");
                    Shove._Web.Cache.ClearCache("T_FriendshipLinks_Links");
                    base.Response.Redirect("FriendshipLinks.aspx", true);
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }

}

