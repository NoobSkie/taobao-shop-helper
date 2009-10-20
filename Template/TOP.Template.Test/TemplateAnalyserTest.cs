using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOP.Template.Facade;
using System.IO;

namespace TOP.Template.Test
{
    [TestClass]
    public class TemplateAnalyserTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "分析模板 - 参数不能为空。")]
        public void TestAnalyseTemplate_空字符串情况()
        {
            TemplateAnalyser.AnalyseTemplate(string.Empty);
        }

        [TestMethod]
        public void TestAnalyseTemplate_一般情况()
        {
            string html = string.Empty;
            using (StreamReader reader = new StreamReader(TestContext.TestDeploymentDir + "\\TemplateFiles\\01.单个模板项.一般情况.htm"))
            {
                html = reader.ReadToEnd();

                reader.Close();
            }

            TemplateObject info = TemplateAnalyser.AnalyseTemplate(html);

            Assert.IsNotNull(info);
            Assert.AreEqual("list", info.Category);
            Assert.AreEqual("TestDisp", info.DisplayName);
            Assert.AreEqual("Image", info.DataType);
            Assert.AreEqual(html.ToString(), info.OuterHTML);
            Assert.AreEqual("\r\n<div>\r\n    <span style=\"font-family: 幼圆; font-size: 1.5em;\"></span>\r\n</div>\r\n", info.InnerHTML);
        }

        [TestMethod]
        public void TestAnalyseTemplateList_一般情况()
        {
            string html = string.Empty;
            using (StreamReader reader = new StreamReader(TestContext.TestDeploymentDir + "\\TemplateFiles\\10.综合测试.一般情况.htm"))
            {
                html = reader.ReadToEnd();

                reader.Close();
            }

            List<TemplateObject> infoList = TemplateAnalyser.AnalyseTemplateList(html);

            Assert.IsNotNull(infoList);
            Assert.AreEqual(2, infoList.Count);

            TemplateObject info1 = infoList[0];
            Assert.AreEqual("list", info1.Category);
            Assert.AreEqual("TestDisp1", info1.DisplayName);
            Assert.AreEqual("Image", info1.DataType);
            Assert.AreEqual(1, info1.Children.Count);
            Assert.AreEqual("Sub1", info1.Children[0].DisplayName);

            TemplateObject info2 = infoList[1];
            Assert.AreEqual("item", info2.Category);
            Assert.AreEqual("TestDisp2", info2.DisplayName);
            Assert.AreEqual("String", info2.DataType);
            Assert.AreEqual(0, info2.Children.Count);
        }
    }
}
