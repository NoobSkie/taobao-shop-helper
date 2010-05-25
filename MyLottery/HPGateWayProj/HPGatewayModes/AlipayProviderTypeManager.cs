using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPGatewayModels
{
    public class AlipayProviderTypeManager
    {
        public List<AlipayProviderType> providerTypes = new List<AlipayProviderType>();

        public AlipayProviderTypeManager()
        {
            this.providerTypes.Clear();
            this.CreateProviderTypes();
        }

        private void CreateProviderTypes()
        {
            this.providerTypes.Clear();

            AlipayProviderType providerType = new AlipayProviderType("2101", "银联");
            this.providerTypes.Add(providerType);

            providerType = new AlipayProviderType("2102", "支付宝");
            this.providerTypes.Add(providerType);

            providerType = new AlipayProviderType("2103", "腾讯财付通");
            this.providerTypes.Add(providerType);

            providerType = new AlipayProviderType("2104", "汇付天下");
            this.providerTypes.Add(providerType);

            providerType = new AlipayProviderType("2105", "快钱");
            this.providerTypes.Add(providerType);

            providerType = new AlipayProviderType("2106", "网银在线");
            this.providerTypes.Add(providerType);

            providerType = new AlipayProviderType("2107", "云网支付");
            this.providerTypes.Add(providerType);
        }
    }
}
