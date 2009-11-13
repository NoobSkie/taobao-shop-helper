using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;
using TOP.Common.CompressionTool;
using System.Web.Script.Serialization;
using Taobao.Top.Api.Domain;
using Taobao.Top.Api;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Parser;
using TOP.Management.Facade;
using TOP.Importor.Facade;
using TOP.Common.Enumerations;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class ImportShop4 : BasePage, IMenuPage
    {
        public delegate void SyncImportShop(string groupId, Shop shop, int version, List<string> ignoreList);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentUser == null)
            {
                string msg = CompressionHelper.Compress("必须登录系统，才能执行导入店铺的操作！");
                string url = "~/Authorizes/UnLogin.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsoluteUri) + "&Msg=" + Server.UrlEncode(msg);
                Response.Redirect(url);
            }
            if (string.IsNullOrEmpty(CurrentSessionKey) || string.IsNullOrEmpty(CurrentSellerNick))
            {
                CurrentSellerNick = "zhandt";
                //string msg = CompressionHelper.Compress("必须先获取淘宝授权，才能执行导入店铺的操作！");
                //string url = "~/Authorizes/UnAuthorize.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsoluteUri) + "&Msg=" + Server.UrlEncode(msg);
                //Response.Redirect(url);
            }
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["GroupId"]))
                {
                    string groupId = Request["GroupId"];
                    DisplayImportDetail(groupId);
                }
                else if (!string.IsNullOrEmpty(Request["Shop"]))
                {
                    string json = CompressionHelper.Decompress(Request["Shop"]);
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    Shop shop = ser.Deserialize<Shop>(json);

                    string groupId = Guid.NewGuid().ToString();
                    int version = 0;
                    AddImportGroupToDb(groupId, shop);
                    version++;

                    SyncImportShop importor = new SyncImportShop(ImportShop);
                    AsyncCallback call = new AsyncCallback(ImportCallBack);
                    IAsyncResult result = importor.BeginInvoke(groupId, shop, version, IgnoreList, call, importor);

                    Response.Redirect("ImportShop4.aspx?GroupId=" + groupId);
                }
                else
                {
                    Response.Redirect("ImportShop1.aspx");
                }
            }
        }

        private void ImportShop(string groupId, Shop shop, int version, List<string> ignoreList)
        {
            ImportFacade facade = new ImportFacade();
            int pageIndex = 1;
            int pageSize = 20;
            while (true)
            {
                List<Item> topItemList = GetItemList(shop.SellerNick, pageIndex++, pageSize);
                if (topItemList == null || topItemList.Count == 0) break;
                foreach (Item item in topItemList)
                {
                    if (ignoreList.Contains(item.Iid)) continue;

                    string itemId = Guid.NewGuid().ToString();
                    facade.AddImportItem(itemId, groupId, CurrentUser.Id, CurrentUser.UserName, item.Iid, item.Title, item.Price, shop.SellerNick, shop.Title, CurrentUser.Id);
                }
                if (topItemList.Count < pageSize) break;
            }

            ImportShop(groupId, version);
        }

        private int AddImportGroupToDb(string groupId, Shop shop)
        {
            int totalCount = GetTotalImportCount(shop.SellerNick);

            ImportFacade facade = new ImportFacade();
            facade.AddImportGroup(groupId, CurrentUser.Id, CurrentUser.UserName, totalCount - IgnoreList.Count, shop.SellerNick, shop.Title, shop.LogoUrl, CurrentSellerNick, CurrentShopTitle, ImportorEnumerations.ImportType.Shop, CurrentUser.Id);

            return totalCount;
        }

        private List<Item> GetItemList(string nick, int pageIndex, int pageSize)
        {
            ITopClient client = GetProductTopClient();
            ItemsGetRequest reqItems = new ItemsGetRequest();
            reqItems.Fields = TopFieldsHelper.GetItemFields_InList();
            reqItems.Nicks = nick;
            reqItems.PageNo = pageIndex;
            reqItems.PageSize = pageSize;
            ResponseList<Item> rsp = client.Execute(reqItems, new ItemListJsonParser());
            return rsp.Content;
        }

        private void ImportShop(string groupId, int version)
        {
            ImportFacade facade = new ImportFacade();
            facade.StartImport(groupId, version++, CurrentUser.Id);
            int pageIndex = 0;
            int pageSize = 20;
            int successCount = 0;
            int failCount = 0;
            while (true)
            {
                List<ImportItemInfo> itemList = facade.GetImportItemList(groupId, pageIndex++, pageSize);
                if (itemList == null || itemList.Count == 0) break;
                foreach (ImportItemInfo item in itemList)
                {
                    try
                    {
                        facade.StartImportItem(item.Id, item.CurrentVersion, CurrentUser.Id);

                        Item toItem = ImportItem(item);

                        facade.FinishImportItem(groupId, version++, item.Id, item.CurrentVersion
                            , ImportorEnumerations.ImportItemResult.AddSuccess
                            , toItem.Iid, toItem.Title, toItem.Price, CurrentSellerNick, CurrentShopTitle
                            , ++successCount, failCount, "导入成功！", CurrentUser.Id);
                    }
                    catch (Exception ex)
                    {
                        facade.FinishImportItem(groupId, version++, item.Id, item.CurrentVersion
                            , ImportorEnumerations.ImportItemResult.Fail
                            , "", "", "", CurrentSellerNick, CurrentShopTitle
                            , ++failCount, failCount, ex.Message, CurrentUser.Id);
                    }
                }
                if (itemList.Count < pageSize) break;
            }
            ImportorEnumerations.ImportGroupResult result;
            if (failCount == 0)
            {
                result = ImportorEnumerations.ImportGroupResult.AllSuccess;
            }
            else if (successCount == 0)
            {
                result = ImportorEnumerations.ImportGroupResult.Fail;
            }
            else
            {
                result = ImportorEnumerations.ImportGroupResult.ParttenSuccess;
            }
            facade.FinishImport(groupId, version++, result, CurrentUser.Id);
        }

        private int GetTotalImportCount(string nick)
        {
            ITopClient client = GetProductTopClient();
            ItemsGetRequest reqItems = new ItemsGetRequest();
            reqItems.Fields = TopFieldsHelper.GetItemFields_OnlyId();
            reqItems.Nicks = nick;
            reqItems.PageNo = 1;
            reqItems.PageSize = 1;
            ResponseList<Item> rsp = client.Execute(reqItems, new ItemListJsonParser());
            return (int)rsp.TotalResults;
        }

        private void ImportCallBack(IAsyncResult result)
        {
            SyncImportShop state = (SyncImportShop)result.AsyncState;
            state.EndInvoke(result);
        }

        private List<string> ignoreList;
        private List<string> IgnoreList
        {
            get
            {
                if (ignoreList == null)
                {
                    if (string.IsNullOrEmpty(Request["IgnoreList"]))
                    {
                        ignoreList = new List<string>();
                    }
                    else
                    {
                        string json = CompressionHelper.Decompress(Request["IgnoreList"]);
                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        ignoreList = ser.Deserialize<List<string>>(json);
                    }
                }
                return ignoreList;
            }
        }

        private void DisplayImportDetail(string groupId)
        {
            ImportFacade facade = new ImportFacade();
            ImportGroupInfo group = facade.GetImportGroup(groupId);
            if (group != null && group.OperatorUserId == CurrentUser.Id)
            {
                if (!string.IsNullOrEmpty(group.ImportFormShopImageUrl))
                {
                    imgShop.Visible = true;
                    imgShop.ImageUrl = string.Format(ShopLogUrlFormat, group.ImportFormShopImageUrl);
                }
                else
                {
                    imgShop.Visible = false;
                }
                lblNick.Text = group.ImportFormSellerNick;
                lblShopTitle.Text = group.ImportFormShopTitle;
                lblImportCount.Text = group.TotalCount.ToString();
                if (group.ImportState == ImportorEnumerations.ImportState.Waitting)
                {
                    lblState.Text = "系统正在准备要导入的数据...";
                    lblSummary.Text = "导入操作完成以后统计数据，请稍等...";
                    hlnkRefresh.NavigateUrl = "ImportShop4.aspx?GroupId=" + groupId;
                }
                else if (group.ImportState == ImportorEnumerations.ImportState.Importing)
                {
                    lblState.Text = "正在导入数据...";
                    lblSummary.Text = "导入操作完成以后统计数据，请稍等...";
                    hlnkRefresh.NavigateUrl = "ImportShop4.aspx?GroupId=" + groupId;
                }
                else
                {
                    string result;
                    if (group.ImportResult == ImportorEnumerations.ImportGroupResult.Pending)
                    {
                        result = "未统计";
                    }
                    else if (group.ImportResult == ImportorEnumerations.ImportGroupResult.AllSuccess)
                    {
                        result = "全部成功";
                    }
                    else if (group.ImportResult == ImportorEnumerations.ImportGroupResult.ParttenSuccess)
                    {
                        result = "部分成功";
                    }
                    else
                    {
                        result = "失败";
                    }
                    lblState.Text = string.Format("导入操作已结束（{0}）", result);
                    lblSummary.Text = string.Format("成功:{0}; 失败:{1};", group.SuccessCount, group.FailCount);
                    hlnkRefresh.Visible = false;
                }
            }
            else
            {
                imgShop.Visible = false;

                List<InformationObject> infoList = new List<InformationObject>();
                InformationObject obj1 = new InformationObject();
                obj1.CssName = "Information";
                obj1.Message = "发生错误，有可能是下列原因之一导致的：";
                infoList.Add(obj1);
                InformationObject obj2 = new InformationObject();
                obj2.CssName = "ErrorMsg";
                obj2.Message = "1.你所查看的导入记录不存在";
                infoList.Add(obj2);
                InformationObject obj3 = new InformationObject();
                obj3.CssName = "ErrorMsg";
                obj3.Message = "2.你所查看的导入记录是其他人的";
                infoList.Add(obj3);
                DisplayInformations(infoList, InformationIcoType.Warning);
            }
        }

        private Item ImportItem(ImportItemInfo item)
        {
            try
            {
                ITopClient client = GetProductTopClient();
                ItemGetRequest req = new ItemGetRequest();
                req.Fields = TopFieldsHelper.GetItemFields_All();
                req.Iid = item.ImportFormItemIid;
                req.Nick = item.ImportFormSellerNick;
                Item topItem = client.Execute<Item>(req, new ItemJsonParser());
                ImportItem(topItem);
                return topItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ImportItem(Item item)
        {
            try
            {
                ITopClient client = GetProductTopClient();
                ItemAddRequest req = new ItemAddRequest();
                req.ApproveStatus = item.ApproveStatus;
                req.EnlistTime = DateTime.Parse(item.EnlistTime);
                req.Num = int.Parse(item.Num);
                req.Price = item.Price;
                req.Type = item.Type;
                req.StuffStatus = item.StuffStatus;
                req.Title = item.Title;
                req.Desc = item.Desc;
                req.Cid = item.Cid;
                req.Location = item.Location;
                req.AutoRepost = item.AutoRepost;
                req.PostFee = item.PostFee;
                req.ExpressFee = item.ExpressFee;
                req.EmsFee = item.EmsFee;
                req.OuterId = item.OuterId;
                req.Props = item.Props;
                // req.SkuProps = item.SkuList;
                req.HasShowcase = item.HasShowcase;
                // req.Image = TestUtils.GetResourceAsFileItem("item.jpg");

                Item importedItem = client.Execute(req, new ItemJsonParser(), CurrentSessionKey);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region IMenuPage Members

        public string GetTopMenuId()
        {
            return "MyShop";
        }

        public string GetSecondMenuId()
        {
            return "ImportShop";
        }

        #endregion
    }
}
