using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_Password : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userID"] != null)
            {
                string userid = Session["userID"].ToString();
                DataSet dt = new Maticsoft.BLL.tUsers().GetList("id='" + userid + "'");
                lblUserLoginID.Text = dt.Tables[0].Rows[0]["UserLoginID"].ToString();
            }
            else
            {
                Response.Write("<script>alert('未登录，请先登录！');window.location.href='index.aspx';</script>");
            }
        }
    }

    protected void btnPwdSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string userid = Session["userID"].ToString();
            DataSet dt = new Maticsoft.BLL.tUsers().GetList("id='" + userid + "'and Password='" + txtOldPwd.Text.Trim() + "'");
            if (dt.Tables[0].Rows.Count > 0)
            {
                Maticsoft.Model.tUsers tUser = new Maticsoft.Model.tUsers();
                tUser.ID = Convert.ToInt32(userid);
                tUser.Password = txtNewPwd.Text.Trim();
                bool b = new Maticsoft.BLL.tUsers().UpdatePassword(tUser);
                if (b)
                {
                    Session.Contents.RemoveAll();
                    Response.Write("<script>alert('密码修改成功，请重新登陆');window.location.href='index.aspx';</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('密码修改失败！');</script>");
                    Response.Redirect("~/index.aspx");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('旧密码验证错误，请重新输入！');</script>");
                txtNewPwd.Text = "";
                txtNewPwd2.Text = "";
                txtOldPwd.Text = "";
            }
        }
    }
}