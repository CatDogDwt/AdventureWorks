using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_UserInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userName"] != null && Session["userType"] != null)
            {
                string userName = Session["userName"].ToString();
                lblUserPetName.Text = userName;
                string userType = Session["userType"].ToString();
                lblUserType.Text = userType;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session.Contents.RemoveAll();
        //跳转到首页
        Response.Write("<script>alert('注销成功！');window.location.href='index.aspx';</script>");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserCenter.aspx");
    }
}