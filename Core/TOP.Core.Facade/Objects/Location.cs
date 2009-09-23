using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Core.Domain;

namespace TOP.Core.Facade
{
    /// <summary>
    /// 商品所在地址
    /// </summary>
    [TOPDataMappingAttribute("location")]
    public class Location : TOPDataItem
    {
        /// <summary>
        /// 省
        /// </summary>
        [TOPDataMappingAttribute("state")]
        public string State { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [TOPDataMappingAttribute("city")]
        public string City { get; set; }

        public override string ToString()
        {
            return State + City;
        }
    }
}
