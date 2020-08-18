using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ML.DBHelper;
namespace ML.DAL
{
    /// <summary>
    /// 数据访问类:Grammar
    /// </summary>
    public partial class Grammar
    {
        public Grammar()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Grammar");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50)           };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.Grammar model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Grammar(");
            strSql.Append("ID,TypeID,Title,Descript,Content,IsClassical,DemoFile,Tags,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@TypeID,@Title,@Descript,@Content,@IsClassical,@DemoFile,@Tags,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50),
                    new SqlParameter("@TypeID", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@Descript", SqlDbType.NVarChar,500),
                    new SqlParameter("@Content", SqlDbType.VarChar,-1),
                    new SqlParameter("@IsClassical", SqlDbType.Bit,1),
                    new SqlParameter("@DemoFile", SqlDbType.VarChar,100),
                    new SqlParameter("@Tags", SqlDbType.VarChar,200),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.TypeID;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Descript;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.IsClassical;
            parameters[6].Value = model.DemoFile;
            parameters[7].Value = model.Tags;
            parameters[8].Value = model.CreateUser;
            parameters[9].Value = model.CreateDate;
            parameters[10].Value = model.UpdateUser;
            parameters[11].Value = model.UpdateDate;

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
        public bool Update(ML.Model.Grammar model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Grammar set ");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("Title=@Title,");
            strSql.Append("Descript=@Descript,");
            strSql.Append("Content=@Content,");
            strSql.Append("IsClassical=@IsClassical,");
            strSql.Append("DemoFile=@DemoFile,");
            strSql.Append("Tags=@Tags,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@TypeID", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@Descript", SqlDbType.NVarChar,500),
                    new SqlParameter("@Content", SqlDbType.VarChar,-1),
                    new SqlParameter("@IsClassical", SqlDbType.Bit,1),
                    new SqlParameter("@DemoFile", SqlDbType.VarChar,100),
                    new SqlParameter("@Tags", SqlDbType.VarChar,200),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.TypeID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Descript;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.IsClassical;
            parameters[5].Value = model.DemoFile;
            parameters[6].Value = model.Tags;
            parameters[7].Value = model.CreateUser;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.UpdateUser;
            parameters[10].Value = model.UpdateDate;
            parameters[11].Value = model.ID;

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
            strSql.Append("delete from Grammar ");
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
            strSql.Append("delete from Grammar ");
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
        public ML.Model.Grammar GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,TypeID,Title,Descript,Content,IsClassical,DemoFile,Tags,CreateUser,CreateDate,UpdateUser,UpdateDate from Grammar ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50)           };
            parameters[0].Value = ID;

            ML.Model.Grammar model = new ML.Model.Grammar();
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
        public ML.Model.Grammar DataRowToModel(DataRow row)
        {
            ML.Model.Grammar model = new ML.Model.Grammar();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["TypeID"] != null)
                {
                    model.TypeID = row["TypeID"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Descript"] != null)
                {
                    model.Descript = row["Descript"].ToString();
                }
                if (row.Table.Columns.Contains("Content"))
                {
                    if (row["Content"] != null)
                    {
                        model.Content = row["Content"].ToString();
                    }
                }
                
                if (row["IsClassical"] != null && row["IsClassical"].ToString() != "")
                {
                    if ((row["IsClassical"].ToString() == "1") || (row["IsClassical"].ToString().ToLower() == "true"))
                    {
                        model.IsClassical = true;
                    }
                    else
                    {
                        model.IsClassical = false;
                    }
                }
                if (row["DemoFile"] != null)
                {
                    model.DemoFile = row["DemoFile"].ToString();
                }
                if (row["Tags"] != null)
                {
                    model.Tags = row["Tags"].ToString();
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
            strSql.Append("select ID,TypeID,Title,Descript,Content,IsClassical,DemoFile,Tags,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM Grammar ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by TypeID,CreateDate ");
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
            strSql.Append(" ID,TypeID,Title,Descript,Content,IsClassical,DemoFile,Tags,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM Grammar ");
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
            strSql.Append("select count(1) FROM Grammar ");
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
            strSql.Append(")AS Row, T.*  from Grammar T ");
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
			parameters[0].Value = "Grammar";
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
        /// 分页获取数据
        /// </summary>
        /// <param name="CurrentPage">当前页码</param>
        /// <param name="PageSize">每页数据条数</param>
        /// <param name="Where">查询条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="RecordCount">输出参数：总记录数</param>
        /// <returns></returns>
        public DataSet GetPageData(int CurrentPage, int PageSize, string Where, string Sort, out int RecordCount)
        {
            RecordCount = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@TableName", SqlDbType.VarChar, 1000),   //表名,多表是请使用 tA a inner join tB b On a.AID = b.AID
                    new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 100),   //主键，可以带表头 a.AID
                    new SqlParameter("@Fields", SqlDbType.VarChar, 2000),      //读取字段默认为*
					new SqlParameter("@Condition", SqlDbType.VarChar,3000),    //Where条件（不用加where关键字）
					new SqlParameter("@CurrentPage", SqlDbType.Int),           //开始页码
					new SqlParameter("@PageSize", SqlDbType.Int),              //页大小
					new SqlParameter("@Sort", SqlDbType.Bit),                  //排序字段
                    new SqlParameter("@RecordCount", SqlDbType.Int) { Direction=ParameterDirection.Output }  //总记录数（输出参数，需单独获取）
					};
            parameters[0].Value = "Grammar";
            parameters[1].Value = "ID";
            parameters[2].Value = "ID,TypeID,Title,Descript,IsClassical,DemoFile,Tags,CreateUser,CreateDate,UpdateUser,UpdateDate";
            parameters[3].Value = Where;
            parameters[4].Value = CurrentPage;
            parameters[5].Value = PageSize;
            parameters[6].Value = Sort;
            var ds = DbHelperSQL.RunProcedure("S_GetPageData", parameters, "SearchResult");
            RecordCount = Convert.ToInt32(parameters[7].Value);
            return ds;
        }

        #endregion  ExtensionMethod
    }
}

