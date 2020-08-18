using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ML.DBHelper;

namespace ML.DAL
{
    /// <summary>
    /// 数据访问类:S_RoleMenu
    /// </summary>
    public partial class S_RoleMenu
    {
        public S_RoleMenu()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string RoleCode, string MenuCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_RoleMenu");
            strSql.Append(" where RoleCode=@RoleCode and MenuCode=@MenuCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20),
                    new SqlParameter("@MenuCode", SqlDbType.VarChar,20)         };
            parameters[0].Value = RoleCode;
            parameters[1].Value = MenuCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.S_RoleMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_RoleMenu(");
            strSql.Append("RoleCode,MenuCode)");
            strSql.Append(" values (");
            strSql.Append("@RoleCode,@MenuCode)");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20),
                    new SqlParameter("@MenuCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.RoleCode;
            parameters[1].Value = model.MenuCode;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 增加多条记录
        /// </summary>
        /// <param name="RoleCode">角色编码</param>
        /// <param name="MenuCodes">菜单编码集合</param>
        /// <returns></returns>
        public bool AddModes(string RoleCode, string[] MenuCodes)
        {
            if (MenuCodes.Length == 0)
            {
                return false;
            }
            StringBuilder strSql = new StringBuilder();
            foreach (var item in MenuCodes)
            {
                strSql.Append("insert into S_RoleMenu(");
                strSql.Append("RoleCode,MenuCode)");
                strSql.Append(" values ('");
                strSql.Append(RoleCode);
                strSql.Append("','");
                strSql.Append(item);
                strSql.Append("');");
            }
            
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除角色对应记录
        /// </summary>
        /// <param name="RoleCode">角色编码</param>
        /// <returns></returns>
        public bool DeleteByRoleCode(string RoleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_RoleMenu ");
            strSql.Append(" where RoleCode=@RoleCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20)};
            parameters[0].Value = RoleCode;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除菜单对应记录
        /// </summary>
        /// <param name="MenuCode">菜单编码</param>
        /// <returns></returns>
        public bool DeleteByMenuCode(string MenuCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_RoleMenu ");
            strSql.Append(" where MenuCode=@MenuCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuCode", SqlDbType.VarChar,20)};
            parameters[0].Value = MenuCode;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ML.Model.S_RoleMenu GetModel(string RoleCode, string MenuCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleCode,MenuCode from S_RoleMenu ");
            strSql.Append(" where RoleCode=@RoleCode and MenuCode=@MenuCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20),
                    new SqlParameter("@MenuCode", SqlDbType.VarChar,20)         };
            parameters[0].Value = RoleCode;
            parameters[1].Value = MenuCode;

            ML.Model.S_RoleMenu model = new ML.Model.S_RoleMenu();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ML.Model.S_RoleMenu DataRowToModel(DataRow row)
        {
            ML.Model.S_RoleMenu model = new ML.Model.S_RoleMenu();
            if (row != null)
            {
                if (row["RoleCode"] != null)
                {
                    model.RoleCode = row["RoleCode"].ToString();
                }
                if (row["MenuCode"] != null)
                {
                    model.MenuCode = row["MenuCode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleCode,MenuCode ");
            strSql.Append(" FROM S_RoleMenu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" RoleCode,MenuCode ");
            strSql.Append(" FROM S_RoleMenu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM S_RoleMenu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.MenuCode desc");
            }
            strSql.Append(")AS Row, T.*  from S_RoleMenu T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "S_RoleMenu";
			parameters[1].Value = "MenuCode";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
            
        #endregion  ExtensionMethod
    }
}

