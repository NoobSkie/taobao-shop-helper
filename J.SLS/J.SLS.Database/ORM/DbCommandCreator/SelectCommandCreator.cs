using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Reflection;
using J.SLS.Database.DBAccess;
using J.SLS.Common;


namespace J.SLS.Database.ORM
{
    /// <summary>
    /// 得到查找数据库对象的DbCommand
    /// </summary>
    internal class SelectCommandCreator : DbCommandCreator
    {
        /// <summary>
        /// 初始化ModifyCommandCreator，dbAccess不能为空
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 传入的dbAccess为空，引发此异常
        /// </exception>
        /// <param name="dbAccess">数据库访问接口</param>
        public SelectCommandCreator(IDBAccess dbAccess)
        {
            this.DbAccess = dbAccess;

            FilterProterties = new string[0];
            OrderBy = new SortInfo[0];
        }


        /// <summary>
        /// 需要处理的类型
        /// 通常使用typeof(T) 或者 t.GetType()得到该类型
        /// </summary>
        public Type ObjectType { get; set; }

        public Criteria Cri { get; set; }

        public bool NeedPaged { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        /// <summary>
        /// 对象主键的值
        /// </summary>
        public object KeyValue { get; set; }

        /// <summary>
        /// 需要处理的对象
        /// </summary>
        private object _Entity;
        public object Entity
        {
            get
            {
                return _Entity;
            }
            set
            {
                _Entity = value;
                ObjectType = value.GetType();
            }
        }

        /// <summary>
        /// 在使用条件过滤时设置
        /// 需要针对特定的属性进行过滤
        /// </summary>
        public string[] FilterProterties { get; set; }

        /// <summary>
        /// 需要针对特定的属性进行排序
        /// </summary>
        public SortInfo[] OrderBy { get; set; }

        /// <summary>
        /// 查找选择类型，使用时不能为空，根据该值的不同调用不同方法生成特定的DbCommand
        /// </summary>
        public SelectType SelectType { get; set; }


        /// <summary>
        /// 通过设定不同的属性和选择不同的生成DbCommand的方式得到不同的DbCommand
        /// 1、设定主键KeyValue和对象类型ObjectType的值，设置SelectType为GetOneByKeyValue，则会生成一个根据该类型和主键查找到唯一对象的DbCommand
        /// 2、通过设定实体对象Entity和SelectType为GetOneByEntityKey，则会根据Entity的主键（可能是多个主键）查找到唯一对象的DbCommand
        /// 3、通过设定对象类型ObjectType和排序方式OrderBy的值，设置SelectType为GetAll，则会按照指定的排序方式去查找到指定类型的所有信息
        /// 4、通过设定实体对象Entity、过滤属性FilterProterties、排序方式OrderBy和SelectType为GetList，则会根据指定的实体对象的需要过滤的值以及排序方式生成DbCommand
        /// 上述参数除了排序方式可以为空，其余都不能为空
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.CommandTextIsEmpty - 0x00010102)">
        /// 当指定的SelectType对应所需的类型为空时，则会引发此异常
        /// </exception>
        /// <returns>根据特定条件返回指定的DbCommand</returns>
        public override DbCommand GetDbCommand()
        {
            DbCommand dbCommand = null;
            switch (SelectType)
            {
                case SelectType.GetOneByKeyValue:
                    dbCommand = GetDbCommand(this.KeyValue, this.ObjectType);
                    break;
                case SelectType.GetOneByEntityKey:
                    dbCommand = GetDbCommand(this.Entity);
                    break;
                case SelectType.GetAll:
                    dbCommand = GetDbCommand(this.ObjectType, this.OrderBy);
                    break;
                case SelectType.GetList:
                    dbCommand = GetDbCommand(this.Cri, this.OrderBy);
                    break;
                case SelectType.GetCount:
                    dbCommand = GetCountDbCommand(this.Entity, this.FilterProterties);
                    break;
                case SelectType.GetAllCount:
                    dbCommand = GetAllCountDbCommand(this.ObjectType);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Don't supportted Type. - " + SelectType.ToString());
            }
            return dbCommand;
        }


        /// <summary>
        /// 构建select count()语句
        /// </summary>
        /// <param name="entityType">指定实体对象</param>
        /// <returns></returns>
        private DbCommand GetCountDbCommand(object entity, string[] filterPerproties)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(entity.GetType());
            List<PropertyInfo> fieldPropertyList = null;
            string sqlSelect = "";
            if (filterPerproties == null)
            {
                sqlSelect = string.Format("SELECT COUNT(*) FROM {0}", this.GetQuotedName(entityInfo.MappingTableAttribute.TableName));
                fieldPropertyList = new List<PropertyInfo>();//初始化fieldPropertyList，仅仅为了给GetDbCommandByEntity提供无元素的List
            }
            else
            {
                sqlSelect = string.Format("SELECT {0}",
                                        GetCountSelectStatement(entityInfo, out fieldPropertyList, filterPerproties));
            }

            DbCommand dbCommand = GetDbCommandByEntity(fieldPropertyList, entity);
            dbCommand.CommandText = sqlSelect;
            return dbCommand;
        }

        private DbCommand GetAllCountDbCommand(Type entityType)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(entityType);
            List<PropertyInfo> fieldPropertyList = new List<PropertyInfo>();
            string sqlSelect = string.Format("SELECT COUNT(*) FROM {0}", this.GetQuotedName(entityInfo.MappingTableAttribute.TableName));
            DbCommand dbCommand = GetDbCommandByEntity(fieldPropertyList, null);
            dbCommand.CommandText = sqlSelect;
            return dbCommand;
        }

        private DbCommand GetDbCommand(object keyValue, Type entityType)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(entityType);
            List<PropertyInfo> fieldPropertyList = null;
            string tableName = entityInfo.MappingTableAttribute.TableName;
            string sqlSelect = string.Format("SELECT {0}", GetSelectStatement(entityInfo, out fieldPropertyList, null));

            DbCommand dbCommand = GetDbCommandByKeyValue(entityInfo, keyValue);
            dbCommand.CommandText = sqlSelect;
            return dbCommand;
        }

        private DbCommand GetDbCommand(object entity)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(entity.GetType());
            List<PropertyInfo> fieldPropertyList = null;
            string tableName = entityInfo.MappingTableAttribute.TableName;
            string sqlSelect = string.Format("SELECT {0}", GetSelectStatement(entityInfo, out fieldPropertyList, null));

            DbCommand dbCommand = GetDbCommandByEntity(fieldPropertyList, entity);
            dbCommand.CommandText = sqlSelect;
            return dbCommand;
        }

        private DbCommand GetDbCommand(Type entityType, params SortInfo[] orderBy)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(entityType);
            List<PropertyInfo> fieldPropertyList = new List<PropertyInfo>();
            string sqlFields = GetSelectStatement(entityInfo);
            string sqlOrder = ToOrderByClause(this.ObjectType, orderBy);
            StringBuilder sqlBuilder = new StringBuilder();
            if (NeedPaged)
            {
                if (sqlOrder == "")
                {
                    foreach (SchemaItem mfi in entityInfo.GetKeyFieldInfos())
                    {
                        if (sqlOrder != "")
                        {
                            sqlOrder += ",";
                        }
                        else
                        {
                            sqlOrder += "ORDER BY ";
                        }
                        sqlOrder += GetQuotedName(mfi.MappingFieldAttribute.FieldName) + " ASC";
                    }
                }
                sqlBuilder.AppendLine("WITH [TMP] AS(");
                sqlBuilder.AppendLine("SELECT *, ROW_NUMBER() OVER (" + sqlOrder + ") AS [ROW]");
                sqlBuilder.AppendLine("FROM(");
                sqlBuilder.AppendLine(string.Format("SELECT {0}", sqlFields));
                sqlBuilder.AppendLine(") AS [A] )");
                sqlBuilder.AppendLine("SELECT * FROM [TMP]");
                sqlBuilder.AppendLine("INNER JOIN (SELECT COUNT([ROW]) AS [TotalCount] FROM [TMP]) AS [B] ON 1 = 1");
                sqlBuilder.AppendLine(string.Format(" AND ROW > {0} AND ROW <= {1}", PageSize * (PageIndex - 1), PageSize * PageIndex));
            }
            else
            {
                sqlBuilder.AppendLine(string.Format("SELECT {0}", sqlFields));
                sqlBuilder.AppendLine(sqlOrder);
            }
            DbCommand dbCommand = GetDbCommandByEntity(fieldPropertyList, null);
            dbCommand.CommandText = sqlBuilder.ToString();
            return dbCommand;
        }

        private DbCommand GetDbCommand(Criteria criteria, params SortInfo[] orderBy)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(this.ObjectType);
            List<PropertyInfo> fieldPropertyList = new List<PropertyInfo>();
            string sqlFields = GetSelectStatement(entityInfo);
            List<DbParameter> parameters;
            string sqlWhere = criteria.GenerateExpression(this.ObjectType, out parameters, DbAccess);
            string sqlOrder = ToOrderByClause(this.ObjectType, orderBy);
            StringBuilder sqlBuilder = new StringBuilder();
            if (NeedPaged)
            {
                if (sqlOrder == "")
                {
                    foreach (SchemaItem mfi in entityInfo.GetKeyFieldInfos())
                    {
                        if (sqlOrder != "")
                        {
                            sqlOrder += ",";
                        }
                        else
                        {
                            sqlOrder += "ORDER BY ";
                        }
                        sqlOrder += GetQuotedName(mfi.MappingFieldAttribute.FieldName) + " ASC";
                    }
                }
                sqlBuilder.AppendLine("WITH [TMP] AS(");
                sqlBuilder.AppendLine("SELECT *, ROW_NUMBER() OVER (" + sqlOrder + ") AS [ROW]");
                sqlBuilder.AppendLine("FROM(");
                sqlBuilder.AppendLine(string.Format("SELECT {0}", sqlFields));
                sqlBuilder.AppendLine(string.Format("WHERE 1=1 {0}", sqlWhere));
                sqlBuilder.AppendLine(") AS [A] )");
                sqlBuilder.AppendLine("SELECT * FROM [TMP]");
                sqlBuilder.AppendLine("INNER JOIN (SELECT COUNT([ROW]) AS [TotalCount] FROM [TMP]) AS [B] ON 1 = 1");
                sqlBuilder.AppendLine(string.Format(" AND ROW > {0} AND ROW <= {1}", PageSize * (PageIndex - 1), PageSize * PageIndex));
            }
            else
            {
                sqlBuilder.AppendLine(string.Format("SELECT {0}", sqlFields));
                sqlBuilder.AppendLine(string.Format("WHERE 1=1 {0}", sqlWhere));
                sqlBuilder.AppendLine(sqlOrder);
            }
            DbCommand dbCommand = GetDbCommandByEntity(fieldPropertyList, null);
            dbCommand.Parameters.AddRange(parameters.ToArray());
            dbCommand.CommandText = sqlBuilder.ToString();
            return dbCommand;
        }

        /// <summary>
        /// 构建带where条件查询的sql语句
        /// </summary>
        /// <param name="fieldPropertyList"></param>
        /// <param name="tableName">表名</param>
        /// <param name="filterProterties">要查询的字段</param>
        /// <returns>sql语句</returns>
        private string GetSelectStatement(TypeSchema entityInfo, out List<PropertyInfo> fieldPropertyList, string[] filterProterties)
        {
            fieldPropertyList = new List<PropertyInfo>();
            string fields = "", query = "";

            foreach (SchemaItem mfi in entityInfo.GetAllFieldInfos())
            {
                PropertyInfo property = mfi.ProInfo;
                EntityMappingFieldAttribute fieldAttr = mfi.MappingFieldAttribute;
                if (fields != "") fields += ",";
                fields += GetQuotedName(fieldAttr.FieldName);
                //当不选择过滤条件则判定是否是主键、当选择过滤字段则判断当前属性是否包含在过滤字段内
                if ((filterProterties == null && fieldAttr.IsKey == true) || (filterProterties != null && filterProterties.Contains(property.Name)))
                {
                    if (query != "") query += " AND ";
                    query += GetQuotedName(fieldAttr.FieldName) + "=@" + property.Name;
                    fieldPropertyList.Add(property);
                }
            }

            return string.Format("{0} FROM {1} WHERE {2}", fields, this.GetQuotedName(entityInfo.MappingTableAttribute.TableName), query);
        }

        /// <summary>
        /// 构建无where条件查询的sql语句
        /// </summary>
        /// <param name="fieldPropertyList"></param>
        /// <param name="tableName">表名</param>
        /// <returns>sql语句</returns>
        private string GetSelectStatement(TypeSchema entityInfo)
        {
            string fields = "";
            foreach (SchemaItem mfi in entityInfo.GetAllFieldInfos())
            {
                if (fields != "") fields += ",";
                fields += GetQuotedName(mfi.MappingFieldAttribute.FieldName);
            }

            return string.Format("{0} FROM {1}", fields, this.GetQuotedName(entityInfo.MappingTableAttribute.TableName));
        }
        /// <summary>
        /// 给select count()语句构建带where条件查询的sql语句
        /// </summary>
        /// <param name="fieldPropertyList"></param>
        /// <param name="tableName"></param>
        /// <param name="filterProterties"></param>
        /// <returns></returns>
        private string GetCountSelectStatement(TypeSchema entityInfo, out List<PropertyInfo> fieldPropertyList, string[] filterProterties)
        {
            fieldPropertyList = new List<PropertyInfo>();
            string fields = "", query = "";
            foreach (SchemaItem mfi in entityInfo.GetAllFieldInfos())
            {
                PropertyInfo property = mfi.ProInfo;
                EntityMappingFieldAttribute fieldAttr = mfi.MappingFieldAttribute;
                if (fields != "") fields += ",";
                fields += GetQuotedName(fieldAttr.FieldName);
                //当不选择过滤条件则判定是否是主键、当选择过滤字段则判断当前属性是否包含在过滤字段内
                if ((filterProterties == null && fieldAttr.IsKey == true) || (filterProterties != null && filterProterties.Contains(property.Name)))
                {
                    if (query != "") query += " AND ";
                    query += GetQuotedName(fieldAttr.FieldName) + "=@" + property.Name;
                    fieldPropertyList.Add(property);
                }
            }
            return string.Format(" COUNT(*) FROM {0} WHERE {1}", this.GetQuotedName(entityInfo.MappingTableAttribute.TableName), query);
        }
        private string ToOrderByClause(Type entityType, params SortInfo[] orderBy)
        {
            TypeSchema entityInfo = ORMSchemaCache.GetTypeSchema(entityType);
            string orderByStr = "";
            if (null != orderBy && orderBy.Length > 0)
            {
                foreach (SortInfo tempSortInfo in orderBy)
                {
                    SchemaItem fieldInfo = entityInfo.GetFieldInfoByPropertyName(tempSortInfo.PropertyName);
                    if (fieldInfo == null)
                    {
                        throw new ArgumentException("Sort property not define a mapping field. - \"" + tempSortInfo.PropertyName + "\"");
                    }
                    string tempName = GetQuotedName(fieldInfo.MappingFieldAttribute.FieldName);
                    if (tempSortInfo.Direction == SortDirection.Desc)
                        orderByStr += "," + tempName + " Desc";
                    else
                        orderByStr += "," + tempName;
                }

                if (orderByStr.Length > 0)
                    orderByStr = orderByStr.Substring(1); //remove the first char ','.
                return string.Format(" ORDER BY {0}", orderByStr);
            }
            else
            {
                return orderByStr;
            }
        }
    }

    /// <summary>
    /// 选择类型
    /// </summary>
    public enum SelectType : int
    {
        Unkown = 0,
        GetOneByKeyValue,
        GetOneByEntityKey,
        GetAll,
        GetCount,
        GetAllCount,
        GetList
    }
}
