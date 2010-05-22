using DAL;
using Shove.Database;
using System;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

public class SiteNotificationTemplates
{
    public Sites Site;

    public SiteNotificationTemplates()
    {
        this.Site = null;
    }

    public SiteNotificationTemplates(Sites site)
    {
        this.Site = site;
    }

    public void SplitEmailTemplate(string Content, ref string Subject, ref string Body)
    {
        Match match = new Regex(@"{Subject}(?<Subject>[^{]*?){/Subject}(?<Body>[\W\w]*)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Content);
        Subject = match.Groups["Subject"].ToString().Trim();
        Body = match.Groups["Body"].ToString().Trim();
    }

    public string this[string Manner, string NotificationType]
    {
        get
        {
            if ((this.Site == null) || (this.Site.ID < 1L))
            {
                throw new Exception("没有初始化 SiteNotificationTemplates 类的 Site 变量");
            }
            if (((Manner != "SMS") && (Manner != "Email")) && (Manner != "StationSMS"))
            {
                throw new Exception("SiteNotificationTemplates 类的通知方式 Manner 变量的值超出的范围，它的范围是：1 (SMS)手机短信 2 Email 3 (StationSMS)站内信");
            }
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
                throw new Exception("SiteNotificationTemplates 类读取数据错误，请检查数据库连接设置");
            }
            if (table.Rows.Count < 1)
            {
                throw new Exception("SiteNotificationTemplates 类的 Site 变量值不在有效范围之内");
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
            return table.Rows[0]["Template" + Manner + "_" + NotificationType].ToString().Replace("[SiteName]", this.Site.Name).Replace("[SiteUrl]", this.Site.Url);
        }
        set
        {
            if ((this.Site == null) || (this.Site.ID < 1L))
            {
                throw new Exception("没有初始化 SiteNotificationTemplates 类的 Site 变量");
            }
            if ((!(Manner == "SMS") && !(Manner == "Email")) && !(Manner == "StationSMS"))
            {
                throw new Exception("SiteNotificationTemplates 类的通知方式 Manner 变量的值超出的范围，它的范围是：1 (SMS)手机短信 2 Email 3 (StationSMS)站内信");
            }
            if (MSSQL.ExecuteNonQuery("update T_Sites set [Template" + Manner + "_" + NotificationType + "] = @Value where [ID]=@ID", new MSSQL.Parameter[] { new MSSQL.Parameter("Value", SqlDbType.VarChar, 0, ParameterDirection.Input, value), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, this.Site.ID) }) < 0)
            {
                throw new Exception("SiteNotificationTemplates 类读取数据错误，请检查数据库连接设置。如果数据库连接设置没有问题，可能是 NotificationType 变量的值不在有效范围之内");
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

    public string this[short Manner, string NotificationType]
    {
        get
        {
            if ((Manner < 1) || (Manner > 3))
            {
                throw new Exception("SiteNotificationTemplates 类的通知方式 Manner 变量的值超出的范围，它的范围是：1 手机短信 2 Email 3 站内信");
            }
            return this[(Manner == 1) ? "SMS" : ((Manner == 2) ? "Email" : "StationSMS"), NotificationType];
        }
        set
        {
            if ((Manner < 1) || (Manner > 3))
            {
                throw new Exception("SiteNotificationTemplates 类的通知方式 Manner 变量的值超出的范围，它的范围是：1 手机短信 2 Email 3 站内信");
            }
            this[(Manner == 1) ? "SMS" : ((Manner == 2) ? "Email" : "StationSMS"), NotificationType] = value;
        }
    }
}

