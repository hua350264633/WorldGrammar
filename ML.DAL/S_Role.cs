using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ML.DBHelper;
namespace ML.DAL
{
    /// <summary>
    /// 数据访问类:S_Role
    /// </summary>
    public partial class S_Role
    {
        public S_Role()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string RoleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_Role");
            strSql.Append(" where RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20)         };
            parameters[0].Value = RoleCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ML.Model.S_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_Role(");
            strSql.Append("RoleCode,RoleName,ParentCode,RoleSeq,Description,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@RoleCode,@RoleName,@ParentCode,@RoleSeq,@Description,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20),
                    new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
                    new SqlParameter("@ParentCode", SqlDbType.VarChar,20),
                    new SqlParameter("@RoleSeq", SqlDbType.Int,4),
                    new SqlParameter("@Description", SqlDbType.NVarChar,100),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.RoleCode;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.ParentCode;
            parameters[3].Value = model.RoleSeq;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.CreateUser;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.UpdateUser;
            parameters[8].Value = model.UpdateDate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(ML.Model.S_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_Role set ");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("ParentCode=@ParentCode,");
            strSql.Append("RoleSeq=@RoleSeq,");
            strSql.Append("Description=@Description,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
                    new SqlParameter("@ParentCode", SqlDbType.VarChar,20),
                    new SqlParameter("@RoleSeq", SqlDbType.Int,4),
                    new SqlParameter("@Description", SqlDbType.NVarChar,100),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.ParentCode;
            parameters[2].Value = model.RoleSeq;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.CreateUser;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.UpdateUser;
            parameters[7].Value = model.UpdateDate;
            parameters[8].Value = model.ID;
            parameters[9].Value = model.RoleCode;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_Role ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string RoleCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_Role ");
            strSql.Append(" where RoleCode=@RoleCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleCode", SqlDbType.VarChar,20)         };
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_Role ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public ML.Model.S_Role GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,RoleCode,RoleName,ParentCode,RoleSeq,Description,CreateUser,CreateDate,UpdateUser,UpdateDate from S_Role ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            ML.Model.S_Role model = new ML.Model.S_Role();
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
        public ML.Model.S_Role DataRowToModel(DataRow row)
        {
            ML.Model.S_Role model = new ML.Model.S_Role();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["RoleCode"] != null)
                {
                    model.RoleCode = row["RoleCode"].ToString();
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
                }
                if (row["ParentCode"] != null)
                {
                    model.ParentCode = row["ParentCode"].ToString();
                }
                if (row["RoleSeq"] != null && row["RoleSeq"].ToString() != "")
                {
                    model.RoleSeq = int.Parse(row["RoleSeq"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["CreateUser"] != null)
                {
                    model.CreateUser = row["CreateUser"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["UpdateUser"] != null)
                {
                    model.UpdateUser = row["UpdateUser"].ToString();
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
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
            strSql.Append("select ID,RoleCode,RoleName,ParentCode,RoleSeq,Description,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM S_Role ");
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
            strSql.Append(" ID,RoleCode,RoleName,ParentCode,RoleSeq,Description,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM S_Role ");
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
            strSql.Append("select count(1) FROM S_Role ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from S_Role T ");
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
			parameters[0].Value = "S_Role";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

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
            var sql = $@"select case when max(RoleCode) is null then concat('0',convert(int,'{parentCode}'),1) else concat('0',convert(int,max(RoleCode))+1) end as newRoleCode 
                        from S_Role where RoleCode <> '0999' and ParentCode = '{parentCode}'";
            if (!string.IsNullOrEmpty(selfCode))
            {
                sql += $" and RoleCode <> '{selfCode}'";
            }
            return DbHelperSQL.GetSingle(sql).ToString();
        }

        #endregion  ExtensionMethod
    }
}

