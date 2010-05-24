using System.Configuration;
using System.Collections.Generic;
using J.SLS.Database.DBAccess;
using System.Collections;
using System.Data.SqlClient;
using System;

namespace J.SLS.Database.Configuration
{
    /// <summary>
    /// MSSql数据库连接配置
    /// </summary>
    public class SqlConnectionConfiguration : ConnectionConfiguration
    {
        /// <summary>
        /// 连接字符串部分，不包含敏感数据
        /// </summary>
        [ConfigurationProperty("PartialConnectionString", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string PartialConnectionString
        {
            get { return (string)base["PartialConnectionString"]; }
            set { base["PartialConnectionString"] = value; }
        }

        /// <summary>
        /// 用户名（敏感数据）。如果为null，则忽略此项。
        /// </summary>
        [ConfigurationProperty("User", DefaultValue = null, IsKey = false, IsRequired = false)]
        public string User
        {
            get { return (string)base["User"]; }
            set { base["User"] = value; }
        }

        /// <summary>
        /// 密码（敏感数据）。如果为null，则忽略此项。
        /// </summary>
        [ConfigurationProperty("Password", DefaultValue = null, IsKey = false, IsRequired = false)]
        public string Password
        {
            get { return (string)base["Password"]; }
            set { base["Password"] = value; }
        }

        /// <summary>
        /// 敏感数据是否已加密
        /// </summary>
        [ConfigurationProperty("UseEncryption", DefaultValue = false, IsKey = false, IsRequired = false)]
        public bool UseEncryption
        {
            get { return (bool)base["UseEncryption"]; }
            set { base["UseEncryption"] = value; }
        }
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        public override RDatabaseType DatabaseType
        {
            get { return RDatabaseType.MSSQL; }
        }

        /// <summary>
        /// 获取完整数据库连接字符串
        /// </summary>
        public override string ConnectionString
        {
            get
            {
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
        }

        private string DecryptString(string encryptStr)
        {
            return encryptStr;
        }
    }
}

