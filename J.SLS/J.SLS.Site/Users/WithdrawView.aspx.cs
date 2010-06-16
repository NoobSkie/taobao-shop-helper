using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SLS.Facade;

public partial class Users_WithdrawView : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentUser == null)
        {
            RedirectToLogin(this.Page, "请先登录系统！");
        }
        if (!IsPostBack)
        {
            UserFacade facade = new UserFacade();
            IList<RequestGetMoneyInfo> requestList = facade.GetRequestMoneyList(CurrentUser.UserId);
            gvRequestList.DataSource = requestList;
            gvRequestList.DataBind();
        }
    }
    protected void gvRequestList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RequestGetMoneyInfo requestItem = e.Row.DataItem as RequestGetMoneyInfo;
            Label lblStatus = e.Row.FindControl("lblStatus") as Label;
            switch (requestItem.Status)
            {
                case J.SLS.Common.MoneyGetStatus.Requesting:
                    lblStatus.Text = "审核中";
                    break;
                case J.SLS.Common.MoneyGetStatus.Accepted:
                    lblStatus.Text = "已提款";
                    break;
                case J.SLS.Common.MoneyGetStatus.Rejected:
                    lblStatus.Text = "被拒绝 - " + requestItem.ResponseMessage;
                    break;
            }
        }
    }
}
