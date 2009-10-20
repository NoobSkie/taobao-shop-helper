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

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlBlock_List : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucCtrlSearchButtonMulti.AfterReturned += new AfterReturnedEventHadler(OnAfterReturnItems);
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
                }
                currentDataSource = new List<TemplateObject>();
                if (string.IsNullOrEmpty(value.DataType))
                {
                    ucCtrlSearchButtonMulti.Visible = false;
                    lbtnAddNew.Visible = true;

                    if (string.IsNullOrEmpty(value.DefaultValue))
                    {
                        CreateChild(string.Empty);
                    }
                    else
                    {
                        string[] values = value.DefaultValue.Split(',');
                        foreach (string v in values)
                        {
                            CreateChild(v);
                        }
                    }
                }
                else
                {
                    switch (value.DataType.ToLower())
                    {
                        case "myitems":
                            ucCtrlSearchButtonMulti.Visible = true;
                            lbtnAddNew.Visible = false;

                            break;
                        default:
                            ucCtrlSearchButtonMulti.Visible = false;
                            lbtnAddNew.Visible = false;
                            break;
                    }
                }
            }
        }

        protected void lbtnAddNew_Click(object sender, EventArgs e)
        {
            SaveCurrentValue();
            CreateChild(string.Empty);
        }

        public void OnAfterReturnItems(SearchWinReturnedEventArg e)
        {
            JsonObjectList<JsonItem> list = JsonParser.ParseJsonResponse<JsonItem>(e.Json);
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
                CreateChild(item.ToJsonString());
            }
        }

        private void SaveCurrentValue()
        {
            for (int i = 0; i < rtpBlockItems.Items.Count; i++)
            {
                RepeaterItem item = rtpBlockItems.Items[i];

                CtrlBlock_Item block = (CtrlBlock_Item)item.FindControl("ucCtrlBlockItem");
                block.SaveCurrentValue();
                currentDataSource[i] = block.TemplateInfo;
            }
        }

        private void CreateChild(string defaultValue)
        {
            if (currentModule != null)
            {
                TemplateObject clone = currentModule.Clone();
                clone.DefaultValue = defaultValue;
                currentDataSource.Add(clone);
                this.rtpBlockItems.DataSource = currentDataSource;
                this.rtpBlockItems.DataBind();
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