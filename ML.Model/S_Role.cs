using System;
namespace ML.Model
{
    /// <summary>
    /// S_Role:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class S_Role
    {
        public S_Role()
        { }
        #region Model
        private int _id;
        private string _rolecode;
        private string _rolename;
        private string _parentcode;
        private int _roleseq;
        private string _description;
        private string _createuser;
        private DateTime _createdate = DateTime.Now;
        private string _updateuser;
        private DateTime _updatedate;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 角色编号
        /// </summary>
        public string RoleCode
        {
            set { _rolecode = value; }
            get { return _rolecode; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 父级角色编号
        /// </summary>
        public string ParentCode
        {
            set { _parentcode = value; }
            get { return _parentcode; }
        }
        /// <summary>
        /// 角色顺序
        /// </summary>
        public int RoleSeq
        {
            set { _roleseq = value; }
            get { return _roleseq; }
        }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        #endregion Model

    }
}

