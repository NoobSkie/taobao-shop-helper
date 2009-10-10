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
        /// 包含iid，名称，卖家昵称，分类id，价格，类型
        /// </summary>
        public static string GetItemFields_InList()
        {
            return "iid,title,nick,cid,price,type";
        }
    }
}
