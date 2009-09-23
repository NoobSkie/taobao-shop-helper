using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using TOP.Core.Facade;
using TOP.Core.Domain;

namespace TestTOP
{
    public partial class _Default : System.Web.UI.Page
    {
        private const string defaultAppKey = "12006575";
        private const string defaultAppSecret = "9d0a6fb5453e9b51877f9ed28b5569a9";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            string q = GB2312ToUTF8(txtQ.Text);// Server.UrlEncode(txtQ.Text);
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            TOPDataList<ItemListItem> list;
            try
            {
                if (ddlQueryType.SelectedValue.Equals("key", StringComparison.OrdinalIgnoreCase))
                {
                    list = facade.QueryItemListByKey(q);
                }
                else
                {
                    list = facade.QueryItemListByNicks(q.Split(','));
                }

                lblItemCount.Text = string.Format("{0}条记录", list.TotalResultNum);
            }
            catch (ResponseException ex)
            {
                Response.Write(ex.Message + " - " + ex.ErrorCode + " - " + ex.ErrorDescription);
                list = null;
                lblItemCount.Text = "0条记录";
            }
            repeater.DataSource = list;
            repeater.DataBind();
        }
        public string GB2312ToUTF8(string str)
        {
            try
            {
                Encoding uft8 = Encoding.GetEncoding(65001);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                byte[] temp = gb2312.GetBytes(str);
                byte[] temp1 = Encoding.Convert(gb2312, uft8, temp);
                string result = uft8.GetString(temp1);
                return result;
            }
            catch
            {
                return str;
            }
        }
    }
}