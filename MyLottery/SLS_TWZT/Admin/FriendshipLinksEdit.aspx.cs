using ASP;
using DAL;
using Shove;
using Shove._IO;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_FriendshipLinksEdit : AdminPageBase, IRequiresSessionState
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
        long num2 = _Convert.StrToLong(Utility.GetRequest("id"), -1L);
        if (num2 < 0L)
        {
            PF.GoError(1, "参数错误", this.Page.GetType().BaseType.FullName);
        }
        else
        {
            this.tbID.Text = num2.ToString();
            DataTable table = new Tables.T_FriendshipLinks().Open("", "SiteID = " + base._Site.ID.ToString() + " and [ID] = " + num2.ToString(), "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else
            {
                this.tbName.Text = table.Rows[0]["LinkName"].ToString();
                this.cbisShow.Checked = _Convert.StrToBool(table.Rows[0]["isShow"].ToString(), true);
                this.tbOrder.Text = table.Rows[0]["Order"].ToString();
                this.tbUrl.Text = table.Rows[0]["Url"].ToString();
                ControlExt.SetDownListBoxText(this.ddlImage, table.Rows[0]["LogoUrl"].ToString());
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string str = this.tbName.Text.Trim();
        if (str == "")
        {
            JavaScript.Alert(this.Page, "请输入友情链接名称。");
        }
        else
        {
            string str2 = this.tbUrl.Text.Trim();
            if (str2 == "")
            {
                JavaScript.Alert(this.Page, "请输入友情链接网址。");
            }
            else
            {
                int num = _Convert.StrToInt(this.tbOrder.Text, 0);
                string shortFileName = "";
                if (!this.cbNoEditImage.Checked)
                {
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
                }
                Tables.T_FriendshipLinks links = new Tables.T_FriendshipLinks
                {
                    LinkName = { Value = str },
                    Url = { Value = str2 },
                    Order = { Value = num },
                    isShow = { Value = this.cbisShow.Checked }
                };
                if (!this.cbNoEditImage.Checked)
                {
                    links.LogoUrl.Value = shortFileName;
                }
                if (links.Update("[ID] = " + Utility.FilteSqlInfusion(this.tbID.Text)) < 0L)
                {
                    PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
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

