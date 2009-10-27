using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using System.IO;
using System.Text;

namespace TOP.Applications.TaobaoShopHelper.Management
{
    public partial class GetItemCategoryListFromTOP : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Expires = -1;
            //string parentId = string.Empty;
            //if (!string.IsNullOrEmpty(Request["ParentCategoryId"]))
            //{
            //    parentId = Request["ParentCategoryId"];
            //}
            //CategoryFacade facade = new CategoryFacade(AppKey, AppSecret);
            //TOPDataList<ItemCategory> list = facade.GetItemCategories(parentId, string.Empty);
            //string str = "";
            //System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(TOPDataList<ItemCategory>), new System.Xml.Serialization.XmlAttributeOverrides());
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    ser.Serialize(stream, list);
            //    stream.ToArray();
            //    str = Encoding.UTF8.GetString(stream.ToArray());
            //}
            //Response.Write(str);
        }
    }
}
