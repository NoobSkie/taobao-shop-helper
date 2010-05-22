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

public partial class Admin_NewsEdit : AdminPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindDataForType();

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

    private void BindDataForType()
    {
        DataTable dt = new DAL.Tables.T_NewsTypes().Open("", "SiteID = " + _Site.ID.ToString(), "[ID]");

        if (dt == null)
        {
            PF.GoError(ErrorNumber.DataReadWrite, "数据库繁忙，请重试", this.GetType().BaseType.FullName);

            return;
        }

        Shove.ControlExt.FillDropDownList(ddlTypes, dt, "Name", "ID");

        string TypeID = Shove._Web.Utility.GetRequest("TypeID");

        if (TypeID != "")
        {
            Shove.ControlExt.SetDownListBoxTextFromValue(ddlTypes, TypeID);
        }
    }

    private void BindData()
    {
        long NewsID = Shove._Convert.StrToLong(Shove._Web.Utility.GetRequest("id"), -1);

        if (NewsID < 0)
        {
            PF.GoError(ErrorNumber.Unknow, "参数错误", this.GetType().BaseType.FullName);

            return;
        }

        tbID.Text = NewsID.ToString();

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

        DataTable dt = new DAL.Tables.T_News().Open("", "SiteID = " + _Site.ID.ToString() + " and [ID] = " + NewsID.ToString(), "");

        if (dt == null)
        {
            PF.GoError(ErrorNumber.DataReadWrite, "数据库繁忙，请重试", this.GetType().BaseType.FullName);

            return;
        }

        if (dt.Rows.Count > 0)
        {
            tbDateTime.Text = dt.Rows[0]["DateTime"].ToString();
            tbReadCount.Text = dt.Rows[0]["ReadCount"].ToString();
            cbisShow.Checked = Shove._Convert.StrToBool(dt.Rows[0]["isShow"].ToString(), true);
            cbisCanComments.Checked = Shove._Convert.StrToBool(dt.Rows[0]["isCanComments"].ToString(), true);
            cbisCommend.Checked = Shove._Convert.StrToBool(dt.Rows[0]["isCommend"].ToString(), false);
            cbisHot.Checked = Shove._Convert.StrToBool(dt.Rows[0]["isHot"].ToString(), false);
            tbTitle.Text = dt.Rows[0]["Title"].ToString();
            if (tbTitle.Text.IndexOf("<font class=red12>") > -1)
            {
                ddlTitleColor.Items[1].Selected = true;
                ddlTitleColor.Items[2].Selected = false;
                ddlTitleColor.Items[0].Selected = false;
                tbTitle.Text = tbTitle.Text.Replace("<font class=red12>", "").Replace("</font>", "");
            }
            else if (tbTitle.Text.IndexOf("<font class=black12>") > -1)
            {
                ddlTitleColor.Items[2].Selected = true;
                ddlTitleColor.Items[1].Selected = false;
                ddlTitleColor.Items[0].Selected = false;
                tbTitle.Text = tbTitle.Text.Replace("<font class=black12>", "").Replace("</font>", "");
            }
            else
            {
                ddlTitleColor.Items[0].Selected = true;
                ddlTitleColor.Items[2].Selected = false;
                ddlTitleColor.Items[1].Selected = false;
            }
            tbContent.Text = dt.Rows[0]["Content"].ToString();

            //Regex regex = new Regex(@"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Match m = regex.Match(UC);

            //if (m.Success)
            //{
            //    trContent.Visible = false;

            //    tbUrl.Text = UC;
            //    rblType.SelectedValue = "1";
            //}
            //else
            //{
            //    trUrl.Visible = false;

            //    tbContent.Text = UC;
            //    rblType.SelectedValue = "2";
            //}

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
        DateTime dt = System.DateTime.Now;

        try
        {
            dt = System.DateTime.Parse(tbDateTime.Text);
        }
        catch
        {
            Shove._Web.JavaScript.Alert(this.Page, "时间格式错误，请输入如“" + dt.ToString() + "”的时间格式。");

            return;
        }

        long ReadCount = Shove._Convert.StrToLong(tbReadCount.Text, -1);

        if (ReadCount < 0)
        {
            Shove._Web.JavaScript.Alert(this.Page, "请输入正确的已阅读次数。");

            return;
        }

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

        int ReturnValue = -1;
        string ReturnDescription = "";
        string UC = tbContent.Text.Trim();

        Regex regex = new Regex(@"([\w-]+\.)+[\w-]+.([^a-z])(/[\w- ./?%&=]*)?|[a-zA-Z0-9\-\.][\w-]+.([^a-z])(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        Match m = regex.Match(UC);

        if (!m.Success)
        {
            Shove._Web.JavaScript.Alert(this, "地址格式错误，请仔细检查。");

            return;
        }

        //if (rblType.SelectedValue == "1")
        //{
        //    UC = tbUrl.Text.Trim();

        //    Regex regex = new Regex(@"([\w-]+\.)+[\w-]+.([^a-z])(/[\w- ./?%&=]*)?|[a-zA-Z0-9\-\.][\w-]+.([^a-z])(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        //    Match m = regex.Match(UC);

        //    if (!m.Success)
        //    {
        //        Shove._Web.JavaScript.Alert(this, "地址格式错误，请仔细检查。");

        //        return;
        //    }
        //}
        //else
        //{
        //    UC = tbContent.Text.Trim();
        //}

        if (string.IsNullOrEmpty(UC))
        {
            Shove._Web.JavaScript.Alert(this.Page, "请输入内容！");

            return;
        }

        if (ddlTitleColor.SelectedValue == "red")
        {
            Title = "<font class='red12'>" + Title + "</font>";
        }
        else if (ddlTitleColor.SelectedValue == "black")
        {
            Title = "<font class='black12'>" + Title + "</font>";
        }

        if (Shove._String.GetLength(Title) > 100)
        {
            Shove._Web.JavaScript.Alert(this.Page, "标题长度超过限制！");

            return;
        }

        int Results = -1;
        Results = DAL.Procedures.P_NewsEdit(_Site.ID, long.Parse(tbID.Text), int.Parse(ddlTypes.SelectedValue), dt, Title, UC, Image, cbisShow.Checked, (Image != ""), cbisCanComments.Checked, cbisCommend.Checked, cbisHot.Checked, ReadCount, ref ReturnValue, ref ReturnDescription);
        if (Results < 0)
        {
            PF.GoError(ErrorNumber.DataReadWrite, "数据库繁忙，请重试", this.GetType().BaseType.FullName);

            return;
        }

        if (ReturnValue < 0)
        {
            Shove._Web.JavaScript.Alert(this.Page, ReturnDescription);

            return;
        }

        string type = ddlTypes.SelectedItem.Text.Trim();

        if (type == "福彩资讯" || type == "体彩资讯" || type == "足彩资讯")
        {
            Shove._Web.Cache.ClearCache("Default_GetNews");
        }

        if (type.Contains("3D"))
        {
            Shove._Web.Cache.ClearCache("Home_Room_Buy_BindNewsForLotterys6");
            Shove._Web.Cache.ClearCache("Home_Room_Buy_BindNewsForLottery6");
        }

        if (type.Contains("双色球"))
        {
            Shove._Web.Cache.ClearCache("Home_Room_Buy_BindNewsForLotterys5");
            Shove._Web.Cache.ClearCache("Home_Room_Buy_BindNewsForLottery5");
        }

        if (type.Contains("玩法攻略"))
        {
            Shove._Web.Cache.ClearCache("Default_BindWFGL");
        }

        string cacheKey = "";
        switch (ddlTypes.SelectedItem.Text)
        {
            case "热门人物追踪":
                cacheKey = "Home_Room_JoinAllBuy_BindNews";
                break;
            case "时时乐资讯":
                cacheKey = DataCache.LotteryNews + "29";
                break;
            case "十一运夺金资讯":
                cacheKey = DataCache.LotteryNews + "62";
                break;
            case "双色球资讯":
                cacheKey = DataCache.LotteryNews + "5";
                break;
            case "3D资讯":
                cacheKey = DataCache.LotteryNews + "6";
                break;
            case "超级大乐透资讯":
                cacheKey = DataCache.LotteryNews + "39";
                break;
            case "排列3/5资讯":
                cacheKey = DataCache.LotteryNews + "63";
                Shove._Web.Cache.ClearCache(DataCache.LotteryNews + "64");
                break;
            case "足彩资讯":
                cacheKey = DataCache.LotteryNews + "1";
                Shove._Web.Cache.ClearCache(DataCache.LotteryNews + "2");
                Shove._Web.Cache.ClearCache(DataCache.LotteryNews + "15");
                break;

        }

        if (cacheKey != "")
        {
            Shove._Web.Cache.ClearCache(cacheKey);  
        }

        this.Response.Redirect("News.aspx?TypeID=" + ddlTypes.SelectedValue, true);
    }

    //protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rblType.SelectedValue == "1")
    //    {
    //        trUrl.Visible = true;
    //        trContent.Visible = false;
    //    }
    //    else
    //    {
    //        trUrl.Visible = false;
    //        trContent.Visible = true;
    //    }
    //}
}
