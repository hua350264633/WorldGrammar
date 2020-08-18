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
    /// GM 的摘要说明
    /// </summary>
    public class GM : ParentAshx,IHttpHandler
    {
        DatagridModel<Grammar> dataGridModel = new DatagridModel<Grammar>();
        ML.BLL.Grammar gmBll = new ML.BLL.Grammar();
        ML.BLL.GrammarType gmTypeBll = new ML.BLL.GrammarType();

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
                        case "SaveGM":
                            JsonResult = SaveGM();
                            break;
                        case "DelGM":
                            JsonResult = DelGM();
                            break;
                        case "GetTreeGM":
                            JsonResult = GetTreeGM();
                            break;
                        case "GetGMById":
                            JsonResult = GetGMById();
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
                var Rows = gmBll.GetPageData(PageIndex, PageSize, where, null, out RecordCount);
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
        /// 保存语法
        /// </summary>
        /// <returns></returns>
        public string SaveGM()
        {
            try
            {
                var id = context.Request["ID"];
                Grammar obj;
                if (string.IsNullOrEmpty(id))
                {
                    obj = new Grammar();
                    obj.ID = Guid.NewGuid().ToString();
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
                obj.TypeID = context.Request["TypeID"];
                obj.Title = context.Request["Title"];
                obj.Descript = context.Request["Descript"];
                obj.Content = context.Request["ContentHTML"];
                obj.IsClassical = context.Request["IsClassical"] == "on" ? true : false;
                obj.DemoFile = context.Request["DemoFile"];
                obj.Tags = context.Request["Tags"];
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
        /// 删除语法
        /// </summary>
        /// <returns></returns>
        public string DelGM()
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

        /// <summary>
        /// 根据ID获取语法详情
        /// </summary>
        /// <returns></returns>
        public string GetGMById()
        {
            try
            {
                var ID = context.Request["ID"];
                if (string.IsNullOrEmpty(ID))
                {
                    dataGridModel.Code = CodeEnum.Error;
                    dataGridModel.Msg = "语法ID不能为空";
                    return JsonData.GetResult(dataGridModel);
                }
                var obj = gmBll.GetModel(ID);
                if (obj == null)
                {
                    dataGridModel.Code = CodeEnum.Error;
                    dataGridModel.Msg = string.Format("语法ID【{0}】不正确，未查询到任何数据", ID);
                    return JsonData.GetResult(dataGridModel);
                }
                dataGridModel.Data = obj;
                dataGridModel.Msg = "获取成功!";
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
        /// 获取所有语法树形Json（如果需要顶级语法，参数中包含haveTop=1即可）
        /// </summary>
        public string GetTreeGM()
        {
            try
            {
                var allGMType = gmTypeBll.GetModelList(string.Format(" LoginName = '{0}'", context.Session["LoginName"].ToString()));  //筛选出用户的语法类型
                //var allGM = gmBll.GetModelList(string.Format(" TypeID in('{0}')",string.Join("','",allGMType.Select(o => o.ID).ToArray())));  //根据语法类型筛选相关语法
                var listData = new List<TreeView>();
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
        /// <param name="all">语法原始数据</param>
        /// <param name="node">要递归的起始节点</param>
        /// <param name="root">根节点</param>
        public void DGNode(List<GrammarType> allGMType,GrammarType node, TreeView root)
        {
            var childs = allGMType.Where(o => o.ParentID == node.ID).ToList();            
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
                DGNode(allGMType, item, temp);
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
