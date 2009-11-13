using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;
using TOP.Common.Enumerations;

namespace TOP.Importor.Domain
{
    /// <summary>
    /// 导入宝贝组，表示一次导入的信息
    /// </summary>
    [DbTable(DbTableName = "ImportGroup", DbObjectType = DbObjectType.Table)]
    public class ImportGroup : DbEntity
    {
        /// <summary>
        /// 操作用户Id
        /// </summary>
        [DbField(DbFieldName = "OperatorUserId", DbFieldType = DbDataType.UNIQUEIDENTIFIER, IsNotNull = true)]
        public string OperatorUserId { get; set; }

        /// <summary>
        /// 操作用户名称
        /// </summary>
        [DbField(DbFieldName = "OperatorUserName", DbFieldType = DbDataType.NVARCHAR, Length = 60)]
        public string OperatorUserName { get; set; }

        /// <summary>
        /// 此次导入的宝贝总数
        /// </summary>
        [DbField(DbFieldName = "TotalCount", DbFieldType = DbDataType.INT, IsNotNull = true)]
        public int TotalCount { get; set; }

        /// <summary>
        /// 导入成功的宝贝总数
        /// </summary>
        [DbField(DbFieldName = "SuccessCount", DbFieldType = DbDataType.INT, IsNotNull = true)]
        public int SuccessCount { get; set; }

        /// <summary>
        /// 导入失败的宝贝数量
        /// </summary>
        [DbField(DbFieldName = "FailCount", DbFieldType = DbDataType.INT, IsNotNull = true)]
        public int FailCount { get; set; }

        /// <summary>
        /// 导入从  卖家昵称
        /// </summary>
        [DbField(DbFieldName = "ImportFormSellerNick", DbFieldType = DbDataType.NVARCHAR, Length = 50)]
        public string ImportFormSellerNick { get; set; }

        /// <summary>
        /// 导入从  店铺名称
        /// </summary>
        [DbField(DbFieldName = "ImportFormShopTitle", DbFieldType = DbDataType.NVARCHAR, Length = 200)]
        public string ImportFormShopTitle { get; set; }

        /// <summary>
        /// 导入从  店铺图标链接
        /// </summary>
        [DbField(DbFieldName = "ImportFormShopImageUrl", DbFieldType = DbDataType.NVARCHAR, Length = 200)]
        public string ImportFormShopImageUrl { get; set; }

        /// <summary>
        /// 导入到  卖家昵称
        /// </summary>
        [DbField(DbFieldName = "ImportToSellerNick", DbFieldType = DbDataType.NVARCHAR, Length = 50)]
        public string ImportToSellerNick { get; set; }

        /// <summary>
        /// 导入到  店铺名称
        /// </summary>
        [DbField(DbFieldName = "ImportToShopTitle", DbFieldType = DbDataType.NVARCHAR, Length = 200)]
        public string ImportToShopTitle { get; set; }

        /// <summary>
        /// 导入操作类型
        /// </summary>
        [DbField(DbFieldName = "ImportType", DbFieldType = DbDataType.INT)]
        public ImportorEnumerations.ImportType ImportType { get; set; }

        /// <summary>
        /// 导入状态
        /// </summary>
        [DbField(DbFieldName = "ImportState", DbFieldType = DbDataType.INT)]
        public ImportorEnumerations.ImportState ImportState { get; set; }

        /// <summary>
        /// 导入结果
        /// </summary>
        [DbField(DbFieldName = "ImportResult", DbFieldType = DbDataType.INT)]
        public ImportorEnumerations.ImportGroupResult ImportResult { get; set; }

        /// <summary>
        /// 排队时间
        /// </summary>
        [DbField(DbFieldName = "ListDateTime", DbFieldType = DbDataType.DATETIME)]
        public DateTime? ListDateTime { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DbField(DbFieldName = "StartDateTime", DbFieldType = DbDataType.DATETIME)]
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DbField(DbFieldName = "FinishDateTime", DbFieldType = DbDataType.DATETIME)]
        public DateTime? FinishDateTime { get; set; }
    }
}
