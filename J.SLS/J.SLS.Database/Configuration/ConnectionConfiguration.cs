using System.Configuration;
using System.Collections.Generic;
using J.SLS.Database.DBAccess;
using System.Collections;
using System.Data.SqlClient;
using System;

namespace J.SLS.Database.Configuration
{
    /// <summary>
    /// 一个连接配置基类，包含最基本的连接配置属性
    /// </summary>
    public abstract class ConnectionConfiguration : ConfigurationSection
    {
        /// <summary>
        /// 获取默认配置节点的数据库连接对象配置，DefaultConnection
        /// </summary>
        /// <returns>返回数据库连接配置对象。如果不存在此节点，则返回null</returns>
        public static ConnectionConfiguration GetConfiguration()
        {
            return GetConfiguration("DefaultConnection");
        }

        /// <summary>
        /// 获取指定名称的配置节点的数据库连接对象配置
        /// </summary>
        /// <param name="configName">指定配置节点名称</param>
        /// <returns>返回数据库连接配置对象。如果不存在此节点，则返回null</returns>
        public static ConnectionConfiguration GetConfiguration(string configName)
        {
            ConnectionConfiguration config = (ConnectionConfiguration)ConfigurationManager.GetSection(configName);
            return config;
        }

        [ThreadStatic]
        private static ILHDBAccess _dbAccess;
        /// <summary>
        /// 获取数据库访问对象，线程单例
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
        /// 获取数据库事务访问对象
        /// </summary>
        public ILHDBTran BeginTran()
        {
            ILHDBTran _dbTran = LHDBFactory.BeginTransaction(DatabaseType, ConnectionString);
            _dbTran.ConnectionTimeout = this.ConnectionTimeout;
            _dbTran.CommandTimeout = this.CommandTimeout;
            return _dbTran;
        }

        /// <summary>
        /// 获取数据库类型
        /// </summary>
        public abstract RDatabaseType DatabaseType { get; }

        /// <summary>
        /// 获取完整数据库连接字符串
        /// </summary>
        public abstract string ConnectionString { get; }

        /// <summary>
        /// 执行超时时间
        /// </summary>
        [ConfigurationProperty("CommandTimeout", DefaultValue = 60, IsKey = false, IsRequired = false)]
        public int CommandTimeout
        {
            get { return (int)base["CommandTimeout"]; }
            set { base["CommandTimeout"] = value; }
        }

        /// <summary>
        /// 连接超时时间
        /// </summary>
        [ConfigurationProperty("ConnectionTimeout", DefaultValue = 60, IsKey = false, IsRequired = false)]
        public int ConnectionTimeout
        {
            get { return (int)base["ConnectionTimeout"]; }
            set { base["ConnectionTimeout"] = value; }
        }
    }
}

