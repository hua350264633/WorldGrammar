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
    /// Menu 的摘要说明
    /// </summary>
    public class Menu : ParentAshx,IHttpHandler
    {
        DatagridModel<object> dataGridModel = new DatagridModel<object>();
        ML.BLL.S_Menu menuBll = new ML.BLL.S_Menu();
        ML.BLL.S_RoleMenu roleMenuBll = new ML.BLL.S_RoleMenu();
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
                        case "SaveMenu":
                            JsonResult = SaveMenu();
                            break;
                        case "DelMenu":
                            JsonResult = DelMenu();
                            break;
                        case "GetTreeMenu":
                            JsonResult = GetTreeMenu();
                            break;
                        case "GenerateMenuCode":
                            JsonResult = GenerateMenuCode();
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
        /// 保存菜单
        /// </summary>
        /// <returns></returns>
        public string SaveMenu()
        {
            try
            {
                var id = 0;
                int.TryParse(context.Request["ID"], out id);
                S_Menu obj = new S_Menu();
                if (id != 0)
                {
                    obj = menuBll.GetModel(id);
                }
                obj.ID = id;
                obj.MenuCode = context.Request["MenuCode"];
                obj.MenuName = context.Request["MenuName"];
                obj.ParentCode = context.Request["ParentCode"];
                obj.MenuSeq = int.Parse(context.Request["MenuSeq"]);
                obj.MenuIcon = context.Request["MenuIcon"];
                obj.URL = context.Request["URL"];
                obj.IsEnable = context.Request["IsEnable"] == "on" ? true : false;
                if (obj.ID == 0)
                {
                    obj.CreateUser = context.Session["LoginName"].ToString();
                    obj.CreateDate = DateTime.Now;
                    obj.UpdateUser = context.Session["LoginName"].ToString();
                    obj.UpdateDate = DateTime.Now;
                    menuBll.Add(obj);
                }
                else
                {
                    obj.UpdateUser = context.Session["LoginName"].ToString();
                    obj.UpdateDate = DateTime.Now;
                    menuBll.Update(obj);
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
        /// 删除菜单
        /// </summary>
        /// <returns></returns>
        public string DelMenu()
        {
            try
            {
                var menuCode = context.Request["MenuCode"];

                var roleMenu = roleMenuBll.GetModelList(string.Format(" MenuCode = '{0}'", menuCode));
                if (roleMenu.Count > 0)
                {
                    dataGridModel.Msg = "菜单关联了角色，请先删除菜单关联角色再删除菜单";
                    dataGridModel.Code = CodeEnum.Error;
                    return JsonData.GetResult(dataGridModel);
                }

                menuBll.Delete(menuCode);
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
        /// 获取所有菜单树形Json（如果需要顶级菜单，参数中包含haveTop=1即可）
        /// </summary>
        public string GetTreeMenu()
        {
            try
            {
                var allMenu = menuBll.GetModelList("");
                var listData = new List<TreeView>();
                var haveTop = context.Request["haveTop"];
                if (haveTop == "1")
                {
                    var top = new TreeView();
                    top.id = "0";
                    top.text = "顶级菜单";
                    listData.Add(top);
                }
                var rootList = allMenu.Where(o => o.ParentCode == "0");
                foreach (var item in rootList)
                {
                    var root = new TreeView();
                    root.id = item.MenuCode;
                    root.text = item.MenuName;
                    root.tags = item;
                    DGNode(allMenu, item, root);
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
        /// 生成菜单编号
        /// </summary>
        /// <returns></returns>
        public string GenerateMenuCode()
        {
            try
            {
                var selfCode = context.Request["SelfCode"];  //本身编号
                var parentMenuCode = context.Request["ParentMenuCode"];  //父级菜单编号
                if (string.IsNullOrEmpty(parentMenuCode))
                {
                    dataGridModel.Code = CodeEnum.Error;
                    dataGridModel.Msg = "参数ParentMenuCode为空";
                    return JsonData.GetResult(dataGridModel);
                }

                dataGridModel.Code = CodeEnum.Success;
                dataGridModel.Data = menuBll.GenerateMenuCode(selfCode, parentMenuCode);
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
        /// <param name="all">菜单原始数据</param>
        /// <param name="node">要递归的起始节点</param>
        /// <param name="root">根节点</param>
        public void DGNode(List<S_Menu> all, S_Menu node, TreeView root)
        {
            var childs = all.Where(o => o.ParentCode == node.MenuCode).ToList();
            if (childs.Count > 0)
            {
                root.nodes = new List<TreeView>();
            }
            foreach (var item in childs)
            {
                var temp = new TreeView();
                temp.id = item.MenuCode;
                temp.text = item.MenuName;
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
