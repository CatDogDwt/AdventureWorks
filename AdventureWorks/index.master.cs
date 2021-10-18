using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Text;

public partial class index : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userName"] != null)
            {
                LoginPanel.Visible = false;
                UserInfoPanel.Visible = true;
                string userName = Session["userName"].ToString();
                LoginRegisterbtn.Text = userName;
            }
            else
            {
                LoginPanel.Visible = true;
                UserInfoPanel.Visible = false;
                LoginRegisterbtn.Text = "登录/注册";
            }

            repCategory.DataSource = new Maticsoft.BLL.tNewsCategory().GetList("status='显示'");
            repCategory.DataBind();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserID.Text == "" || txtLPwd.Text == "")
        {
            Response.Write("<script>alert('用户名或密码不能为空！')</script>");
        }
        else
        {
            if ((Session["CheckCode"] != null) && (Session["CheckCode"].ToString() != ""))
            {
                if (Session["CheckCode"].ToString().ToLower() != this.txtCheckCode.Text.ToLower())
                {
                    Session["CheckCode"] = null;
                    this.txtCheckCode.Text = "";
                    Response.Write("<script>alert('验证码输入有误！')</script>");
                    return;
                }
                else
                {
                    Session["CheckCode"] = null;
                }
            }
            else
            {
                Response.Redirect("~/index.aspx");
            }
            DataSet dt = new Maticsoft.BLL.tUsers().Validate(txtUserID.Text.Trim(), txtLPwd.Text.Trim());
            if (dt.Tables[0].Rows.Count > 0)
            {
                if (dt.Tables[0].Rows[0]["usertype"].ToString() == "禁止用户")
                {
                    Response.Write("<script>alert('该用户已被禁止登陆！');{location.href='UserLogin.aspx'()};</script>");
                    return;
                }
                Session["userName"] = dt.Tables[0].Rows[0][3].ToString().Trim();
                Session["userType"] = dt.Tables[0].Rows[0][6].ToString().Trim();
                Session["userID"] = dt.Tables[0].Rows[0][0].ToString().Trim();
                if (Session["UserType"] != null)
                {
                    if (dt.Tables[0].Rows[0]["usertype"].ToString() == "普通用户")
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('恭喜您" + txtUserID.Text + ",登陆成功！');</script>");
                        Response.Redirect("index.aspx");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误，请重新登陆!');{location.href='index.aspx'};</script>");
            }
        }
    }

    protected void txtUserLoginID_TextChanged(object sender, EventArgs e)
    {
        if (txtUserLoginID.Text.Trim() == "")
        {
            Label1.Text = "";
        }
        else
        {
            DataSet dt = new Maticsoft.BLL.tUsers().GetList("userloginid='" + txtUserLoginID.Text.Trim() + "'");
            if (dt.Tables[0].Rows.Count > 0)
            {
                this.Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "X";
            }
            else
            {
                this.Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "√";
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string Name = "新用户#";

        if (Page.IsValid)
        {

            if (Label1.Text.Trim() == "√")
            {
                Maticsoft.Model.tUsers tUsers = new Maticsoft.Model.tUsers();

                tUsers.UserLoginID = txtUserLoginID.Text.Trim();
                tUsers.UserName = Name + RandomHelper.GenerateRandomCode(9999).ToString();
                //此处应有判断默认名后数字是否重复，但由于用户注册量不会太多仅做测试用，所以没写
                tUsers.Password = txtRPwd.Text.Trim();
                tUsers.UserEmail = txtEmail.Text.Trim();
                tUsers.UserType = "普通用户";

                int sum = new Maticsoft.BLL.tUsers().Add(tUsers);
                if (sum > 0)
                {
                    Response.Write("<script>alert('注册成功！');window.location.href='index.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('注册失败，请联系管理员！');window.location.reload();</script>");
                }
            }
            else
            {
                if (Label1.Text.Trim() != "√")
                {
                    Label1.Visible = true;
                }
                else
                {
                    Label1.Visible = false;
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text != "")
        {
            string key = txtSearch.Text.Trim();

            Response.Redirect("~/Search.aspx?key=" + Server.HtmlEncode(key));
        }
        else
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}

public class RandomHelper
{
    /// <summary>
    ///生成制定位数的随机码（数字）
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string GenerateRandomCode(int length)
    {
        var result = new StringBuilder();
        for (var i = 0; i < length; i++)
        {
            var r = new Random(Guid.NewGuid().GetHashCode());
            result.Append(r.Next(0, 10));
        }
        return result.ToString();
    }
}
