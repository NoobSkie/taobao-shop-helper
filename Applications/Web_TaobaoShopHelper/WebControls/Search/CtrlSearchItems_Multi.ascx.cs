using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using Taobao.Top.Api.Domain;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Search
{
    public partial class CtrlSearchItems_Multi : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptItems.DataBind();
            }
        }

        public ItemDisplayType DisplayType
        {
            get;
            set;
        }

        public List<Item> ItemSource
        {
            set
            {
                rptItems.DataSource = value;
            }
        }
    }
}