using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;
using J.SLS.Common.Exceptions;

public partial class Admins_NoticeManagement : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NoticeFacade facade = new NoticeFacade();
            IList<NoticeInfo> list = facade.GetAllNoticeList();
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
                NoticeFacade facade = new NoticeFacade();
                string listId = e.CommandArgument.ToString();
                facade.DeleteNotice(listId);
                JavascriptAlertAndRedirect("删除通知成功！", "NoticeManagement.aspx");
            }
            catch (FacadeException ex)
            {
                JavascriptAlert(ex.Message);
            }
            catch
            {
                JavascriptAlert(@"删除通知发生未知错误，请联系系统配置人员！");
            }
        }
    }
}
