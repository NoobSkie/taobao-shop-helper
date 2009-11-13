using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;
using TOP.Common.Logic;
using TOP.Common.Enumerations;

namespace TOP.Importor.Facade
{
    /// <summary>
    /// 导入宝贝项
    /// </summary>
    [DbTable(DbTableName = "v_ImportItem_All", DbObjectType = DbObjectType.View)]
    public class ImportItemInfo : FacadeInfoBase
    {
        /// <summary>
        /// 操作用户Id
        /// </summary>
        [DbField(DbFieldName = "OperatorUserId", DbFieldType = DbDataType.UNIQUEIDENTIFIER)]
        public string OperatorUserId { get; set; }

        /// <summary>
        /// 操作用户名称
        /// </summary>
        [DbField(DbFieldName = "OperatorUserName", DbFieldType = DbDataType.NVARCHAR, Length = 60)]
        public string OperatorUserName { get; set; }

        /// <summary>
        /// 所属导入组Id
        /// </summary>
        [DbField(DbFieldName = "ItsImportGroupId", DbFieldType = DbDataType.UNIQUEIDENTIFIER)]
        public string ItsImportGroupId { get; set; }

        /// <summary>
        /// 导入从  宝贝Iid
        /// </summary>
        [DbField(DbFieldName = "ImportFormItemIid", DbFieldType = DbDataType.NVARCHAR, Length = 50)]
        public string ImportFormItemIid { get; set; }

        /// <summary>
        /// 导入从  宝贝名称
        /// </summary>
        [DbField(DbFieldName = "ImportFormItemTitle", DbFieldType = DbDataType.NVARCHAR, Length = 200)]
        public string ImportFormItemTitle { get; set; }

        /// <summary>
        /// 导入从  宝贝价格
        /// </summary>
        [DbField(DbFieldName = "ImportFormItemPrice", DbFieldType = DbDataType.NVARCHAR, Length = 50)]
        public string ImportFormItemPrice { get; set; }

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
        /// 导入到  宝贝Iid
        /// </summary>
        [DbField(DbFieldName = "ImportToItemIid", DbFieldType = DbDataType.NVARCHAR, Length = 50)]
        public string ImportToItemIid { get; set; }

        /// <summary>
        /// 导入到  宝贝名称
        /// </summary>
        [DbField(DbFieldName = "ImportToItemTitle", DbFieldType = DbDataType.NVARCHAR, Length = 200)]
        public string ImportToItemTitle { get; set; }

        /// <summary>
        /// 导入到  宝贝价格
        /// </summary>
        [DbField(DbFieldName = "ImportToItemPrice", DbFieldType = DbDataType.NVARCHAR, Length = 50)]
        public string ImportToItemPrice { get; set; }

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
        /// 导入状态
        /// </summary>
        [DbField(DbFieldName = "ImportState", DbFieldType = DbDataType.INT)]
        public ImportorEnumerations.ImportState ImportState { get; set; }

        /// <summary>
        /// 导入结果
        /// </summary>
        [DbField(DbFieldName = "ImportResult", DbFieldType = DbDataType.INT)]
        public ImportorEnumerations.ImportItemResult ImportResult { get; set; }

        /// <summary>
        /// 结果消息
        /// </summary>
        [DbField(DbFieldName = "ResultMessage", DbFieldType = DbDataType.NVARCHAR, Length = 1000)]
        public string ResultMessage { get; set; }

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

        /// <summary>
        /// 操作用户名称
        /// </summary>
        [DbField(DbFieldName = "OperatorUserName_Last", DbFieldType = DbDataType.NVARCHAR)]
        public string OperatorUserName_Last { get; set; }

        /// <summary>
        /// 操作用户名称
        /// </summary>
        [DbField(DbFieldName = "OperatorLoginName_Last", DbFieldType = DbDataType.NVARCHAR)]
        public string OperatorLoginName_Last { get; set; }
    }
}
