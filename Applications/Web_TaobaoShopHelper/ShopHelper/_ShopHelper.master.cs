using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;
using TOP.Menu.Facade;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class _ShopHelper : BaseMaster, IInformationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MenuAnalyser analyser = new MenuAnalyser();
                string menuPath = Server.MapPath("_SecondMenu.xml");
                List<MenuInfo> menuList = analyser.Analyser(menuPath);
                SetSelectedMenu(menuList, 2);
                rptMenus.DataSource = menuList;
                rptMenus.DataBind();
            }
        }

        #region IInformationPage Members

        public void SetInformationIco(InformationIcoType icoType)
        {
            this.ucCtrlInformationBox.SetInformationIco(icoType);
        }

        public void SetInformation(List<InformationObject> infoList)
        {
            this.ucCtrlInformationBox.SetInformationList(infoList);
        }

        public void SetInformationBoxVisible(bool visible)
        {
            this.ucCtrlInformationBox.Visible = visible;
        }

        #endregion
    }
}
