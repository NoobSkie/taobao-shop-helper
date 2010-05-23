using SLS.Site.App_Code.DAL;
using System;
using System.Data;
using System.Reflection;
using System.Web;

namespace SLS.Site.App_Code
{
    public class SystemOptions
    {
        public OptionValue this[string Key]
        {
            get
            {
                string name = "SystemOptions_";
                DataTable table = null;
                bool flag = true;
                try
                {
                    table = (DataTable)HttpContext.Current.Application[name];
                }
                catch
                {
                }
                if (table == null)
                {
                    flag = false;
                    table = new Tables.T_Options().Open("[Key], [Value]", "", "");
                }
                if (table == null)
                {
                    throw new Exception("T_Options 表读取发生错误，请检查数据连接或者数据库是否完整");
                }
                DataRow[] rowArray = table.Select("Key='" + Key + "'");
                if ((rowArray == null) || (rowArray.Length < 1))
                {
                    throw new Exception("T_Options 表读取发生错误，请检查数据连接或者是否该表拥有 Key 值为 " + Key + " 记录");
                }
                if (!flag)
                {
                    try
                    {
                        HttpContext.Current.Application.Lock();
                        HttpContext.Current.Application.Add(name, table);
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
                return new OptionValue(rowArray[0]["Value"]);
            }
            set
            {
                Procedures.P_SetOptions(Key, value.Value.ToString());
                string name = "SystemOptions_";
                try
                {
                    HttpContext.Current.Application.Lock();
                    HttpContext.Current.Application.Remove(name);
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
}