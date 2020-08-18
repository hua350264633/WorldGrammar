using System;
using System.Data;
using System.Collections.Generic;
using ML.Model;
namespace ML.BLL
{
    /// <summary>
    /// S_Role
    /// </summary>
    public partial class S_Role
    {
        private readonly ML.DAL.S_Role dal = new ML.DAL.S_Role();
        public S_Role()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string RoleCode)
        {
            return dal.Exists(RoleCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ML.Model.S_Role model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ML.Model.S_Role model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string RoleCode)
        {

            return dal.Delete(RoleCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ML.Model.S_Role GetModel(int ID)
        {

            return dal.GetModel(ID);
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
        public List<ML.Model.S_Role> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ML.Model.S_Role> DataTableToList(DataTable dt)
        {
            List<ML.Model.S_Role> modelList = new List<ML.Model.S_Role>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ML.Model.S_Role model;
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
        /// 自动生成角色编码
        /// </summary>
        /// <param name="selfCode">本身编码</param>
        /// <param name="parentCode">父级角色编码</param>
        /// <returns></returns>
        public string GenerateRoleCode(string selfCode, string parentCode)
        {
            return dal.GenerateRoleCode(selfCode, parentCode);
        }

        #endregion  ExtensionMethod
    }
}

