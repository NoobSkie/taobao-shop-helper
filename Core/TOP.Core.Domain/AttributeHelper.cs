using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TOP.Core.Domain
{
    public class AttributeHelper
    {
        public string GetTypeMappingName(Type type)
        {
            string mappingName = string.Empty;
            object[] attrs = type.GetCustomAttributes(typeof(TOPDataMappingAttribute), true);
            foreach (TOPDataMappingAttribute attr in attrs)
            {
                mappingName = attr.DataMappingName;
            }
            return mappingName;
        }

        public void GetPropertyMappingName(PropertyInfo property, out string dataMappingName, out string listMappingName)
        {
            dataMappingName = string.Empty;
            listMappingName = string.Empty;
            object[] attrs = property.GetCustomAttributes(typeof(TOPDataMappingAttribute), true);
            foreach (TOPDataMappingAttribute attr in attrs)
            {
                dataMappingName = attr.DataMappingName;
                listMappingName = attr.ListMappingName;
            }
        }

        public string GetDataObjFieldsString(Type dataObjType)
        {
            List<string> fields = new List<string>();
            foreach (PropertyInfo property in dataObjType.GetProperties())
            {
                object[] attrs = property.GetCustomAttributes(typeof(TOPDataMappingAttribute), true);
                foreach (TOPDataMappingAttribute attr in attrs)
                {
                    fields.Add(attr.DataMappingName);
                    break;
                }
            }
            return string.Join(",", fields.ToArray());
        }
    }
}
