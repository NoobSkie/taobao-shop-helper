using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TOP.Core.Domain
{
    public class TOPDataList<T> : List<T>, IAnalyseXML
        where T : TOPDataItem, new()
    {
        private AttributeHelper helper = new AttributeHelper();

        private int totalResultNum;
        public int TotalResultNum
        {
            get
            {
                return totalResultNum;
            }
        }

        public bool DoAnalyse(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement element = doc.DocumentElement;

            string typeMappingName = helper.GetTypeMappingName(typeof(T));
            foreach (XmlNode node in element.ChildNodes)
            {
                if (node.Name.Equals(typeMappingName, StringComparison.OrdinalIgnoreCase))
                {
                    T t = new T();
                    t.AnalyseXML(node.OuterXml);
                    this.Add(t);
                }
                else if (node.Name.Equals("totalResults", StringComparison.OrdinalIgnoreCase))
                {
                    totalResultNum = int.Parse(node.InnerText);
                }
            }
            return true;
        }

        #region IAnalyseXML 成员

        private string orginXml = string.Empty;
        public string OrginXml
        {
            get { return orginXml; }
        }

        public void AnalyseXML(string xml)
        {
            orginXml = xml;
            AnalyseState = XmlAnalyseState.Analysing;

            try
            {
                if (DoAnalyse(xml))
                {
                    AnalyseState = XmlAnalyseState.Success;
                }
                else
                {
                    AnalyseState = XmlAnalyseState.Fail;
                }
            }
            catch
            {
                AnalyseState = XmlAnalyseState.Error;
            }
        }

        public XmlAnalyseState AnalyseState { get; set; }

        #endregion
    }
}
