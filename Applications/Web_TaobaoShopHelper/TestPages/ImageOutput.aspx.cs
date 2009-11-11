using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace TOP.Applications.TaobaoShopHelper.TestPages
{
    public partial class ImageOutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string imgPath = Server.MapPath("~/Images/Shops/zhongjy001/0_T1cIplXg1FFJQlGnoT_012858.jpg");
            using (FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
            {
                byte[] mydata = new byte[fs.Length];
                int Length = Convert.ToInt32(fs.Length);
                fs.Read(mydata, 0, Length);
                fs.Close();

                Response.ContentType = "image/jpeg";
                Response.OutputStream.Write(mydata, 0, Length);
                Response.End();
            }
        }
    }
}
