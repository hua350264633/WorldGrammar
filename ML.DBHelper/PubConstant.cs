using System;

using System.Configuration;

namespace ML.DBHelper
{
    /// <summary>
    /// 获取数据库连接字符串类
    /// </summary>
    public class PubConstant
    {
        private static string _connectionString = string.Empty;
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                _connectionString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
                return _connectionString;
            }
        }
    }
}
