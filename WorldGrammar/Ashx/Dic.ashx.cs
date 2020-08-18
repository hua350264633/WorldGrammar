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
    /// Dic 的摘要说明
    /// </summary>
    public class Dic : ParentAshx,IHttpHandler
    {
        DatagridModel<S_Dictionary> dataGridModel = new DatagridModel<S_Dictionary>();
        ML.BLL.S_Dictionary dicBll = new ML.BLL.S_Dictionary();
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                //验证字典是否登录
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
                        case "GetTreeDic":
                            JsonResult = GetTreeDic();
                            break;
                        case "AddDic":
                            JsonResult = AddDic();
                            break;
                        case "EditDic":
                            JsonResult = EditDic();
                            break;
                        case "DelDic":
                            JsonResult = DelDic();
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
        /// 加载字典列表
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
                var Rows = dicBll.GetPageData(PageIndex, PageSize, where, null, out RecordCount);
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
        /// 获取所有菜单树形Json（如果需要顶级菜单，参数中包含haveTop=1即可）
        /// </summary>
        public string GetTreeDic()
        {
            try
            {
                var allDic = dicBll.GetModelList("");
                var listData = new List<TreeView>();
                var haveTop = context.Request["haveTop"];
                if (haveTop == "1")
                {
                    var top = new TreeView();
                    top.id = "0";
                    top.text = "顶级菜单";
                    listData.Add(top);
                }
                var rootList = allDic.Where(o => o.PID == "0");
                foreach (var item in rootList)
                {
                    var root = new TreeView();
                    root.id = item.ID;
                    root.text = item.DicKey;
                    root.tags = item;
                    DGNode(allDic, item, root);
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
        /// 递归处理数据
        /// </summary>
        /// <param name="all">菜单原始数据</param>
        /// <param name="node">要递归的起始节点</param>
        /// <param name="root">根节点</param>
        public void DGNode(List<S_Dictionary> all, S_Dictionary node, TreeView root)
        {
            var childs = all.Where(o => o.PID == node.ID).ToList();
            if (childs.Count > 0)
            {
                root.nodes = new List<TreeView>();
            }
            foreach (var item in childs)
            {
                var temp = new TreeView();
                root.id = item.ID;
                root.text = item.DicKey;
                temp.tags = item;
                root.nodes.Add(temp);
                DGNode(all, item, temp);
            }
        }

        /// <summary>
        /// 新增字典
        /// </summary>
        /// <returns></returns>
        public string AddDic()
        {
            try
            {
                ////获取对象
                //var LoginName = context.Request["LoginName"];
                //var obj = dicBll.GetModel(LoginName);
                //obj.NickName = context.Request["NickName"];
                //obj.Sex = bool.Parse(context.Request["Sex"]);
                //obj.Birthday = DateTime.Parse(context.Request["Birthday"]);
                //obj.PlaceBirth = context.Request["PlaceBirth"];
                //obj.PhoneNumber = context.Request["PhoneNumber"];
                //obj.IsEnabled = bool.Parse(context.Request["IsEnabled"]);  

                //obj.UpdateDic = context.Session["LoginName"].ToString();
                //obj.UpdateDate = DateTime.Now;
                //dicBll.Update(obj);

                //dataGridModel.Msg = "修改成功!";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改字典
        /// </summary>
        /// <returns></returns>
        public string EditDic()
        {
            try
            {
                ////获取对象
                //var LoginName = context.Request["LoginName"];
                //var obj = dicBll.GetModel(LoginName);
                //obj.NickName = context.Request["NickName"];
                //obj.Sex = bool.Parse(context.Request["Sex"]);
                //obj.Birthday = DateTime.Parse(context.Request["Birthday"]);
                //obj.PlaceBirth = context.Request["PlaceBirth"];
                //obj.PhoneNumber = context.Request["PhoneNumber"];
                //obj.IsEnabled = bool.Parse(context.Request["IsEnabled"]);  
                              
                //obj.UpdateDic = context.Session["LoginName"].ToString();
                //obj.UpdateDate = DateTime.Now;
                //dicBll.Update(obj);

                //dataGridModel.Msg = "修改成功!";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除字典
        /// </summary>
        /// <returns></returns>
        public string DelDic()
        {
            try
            {
                //var LoginName = context.Request["LoginName"];
                //if (LoginName.Equals("admin"))
                //{
                //    dataGridModel.Msg = "不能删除管理员";
                //    dataGridModel.Code = CodeEnum.Error;
                //    return JsonData.GetResult(dataGridModel);
                //}

                //var userRole = userRoleBll.GetModelList(string.Format(" LoginName = '{0}'",LoginName));
                //if (userRole.Count > 0)
                //{
                //    dataGridModel.Msg = "字典关联了角色，请先删除字典关联角色再删除字典";
                //    dataGridModel.Code = CodeEnum.Error;
                //    return JsonData.GetResult(dataGridModel);
                //}
                //dicBll.Delete(LoginName);
                dataGridModel.Msg = "删除成功!";
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
