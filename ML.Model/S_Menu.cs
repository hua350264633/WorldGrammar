using System;
namespace ML.Model
{
    /// <summary>
    /// S_Menu:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class S_Menu
    {
        public S_Menu()
        { }
        #region Model
        private int _id;
        private string _menucode;
        private string _menuname;
        private string _parentcode;
        private int _menuseq;
        private string _menuicon;
        private string _url;
        private bool _isenable = true;
        private string _createuser;
        private DateTime _createdate;
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
        /// 菜单编号
        /// </summary>
        public string MenuCode
        {
            set { _menucode = value; }
            get { return _menucode; }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName
        {
            set { _menuname = value; }
            get { return _menuname; }
        }
        /// <summary>
        /// 父级编号
        /// </summary>
        public string ParentCode
        {
            set { _parentcode = value; }
            get { return _parentcode; }
        }
        /// <summary>
        /// 菜单排序码（同一父级）
        /// </summary>
        public int MenuSeq
        {
            set { _menuseq = value; }
            get { return _menuseq; }
        }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string MenuIcon
        {
            set { _menuicon = value; }
            get { return _menuicon; }
        }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string URL
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 是否启用（默认为1）
        /// </summary>
        public bool IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        #endregion Model

    }
}

