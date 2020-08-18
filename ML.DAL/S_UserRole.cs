using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ML.DBHelper;
namespace ML.DAL
{
    /// <summary>
    /// 数据访问类:S_UserRole
    /// </summary>
    public partial class S_UserRole
    {
        public S_UserRole()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LoginName, string RoleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_UserRole");
            strSql.Append(" where LoginName=@LoginName and RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20),
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20)         };
            parameters[0].Value = LoginName;
            parameters[1].Value = RoleCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.S_UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_UserRole(");
            strSql.Append("LoginName,RoleCode)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@RoleCode)");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20),
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.RoleCode;

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
        /// <param name="LoginNames">用户登录名集合</param>
        /// <returns></returns>
        public bool AddModes(string RoleCode, string[] LoginNames)
        {
            if (LoginNames.Length == 0)
            {
                return false;
            }
            StringBuilder strSql = new StringBuilder();
            foreach (var item in LoginNames)
            {
                strSql.Append("insert into S_UserRole(");
                strSql.Append("LoginName,RoleCode)");
                strSql.Append(" values ('");
                strSql.Append(item);
                strSql.Append("','");
                strSql.Append(RoleCode);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(ML.Model.S_UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_UserRole set ");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("RoleCode=@RoleCode");
            strSql.Append(" where LoginName=@LoginName and RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20),
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.RoleCode;

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
        /// 根据角色编码删除
        /// </summary>
        /// <param name="RoleCode">角色编码</param>
        /// <returns></returns>
        public bool DeleteByRole(string RoleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_UserRole ");
            strSql.Append(" where RoleCode=@RoleCode ");
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
        /// 根据用户登录名删除
        /// </summary>
        /// <param name="LoginName">用户登录名</param>
        /// <returns></returns>
        public bool DeleteByLoginName(string LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_UserRole ");
            strSql.Append(" where LoginName=@LoginName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20)};
            parameters[0].Value = LoginName;

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
        public ML.Model.S_UserRole GetModel(string LoginName, string RoleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LoginName,RoleCode from S_UserRole ");
            strSql.Append(" where LoginName=@LoginName and RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20),
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20)         };
            parameters[0].Value = LoginName;
            parameters[1].Value = RoleCode;

            ML.Model.S_UserRole model = new ML.Model.S_UserRole();
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
        public ML.Model.S_UserRole DataRowToModel(DataRow row)
        {
            ML.Model.S_UserRole model = new ML.Model.S_UserRole();
            if (row != null)
            {
                if (row["LoginName"] != null)
                {
                    model.LoginName = row["LoginName"].ToString();
                }
                if (row["RoleCode"] != null)
                {
                    model.RoleCode = row["RoleCode"].ToString();
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
            strSql.Append("select LoginName,RoleCode ");
            strSql.Append(" FROM S_UserRole ");
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
            strSql.Append(" LoginName,RoleCode ");
            strSql.Append(" FROM S_UserRole ");
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
            strSql.Append("select count(1) FROM S_UserRole ");
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
                strSql.Append("order by T.RoleCode desc");
            }
            strSql.Append(")AS Row, T.*  from S_UserRole T ");
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
			parameters[0].Value = "S_UserRole";
			parameters[1].Value = "RoleCode";
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

