using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Common.Xml
{
    public class XmlMappingAttribute : Attribute
    {
        public XmlMappingAttribute(string mappingName)
            : this(mappingName, MappingType.Element, XmlObjectType.Item)
        {
        }
        public XmlMappingAttribute(string mappingName, MappingType mappingType)
            : this(mappingName, mappingType, XmlObjectType.Item)
        {
        }
        public XmlMappingAttribute(string mappingName, MappingType mappingType, XmlObjectType objectType)
        {
            MappingType = mappingType;
            MappingName = mappingName;
            ObjectType = objectType;
        }

        public string MappingName { get; set; }

        public MappingType MappingType { get; set; }

        public XmlObjectType ObjectType { get; set; }
    }
}
