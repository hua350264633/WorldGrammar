using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ML.DBHelper;
using ML.Model;

namespace ML.Accounts
{
    /// <summary>
    /// 用户实体类
    /// </summary>  
    [Serializable]
    public partial class User
    {
        #region 字段
        
        private DataRow _userRow;
        private List<Strings> _roleList;
        private string _loginName;
        private string _nickName;

        #endregion

        #region   属性

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string  NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }
        
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        
        /// <summary>
        /// 用户角色
        /// </summary>
        public List<Strings> UserRoles
        {
            get { return _roleList; }
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        public DataRow UserRow
        {
            get { return _userRow; }
        }

        #endregion

        /// <summary>
        /// 无参构造
        /// </summary>
        public User() { }

        /// <summary>
        /// 使用登录名构造用户
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        public User(string loginName)
        {
            SqlParameter[] parameters = { new SqlParameter("@LoginName", SqlDbType.VarChar, 20) };
            parameters[0].Value = loginName;
            //获取用户相关信息
            DataSet ds = DbHelperSQL.RunProcedure("S_GetUserInfo", parameters, "ds");
            _userRow = GetUser(ds);
            _roleList = GetUserRoles(ds);
            if (_userRow != null)
            {
                _loginName = (string)_userRow["LoginName"];
                _nickName = (string)_userRow["NickName"];
            }
        }

        /// <summary>
        /// 验证用户名和密码是否匹配
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="encPassword">加密后的密码</param>
        /// <returns>返回为1表示验证通过</returns>
        public int ValidateUser(string loginName, string encPassword)
        {
            int rowsAffected;
            SqlParameter[] parameters ={
                       new SqlParameter("@LoginName", SqlDbType.VarChar, 20),
                        new SqlParameter("@EncryptedPassword", SqlDbType.VarChar, 100)
            };
            parameters[0].Value = loginName;
            parameters[1].Value = encPassword;
            var ReturnValue = DbHelperSQL.RunProcedure("S_ValidateUser", parameters, out rowsAffected);
            return ReturnValue;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="encPassword">加密后新密码</param>
        /// <returns></returns>
        public bool EditPwd(string loginName, string encPassword)
        {
            string strsql = "update [S_User] set LoginPwd=@EncryptedPassword where LoginName=@LoginName";
            SqlParameter[] parameters ={
		               new SqlParameter("@LoginName", SqlDbType.VarChar, 20),
	 	               new SqlParameter("@EncryptedPassword", SqlDbType.VarChar, 100)
	                     };
            parameters[0].Value = loginName;
            parameters[1].Value = encPassword;
            int row = DbHelperSQL.ExecuteSql(strsql, parameters);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                      
        }

        #region   得到用户信息

        /// <summary>
        /// 获取用户的信息
        /// </summary>
        /// <returns></returns>
        private DataRow GetUser(DataSet ds)
        {
            DataRow dr = null;
            if (ds != null && ds.Tables.Count == 2)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                }
            }
            return dr;
        }

        #endregion

        #region 得到用户的角色信息

        /// <summary>
        /// 获取用户的角色信息
        /// </summary>
        private List<Strings> GetUserRoles(DataSet ds)
        {
            List<Strings> list = new List<Strings>();
            try
            {
                if (ds != null && ds.Tables.Count == 2)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        Strings tmp = new Strings();
                        if (dr["RoleCode"] != null)
                        {
                            tmp.ID = dr["RoleCode"].ToString();
                        }
                        if (dr["RoleName"] != null)
                        {
                            tmp.Name = dr["RoleName"].ToString();
                        }
                        list.Add(tmp);
                    }

                }
            }
            catch
            {
            }
            return list;
        }

        #endregion

        #region 得到用户菜单信息

        /// <summary>
        /// 根据角色ID集合获取菜单信息
        /// </summary>
        /// <param name="roleStrs">角色ID集合（示例：roleid1,roleid2,....）</param>
        /// <returns></returns>
        public List<S_Menu> GetEffectiveMenuList(string roleStrs)
        {
            List<S_Menu> list = new List<S_Menu>();
            SqlParameter[] parameters = { new SqlParameter("@RoleStrs", SqlDbType.VarChar, 200) };
            parameters[0].Value = roleStrs;

            DataSet ds = DbHelperSQL.RunProcedure("S_GetRolesMenu", parameters, "ds");
            if (ds != null && ds.Tables.Count > 0)
            {
                list = Common.Common.DT2EntityList<S_Menu>(ds.Tables[0]);
            }
            return list;
        }

        #endregion
        
    }

    [Serializable]
    public partial class Strings 
    {
        public Strings() { }

        private string _id;
        private string _name;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
