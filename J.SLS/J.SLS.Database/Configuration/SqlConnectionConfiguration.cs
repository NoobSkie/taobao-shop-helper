using System.Configuration;
using System.Collections.Generic;
using J.SLS.Database.DBAccess;
using System.Collections;
using System.Data.SqlClient;
using System;

namespace J.SLS.Database.Configuration
{
    /// <summary>
    /// MSSql���ݿ���������
    /// </summary>
    public class SqlConnectionConfiguration : ConnectionConfiguration
    {
        /// <summary>
        /// �����ַ������֣���������������
        /// </summary>
        [ConfigurationProperty("PartialConnectionString", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string PartialConnectionString
        {
            get { return (string)base["PartialConnectionString"]; }
            set { base["PartialConnectionString"] = value; }
        }

        /// <summary>
        /// �û������������ݣ������Ϊnull������Դ��
        /// </summary>
        [ConfigurationProperty("User", DefaultValue = null, IsKey = false, IsRequired = false)]
        public string User
        {
            get { return (string)base["User"]; }
            set { base["User"] = value; }
        }

        /// <summary>
        /// ���루�������ݣ������Ϊnull������Դ��
        /// </summary>
        [ConfigurationProperty("Password", DefaultValue = null, IsKey = false, IsRequired = false)]
        public string Password
        {
            get { return (string)base["Password"]; }
            set { base["Password"] = value; }
        }

        /// <summary>
        /// ���������Ƿ��Ѽ���
        /// </summary>
        [ConfigurationProperty("UseEncryption", DefaultValue = false, IsKey = false, IsRequired = false)]
        public bool UseEncryption
        {
            get { return (bool)base["UseEncryption"]; }
            set { base["UseEncryption"] = value; }
        }
        /// <summary>
        /// ��ȡ���ݿ�����
        /// </summary>
        public override RDatabaseType DatabaseType
        {
            get { return RDatabaseType.MSSQL; }
        }

        /// <summary>
        /// ��ȡ�������ݿ������ַ���
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

