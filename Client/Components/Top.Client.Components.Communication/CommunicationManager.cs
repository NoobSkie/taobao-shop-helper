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
using System.ServiceModel.Channels;
using System.Text;
using Top.Client.Components.DataObject;
using System.Threading;

namespace Top.Client.Components.Communication
{
    public class CommunicationManager
    {
        // Fields
        private static string _addr;
        private static string _clientID = Guid.NewGuid().ToString();
        private static IFICService _FICService;
        private static BasicHttpSecurityMode _sMode = BasicHttpSecurityMode.None;
        private static string _userIID = Guid.Empty.ToString();
        private const string LHBISAuthCookieIV = "LHBIS.DSC";
        private const string LHBISAuthCookieKey = "LhbisFicHttpPasswordKey";
        private const string LHBISAuthCookieName = "LHBISAuthCookie";
        private const string LHBISUseraTokenKey = "LhbisFicUserIDKey";

        // Methods
        private static Guid Decrpty(string key, string input)
        {
            try
            {
                return new Guid(SymmetricCrypt.Decrypt(key, "LHBIS.DSC", input).Substring(0, 0x24));
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        private static string DescriptUserIID(string UserIIDToken)
        {
            try
            {
                return Decrpty("LhbisFicUserIDKey", UserIIDToken).ToString();
            }
            catch
            {
                return Guid.Empty.ToString();
            }
        }

        private static string Encrpty(string key, Guid userIID)
        {
            string input = userIID.ToString() + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            return SymmetricCrypt.Encrypt(key, "LHBIS.DSC", input);
        }

        public static void init(string bindingAddress, BasicHttpSecurityMode sMode)
        {
            _addr = bindingAddress;
            _sMode = sMode;
        }

        private static object Invoke(InvokeInfo iInfo, int nReTry)
        {
            try
            {
                InvokeResult result;
                using (new OperationContextScope((IContextChannel)Service))
                {
                    HttpRequestMessageProperty property = new HttpRequestMessageProperty();
                    property.Headers["LHBISAuthCookie"] = UsrHeaderToken;
                    OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, property);
                    IAsyncResult result2 = Service.BeginInvoke(_clientID, iInfo, null, null);
                    result = Service.EndInvoke(result2);
                }
                if (result.Error != null)
                {
                    throw new ServiceException(result.Error.ClassFullName, result.Error.CustomErrorCode, result.Error.Parameters);
                }
                return result.Result;
            }
            catch (ThreadAbortException)
            {
            }
            catch (ServiceException exception)
            {
                throw exception;
            }
            catch (TimeoutException)
            {
                if (nReTry <= 0)
                {
                    throw new ServiceException("Error.LHBIS.FIC.Communication", "timeout", new string[] { iInfo.Name });
                }
                return Invoke(iInfo, nReTry - 1);
            }
            catch (Exception exception2)
            {
                if (nReTry > 0)
                {
                    return Invoke(iInfo, nReTry - 1);
                }
                StringBuilder builder = new StringBuilder();
                builder.Append(exception2.Message).Append("\r\n").Append(exception2.StackTrace);
                if (exception2.InnerException != null)
                {
                    builder.Append("\r\n").Append(exception2.InnerException.Message).Append("\r\n").Append(exception2.InnerException.StackTrace);
                }
                throw new ServiceException("Error.LHBIS.FIC.Communication", "unknown", exception2, new string[] { iInfo.Name, builder.ToString() });
            }
            return null;
        }

        public static object Invoke(string name, params object[] parameters)
        {
            return Invoke(new InvokeInfo(name, parameters), 1);
        }

        public static object Login(string userID, string password)
        {
            string key = Guid.NewGuid().ToString();
            string iV = Guid.NewGuid().ToString();
            InvokeInfo info = new InvokeInfo("Decrypt", new object[] { key, iV, SymmetricCrypt.Encrypt(key, iV, userID) });
            InvokeInfo info2 = new InvokeInfo("Decrypt", new object[] { key, iV, SymmetricCrypt.Encrypt(key, iV, password) });
            return Invoke("User.Login", new object[] { info, info2 });
        }

        public static void SetUserInfo(string UserIIDToken)
        {
            _userIID = DescriptUserIID(UserIIDToken);
        }

        // Properties
        private static string addr
        {
            get
            {
                return _addr;
            }
        }

        public static string ClientID
        {
            get
            {
                return _clientID;
            }
        }

        private static IFICService Service
        {
            get
            {
                if (_addr == null)
                {
                    throw new Exception("The binding address must not be null.");
                }
                if (_FICService == null)
                {
                    BasicHttpBinding binding = new BasicHttpBinding(_sMode);
                    binding.MaxReceivedMessageSize = 0x400000L;
                    binding.MaxBufferSize = 0x400000;
                    EndpointAddress remoteAddress = new EndpointAddress(_addr);
                    ChannelFactory<IFICService> factory = new ChannelFactory<IFICService>(binding, remoteAddress);
                    factory.Open();
                    _FICService = factory.CreateChannel();
                }
                return _FICService;
            }
        }

        public static string UsrHeaderToken
        {
            get
            {
                return Encrpty("LhbisFicHttpPasswordKey", new Guid(_userIID));
            }
        }
    }
}
