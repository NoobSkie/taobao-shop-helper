using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using System.Configuration;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Common
{
    public partial class CtrlInformationBox : System.Web.UI.UserControl
    {
        private InformationIcoType _icoType = InformationIcoType.Default;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetInformationList(List<InformationObject> informationList)
        {
            rptInformationList.DataSource = informationList;
            rptInformationList.DataBind();
        }

        public void SetInformationIco(InformationIcoType icoType)
        {
            _icoType = icoType;
        }

        public InformationIcoType InformationIcoType
        {
            get
            {
                return _icoType;
            }
        }

        public string InformationIcoTypeName
        {
            get
            {
                return _icoType.ToString();
            }
        }

        public bool IsDisplayIco
        {
            get
            {
                if (_icoType == InformationIcoType.None)
                {
                    return false;
                }
                return true;
            }
        }

        public string IcoUrl
        {
            get
            {
                string path = ConfigurationManager.AppSettings["InformationBoxIcoPath"];
                if (IsDisplayIco)
                {
                    string url = this.ResolveUrl(path + _icoType.ToString() + ".png");
                    return url;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}