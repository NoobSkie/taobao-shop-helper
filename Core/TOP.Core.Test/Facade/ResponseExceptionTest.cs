using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOP.Core.Facade;

namespace TOP.Core.Test.Facade
{
    [TestClass]
    public class ResponseExceptionTest
    {
        [TestMethod]
        public void TestCreateException_获取单个商品失败()
        {
            string xml = ""
                + "<error_rsp>"
                + "    <args>"
                + "        <arg name=\"api_key\"><![CDATA[12003014]]></arg>"
                + "        <arg name=\"fields\"><![CDATA[iid,title,nick,detail_url,type,cid,desc,product_id,pic_path,num,approve_status,itemimg,propImg]]></arg>"
                + "        <arg name=\"format\"><![CDATA[xml]]></arg>"
                + "        <arg name=\"iid\"><![CDATA[302a0499bf58d002ee05aa07f523f3f9]]></arg>"
                + "        <arg name=\"method\"><![CDATA[taobao.item.get]]></arg>"
                + "        <arg name=\"nick\"><![CDATA[fengxiangxia]]></arg>"
                + "        <arg name=\"sign\"><![CDATA[3055A4992C1D523D68FE1EA35C1576F3]]></arg>"
                + "        <arg name=\"timestamp\"><![CDATA[2009-07-28 05:08:24]]></arg>"
                + "        <arg name=\"v\"><![CDATA[1.0]]></arg>"
                + "    </args>"
                + "    <code>551</code>"
                + "    <msg><![CDATA[Item service unavailable:获取单个商品失败]]></msg>"
                + "</error_rsp>";

            ResponseException ex = new ResponseException(xml);
            Assert.AreEqual(xml, ex.ErrorXml);
            Assert.AreEqual("551", ex.ErrorCode);
            Assert.AreEqual("Item service unavailable:获取单个商品失败", ex.ErrorDescription);
            Assert.AreEqual(9, ex.ArgList.Count);
            string msg = "api_key: 12003014\n"
                + "fields: iid,title,nick,detail_url,type,cid,desc,product_id,pic_path,num,approve_status,itemimg,propImg\n"
                + "format: xml\n"
                + "iid: 302a0499bf58d002ee05aa07f523f3f9\n"
                + "method: taobao.item.get\n"
                + "nick: fengxiangxia\n"
                + "sign: 3055A4992C1D523D68FE1EA35C1576F3\n"
                + "timestamp: 2009-07-28 05:08:24\n"
                + "v: 1.0\n";
            Assert.AreEqual(msg, ex.ToArgListString());
        }

        [TestMethod]
        public void TestGetExceptionMessage_系统级错误()
        {
            string errMsg = "<error_rsp><args><arg name=\"api_key\"><![CDATA[12003014]]></arg></args><code>25</code><msg><![CDATA[Item service unavailable:获取单个商品失败]]></msg></error_rsp>";

            ResponseException ex = new ResponseException(errMsg);

            Assert.AreEqual("25", ex.ErrorCode);
            Assert.AreEqual("Item service unavailable:获取单个商品失败", ex.ErrorDescription);
            Assert.AreEqual("签名无效", ex.ErrorMessageCh);
            Assert.AreEqual("Invalid signature", ex.ErrorMessageEn);
            Assert.AreEqual(ResponseErrorType.System, ex.ErrorType);
        }

        [TestMethod]
        public void TestGetExceptionMessage_业务级错误()
        {
            string errMsg = "<error_rsp><args><arg name=\"api_key\"><![CDATA[12003014]]></arg></args><code>551</code><msg><![CDATA[Item service unavailable:获取单个商品失败]]></msg></error_rsp>";

            ResponseException ex = new ResponseException(errMsg);

            Assert.AreEqual("551", ex.ErrorCode);
            Assert.AreEqual("Item service unavailable:获取单个商品失败", ex.ErrorDescription);
            Assert.AreEqual("商品数据服务不可用", ex.ErrorMessageCh);
            Assert.AreEqual("Item service unavailable", ex.ErrorMessageEn);
            Assert.AreEqual(ResponseErrorType.Business, ex.ErrorType);
        }
    }
}
