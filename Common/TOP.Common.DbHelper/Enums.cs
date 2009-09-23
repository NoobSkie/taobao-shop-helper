using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.DbHelper
{
    /// <summary>
    /// 字段数据类型
    /// </summary>
    public enum DbDataType
    {
        UNIQUEIDENTIFIER = 1,
        NVARCHAR,
        INT,
        BIT,
        DATETIME,
    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DbType : short
    {
        MSSqlServer2005 = 2,
    }

    /// <summary>
    /// 数据库对象类型
    /// </summary>
    public enum DbObjectType : short
    {
        /// <summary>
        /// 表
        /// </summary>
        Table = 1,
        /// <summary>
        /// 视图
        /// </summary>
        View = 2,
    }
}
