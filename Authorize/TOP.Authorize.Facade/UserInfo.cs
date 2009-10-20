using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.Logic;
using TOP.Common.DbHelper;

namespace TOP.Authorize.Facade
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [DbTable(DbTableName = "v_SystemUser_All", DbObjectType = DbObjectType.View)]
    public class UserInfo : FacadeInfoBase
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [DbField(DbFieldName = "LoginName", DbFieldType = DbDataType.NVARCHAR, Length = 20)]
        public string LoginName { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [DbField(DbFieldName = "UserName", DbFieldType = DbDataType.NVARCHAR, Length = 60)]
        public string UserName { get; set; }
    }
}
