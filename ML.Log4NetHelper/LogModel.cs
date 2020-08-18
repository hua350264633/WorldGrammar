using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ML.Log4NetHelper
{
    /// <summary>
    /// 日志实体类
    /// </summary>
    [Serializable]
    public class LogModel
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 用户登录IP
        /// </summary>
        public string LoginIP { get; set; }
        
        /// <summary>
        /// 用户内容
        /// </summary>
        public string LogContent { get; set; }
        
    }
}
