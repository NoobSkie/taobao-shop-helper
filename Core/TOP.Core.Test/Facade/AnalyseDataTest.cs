using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOP.Core.Facade;
using TOP.Core.Domain;

namespace TOP.Core.Test.Facade
{
    [TestClass]
    public class AnalyseDataTest
    {
        private string defaultAppKey = "12006575";
        private string defaultAppSecret = "9d0a6fb5453e9b51877f9ed28b5569a9";

        #region 解析XML文本到数据项

        [TestMethod]
        public void TestAnalyseDataItem_服务器返回错误信息()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<error_rsp>"
                + "  <args>"
                + "    <arg name=\"api_key\"><![CDATA[12003014]]></arg>"
                + "  </args>"
                + "  <code>551</code>"
                + "  <msg><![CDATA[Item service unavailable:获取单个商品失败]]></msg>"
                + "</error_rsp>"
                + "<!--top50.cm1-->";

            AnalyseData analyser = new AnalyseData(defaultAppKey, defaultAppSecret);
            try
            {
                ItemListItem item = analyser.AnalyseDataItem<ItemListItem>(xml);
            }
            catch (ResponseException ex)
            {
                string errorXml = "<error_rsp>"
                    + "<args>"
                        + "<arg name=\"api_key\"><![CDATA[12003014]]></arg>"
                    + "</args>"
                    + "<code>551</code>"
                    + "<msg><![CDATA[Item service unavailable:获取单个商品失败]]></msg>"
                    + "</error_rsp>";
                Assert.AreEqual(errorXml, ex.ErrorXml);
            }
            catch (Exception ex)
            {
                Assert.Fail("应该抛出服务器返回错误信息的异常，而不是" + ex.GetType().ToString() + "异常");
            }
        }

        [TestMethod]
        public void TestAnalyseDataItem_解析正确的XML文本()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<rsp>"
                + "  <item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "    <detail_url><![CDATA[http://item.taobao.com/auction/item_detail.jhtml?item_id=302a0499bf58d002de05da07f523f3f9&x_id=0xid]]></detail_url>"
                + "    <title><![CDATA[韩国代购THURSDAY ISLAND专柜正品&mdash;TB3TS05AU粉色短袖T恤]]></title>"
                + "    <nick><![CDATA[fengxiangxia]]></nick>"
                + "    <type><![CDATA[fixed]]></type>"
                + "    <cid><![CDATA[50011150]]></cid>"
                + "    <desc><![CDATA[商品描述]]></desc>"
                + "    <pic_path><![CDATA[http://img06.taobaocdn.com/bao/uploaded/i6/T1h.ljXoUrvJN81.sV_021900.jpg]]></pic_path>"
                + "    <num>6</num>"
                + "    <approve_status><![CDATA[onsale]]></approve_status>"
                + "  </item>"
                + "</rsp>"
                + "<!--top14.cm3-->";

            AnalyseData analyser = new AnalyseData(defaultAppKey, defaultAppSecret);
            ItemListItem item = analyser.AnalyseDataItem<ItemListItem>(xml);
            Assert.AreEqual("302a0499bf58d002de05da07f523f3f9", item.Id);
        }

        #endregion

        #region 请求服务器并返回数据项

        [TestMethod]
        public void TestRequestTOPDataItem_测试请求服务器_正确()
        {
            string nick = "fengxiangxia";
            string id = "302a0499bf58d002de05da07f523f3f9";

            AnalyseData analyser = new AnalyseData(defaultAppKey, defaultAppSecret);
            Dictionary<string, string> q = new Dictionary<string, string>();
            q.Add("nick", nick);
            q.Add("iid", id);
            ItemListItem item = analyser.RequestTOPDataItem<ItemListItem>("taobao.item.get", q);
            Assert.AreEqual("302a0499bf58d002de05da07f523f3f9", item.Id);
            Assert.AreEqual("韩国代购THURSDAY ISLAND专柜正品&mdash;TB3TS05AU粉色短袖T恤", item.Title);
        }

        [TestMethod]
        public void TestRequestTOPDataItem_测试请求服务器_商品不存在()
        {
            string nick = "fengxiangxia";
            string id = "102a0499bf58d002de05da07f523f3f1";

            AnalyseData analyser = new AnalyseData(defaultAppKey, defaultAppSecret);
            Dictionary<string, string> q = new Dictionary<string, string>();
            q.Add("nick", nick);
            q.Add("iid", id);
            try
            {
                ItemListItem item = analyser.RequestTOPDataItem<ItemListItem>("taobao.item.get", q);
            }
            catch (ResponseException ex)
            {
                Assert.AreEqual("服务器返回错误响应消息", ex.Message);
                Assert.AreEqual("551", ex.ErrorCode);
                Assert.AreEqual("Item service unavailable:获取单个商品失败", ex.ErrorDescription);
            }
            catch (Exception ex)
            {
                Assert.Fail("应该抛出服务器返回错误信息的异常，而不是" + ex.GetType().ToString() + "异常");
            }
        }

        [TestMethod]
        public void TestRequestTOPDataItem_测试请求服务器_卖家不存在()
        {
            string nick = "不存在的卖家";
            string id = "102a0499bf58d002de05da07f523f3f1";

            AnalyseData analyser = new AnalyseData(defaultAppKey, defaultAppSecret);
            Dictionary<string, string> q = new Dictionary<string, string>();
            q.Add("nick", nick);
            q.Add("iid", id);
            try
            {
                ItemListItem item = analyser.RequestTOPDataItem<ItemListItem>("taobao.item.get", q);
            }
            catch (ResponseException ex)
            {
                Assert.AreEqual("服务器返回错误响应消息", ex.Message);
                Assert.AreEqual("601", ex.ErrorCode);
                Assert.AreEqual("User not exist:不存在的卖家", ex.ErrorDescription);
            }
            catch (Exception ex)
            {
                Assert.Fail("应该抛出服务器返回错误信息的异常，而不是" + ex.GetType().ToString() + "异常");
            }
        }

        #endregion

        #region 请求服务器数据列表

        [TestMethod]
        public void TestRequestTOPDataList_测试请求服务器_正确()
        {
            string nick = "fengxiangxia";

            AnalyseData analyser = new AnalyseData(defaultAppKey, defaultAppSecret);
            Dictionary<string, string> q = new Dictionary<string, string>();
            q.Add("nicks", nick);
            TOPDataList<ItemListItem> list = analyser.RequestTOPDataList<ItemListItem>("taobao.items.get", q);
            Assert.AreEqual(40, list.Count);
            Assert.IsTrue(list.TotalResultNum > 100);
            Assert.IsFalse(string.IsNullOrEmpty(list[0].Title));
        }

        #endregion
    }
}
