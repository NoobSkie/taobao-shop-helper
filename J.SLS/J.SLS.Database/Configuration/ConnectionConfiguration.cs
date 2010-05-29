using System.Configuration;
using System.Collections.Generic;
using J.SLS.Database.DBAccess;
using System.Collections;
using System.Data.SqlClient;
using System;

namespace J.SLS.Database.Configuration
{
    /// <summary>
    /// һ���������û��࣬�����������������������
    /// </summary>
    public abstract class ConnectionConfiguration : ConfigurationSection
    {
        /// <summary>
        /// ��ȡĬ�����ýڵ�����ݿ����Ӷ������ã�DefaultConnection
        /// </summary>
        /// <returns>�������ݿ��������ö�����������ڴ˽ڵ㣬�򷵻�null</returns>
        public static ConnectionConfiguration GetConfiguration()
        {
            return GetConfiguration("DefaultConnection");
        }

        /// <summary>
        /// ��ȡָ�����Ƶ����ýڵ�����ݿ����Ӷ�������
        /// </summary>
        /// <param name="configName">ָ�����ýڵ�����</param>
        /// <returns>�������ݿ��������ö�����������ڴ˽ڵ㣬�򷵻�null</returns>
        public static ConnectionConfiguration GetConfiguration(string configName)
        {
            ConnectionConfiguration config = (ConnectionConfiguration)ConfigurationManager.GetSection(configName);
            return config;
        }

        [ThreadStatic]
        private static ILHDBAccess _dbAccess;
        /// <summary>
        /// ��ȡ���ݿ���ʶ����̵߳���
        /// </summary>
        public ILHDBAccess DbAccess
        {
            get
            {
                if (_dbAccess == null)
                {
                    _dbAccess = LHDBFactory.CreateDBAccessInstance(DatabaseType, ConnectionString);
                    _dbAccess.ConnectionTimeout = this.ConnectionTimeout;
                    _dbAccess.CommandTimeout = this.CommandTimeout;
                }
                return _dbAccess;
            }
        }

        /// <summary>
        /// ��ȡ���ݿ�������ʶ���
        /// </summary>
        public ILHDBTran BeginTran()
        {
            ILHDBTran _dbTran = LHDBFactory.BeginTransaction(DatabaseType, ConnectionString);
            _dbTran.ConnectionTimeout = this.ConnectionTimeout;
            _dbTran.CommandTimeout = this.CommandTimeout;
            return _dbTran;
        }

        /// <summary>
        /// ��ȡ���ݿ�����
        /// </summary>
        public abstract RDatabaseType DatabaseType { get; }

        /// <summary>
        /// ��ȡ�������ݿ������ַ���
        /// </summary>
        public abstract string ConnectionString { get; }

        /// <summary>
        /// ִ�г�ʱʱ��
        /// </summary>
        [ConfigurationProperty("CommandTimeout", DefaultValue = 60, IsKey = false, IsRequired = false)]
        public int CommandTimeout
        {
            get { return (int)base["CommandTimeout"]; }
            set { base["CommandTimeout"] = value; }
        }

        /// <summary>
        /// ���ӳ�ʱʱ��
        /// </summary>
        [ConfigurationProperty("ConnectionTimeout", DefaultValue = 60, IsKey = false, IsRequired = false)]
        public int ConnectionTimeout
        {
            get { return (int)base["ConnectionTimeout"]; }
            set { base["ConnectionTimeout"] = value; }
        }
    }
}

