using ML.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Model
{
    /// <summary>
    /// 文件上传时返回的实体对象
    /// </summary>
    public class FileUpLoadEntity
    {        
        /// <summary>
        /// 文件存放位置
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 文件名称（带后缀）
        /// </summary>
        public string FileName { get; set; }
    }
}
