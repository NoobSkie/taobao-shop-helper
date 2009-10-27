using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Menu.Facade;

namespace TOP.Applications.TaobaoShopHelper
{
    public partial class Top : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MenuAnalyser analyser = new MenuAnalyser();
                string menuPath = Server.MapPath("~/App_Data/MainMenu.xml");
                List<MenuInfo> menuList = analyser.Analyser(menuPath);
                SetSelectedMenu(menuList, 1);
                rptMenus.DataSource = menuList;
                rptMenus.DataBind();
            }
        }
    }
}
