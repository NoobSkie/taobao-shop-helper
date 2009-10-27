using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    public partial class Default : BasePage, IMenuPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region IMenuPage Members

        public string GetTopMenuId()
        {
            return "Template";
        }

        public string GetSecondMenuId()
        {
            return "Default";
        }

        #endregion
    }
}
