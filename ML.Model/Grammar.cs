using System;
namespace ML.Model
{
    /// <summary>
    /// Grammar:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Grammar
    {
        public Grammar()
        { }
        #region Model
        private string _id;
        private string _typeid = "0";
        private string _title;
        private string _descript;
        private string _content;
        private bool _isclassical = false;
        private string _demofile;
        private string _tags;
        private string _createuser;
        private DateTime _createdate;
        private string _updateuser;
        private DateTime _updatedate;
        /// <summary>
        /// GUID
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// GrammarType表中的ID
        /// </summary>
        public string TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 语法标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 语法功能描述
        /// </summary>
        public string Descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 语法内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 是否是经典语法
        /// </summary>
        public bool IsClassical
        {
            set { _isclassical = value; }
            get { return _isclassical; }
        }
        /// <summary>
        /// 例子文件
        /// </summary>
        public string DemoFile
        {
            set { _demofile = value; }
            get { return _demofile; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Tags
        {
            get { return _tags; }
            set { _tags = value; }
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
        /// 创建时间
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
        /// 修改时间
        /// </summary>
        public DateTime UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        #endregion Model

    }
}

