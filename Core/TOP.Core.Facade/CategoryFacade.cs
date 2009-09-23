using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    public class CategoryFacade
    {
        private readonly AnalyseData analyser;
        private string currentAppKey, currentAppSecret, currentVersion;

        public CategoryFacade(string appKey, string appSecret) : this(appKey, appSecret, "1.0") { }

        public CategoryFacade(string appKey, string appSecret, string version)
        {
            currentAppKey = appKey;
            currentAppSecret = appSecret;
            currentVersion = version;

            analyser = new AnalyseData(appKey, appSecret, version);
        }

        #region 标准商品类目

        /// <summary>
        /// 获取后台供卖家发布商品的标准商品类目。
        /// </summary>
        /// <param name="parentId">父商品类目 id，0表示根节点, 传输该参数返回所有子类目。</param>
        /// <param name="cids">商品所属类目ID列表，用半角逗号(,)分隔 例如:(18957,19562,)</param>
        public TOPDataList<ItemCategory> GetItemCategories(string parentId, string cids)
        {
            if (string.IsNullOrEmpty(parentId))
            {
                parentId = "0";
            }
            string method = "taobao.itemcats.get.v2";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("parent_cid", parentId);
            if (!string.IsNullOrEmpty(cids))
            {
                req_params.Add("cids", cids);
            }

            return analyser.RequestTOPDataList<ItemCategory>(method, req_params);
        }

        #endregion

        #region 店铺内卖家自定义商品类目

        /// <summary>
        /// taobao.sellercats.list.get(获取前台展示的店铺内卖家自定义商品类目)
        /// </summary>
        /// <param name="nick">卖家昵称。</param>
        public TOPDataList<SellerCategory> GetSellerCategories(string nick)
        {
            string method = "taobao.sellercats.list.get";

            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("nick", nick);

            return analyser.RequestTOPDataList<SellerCategory>(method, req_params);
        }

        /// <summary>
        /// 添加卖家自定义类目.注:因为缓存的关系,添加的新类目需8个小时后才可以在淘宝页面上正常显示.但是不影响在该类目下产品发布. 
        /// 须用户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pictureUrl">该字段表示类目图片的url地址，以"http://"开头的形式，添加图片后，类目名称会被图片取代，但在前台浏览时，鼠标放在图片上时会有提示该图片表示类目名称。 </param>
        /// <returns></returns>
        public SellerCategoryResult AddSellerCategory(SellerCategory sellerCat, string sessionKey)
        {
            string method = "taobao.sellercats.list.add";

            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("name", sellerCat.Name);
            req_params.Add("pict_url", sellerCat.PictureUrl);
            req_params.Add("parent_cid", sellerCat.ParentId);
            req_params.Add("sort_order", sellerCat.SortOrder.ToString());
            req_params.Add("session", sessionKey);

            return analyser.RequestTOPDataItem<SellerCategoryResult>(method, req_params);
        }

        /// <summary>
        /// 更新卖家自定义类目.注:因为缓存的关系,添加的新类目需8个小时后才可以在淘宝页面上正常显示.但是不影响在该类目下产品发布. 
        /// 须用户登录
        /// </summary>
        /// <returns></returns>
        public SellerCategoryResult UpdateSellerCategory(SellerCategory sellerCat, string sessionKey)
        {
            string method = "taobao.sellercats.list.update";

            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("cid", sellerCat.Id);
            req_params.Add("name", sellerCat.Name);
            req_params.Add("pict_url", sellerCat.PictureUrl);
            req_params.Add("sort_order", sellerCat.SortOrder.ToString());
            req_params.Add("session", sessionKey);

            return analyser.RequestTOPDataItem<SellerCategoryResult>(method, req_params);
        }

        #endregion

        #region 前台展示的店铺类目

        /// <summary>
        /// taobao.shopcats.list.get(获取前台展示的店铺类目)
        /// 此API有错误
        /// </summary>
        /// <returns></returns>
        public TOPDataList<ShopCategory> GetShopCategories()
        {
            string method = "taobao.sellercats.list.get";

            Dictionary<string, string> req_params = new Dictionary<string, string>();

            return analyser.RequestTOPDataList<ShopCategory>(method, req_params);
        }

        #endregion
    }
}
