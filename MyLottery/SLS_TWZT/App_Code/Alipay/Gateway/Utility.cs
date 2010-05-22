namespace Alipay.Gateway
{
    using Shove.Alipay;
    using System;
    using System.Collections;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;

    public class Utility
    {
        public static string[] BubbleSort(string[] r)
        {
            for (int i = 0; i < r.Length; i++)
            {
                bool flag = false;
                for (int j = r.Length - 2; j >= i; j--)
                {
                    if (string.CompareOrdinal(r[j + 1], r[j]) < 0)
                    {
                        string str = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = str;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    return r;
                }
            }
            return r;
        }

        public string CreateLoginUrl(string Gateway, string Partner, string SignType, string ReturnUrl, string Key, string InputCharset, string parameters)
        {
            int num;
            string[] strArray3 = BubbleSort(new string[] { "Partner=" + Partner, "InputCharset=" + InputCharset, "ReturnUrl=" + ReturnUrl, "parameters=" + parameters });
            StringBuilder builder = new StringBuilder();
            for (num = 0; num < strArray3.Length; num++)
            {
                if (num == (strArray3.Length - 1))
                {
                    builder.Append(strArray3[num]);
                }
                else
                {
                    builder.Append(strArray3[num] + "&");
                }
            }
            builder.Append(Partner + Key);
            string str = Shove.Alipay.Alipay.GetMD5(builder.ToString(), InputCharset);
            char[] separator = new char[] { '=' };
            StringBuilder builder2 = new StringBuilder();
            builder2.Append(Gateway);
            for (num = 0; num < strArray3.Length; num++)
            {
                builder2.Append(strArray3[num].Split(separator)[0] + "=" + HttpUtility.UrlEncode(strArray3[num].Split(separator)[1]) + "&");
            }
            builder2.Append("Sign=" + str + "&SignType=" + SignType);
            return builder2.ToString();
        }

        public string Createurl(string gateway, string service, string partner, string Key, string sign_type, string Charset, params string[] ParamsAndValue)
        {
            if (!gateway.EndsWith("?"))
            {
                gateway = gateway + "?";
            }
            ArrayList list = new ArrayList();
            list.Add("_input_charset=" + Charset);
            list.Add("partner=" + partner);
            list.Add("service=" + service);
            for (int i = 0; i < (ParamsAndValue.Length / 2); i++)
            {
                if ((ParamsAndValue[i * 2] != "") && (ParamsAndValue[(i * 2) + 1] != ""))
                {
                    list.Add(ParamsAndValue[i * 2].ToLower() + "=" + ParamsAndValue[(i * 2) + 1]);
                }
            }
            string[] strArray = new string[list.Count];
            string[] r = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                r[j] = list[j].ToString();
                strArray[j] = list[j].ToString();
            }
            string[] strArray3 = BubbleSort(r);
            StringBuilder builder = new StringBuilder();
            for (int k = 0; k < strArray3.Length; k++)
            {
                if (k == (strArray3.Length - 1))
                {
                    builder.Append(strArray3[k]);
                }
                else
                {
                    builder.Append(strArray3[k] + "&");
                }
            }
            builder.Append(Key);
            string str = GetMD5(builder.ToString(), Charset);
            char[] separator = new char[] { '=' };
            StringBuilder builder2 = new StringBuilder();
            builder2.Append(gateway);
            for (int m = 0; m < strArray.Length; m++)
            {
                builder2.Append(strArray[m].Split(separator)[0] + "=" + HttpUtility.UrlEncode(strArray[m].Split(separator)[1]) + "&");
            }
            builder2.Append("sign=" + str + "&sign_type=" + sign_type);
            return builder2.ToString();
        }

        public string CreatUrl(string gateway, string service, string partner, string sign_type, string key, string return_url, string _input_charset)
        {
            int num;
            string[] strArray3 = BubbleSort(new string[] { "service=" + service, "partner=" + partner, "_input_charset=" + _input_charset, "return_url=" + return_url });
            StringBuilder builder = new StringBuilder();
            for (num = 0; num < strArray3.Length; num++)
            {
                if (num == (strArray3.Length - 1))
                {
                    builder.Append(strArray3[num]);
                }
                else
                {
                    builder.Append(strArray3[num] + "&");
                }
            }
            builder.Append(key);
            string str = GetMD5(builder.ToString(), _input_charset);
            char[] separator = new char[] { '=' };
            StringBuilder builder2 = new StringBuilder();
            builder2.Append(gateway);
            for (num = 0; num < strArray3.Length; num++)
            {
                builder2.Append(strArray3[num].Split(separator)[0] + "=" + HttpUtility.UrlEncode(strArray3[num].Split(separator)[1]) + "&");
            }
            builder2.Append("sign=" + str + "&sign_type=" + sign_type);
            return builder2.ToString();
        }

        public string CreatUrl(string gateway, string service, string partner, string sign_type, string out_trade_no, string subject, string body, string payment_type, string total_fee, string show_url, string seller_email, string key, string return_url, string _input_charset, string notify_url, string agentID, string buyer_email)
        {
            int num;
            string[] strArray3 = BubbleSort(new string[] { "service=" + service, "partner=" + partner, "subject=" + subject, "body=" + body, "out_trade_no=" + out_trade_no, "total_fee=" + total_fee, "show_url=" + show_url, "payment_type=" + payment_type, "seller_email=" + seller_email, "notify_url=" + notify_url, "_input_charset=" + _input_charset, "return_url=" + return_url, "agent=" + agentID });
            StringBuilder builder = new StringBuilder();
            for (num = 0; num < strArray3.Length; num++)
            {
                if (num == (strArray3.Length - 1))
                {
                    builder.Append(strArray3[num]);
                }
                else
                {
                    builder.Append(strArray3[num] + "&");
                }
            }
            builder.Append(key);
            string str = GetMD5(builder.ToString(), _input_charset);
            char[] separator = new char[] { '=' };
            StringBuilder builder2 = new StringBuilder();
            builder2.Append(gateway);
            for (num = 0; num < strArray3.Length; num++)
            {
                builder2.Append(strArray3[num].Split(separator)[0] + "=" + HttpUtility.UrlEncode(strArray3[num].Split(separator)[1]) + "&");
            }
            builder2.Append("sign=" + str + "&sign_type=" + sign_type);
            return builder2.ToString();
        }

        public string CreatUrl(string gateway, string service, string partner, string sign_type, string out_trade_no, string subject, string body, string payment_type, string total_fee, string show_url, string seller_email, string key, string return_url, string _input_charset, string notify_url, string agentID, string BankCode, string buyer_email)
        {
            int num;
            string[] strArray3 = BubbleSort(new string[] { "service=" + service, "partner=" + partner, "subject=" + subject, "body=" + body, "out_trade_no=" + out_trade_no, "total_fee=" + total_fee, "show_url=" + show_url, "payment_type=" + payment_type, "seller_email=" + seller_email, "notify_url=" + notify_url, "_input_charset=" + _input_charset, "return_url=" + return_url, "defaultbank=" + BankCode, "agent=" + agentID });
            StringBuilder builder = new StringBuilder();
            for (num = 0; num < strArray3.Length; num++)
            {
                if (num == (strArray3.Length - 1))
                {
                    builder.Append(strArray3[num]);
                }
                else
                {
                    builder.Append(strArray3[num] + "&");
                }
            }
            builder.Append(key);
            string str = GetMD5(builder.ToString(), _input_charset);
            char[] separator = new char[] { '=' };
            StringBuilder builder2 = new StringBuilder();
            builder2.Append(gateway);
            for (num = 0; num < strArray3.Length; num++)
            {
                builder2.Append(strArray3[num].Split(separator)[0] + "=" + HttpUtility.UrlEncode(strArray3[num].Split(separator)[1]) + "&");
            }
            builder2.Append("sign=" + str + "&sign_type=" + sign_type);
            return builder2.ToString();
        }

        public static string GetMD5(string s, string _input_charset)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder builder = new StringBuilder(0x20);
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }
    }
}

