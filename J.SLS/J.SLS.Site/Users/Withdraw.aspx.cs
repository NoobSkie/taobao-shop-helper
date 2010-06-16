using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SLS.Facade;
using J.SLS.Common.Exceptions;
using Shove._Web;

public partial class Users_Withdraw : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentUser == null)
        {
            RedirectToLogin(this.Page, "请登录系统。");
        }
        if (!IsPostBack)
        {
            txtBankName.Text = CurrentUser.BankName;
            txtAccount.Text = CurrentUser.BankCardNumber;
            txtMoney.Text = "";
            lblMoneyDesc.Text = string.Format("{0:0.00}(账户余额:{1:0.00},冻结:{2:0.00})", CurrentUser.EnableMoney, CurrentUser.Balance, CurrentUser.Freeze);
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            UserFacade facade = new UserFacade();
            facade.RequestGetMoney(CurrentUser.UserId, 1, txtBankName.Text, txtAccount.Text, decimal.Parse(txtMoney.Text));
            CurrentUser.Freeze += decimal.Parse(txtMoney.Text);
            JavaScript.Alert(this.Page, "提款申请已提交，系统将在2个工作日内处理！", "");
        }
        catch (FacadeException ex)
        {
            JavaScript.Alert(this.Page, ex.Message);
        }
        catch
        {
            JavaScript.Alert(this.Page, "发送提款申请失败，请重试。如果继续错误，联系管理人员！");
        }
    }
}
