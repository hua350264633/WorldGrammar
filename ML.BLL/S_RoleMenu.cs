using System;
using System.Data;
using System.Collections.Generic;
using ML.Model;
namespace ML.BLL
{
    /// <summary>
    /// S_RoleMenu
    /// </summary>
    public partial class S_RoleMenu
    {
        private readonly ML.DAL.S_RoleMenu dal = new ML.DAL.S_RoleMenu();
        public S_RoleMenu()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string RoleCode, string MenuCode)
        {
            return dal.Exists(RoleCode, MenuCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.S_RoleMenu model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除角色对应记录
        /// </summary>
        /// <param name="RoleCode">角色编码</param>
        /// <returns></returns>
        public bool DeleteByRoleCode(string RoleCode)
        {
            return dal.DeleteByRoleCode(RoleCode);
        }

        /// <summary>
        /// 删除菜单对应记录
        /// </summary>
        /// <param name="MenuCode">菜单编码</param>
        /// <returns></returns>
        public bool DeleteByMenuCode(string MenuCode)
        {
            return dal.DeleteByMenuCode(MenuCode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ML.Model.S_RoleMenu GetModel(string RoleCode, string MenuCode)
        {

            return dal.GetModel(RoleCode, MenuCode);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ML.Model.S_RoleMenu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ML.Model.S_RoleMenu> DataTableToList(DataTable dt)
        {
            List<ML.Model.S_RoleMenu> modelList = new List<ML.Model.S_RoleMenu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ML.Model.S_RoleMenu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 保存角色对应菜单
        /// </summary>
        /// <param name="RoleCode">角色编码</param>
        /// <param name="MenuCodes">菜单编码集合</param>
        public void SaveRoleMenu(string RoleCode, string[] MenuCodes)
        {
            //删除角色原有记录
            DeleteByRoleCode(RoleCode);
            dal.AddModes(RoleCode, MenuCodes);
        }
        
        #endregion  ExtensionMethod
    }
}

