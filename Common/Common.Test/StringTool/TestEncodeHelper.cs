using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOP.Common.StringTool;

namespace TOP.Common.Test.StringTool
{
    [TestClass]
    public class TestEncodeHelper
    {
        [TestMethod]
        public void TestGB2312ToUTF8_非中文()
        {
            string testString = "English";
            string str = EncodeHelper.GB2312ToUTF8(testString);
            Assert.AreEqual("English", str);
        }

        [TestMethod]
        public void TestGB2312ToUTF8_中文()
        {
            string testString = "中文文本测试";
            string str = EncodeHelper.GB2312ToUTF8(testString);
            Assert.AreEqual("中文文本测试", str);
        }
    }
}
