using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;

namespace TOP.Applications.TaobaoShopHelper.TestPages.ControlTest
{
    public partial class TestInformationBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOneMessage_Click(object sender, EventArgs e)
        {
            divInformationBox.Attributes["class"] = "OneMessage";

            List<InformationObject> list = new List<InformationObject>();
            InformationObject obj = new InformationObject();
            obj.Message = "测试只有一条信息";
            list.Add(obj);
            ucInformationBox.SetInformationList(list);
        }

        protected void btnMultiMessageNoSperator_Click(object sender, EventArgs e)
        {
            divInformationBox.Attributes["class"] = "MultiMessageNoSperator";

            List<InformationObject> list = new List<InformationObject>();

            InformationObject obj1 = new InformationObject();
            obj1.Message = "简单的多条信息 - 第1条";
            list.Add(obj1);
            InformationObject obj2 = new InformationObject();
            obj2.Message = "简单的多条信息 - 第2条";
            list.Add(obj2);
            InformationObject obj3 = new InformationObject();
            obj3.Message = "简单的多条信息 - 第3条";
            list.Add(obj3);
            InformationObject obj4 = new InformationObject();
            obj4.Message = "简单的多条信息 - 第4条";
            list.Add(obj4);
            InformationObject obj5 = new InformationObject();
            obj5.Message = "简单的多条信息 - 第5条";
            list.Add(obj5);

            ucInformationBox.SetInformationList(list);
        }

        protected void btnMultiMessageCustomerSperator_Click(object sender, EventArgs e)
        {
            divInformationBox.Attributes["class"] = "MultiMessageCustomerSperator";

            List<InformationObject> list = new List<InformationObject>();

            InformationObject obj1 = new InformationObject();
            obj1.CssName = "BlueText";
            obj1.Message = "简单的多条信息 - 第1条";
            list.Add(obj1);
            InformationObject obj2 = new InformationObject();
            obj2.CssName = "BlackText";
            obj2.Message = "简单的多条信息 - 第2条";
            list.Add(obj2);
            InformationObject obj3 = new InformationObject();
            obj3.CssName = "RedText";
            obj3.Message = "简单的多条信息 - 第3条";
            list.Add(obj3);
            InformationObject obj4 = new InformationObject();
            obj4.CssName = "BlueText";
            obj4.Message = "简单的多条信息 - 第4条";
            list.Add(obj4);
            InformationObject obj5 = new InformationObject();
            obj5.CssName = "RedText";
            obj5.Message = "简单的多条信息 - 第5条";
            list.Add(obj5);

            ucInformationBox.SetInformationList(list);
        }
    }
}
