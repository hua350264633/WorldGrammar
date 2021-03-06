﻿using System;
using System.Data;
using System.Collections.Generic;
using ML.Model;
namespace ML.BLL
{
    /// <summary>
    /// S_UserRole
    /// </summary>
    public partial class S_UserRole
    {
        private readonly ML.DAL.S_UserRole dal = new ML.DAL.S_UserRole();
        public S_UserRole()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LoginName, string RoleCode)
        {
            return dal.Exists(LoginName, RoleCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.S_UserRole model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ML.Model.S_UserRole model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 根据角色编码删除
        /// </summary>
        /// <param name="RoleCode">角色编码</param>
        /// <returns></returns>
        public bool DeleteByRole(string RoleCode)
        {
            return dal.DeleteByRole(RoleCode);
        }

        /// <summary>
        /// 根据用户登录名删除
        /// </summary>
        /// <param name="LoginName">用户登录名</param>
        /// <returns></returns>
        public bool DeleteByLoginName(string LoginName)
        {
            return dal.DeleteByLoginName(LoginName);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ML.Model.S_UserRole GetModel(string LoginName, string RoleCode)
        {

            return dal.GetModel(LoginName, RoleCode);
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
        public List<ML.Model.S_UserRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ML.Model.S_UserRole> DataTableToList(DataTable dt)
        {
            List<ML.Model.S_UserRole> modelList = new List<ML.Model.S_UserRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ML.Model.S_UserRole model;
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
        /// 分页获取数据列表
        /// <param name="RoleCode">角色编码</param>
        /// <param name="LoginNames">用户登录名集合</param>
        /// </summary>
        public void SaveRoleUser(string RoleCode,string[] LoginNames)
        {
            dal.DeleteByRole(RoleCode);
            dal.AddModes(RoleCode,LoginNames);
        }

        #endregion  ExtensionMethod
    }
}

