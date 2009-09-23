using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOP.Authorize.Facade;

namespace TOP.Authorize.Test
{
    [TestClass]
    public class UiPageAnalyseTest
    {
        #region AnalyseUrl

        [TestMethod]
        public void TestAnalyseUrl_初始状态()
        {
            UiPage page = new UiPage();

            Assert.IsTrue(string.IsNullOrEmpty(page.OrginUrl));
            Assert.IsTrue(string.IsNullOrEmpty(page.OrginAppRelativeDirectory));
            Assert.IsTrue(string.IsNullOrEmpty(page.DomainName));
            Assert.IsTrue(string.IsNullOrEmpty(page.VirtualName));
            Assert.IsTrue(string.IsNullOrEmpty(page.RelativeDirectory));
            Assert.IsTrue(string.IsNullOrEmpty(page.FileName));
            Assert.IsFalse(page.IsHasParamters);
            Assert.IsTrue(string.IsNullOrEmpty(page.ParameterString));
        }

        [TestMethod]
        public void TestAnalyseUrl_没有参数的情况()
        {
            UiPage page = new UiPage();

            page.AnalyseUrl("http://localhost:808/TaobaoShopHelper/TestPages/TestStyles.aspx", "~/TestPages/");

            Assert.AreEqual("http://localhost:808/TaobaoShopHelper/TestPages/TestStyles.aspx", page.OrginUrl);
            Assert.AreEqual("~/TestPages/", page.OrginAppRelativeDirectory);
            Assert.AreEqual("localhost:808", page.DomainName);
            Assert.AreEqual("TaobaoShopHelper", page.VirtualName);
            Assert.AreEqual("/TestPages/", page.RelativeDirectory);
            Assert.AreEqual("TestStyles.aspx", page.FileName);
            Assert.AreEqual(false, page.IsHasParamters);
            Assert.IsTrue(string.IsNullOrEmpty(page.ParameterString));
        }

        [TestMethod]
        public void TestAnalyseUrl_有参数的情况()
        {
            UiPage page = new UiPage();

            page.AnalyseUrl("http://localhost:808/TaobaoShopHelper/TestPages/TestStyles.aspx?a=a1", "~/TestPages/");

            Assert.AreEqual("http://localhost:808/TaobaoShopHelper/TestPages/TestStyles.aspx?a=a1", page.OrginUrl);
            Assert.AreEqual("~/TestPages/", page.OrginAppRelativeDirectory);
            Assert.AreEqual("localhost:808", page.DomainName);
            Assert.AreEqual("TaobaoShopHelper", page.VirtualName);
            Assert.AreEqual("/TestPages/", page.RelativeDirectory);
            Assert.AreEqual("TestStyles.aspx", page.FileName);
            Assert.AreEqual(true, page.IsHasParamters);
            Assert.AreEqual("a=a1", page.ParameterString);
        }

        [TestMethod]
        public void TestAnalyseUrl_根目录的情况()
        {
            UiPage page = new UiPage();

            page.AnalyseUrl("http://localhost:808/TaobaoShopHelper/TestStyles.aspx?a=a1", "~/");

            Assert.AreEqual("http://localhost:808/TaobaoShopHelper/TestStyles.aspx?a=a1", page.OrginUrl);
            Assert.AreEqual("~/", page.OrginAppRelativeDirectory);
            Assert.AreEqual("localhost:808", page.DomainName);
            Assert.AreEqual("TaobaoShopHelper", page.VirtualName);
            Assert.AreEqual("/", page.RelativeDirectory);
            Assert.AreEqual("TestStyles.aspx", page.FileName);
            Assert.AreEqual(true, page.IsHasParamters);
            Assert.AreEqual("a=a1", page.ParameterString);
        }

        [TestMethod]
        public void TestAnalyseUrl_网站的情况()
        {
            UiPage page = new UiPage();

            page.AnalyseUrl("http://localhost:808/TestPages/TestStyles.aspx?a=a1", "~/TestPages/");

            Assert.AreEqual("http://localhost:808/TestPages/TestStyles.aspx?a=a1", page.OrginUrl);
            Assert.AreEqual("~/TestPages/", page.OrginAppRelativeDirectory);
            Assert.AreEqual("localhost:808", page.DomainName);
            Assert.IsTrue(string.IsNullOrEmpty(page.VirtualName));
            Assert.AreEqual("/TestPages/", page.RelativeDirectory);
            Assert.AreEqual("TestStyles.aspx", page.FileName);
            Assert.AreEqual(true, page.IsHasParamters);
            Assert.AreEqual("a=a1", page.ParameterString);
        }

        [TestMethod]
        public void TestAnalyseUrl_网站根目录的情况()
        {
            UiPage page = new UiPage();

            page.AnalyseUrl("http://localhost:808/TestStyles.aspx?a=a1", "~/");

            Assert.AreEqual("http://localhost:808/TestStyles.aspx?a=a1", page.OrginUrl);
            Assert.AreEqual("~/", page.OrginAppRelativeDirectory);
            Assert.AreEqual("localhost:808", page.DomainName);
            Assert.IsTrue(string.IsNullOrEmpty(page.VirtualName));
            Assert.AreEqual("/", page.RelativeDirectory);
            Assert.AreEqual("TestStyles.aspx", page.FileName);
            Assert.AreEqual("a=a1", page.ParameterString);
        }

        #endregion

        #region AnalyseParameters

        [TestMethod]
        public void TestAnalyseParameters_初始状态()
        {
            UiPage page = new UiPage();

            Assert.IsNotNull(page.Parameters);
            Assert.AreEqual(false, page.IsHasParamters);
            Assert.AreEqual(0, page.Parameters.Count);
        }

        [TestMethod]
        public void TestAnalyseParameters_一个参数的情况()
        {
            UiPage page = new UiPage();
            Dictionary<string, string> parameters = page.AnalyseParameters("p1=v1");

            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Count);
            Assert.AreEqual(true, parameters.ContainsKey("p1"));
            Assert.AreEqual("v1", parameters["p1"]);
        }

        [TestMethod]
        public void TestAnalyseParameters_多个参数的情况()
        {
            UiPage page = new UiPage();
            Dictionary<string, string> parameters = page.AnalyseParameters("p1=v1&p2=v2&p3=v3");

            Assert.IsNotNull(parameters);
            Assert.AreEqual(3, parameters.Count);
            Assert.AreEqual(true, parameters.ContainsKey("p1"));
            Assert.AreEqual("v1", parameters["p1"]);
            Assert.AreEqual(true, parameters.ContainsKey("p2"));
            Assert.AreEqual("v2", parameters["p2"]);
            Assert.AreEqual(true, parameters.ContainsKey("p3"));
            Assert.AreEqual("v3", parameters["p3"]);
        }

        #endregion
    }
}
