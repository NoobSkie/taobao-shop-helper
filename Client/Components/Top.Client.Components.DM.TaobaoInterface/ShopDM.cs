using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Top.Client.Components.Communication;

namespace Top.Client.Components.DM
{
    public class ShopDM
    {
        private string wcfServer = string.Empty;

        public ShopDM(string wcfServer_)
        {
            wcfServer = wcfServer_;
            CommunicationManager.init(wcfServer_, BasicHttpSecurityMode.TransportCredentialOnly);
        }

        private ChannelFactory<T> GetService<T>()
        {
            if (!string.IsNullOrEmpty(wcfServer))
            {
                BasicHttpBinding bind = new BasicHttpBinding();
                bind.MaxReceivedMessageSize = 2147483647;
                bind.MaxBufferSize = 2147483647;
                //bind.MaxBufferPoolSize = 52428800;
                //bind.ReaderQuotas.MaxArrayLength = 2147483647;
                //bind.ReaderQuotas.MaxStringContentLength = 2147483647;
                bind.SendTimeout = new TimeSpan(0, 20, 0);
                bind.ReceiveTimeout = new TimeSpan(0, 20, 0);
                EndpointAddress address = new EndpointAddress(wcfServer);
                return new ChannelFactory<T>(bind, address);
            }
            else
            {
                return new ChannelFactory<T>(typeof(T).Name);
            }
        }

        private void aa(IAsyncResult result)
        {
            
        }

        public string GetFullShopInfoByNick(string nick)
        {
            object obj = CommunicationManager.Invoke("ShopApiFacade.GetFullShopInfoByNick", nick);
            return obj.ToString();
            //ServiceReference1.ShopApiFacadeClient client = new Top.Client.Components.DM.ServiceReference1.ShopApiFacadeClient();
            //ServiceReference1.IShopApiFacade facade = client.ChannelFactory.CreateChannel();
            //IAsyncResult result = facade.BeginGetFullShopInfoByNick(nick, aa, nick);
            //ServiceReference1.FullShopInfo shop = facade.EndGetFullShopInfoByNick(result);
            //return shop.Title;
            //ChannelFactory<IShopApiFacade> chl = GetService<IShopApiFacade>();
            //try
            //{
            //    chl.Open();

            //    IShopApiFacade service = chl.CreateChannel();

            //    FullShopInfo rtn = service.GetFullShopInfoByNick(nick);

            //    chl.Close();

            //    return rtn;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("执行SQL发生异常 - " + ex.Message);
            //}
            //finally
            //{
            //    if (chl.State != CommunicationState.Closed)
            //    {
            //        chl.Close();
            //    }
            //}
        }
    }
}
