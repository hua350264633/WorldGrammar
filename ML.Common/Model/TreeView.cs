using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Common.Model
{
    /// <summary>
    /// bootstrap-treeview 树形实体类
    /// </summary>
    public class TreeView
    {
        /// <summary>
        /// 实际的值
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 显示的值
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<TreeView> nodes { get; set; }

        /// <summary>
        /// 节点对应对象
        /// </summary>
        public object tags { get; set; }
    }
}
