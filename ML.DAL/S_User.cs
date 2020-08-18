using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ML.DBHelper;
using System.Collections.Generic;

namespace ML.DAL
{
    /// <summary>
    /// 数据访问类:S_User
    /// </summary>
    public partial class S_User
    {
        public S_User()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_User");
            strSql.Append(" where LoginName=@LoginName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20)            };
            parameters[0].Value = LoginName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ML.Model.S_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_User(");
            strSql.Append("LoginName,LoginPwd,NickName,Sex,Birthday,PlaceBirth,PhoneNumber,IsEnabled,CreateDate,CreateUser,UpdateDate,UpdateUser)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@LoginPwd,@NickName,@Sex,@Birthday,@PlaceBirth,@PhoneNumber,@IsEnabled,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser)");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20),
                    new SqlParameter("@LoginPwd", SqlDbType.VarChar,100),
                    new SqlParameter("@NickName", SqlDbType.NVarChar,10),
                    new SqlParameter("@Sex", SqlDbType.Bit,1),
                    new SqlParameter("@Birthday", SqlDbType.Date,3),
                    new SqlParameter("@PlaceBirth", SqlDbType.NVarChar,50),
                    new SqlParameter("@PhoneNumber", SqlDbType.Char,11),
                    new SqlParameter("@IsEnabled", SqlDbType.Bit,1),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.LoginPwd;
            parameters[2].Value = model.NickName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.PlaceBirth;
            parameters[6].Value = model.PhoneNumber;
            parameters[7].Value = model.IsEnabled;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.CreateUser;
            parameters[10].Value = model.UpdateDate;
            parameters[11].Value = model.UpdateUser;

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
        public bool Update(ML.Model.S_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_User set ");
            strSql.Append("LoginPwd=@LoginPwd,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("PlaceBirth=@PlaceBirth,");
            strSql.Append("PhoneNumber=@PhoneNumber,");
            strSql.Append("IsEnabled=@IsEnabled,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("UpdateDate=@UpdateDate,");
            strSql.Append("UpdateUser=@UpdateUser");
            strSql.Append(" where LoginName=@LoginName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginPwd", SqlDbType.VarChar,100),
                    new SqlParameter("@NickName", SqlDbType.NVarChar,10),
                    new SqlParameter("@Sex", SqlDbType.Bit,1),
                    new SqlParameter("@Birthday", SqlDbType.Date,3),
                    new SqlParameter("@PlaceBirth", SqlDbType.NVarChar,50),
                    new SqlParameter("@PhoneNumber", SqlDbType.Char,11),
                    new SqlParameter("@IsEnabled", SqlDbType.Bit,1),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20)};
            parameters[0].Value = model.LoginPwd;
            parameters[1].Value = model.NickName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.PlaceBirth;
            parameters[5].Value = model.PhoneNumber;
            parameters[6].Value = model.IsEnabled;
            parameters[7].Value = model.CreateDate;
            parameters[8].Value = model.CreateUser;
            parameters[9].Value = model.UpdateDate;
            parameters[10].Value = model.UpdateUser;
            parameters[11].Value = model.LoginName;

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
        public bool Delete(string LoginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_User ");
            strSql.Append(" where LoginName=@LoginName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20)            };
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string LoginNamelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_User ");
            strSql.Append(" where LoginName in (" + LoginNamelist + ")  ");
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
        public ML.Model.S_User GetModel(string LoginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LoginName,LoginPwd,NickName,Sex,Birthday,PlaceBirth,PhoneNumber,IsEnabled,CreateDate,CreateUser,UpdateDate,UpdateUser from S_User ");
            strSql.Append(" where LoginName=@LoginName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20)            };
            parameters[0].Value = LoginName;

            ML.Model.S_User model = new ML.Model.S_User();
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
        public ML.Model.S_User DataRowToModel(DataRow row)
        {
            ML.Model.S_User model = new ML.Model.S_User();
            if (row != null)
            {
                if (row["LoginName"] != null)
                {
                    model.LoginName = row["LoginName"].ToString();
                }
                if (row["LoginPwd"] != null)
                {
                    model.LoginPwd = row["LoginPwd"].ToString();
                }
                if (row["NickName"] != null)
                {
                    model.NickName = row["NickName"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    if ((row["Sex"].ToString() == "1") || (row["Sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["PlaceBirth"] != null)
                {
                    model.PlaceBirth = row["PlaceBirth"].ToString();
                }
                if (row["PhoneNumber"] != null)
                {
                    model.PhoneNumber = row["PhoneNumber"].ToString();
                }
                if (row["IsEnabled"] != null && row["IsEnabled"].ToString() != "")
                {
                    if ((row["IsEnabled"].ToString() == "1") || (row["IsEnabled"].ToString().ToLower() == "true"))
                    {
                        model.IsEnabled = true;
                    }
                    else
                    {
                        model.IsEnabled = false;
                    }
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["CreateUser"] != null)
                {
                    model.CreateUser = row["CreateUser"].ToString();
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
                if (row["UpdateUser"] != null)
                {
                    model.UpdateUser = row["UpdateUser"].ToString();
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
            strSql.Append("select LoginName,LoginPwd,NickName,Sex,Birthday,PlaceBirth,PhoneNumber,IsEnabled,CreateDate,CreateUser,UpdateDate,UpdateUser ");
            strSql.Append(" FROM S_User ");
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
            strSql.Append(" LoginName,LoginPwd,NickName,Sex,Birthday,PlaceBirth,PhoneNumber,IsEnabled,CreateDate,CreateUser,UpdateDate,UpdateUser ");
            strSql.Append(" FROM S_User ");
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
            strSql.Append("select count(1) FROM S_User ");
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
                strSql.Append("order by T.LoginName desc");
            }
            strSql.Append(")AS Row, T.*  from S_User T ");
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
        public DataSet GetPageData(int CurrentPage, int PageSize, string Where,string Sort,out int RecordCount)
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
			parameters[0].Value = "S_User";
			parameters[1].Value = "LoginName";
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

