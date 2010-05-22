namespace SLS.Security
{
    using Shove;
    using System;
    using System.Web.Security;

    public class Password
    {
        public static string Encrypt(string CallCert, string input)
        {
            if (CallCert != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                throw new Exception("Call the Password.Encrypt is request a CallCert.");
            }
            return FormsAuthentication.HashPasswordForStoringInConfigFile(input + "7ien.shovesoft.shove 中国深圳 2007-10-25", "MD5");
        }

        private static string GetCallCert()
        {
            string sSourceStr = "";
            string str2 = _String.Reverse("ShoveSoft" + " " + "CO.,Ltd ");
            str2 = _String.Reverse(_String.Reverse(str2) + ("--" + " by Shove "));
            sSourceStr = "20050709";
            sSourceStr = _String.Reverse(sSourceStr + _String.Reverse("圳深 ") + _String.Reverse("安宝"));
            return (_String.Reverse(str2) + _String.Reverse(sSourceStr));
        }
    }
}

