using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_UserNews : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        gvNews.DataSource = new Maticsoft.BLL.tNews().GetListnews("authorid='" + Session["userID"].ToString() + "'");
        gvNews.DataBind();
    }

    protected void gvNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bool b = new Maticsoft.BLL.tNews().Delete(Convert.ToInt32(gvNews.DataKeys[e.RowIndex].Value));
        if (b)
        {


            Response.Write("<script>alert('删除成功！')</script>");
            gvNews.DataSource = new Maticsoft.BLL.tNews().GetListnews("authorid='" + Session["userID"].ToString() + "'");
            gvNews.DataBind();
        }
        else
        {
            Response.Write("<script>alert('删除失败！')</script>");
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