using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;
using J.SLS.Common.Exceptions;

public partial class Admins_ListManagement : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            IList<ListItemInfo> list = facade.GetListItems();
            rptList.DataSource = list;
            rptList.DataBind();
        }
    }

    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            try
            {
                PageFacade facade = PageHelper.GetPageFacade(this.Page);
                string listId = e.CommandArgument.ToString();
                IList<HtmlItemInfo> listItem = facade.GetHtmlItemsByParent(listId);
                if (listItem.Count > 0)
                {
                    JavascriptAlert("此列表包含有子页面，请先删除列表下的全部子页面。");
                    return;
                }
                facade.DeleteList(listId);
                JavascriptAlertAndRedirect("删除列表成功！", "ListManagement.aspx");
            }
            catch (FacadeException ex)
            {
                JavascriptAlert(ex.Message);
            }
            catch
            {
                JavascriptAlert(@"删除列表发生未知错误，请联系系统配置人员！");
            }
        }
    }
}
