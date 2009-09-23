using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    public class ProductFacade
    {
        private readonly AnalyseData analyser;
        private string currentAppKey, currentAppSecret, currentVersion;

        public ProductFacade(string appKey, string appSecret) : this(appKey, appSecret, "1.0") { }

        public ProductFacade(string appKey, string appSecret, string version)
        {
            currentAppKey = appKey;
            currentAppSecret = appSecret;
            currentVersion = version;

            analyser = new AnalyseData(appKey, appSecret, version);
        }

        /// <summary>
        /// taobao.product.get(获取一个产品的信息)
        /// 传入product_id来查询 
        /// </summary>
        /// <param name="productIds">Product的id.两种方式来查看一个产品:1.传入product_id来查询 2.传入cid和props来查询 </param>
        /// <returns>返回具体信息为入参fields请求的字段信息 </returns>
        public TOPDataList<Product> GetProduct(string productId)
        {
            string method = "taobao.product.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("product_id", productId);

            return analyser.RequestTOPDataList<Product>(method, req_params);
        }

        /// <summary>
        /// taobao.product.get(获取一个产品的信息)
        /// 传入cid和props来查询 
        /// </summary>
        /// <param name="cid">商品类目id.调用taobao.itemcats.get.v2获取;必须是叶子类目id,如果没有传product_id,那么cid和props必须要传. </param>
        /// <param name="props">关键属性列表.调用taobao.itemprops.get.v2获取类目属性,如果属性是关键属性,再用taobao.itempropvalues.get取得vid.格式:pid:vid;pid:vid.
        /// 比如:诺基亚N73这个产品的关键属性列表就是:品牌:诺基亚;型号:N73,对应的PV值就是10005:10027;10006:29729. </param>
        /// <returns></returns>
        public TOPDataList<Product> GetProduct(string cid, string props)
        {
            string method = "taobao.product.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("cid", cid);
            req_params.Add("props", props);

            return analyser.RequestTOPDataList<Product>(method, req_params);
        }

        /// <summary>
        /// taobao.products.search(搜索产品信息)
        /// 两种方式搜索所有产品信息(二种至少传一种): 
        /// 1.传入关键字q搜索 
        /// 2.传入cid和props搜索 
        /// </summary>
        /// <param name="q">搜索的关键词是用来搜索产品的title以及关键属性值的名称.如:"优衣库 1234",这种用来表示查询优衣库这个品牌下的货号为1234的产品;　注:q,cid和props至少传入一个 </param>
        /// <param name="cid">商品类目ID.调用taobao.itemcats.get.v2获取. </param>
        /// <param name="props">属性,属性值的组合.格式:pid:vid;pid:vid;调用taobao.itemprops.get.v2获取类目属性pid,再用taobao.itempropvalues.get取得vid. </param>
        /// <returns>返回具体信息为入参fields请求的字段信息 </returns>
        public TOPDataList<ProductListItem> QueryProducts(string q, string cid, string props)
        {
            return QueryProducts(q, cid, props, -1, -1);
        }

        /// <summary>
        /// taobao.products.search(搜索产品信息)
        /// 两种方式搜索所有产品信息(二种至少传一种): 
        /// 1.传入关键字q搜索 
        /// 2.传入cid和props搜索 
        /// </summary>
        /// <param name="q">搜索的关键词是用来搜索产品的title以及关键属性值的名称.如:"优衣库 1234",这种用来表示查询优衣库这个品牌下的货号为1234的产品;　注:q,cid和props至少传入一个 </param>
        /// <param name="cid">商品类目ID.调用taobao.itemcats.get.v2获取. </param>
        /// <param name="props">属性,属性值的组合.格式:pid:vid;pid:vid;调用taobao.itemprops.get.v2获取类目属性pid,再用taobao.itempropvalues.get取得vid. </param>
        /// <param name="page_size">每页条数.每页返回最多返回100条,默认值(-1)为40.</param>
        /// <param name="page_no">页码.传入值为1代表第一页,传入值为2代表第二页,依此类推.默认(-1)返回的数据是从第一页开始. </param>
        /// <returns>返回具体信息为入参fields请求的字段信息 </returns>
        public TOPDataList<ProductListItem> QueryProducts(string q, string cid, string props, int page_size, int page_no)
        {
            if (string.IsNullOrEmpty(q + cid + props))
            {
                throw new ArgumentException("缺少参数，q,cid和props至少传入一个。");
            }
            string method = "taobao.products.search";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("q", q);
            req_params.Add("cid", cid);
            req_params.Add("props", props);
            if (page_size != -1)
            {
                req_params.Add("page_size", page_size.ToString());
            }
            if (page_no != -1)
            {
                req_params.Add("page_no", page_no.ToString());
            }

            return analyser.RequestTOPDataList<ProductListItem>(method, req_params);
        }
    }
}
