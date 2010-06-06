using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Collections;

namespace J.SLS.Common.Xml
{
    public abstract class XmlMappingObject
    {
        public virtual void AnalyzeXmlNode(XmlNode xmlNode)
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
                        XmlNode node;
                        if (attr.ObjectType == XmlObjectType.List)
                        {
                            node = GetNodeList(xmlNode, attr.MappingName);
                        }
                        else
                        {
                            node = GetChildNode(xmlNode, attr.MappingName);
                        }
                        child.AnalyzeXmlNode(node);
                        property.SetValue(this, child, null);
                    }
                    else if (attr.ObjectType == XmlObjectType.List)
                    {
                        XmlNode node = GetNodeList(xmlNode, attr.MappingName);
                        List<string> list = new List<string>();
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            list.Add(GetNodeValue(child, attr.MappingType));
                        }
                        property.SetValue(this, list, null);
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

        public virtual string ToXmlString()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("message");
            BuildXmlNode(doc, ref root, root.Name);
            return root.OuterXml;
        }

        public virtual void BuildXmlNode(XmlDocument doc, ref XmlNode refNode, string subName)
        {
            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                object[] attrs = property.GetCustomAttributes(typeof(XmlMappingAttribute), true);
                if (attrs.Length > 0)
                {
                    XmlMappingAttribute attr = attrs[0] as XmlMappingAttribute;
                    if (property.PropertyType.IsSubclassOf(typeof(XmlMappingObject)))
                    {
                        XmlMappingObject obj = property.GetValue(this, null) as XmlMappingObject;
                        if (attr.ObjectType == XmlObjectType.List)
                        {
                            obj.BuildXmlNode(doc, ref refNode, attr.MappingName);
                        }
                        else
                        {
                            XmlNode node = CreateElement(doc, attr.MappingName, "");
                            obj.BuildXmlNode(doc, ref node, attr.MappingName);
                            refNode.AppendChild(node);
                        }
                    }
                    else if (attr.ObjectType == XmlObjectType.List)
                    {
                        List<string> list = property.GetValue(this, null) as List<string>;
                        foreach (string item in list)
                        {
                            XmlNode node = CreateElement(doc, attr.MappingName, item);
                            refNode.AppendChild(node);
                        }
                    }
                    else if (property.PropertyType.IsEnum)
                    {
                        int value = (int)property.GetValue(this, null);
                        if (attr.MappingType == MappingType.Attribute)
                        {
                            refNode.Attributes.Append(CreateAttribute(doc, attr.MappingName, value));
                        }
                        else
                        {
                            refNode.AppendChild(CreateElement(doc, attr.MappingName, value));
                        }
                    }
                    else
                    {
                        object value = property.GetValue(this, null);
                        if (attr.MappingType == MappingType.Attribute)
                        {
                            refNode.Attributes.Append(CreateAttribute(doc, attr.MappingName, value));
                        }
                        else
                        {
                            refNode.AppendChild(CreateElement(doc, attr.MappingName, value));
                        }
                    }
                }
            }
        }

        private XmlNode CreateElement(XmlDocument doc, string mappingName, object value)
        {
            XmlElement ele = doc.CreateElement(mappingName);
            if (value != null)
            {
                ele.InnerText = value.ToString();
            }
            return ele;
        }

        private XmlAttribute CreateAttribute(XmlDocument doc, string mappingName, object value)
        {
            XmlAttribute attr = doc.CreateAttribute(mappingName);
            if (value != null)
            {
                attr.Value = value.ToString();
            }
            return attr;
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

        private string GetNodeValue(XmlNode xmlNode, MappingType type)
        {
            if (type == MappingType.Element)
            {
                return xmlNode.InnerText;
            }
            else
            {
                return xmlNode.Value;
            }
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

        private XmlNode GetNodeList(XmlNode xmlNode, string childName)
        {
            XmlNode node = xmlNode.CloneNode(true);
            for (int i = node.ChildNodes.Count - 1; i >= 0; i--)
            {
                XmlNode child = node.ChildNodes[i];
                if (!child.Name.Equals(childName, StringComparison.OrdinalIgnoreCase))
                {
                    node.RemoveChild(child);
                }
            }
            return node;
        }
    }

    public class XmlMappingList<T> : XmlMappingObject, IList<T>
        where T : XmlMappingObject, new()
    {
        private IList<T> _list;
        public XmlMappingList()
        {
            _list = new List<T>();
        }

        #region 接口 IList<T> 成员

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Remove(T item)
        {
            _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public T this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }

        bool ICollection<T>.Remove(T item)
        {
            return _list.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion

        public override void AnalyzeXmlNode(XmlNode xmlNode)
        {
            foreach (XmlNode child in xmlNode.ChildNodes)
            {
                T t = new T();
                t.AnalyzeXmlNode(child);
                Add(t);
            }
        }

        public override void BuildXmlNode(XmlDocument doc, ref XmlNode refNode, string subName)
        {
            foreach (T item in this)
            {
                XmlNode node = CreateElement(doc, subName, "");
                item.BuildXmlNode(doc, ref node, subName);
                refNode.AppendChild(node);
            }
        }

        private XmlNode CreateElement(XmlDocument doc, string mappingName, object value)
        {
            XmlElement ele = doc.CreateElement(mappingName);
            ele.InnerText = value.ToString();
            return ele;
        }
    }
}
