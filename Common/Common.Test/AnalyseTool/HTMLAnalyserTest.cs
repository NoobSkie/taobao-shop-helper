using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TOP.Common.AnalyseTool;

namespace TOP.Common.Test.HTMLHelper
{
    [TestClass]
    public class HTMLAnalyserTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestAnalyse_分析空字符串()
        {
            HTMLAnalyser analyser = new HTMLAnalyser();
            List<InputItem> list = analyser.Analyse(string.Empty);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestAnalyse_没有输入项的普通文本()
        {
            HTMLAnalyser analyser = new HTMLAnalyser();
            List<InputItem> list = analyser.Analyse("afasldlajdgljaldjlajfljasdlfjasdf");

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestAnalyse_没有输入项的HTML()
        {
            StreamReader reader = new StreamReader(TestContext.TestDeploymentDir + @"\HTMLs\01.htm");
            string html = reader.ReadToEnd();

            HTMLAnalyser analyser = new HTMLAnalyser();
            List<InputItem> list = analyser.Analyse(html);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestAnalyse_有一个Item输入项()
        {
            StreamReader reader = new StreamReader(TestContext.TestDeploymentDir + @"\HTMLs\02.htm");
            string html = reader.ReadToEnd();

            HTMLAnalyser analyser = new HTMLAnalyser();
            List<InputItem> list = analyser.Analyse(html);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("规格介绍", list[0].DisplayName);
            Assert.AreEqual(InputType.Item, list[0].InputType);
            Assert.AreEqual(default(string), list[0].ItemValue);
            Assert.AreEqual(TOP.Common.AnalyseTool.ValueType.Image, list[0].ValueType);
            Assert.AreEqual(default(string), list[0].DefaultValue);
            Assert.AreEqual(string.Empty, list[0].InnerHTML.Trim());
        }

        [TestMethod]
        public void TestGetItemByHTML_没有属性()
        {
            string html = "<tag:Item></tag>";

            HTMLAnalyser analyser = new HTMLAnalyser();
            InputItem item = analyser.GetItemByHTML(html);
            Assert.AreEqual(InputType.Item, item.InputType);
            Assert.AreEqual("<tag:Item></tag>", item.OuterHTML);
            Assert.AreEqual("", item.InnerHTML);

            Assert.AreEqual(default(string), item.DisplayName);
            Assert.AreEqual(default(string), item.ItemValue);
            Assert.AreEqual(default(string), item.DefaultValue);
            Assert.AreEqual(default(TOP.Common.AnalyseTool.ValueType), item.ValueType);
        }

        [TestMethod]
        public void TestGetItemByHTML_有属性()
        {
            string html = "<tag:Item DisplayName=\"规格介绍\" valuetype=\"Image\"></tag>";

            HTMLAnalyser analyser = new HTMLAnalyser();
            InputItem item = analyser.GetItemByHTML(html);
            Assert.AreEqual(InputType.Item, item.InputType);
            Assert.AreEqual("<tag:Item DisplayName=\"规格介绍\" valuetype=\"Image\"></tag>", item.OuterHTML);
            Assert.AreEqual("", item.InnerHTML);

            Assert.AreEqual("规格介绍", item.DisplayName);
            Assert.AreEqual(default(string), item.ItemValue);
            Assert.AreEqual(default(string), item.DefaultValue);
            Assert.AreEqual(TOP.Common.AnalyseTool.ValueType.Image, item.ValueType);
        }

        [TestMethod]
        public void TestGetItemByHTML_有内容()
        {
            string html = "<tag:Item DisplayName=\"规格介绍\" valuetype=\"Image\"><div></div></tag>";

            HTMLAnalyser analyser = new HTMLAnalyser();
            InputItem item = analyser.GetItemByHTML(html);
            Assert.AreEqual(InputType.Item, item.InputType);
            Assert.AreEqual("<tag:Item DisplayName=\"规格介绍\" valuetype=\"Image\"><div></div></tag>", item.OuterHTML);
            Assert.AreEqual("<div></div>", item.InnerHTML);

            Assert.AreEqual("规格介绍", item.DisplayName);
            Assert.AreEqual(default(string), item.ItemValue);
            Assert.AreEqual(default(string), item.DefaultValue);
            Assert.AreEqual(TOP.Common.AnalyseTool.ValueType.Image, item.ValueType);
        }
    }
}
