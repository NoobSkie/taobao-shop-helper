using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

namespace J.SLS.Common.Xml
{
    public abstract class XmlMappingObject
    {
        public void AnalyzeXmlNode(XmlNode xmlNode)
        {
            if (xmlNode == null) return;
            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                object[] attrs = property.GetCustomAttributes(typeof(XmlMappingAttribute), true);
                if (attrs.Length > 0)
                {
                    XmlMappingAttribute attr = attrs[0] as XmlMappingAttribute;
                    if (property.PropertyType.IsSubclassOf(typeof(XmlMappingObject)))
                    {
                        XmlMappingObject child = property.PropertyType.GetConstructor(Type.EmptyTypes).Invoke(null) as XmlMappingObject;
                        XmlNode node = GetChildNode(xmlNode, attr.MappingName);
                        child.AnalyzeXmlNode(node);
                        property.SetValue(this, child, null);
                    }
                    else if (property.PropertyType.IsEnum)
                    {
                        object enumObj = Enum.Parse(property.PropertyType, GetNodeValue(xmlNode, attr.MappingName, attr.MappingType));
                        property.SetValue(this, enumObj, null);
                    }
                    else if (property.PropertyType.Equals(typeof(string)))
                    {
                        property.SetValue(this, GetNodeValue(xmlNode, attr.MappingName, attr.MappingType), null);
                    }
                    else
                    {
                        string value = GetNodeValue(xmlNode, attr.MappingName, attr.MappingType);
                        Type type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        property.SetValue(this, Convert.ChangeType(value, type), null);
                    }
                }
            }
        }

        private string GetNodeValue(XmlNode xmlNode, string mappingName, MappingType type)
        {
            if (type == MappingType.Element)
            {
                foreach (XmlNode child in xmlNode.ChildNodes)
                {
                    if (child.Name.Equals(mappingName, StringComparison.OrdinalIgnoreCase))
                    {
                        return child.InnerText;
                    }
                }
            }
            else
            {
                foreach (XmlAttribute attr in xmlNode.Attributes)
                {
                    if (attr.Name.Equals(mappingName, StringComparison.OrdinalIgnoreCase))
                    {
                        return attr.Value;
                    }
                }
            }
            return null;
        }

        private XmlNode GetChildNode(XmlNode xmlNode, string childName)
        {
            foreach (XmlNode child in xmlNode.ChildNodes)
            {
                if (child.Name.Equals(childName, StringComparison.OrdinalIgnoreCase))
                {
                    return child;
                }
            }
            return null;
        }
    }
}
