using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper.WebControls.Search;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.TestPages
{
    public partial class TestSearchItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CtrlSearchButton_Multi1.AfterReturned += new AfterReturnedEventHadler(OnAfterReturnItems);
        }

        public void OnAfterReturnItems(SearchWinReturnedEventArg e)
        {
            JsonObjectList<JsonItem> list = JsonParser.ParseJsonResponse<JsonItem>(e.Json);
            Response.Write(list.TotalCount);
        }
    }
}
