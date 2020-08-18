using System;
using System.Data;
using System.Collections.Generic;
using ML.Model;
namespace ML.BLL
{
    /// <summary>
    /// S_Dictionary
    /// </summary>
    public partial class S_Dictionary
    {
        private readonly ML.DAL.S_Dictionary dal = new ML.DAL.S_Dictionary();
        public S_Dictionary()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.S_Dictionary model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ML.Model.S_Dictionary model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {

            return dal.Delete(ID);
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
        public ML.Model.S_Dictionary GetModel(string ID)
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
        public List<ML.Model.S_Dictionary> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ML.Model.S_Dictionary> DataTableToList(DataTable dt)
        {
            List<ML.Model.S_Dictionary> modelList = new List<ML.Model.S_Dictionary>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ML.Model.S_Dictionary model;
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
        public List<Model.S_Dictionary> GetPageData(int CurrentPage, int PageSize, string Where, string Sort, out int RecordCount)
        {
            List<ML.Model.S_Dictionary> list = new List<Model.S_Dictionary>();
            var ds = dal.GetPageData(CurrentPage, PageSize, Where, Sort, out RecordCount);
            if (ds != null && ds.Tables.Count > 0)
            {
                list = DataTableToList(ds.Tables[0]);
            }
            return list;
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

