using System;

namespace J.SLS.Database.ORM
{
    /// <summary>
    /// 实体类中需持久化字段的标注。
    /// 用于配置该字段映射表字段的信息，其中映射的字段名不能为null或空串。
    /// 只能将此特性定义到类的属性上。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EntityMappingFieldAttribute : Attribute
    {
        /// <summary>
        /// 映射到数据库的字段名，不能为null或空串
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 是否需要更新到数据库中，默认为true
        /// </summary>
        public bool NeedUpdate { get; set; }
        /// <summary>
        /// 是否为自动生成的字段，如果为true，新增时忽略此字段。默认为false
        /// </summary>
        public bool IsAutoField { get; set; }
        /// <summary>
        /// 是否为数据库中的主键，默认为false
        /// </summary>
        public bool IsKey { get; set; }

        /// <summary>
        /// 初始化对象实例。设置字段映射属性,字段名不能为null或空串
        /// 默认该字段不为主键，并且需要更新
        /// </summary>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下情况会引发该异常：
        /// 1.传入的fieldName为null或空串时
        /// </exception>
        /// <param name="fieldName">映射到数据库中的字段名</param>
        public EntityMappingFieldAttribute(string fieldName)
        {
            this.FieldName = fieldName;
            this.IsKey = false;
            this.NeedUpdate = true;
        }
    }
}