using System;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using J.SLS.Database.DBAccess;
using J.SLS.Common;
using System.Linq;
using System.Text;


namespace J.SLS.Database.ORM
{
    internal static class ORMSchemaCache
    {
        private readonly static Dictionary<Type, TypeSchema> _entityInfos = new Dictionary<Type, TypeSchema>();
        private static object o = new object();

        internal static TypeSchema GetTypeSchema(Type objectType)
        {
            TypeSchema entityInfo = null;

            if (!_entityInfos.TryGetValue(objectType, out entityInfo))
            {
                lock (o)
                {
                    if (!_entityInfos.TryGetValue(objectType, out entityInfo))
                    {
                        entityInfo = new TypeSchema(objectType);
                        _entityInfos.Add(objectType, entityInfo);
                    }
                }
            }

            return entityInfo;
        }

        internal static List<SchemaItem> GetSchemaItems(Type objectType)
        {
            TypeSchema entityInfo = GetTypeSchema(objectType);
            return entityInfo.GetAllFieldInfos();
        }
    }

    internal class TypeSchema
    {
        internal string FullClassName { get; private set; }
        internal EntityMappingTableAttribute MappingTableAttribute { get; private set; }
        internal Dictionary<string, SchemaItem> SchemaItems { get; private set; }

        private Type _objectType;
        private List<SchemaItem> _keyFieldInfos;
        private List<SchemaItem> _needUpdateFieldInfos;

        internal TypeSchema(Type objectType)
        {
            this._objectType = objectType;
            this.FullClassName = objectType.FullName;
            this.Init();
        }

        #region 公共方法

        internal List<SchemaItem> GetAllFieldInfos()
        {
            return this.SchemaItems.Values.ToList();
        }

        internal List<SchemaItem> GetKeyFieldInfos()
        {
            if (this._keyFieldInfos == null)
            {
                this._keyFieldInfos = this.GetAllFieldInfos()
                    .Where((x) => x.MappingFieldAttribute.IsKey == true).ToList();
            }
            return _keyFieldInfos;
        }

        internal List<SchemaItem> GetNeedUpdateFieldInfos()
        {
            if (this._needUpdateFieldInfos == null)
            {
                this._needUpdateFieldInfos = this.GetAllFieldInfos()
                    .Where((x) => x.MappingFieldAttribute.IsKey == false
                        && x.MappingFieldAttribute.NeedUpdate == true
                        && x.MappingFieldAttribute.IsAutoField == false).ToList();
            }
            return _needUpdateFieldInfos;
        }

        internal SchemaItem GetFieldInfoByPropertyName(string propertyName)
        {
            SchemaItem fieldInfo = null;
            SchemaItems.TryGetValue(propertyName, out fieldInfo);
            return fieldInfo;
        }

        #endregion

        #region 私有初始化函数
        private void Init()
        {
            InitMappingTableAttribute(this._objectType);
            InitSchemaItems(this._objectType);
        }

        private void InitMappingTableAttribute(Type entityType)
        {
            object[] objCollection = entityType.GetCustomAttributes(typeof(EntityMappingTableAttribute), true);
            if (objCollection.Length > 0)
            {
                this.MappingTableAttribute = objCollection[0] as EntityMappingTableAttribute;
            }
        }

        private void InitSchemaItems(Type entityType)
        {
            if (this.SchemaItems == null)
            {
                SchemaItems = new Dictionary<string, SchemaItem>();
            }

            PropertyInfo[] propertyInfos = entityType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (PropertyInfo pro in propertyInfos)
            {
                SchemaItem temp = this.FieldInfo(pro);
                if (temp != null)
                {
                    SchemaItems.Add(pro.Name, temp);
                }
            }
        }

        private SchemaItem FieldInfo(PropertyInfo propertyInfo)
        {
            EntityMappingFieldAttribute mappingFieldAttribute = null;
            object[] objCollection = propertyInfo.GetCustomAttributes(typeof(EntityMappingFieldAttribute), true);
            if (objCollection.Length == 1)
            {
                mappingFieldAttribute = objCollection[0] as EntityMappingFieldAttribute;

                if (string.IsNullOrEmpty(mappingFieldAttribute.FieldName))
                    mappingFieldAttribute.FieldName = propertyInfo.Name;

                return new SchemaItem(propertyInfo, mappingFieldAttribute);
            }

            return null;
        }
        #endregion
    }

    internal class SchemaItem
    {
        internal SchemaItem(PropertyInfo pro, EntityMappingFieldAttribute mappingFieldAttribute)
        {
            this.ProInfo = pro;
            this.MappingFieldAttribute = mappingFieldAttribute;
        }

        internal PropertyInfo ProInfo { get; private set; }
        internal EntityMappingFieldAttribute MappingFieldAttribute { get; private set; }
    }
}