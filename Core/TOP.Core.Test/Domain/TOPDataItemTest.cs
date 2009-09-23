using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using TOP.Core.Domain;
using System.Xml;

namespace TOP.Core.Test.Domain
{
    [TestClass]
    public class TOPDataItemTest
    {
        #region 测试类

        #region 测试解析的类__失败__未定义

        public class DataItem_Item_Fail_Undefine : TOPDataItem
        {
            [TOPDataMapping("iid")]
            public string Id { get; set; }

            [TOPDataMapping("title")]
            public string Title { get; set; }

            [TOPDataMapping("detail_url")]
            public string DetailUrl { get; set; }
        }

        #endregion

        #region 测试解析的类__失败__不匹配

        [TOPDataMapping("NotMatch")]
        public class DataItem_Item_Fail_NotMatch : TOPDataItem
        {
            [TOPDataMapping("iid")]
            public string Id { get; set; }

            [TOPDataMapping("title")]
            public string Title { get; set; }

            [TOPDataMapping("detail_url")]
            public string DetailUrl { get; set; }
        }

        #endregion

        #region 测试解析的类__成功

        [TOPDataMapping("item")]
        public class DataItem_Item_Succ : TOPDataItem
        {
            [TOPDataMapping("iid")]
            public string Id { get; set; }

            [TOPDataMapping("title")]
            public string Title { get; set; }

            [TOPDataMapping("detail_url")]
            public string DetailUrl { get; set; }
        }

        #endregion

        #endregion

        #region 解析XML文本

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void TestDoAnalyse_错误的XML文本解析()
        {
            DataItem_Item_Fail_Undefine obj = new DataItem_Item_Fail_Undefine();
            string xml = "error xml schema";
            obj.DoAnalyse(xml);
        }

        [TestMethod]
        public void TestDoAnalyse_解析XML文本失败_未定义()
        {
            DataItem_Item_Fail_Undefine obj = new DataItem_Item_Fail_Undefine();
            string xml = ""
                + "<item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "</item>";
            bool rtn = obj.DoAnalyse(xml);

            Assert.AreEqual(false, rtn);
        }

        [TestMethod]
        public void TestDoAnalyse_解析XML文本失败_不匹配()
        {
            DataItem_Item_Fail_NotMatch obj = new DataItem_Item_Fail_NotMatch();
            string xml = ""
                + "<item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "</item>";
            bool rtn = obj.DoAnalyse(xml);

            Assert.AreEqual(false, rtn);
        }

        [TestMethod]
        public void TestDoAnalyse_解析XML文本成功_仅验证操作()
        {
            DataItem_Item_Succ obj = new DataItem_Item_Succ();
            string xml = ""
                + "<item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "</item>";
            bool rtn = obj.DoAnalyse(xml);

            Assert.AreEqual(true, rtn);
        }

        [TestMethod]
        public void TestDoAnalyse_解析XML文本成功_验证明细_完全匹配()
        {
            DataItem_Item_Succ obj = new DataItem_Item_Succ();
            string xml = ""
                + "<item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "    <title><![CDATA[韩国代购THURSDAY ISLAND专柜正品&mdash;TB3TS05AU粉色短袖T恤]]></title>"
                + "    <detail_url><![CDATA[http://item.taobao.com/auction/item_detail.jhtml?item_id=302a0499bf58d002de05da07f523f3f9&x_id=0xid]]></detail_url>"
                + "</item>";
            bool rtn = obj.DoAnalyse(xml);

            Assert.AreEqual(true, rtn);
            Assert.AreEqual("302a0499bf58d002de05da07f523f3f9", obj.Id);
            Assert.AreEqual("韩国代购THURSDAY ISLAND专柜正品&mdash;TB3TS05AU粉色短袖T恤", obj.Title);
            Assert.AreEqual("http://item.taobao.com/auction/item_detail.jhtml?item_id=302a0499bf58d002de05da07f523f3f9&x_id=0xid", obj.DetailUrl);
        }

        [TestMethod]
        public void TestDoAnalyse_解析XML文本成功_验证明细_不完全匹配()
        {
            DataItem_Item_Succ obj = new DataItem_Item_Succ();
            string xml = ""
                + "<item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "    <title_new><![CDATA[韩国代购THURSDAY ISLAND专柜正品&mdash;TB3TS05AU粉色短袖T恤]]></title_new>"
                + "</item>";
            bool rtn = obj.DoAnalyse(xml);

            Assert.AreEqual(true, rtn);
            Assert.AreEqual("302a0499bf58d002de05da07f523f3f9", obj.Id);
            Assert.AreEqual(default(string), obj.Title);
            Assert.AreEqual(default(string), obj.DetailUrl);
        }

        [TestMethod]
        public void TestDoAnalyse_解析XML文本成功_验证明细_有更少的匹配项()
        {
            DataItem_Item_Succ obj = new DataItem_Item_Succ();
            string xml = ""
                + "<item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "</item>";
            bool rtn = obj.DoAnalyse(xml);

            Assert.AreEqual(true, rtn);
            Assert.AreEqual("302a0499bf58d002de05da07f523f3f9", obj.Id);
            Assert.AreEqual(default(string), obj.Title);
            Assert.AreEqual(default(string), obj.DetailUrl);
        }

        [TestMethod]
        public void TestDoAnalyse_解析XML文本成功_验证明细_有更多的匹配项()
        {
            DataItem_Item_Succ obj = new DataItem_Item_Succ();
            string xml = ""
                + "<item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "    <title><![CDATA[韩国代购THURSDAY ISLAND专柜正品&mdash;TB3TS05AU粉色短袖T恤]]></title>"
                + "    <detail_url><![CDATA[http://item.taobao.com/auction/item_detail.jhtml?item_id=302a0499bf58d002de05da07f523f3f9&x_id=0xid]]></detail_url>"
                + "    <more><![CDATA[302a0499bf58d002de05da07f523f3f9]]></more>"
                + "</item>";
            bool rtn = obj.DoAnalyse(xml);

            Assert.AreEqual(true, rtn);
            Assert.AreEqual("302a0499bf58d002de05da07f523f3f9", obj.Id);
            Assert.AreEqual("韩国代购THURSDAY ISLAND专柜正品&mdash;TB3TS05AU粉色短袖T恤", obj.Title);
            Assert.AreEqual("http://item.taobao.com/auction/item_detail.jhtml?item_id=302a0499bf58d002de05da07f523f3f9&x_id=0xid", obj.DetailUrl);
        }

        #endregion

        #region 解析XML文本之后返回的状态

        [TestMethod]
        public void TestAnalyseXML_原始状态()
        {
            DataItem_Item_Fail_Undefine obj = new DataItem_Item_Fail_Undefine();

            Assert.AreEqual(XmlAnalyseState.Pending, obj.AnalyseState);
        }

        [TestMethod]
        public void TestAnalyseXML_错误()
        {
            DataItem_Item_Fail_Undefine obj = new DataItem_Item_Fail_Undefine();
            string xml = "error xml schema";
            obj.AnalyseXML(xml);

            Assert.AreEqual(XmlAnalyseState.Error, obj.AnalyseState);
        }

        [TestMethod]
        public void TestAnalyseXML_失败()
        {
            DataItem_Item_Fail_Undefine obj = new DataItem_Item_Fail_Undefine();
            string xml = ""
                + "<item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "</item>";
            obj.AnalyseXML(xml);

            Assert.AreEqual(XmlAnalyseState.Fail, obj.AnalyseState);
        }

        [TestMethod]
        public void TestAnalyseXML_成功()
        {
            DataItem_Item_Succ obj = new DataItem_Item_Succ();
            string xml = ""
                + "<item>"
                + "    <iid><![CDATA[302a0499bf58d002de05da07f523f3f9]]></iid>"
                + "</item>";
            obj.AnalyseXML(xml);

            Assert.AreEqual(XmlAnalyseState.Success, obj.AnalyseState);
            Assert.AreEqual("302a0499bf58d002de05da07f523f3f9", obj.Id);
            Assert.AreEqual(default(string), obj.Title);
            Assert.AreEqual(default(string), obj.DetailUrl);
        }

        #endregion
    }
}
