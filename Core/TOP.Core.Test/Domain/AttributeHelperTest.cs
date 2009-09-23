using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using TOP.Core.Domain;

namespace TOP.Core.Test.Domain
{
    [TestClass]
    public class AttributeHelperTest
    {
        #region 测试类

        #region 测试使用的其他特性类

        public class TestOtherAttribute : Attribute
        {
            public TestOtherAttribute(string name) { }
        }

        #endregion

        #region 没有定义类映射

        public class DataItem_MappingClass_NoneMapping : TOPDataItem
        {
            public string TestProp { get; set; }
        }

        #endregion

        #region 定义了一个类映射

        [TOPDataMapping("TestMappingName")]
        public class DataItem_MappingClass_MappingOne : TOPDataItem
        {
            public string TestProp { get; set; }
        }

        #endregion

        #region 只定义了其他特性的类

        [TestOther("TestName")]
        public class DataItem_MappingClass_Other : TOPDataItem
        {
            public string TestProp { get; set; }
        }

        #endregion

        #region 同时定义了其他特性和映射特性的类

        [TestOther("TestName")]
        [TOPDataMapping("TestMappingName")]
        public class DataItem_MappingClass_OtherToo : TOPDataItem
        {
            public string TestProp { get; set; }
        }

        #endregion

        #region 测试属性映射的类

        public class DataItem_MappingProperty : TOPDataItem
        {
            public string NoneMapping { get; set; }

            [TOPDataMapping("TestMappingOne")]
            public string MappingOne { get; set; }

            [TestOther("TestMappingOther")]
            public string MappingOther { get; set; }

            [TestOther("TestMappingOther")]
            [TOPDataMapping("TestMappingAll")]
            public string MappingAll { get; set; }
        }

        #endregion

        #endregion

        #region 获取对象映射XML名称

        [TestMethod]
        public void TestGetObjMappingName_没有定义映射()
        {
            AttributeHelper helper = new AttributeHelper();
            string mappingName = helper.GetTypeMappingName(typeof(DataItem_MappingClass_NoneMapping));

            Assert.AreEqual("", mappingName);
        }

        [TestMethod]
        public void TestGetObjMappingName_定义一个映射()
        {
            AttributeHelper helper = new AttributeHelper();
            string mappingName = helper.GetTypeMappingName(typeof(DataItem_MappingClass_MappingOne));

            Assert.AreEqual("TestMappingName", mappingName);
        }

        [TestMethod]
        public void TestGetObjMappingName_只定义其他特性()
        {
            AttributeHelper helper = new AttributeHelper();
            string mappingName = helper.GetTypeMappingName(typeof(DataItem_MappingClass_Other));

            Assert.AreEqual("", mappingName);
        }

        [TestMethod]
        public void TestGetObjMappingName_定义多种特性()
        {
            AttributeHelper helper = new AttributeHelper();
            string mappingName = helper.GetTypeMappingName(typeof(DataItem_MappingClass_OtherToo));

            Assert.AreEqual("TestMappingName", mappingName);
        }

        #endregion

        #region 获取属性映射XML名称

        [TestMethod]
        public void TestGetPropertyMappingName_没有定义映射()
        {
            AttributeHelper helper = new AttributeHelper();
            PropertyInfo property = typeof(DataItem_MappingProperty).GetProperty("NoneMapping");
            string dataMappingName, listMappingName;
            helper.GetPropertyMappingName(property, out dataMappingName, out listMappingName);

            Assert.AreEqual("", dataMappingName);
            Assert.IsTrue(string.IsNullOrEmpty(listMappingName));
        }

        [TestMethod]
        public void TestGetPropertyMappingName_定义一个映射()
        {
            AttributeHelper helper = new AttributeHelper();
            PropertyInfo property = typeof(DataItem_MappingProperty).GetProperty("MappingOne");
            string dataMappingName, listMappingName;
            helper.GetPropertyMappingName(property, out dataMappingName, out listMappingName);

            Assert.AreEqual("TestMappingOne", dataMappingName);
            Assert.IsTrue(string.IsNullOrEmpty(listMappingName));
        }

        [TestMethod]
        public void TestGetPropertyMappingName_只定义其他特性()
        {
            AttributeHelper helper = new AttributeHelper();
            PropertyInfo property = typeof(DataItem_MappingProperty).GetProperty("MappingOther");
            string dataMappingName, listMappingName;
            helper.GetPropertyMappingName(property, out dataMappingName, out listMappingName);

            Assert.AreEqual("", dataMappingName);
            Assert.IsTrue(string.IsNullOrEmpty(listMappingName));
        }

        [TestMethod]
        public void TestGetPropertyMappingName_定义多种特性()
        {
            AttributeHelper helper = new AttributeHelper();
            PropertyInfo property = typeof(DataItem_MappingProperty).GetProperty("MappingAll");
            string dataMappingName, listMappingName;
            helper.GetPropertyMappingName(property, out dataMappingName, out listMappingName);

            Assert.AreEqual("TestMappingAll", dataMappingName);
            Assert.IsTrue(string.IsNullOrEmpty(listMappingName));
        }

        #endregion
    }
}
