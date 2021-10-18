using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string CategoryID = Request.QueryString["CategoryID"];
            DataSet ds = new Maticsoft.BLL.tNewsCategory().GetList("ID='" + CategoryID + "'");
            try
            {
                lblCategoryName.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            }
            catch
            {

                Response.Redirect("index.aspx");
            }
            DataSet dt = new Maticsoft.BLL.tNews().GetListnews("CategoryID='" + CategoryID + "'and tNews.status='可发布'and usertype!='禁止用户'");
            gvListNews.DataSource = dt;
            gvListNews.DataBind();
        }
    }

    public static string StringTruncat(string oldStr, int maxLength, string endWith)
    {
        if (string.IsNullOrEmpty(oldStr))
            //   throw   new   NullReferenceException( "原字符串不能为空 "); 
            return oldStr + endWith;
        if (maxLength < 1)
            throw new Exception("返回的字符串长度必须大于[0] ");
        if (oldStr.Length > maxLength)
        {
            string strTmp = oldStr.Substring(0, maxLength);
            if (string.IsNullOrEmpty(endWith))
                return strTmp;
            else
                return strTmp + endWith;
        }
        return oldStr;
    }
}