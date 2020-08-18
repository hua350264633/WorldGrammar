using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Common
{
    [Serializable]
    public partial class DatagridModel<T>
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total
        {
            get; set;
        }

        /// <summary>
        /// 行数据列表
        /// </summary>
        public List<T> Rows
        {
            get; set;
        }

        /// <summary>
        /// 状态编码枚举
        /// </summary>
        public CodeEnum Code
        {
            get; set;
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg
        {
            get;set;
        }   

        /// <summary>
        /// 数据
        /// </summary>
        public object Data
        {
            get;set;
        }
    }
}
