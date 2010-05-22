namespace Alipay.Gateway
{
    using System;
    using System.IO;
    using System.Xml;

    public class OnlinePay
    {
        public int Query(string PayType, string PaymentNumber, ref string AlipayPaymentNumber, ref string ReturnDescription)
        {
            SystemOptions options = new SystemOptions();
            string gateway = options["QueryAddMoney_Alipay_Gateway"].ToString("");
            string service = "single_trade_query";
            string partner = "";
            string key = "";
            string charset = "utf-8";
            string str6 = "MD5";
            if (PayType == "ALIPAY_alipay")
            {
                partner = options["OnlinePay_Alipay_UserNumber"].ToString("");
                key = options["OnlinePay_Alipay_MD5Key"].ToString("");
            }
            else
            {
                partner = options["OnlinePay_Alipay_UserNumber1"].ToString("");
                key = options["OnlinePay_Alipay_MD5Key1"].ToString("");
            }
            if (((gateway == "") || (partner == "")) || (key == ""))
            {
                ReturnDescription = "系统设置信息错误";
                return -1;
            }
            string url = new Utility().Createurl(gateway, service, partner, key, str6, charset, new string[] { "out_trade_no", PaymentNumber });
            string str8 = "";
            try
            {
                str8 = PF.GetHtml(url, "utf-8", 120);
            }
            catch
            {
                ReturnDescription = "数据获取异常，请重新审核";
                return -2;
            }
            if (string.IsNullOrEmpty(str8))
            {
                ReturnDescription = "数据获取异常，请重新审核";
                return -3;
            }
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(new StringReader(str8));
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
            string str10 = list3[0].InnerText.ToUpper();
            switch (str10)
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
            if (str10 != "TRADE_FINISHED")
            {
                ReturnDescription = "其他未成功支付的错误";
                return -9999;
            }
            return 0;
        }
    }
}

