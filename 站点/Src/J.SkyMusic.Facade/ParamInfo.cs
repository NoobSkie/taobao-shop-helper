using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SkyMusic.Domain;
using System.Xml;

namespace J.SkyMusic.Facade
{
    public class ParamInfo
    {
        public string Key { get; set; }

        public string Value { get; set; }

        internal XmlNode ItsNode { get; set; }

        public static ParamInfo LoadByXmlNode(XmlNode xmlNode)
        {
            ParamInfo item = new ParamInfo();
            foreach (XmlNode child in xmlNode.ChildNodes)
            {
                switch (child.Name.ToUpper())
                {
                    case "KEY":
                        item.Key = child.InnerText;
                        break;
                    case "VALUE":
                        item.Value = child.InnerText;
                        break;
                }
            }
            item.ItsNode = xmlNode;
            return item;
        }

        public void SetNodeValue()
        {
            foreach (XmlNode child in ItsNode.ChildNodes)
            {
                switch (child.Name.ToUpper())
                {
                    case "KEY":
                        child.InnerText = Key;
                        break;
                    case "VALUE":
                        child.InnerText = Value;
                        break;
                }
            }
        }

        public ParamInfo Clone()
        {
            ParamInfo info = new ParamInfo();
            info.Key = Key;
            info.Value = Value;
            if (ItsNode == null)
            {
                info.ItsNode = null;
            }
            else
            {
                info.ItsNode = ItsNode.Clone();
            }
            return info;
        }
    }
}
