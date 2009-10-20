using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    public partial class TemplateApp_Step3_Edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<InformationObject> infoList = new List<InformationObject>();
            if (CurrentUser == null)
            {
                infoList.Add(GetUnLoginInformation());
            }
            else
            {
                TemplateFacade facade = new TemplateFacade();
                List<TemplateInfo> templateList = facade.GetTemplateInfoListByUserId(CurrentUser.Id);
                templateList.Insert(0, TemplateInfo.GetEmptyObject<TemplateInfo>());
                ddlTemplates.DataSource = templateList;
                ddlTemplates.DataBind();
            }
            if (string.IsNullOrEmpty(TOP_SessionKey))
            {
                infoList.Add(GetUnAuthorizeInformation());
            }
            if (infoList.Count > 0)
            {
                DisplayInformations(infoList);
            }
            string names = Request["Names"];
            List<WaittingTemplate> list = new List<WaittingTemplate>();
            if (!string.IsNullOrEmpty(names))
            {
                foreach (string name in names.Split(','))
                {
                    WaittingTemplate item = new WaittingTemplate()
                    {
                        Name = name,
                        Url = "http://www.google.cn"
                    };
                    list.Add(item);
                }
            }
            rptItemList.DataSource = list;
            rptItemList.DataBind();
        }
    }

    public class WaittingTemplate
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}
