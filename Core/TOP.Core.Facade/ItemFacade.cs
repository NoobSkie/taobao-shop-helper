using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;
using System.IO;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 商品外观服务对象
    /// </summary>
    public class ItemFacade
    {
        private readonly AnalyseData analyser;
        private string currentAppKey, currentAppSecret, currentVersion;

        public ItemFacade(string appKey, string appSecret) : this(appKey, appSecret, "1.0") { }

        public ItemFacade(string appKey, string appSecret, string version)
        {
            currentAppKey = appKey;
            currentAppSecret = appSecret;
            currentVersion = version;

            analyser = new AnalyseData(appKey, appSecret, version);
        }

        public string AddItem(
            string number               // 商品数量，取值范围:大于零的整数。数量需要等于SKU所有数量的和 
            , string price              // 商品价格。取值范围:0-100000000;精确到2位小数;单位:元。如:200.07，表示:200元7分。需要在正确的价格区间内。 
            , string itemType           // 发布类型。可选值:fixed(一口价),auction(拍卖)。B商家不能发布拍卖商品，而且拍卖商品是没有SKU的 
            , string stuff_status       // 新旧程度。可选值：new(新)，second(二手)，unused(闲置)。B商家不能发布二手商品。如果是二手商品，特定类目下属性里面必填新旧成色属性
            , string title              // 宝贝标题。不能超过60字节，受违禁词控制 
            , string description        // 宝贝描述。字数要大于5个字符，小于25000个字符，受违禁词控制 
            , string province           // 所在地省份。如浙江，具体可以用taobao.areas.get 取到 
            , string city               // 所在地城市。如杭州 。具体可以用taobao.areas.get 取到 
            , string categoryId         // 叶子类目id
            , string properties         // 商品属性列表。格式:pid:vid;pid:vid。
            // 属性的pid调用taobao.itemprops.get.v2取得，属性值的vid用taobao.itempropvalues.get取得vid。 
            // 如果该类目下面没有属性，可以不用填写。如果有属性，必选属性必填，其他非必选属性可以选择不填写.
            // 属性不能超过35对。所有属性加起来包括分割符不能超过549字节，单个属性没有限制。 
            // 如果有属性是可输入的话，则用字段input_str填入属性的值 
            , string approve_status     // 商品上传后的状态。可选值:onsale(出售中),instock(仓库中);默认值:onsale 
            , string freight_payer      // 运费承担方式。可选值:seller（卖家承担）,buyer(买家承担);默认值:seller。卖家承担不用设置邮费和postage_id.买家承担的时候，必填邮费和postage_id. 如果用户设置了运费模板会优先使用运费模板，否则要同步设置邮费（post_fee,express_fee,ems_fee） 
            , string valid_thru         // 有效期。可选值:7,14;单位:天;默认值:14 
            , string has_invoice        // 是否有发票。可选值:true,false (商城卖家此字段必须为true);默认值:false(无发票) 
            , string has_warranty 	    // 是否有保修。可选值:true,false;默认值:false(不保修) 
            , string auto_repost 	    // 自动重发。可选值:true,false;默认值:false(不重发) 
            , string has_showcase       // 橱窗推荐。可选值:true,false;默认值:false(不推荐) 
            , string seller_cids        // 商品所属的店铺类目列表。按逗号分隔。结构:",cid1,cid2,...,"，如果店铺类目存在二级类目，必须传入子类目cids。 
            , string has_discount 	    // 支持会员打折。可选值:true,false;默认值:false(不打折) 
            , string post_fee 	        // 平邮费用。取值范围:0.01-10000.00;精确到2位小数;单位:元。如:5.07，表示:5元7分. 注:post_fee,express_fee,ems_fee需要一起填写 
            , string express_fee 	    // 快递费用。取值范围:0.01-10000.00;精确到2位小数;单位:元。如:15.07，表示:15元7分 
            , string ems_fee 	        // ems费用。取值范围:0-100000000;精确到2位小数;单位:元。如:25.07，表示:25元7分
            , string list_time 	        // 定时上架时间。(时间格式：yyyy-MM-dd HH:mm:ss) 
            , string increment 	        // 加价幅度。如果为0，代表系统代理幅度
            , string postage_id         // 宝贝所属的运费模板ID。模板可以通过taobao.postages.get获得 
            , string imagePath 	        // 商品主图片。类型:JPG,GIF;最大长度:500K 
            , string auction_point 	    // 商品的积分返点比例。如:5,表示:返点比例0.5%. 注意：返点比例必须是>0的整数，而且最大是90,即为9%.B商家在发布非虚拟商品时，返点必须是 5的倍数，即0.5%的倍数。其它是1的倍数，即0.1%的倍数 
            , string property_alias 	// 属性值别名。如pid:vid:别名;pid1:vid1:别名1 ，其中：pid是属性id vid是属性值id。总长度不超过511字节 
            , string input_pids 	    // 用户自行输入的类目属性ID串。结构："pid1,pid2,pid3"，如："20000"（表示品牌） 注：通常一个类目下用户可输入的关键属性不超过1个。 
            , string input_str 	        // 用户自行输入的子属性名和属性值，
            // 结构:"父属性值;一级子属性名;一级子属性值;二级子属性名;自定义输入值,....",
            // 如：“耐克;耐克系列;科比系列;科比系列;2K5,Nike 乔丹鞋;乔丹系列;乔丹鞋系列;乔丹鞋系列;json5”，
            // 多个自定义属性用','分割，input_str需要与input_pids一一对应，
            // 注：通常一个类目下用户可输入的关键属性不超过1个。所有属性别名加起来不能超过3999字节 
            , string sku_properties 	    // 更新的SKU的属性串，调用taobao.itemprops.get.v2获取类目属性，如果属性是销售属性，再用 taobao.itempropvalues.get取得vid。
            // 格式:pid:vid;pid:vid。该字段内的销售属性也需要在props字段填写。sku的销售属性需要一同选取，如:颜色，尺寸 
            , string sku_quantities 	// SKU的数量串，结构如：num1,num2,num3 如：2,3 
            , string sku_prices 	    // SKU的价格串，结构如：10.00,5.00,… 精确到2位小数;单位:元。如:200.07，表示:200元7分
            , string sku_outer_ids 	    // SKU的外部id串，结构如：1234,1342,…
            // sku_properties, sku_quantities, sku_prices, sku_outer_ids在输入数据时要一一对应，如果没有sku_outer_ids可写成：“, ,” 
            , string lang 	            // 商品文字的字符集。繁体传入"zh_HK"，简体传入"zh_CN"，不传默认为简体 
            , string outer_id           // 商家编码
            , string product_id         // 商品所属的产品ID(B商家发布商品需要用) 
            , string sessionKey)
        {
            string method = "taobao.item.add";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("session", sessionKey);
            req_params.Add("num", number);
            req_params.Add("price", price);
            req_params.Add("type", itemType);
            req_params.Add("stuff_status", stuff_status);
            req_params.Add("title", title);
            req_params.Add("desc", description);
            req_params.Add("location.state", province);
            req_params.Add("location.city", city);
            req_params.Add("cid", categoryId);

            req_params.Add("props", properties);
            req_params.Add("approve_status", approve_status);
            req_params.Add("freight_payer", freight_payer);
            req_params.Add("valid_thru", valid_thru);
            req_params.Add("has_invoice", has_invoice);
            req_params.Add("has_warranty", has_warranty);
            req_params.Add("auto_repost", auto_repost);
            req_params.Add("has_showcase", has_showcase);
            req_params.Add("seller_cids", seller_cids);
            req_params.Add("has_discount", has_discount);
            req_params.Add("post_fee", post_fee);
            req_params.Add("express_fee", express_fee);
            req_params.Add("ems_fee", ems_fee);
            req_params.Add("list_time", list_time);
            req_params.Add("increment", increment);
            req_params.Add("postage_id", postage_id);
            req_params.Add("auction_point", auction_point);
            req_params.Add("property_alias", property_alias);

            req_params.Add("input_pids", input_pids);
            req_params.Add("input_str", input_str);
            req_params.Add("sku_properties", sku_properties);
            req_params.Add("sku_quantities", sku_quantities);
            req_params.Add("sku_prices", sku_prices);
            req_params.Add("sku_outer_ids", sku_outer_ids);
            req_params.Add("lang", lang);
            req_params.Add("outer_id", outer_id);
            req_params.Add("product_id", product_id);

            try
            {
                ResultObject result;
                if (!string.IsNullOrEmpty(imagePath))
                {
                    Dictionary<string, FileInfo> fileParams = new Dictionary<string, FileInfo>();
                    fileParams.Add("image", new FileInfo(imagePath));

                    result = analyser.RequestTOPResult(method, req_params, fileParams);
                }
                else
                {
                    result = analyser.RequestTOPResult(method, req_params);
                }

                return "";
            }
            catch (ResponseException ex)
            {
                throw ex;
            }
        }

        public string UpdateItemDescription(string iid, string description)
        {
            string method = "taobao.item.update";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("session", "1a3ea0b7eebc93fa75f7d2b7eb203d70d");
            req_params.Add("iid", iid);
            req_params.Add("desc", description);

            try
            {
                ResultObject result = analyser.RequestTOPResult(method, req_params);
                return "";
            }
            catch (ResponseException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询指定卖家，获取基础商品列表。分页功能。
        /// </summary>
        public TOPDataList<SampleListItem> QuerySampleListByNick(int page_no, int page_size, string nick)
        {
            string method = "taobao.items.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("nicks", nick);
            req_params.Add("page_no", page_no.ToString());
            req_params.Add("page_size", page_size.ToString());

            return analyser.RequestTOPDataList<SampleListItem>(method, req_params);
        }

        /// <summary>
        /// 查询指定卖家及关键字的商品列表。
        /// </summary>
        /// <param name="key">商品关键字</param>
        /// <param name="nick">卖家昵称。最多5个，超出部分被自动截断。</param>
        /// <returns></returns>
        public TOPDataList<ItemListItem> QueryItemListByNicksAndKey(string key, params string[] nicks)
        {
            // 查询的卖家
            List<string> nickList = new List<string>(nicks);
            while (nickList.Count > 5)
            {
                nickList.RemoveAt(5);
            }

            string method = "taobao.items.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("nicks", string.Join(",", nickList.ToArray()));
            req_params.Add("q", key);

            return analyser.RequestTOPDataList<ItemListItem>(method, req_params);
        }

        /// <summary>
        /// 查询卖家的商品列表。最多5个卖家昵称。
        /// </summary>
        /// <param name="nick">卖家昵称。最多5个，超出部分被自动截断。</param>
        /// <returns></returns>
        public TOPDataList<ItemListItem> QueryItemListByNicks(params string[] nicks)
        {
            // 查询的卖家
            List<string> nickList = new List<string>(nicks);
            while (nickList.Count > 5)
            {
                nickList.RemoveAt(5);
            }

            string method = "taobao.items.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("nicks", string.Join(",", nickList.ToArray()));

            return analyser.RequestTOPDataList<ItemListItem>(method, req_params);
        }

        /// <summary>
        /// 查询卖家的商品列表。分页功能。
        /// </summary>
        /// <param name="nick">卖家昵称。最多5个，超出部分被自动截断。</param>
        /// <returns></returns>
        public TOPDataList<ItemListItem> QueryItemListByNicks(int page_no, int page_size, params string[] nicks)
        {
            // 查询的卖家
            List<string> nickList = new List<string>(nicks);
            while (nickList.Count > 5)
            {
                nickList.RemoveAt(5);
            }

            string method = "taobao.items.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("nicks", string.Join(",", nickList.ToArray()));
            req_params.Add("page_no", page_no.ToString());
            req_params.Add("page_size", page_size.ToString());

            return analyser.RequestTOPDataList<ItemListItem>(method, req_params);
        }

        /// <summary>
        /// 根据关键字查询商品列表。
        /// </summary>
        /// <param name="q">商品关键字</param>
        /// <returns></returns>
        public TOPDataList<ItemListItem> QueryItemListByKey(string q)
        {
            string method = "taobao.items.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("q", q);

            return analyser.RequestTOPDataList<ItemListItem>(method, req_params);
        }

        /// <summary>
        /// 得到单个商品信息明细信息
        /// </summary>
        /// <param name="iid">商品ID</param>
        /// <param name="nick">卖家昵称</param>
        /// <returns></returns>
        public ItemDetail GetItem(string iid, string nick)
        {
            string method = "taobao.item.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("iid", iid);
            req_params.Add("nick", nick);

            return analyser.RequestTOPDataItem<ItemDetail>(method, req_params);
        }

        /// <summary>
        /// 根据卖家昵称和商品ID列表获取SKU信息
        /// </summary>
        /// <param name="iid">商品ID</param>
        /// <param name="nick">卖家昵称</param>
        /// <returns></returns>
        public TOPDataList<Sku> GetSkuListByNick(string iid, string nick)
        {
            string method = "taobao.item.skus.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("iids", iid);
            req_params.Add("nick", nick);

            return analyser.RequestTOPDataList<Sku>(method, req_params);
        }

        /// <summary>
        /// 获取SKU
        /// </summary>
        /// <param name="skuId">Sku的id</param>
        /// <param name="nick">Sku所属用户的昵称</param>
        /// <returns></returns>
        public Sku GetSku(string skuId, string nick)
        {
            string method = "taobao.item.sku.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("sku_id", skuId);
            req_params.Add("nick", nick);

            return analyser.RequestTOPDataItem<Sku>(method, req_params);
        }

        public ResultObject AddSku(string iid, string properties, string quantity, string price, string outer_id, string lang)
        {
            string method = "taobao.item.sku.add";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("iid", iid);
            req_params.Add("properties", properties);
            req_params.Add("quantity", quantity);
            req_params.Add("price", price);
            req_params.Add("outer_id", outer_id);
            req_params.Add("lang", lang);

            return analyser.RequestTOPDataItem<ResultObject>(method, req_params);
        }

        /// <summary>
        /// 获取属性信息
        /// </summary>
        /// <param name="cid">叶子类目ID ,通过taobao.itemcats.get.v2获得叶子类目ID</param>
        /// <param name="pvs">属性和属性值 id串，格式例如(pid1;pid2)或(pid1:vid1;pid2:vid2)或(pid1;pid2:vid2)</param>
        /// <returns></returns>
        public TOPDataList<ItemPropValue> GetItemPropValues(string cid, string pvs)
        {
            string method = "taobao.itempropvalues.get";
            Dictionary<string, string> req_params = new Dictionary<string, string>();
            req_params.Add("cid", cid);
            req_params.Add("pvs", pvs);

            return analyser.RequestTOPDataList<ItemPropValue>(method, req_params);
        }
    }
}
