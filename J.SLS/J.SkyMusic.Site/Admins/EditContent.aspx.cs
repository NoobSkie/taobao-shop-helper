using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;
using J.SLS.Common.Exceptions;

public partial class Admins_EditContent : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            string listId = Request["lid"];
            if (!string.IsNullOrEmpty(listId))
            {
                ListItemInfo listItem = facade.GetListItemById(listId);
                if (listItem != null)
                {
                    if (IsAdd)
                    {
                        lblTitle.Text = "添加子页面 -> " + listItem.Name;
                    }
                    else
                    {
                        string htmlId = Request["id"];
                        HtmlItemFullInfo htmlItem = facade.GetHtmlItemById(htmlId);
                        if (htmlItem != null)
                        {
                            BindHtmlInfo(htmlItem);
                            lblTitle.Text = "编辑页面 -> " + listItem.Name + " -> " + htmlItem.Name;
                        }
                    }
                }
            }
            else
            {
                if (IsAdd)
                {
                    lblTitle.Text = "添加独立子页面";
                }
                else
                {
                    string htmlId = Request["id"];
                    HtmlItemFullInfo htmlItem = facade.GetHtmlItemById(htmlId);
                    if (htmlItem != null)
                    {
                        BindHtmlInfo(htmlItem);
                        lblTitle.Text = "编辑页面 -> " + htmlItem.Name;
                    }
                }
            }
        }
    }

    private void BindHtmlInfo(HtmlItemFullInfo htmlItem)
    {
        txtName.Text = htmlItem.Name;
        txtTitle.Text = htmlItem.Title;
        txtContent.Text = htmlItem.Content;
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
        try
        {
            string name1 = txtName.Text.Trim();
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                title = name1;
            }
            string content = txtContent.Text;

            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            HtmlItemFullInfo html = new HtmlItemFullInfo();
            html.Name = name1;
            html.Title = title;
            html.Content = content;
            html.ItsListId = Request["lid"];

            string msg, url;
            if (IsAdd)
            {
                facade.AddHtml(html);
                msg = string.Format("添加页面成功 - \"{0}\"", name1);
            }
            else
            {
                html.Id = Request["id"];
                facade.ModifyHtml(html);
                msg = string.Format("修改页面成功 - \"{0}\"", name1);
            }
            if (string.IsNullOrEmpty(Request["lid"]))
            {
                url = "SingleList.aspx";
            }
            else
            {
                url = string.Format("EditList.aspx?id={0}", Request["lid"] ?? "");
            }
            JavascriptAlertAndRedirect(msg, url);
        }
        catch (FacadeException ex)
        {
            JavascriptAlert(ex.Message);
        }
        catch
        {
            JavascriptAlert(@"保存页面发生未知错误，请联系系统配置人员！");
        }
    }
}
