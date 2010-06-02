using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SkyMusic.Domain;
using J.SLS.Database.DBAccess;
using System.IO;
using System.Xml;

namespace J.SkyMusic.Facade
{
    public class ParamFacade : BaseFacade
    {
        public ParamFacade(string baseXmlDir) : base(baseXmlDir) { }

        public ParamInfo GetParam(string key)
        {
            XmlDocument doc = GetXmlDocumentByFileName(DbParamsFile);
            XmlNodeList nodeList = doc.GetElementsByTagName("Params");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    ParamInfo param = ParamInfo.LoadByXmlNode(node);
                    if (param.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        return param;
                    }
                }
            }
            return null;
        }

        public void SaveParam(ParamInfo param)
        {
            XmlDocument doc = GetXmlDocumentByFileName(DbParamsFile);
            XmlNodeList nodeList = doc.GetElementsByTagName("Params");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                bool hasParam = false;
                foreach (XmlNode node in root.ChildNodes)
                {
                    ParamInfo tmp = ParamInfo.LoadByXmlNode(node);
                    param.ItsNode = tmp.ItsNode;
                    if (tmp.Key.Equals(param.Key, StringComparison.OrdinalIgnoreCase))
                    {
                        param.SetNodeValue();
                        hasParam = true;
                        break;
                    }
                }
                if (!hasParam && param.ItsNode != null)
                {
                    param.ItsNode = param.ItsNode.Clone();
                    param.SetNodeValue();
                    root.AppendChild(param.ItsNode);
                }
                SaveXmlDocument(doc, DbParamsFile);
            }
        }
    }
}
