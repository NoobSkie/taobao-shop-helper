using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taobao.Top.Api;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Domain;
using Taobao.Top.Api.Parser;
using Top.Server.Wcf.Contract.TaobaoInterface;

namespace Top.Server.TaobaoInterface
{
    public class ShopApiFacade : IShopApiFacade
    {
        /// <summary>
        /// 根据Nick获取店铺完整信息
        /// </summary>
        public FullShopInfo GetFullShopInfoByNick(string nick)
        {
            ITopClient client = new TopRestClient("http://gw.api.taobao.com/router/rest", "12001666", "e121148ca8d31bc28a4743241b74c2bd", "json");
            ShopGetRequest req = new ShopGetRequest();
            req.Fields = "sid,cid,title,nick,desc,bulletin,pic_path,created,modified";
            req.Nick = nick;
            Shop shop = client.Execute(req, new ShopJsonParser());
            return GetFacadeObjectByDomain(shop);
        }

        private FullShopInfo GetFacadeObjectByDomain(Shop entity)
        {
            if (entity == null) return null;

            FullShopInfo info = new FullShopInfo();
            info.Sid = entity.Sid;
            info.Cid = entity.Cid;
            info.Title = entity.Title;
            info.SellerNick = entity.SellerNick;
            info.Description = entity.Description;
            info.Bulletin = entity.Bulletin;
            info.RemainShowcase = entity.RemainShowcase;
            info.LogoUrl = entity.LogoUrl;
            info.Created = entity.Created;
            info.Modified = entity.Modified;
            return info;
        }
    }
}
