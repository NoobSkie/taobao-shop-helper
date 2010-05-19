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

namespace Top.Client.Components.Communication
{
    [ServiceContract]
    public interface IFICService
    {
        // Methods
        [OperationContract(AsyncPattern = true, Action = "http://tempuri.org/IFICService/Invoke", ReplyAction = "http://tempuri.org/IFICService/InvokeResponse")]
        IAsyncResult BeginInvoke(string clientID, InvokeInfo info, AsyncCallback callback, object asyncState);
        InvokeResult EndInvoke(IAsyncResult result);
    }
}
