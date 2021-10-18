using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserCenter : System.Web.UI.Page
{
    protected static string userName;
    Maticsoft.Model.tUsers tUser = new Maticsoft.Model.tUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userID"] != null)
            {
                Bind();
            }
        }
        UCPinfo.Visible = true;
        UCPpwd.Visible = false;
        UCPcomment.Visible = false;
        UCbtnOK.Visible = false;
        UCbtnCancle.Visible = false;
    }

    protected void lbPinfo_Click(object sender, EventArgs e)
    {
        UCPinfo.Visible = true;
        UCPpwd.Visible = false;
        UCPcomment.Visible = false;
    }

    protected void lblPpwd_Click(object sender, EventArgs e)
    {
        UCPinfo.Visible = false;
        UCPpwd.Visible = true;
        UCPcomment.Visible = false;
    }

    protected void lblPcomment_Click(object sender, EventArgs e)
    {
        UCPinfo.Visible = false;
        UCPpwd.Visible = false;
        UCPcomment.Visible = true;
    }

    protected void UCbtnchangeinfo_Click(object sender, EventArgs e)
    {
        UCtxtEmail.ReadOnly = false;
        UCtxtID.ReadOnly = false;
        UCbtnchangeinfo.Visible = false;
        UCbtnOK.Visible = true;
        UCbtnCancle.Visible = true;
    }

    protected void UCbtnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }

    protected void UCbtnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Label1.Text != "X")
            {
                string userid = Session["userID"].ToString();
                Maticsoft.Model.tUsers model = new Maticsoft.BLL.tUsers().GetModel(Convert.ToInt32(userid));
                model.ID = Convert.ToInt32(userid);
                model.UserName = UCtxtID.Text.Trim();
                model.UserEmail = UCtxtEmail.Text.Trim();
                bool b = new Maticsoft.BLL.tUsers().Update(model);
                if (b)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('用户信息修改成功！');</script>");
                    Bind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('用户信息修改失败！');</script>");
                    Bind();
                }
            }
            else
            {
                Label1.Visible = true;
            }
            UCbtnchangeinfo.Visible = true;
            UCbtnOK.Visible = false;
            UCbtnCancle.Visible = false;
        }
    }

    protected void Bind()
    {
        string userid = Session["userID"].ToString();
        Maticsoft.Model.tUsers model = new Maticsoft.BLL.tUsers().GetModel(Convert.ToInt32(userid));
        UClbID.Text = model.UserName.ToString();
        UCtxtID.Text = model.UserName.ToString();
        UCtxtname.Text = model.UserLoginID.ToString();
        userName = model.UserName.ToString();
        UCtxtEmail.Text = model.UserEmail.ToString();
    }

    protected void UCtxtID_TextChanged(object sender, EventArgs e)
    {
        if (UCtxtID.Text.Trim() == "")
        {
            Label1.Text = "";
        }
        else
        {
            DataSet dt = new Maticsoft.BLL.tUsers().GetList("username='" + UCtxtID.Text.Trim() + "'");
            if (dt.Tables[0].Rows.Count > 0 && UCtxtID.Text.Trim() != userName)
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
}