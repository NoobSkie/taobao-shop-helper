namespace Alipay.Gateway
{
    using Shove;
    using Shove._Web;
    using Shove.Alipay;
    using System;
    using System.IO;
    using System.Xml;

    public class Member
    {
        public string BuildLoginUrl()
        {
            SystemOptions options = new SystemOptions();
            string key = options["MemberSharing_Alipay_MD5"].ToString("");
            string str2 = Shove._Web.Utility.GetUrl() + "/MemberSharing/Alipay/Receive.aspx";
            string gateway = options["MemberSharing_Alipay_Gateway"].ToString("");
            string str4 = "utf-8";
            string service = "user_authentication";
            string str6 = "MD5";
            string partner = options["MemberSharing_Alipay_UserNumber"].ToString("");
            string returnUrl = Shove._Web.Utility.GetUrl() + "/MemberSharing/Alipay/Receive.aspx";
            Shove.Alipay.Alipay alipay = new Shove.Alipay.Alipay();
            return alipay.CreatUrl(gateway, service, partner, str6, key, str2, str4, returnUrl);
        }

        public string BuildRegisterUrl(string Acccount, object OtherInfo)
        {
            SystemOptions options = new SystemOptions();
            string gateway = options["MemberRegister_Alipay_Gateway"].ToString("");
            string service = "create_member";
            string partner = options["MemberRegister_Alipay_UserNumber"].ToString("");
            string key = options["MemberRegister_Alipay_MD5"].ToString("");
            string str5 = "MD5";
            string charset = "utf-8";
            if (((gateway == "") || (partner == "")) || (key == ""))
            {
                return "";
            }
            string str7 = Shove._Web.Utility.GetUrl() + "/AlipayMemberReceive/RegReceive.aspx";
            string str8 = Acccount;
            string str9 = "";
            string str10 = "";
            string str11 = "";
            string str12 = "";
            string str13 = OtherInfo.ToString();
            Gateway.Utility utility = new Gateway.Utility();
            if (PF.AlipayAccountRegisterPid != "")
            {
                return utility.Createurl(gateway, service, partner, key, str5, charset, new string[] { "email", str8, "cert_type", str9, "cert_no", str10, "company_name", str11, "account_type", str12, "other_info", str13, "return_url", str7, "id", PF.AlipayAccountRegisterPid });
            }
            return utility.Createurl(gateway, service, partner, key, str5, charset, new string[] { "email", str8, "cert_type", str9, "cert_no", str10, "company_name", str11, "account_type", str12, "other_info", str13, "return_url", str7 });
        }

        public long Query(string Account, ref string RealityName)
        {
            SystemOptions options = new SystemOptions();
            string gateway = options["MemberRegister_Alipay_Gateway"].ToString("");
            string service = "user_query";
            string partner = options["MemberRegister_Alipay_UserNumber"].ToString("");
            string key = options["MemberRegister_Alipay_MD5"].ToString("");
            string charset = "utf-8";
            string str6 = "MD5";
            if (((gateway == "") || (partner == "")) || (key == ""))
            {
                return -1L;
            }
            Utility ul = new Gateway.Utility();
            string url = ul.Createurl(gateway, service, partner, key, str6, charset, new string[] { "email", Account });
            string str8 = "";
            try
            {
                str8 = PF.GetHtml(url, "utf-8", 20);
            }
            catch
            {
                return -2L;
            }
            if (string.IsNullOrEmpty(str8))
            {
                return -3L;
            }
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(new StringReader(str8));
            }
            catch
            {
                return -4L;
            }
            XmlNodeList elementsByTagName = document.GetElementsByTagName("is_success");
            if ((elementsByTagName == null) || (elementsByTagName.Count < 1))
            {
                return -5L;
            }
            if (elementsByTagName[0].InnerText.ToUpper() != "T")
            {
                return -6L;
            }
            XmlNodeList list2 = document.GetElementsByTagName("user_id");
            if ((list2 == null) || (list2.Count < 1))
            {
                return -7L;
            }
            XmlNodeList list3 = document.GetElementsByTagName("real_name");
            if ((list3 != null) && (list3.Count >= 1))
            {
                RealityName = list3[0].InnerText;
            }
            else
            {
                RealityName = "";
            }
            return _Convert.StrToLong(list2[0].InnerText, -8L);
        }
    }
}

