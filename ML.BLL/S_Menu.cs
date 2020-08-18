﻿using System;
using System.Data;
using System.Collections.Generic;
using ML.Model;
namespace ML.BLL
{
    /// <summary>
    /// S_Menu
    /// </summary>
    public partial class S_Menu
    {
        private readonly ML.DAL.S_Menu dal = new ML.DAL.S_Menu();
        public S_Menu()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string MenuCode)
        {
            return dal.Exists(MenuCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ML.Model.S_Menu model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ML.Model.S_Menu model)
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
        public bool Delete(string MenuCode)
        {

            return dal.Delete(MenuCode);
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
        public ML.Model.S_Menu GetModel(int ID)
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
        public List<ML.Model.S_Menu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ML.Model.S_Menu> DataTableToList(DataTable dt)
        {
            List<ML.Model.S_Menu> modelList = new List<ML.Model.S_Menu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ML.Model.S_Menu model;
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
        /// 自动生成菜单编码
        /// </summary>
        /// <param name="selfCode">本身编码</param>
        /// <param name="parentCode">父级菜单编码</param>
        /// <returns></returns>
        public string GenerateMenuCode(string selfCode, string parentCode)
        {
            return dal.GenerateMenuCode(selfCode, parentCode);
        }

        #endregion  ExtensionMethod
    }
}

