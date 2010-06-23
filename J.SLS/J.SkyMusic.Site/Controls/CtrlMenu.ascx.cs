using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class Controls_CtrlMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (MenuList != null)
            {
                rptMenuList.DataSource = MenuList;
                rptMenuList.DataBind();

                string selectedId = "";
                if (!string.IsNullOrEmpty(Request.QueryString["m"]))
                {
                    selectedId = Request.QueryString["m"];
                }
                else if (MenuList.Count > 0)
                {
                    selectedId = MenuList[0].Id;
                }
                if (selectedId != "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowFirstTopMenuJs", "ShowSubMenu('" + selectedId + "')", true);
                }
            }
        }
    }

    public IList<MenuItemInfo> MenuList { get; set; }
}
