using System;
namespace ML.Model
{
    /// <summary>
    /// S_RoleMenu:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class S_RoleMenu
    {
        public S_RoleMenu()
        { }
        #region Model
        private string _rolecode;
        private string _menucode;
        /// <summary>
        /// 角色编号
        /// </summary>
        public string RoleCode
        {
            set { _rolecode = value; }
            get { return _rolecode; }
        }
        /// <summary>
        /// 菜单编号
        /// </summary>
        public string MenuCode
        {
            set { _menucode = value; }
            get { return _menucode; }
        }
        #endregion Model

    }
}

