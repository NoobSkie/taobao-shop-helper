using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class QueryResult_Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //QueryResult resultPage = Context.Handler as QueryResult;
            //if (resultPage != null)
            //{
            //    Response.Write(resultPage.DataSource_Shop.Title);
            //}
            List<InformationObject> list = new List<InformationObject>();
            InformationObject obj = new InformationObject();
            obj.Message = "您尚未登录，不能执行整店导入的操作。";
            obj.CssName = "Information";
            obj.AddLink("<span>登录帐号</span>", "~/Login.aspx");
            list.Add(obj);
            ucInformationBox_Tip.SetInformationList(list);
        }
    }
}
