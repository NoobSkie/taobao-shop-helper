using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Top.Server.Wcf.Contract.TaobaoInterface
{
    /// <summary>
    /// Top远程Api外观接口
    /// </summary>
    [ServiceContract]
    public interface IShopApiFacade
    {
        /// <summary>
        /// 根据Nick获取店铺完整信息
        /// </summary>
        [OperationContract]
        FullShopInfo GetFullShopInfoByNick(string nick);
    }
}
