using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ML.Log4NetHelper
{
    public class LogHelper
    {
        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="exErr">异常</param>
        /// <returns></returns>
        public static void AddLog(string loginName, string loginIP, Exception ex)
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(LogHelper));
            var logObj = new LogModel();
            logObj.LoginName = loginName;
            logObj.LoginIP = loginIP;
            logObj.LogContent = string.Format("异常内容：{0},堆栈信息：{1}", ex.Message, ex.StackTrace);
            log.Info(logObj);
        }

        /// <summary>
        /// 添加日志信息
        /// </summary>
        /// <param name="logObj"></param>
        public static void AddLog(LogModel logObj)
        {
            if (logObj == null)
            {
                return;
            }
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(LogHelper));
            log.Info(logObj);
        }
    }
}
