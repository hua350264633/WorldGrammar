using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Common
{
    /// <summary>
    /// 动态表头实体类
    /// </summary>
    [Serializable]
   public class trendColumns
    {
        public trendColumns()
        { }
        private string _title;
        private string _field;
        private int _width=80;
        private string _formatter;
        private string _align = "center";

        /// <summary>
        /// 对齐方式
        /// </summary>     
        public string align
        {
            get { return _align; }
            set { _align = value; }
        }
        
        /// <summary>
        /// 格式化字符串匿名函数
        /// </summary>      
        public string formatter
        {
            get { return _formatter; }
            set { _formatter = value; }
        }
        
        /// <summary>
        /// 宽度
        /// </summary>
        public int width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// 字段名
        /// </summary>
        public string field
        {
            get { return _field; }
            set { _field = value; }
        } 
        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        private bool _hidden;
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        
        
    }
}
