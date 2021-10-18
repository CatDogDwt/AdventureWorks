using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Password.Visible = false;
        UserNews.Visible = false;
        release.Visible = true;
        CommentManagement.Visible = false;
        CategoryManagement.Visible = false;
        UserManagement.Visible = false;
    }

    protected void lbtnNews_Click(object sender, EventArgs e)
    {
        Password.Visible = false;
        UserNews.Visible = true;
        release.Visible = false;
        CommentManagement.Visible = false;
        CategoryManagement.Visible = false;
        UserManagement.Visible = false;
    }

    protected void lbtnComment_Click(object sender, EventArgs e)
    {
        Password.Visible = false;
        UserNews.Visible = false;
        release.Visible = false;
        CommentManagement.Visible = true;
        CategoryManagement.Visible = false;
        UserManagement.Visible = false;
    }

    protected void lbtnSort_Click(object sender, EventArgs e)
    {
        Password.Visible = false;
        UserNews.Visible = false;
        release.Visible = false;
        CommentManagement.Visible = false;
        CategoryManagement.Visible = true;
        UserManagement.Visible = false;
    }

    protected void lbtnInfo_Click(object sender, EventArgs e)
    {
        Password.Visible = true;
        UserNews.Visible = false;
        release.Visible = false;
        CommentManagement.Visible = false;
        CategoryManagement.Visible = false;
        UserManagement.Visible = false;
    }

    protected void lbtnFaBu_Click(object sender, EventArgs e)
    {
        Password.Visible = false;
        UserNews.Visible = false;
        release.Visible = true;
        CommentManagement.Visible = false;
        CategoryManagement.Visible = false;
        UserManagement.Visible = false;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //清除所有session
        Session.Contents.RemoveAll();
        //跳转到首页
        Response.Write("<script>alert('注销成功！');window.location.href='index.aspx';</script>");
    }

    protected void lblUM_Click(object sender, EventArgs e)
    {
        Password.Visible = false;
        UserNews.Visible = false;
        release.Visible = false;
        CommentManagement.Visible = false;
        CategoryManagement.Visible = false;
        UserManagement.Visible = true;
    }
}