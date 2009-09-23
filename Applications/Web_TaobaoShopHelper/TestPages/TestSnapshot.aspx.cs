using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Html.Snapshot;
using System.Drawing.Imaging;
using System.Drawing;

namespace TOP.Applications.TaobaoShopHelper.TestPages
{
    public partial class TestSnapshot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSnapshot_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string html = txtHtml.Text;

            string fold = "~/Images/Snapshot/";//图片存放目录
            string physicsFold = Server.MapPath(fold);
            try
            {
                string guid = "";
                if (string.IsNullOrEmpty(url))
                {
                    guid = WebPreview.GetHtmlPreview(html, physicsFold);
                }
                else
                {
                    guid = WebPreview.GetUrlPreview(url, physicsFold);
                }
                string fileName = "img_" + guid + ".jpg";
                imgPrevew.ImageUrl = "~/Images/Snapshot/" + fileName;
            }
            catch
            {
                throw;
            }
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
