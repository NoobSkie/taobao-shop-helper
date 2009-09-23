using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using TOP.Common.DbHelper;
using System.Reflection;

namespace TOP.Common.Logic
{
    public abstract class FacadeBase
    {
        protected readonly DbQuery sqlHelper = new MSSql2005Query();

        public FacadeBase()
        {
            ConnString = ConfigurationManager.AppSettings["ConnString"];
        }

        protected string ConnString { get; set; }

        protected T TransferInfo<T>(DataRow dtRow)
            where T : FacadeInfoBase, new()
        {
            Type infoType = typeof(T);
            if (!infoType.IsSubclassOf(typeof(FacadeInfoBase)))
            {
                throw new ArgumentException("必须是TOP.Common.Logic.FacadeBase类型的对象才能执行此操作。 - " + infoType.FullName);
            }
            T t = new T();
            foreach (PropertyInfo prop in infoType.GetProperties())
            {
                foreach (DbFieldAttribute attr in prop.GetCustomAttributes(typeof(DbFieldAttribute), true))
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        if (dtRow[attr.DbFieldName] != DBNull.Value)
                        {
                            prop.SetValue(t, dtRow[attr.DbFieldName].ToString(), null);
                        }
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        if (dtRow[attr.DbFieldName] != DBNull.Value)
                        {
                            prop.SetValue(t, DateTime.Parse(dtRow[attr.DbFieldName].ToString()), null);
                        }
                    }
                    else if (prop.PropertyType == typeof(int))
                    {
                        if (dtRow[attr.DbFieldName] != DBNull.Value)
                        {
                            prop.SetValue(t, int.Parse(dtRow[attr.DbFieldName].ToString()), null);
                        }
                    }
                    else if (prop.PropertyType == typeof(bool))
                    {
                        if (dtRow[attr.DbFieldName] != DBNull.Value)
                        {
                            prop.SetValue(t, bool.Parse(dtRow[attr.DbFieldName].ToString()), null);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("未能对该类型的字段赋值。 - " + attr.DbFieldType.ToString());
                    }
                }
            }
            return t;
        }
    }
}
