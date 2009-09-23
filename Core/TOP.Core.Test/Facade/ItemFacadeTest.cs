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
    public class ItemFacadeTest
    {
        private string defaultAppKey = "12006575";
        private string defaultAppSecret = "9d0a6fb5453e9b51877f9ed28b5569a9";

        [TestMethod]
        public void TestGetSkuListByNick_测试()
        {
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            TOPDataList<Sku> skuList = facade.GetSkuListByNick("e451e370789042d8ad387d087a372d25", "jimmy422");
            Assert.IsTrue(skuList.Count > 0);
        }

        [TestMethod]
        public void TestQuerySkuListByNicks_测试()
        {
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            TOPDataList<ItemListItem> itemList = facade.QueryItemListByNicks("jimmy422");
            Assert.IsTrue(itemList.Count > 0);
        }

        [TestMethod]
        public void TestQuerySkuListByKey_测试()
        {
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            TOPDataList<ItemListItem> itemList = facade.QueryItemListByKey("NIKE");
            Assert.IsTrue(itemList.Count > 0);
        }

        [TestMethod]
        public void TestGetSkuById_测试()
        {
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            TOPDataList<Sku> skuList = facade.GetSkuListByNick("e451e370789042d8ad387d087a372d25", "jimmy422");
            if (skuList.Count > 0)
            {
                Sku sku = facade.GetSku(skuList[0].Id, "jimmy422");
                Assert.IsNotNull(sku);
            }
            else
            {
                Assert.Fail("没查询到商品的Sku列表");
            }
        }

        [TestMethod]
        public void TestGetItemPropValues_测试裤子()
        {
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            ItemDetail item = facade.GetItem("e451e370789042d8ad387d087a372d25", "jimmy422");

            Assert.IsNotNull(item);

            TOPDataList<ItemPropValue> mainProps = facade.GetItemPropValues(item.CategoryId, item.Properties);
            string propStr = string.Empty;
            foreach (ItemPropValue prop in mainProps)
            {
                propStr += prop.SortOrder + "." + prop.PropertyName + "：" + prop.Name + "（" + prop.NameAlias + "）\n";
            }
            Assert.IsFalse(string.IsNullOrEmpty(propStr));
            Assert.IsNotNull(mainProps);
            Assert.IsTrue(mainProps.Count > 0);

            TOPDataList<Sku> skuList = facade.GetSkuListByNick("e451e370789042d8ad387d087a372d25", "jimmy422");
            if (skuList.Count > 0)
            {
                string propStrings = propStr;
                for (int i = 0; i < skuList.Count; i++)
                {
                    Sku sku = skuList[i];

                    Assert.IsNotNull(sku);

                    TOPDataList<ItemPropValue> props = facade.GetItemPropValues(item.CategoryId, sku.Properties);
                    propStr = string.Empty;
                    foreach (ItemPropValue prop in props)
                    {
                        propStr += prop.SortOrder + "." + prop.PropertyName + "：" + prop.Name + "（" + prop.NameAlias + "）\n";
                    }
                    Assert.IsFalse(string.IsNullOrEmpty(propStr));
                    Assert.IsNotNull(props);
                    Assert.IsTrue(props.Count > 0);

                    propStrings += propStr;
                }
                Assert.IsFalse(string.IsNullOrEmpty(propStrings));
            }
            else
            {
                Assert.Fail("没查询到商品的Sku列表");
            }
        }

        [TestMethod]
        public void TestGetItemPropValues_测试电脑()
        {
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            ItemDetail item = facade.GetItem("4e30aff3293626fbf0d9cbd2be5d9f03", "liangweidaren");

            Assert.IsNotNull(item);

            TOPDataList<ItemPropValue> mainProps = facade.GetItemPropValues(item.CategoryId, item.Properties);
            string propStr = string.Empty;
            foreach (ItemPropValue prop in mainProps)
            {
                propStr += prop.SortOrder + "." + prop.PropertyName + "：" + prop.Name + "（" + prop.NameAlias + "）\n";
            }
            Assert.IsFalse(string.IsNullOrEmpty(propStr));
            Assert.IsNotNull(mainProps);
            Assert.IsTrue(mainProps.Count > 0);

            TOPDataList<Sku> skuList = facade.GetSkuListByNick("4e30aff3293626fbf0d9cbd2be5d9f03", "liangweidaren");
            if (skuList.Count > 0)
            {
                string propStrings = propStr;
                for (int i = 0; i < skuList.Count; i++)
                {
                    Sku sku = skuList[i];

                    Assert.IsNotNull(sku);

                    TOPDataList<ItemPropValue> props = facade.GetItemPropValues(item.CategoryId, sku.Properties);
                    propStr = string.Empty;
                    foreach (ItemPropValue prop in props)
                    {
                        propStr += prop.SortOrder + "." + prop.PropertyName + "：" + prop.Name + "（" + prop.NameAlias + "）\n";
                    }
                    Assert.IsFalse(string.IsNullOrEmpty(propStr));
                    Assert.IsNotNull(props);
                    Assert.IsTrue(props.Count > 0);

                    propStrings += propStr;
                }
                Assert.IsFalse(string.IsNullOrEmpty(propStrings));
            }
            else
            {
                Assert.Fail("没查询到商品的Sku列表");
            }
        }

        [TestMethod]
        public void TestGetItem()
        {
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            // <p><img alt="" src="http://image.rakuten.co.jp/simple-mart/cabinet/h001/img55421747.jpg" /><img alt="" src="http://image.rakuten.co.jp/simple-mart/cabinet/h001/img55421748.jpg" /><img alt="" src="http://image.rakuten.co.jp/simple-mart/cabinet/h001/img55421749.jpg" /><img alt="" src="http://image.rakuten.co.jp/simple-mart/cabinet/h001/img55421751.jpg" /><img alt="" src="http://image.rakuten.co.jp/simple-mart/cabinet/h001/img55421752.jpg" /><img alt="" src="http://image.rakuten.co.jp/simple-mart/cabinet/h001/img55421753.jpg" /><img alt="" src="http://image.rakuten.co.jp/simple-mart/cabinet/h001/img55421754.jpg" /><img alt="" src="http://image.rakuten.co.jp/simple-mart/cabinet/h001/img55421756.jpg" /><img alt="" src="http://image.rakuten.co.jp/simple-mart/cabinet/h001/img55421757.jpg" /></p>
            ItemDetail item = facade.GetItem("ff5877fe8e9fa838043b43d7f20f7dfd", "zhongjy001");
            Assert.IsNotNull(item);
            Assert.AreEqual("", item.Description);
            Assert.IsFalse(string.IsNullOrEmpty(item.Description));
        }

        [TestMethod]
        public void TestUpdateItemDescription()
        {
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            // ff5877fe8e9fa838043b43d7f20f7dfd_T1UyRlXgKkItQ5DJM__075740.jpg
            string rtn = facade.UpdateItemDescription("ff5877fe8e9fa838043b43d7f20f7dfd", "ff5877fe8e9fa838043b43d7f20f7dfd_T1UyRlXgKkItQ5DJM__075740.jpg");
            Assert.AreEqual("", rtn);
        }
    }
}
