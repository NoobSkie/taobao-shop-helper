using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common.Xml
{
    public class XmlMappingAttribute : Attribute
    {
        public XmlMappingAttribute(string mappingName, int index)
            : this(mappingName, index, MappingType.Element, XmlObjectType.Item)
        {
        }
        public XmlMappingAttribute(string mappingName, int index, MappingType mappingType)
            : this(mappingName, index, mappingType, XmlObjectType.Item)
        {
        }
        public XmlMappingAttribute(string mappingName, int index, MappingType mappingType, XmlObjectType objectType)
        {
            MappingType = mappingType;
            Index = index;
            ObjectType = objectType;
        }

        public string MappingName { get; set; }

        public int Index { get; set; }

        public MappingType MappingType { get; set; }

        public XmlObjectType ObjectType { get; set; }
    }
}
