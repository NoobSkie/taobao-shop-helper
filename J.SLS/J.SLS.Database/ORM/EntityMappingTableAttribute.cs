using System;

namespace J.SLS.Database.ORM
{
    /// <summary>
    /// 实体类的类标注，用于标注实体类存储在数据库中的表名
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EntityMappingTableAttribute : Attribute
    {
        /// <summary>
        /// 实体类映射到数据库的表名，不能为null或空串
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 指定映射的对象是否是一个只读对象。
        /// 如果被指定为只读对象,在对此对象做增、删、改操作时,会抛出对应异常
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// 设置实体类映射的表名，表名不能为null或空串
        /// </summary>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下情况会引发该异常：
        /// 1.传入的tableName为null或空串时
        /// </exception>
        /// <param name="tableName">需持久化的类映射的数据库表名</param>
        public EntityMappingTableAttribute(string tableName)
        {
            this.TableName = tableName;
            this.ReadOnly = false;
        }
    }
}