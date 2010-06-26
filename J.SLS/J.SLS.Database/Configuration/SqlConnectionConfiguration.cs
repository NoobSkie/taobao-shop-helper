using System.Configuration;
using System.Collections.Generic;
using J.SLS.Database.DBAccess;
using System.Collections;
using System.Data.SqlClient;
using System;

namespace J.SLS.Database.Configuration
{
    public class SqlConnectionConfiguration : ConnectionConfiguration
    {
        [ConfigurationProperty("PartialConnectionString", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string PartialConnectionString
        {
            get { return (string)base["PartialConnectionString"]; }
            set { base["PartialConnectionString"] = value; }
        }

        [ConfigurationProperty("User", DefaultValue = null, IsKey = false, IsRequired = false)]
        public string User
        {
            get { return (string)base["User"]; }
            set { base["User"] = value; }
        }

        [ConfigurationProperty("Password", DefaultValue = null, IsKey = false, IsRequired = false)]
        public string Password
        {
            get { return (string)base["Password"]; }
            set { base["Password"] = value; }
        }

        [ConfigurationProperty("UseEncryption", DefaultValue = false, IsKey = false, IsRequired = false)]
        public bool UseEncryption
        {
            get { return (bool)base["UseEncryption"]; }
            set { base["UseEncryption"] = value; }
        }

        [ConfigurationProperty("IsPartialFull", DefaultValue = false, IsKey = false, IsRequired = false)]
        public bool IsPartialFull
        {
            get { return (bool)base["IsPartialFull"]; }
            set { base["IsPartialFull"] = value; }
        }

        public override RDatabaseType DatabaseType
        {
            get { return RDatabaseType.MSSQL; }
        }

        public override string ConnectionString
        {
            get
            {
                try
                {
                    if (IsPartialFull)
                    {
                        return PartialConnectionString;
                    }
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(PartialConnectionString);
                    if (!builder.IntegratedSecurity)
                    {
                        if (User != null)
                        {
                            string userId = User;
                            if (UseEncryption) { userId = DecryptString(userId); }
                            builder.UserID = userId;
                        }
                        if (Password != null)
                        {
                            string password = Password;
                            if (UseEncryption) { password = DecryptString(password); }
                            builder.Password = password;
                        }
                    }
                    return builder.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("获取连接字符串错误 - " + PartialConnectionString, ex);
                }
            }
        }

        private string DecryptString(string encryptStr)
        {
            return encryptStr;
        }
    }
}

