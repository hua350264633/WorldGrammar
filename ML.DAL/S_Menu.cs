using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ML.DBHelper;
namespace ML.DAL
{
    /// <summary>
    /// 数据访问类:S_Menu
    /// </summary>
    public partial class S_Menu
    {
        public S_Menu()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string MenuCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_Menu");
            strSql.Append(" where MenuCode=@MenuCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuCode", SqlDbType.VarChar,20)         };
            parameters[0].Value = MenuCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ML.Model.S_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_Menu(");
            strSql.Append("MenuCode,MenuName,ParentCode,MenuSeq,MenuIcon,URL,IsEnable,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@MenuCode,@MenuName,@ParentCode,@MenuSeq,@MenuIcon,@URL,@IsEnable,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuCode", SqlDbType.VarChar,20),
                    new SqlParameter("@MenuName", SqlDbType.NVarChar,20),
                    new SqlParameter("@ParentCode", SqlDbType.VarChar,20),
                    new SqlParameter("@MenuSeq", SqlDbType.Int,4),
                    new SqlParameter("@MenuIcon", SqlDbType.VarChar,50),
                    new SqlParameter("@URL", SqlDbType.VarChar,255),
                    new SqlParameter("@IsEnable", SqlDbType.Bit,1),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.MenuCode;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.ParentCode;
            parameters[3].Value = model.MenuSeq;
            parameters[4].Value = model.MenuIcon;
            parameters[5].Value = model.URL;
            parameters[6].Value = model.IsEnable;
            parameters[7].Value = model.CreateUser;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.UpdateUser;
            parameters[10].Value = model.UpdateDate;

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
        public bool Update(ML.Model.S_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_Menu set ");
            strSql.Append("MenuCode=@MenuCode,");
            strSql.Append("MenuName=@MenuName,");
            strSql.Append("ParentCode=@ParentCode,");
            strSql.Append("MenuSeq=@MenuSeq,");
            strSql.Append("MenuIcon=@MenuIcon,");
            strSql.Append("URL=@URL,");
            strSql.Append("IsEnable=@IsEnable,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuName", SqlDbType.NVarChar,20),
                    new SqlParameter("@ParentCode", SqlDbType.VarChar,20),
                    new SqlParameter("@MenuSeq", SqlDbType.Int,4),
                    new SqlParameter("@MenuIcon", SqlDbType.VarChar,50),
                    new SqlParameter("@URL", SqlDbType.VarChar,255),
                    new SqlParameter("@IsEnable", SqlDbType.Bit,1),
                    new SqlParameter("@CreateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.VarChar,20),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@MenuCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.MenuName;
            parameters[1].Value = model.ParentCode;
            parameters[2].Value = model.MenuSeq;
            parameters[3].Value = model.MenuIcon;
            parameters[4].Value = model.URL;
            parameters[5].Value = model.IsEnable;
            parameters[6].Value = model.CreateUser;
            parameters[7].Value = model.CreateDate;
            parameters[8].Value = model.UpdateUser;
            parameters[9].Value = model.UpdateDate;
            parameters[10].Value = model.ID;
            parameters[11].Value = model.MenuCode;

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
            strSql.Append("delete from S_Menu ");
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
        public bool Delete(string MenuCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_Menu ");
            strSql.Append(" where MenuCode=@MenuCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuCode", SqlDbType.VarChar,20)         };
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from S_Menu ");
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
        public ML.Model.S_Menu GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MenuCode,MenuName,ParentCode,MenuSeq,MenuIcon,URL,IsEnable,CreateUser,CreateDate,UpdateUser,UpdateDate from S_Menu ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            ML.Model.S_Menu model = new ML.Model.S_Menu();
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
        public ML.Model.S_Menu DataRowToModel(DataRow row)
        {
            ML.Model.S_Menu model = new ML.Model.S_Menu();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["MenuCode"] != null)
                {
                    model.MenuCode = row["MenuCode"].ToString();
                }
                if (row["MenuName"] != null)
                {
                    model.MenuName = row["MenuName"].ToString();
                }
                if (row["ParentCode"] != null)
                {
                    model.ParentCode = row["ParentCode"].ToString();
                }
                if (row["MenuSeq"] != null && row["MenuSeq"].ToString() != "")
                {
                    model.MenuSeq = int.Parse(row["MenuSeq"].ToString());
                }
                if (row["MenuIcon"] != null)
                {
                    model.MenuIcon = row["MenuIcon"].ToString();
                }
                if (row["URL"] != null)
                {
                    model.URL = row["URL"].ToString();
                }
                if (row["IsEnable"] != null && row["IsEnable"].ToString() != "")
                {
                    if ((row["IsEnable"].ToString() == "1") || (row["IsEnable"].ToString().ToLower() == "true"))
                    {
                        model.IsEnable = true;
                    }
                    else
                    {
                        model.IsEnable = false;
                    }
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
            strSql.Append("select ID,MenuCode,MenuName,ParentCode,MenuSeq,MenuIcon,URL,IsEnable,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM S_Menu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ParentCode,MenuSeq");  //排序
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
            strSql.Append(" ID,MenuCode,MenuName,ParentCode,MenuSeq,MenuIcon,URL,IsEnable,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM S_Menu ");
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
            strSql.Append("select count(1) FROM S_Menu ");
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
            strSql.Append(")AS Row, T.*  from S_Menu T ");
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
			parameters[0].Value = "S_Menu";
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
        /// 自动生成菜单编码
        /// </summary>
        /// <param name="selfCode">本身编码</param>
        /// <param name="parentCode">父级菜单编码</param>
        /// <returns></returns>
        public string GenerateMenuCode(string selfCode, string parentCode)
        {
            var sql = $@"select case when max(MenuCode) is null then concat('0',convert(int,'{parentCode}'),1) else concat('0',convert(int,max(MenuCode))+1) end as newMenuCode 
                        from S_Menu where MenuCode <> '0999' and ParentCode = '{parentCode}'";
            if (!string.IsNullOrEmpty(selfCode))
            {
                sql += $" and MenuCode <> '{selfCode}'";
            }
            return DbHelperSQL.GetSingle(sql).ToString();
        }


        #endregion  ExtensionMethod
    }
}

