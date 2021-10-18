using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tNews
    /// </summary>
    public partial class tNews
    {
        public tNews()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "tNews");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tNews");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.tNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tNews(");
            strSql.Append("Title,AuthorID,CategoryID,AddDate,ReferInfo,Contents,Status,CommentStatus,Remark,LiuLan)");
            strSql.Append(" values (");
            strSql.Append("@Title,@AuthorID,@CategoryID,@AddDate,@ReferInfo,@Contents,@Status,@CommentStatus,@Remark,@LiuLan)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@ReferInfo", SqlDbType.NVarChar,50),
					new SqlParameter("@Contents", SqlDbType.Text),
					new SqlParameter("@Status", SqlDbType.NVarChar,-1),
					new SqlParameter("@CommentStatus", SqlDbType.NVarChar,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@LiuLan", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.AuthorID;
            parameters[2].Value = model.CategoryID;
            parameters[3].Value = model.AddDate;
            parameters[4].Value = model.ReferInfo;
            parameters[5].Value = model.Contents;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.CommentStatus;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.LiuLan;

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
        public bool Update(Maticsoft.Model.tNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tNews set ");
            strSql.Append("Title=@Title,");
            strSql.Append("AuthorID=@AuthorID,");
            strSql.Append("CategoryID=@CategoryID,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("ReferInfo=@ReferInfo,");
            strSql.Append("Contents=@Contents,");
            strSql.Append("Status=@Status,");
            strSql.Append("CommentStatus=@CommentStatus,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("LiuLan=@LiuLan");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@ReferInfo", SqlDbType.NVarChar,50),
					new SqlParameter("@Contents", SqlDbType.Text),
					new SqlParameter("@Status", SqlDbType.NVarChar,-1),
					new SqlParameter("@CommentStatus", SqlDbType.NVarChar,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@LiuLan", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.AuthorID;
            parameters[2].Value = model.CategoryID;
            parameters[3].Value = model.AddDate;
            parameters[4].Value = model.ReferInfo;
            parameters[5].Value = model.Contents;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.CommentStatus;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.LiuLan;
            parameters[10].Value = model.ID;

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
            strSql.Append("delete from tNews ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tNews ");
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
        /// 获得搜索新闻
        /// </summary>
        /// <param name="strKey">搜索关键字</param>
        /// <returns></returns>
        public DataSet GetSearchNews(string strKey)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tNews.ID,Title,AuthorID,CategoryID,CategoryName,AddDate,");
            strSql.Append("ReferInfo,Contents,tNews.Status,CommentStatus,LiuLan,usertype,username");
            strSql.Append(" FROM tNews INNER join tNewsCategory on tNewsCategory.id= tNews.CategoryID ");
            strSql.Append("INNER JOIN tUsers ON tNews.AuthorID = tUsers.ID ");
            strSql.Append(" where (Title like @Title or Contents like @Contents) and tNews.status='可发布'");
            SqlParameter[] parameters = {
				    new SqlParameter("@Title", SqlDbType.NVarChar,50),
				    new SqlParameter("@Contents", SqlDbType.Text)};
            string strLikeKey = "%" + strKey + "%";
            parameters[0].Value = strLikeKey;
            parameters[1].Value = strLikeKey;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得分类页新闻列表
        /// </summary>
        public DataSet GetListnews(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tNews.ID,Title,AuthorID,CategoryID,CategoryName,AddDate,ReferInfo,Contents,tNews.Status,CommentStatus,LiuLan,usertype,username");
            strSql.Append(" FROM tNews INNER join tNewsCategory on tNewsCategory.id= tNews.CategoryID INNER JOIN tUsers ON tNews.AuthorID = tUsers.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.tNews GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Title,AuthorID,CategoryID,AddDate,ReferInfo,Contents,Status,CommentStatus,Remark,LiuLan from tNews ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.tNews model = new Maticsoft.Model.tNews();
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
        public Maticsoft.Model.tNews DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tNews model = new Maticsoft.Model.tNews();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["AuthorID"] != null && row["AuthorID"].ToString() != "")
                {
                    model.AuthorID = int.Parse(row["AuthorID"].ToString());
                }
                if (row["CategoryID"] != null && row["CategoryID"].ToString() != "")
                {
                    model.CategoryID = int.Parse(row["CategoryID"].ToString());
                }
                if (row["AddDate"] != null && row["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(row["AddDate"].ToString());
                }
                if (row["ReferInfo"] != null)
                {
                    model.ReferInfo = row["ReferInfo"].ToString();
                }
                if (row["Contents"] != null)
                {
                    model.Contents = row["Contents"].ToString();
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["CommentStatus"] != null)
                {
                    model.CommentStatus = row["CommentStatus"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["LiuLan"] != null && row["LiuLan"].ToString() != "")
                {
                    model.LiuLan = int.Parse(row["LiuLan"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得类别名称前几行数据
        /// </summary>
        public DataSet GetTotalList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" tNews.ID,Title,AuthorID,CategoryID,CategoryName,AddDate,ReferInfo,Contents,tNews.Status,CommentStatus,LiuLan,usertype ");
            strSql.Append(" FROM tNews INNER join tNewsCategory on tNewsCategory.id= tNews.CategoryID INNER JOIN tUsers ON tNews.AuthorID = tUsers.ID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,AuthorID,CategoryID,AddDate,ReferInfo,Contents,Status,CommentStatus,Remark,LiuLan ");
            strSql.Append(" FROM tNews ");
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
            strSql.Append(" ID,Title,AuthorID,CategoryID,AddDate,ReferInfo,Contents,Status,CommentStatus,Remark,LiuLan ");
            strSql.Append(" FROM tNews ");
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
            strSql.Append("select count(1) FROM tNews ");
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
            strSql.Append(")AS Row, T.*  from tNews T ");
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
            parameters[0].Value = "tNews";
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