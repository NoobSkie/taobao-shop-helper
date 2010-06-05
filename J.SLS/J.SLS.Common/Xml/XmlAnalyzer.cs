using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace J.SLS.Common.Xml
{
    public class XmlAnalyzer
    {
        public static T AnalyseResponse<T>(string body)
            where T : XmlMappingObject, new()
        {
            try
            {
                Dictionary<string, string> parameters = GetParameters(body);
                string xml = parameters["transMessage"];
                if (!string.IsNullOrEmpty(xml))
                {
                    return AnalyseXml<T>(xml);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new XmlException("解析完整请求错误。" + body, ex);
            }
        }

        public static T AnalyseXml<T>(string xml)
            where T : XmlMappingObject, new()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                T t = new T();
                t.XmlHeader = doc.FirstChild.OuterXml;
                XmlNodeList nodeList = doc.GetElementsByTagName("message");
                if (nodeList.Count > 0)
                {
                    t.AnalyzeXmlNode(nodeList[0]);
                    return t;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new XmlException("解析XML错误。" + xml, ex);
            }
        }

        public static Dictionary<string, string> GetParameters(string body)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                foreach (string item in body.Split('&'))
                {
                    string[] keyValue = item.Split(new char[] { '=' }, 2);
                    parameters.Add(keyValue[0], keyValue[1]);
                }
                return parameters;
            }
            catch (Exception ex)
            {
                throw new XmlException("解析请求文本，并返回参数列表错误。" + body, ex);
            }
        }
    }
}
