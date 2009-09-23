using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;

namespace TOP.Management.Domain
{
    /// <summary>
    /// 地址区域结构(Area)
    /// </summary>
    [DbTable(DbTableName = "Area", DbObjectType = DbObjectType.Table)]
    public class Area : DbEntity
    {
        /// <summary>
        /// 标准行政区域代码.参考:http://www.stats.gov.cn/tjbz/xzqhdm/t20080215_402462675.htm. 
        /// </summary>
        [DbField(DbFieldName = "AreaId", DbFieldType = DbDataType.NVARCHAR, Length = 10)]
        public string AreaId { get; set; }

        /// <summary>
        /// 区域类型.area区域 1:country/国家;2:province/省/自治区/直辖市;3:city/地区(省下面的地级市);4:district/县/市(县级市)/区;abroad:海外.
        /// 比如北京市的area_type = 2,朝阳区是北京市的一个区,所以朝阳区的area_type = 4. 
        /// </summary>
        [DbField(DbFieldName = "AreaType", DbFieldType = DbDataType.NVARCHAR, Length = 10)]
        public string AreaTypeId { get; set; }

        /// <summary>
        /// 地域名称.如北京市,杭州市,西湖区,每一个area_id 都代表了一个具体的地区. 
        /// </summary>
        [DbField(DbFieldName = "AreaName", DbFieldType = DbDataType.NVARCHAR, Length = 50)]
        public string AreaName { get; set; }

        /// <summary>
        /// 父节点区域标识.如北京市的area_id是110100,朝阳区是北京市的一个区,所以朝阳区的parent_id就是北京市的area_id. 
        /// </summary>
        [DbField(DbFieldName = "ParentId", DbFieldType = DbDataType.NVARCHAR, Length = 10)]
        public string ParentId { get; set; }

        /// <summary>
        /// 具体一个地区的邮编 
        /// </summary>
        [DbField(DbFieldName = "Zip", DbFieldType = DbDataType.NVARCHAR, Length = 10)]
        public string Zip { get; set; }
    }
}
