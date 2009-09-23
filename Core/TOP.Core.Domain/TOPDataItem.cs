using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;

namespace TOP.Core.Domain
{
    [Serializable]
    public class TOPDataItem : IAnalyseXML
    {
        private AttributeHelper helper = new AttributeHelper();

        public bool DoAnalyse(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement element = doc.DocumentElement;

            string typeMappingName = helper.GetTypeMappingName(this.GetType());
            if (element.Name.Equals(typeMappingName, StringComparison.OrdinalIgnoreCase))
            {
                List<PropertyInfo> properties = new List<PropertyInfo>(this.GetType().GetProperties());
                foreach (XmlNode node in element.ChildNodes)
                {
                    for (int i = properties.Count - 1; i >= 0; i--)
                    {
                        PropertyInfo property = properties[i];
                        string dataMappingName, listMappingName;
                        helper.GetPropertyMappingName(property, out dataMappingName, out listMappingName);
                        if (string.IsNullOrEmpty(listMappingName))
                        {
                            if (node.Name.Equals(dataMappingName, StringComparison.OrdinalIgnoreCase))
                            {
                                if (property.PropertyType == typeof(int))
                                {
                                    property.SetValue(this, int.Parse(node.InnerText), null);
                                }
                                else if (property.PropertyType == typeof(bool))
                                {
                                    property.SetValue(this, bool.Parse(node.InnerText), null);
                                }
                                else if (property.PropertyType == typeof(DateTime))
                                {
                                    property.SetValue(this, DateTime.Parse(node.InnerText), null);
                                }
                                else if (property.PropertyType == typeof(string))
                                {
                                    property.SetValue(this, node.InnerText, null);
                                }
                                else if (property.PropertyType.IsSubclassOf(typeof(TOPDataItem)))
                                {
                                    TOPDataItem item = (TOPDataItem)property.PropertyType.GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
                                    item.AnalyseXML(node.OuterXml);

                                    property.SetValue(this, item, null);
                                }
                                else
                                {
                                    throw new ArgumentException("不支持当前数据类型 - " + property.PropertyType.FullName);
                                }
                                properties.Remove(property);
                            }
                        }
                        else
                        {
                            if (node.Name.Equals(listMappingName, StringComparison.OrdinalIgnoreCase))
                            {
                                IAnalyseXML list = (IAnalyseXML)property.PropertyType.GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
                                list.AnalyseXML(node.OuterXml);

                                property.SetValue(this, list, null);
                            }
                        }
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        #region 解析XML文本

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
