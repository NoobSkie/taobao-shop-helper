using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Core.Domain
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class TOPDataMappingAttribute : Attribute
    {
        public TOPDataMappingAttribute(string mappingName)
            : this(mappingName, string.Empty)
        {
        }

        public TOPDataMappingAttribute(string mappingName, string listMappingName)
        {
            _dataMappingName = mappingName;
            _listMappingName = listMappingName;
        }

        private string _dataMappingName = string.Empty;
        public string DataMappingName
        {
            get { return _dataMappingName; }
        }

        private string _listMappingName = string.Empty;
        public string ListMappingName
        {
            get { return _listMappingName; }
        }
    }
}
