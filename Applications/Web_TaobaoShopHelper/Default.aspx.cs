using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Core.Facade;
using TOP.Core.Domain;
using TOP.Common.StringTool;

namespace TOP.Applications.TaobaoShopHelper
{
    public partial class _Default : BasePage
    {
        private ConstVariables varHelper = new ConstVariables();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["top_session"]))
                {
                    TOP_SessionKey = Request["top_session"];
                    if (!string.IsNullOrEmpty(LastAsseccPageUrl))
                    {
                        Response.Redirect(LastAsseccPageUrl, true);
                    }
                }
            }
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            string q = EncodeHelper.GB2312ToUTF8(txtQ.Text);// Server.UrlEncode(txtQ.Text);
            ItemFacade facade = new ItemFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
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
    }
}
