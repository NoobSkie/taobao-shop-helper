using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    public partial class NestedTemplatePage : BaseMaster, IInformationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
