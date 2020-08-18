using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using ML.Common;
using ML.Accounts.Control;
using ML.Accounts;
using System.Web.Security;
using ML.Log4NetHelper;
using System.Security.Principal;
using ML.Model;

namespace WorldGrammar.Ashx
{
    /// <summary>
    /// 用户登录登出处理类
    /// </summary>
    public class Login : ParentAshx,IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 返回的数据对象
        /// </summary>
        DatagridModel<object> dataGridModel = new DatagridModel<object>();
        
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            try
            {
                var typeClass = context.Request["typeClass"];
                switch (typeClass)
                {
                    case "LoginIn":
                        JsonResult = LoginIn(context);
                        break;
                    case "LoginOut":
                        JsonResult = LoginOut(context);
                        break;
                    case "Regist":
                        JsonResult = Regist(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                dataGridModel.Code = CodeEnum.Exception;
                dataGridModel.Msg = ex.Message;
                JsonResult = JsonData.GetResult(dataGridModel);
                //记录到日志
                LogHelper.AddLog(GetType().ToString(), context.Request.UserHostAddress, ex);
            }
            finally
            {
                context.Response.Write(JsonResult);
                context.Response.End();
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="context">数据上下文对象</param>
        /// <returns></returns>
        private string LoginIn(HttpContext context)
        {
            try
            {
                string loginName = context.Request["LoginName"];
                string loginPwd = context.Request["LoginPwd"];
                //非空验证
                if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(loginPwd))
                {
                    dataGridModel.Code = CodeEnum.LoginInfoEmpty;
                    dataGridModel.Msg = "用户名或密码不能为空!";
                    dataGridModel.Data = base.LoginUrl;
                    return JsonData.GetResult(dataGridModel);
                }
                //登录信息验证
                AccountsPrincipal accounts = AccountsPrincipal.ValidateLogin(loginName, loginPwd);
                if (accounts == null)
                {
                    //登录信息不对
                    dataGridModel.Code = CodeEnum.LoginErr;
                    dataGridModel.Msg = "登录失败,请检查用户名与密码!";
                    dataGridModel.Data = base.LoginUrl;
                    return JsonData.GetResult(dataGridModel);
                }
                //保存当前用户对象信息到Session和Cookie中  为：context.User.Identity.Name 赋值
                FormsAuthentication.SetAuthCookie(loginName, false);
                context.Response.SetCookie(new HttpCookie("NickName") { Path = "/", Value = accounts.CurrUser.NickName });
                context.Session["LoginName"] = loginName;
                context.Session["Accounts"] = accounts;

                //记录到日志数据表
                var logObj = new LogModel();
                logObj.LoginName = loginName;
                logObj.LoginIP = context.Request.UserHostAddress;
                logObj.LogContent = "登录成功";
                LogHelper.AddLog(logObj);

                dataGridModel.Code = CodeEnum.Success;
                dataGridModel.Msg = "登录成功!";
                dataGridModel.Data = base.DefaultUrl;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        /// <param name="context">数据上下文对象</param>
        /// <returns></returns>
        public string LoginOut(HttpContext context)
        {
            try
            {
                var Accounts = context.Session["Accounts"];
                if (Accounts == null)
                {
                    dataGridModel.Code = CodeEnum.SessionEmpty;
                    dataGridModel.Msg = "用户会话信息为空，请刷新页面后重试";
                    return JsonData.GetResult(dataGridModel);
                }
                var currentUser = (Accounts as AccountsPrincipal).CurrUser;
                FormsAuthentication.SignOut();  //登出用户
                context.Session["Accounts"] = null;

                //记录到日志数据表
                var logObj = new LogModel();
                logObj.LoginName = currentUser.LoginName;
                logObj.LoginIP = context.Request.UserHostAddress;
                logObj.LogContent = "注销成功";
                LogHelper.AddLog(logObj);

                dataGridModel.Code = CodeEnum.Success;
                dataGridModel.Msg = "注销成功";
                dataGridModel.Data = base.LoginUrl;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        public string Regist(HttpContext context)
        {
            try
            {
                var obj = new S_User();
                var bll = new ML.BLL.S_User();
                obj.LoginName = context.Request["LoginName"];
                obj.LoginPwd = EncryptHelper.DESEncrypt(context.Request["LoginPwd"], Key);
                obj.NickName = context.Request["NickName"];
                obj.Birthday = DateTime.Parse(context.Request["Birthday"]);
                obj.PlaceBirth = context.Request["PlaceBirth"];
                obj.PhoneNumber = context.Request["PhoneNumber"];
                obj.Sex = context.Request["Sex"] == "1" ? true : false;
                obj.CreateUser = SystemUser;
                obj.CreateDate = DateTime.Now;
                obj.UpdateUser = SystemUser;
                obj.UpdateDate = DateTime.Now;
                if (bll.Exists(obj.LoginName))
                {
                    dataGridModel.Msg = string.Format("登录名：{0}，已存在，请使用其他登录名！");
                    dataGridModel.Code = CodeEnum.Error;
                    return JsonData.GetResult(dataGridModel);
                }
                var RegisteSuc = bll.Add(obj);
                if (RegisteSuc)
                {
                    dataGridModel.Msg = "恭喜你，注册成功√";
                    dataGridModel.Code = CodeEnum.Success;
                    dataGridModel.Data = base.LoginUrl;
                }
                else
                {
                    dataGridModel.Msg = "对不起，注册失败×";
                    dataGridModel.Code = CodeEnum.Error;
                }
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}