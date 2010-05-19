using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;
using Top.Client.Components.DataObject;

namespace Top.Client.Components.Communication
{
    public class ChannelItem
    {
        // Fields
        private IFICService _service;

        // Methods
        private ChannelItem(IFICService service)
        {
            this._service = service;
        }

        public static ChannelItem CreateInstance(string uri)
        {
            BasicHttpBinding bind = new BasicHttpBinding();
            bind.MaxReceivedMessageSize = 0x200000L;
            bind.MaxBufferSize = 0x200000;
            EndpointAddress address = new EndpointAddress(uri);
            return CreateInstance(bind, address);
        }

        public static ChannelItem CreateInstance(BasicHttpBinding bind, EndpointAddress address)
        {
            ChannelFactory<IFICService> factory = new ChannelFactory<IFICService>(bind, address);
            factory.Open();
            IFICService service = factory.CreateChannel();
            return ((service == null) ? null : new ChannelItem(service));
        }

        public object Invoke(string name, params object[] parameters)
        {
            IAsyncResult result = this._service.BeginInvoke(CommunicationManager.ClientID, new InvokeInfo(name, parameters), null, null);
            InvokeResult result2 = this._service.EndInvoke(result);
            if (result2.Error != null)
            {
                throw new ServiceException(result2.Error.ClassFullName, result2.Error.CustomErrorCode, result2.Error.Parameters);
            }
            return result2.Result;
        }
    }
}
