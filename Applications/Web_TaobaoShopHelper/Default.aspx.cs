using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Common.StringTool;
using System.Text;

namespace TOP.Applications.TaobaoShopHelper
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["top_session"]))
                {
                    CurrentSessionKey = Request["top_session"];
                }
                if (!string.IsNullOrEmpty(Request["top_parameters"]))
                {
                    Dictionary<string, string> parameters = GetParameters(Request["top_parameters"]);
                    if (parameters.ContainsKey("visitor_nick"))
                    {
                        CurrentSellerNick = parameters["visitor_nick"];
                    }
                }
                if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
                {
                    Response.Redirect(Request["ReturnUrl"], true);
                }
            }
        }

        private Dictionary<string, string> GetParameters(string base64string)
        {
            byte[] output = Convert.FromBase64String(base64string);
            string parameters = Encoding.Default.GetString(output);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (string item in parameters.Split('&'))
            {
                string[] ss = item.Split('=');
                if (ss.Length <= 0)
                {
                    continue;
                }
                else if (ss.Length == 1)
                {
                    dictionary.Add(ss[0], string.Empty);
                }
                else
                {
                    dictionary.Add(ss[0], ss[1]);
                }
            }
            return dictionary;
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //string q = EncodeHelper.GB2312ToUTF8(txtQ.Text);// Server.UrlEncode(txtQ.Text);
            //ItemFacade facade = new ItemFacade(AppKey, AppSecret);
            //TOPDataList<ItemListItem> list;
            //try
            //{
            //    if (ddlQueryType.SelectedValue.Equals("key", StringComparison.OrdinalIgnoreCase))
            //    {
            //        list = facade.QueryItemListByKey(q);
            //    }
            //    else
            //    {
            //        list = facade.QueryItemListByNicks(q.Split(','));
            //    }

            //    lblItemCount.Text = string.Format("{0}条记录", list.TotalResultNum);
            //}
            //catch (ResponseException ex)
            //{
            //    Response.Write(ex.Message + " - " + ex.ErrorCode + " - " + ex.ErrorDescription);
            //    list = null;
            //    lblItemCount.Text = "0条记录";
            //}
            //repeater.DataSource = list;
            //repeater.DataBind();
        }
    }
}
