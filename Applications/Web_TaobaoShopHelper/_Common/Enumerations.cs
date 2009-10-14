using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public enum InformationIcoType
    {
        None = 0,
        Default = 1,
        Information = 11,
        Warning = 12,
        Question = 13,
        Stop = 14,
        Error = 15,
        Person = 16,
    }

    /// <summary>
    /// 列表中，商品显示的样式
    /// </summary>
    public enum ItemDisplayType
    {
        /// <summary>
        /// 大图显示，一行显示多个商品，商品图片较大。
        /// </summary>
        Image = 0,
        /// <summary>
        /// 列表显示，一行显示一个商品，商品图片较小，显示的信息较多。
        /// </summary>
        List = 1,
    }

    public enum SearchWinType
    {
        Multi_MyItems,
    }
}
