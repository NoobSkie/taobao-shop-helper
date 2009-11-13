using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.Enumerations
{
    public class ImportorEnumerations
    {
        /// <summary>
        /// 导入组结果
        /// </summary>
        public enum ImportGroupResult
        {
            /// <summary>
            /// 未开始统计
            /// </summary>
            Pending = 0,
            /// <summary>
            /// 全部成功
            /// </summary>
            AllSuccess = 1,
            /// <summary>
            /// 部分成功
            /// </summary>
            ParttenSuccess = 2,
            /// <summary>
            /// 失败
            /// </summary>
            Fail = 3,
        }

        /// <summary>
        /// 导入一个宝贝结果
        /// </summary>
        public enum ImportItemResult
        {
            /// <summary>
            /// 未开始
            /// </summary>
            Pending = 0,
            /// <summary>
            /// 新增成功
            /// </summary>
            AddSuccess = 1,
            /// <summary>
            /// 更新成功
            /// </summary>
            UpdateSuccess = 2,
            /// <summary>
            /// 已存在，停止导入
            /// </summary>
            ExistStop = 3,
            /// <summary>
            /// 操作失败
            /// </summary>
            Fail = 4,
        }

        /// <summary>
        /// 导入操作状态
        /// </summary>
        public enum ImportState
        {
            /// <summary>
            /// 排队中
            /// </summary>
            Waitting = 0,
            /// <summary>
            /// 正在导入
            /// </summary>
            Importing = 1,
            /// <summary>
            /// 结束
            /// </summary>
            Finished = 2,
        }

        /// <summary>
        /// 导入数据类型
        /// </summary>
        public enum ImportType
        {
            /// <summary>
            /// 宝贝
            /// </summary>
            Item = 0,
            /// <summary>
            /// 店铺
            /// </summary>
            Shop = 1,
        }
    }
}
