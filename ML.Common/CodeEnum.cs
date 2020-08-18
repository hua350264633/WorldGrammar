using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Common
{
    /// <summary>
    /// 系统所有编码枚举类
    /// </summary>
    public enum CodeEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 200,
        
        /// <summary>
        /// 异常
        /// </summary>
        Exception = 201,

        /// <summary>
        /// 错误
        /// </summary>
        Error = 202,

        /// <summary>
        /// 登录用户名或密码为空
        /// </summary>
        LoginInfoEmpty = 301,

        /// <summary>
        /// 登录失败
        /// </summary>
        LoginErr = 302,

        /// <summary>
        /// 会话信息为空
        /// </summary>
        SessionEmpty = 303,

        /// <summary>
        /// 登录超时
        /// </summary>
        LoginOutTime = 400
    }
}
