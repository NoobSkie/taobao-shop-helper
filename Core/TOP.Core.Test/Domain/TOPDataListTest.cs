using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOP.Core.Domain;

namespace TOP.Core.Test.Domain
{
    [TestClass]
    public class TOPDataListTest
    {
        #region 测试类

        [TOPDataMapping("item")]
        public class DataItem_Item_item : TOPDataItem
        {
            [TOPDataMapping("iid")]
            public string Id { get; set; }

            [TOPDataMapping("title")]
            public string Title { get; set; }

            [TOPDataMapping("detail_url")]
            public string DetailUrl { get; set; }
        }

        #endregion

        #region 解析XML文本

        [TestMethod]
        public void TestDoAnalyse_解析XML文本成功_全部匹配()
        {
            string xml = ""
                + "<rsp>"
                + "    <totalResults>23</totalResults>"
                + "    <item>"
                + "        <iid><![CDATA[11111111]]></iid>"
                + "        <title><![CDATA[标题一]]></title>"
                + "        <detail_url><![CDATA[http://item.taobao.com/auction/item1.jhtml]]></detail_url>"
                + "    </item>"
                + "    <item>"
                + "        <iid><![CDATA[22222222]]></iid>"
                + "        <title><![CDATA[标题二]]></title>"
                + "        <detail_url><![CDATA[http://item.taobao.com/auction/item2.jhtml]]></detail_url>"
                + "    </item>"
                + "    <item>"
                + "        <iid><![CDATA[33333333]]></iid>"
                + "        <title><![CDATA[标题三]]></title>"
                + "        <detail_url><![CDATA[http://item.taobao.com/auction/item3.jhtml]]></detail_url>"
                + "    </item>"
                + "</rsp>";

            TOPDataList<DataItem_Item_item> list = new TOPDataList<DataItem_Item_item>();

            Assert.AreEqual(0, list.TotalResultNum);
            Assert.AreEqual(0, list.Count);

            list.AnalyseXML(xml);

            Assert.AreEqual(XmlAnalyseState.Success, list.AnalyseState);
            Assert.AreEqual(23, list.TotalResultNum);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("11111111", list[0].Id);
            Assert.AreEqual("标题一", list[0].Title);
            Assert.AreEqual("http://item.taobao.com/auction/item1.jhtml", list[0].DetailUrl);
        }

        [TestMethod]
        public void TestDoAnalyse_解析XML文本成功_部分匹配()
        {
            string xml = ""
                + "<rsp>"
                + "    <totalResults>23</totalResults>"
                + "    <item>"
                + "        <iid><![CDATA[11111111]]></iid>"
                + "        <title><![CDATA[标题一]]></title>"
                + "        <detail_url><![CDATA[http://item.taobao.com/auction/item1.jhtml]]></detail_url>"
                + "    </item>"
                + "    <item_new>"
                + "        <iid><![CDATA[22222222]]></iid>"
                + "        <title><![CDATA[标题二]]></title>"
                + "        <detail_url><![CDATA[http://item.taobao.com/auction/item2.jhtml]]></detail_url>"
                + "    </item_new>"
                + "    <item>"
                + "        <iid><![CDATA[33333333]]></iid>"
                + "        <title><![CDATA[标题三]]></title>"
                + "        <detail_url><![CDATA[http://item.taobao.com/auction/item3.jhtml]]></detail_url>"
                + "    </item>"
                + "</rsp>";

            TOPDataList<DataItem_Item_item> list = new TOPDataList<DataItem_Item_item>();

            Assert.AreEqual(0, list.TotalResultNum);
            Assert.AreEqual(0, list.Count);

            list.AnalyseXML(xml);

            Assert.AreEqual(XmlAnalyseState.Success, list.AnalyseState);
            Assert.AreEqual(23, list.TotalResultNum);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("11111111", list[0].Id);
            Assert.AreEqual("标题一", list[0].Title);
            Assert.AreEqual("http://item.taobao.com/auction/item1.jhtml", list[0].DetailUrl);
        }

        #endregion
    }
}
