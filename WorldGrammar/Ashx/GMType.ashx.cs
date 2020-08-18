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
    /// GMType 的摘要说明
    /// </summary>
    public class GMType : ParentAshx,IHttpHandler
    {
        DatagridModel<object> dataGridModel = new DatagridModel<object>();
        ML.BLL.GrammarType gmBll = new ML.BLL.GrammarType();
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
                        case "SaveGMType":
                            JsonResult = SaveGMType();
                            break;
                        case "DelGMType":
                            JsonResult = DelGMType();
                            break;
                        case "GetTreeGMType":
                            JsonResult = GetTreeGMType();
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
        /// 保存语法类型
        /// </summary>
        /// <returns></returns>
        public string SaveGMType()
        {
            try
            {
                var id = context.Request["ID"];
                GrammarType obj;
                if (string.IsNullOrEmpty(id))
                {
                    obj = new GrammarType();
                    obj.ID = Guid.NewGuid().ToString();
                    obj.LoginName = context.Session["LoginName"].ToString();
                    obj.CreateUser = context.Session["LoginName"].ToString();
                    obj.CreateDate = DateTime.Now;
                    obj.UpdateUser = context.Session["LoginName"].ToString();
                    obj.UpdateDate = DateTime.Now;
                }
                else
                {
                    obj = gmBll.GetModel(id);
                    obj.UpdateUser = context.Session["LoginName"].ToString();
                    obj.UpdateDate = DateTime.Now;
                }
                obj.ParentID = context.Request["ParentID"];
                obj.TypeName = context.Request["TypeName"];
                obj.Remark = context.Request["Remark"];
                obj.Seq = int.Parse(context.Request["Seq"]);
                if (string.IsNullOrEmpty(id))
                {
                    gmBll.Add(obj);
                }
                else
                {
                    gmBll.Update(obj);
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
        /// 删除语法类型
        /// </summary>
        /// <returns></returns>
        public string DelGMType()
        {
            try
            {
                var ID = context.Request["ID"];
                gmBll.Delete(ID);

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
        /// 获取所有语法类型树形Json（如果需要顶级语法类型，参数中包含haveTop=1即可）
        /// </summary>
        public string GetTreeGMType()
        {
            try
            {
                var allGMType = gmBll.GetModelList("");
                var listData = new List<TreeView>();
                var haveTop = context.Request["haveTop"];
                if (haveTop == "1")
                {
                    var top = new TreeView();
                    top.id = "0";
                    top.text = "顶级语法类型";
                    listData.Add(top);
                }
                var rootList = allGMType.Where(o => o.ParentID == "0");
                foreach (var item in rootList)
                {
                    var root = new TreeView();
                    root.id = item.ID;
                    root.text = item.TypeName;
                    root.tags = item;
                    DGNode(allGMType, item, root);
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
        /// <param name="all">语法类型原始数据</param>
        /// <param name="node">要递归的起始节点</param>
        /// <param name="root">根节点</param>
        public void DGNode(List<GrammarType> all, GrammarType node, TreeView root)
        {
            var childs = all.Where(o => o.ParentID == node.ID).ToList();
            if (childs.Count > 0)
            {
                root.nodes = new List<TreeView>();
            }
            foreach (var item in childs)
            {
                var temp = new TreeView();
                temp.id = item.ID;
                temp.text = item.TypeName;
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
