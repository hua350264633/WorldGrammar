using System;
namespace ML.Model
{
    /// <summary>
    /// S_Dictionary:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class S_Dictionary
    {
        public S_Dictionary()
        { }
        #region Model
        private string _id;
        private string _pid;
        private string _dictype;
        private string _dickey;
        private string _dicvalue;
        private string _remark;
        private int? _seq;

        /// <summary>
        /// 主键GUID
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 父级ID（顶级菜单，用0表示）
        /// </summary>
        public string PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 字典类型
        /// </summary>
        public string DicType
        {
            set { _dictype = value; }
            get { return _dictype; }
        }
        /// <summary>
        /// 字典键
        /// </summary>
        public string DicKey
        {
            set { _dickey = value; }
            get { return _dickey; }
        }
        /// <summary>
        /// 字典值
        /// </summary>
        public string DicValue
        {
            set { _dicvalue = value; }
            get { return _dicvalue; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? Seq
        {
            set { _seq = value; }
            get { return _seq; }
        }
        #endregion Model

    }
}

