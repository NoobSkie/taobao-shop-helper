namespace Shove.Alipay
{
    using Shove;
    using Shove._Security;
    using Shove.Database;
    using System;
    using System.Collections;
    using System.Data;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Xml;

    public class Alipay
    {
        private string _key = "438p67m0bkl0xb7wvv96ktcitob42aws";//安全校验码
        private double _num = 0.01;//分润点
        private string _royaltyParameters = "alipay_cn_service@yahoo.com";//平台分润账户
        private string _partner = "2088101178484721";//商户ID，合作ID

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

        public string Creaturl(string gateway, string service, string partner, string Key, string sign_type, string Charset, params string[] ParamsAndValue)
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

        public string CreatUrl(string gateway, string service, string partner, string sign_type, string key, string return_url, string _input_charset, string ReturnUrl)
        {
            int num;
            if (!gateway.EndsWith("?"))
            {
                gateway = gateway + "?";
            }
            string[] strArray2 = BubbleSort(new string[] { "service=" + service, "partner=" + partner, "_input_charset=" + _input_charset, "return_url=" + return_url, "returnurl=" + ReturnUrl });
            StringBuilder builder = new StringBuilder();
            for (num = 0; num < strArray2.Length; num++)
            {
                if (num == (strArray2.Length - 1))
                {
                    builder.Append(strArray2[num]);
                }
                else
                {
                    builder.Append(strArray2[num] + "&");
                }
            }
            builder.Append(key);
            string str = GetMD5(builder.ToString(), _input_charset);
            char[] separator = new char[] { '=' };
            StringBuilder builder2 = new StringBuilder();
            builder2.Append(gateway);
            for (num = 0; num < strArray2.Length; num++)
            {
                builder2.Append(strArray2[num].Split(separator)[0] + "=" + HttpUtility.UrlEncode(strArray2[num].Split(separator)[1]) + "&");
            }
            builder2.Append("sign=" + str + "&sign_type=" + sign_type);
            return builder2.ToString();
        }

        //service 交易类型
        public string CreatUrl(string gateway, string service, string partner, string sign_type, string batch_no, string account_name, string batch_fee, string batch_num, string email, string pay_date, string detail_data, string key, string notify_url, string _input_charset)
        {
            int num;
            string[] strArray2 = BubbleSort(new string[] { "service=" + service, "partner=" + partner, "batch_no=" + batch_no, "account_name=" + account_name, "batch_fee=" + batch_fee, "batch_num=" + batch_num, "email=" + email, "pay_date=" + pay_date, "detail_data=" + detail_data, "notify_url=" + notify_url, "_input_charset=" + _input_charset });
            StringBuilder builder = new StringBuilder();
            for (num = 0; num < strArray2.Length; num++)
            {
                if (num == (strArray2.Length - 1))
                {
                    builder.Append(strArray2[num]);
                }
                else
                {
                    builder.Append(strArray2[num] + "&");
                }
            }
            builder.Append(key);
            string str = GetMD5(builder.ToString(), _input_charset);
            StringBuilder builder2 = new StringBuilder();
            builder2.Append(gateway);
            for (num = 0; num < strArray2.Length; num++)
            {
                builder2.Append(strArray2[num] + "&");
            }
            builder2.Append("sign=" + str + "&sign_type=" + sign_type);
            return builder2.ToString();
        }

        public string CreatUrl(string gateway, string service, string partner, string return_url, string notify_url, string out_trade_no, string subject, string payment_type, string total_fee, string seller_email, string Key, string Charset, string SignType, params string[] ParamsAndValue)
        {
            string str = "10";
            string royaltyPara = "";
            double num = 0.01;
            this.GetOption();
            partner = this._partner;
            Key = this._key;
            royaltyPara = this._royaltyParameters;
            num = this._num;
            if (!gateway.EndsWith("?"))
            {
                gateway = gateway + "?";
            }
            ArrayList list = new ArrayList();
            double num2 = 0.0;
            try
            {
                num2 = Convert.ToDouble(total_fee);
            }
            catch
            {
                return "";
            }
            num = Math.Round((double) (num2 * num), 2);
            string str3 = "";
            if (num > 0.0)
            {
                str3 = royaltyPara + "^" + num.ToString() + "^alipay_service";
            }
            list.Add("seller_email=" + seller_email);
            list.Add("subject=" + subject);
            list.Add("out_trade_no=" + out_trade_no);
            list.Add("total_fee=" + total_fee);
            list.Add("return_url=" + return_url);
            list.Add("notify_url=" + notify_url);
            list.Add("partner=" + partner);
            for (int i = 0; i < (ParamsAndValue.Length / 2); i++)
            {
                if ((ParamsAndValue[i * 2] != "") && (ParamsAndValue[(i * 2) + 1] != ""))
                {
                    if (ParamsAndValue[i * 2].ToLower().IndexOf("royalty_parameters") < 0)
                    {
                        list.Add(ParamsAndValue[i * 2].ToLower() + "=" + ParamsAndValue[(i * 2) + 1]);
                    }
                    else if (str3 != "")
                    {
                        str3 = str3 + "|" + ParamsAndValue[(i * 2) + 1];
                    }
                    else
                    {
                        str3 = str3 + ParamsAndValue[(i * 2) + 1];
                    }
                }
            }
            string[] strArray = str3.Split(new char[] { '|' });
            if (strArray.Length > 4)
            {
                str3 = strArray[0] + "|" + strArray[1] + "|" + strArray[2] + "|" + strArray[3] + "|" + strArray[4];
            }
            if (str3 != "")
            {
                list.Add("royalty_type=" + str);
                list.Add("royalty_parameters=" + str3);
            }
            list.Add("_input_charset=" + Charset);
            list.Add("payment_type=" + payment_type);
            list.Add("service=" + service);
            string[] strArray2 = new string[list.Count];
            string[] r = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                r[j] = list[j].ToString();
                strArray2[j] = list[j].ToString();
            }
            string[] strArray4 = BubbleSort(r);
            StringBuilder builder = new StringBuilder();
            for (int k = 0; k < strArray4.Length; k++)
            {
                if (k == (strArray4.Length - 1))
                {
                    builder.Append(strArray4[k]);
                }
                else
                {
                    builder.Append(strArray4[k] + "&");
                }
            }
            builder.Append(Key);
            string str4 = GetMD5(builder.ToString(), Charset);
            char[] separator = new char[] { '=' };
            StringBuilder builder2 = new StringBuilder();
            builder2.Append(gateway);
            for (int m = 0; m < strArray2.Length; m++)
            {
                builder2.Append(strArray2[m].Split(separator)[0] + "=" + HttpUtility.UrlEncode(strArray2[m].Split(separator)[1]) + "&");
            }
            builder2.Append("sign=" + str4 + "&sign_type=" + SignType);
            return builder2.ToString();
        }

        private bool CheckT_OptionsContainsFiled(string fieldName)
        {
            DataTable table = MSSQL.Select("select * from T_Options where 1 = 2", new MSSQL.Parameter[0]);
            if (table == null)
            {
                throw new Exception("T_Options not found.");
            }
            foreach (DataColumn column in table.Columns)
            {
                if (column.ColumnName.ToLower() == fieldName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public string Get_Http(string NotifyService, string NotifyID, string SellerEmail, string Charset, int NotifyType, int _TimeOut)
        {
            string str = "";
            string requestUriString = "";
            this.GetOption();
            str = this._partner;
            if (NotifyType == 1)
            {
                requestUriString = "https://www.alipay.com/cooperate/gateway.do?service=" + NotifyService + "&partner=" + str + "&notify_id=" + NotifyID;
            }
            else
            {
                requestUriString = "http://notify.alipay.com/trade/notify_query.do?partner=" + str + "&notify_id=" + NotifyID;
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUriString);
                request.Timeout = _TimeOut;
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                StringBuilder builder = new StringBuilder();
                while (-1 != reader.Peek())
                {
                    builder.Append(reader.ReadLine());
                }
                return builder.ToString();
            }
            catch (Exception exception)
            {
                return ("错误：" + exception.Message);
            }
        }

        public string[] GetDownloadParams(string service, string _input_charset, string partner, string biz_type)
        {
            return BubbleSort(new string[] { "service=" + service, "partner=" + partner, "biz_type=" + biz_type, "_input_charset=" + _input_charset });
        }

        public string GetHtml(string Url, string encodeing, int TimeoutSeconds)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            try
            {
                request = (HttpWebRequest) WebRequest.Create(Url);
                request.UserAgent = "www.svnhost.cn";
                if (TimeoutSeconds > 0)
                {
                    request.Timeout = 0x3e8 * TimeoutSeconds;
                }
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse) request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodeing));
                    return reader.ReadToEnd();
                }
                return "";
            }
            catch (SystemException)
            {
                return "";
            }
        }

        public static string GetMD5(string s, string Charset)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(Charset).GetBytes(s));
            StringBuilder builder = new StringBuilder(0x20);
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }

        public static string GetMD5(byte[] Date, string Charset)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Date);
            StringBuilder builder = new StringBuilder(0x20);
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }

        public string GetMD5(string s, string SellerEmail, string Charset)
        {
            string str = "";
            this.GetOption();
            str = this._key;
            s = s + str;
            return GetMD5(s, Charset);
        }

        public void GetOption()
        {
            object obj2 = MSSQL.ExecuteScalar("select [Value] from T_Options where [Key] = 'AlipayOnlinePaySetting'", new MSSQL.Parameter[0]);
            if (obj2 != null)
            {
                string str = obj2.ToString().Trim();
                if (str != "")
                {
                    if (!this.UnEncryptString(str))
                    {
                        throw new Exception("OptionValue is error.");
                    }
                    try
                    {
                        string[] strArray = Encrypt.UnEncryptString("ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安", str.Substring(0x20, str.Length - 0x20)).Split(new char[] { ',' });
                        this._partner = strArray[0];
                        this._key = strArray[1];
                        this._royaltyParameters = strArray[2];
                        this._num = _Convert.StrToDouble(strArray[3], 0.01);
                    }
                    catch
                    {
                    }
                }
            }
        }

        public string[] GetUploadParams(string service, string _input_charset, string partner, string file_digest_type, string biz_type, string agentID)
        {
            return BubbleSort(new string[] { "service=" + service, "partner=" + partner, "biz_type=" + biz_type, "file_digest_type=" + file_digest_type, "_input_charset=" + _input_charset, "agentID=" + agentID });
        }

        private bool CheckT_Options()
        {
            DataTable table = MSSQL.Select("Select 1 from sysobjects where OBJECTPROPERTY(id, N'IsUserTable') = 1 and OBJECTPROPERTY(id,N'IsMSShipped')=0 and [Name]='T_Options'", new MSSQL.Parameter[0]);
            if (table == null)
            {
                throw new Exception("Database Connect Fail.");
            }
            return (table.Rows.Count > 0);
        }

        public int Query(string gateway, string PaymentNumber, ref string AlipayPaymentNumber, ref string ReturnDescription)
        {
            this.GetOption();
            string service = "single_trade_query";
            string partner = this._partner;
            string key = this._key;
            string charset = "utf-8";
            string str5 = "MD5";
            if (((gateway == "") || (partner == "")) || (key == ""))
            {
                ReturnDescription = "系统设置信息错误";
                return -1;
            }
            string url = this.Creaturl(gateway, service, partner, key, str5, charset, new string[] { "out_trade_no", PaymentNumber });
            string str7 = "";
            try
            {
                str7 = this.GetHtml(url, "utf-8", 120);
            }
            catch
            {
                ReturnDescription = "数据获取异常，请重新审核";
                return -2;
            }
            if (string.IsNullOrEmpty(str7))
            {
                ReturnDescription = "数据获取异常，请重新审核";
                return -3;
            }
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(new StringReader(str7));
            }
            catch
            {
                ReturnDescription = "数据获取异常，请重新审核";
                return -4;
            }
            XmlNodeList elementsByTagName = document.GetElementsByTagName("is_success");
            if ((elementsByTagName == null) || (elementsByTagName.Count < 1))
            {
                ReturnDescription = "查询信息获取异常，请重新查询";
                return -5;
            }
            if (elementsByTagName[0].InnerText.ToUpper() != "T")
            {
                ReturnDescription = "该支付记录未支付成功";
                return -6;
            }
            XmlNodeList list2 = document.GetElementsByTagName("trade_no");
            if ((list2 == null) || (list2.Count < 1))
            {
                ReturnDescription = "没有对应的支付信息";
                return -7;
            }
            AlipayPaymentNumber = list2[0].InnerText;
            XmlNodeList list3 = document.GetElementsByTagName("trade_status");
            if ((list3 == null) || (list3.Count < 1))
            {
                ReturnDescription = "没有对应的支付信息";
                return -8;
            }
            string str9 = list3[0].InnerText.ToUpper();
            switch (str9)
            {
                case "WAIT_BUYER_PAY":
                    ReturnDescription = "等待买家付款";
                    return -9;

                case "WAIT_SELLER_SEND_GOODS":
                    ReturnDescription = "买家付款成功(担保交易，未确定支付给商家)";
                    return -10;

                case "WAIT_BUYER_CONFIRM_GOODS":
                    ReturnDescription = "卖家发货成功(未确定支付给商家)";
                    return -11;

                case "TRADE_CLOSED":
                    ReturnDescription = "交易被关闭，未成功付款";
                    return -12;
            }
            if (str9 != "TRADE_FINISHED")
            {
                ReturnDescription = "其他未成功支付的错误";
                return -9999;
            }
            return 0;
        }

        public void SetOption(string CallCert, string OptionValue)
        {
            if (CallCert != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                throw new Exception("Call fail.");
            }
            if (!this.UnEncryptString(OptionValue))
            {
                throw new Exception("OptionValue is error.");
            }
            if (!this.CheckT_Options() && (MSSQL.ExecuteNonQuery("create table T_Options (ID smallint, [Key] varchar(100), [Value] varchar(2000)", new MSSQL.Parameter[0]) < 0))
            {
                throw new Exception("Create table T_Options fail.");
            }
            if (!this.CheckT_OptionsContainsFiled("Key") && (MSSQL.ExecuteNonQuery("alter table T_Options add [Key] varchar(100)", new MSSQL.Parameter[0]) < 0))
            {
                throw new Exception("Add column [Key] for T_Options fail.");
            }
            if (!this.CheckT_OptionsContainsFiled("Value") && (MSSQL.ExecuteNonQuery("alter table T_Options add [Value] varchar(2000)", new MSSQL.Parameter[0]) < 0))
            {
                throw new Exception("Add column [Value] for T_Options fail.");
            }
            if (MSSQL.ExecuteNonQuery("if exists (select 1 from T_Options where [Key] = 'AlipayOnlinePaySetting') update T_Options set [Value] = @Value where [Key] = 'AlipayOnlinePaySetting' else insert into T_Options ([Key], [Value]) values ('AlipayOnlinePaySetting', @Value2)", new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.VarChar, 0, ParameterDirection.Input, OptionValue), new MSSQL.Parameter("Value2", SqlDbType.VarChar, 0, ParameterDirection.Input, OptionValue) }) < 0)
            {
                throw new Exception("Set fail.");
            }
            try
            {
                string[] strArray = Encrypt.UnEncryptString("ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安", OptionValue.Substring(0x20, OptionValue.Length - 0x20)).Split(new char[] { ',' });
                this._partner = strArray[0];
                this._key = strArray[1];
                this._royaltyParameters = strArray[2];
                this._num = _Convert.StrToDouble(strArray[3], 0.01);
            }
            catch
            {
            }
        }

        private bool UnEncryptString(string str)
        {
            if (str.Length < 32)
            {
                return false;
            }
            string callPassword = "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安";
            string str2 = str.Substring(0, 32);
            str = str.Substring(32, str.Length - 32);
            if (str2 != Encrypt.MD5(str + callPassword))
            {
                return false;
            }
            try
            {
                str = Encrypt.UnEncryptString(callPassword, str);
            }
            catch
            {
                return false;
            }
            if (str.Split(new char[] { ',' }).Length < 4)
            {
                return false;
            }
            return true;
        }

        private static string GetCallCert()
        {
            string sSourceStr = "";
            string str2 = _String.Reverse("ShoveSoft" + " " + "CO.,Ltd ");
            str2 = _String.Reverse(_String.Reverse(str2) + ("--" + " by Shove "));
            sSourceStr = "20050709";
            sSourceStr = _String.Reverse(sSourceStr + " 深圳" + "宝安");
            return (_String.Reverse(str2) + _String.Reverse(sSourceStr));
        }
    }
}

