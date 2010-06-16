using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SLS.Facade;

public partial class Admin_ResponseGetMoney : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserFacade facade = new UserFacade();
            IList<RequestGetMoneyInfo> requestList = facade.GetUnhandleRequestMoneyList();
            gvRequestList.DataSource = requestList;
            gvRequestList.DataBind();
        }
    }
}
