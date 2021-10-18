using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtAdminName.Text == "" || txtAdminPwd.Text == "")
        {
            Response.Write("<script>alert('用户名或密码不能为空！')</script>");
        }
        else
        {
            DataSet dt = new Maticsoft.BLL.tUsers().Validate(txtAdminName.Text.Trim(), txtAdminPwd.Text.Trim());
            if (dt.Tables[0].Rows.Count > 0)
            {
                Session["userName"] = dt.Tables[0].Rows[0][3].ToString().Trim();
                Session["userType"] = dt.Tables[0].Rows[0][6].ToString().Trim();
                Session["userID"] = dt.Tables[0].Rows[0][0].ToString().Trim();
                if (Session["UserType"] != null)
                {
                    if (dt.Tables[0].Rows[0]["usertype"].ToString() == "普通用户")
                    {
                        Response.Write("<script>alert('对不起您不是管理员!请在首页登录');</script>");
                        Response.Redirect("index.aspx");
                    }
                    else if (dt.Tables[0].Rows[0]["usertype"].ToString() == "管理员")
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('恭喜您管理员" + txtAdminName.Text + ",登陆成功！');</script>");
                        Response.Redirect("UserManage.aspx");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误，请重新登陆!');window.location.reload();</script>");
            }
        }
    }
}