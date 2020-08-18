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
    /// Role 的摘要说明
    /// </summary>
    public class Role : ParentAshx,IHttpHandler
    {
        DatagridModel<object> dataGridModel = new DatagridModel<object>();
        ML.BLL.S_Role roleBll = new ML.BLL.S_Role();
        ML.BLL.S_RoleMenu rolemenuBll = new ML.BLL.S_RoleMenu();
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
                        case "SaveRole":
                            JsonResult = SaveRole();
                            break;
                        case "SaveRoleMenu":
                            JsonResult = SaveRoleMenu();
                            break;
                        case "GetRoleMenu":
                            JsonResult = GetRoleMenu();
                            break;
                        case "SaveRoleUser":
                            JsonResult = SaveRoleUser();
                            break;
                        case "GetRoleUser":
                            JsonResult = GetRoleUser();
                            break; 
                        case "DelRole":
                            JsonResult = DelRole();
                            break;
                        case "GetTreeRole":
                            JsonResult = GetTreeRole();
                            break;
                        case "GenerateRoleCode":
                            JsonResult = GenerateRoleCode();
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
        /// 保存角色
        /// </summary>
        /// <returns></returns>
        public string SaveRole()
        {
            try
            {
                var id = 0;
                int.TryParse(context.Request["ID"], out id);
                S_Role obj = new S_Role();
                if (id != 0)
                {
                    obj = roleBll.GetModel(id);
                }
                obj.ID = id;
                obj.RoleCode = context.Request["RoleCode"];
                obj.RoleName = context.Request["RoleName"];
                obj.ParentCode = context.Request["ParentCode"];
                obj.RoleSeq = int.Parse(context.Request["RoleSeq"]);
                obj.Description = context.Request["Description"];
                if (obj.ID == 0)
                {
                    obj.CreateUser = context.Session["LoginName"].ToString();
                    obj.CreateDate = DateTime.Now;
                    obj.UpdateUser = context.Session["LoginName"].ToString();
                    obj.UpdateDate = DateTime.Now;
                    roleBll.Add(obj);
                }
                else
                {
                    obj.UpdateUser = context.Session["LoginName"].ToString();
                    obj.UpdateDate = DateTime.Now;
                    roleBll.Update(obj);
                }

                dataGridModel.Msg = "保存成功!";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存角色菜单
        /// </summary>
        /// <returns></returns>
        public string SaveRoleMenu()
        {
            try
            {
                var RoleCode = context.Request["RoleCode"];
                var MenuCodes = context.Request["MenuCodes"].Split(',').Where(o=> !string.IsNullOrEmpty(o)).ToArray();
                rolemenuBll.SaveRoleMenu(RoleCode, MenuCodes);
                dataGridModel.Msg = "角色菜单保存成功!";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取角色菜单
        /// </summary>
        /// <returns></returns>
        public string GetRoleMenu()
        {
            try
            {
                var RoleCode = context.Request["RoleCode"];
                var data = rolemenuBll.GetModelList(string.Format(" RoleCode = {0}", RoleCode));
                dataGridModel.Msg = "获取角色菜单成功!";
                dataGridModel.Code = CodeEnum.Success;
                dataGridModel.Data = data;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存角色菜单
        /// </summary>
        /// <returns></returns>
        public string SaveRoleUser()
        {
            try
            {
                var RoleCode = context.Request["RoleCode"];
                var LoginNames = context.Request["LoginNames"].Split(',').Where(o => !string.IsNullOrEmpty(o)).ToArray();
                userRoleBll.SaveRoleUser(RoleCode, LoginNames);
                dataGridModel.Msg = "角色用户保存成功!";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取角色用户
        /// </summary>
        /// <returns></returns>
        public string GetRoleUser()
        {
            try
            {
                var RoleCode = context.Request["RoleCode"];
                var data = userRoleBll.GetModelList(string.Format(" RoleCode = {0}", RoleCode));
                dataGridModel.Msg = "获取角色用户成功!";
                dataGridModel.Code = CodeEnum.Success;
                dataGridModel.Data = data;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <returns></returns>
        public string DelRole()
        {
            try
            {
                var roleCode = context.Request["RoleCode"];
                roleBll.Delete(roleCode);

                var userRole = userRoleBll.GetModelList(string.Format(" RoleCode = '{0}'", roleCode));
                if (userRole.Count > 0)
                {
                    dataGridModel.Msg = "角色关联了用户，请先删除用户关联角色再删除用户";
                    dataGridModel.Code = CodeEnum.Error;
                    return JsonData.GetResult(dataGridModel);
                }

                dataGridModel.Msg = "删除成功!";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 其他操作


        /// <summary>
        /// 获取所有角色树形Json（如果需要顶级角色，参数中包含haveTop=1即可）
        /// </summary>
        public string GetTreeRole()
        {
            try
            {
                var allRole = roleBll.GetModelList("");
                var listData = new List<TreeView>();
                var haveTop = context.Request["haveTop"];
                if (haveTop == "1")
                {
                    var top = new TreeView();
                    top.id = "0";
                    top.text = "顶级角色";
                    listData.Add(top);
                }
                var rootList = allRole.Where(o => o.ParentCode == "0");
                foreach (var item in rootList)
                {
                    var root = new TreeView();
                    root.id = item.RoleCode;
                    root.text = item.RoleName;
                    root.tags = item;
                    DGNode(allRole, item, root);
                    listData.Add(root);
                }

                dataGridModel.Code = CodeEnum.Success;
                dataGridModel.Data = JsonData.GetResult(listData);
                return JsonData.GetResult(dataGridModel);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 生成角色编号
        /// </summary>
        /// <returns></returns>
        public string GenerateRoleCode()
        {
            try
            {
                var selfCode = context.Request["SelfCode"];  //本身编号
                var parentRoleCode = context.Request["ParentRoleCode"];  //父级角色编号
                if (string.IsNullOrEmpty(parentRoleCode))
                {
                    dataGridModel.Code = CodeEnum.Error;
                    dataGridModel.Msg = "参数ParentRoleCode为空";
                    return JsonData.GetResult(dataGridModel);
                }

                dataGridModel.Code = CodeEnum.Success;
                dataGridModel.Data = roleBll.GenerateRoleCode(selfCode, parentRoleCode);
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 递归处理数据
        /// </summary>
        /// <param name="all">角色原始数据</param>
        /// <param name="node">要递归的起始节点</param>
        /// <param name="root">根节点</param>
        public void DGNode(List<S_Role> all, S_Role node, TreeView root)
        {
            var childs = all.Where(o => o.ParentCode == node.RoleCode).ToList();
            if (childs.Count > 0)
            {
                root.nodes = new List<TreeView>();
            }
            foreach (var item in childs)
            {
                var temp = new TreeView();
                temp.id = item.RoleCode;
                temp.text = item.RoleName;
                temp.tags = item;
                root.nodes.Add(temp);
                DGNode(all, item, temp);
            }
        }

        #endregion

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
