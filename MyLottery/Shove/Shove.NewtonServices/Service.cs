namespace Shove.NewtonServices
{
    using Shove.Properties;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Web.Services;
    using System.Web.Services.Description;
    using System.Web.Services.Protocols;

    [WebServiceBinding(Name="ServiceSoap", Namespace="http://tempuri.org/"), DesignerCategory("code"), DebuggerStepThrough, GeneratedCode("System.Web.Services", "2.0.50727.3053")]
    public class Service : SoapHttpClientProtocol
    {
        private bool useCredential;

        private SendOrPostCallback getSIOperationCompleted;
        public event getSICompletedEventHandler getSICompleted;

        public Service()
        {
            this.Url = Settings.Default.Shove_NewtonServices_Service;
            if (this.CheckUrl(this.Url))
            {
                this.UseDefaultCredentials = true;
                this.useCredential = false;
            }
            else
            {
                this.useCredential = true;
            }
        }
        
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        [SoapDocumentMethod("http://tempuri.org/getSI", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public int getSI(string Url, string Sign)
        {
            return (int) base.Invoke("getSI", new object[] { Url, Sign })[0];
        }

        public void getSIAsync(string Url, string Sign)
        {
            this.getSIAsync(Url, Sign, null);
        }

        public void getSIAsync(string Url, string Sign, object userState)
        {
            if (this.getSIOperationCompleted == null)
            {
                this.getSIOperationCompleted = new SendOrPostCallback(this.OngetSIOperationCompleted);
            }
            base.InvokeAsync("getSI", new object[] { Url, Sign }, this.getSIOperationCompleted, userState);
        }

        private void OngetSIOperationCompleted(object arg)
        {
            if (this.getSICompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.getSICompleted(this, new getSICompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private bool CheckUrl(string strUrl)
        {
            if ((strUrl == null) || (strUrl == string.Empty))
            {
                return false;
            }
            Uri uri = new Uri(strUrl);
            return ((uri.Port >= 0x400) && (string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0));
        }

        public new string Url
        {
            get
            {
                return base.Url;
            }
            set
            {
                if ((this.CheckUrl(base.Url) && !this.useCredential) && !this.CheckUrl(value))
                {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }

        public new bool UseDefaultCredentials
        {
            get
            {
                return base.UseDefaultCredentials;
            }
            set
            {
                base.UseDefaultCredentials = value;
                this.useCredential = true;
            }
        }
    }
}

