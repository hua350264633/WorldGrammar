using ML.Accounts;
using ML.Common;
using ML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ML.Common.Model;

namespace WorldGrammar.Ashx
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class User : ParentAshx,IHttpHandler
    {
        DatagridModel<S_User> dataGridModel = new DatagridModel<S_User>();
        ML.BLL.S_User userBll = new ML.BLL.S_User();
        ML.BLL.S_UserRole userRoleBll = new ML.BLL.S_UserRole();
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                //验证用户是否登录
                if (!IsLogin())
                {
                    var dataGridModel = new DatagridModel<object>();
                    dataGridModel.Msg = "登录超时,请重新登录";
                    dataGridModel.Code = CodeEnum.LoginOutTime;
                    dataGridModel.Data = base.LoginUrl;
                    JsonResult = JsonData.GetResult(dataGridModel);
                }
                else
                {
                    switch (typeClass)
                    {
                        case "GetPageData":
                            JsonResult = GetPageData();
                            break;
                        case "EditUser":
                            JsonResult = EditUser();
                            break;
                        case "DelUser":
                            JsonResult = DelUser();
                            break;
                        case "ResetPwd":
                            JsonResult = ResetPwd();
                            break;
                        case "ChangePwd":
                            JsonResult = ChangePwd();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                dataGridModel.Msg = ex.Message;
                dataGridModel.Code = CodeEnum.Exception;
                JsonResult = JsonData.GetResult(dataGridModel);
            }
            context.Response.Write(JsonResult);
            context.Response.End();
        }
        
        /// <summary>
        /// 加载用户列表
        /// </summary>
        /// <returns></returns>
        public string GetPageData()
        {
            try
            {
                var P_CurrentPage = context.Request["CurrentPage"];
                var P_PageSize = context.Request["PageSize"];
                var where = context.Request["Where"];
                #region 处理分页

                var PageIndex = 0;
                var PageSize = 0;
                if (string.IsNullOrEmpty(P_CurrentPage))
                {
                    PageIndex = 1;
                }
                else
                {
                    int.TryParse(P_CurrentPage, out PageIndex);
                }
                if (string.IsNullOrEmpty(P_PageSize))
                {
                    PageSize = 30;
                }
                else
                {
                    int.TryParse(P_PageSize, out PageSize);
                }

                #endregion
                var RecordCount = 0;
                var Rows = userBll.GetPageData(PageIndex, PageSize, where, null, out RecordCount);
                dataGridModel.Rows = Rows;
                dataGridModel.Total = RecordCount;
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public string EditUser()
        {
            try
            {
                //获取对象
                var LoginName = context.Request["LoginName"];
                var obj = userBll.GetModel(LoginName);
                obj.NickName = context.Request["NickName"];
                obj.Sex = bool.Parse(context.Request["Sex"]);
                obj.Birthday = DateTime.Parse(context.Request["Birthday"]);
                obj.PlaceBirth = context.Request["PlaceBirth"];
                obj.PhoneNumber = context.Request["PhoneNumber"];
                obj.IsEnabled = bool.Parse(context.Request["IsEnabled"]);  
                              
                obj.UpdateUser = context.Session["LoginName"].ToString();
                obj.UpdateDate = DateTime.Now;
                userBll.Update(obj);

                dataGridModel.Msg = "修改成功!";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public string DelUser()
        {
            try
            {
                var LoginName = context.Request["LoginName"];
                if (LoginName.Equals("admin"))
                {
                    dataGridModel.Msg = "不能删除管理员";
                    dataGridModel.Code = CodeEnum.Error;
                    return JsonData.GetResult(dataGridModel);
                }

                var userRole = userRoleBll.GetModelList(string.Format(" LoginName = '{0}'",LoginName));
                if (userRole.Count > 0)
                {
                    dataGridModel.Msg = "用户关联了角色，请先删除用户关联角色再删除用户";
                    dataGridModel.Code = CodeEnum.Error;
                    return JsonData.GetResult(dataGridModel);
                }
                userBll.Delete(LoginName);
                dataGridModel.Msg = "删除成功!";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public string ResetPwd()
        {
            try
            {
                var LoginName = context.Request["LoginName"];
                var DESPwd = EncryptHelper.DESEncrypt(DefaultPwd, Key);
                if (userBll.ResetPwd(LoginName, DESPwd))
                {
                    dataGridModel.Msg = string.Format("登录名：{0} 密码重置成功！默认密码为：{1}", LoginName, DefaultPwd);
                }
                else
                {
                    dataGridModel.Msg = string.Format("登录名：{0} 密码重置失败",LoginName);
                }
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ChangePwd()
        {
            try
            {
                var LoginName = context.Session["LoginName"].ToString();
                var LoginPwd = context.Request["LoginPwd"];
                if (string.IsNullOrEmpty(LoginPwd))
                {
                    throw new ArgumentNullException("LoginPwd为空，请验证后重试");
                }
                var DESPwd = EncryptHelper.DESEncrypt(LoginPwd, Key);
                if (userBll.ResetPwd(LoginName, DESPwd))
                {
                    dataGridModel.Msg = string.Format("登录名：{0} 密码修改成功！新密码为：{1}", LoginName, LoginPwd);
                }
                else
                {
                    dataGridModel.Msg = string.Format("登录名：{0} 密码修改失败", LoginName);
                }
                dataGridModel.Code = CodeEnum.Success;
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
