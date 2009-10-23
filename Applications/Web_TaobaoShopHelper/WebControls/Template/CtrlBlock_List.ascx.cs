using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;
using TOP.Applications.TaobaoShopHelper.WebControls.Search;
using TOP.Applications.TaobaoShopHelper._Common;
using Taobao.Top.Api;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Domain;
using Taobao.Top.Api.Parser;
using TOP.Applications.TaobaoShopHelper.Templates;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlBlock_List : TemplateEditCtrlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucCtrlSearchButtonMulti.AfterReturned += new AfterReturnedEventHadler(OnAfterReturnItems);
            if (!IsPostBack)
            {
                this.rtpBlockItems.DataSource = currentDataSource;
                this.rtpBlockItems.DataBind();
            }
        }

        private List<TemplateObject> currentDataSource
        {
            get
            {
                return (List<TemplateObject>)ViewState["CtrlBlock_List.currentDataSource"];
            }
            set
            {
                ViewState["CtrlBlock_List.currentDataSource"] = value;
            }
        }

        private TemplateObject currentModule
        {
            get
            {
                return (TemplateObject)ViewState["CtrlBlock_List.currentModule"];
            }
            set
            {
                ViewState["CtrlBlock_List.currentModule"] = value;
            }
        }

        public TemplateObject TemplateInfo
        {
            get
            {
                return (TemplateObject)ViewState["CtrlBlock_List.TemplateInfo"];
            }
            set
            {
                ViewState["CtrlBlock_List.TemplateInfo"] = value;

                if (value.ShowTitle)
                {
                    this.lblHeader.Text = value.DisplayName;
                }
                if (value.Children.Count > 0)
                {
                    currentModule = value.Children[0];
                    ucCtrlSearchButtonMulti.SearchWinTitle = value.Children[0].DisplayName;
                    ucCtrlSearchButtonMulti.DemoInput = value.Children[0].DemoInput;
                    ucCtrlSearchButtonMulti.Information = value.Children[0].Information;
                }
                currentDataSource = new List<TemplateObject>();
                if (string.IsNullOrEmpty(value.DataType))
                {
                    ucCtrlSearchButtonMulti.Visible = true;
                    ucCtrlSearchButtonMulti.SearchWinType = SearchWinType.Input_Text;
                }
                else
                {
                    switch (value.DataType.ToLower())
                    {
                        case "myitems":
                            ucCtrlSearchButtonMulti.Visible = true;
                            ucCtrlSearchButtonMulti.SearchWinType = SearchWinType.Multi_MyItems;
                            break;
                        default:
                            ucCtrlSearchButtonMulti.Visible = true;
                            ucCtrlSearchButtonMulti.SearchWinType = SearchWinType.Input_Text;
                            break;
                    }
                }
            }
        }

        public void OnAfterReturnItems(SearchWinReturnedEventArg e)
        {
            switch (e.SearchWinType)
            {
                case SearchWinType.Input_Text:
                    foreach (string data in e.PostData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        AddChild(data);
                    }
                    break;
                default:
                    JsonObjectList<JsonItem> list = JsonParser.ParseJsonResponse<JsonItem>(e.PostData);
                    foreach (JsonItem item in list)
                    {
                        if (string.IsNullOrEmpty(item.DetailUrl))
                        {
                            ITopClient client = GetProductTopClient();
                            ItemGetRequest req = new ItemGetRequest();
                            req.Fields = "detail_url";
                            req.Iid = item.Id;
                            req.Nick = item.Nick;
                            Item rsp = client.Execute<Item>(req, new ItemJsonParser());
                            if (rsp != null && !string.IsNullOrEmpty(rsp.DetailUrl))
                            {
                                item.DetailUrl = rsp.DetailUrl;
                            }
                        }
                        AddChild(item.ToJsonString());
                    }
                    break;
            }
            Response.Redirect(Request.Url.AbsolutePath);
        }

        public void AddChild(string defaultValue)
        {
            if (currentModule != null)
            {
                TemplateObject clone = currentModule.Clone();
                clone.DefaultValue = defaultValue;
                TemplateSetItem flow = new TemplateSetItem();
                flow.Action = "Add";
                flow.ChildrenCount = clone.Children.Count;
                flow.ContainerId = clone.Id;
                flow.Value = defaultValue;
                CurrentTemplateSetFlow.CurrentFlow.Add(flow);
            }
        }

        public void CreateChild(string defaultValue)
        {
            if (currentModule != null)
            {
                TemplateObject clone = currentModule.Clone();
                clone.DefaultValue = defaultValue;
                currentDataSource.Add(clone);
            }
        }

        public string GetOuterHTML()
        {
            return TemplateInfo.OuterHTML;
        }

        public string GetInputHTML()
        {
            string html = TemplateInfo.InnerHTML;
            string newHtml = string.Empty;
            foreach (RepeaterItem item in rtpBlockItems.Items)
            {
                CtrlBlock_Item block = (CtrlBlock_Item)item.FindControl("ucCtrlBlockItem");
                string itemHtml = html.Replace(currentModule.OuterHTML, block.GetInputHTML());
                newHtml += itemHtml;
            }
            return TemplateInfo.OuterHTML.Replace(TemplateInfo.OuterHTML, newHtml);
        }
    }
}