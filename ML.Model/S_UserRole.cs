using System;
namespace ML.Model
{
    /// <summary>
    /// S_UserRole:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class S_UserRole
    {
        public S_UserRole()
        { }
        #region Model
        private string _loginname;
        private string _rolecode;
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleCode
        {
            set { _rolecode = value; }
            get { return _rolecode; }
        }
        #endregion Model

    }
}

