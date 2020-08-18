using System;
using System.Data;
using System.Collections.Generic;
using ML.Model;
namespace ML.BLL
{
    /// <summary>
    /// S_User
    /// </summary>
    public partial class S_User
    {
        private readonly ML.DAL.S_User dal = new ML.DAL.S_User();
        public S_User()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LoginName)
        {
            return dal.Exists(LoginName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.S_User model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ML.Model.S_User model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string LoginName)
        {

            return dal.Delete(LoginName);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string LoginNamelist)
        {
            return dal.DeleteList(LoginNamelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ML.Model.S_User GetModel(string LoginName)
        {

            return dal.GetModel(LoginName);
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
        public List<ML.Model.S_User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ML.Model.S_User> DataTableToList(DataTable dt)
        {
            List<ML.Model.S_User> modelList = new List<ML.Model.S_User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ML.Model.S_User model;
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
        /// 分页获取数据
        /// </summary>
        /// <param name="CurrentPage">当前页码</param>
        /// <param name="PageSize">每页数据条数</param>
        /// <param name="Where">查询条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="RecordCount">输出参数：总记录数</param>
        /// <returns></returns>
        public List<Model.S_User> GetPageData(int CurrentPage, int PageSize, string Where, string Sort, out int RecordCount)
        {
            List<ML.Model.S_User> list = new List<Model.S_User>();
            var ds = dal.GetPageData(CurrentPage, PageSize, Where, Sort,out RecordCount);
            if (ds != null && ds.Tables.Count > 0)
            {
                list = DataTableToList(ds.Tables[0]);
            }
            return list;
        }

        #endregion  BasicMethod

        #region  ExtensionMethod

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="LoginName">用户登录名</param>
        /// <param name="DESPwd">加密后的密码</param>
        /// <returns></returns>
        public bool ResetPwd(string LoginName,string DESPwd)
        {
            var obj = GetModel(LoginName);
            obj.LoginPwd = DESPwd;
            return Update(obj);
        }
        #endregion  ExtensionMethod
    }
}

