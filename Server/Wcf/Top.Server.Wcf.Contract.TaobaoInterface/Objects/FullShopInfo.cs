using System;
using System.Xml.Serialization;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Top.Server.Wcf.Contract.TaobaoInterface
{
    /// <summary>
    /// 店铺完整信息
    /// </summary>
    [DataContract]
    public class FullShopInfo : ApiBaseInfo
    {
        /// <summary>
        /// 店铺编号
        /// </summary>
        [DataMember]
        public string Sid { get; set; }

        /// <summary>
        /// 店铺所属的类目编号
        /// </summary>
        [DataMember]
        public string Cid { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        [DataMember]
        public string SellerNick { get; set; }

        /// <summary>
        /// 店铺标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 店铺描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 店铺公告
        /// </summary>
        [DataMember]
        public string Bulletin { get; set; }

        /// <summary>
        /// 店标地址
        /// </summary>
        [DataMember]
        public string LogoUrl { get; set; }

        /// <summary>
        /// 剩余橱窗推荐数
        /// </summary>
        [DataMember]
        public int RemainShowcase { get; set; }
    }
}
