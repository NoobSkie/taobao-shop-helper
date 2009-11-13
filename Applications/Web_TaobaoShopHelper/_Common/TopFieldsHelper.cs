using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    /// <summary>
    /// 获取TOP请求字段的类
    /// </summary>
    public static class TopFieldsHelper
    {
        /// <summary>
        /// 商品字段 - 列表中的商品。
        /// 包含iid，名称，卖家昵称，分类id，价格，类型，图片路径
        /// </summary>
        public static string GetItemFields_InList()
        {
            return "iid,title,nick,cid,price,type,pic_path";
        }

        public static string GetItemFields_OnlyId()
        {
            return "iid";
        }

        public static string GetItemFields_All()
        {
            return "iid,title,nick,cid,price,type,pic_path";
        }

        /// <summary>
        /// 获取所有店铺的字段
        /// </summary>
        /// <returns></returns>
        public static string GetShopFields_Common()
        {
            return "sid,cid,title,nick,bulletin,pic_path,created,modified";
        }

        public static string GetShopFields_OnlyTitle()
        {
            return "title";
        }

        public static string GetItemCatFields_Name()
        {
            return "cid,name,status";
        }

        public static string GetUserFields_All()
        {
            return "nick,sex,buyer_credit,seller_credit,location.city,location.state,location.country,created,last_visit";
        }
    }
}
