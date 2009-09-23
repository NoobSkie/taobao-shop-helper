using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Core.Facade;
using TOP.Core.Domain;
using System.IO;
using System.Text;

namespace TOP.Applications.TaobaoShopHelper.RequestPages
{
    public partial class UpdateItemCategoryListToLocal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xml = Request["ItemCategoryListString"];

            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(TOPDataList<ItemCategory>), new System.Xml.Serialization.XmlAttributeOverrides());
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] bs = Encoding.UTF8.GetBytes(xml);
                stream.Write(bs, 0, bs.Length);
                TOPDataList<ItemCategory> list = (TOPDataList<ItemCategory>)ser.Deserialize(stream);
                Response.Write("ok");
            }
        }
    }
}
