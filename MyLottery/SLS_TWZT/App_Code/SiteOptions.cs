using DAL;
using Shove.Database;
using System;
using System.Data;
using System.Reflection;
using System.Web;

public class SiteOptions
{
    public Sites Site;

    public SiteOptions()
    {
        this.Site = null;
    }

    public SiteOptions(Sites site)
    {
        this.Site = site;
    }

    public OptionValue this[string Key]
    {
        get
        {
            string str = "SiteOptions_";
            DataTable table = null;
            bool flag = true;
            try
            {
                table = (DataTable)HttpContext.Current.Application[str + this.Site.ID.ToString()];
            }
            catch
            {
            }
            if ((table == null) || (table.Rows.Count < 1))
            {
                flag = false;
                table = new Tables.T_Sites().Open("", "[ID] = " + this.Site.ID.ToString(), "");
            }
            if (table == null)
            {
                throw new Exception("T_Sites 表读取发生错误，请检查数据连接或者数据库是否完整");
            }
            if (table.Rows.Count < 1)
            {
                throw new Exception("没有读到站点 ID 为 " + this.Site.ID.ToString() + " 的站点信息");
            }
            if (!flag)
            {
                try
                {
                    HttpContext.Current.Application.Lock();
                    HttpContext.Current.Application.Add(str + this.Site.ID.ToString(), table);
                }
                catch
                {
                }
                finally
                {
                    try
                    {
                        HttpContext.Current.Application.UnLock();
                    }
                    catch
                    {
                    }
                }
            }
            return new OptionValue(table.Rows[0][Key]);
        }
        set
        {
            if ((this.Site == null) || (this.Site.ID < 1L))
            {
                throw new Exception("没有初始化 SiteOptions 类的 Site 变量");
            }
            DataTable table = new Tables.T_Sites().Open(Key, "[ID] = " + this.Site.ID.ToString(), "");
            if (table == null)
            {
                throw new Exception("T_Sites 表读取发生错误，请检查数据连接或者是否该表拥有 " + Key + " 字段");
            }
            if (table.Rows.Count < 1)
            {
                throw new Exception("没有读到站点 ID 为 " + this.Site.ID.ToString() + " 的站点信息");
            }
            switch (table.Columns[0].DataType.Name)
            {
                case "Byte[]":
                    if (MSSQL.ExecuteNonQuery("update T_Sites set " + Key + " = @Value where [ID] = " + this.Site.ID.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.VarChar, 0, ParameterDirection.Input, value.Value.ToString()) }) < 0)
                    {
                        throw new Exception("设置站点属性 " + Key + " 发生异常");
                    }
                    break;

                case "String":
                    if (MSSQL.ExecuteNonQuery("update T_Sites set " + Key + " = @Value where [ID] = " + this.Site.ID.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.VarChar, 0, ParameterDirection.Input, value.Value) }) < 0)
                    {
                        throw new Exception("设置站点属性 " + Key + " 发生异常");
                    }
                    break;

                case "Int16":
                    if (MSSQL.ExecuteNonQuery("update T_Sites set " + Key + " = @Value where [ID] = " + this.Site.ID.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.SmallInt, 0, ParameterDirection.Input, value.Value) }) < 0)
                    {
                        throw new Exception("设置站点属性 " + Key + " 发生异常");
                    }
                    break;

                case "Int32":
                    if (MSSQL.ExecuteNonQuery("update T_Sites set " + Key + " = @Value where [ID] = " + this.Site.ID.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.Int, 0, ParameterDirection.Input, value.Value) }) < 0)
                    {
                        throw new Exception("设置站点属性 " + Key + " 发生异常");
                    }
                    break;

                case "Int64":
                    if (MSSQL.ExecuteNonQuery("update T_Sites set " + Key + " = @Value where [ID] = " + this.Site.ID.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.BigInt, 0, ParameterDirection.Input, value.Value) }) < 0)
                    {
                        throw new Exception("设置站点属性 " + Key + " 发生异常");
                    }
                    break;

                case "Decimal":
                    if (MSSQL.ExecuteNonQuery("update T_Sites set " + Key + " = @Value where [ID] = " + this.Site.ID.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.Money, 0, ParameterDirection.Input, value.Value) }) < 0)
                    {
                        throw new Exception("设置站点属性 " + Key + " 发生异常");
                    }
                    break;

                case "Boolean":
                    if (MSSQL.ExecuteNonQuery("update T_Sites set " + Key + " = @Value where [ID] = " + this.Site.ID.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.Bit, 0, ParameterDirection.Input, value.Value) }) < 0)
                    {
                        throw new Exception("设置站点属性 " + Key + " 发生异常");
                    }
                    break;

                case "Double":
                    if (MSSQL.ExecuteNonQuery("update T_Sites set " + Key + " = @Value where [ID] = " + this.Site.ID.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.Float, 0, ParameterDirection.Input, value.Value) }) < 0)
                    {
                        throw new Exception("设置站点属性 " + Key + " 发生异常");
                    }
                    break;

                default:
                    throw new Exception("设置站点属性 " + Key + " 发生异常");
            }
            string str2 = "SiteOptions_";
            try
            {
                HttpContext.Current.Application.Lock();
                HttpContext.Current.Application.Remove(str2 + this.Site.ID.ToString());
            }
            catch
            {
            }
            finally
            {
                try
                {
                    HttpContext.Current.Application.UnLock();
                }
                catch
                {
                }
            }
        }
    }
}

