using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ML.DBHelper;
namespace ML.DAL
{
    /// <summary>
    /// 数据访问类:S_Dictionary
    /// </summary>
    public partial class S_Dictionary
    {
        public S_Dictionary()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_Dictionary");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50)           };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.S_Dictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_Dictionary(");
            strSql.Append("ID,PID,DicType,DicKey,DicValue,Remark,Seq)");
            strSql.Append(" values (");
            strSql.Append("@ID,@PID,@DicType,@DicKey,@DicValue,@Remark,@Seq)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50),
                    new SqlParameter("@PID", SqlDbType.VarChar,50),
                    new SqlParameter("@DicType", SqlDbType.NVarChar,50),
                    new SqlParameter("@DicKey", SqlDbType.NVarChar,50),
                    new SqlParameter("@DicValue", SqlDbType.NVarChar,50),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@Seq", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PID;
            parameters[2].Value = model.DicType;
            parameters[3].Value = model.DicKey;
            parameters[4].Value = model.DicValue;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.Seq;

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
        public bool Update(ML.Model.S_Dictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_Dictionary set ");
            strSql.Append("PID=@PID,");
            strSql.Append("DicType=@DicType,");
            strSql.Append("DicKey=@DicKey,");
            strSql.Append("DicValue=@DicValue,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Seq=@Seq");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@PID", SqlDbType.VarChar,50),
                    new SqlParameter("@DicType", SqlDbType.NVarChar,50),
                    new SqlParameter("@DicKey", SqlDbType.NVarChar,50),
                    new SqlParameter("@DicValue", SqlDbType.NVarChar,50),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@Seq", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PID;
            parameters[1].Value = model.DicType;
            parameters[2].Value = model.DicKey;
            parameters[3].Value = model.DicValue;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.Seq;
            parameters[6].Value = model.ID;

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
            strSql.Append("delete from S_Dictionary ");
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
            strSql.Append("delete from S_Dictionary ");
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
        public ML.Model.S_Dictionary GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PID,DicType,DicKey,DicValue,Remark,Seq from S_Dictionary ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50)           };
            parameters[0].Value = ID;

            ML.Model.S_Dictionary model = new ML.Model.S_Dictionary();
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
        public ML.Model.S_Dictionary DataRowToModel(DataRow row)
        {
            ML.Model.S_Dictionary model = new ML.Model.S_Dictionary();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["PID"] != null)
                {
                    model.PID = row["PID"].ToString();
                }
                if (row["DicType"] != null)
                {
                    model.DicType = row["DicType"].ToString();
                }
                if (row["DicKey"] != null)
                {
                    model.DicKey = row["DicKey"].ToString();
                }
                if (row["DicValue"] != null)
                {
                    model.DicValue = row["DicValue"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Seq"] != null && row["Seq"].ToString() != "")
                {
                    model.Seq = int.Parse(row["Seq"].ToString());
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
            strSql.Append("select ID,PID,DicType,DicKey,DicValue,Remark,Seq ");
            strSql.Append(" FROM S_Dictionary ");
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
            strSql.Append(" ID,PID,DicType,DicKey,DicValue,Remark,Seq ");
            strSql.Append(" FROM S_Dictionary ");
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
            strSql.Append("select count(1) FROM S_Dictionary ");
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
            strSql.Append(")AS Row, T.*  from S_Dictionary T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "S_Dictionary";
            parameters[1].Value = "ID";
            parameters[2].Value = "*";
            parameters[3].Value = Where;
            parameters[4].Value = CurrentPage;
            parameters[5].Value = PageSize;
            parameters[6].Value = Sort;
            var ds = DbHelperSQL.RunProcedure("S_GetPageData", parameters, "SearchResult");
            RecordCount = Convert.ToInt32(parameters[7].Value);
            return ds;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

