using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taobao.Top.Api.Request;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public class TopSessionRequestProxy : ITopRequest
    {
        private ITopRequest currentRequest;
        private string currentSession;

        public TopSessionRequestProxy(ITopRequest request, string session)
        {
            currentRequest = request;
            currentSession = session;
        }

        #region ITopRequest Members

        public string GetApiName()
        {
            return currentRequest.GetApiName();
        }

        public IDictionary<string, string> GetParameters()
        {
            IDictionary<string, string> parameters = currentRequest.GetParameters();
            parameters.Add("session", currentSession);
            return parameters;
        }

        #endregion
    }
}
