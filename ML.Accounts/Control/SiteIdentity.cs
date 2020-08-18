using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ML.Common;
using System.Security.Principal;

namespace ML.Accounts.Control
{
    /// <summary>
    /// 当前用户的标识对象
    /// </summary>
    [Serializable]
    public class SiteIdentity : GlobleConfig, IIdentity
    {
        #region 用户字段
        
        private string _nikeName;
        private string _loginName;

        #endregion

        #region  用户属性

        /// <summary>
        /// 登录名
        /// </summary>
        public string Name
        {
            get
            {
                return _loginName;
            }
        }

        /// <summary>
        /// 用户登录名
        /// </summary>
        public string NickName
        {
            get
            {
                return _nikeName;
            }
        }
        
        #endregion
        

        /// <summary>
        /// 获取所使用的身份验证的类型（用户自定义）。
        /// </summary>
        public string AuthenticationType
        {
            get
            {
                return "Custom Authentication";
            }
            set
            {
                // do nothing
            }
        }

        /// <summary>
        /// 如果标识对象的用户属性不为空则表示已经过验证
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                if (!string.IsNullOrEmpty(_nikeName) && !string.IsNullOrEmpty(_loginName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        /// <summary>
        /// 根据用户ID构造
        /// </summary>
        public SiteIdentity(DataRow userRow)
        {
            if (userRow != null)
            {
                _nikeName = (string)userRow["NickName"];
                _loginName = (string)userRow["LoginName"];
            }
        }
        ///// <summary>
        ///// 检查当前用户名和密码
        ///// </summary>
        ///// <param name="password">加密前的密码</param>
        ///// <returns></returns>
        //public int TestPassword(string password)
        //{
        //   string cryptPassword = EncryptHelper.DESEncrypt(password, Key);
        //   return dataUser.ValidateUser(_loginName, cryptPassword);
        //}

        ///// <summary>
        ///// 检查传递过来的用户和密码
        ///// </summary>
        ///// <param name="loginName">用户登录名</param>
        ///// <param name="password">加密前的密码</param>
        ///// <returns></returns>
        //public int TestPassword(string loginName, string password)
        //{
        //    string cryptPassword = EncryptHelper.DESEncrypt(password, Key);
        //    return dataUser.ValidateUser(loginName, cryptPassword);
        //}
    }
}
