using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Common
{
    public partial class CtrlInformationItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private InformationObject _informationObject;
        public InformationObject InformationObject
        {
            get
            {
                return _informationObject;
            }
            set
            {
                _informationObject = value;

                _message = (_informationObject == null) ? "" : _informationObject.Message;
                _cssName = (_informationObject == null) ? "" : _informationObject.CssName;
                _linkList = (_informationObject == null) ? null : _informationObject.LinkList;
            }
        }

        private List<LinkItem> _linkList;
        public List<LinkItem> LinkList
        {
            get
            {
                return _linkList;
            }
        }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
        }

        private string _cssName;
        public string CssName
        {
            get
            {
                return _cssName;
            }
        }
    }
}