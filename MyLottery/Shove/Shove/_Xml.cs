namespace Shove
{
    using Shove.Properties;
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;

    public class _Xml
    {
        public static string XmlToJson(string XmlInput)
        {
            Stream inStream = new MemoryStream(Encoding.Default.GetBytes(XmlInput));
            XmlDocument document = new XmlDocument();
            inStream.Position = 0L;
            document.Load(inStream);
            XmlNodeList childNodes = document.DocumentElement.ChildNodes;
            XmlDocument document2 = new XmlDocument();
            string str = null;
            foreach (XmlNode node in childNodes)
            {
                str = str + node.OuterXml;
            }
            str = "<Shove_Xml_XmlToJson_Result>" + str + "</Shove_Xml_XmlToJson_Result>";
            document2.InnerXml = str;
            XPathNavigator navigator = document2.CreateNavigator();
            XmlDocument stylesheet = new XmlDocument();
            stylesheet.LoadXml(new Settings().Xml2JsonXslt);
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(stylesheet);
            Stream w = new MemoryStream();
            new XmlTextWriter(w, Encoding.GetEncoding("UTF-8"));
            transform.Transform((IXPathNavigable) navigator, null, w);
            w.Position = 0L;
            StreamReader reader = new StreamReader(w);
            string str2 = reader.ReadToEnd().Replace("\"Shove_Xml_XmlToJson_Result\":  ", "");
            w.Close();
            reader.Close();
            return str2;
        }
    }
}

