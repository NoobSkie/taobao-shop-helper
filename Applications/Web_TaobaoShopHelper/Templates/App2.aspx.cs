using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;
using TOP.Template.Facade;
using TOP.Common.CompressionTool;
using Taobao.Top.Api;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Parser;
using Taobao.Top.Api.Domain;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    public partial class App2 : BasePage, IMenuPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<InformationObject> infoList = new List<InformationObject>();
                if (CurrentUser == null)
                {
                    infoList.Add(GetUnLoginInformation());
                }
                if (string.IsNullOrEmpty(CurrentSessionKey) || string.IsNullOrEmpty(CurrentSellerNick))
                {
                    infoList.Add(GetUnAuthorizeInformation());
                }
                if (infoList.Count > 0)
                {
                    DisplayInformations(infoList);

                    lbtnSave.Enabled = false;
                    lbtnPreview.Enabled = false;
                }
                else
                {
                    BindWaittingTemplateList();
                    BindTemplateList();
                    BindTemplateInfo();

                    int isSuccess = 0;
                    if (!string.IsNullOrEmpty(Request["IsSuccess"]))
                    {
                        isSuccess = int.Parse(Request["IsSuccess"]);
                    }
                    if (isSuccess > 0)
                    {
                        InformationObject obj = new InformationObject();
                        obj.Message = Request["Message"];
                        infoList.Add(obj);
                        DisplayInformations(infoList, InformationIcoType.Information);
                    }
                    else if (isSuccess < 0)
                    {
                        InformationObject obj = new InformationObject();
                        obj.Message = Request["Message"];
                        infoList.Add(obj);
                        DisplayInformations(infoList, InformationIcoType.Error);
                    }
                }
            }
        }

        private void BindTemplateInfo()
        {
            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                ucTemplateEditor.ItemIid = Request["Id"];
            }
        }

        private void BindTemplateList()
        {
            TemplateFacade facade = new TemplateFacade();
            List<TemplateInfo> templateList = facade.GetTemplateInfoListByUserId(CurrentUser.Id);
            templateList.Insert(0, TemplateInfo.GetEmptyObject<TemplateInfo>());
            ddlTemplates.DataSource = templateList;
            ddlTemplates.DataBind();

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                ddlTemplates.SelectedValue = Request["Id"];
            }
        }

        private void BindWaittingTemplateList()
        {
            List<WaittingTemplate> list = GetWaittingTemplateList();
            rptItemList.DataSource = list;
            rptItemList.DataBind();
        }

        private List<WaittingTemplate> GetWaittingTemplateList()
        {
            string names = Request["List"];
            string items = CompressionHelper.Decompress(names);
            List<WaittingTemplate> list = new List<WaittingTemplate>();
            if (!string.IsNullOrEmpty(items))
            {
                int index = 0;
                string currentKey = Request["Current"];
                foreach (string name in items.Split(new string[] { "_-p-_" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] keyValue = name.Split(new string[] { "_-c-_" }, StringSplitOptions.RemoveEmptyEntries);
                    if (keyValue.Length == 2)
                    {
                        if (string.IsNullOrEmpty(currentKey) && index == 0)
                        {
                            currentKey = keyValue[0];
                        }
                        bool isCurrent = (keyValue[0] == currentKey);
                        WaittingTemplate item = new WaittingTemplate()
                        {
                            Key = keyValue[0],
                            Name = keyValue[1],
                            Url = GetUrlByKey(keyValue[0]),
                            IsCurrent = isCurrent
                        };
                        list.Add(item);
                    }
                    index++;
                }
            }
            return list;
        }

        private string GetUrlByKey(string key)
        {
            Dictionary<string, string> parameters = GetParameterListByQuery();
            if (parameters.ContainsKey("Current"))
            {
                parameters["Current"] = key;
            }
            else
            {
                parameters.Add("Current", key);
            }
            return Request.Url.AbsolutePath + "?" + GetQueryByParameterList(parameters);
        }

        protected void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = GetParameterListByQuery();
            string id = ddlTemplates.SelectedValue;
            if (id == Guid.Empty.ToString())
            {
                if (parameters.ContainsKey("Id"))
                {
                    parameters.Remove("Id");
                }
            }
            else
            {
                if (parameters.ContainsKey("Id"))
                {
                    parameters["Id"] = id;
                }
                else
                {
                    parameters.Add("Id", id);
                }
            }
            Response.Redirect(Request.Url.AbsolutePath + "?" + GetQueryByParameterList(parameters));
        }

        protected void lbtnPreview_Click(object sender, EventArgs e)
        {
            string html = ucTemplateEditor.GetHtml();
            string arg = CompressionHelper.Compress(html);
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            string html = ucTemplateEditor.GetHtml();
            ITopClient client = GetProductTopClient();
            ItemUpdateRequest req = new ItemUpdateRequest();
            // SellerItemCatsGetRequest req = new SellerItemCatsGetRequest();
            req.Desc = html;
            req.Iid = Request["Current"];
            Item item = client.Execute(req, new ItemJsonParser(), CurrentSessionKey);

            Dictionary<string, string> parameters = GetParameterListByQuery();
            parameters.Add("IsSuccess", "1");
            parameters.Add("Message", "设置宝贝描述信息成功！");
            Response.Redirect(Request.Url.AbsolutePath + "?" + GetQueryByParameterList(parameters));
        }

        #region IMenuPage Members

        public string GetTopMenuId()
        {
            return "Template";
        }

        public string GetSecondMenuId()
        {
            return "App";
        }

        #endregion
    }

    public class WaittingTemplate
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public bool IsCurrent { get; set; }

        public string CssName
        {
            get
            {
                if (IsCurrent)
                {
                    return "Selected";
                }
                return "";
            }
        }
    }
}
