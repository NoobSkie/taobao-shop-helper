namespace SMS.Eucp.Gateway
{
    using System;

    public class SMS
    {
        public string Content;
        public string FromMobile;

        public SMS(string frommobile, string content)
        {
            this.FromMobile = frommobile;
            this.Content = content;
        }
    }
}

