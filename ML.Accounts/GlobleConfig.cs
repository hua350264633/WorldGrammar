using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace ML.Accounts
{
    /// <summary>
    /// 权限处理的父级
    /// </summary>
    public class GlobleConfig
    {
        /// <summary>
        /// 用户登录密码加密密匙
        /// </summary>
        public const  string Key = "MrLi";

        /// <summary>
        /// 重置默认密码
        /// </summary>
        public const string DefaultPwd = "123456789";

        /// <summary>
        /// 系统名（例如：注册用户时的CreateUser）
        /// </summary>
        public const string SystemUser = "MLSystem"; 

        /// <summary>
        /// 系统登录页
        /// </summary>
        public string LoginUrl = FormsAuthentication.LoginUrl;

        /// <summary>
        /// 主页
        /// </summary>
        public string DefaultUrl = FormsAuthentication.DefaultUrl;        
    }
}
