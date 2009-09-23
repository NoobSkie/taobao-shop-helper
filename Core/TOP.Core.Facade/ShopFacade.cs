using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    public class ShopFacade
    {
        private readonly AnalyseData analyser;
        private string currentAppKey, currentAppSecret, currentVersion;

        public ShopFacade(string appKey, string appSecret) : this(appKey, appSecret, "1.0") { }

        public ShopFacade(string appKey, string appSecret, string version)
        {
            currentAppKey = appKey;
            currentAppSecret = appSecret;
            currentVersion = version;

            analyser = new AnalyseData(appKey, appSecret, version);
        }

        /// <summary>
        /// 查询卖家所有商品列表。分页功能。
        /// </summary>
        public TOPDataList<SampleListItem> GetAllShopItems(int page_no, int page_size, string sessionKey)
        {
            string method = "taobao.items.all.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("session", sessionKey);
            req_params.Add("page_no", page_no.ToString());
            req_params.Add("page_size", page_size.ToString());

            return analyser.RequestTOPDataList<SampleListItem>(method, req_params);
        }

        /// <summary>
        /// 根据关键字，查询卖家商品列表。分页功能。
        /// </summary>
        /// <param name="key">搜索字段。搜索商品的title。</param>
        /// <param name="itemCatId">商品类目ID。ItemCat中的cid。可以通过taobao.itemcats.get.v2取到 </param>
        /// <param name="sellerCatId">卖家店铺内自定义类目ID。多个之间用“,”分隔。可以根据taobao.sellercats.list.get获得 </param>
        /// <param name="page_no">页码。取值范围:大于零的整数;默认值为1，即返回第一页数据。</param>
        /// <param name="page_size">每页条数。取值范围:大于零的整数;最大值：200；默认值：40。 </param>
        /// <param name="orderBy">排序方式。格式为column:asc/desc ，column可选值:list_time(上架时间),delist_time(下架时间),num(商品数量);默认上架时间降序(即最新上架排在前面)。如按照上架时间降序排序方式为list_time:desc</param>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        public TOPDataList<SampleListItem> QueryShopItemsByKey(string key, string itemCatId, string sellerCatId, int page_no, int page_size, string orderBy, string sessionKey)
        {
            string method = "taobao.items.all.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(key))
            {
                req_params.Add("q", key);
            }
            if (!string.IsNullOrEmpty(itemCatId))
            {
                req_params.Add("cid", itemCatId);
            }
            if (!string.IsNullOrEmpty(itemCatId))
            {
                req_params.Add("seller_cids", sellerCatId);
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                req_params.Add("order_by", orderBy);
            }
            req_params.Add("session", sessionKey);
            req_params.Add("page_no", page_no.ToString());
            req_params.Add("page_size", page_size.ToString());

            return analyser.RequestTOPDataList<SampleListItem>(method, req_params);
        }

        /// <summary>
        /// taobao.shop.get(获取卖家店铺的基本信息)
        /// </summary>
        /// <param name="nick">卖家昵称。</param>
        /// <returns></returns>
        public Shop GetShopByNick(string nick)
        {
            string method = "taobao.shop.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("nick", nick);

            return analyser.RequestTOPDataItem<Shop>(method, req_params);
        }
    }
}
