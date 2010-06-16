using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SLS.Common.Exceptions;
using Shove._Web;
using J.SLS.Facade;

public partial class Admin_ResponseGetMoneyView : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request["rid"];
            if (string.IsNullOrEmpty(id))
            {
                RedirectToUrl("ResponseGetMoney.aspx");
            }
            UserFacade facade = new UserFacade();
            RequestGetMoneyInfo request = facade.GetRequestMoneyInfo(long.Parse(Request["rid"]));
            if (request == null)
            {
                JavaScript.Alert(this.Page, "错误 - 指定的提款请求不存在！", "ResponseGetMoney.aspx");
            }
            else
            {
                lblUser.Text = request.UserName;
                lblMoney.Text = request.RequestMoney.ToString("0.00");
                lblBankName.Text = request.BankName;
                lblCardNumber.Text = request.BankCardNumber;
                lblTime.Text = request.RequestTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        try
        {
            string message = txtReason.Text;
            if (message.Trim() == "")
            {
                message = "请求已受理";
            }
            UserFacade facade = new UserFacade();
            facade.AcceptRequestGetMoney(long.Parse(Request["rid"]), CurrentUser.UserId, message);

            JavaScript.Alert(this.Page, "请求已被受理！", "ResponseGetMoney.aspx");
        }
        catch (FacadeException ex)
        {
            JavaScript.Alert(this.Page, ex.Message);
        }
        catch
        {
            JavaScript.Alert(this.Page, "发生未知异常，请联系管理员！");
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        try
        {
            string message = txtReason.Text;
            if (message.Trim() == "")
            {
                message = "请求已拒绝";
            }
            UserFacade facade = new UserFacade();
            facade.RejectRequestGetMoney(long.Parse(Request["rid"]), CurrentUser.UserId, message);

            JavaScript.Alert(this.Page, "请求已被拒绝！", "ResponseGetMoney.aspx");
        }
        catch (FacadeException ex)
        {
            JavaScript.Alert(this.Page, ex.Message);
        }
        catch
        {
            JavaScript.Alert(this.Page, "发生未知异常，请联系管理员！");
        }
    }
}
