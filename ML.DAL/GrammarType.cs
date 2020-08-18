using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ML.DBHelper;
namespace ML.DAL
{
    /// <summary>
    /// 数据访问类:GrammarType
    /// </summary>
    public partial class GrammarType
    {
        public GrammarType()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from GrammarType");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50)           };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.GrammarType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GrammarType(");
            strSql.Append("ID,ParentID,TypeName,Remark,Seq,LoginName,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@ParentID,@TypeName,@Remark,@Seq,@LoginName,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50),
                    new SqlParameter("@ParentID", SqlDbType.VarChar,50),
                    new SqlParameter("@TypeName", SqlDbType.NVarChar,20),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@Seq", SqlDbType.Int,4),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.TypeName;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.Seq;
            parameters[5].Value = model.LoginName;
            parameters[6].Value = model.CreateUser;
            parameters[7].Value = model.CreateDate;
            parameters[8].Value = model.UpdateUser;
            parameters[9].Value = model.UpdateDate;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(ML.Model.GrammarType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GrammarType set ");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("TypeName=@TypeName,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Seq=@Seq,");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ParentID", SqlDbType.VarChar,50),
                    new SqlParameter("@TypeName", SqlDbType.NVarChar,20),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@Seq", SqlDbType.Int,4),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.Seq;
            parameters[4].Value = model.LoginName;
            parameters[5].Value = model.CreateUser;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.UpdateUser;
            parameters[8].Value = model.UpdateDate;
            parameters[9].Value = model.ID;

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
        public bool Delete(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GrammarType ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50)           };
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GrammarType ");
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
        public ML.Model.GrammarType GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParentID,TypeName,Remark,Seq,LoginName,CreateUser,CreateDate,UpdateUser,UpdateDate from GrammarType ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50)           };
            parameters[0].Value = ID;

            ML.Model.GrammarType model = new ML.Model.GrammarType();
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
        public ML.Model.GrammarType DataRowToModel(DataRow row)
        {
            ML.Model.GrammarType model = new ML.Model.GrammarType();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["ParentID"] != null)
                {
                    model.ParentID = row["ParentID"].ToString();
                }
                if (row["TypeName"] != null)
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Seq"] != null && row["Seq"].ToString() != "")
                {
                    model.Seq = int.Parse(row["Seq"].ToString());
                }
                if (row["LoginName"] != null)
                {
                    model.LoginName = row["LoginName"].ToString();
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
            strSql.Append("select ID,ParentID,TypeName,Remark,Seq,LoginName,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM GrammarType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ParentID,Seq");
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
            strSql.Append(" ID,ParentID,TypeName,Remark,Seq,LoginName,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM GrammarType ");
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
            strSql.Append("select count(1) FROM GrammarType ");
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
            strSql.Append(")AS Row, T.*  from GrammarType T ");
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
			parameters[0].Value = "GrammarType";
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

        #endregion  ExtensionMethod
    }
}

