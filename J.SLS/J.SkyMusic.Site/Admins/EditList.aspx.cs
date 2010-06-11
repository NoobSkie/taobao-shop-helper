using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;
using J.SLS.Common.Exceptions;

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
                ListItemInfo listItem = facade.GetListItemById(id);
                if (listItem != null)
                {
                    lblTitle.Text = "编辑列表 - " + listItem.Name;
                    txtName.Text = listItem.Name;
                }
                else
                {
                    lblTitle.Text = "编辑列表 - 发生错误";
                    lblInformation.Visible = true;
                    lblInformation.Text = "此列表不存在，可能已经被删除！";
                    lblInformation.CssClass = "Error";

                    hlnkAddSub.Enabled = false;
                    lbtnSave.Enabled = false;
                    return;
                }
                IList<HtmlItemInfo> list = facade.GetHtmlItemsByParent(id);
                rptHtmlList.DataSource = list;
                rptHtmlList.DataBind();
                lbtnSave.Text = "<span>修改列表名称</span>";
                hlnkAddSub.NavigateUrl = "EditContent.aspx?lid=" + id;
            }
            else
            {
                lblTitle.Text = "新增列表页面";
                lbtnSave.Text = "<span>新增列表</span>";
                hlnkAddSub.Visible = false;
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
        string name = txtName.Text;
        if (name.Trim() == "")
        {
            JavascriptAlert("请填入列表名称！");
            return;
        }
        try
        {
            string msg, url;
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            if (IsAdd)
            {
                ListItemInfo list = new ListItemInfo();
                list.Name = name;
                facade.AddList(list);

                msg = string.Format("添加列表成功 - \"{0}\"", name);
                url = "EditList.aspx?id=" + list.Id;
                JavascriptAlertAndRedirectAndRefreshParent(msg, url);
            }
            else
            {
                ListItemInfo list = facade.GetListItemById(Request["id"]);
                if (list == null)
                {
                    JavascriptAlert("失败 - 此列表不存在，可能已经被删除！");
                    return;
                }
                list.Name = name;
                facade.ModifyListName(Request["id"], name);
                msg = string.Format("修改列表成功 - \"{0}\"", name);
                url = "EditList.aspx?id=" + list.Id;
                JavascriptAlertAndRedirect(msg, url);
            }
        }
        catch (FacadeException ex)
        {
            JavascriptAlert(ex.Message);
        }
        catch
        {
            JavascriptAlert(@"保存列表发生未知错误，请联系系统配置人员！");
        }
    }
}
