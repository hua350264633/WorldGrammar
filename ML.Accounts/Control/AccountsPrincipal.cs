using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ML.Model;
using System.Security.Principal;
using ML.Common;

namespace ML.Accounts.Control
{
    /// <summary>
    /// 用户对象的安全上下文信息
    /// </summary>
    public class AccountsPrincipal : GlobleConfig,IPrincipal
    {
        #region 字段

        private List<S_Menu> _menuList;
        private List<Strings> _roleList;
        private IIdentity identity;
        private User _currUser;

        #endregion

        #region 属性
        
        /// <summary>
        /// 当前用户的所有角色
        /// </summary>
        public List<Strings> Roles
        {
            get
            {
                return _roleList;
            }
        }

        /// <summary>
        /// 当前用户拥有的菜单列表
        /// </summary>
        public List<S_Menu> MenuList
        {
            get
            {
                return _menuList;
            }
        }
        
        /// <summary>
        /// 当前用户的标识对象
        /// </summary>
        public IIdentity Identity
        {
            get
            {
                return identity;
            }
            set
            {
                identity = value;
            }
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public User CurrUser
        {
            get
            {
                return _currUser;
            }
        }

        #endregion

        /// <summary>
        /// 根据用户登录名构造上下文对象
        /// </summary>
        /// <param name="LoginName">用户登录名</param>
        public AccountsPrincipal(string LoginName)
        {
            _currUser = new User(LoginName);
            identity = new SiteIdentity(_currUser.UserRow);
            //用户角色
            _roleList = _currUser.UserRoles;
            StringBuilder sb = new StringBuilder();
            foreach (Strings model in _roleList)
            {
                sb.Append(",");
                sb.Append(model.ID);
            }
            if (sb.Length > 0)
            {
                string roles = sb.Remove(0, 1).ToString();
                //菜单列表
                _menuList = _currUser.GetEffectiveMenuList(roles);
            }
        }
        
        /// <summary>
        /// 验证用户名和密码是否匹配并创建数据上下文对象
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="password">加密前的密码</param>
        /// <returns></returns>
        public static AccountsPrincipal ValidateLogin(string loginName, string password)
        {
            string cryptPassword = EncryptHelper.DESEncrypt(password, Key);
            var dalUser = new User();
            if ((dalUser.ValidateUser(loginName, cryptPassword)) == 1)
                return new AccountsPrincipal(loginName);
            else
                return null;
        }

        /// <summary>
        /// 当前用户是否拥有指定角色ID的角色
        /// </summary>
        /// <param name="roleCode">角色编码</param>
        /// <returns></returns>
        public bool IsInRole(string roleCode)
        {
            bool Exist = false;
            foreach (Strings model in _roleList)
            {
                if (model.ID == roleCode)
                {
                    Exist = true;
                    break;
                }
            }
            return Exist;
        }
    }
}
