using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_UserManagement : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void Bind()
    {
        gvuser.DataSource = new Maticsoft.BLL.tUsers().GetAllList();
        gvuser.DataBind();
    }

    protected void gvuser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bool b = new Maticsoft.BLL.tUsers().Delete(Convert.ToInt32(gvuser.DataKeys[e.RowIndex].Value));
        if (b)
        {
            Response.Write("<script>alert('删除成功！')</script>");
            Bind();
        }
        else
        {
            Response.Write("<script>alert('删除失败！')</script>");
        }
    }

    protected void btnSelectUser_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DataSet dt = new Maticsoft.BLL.tUsers().GetList("UserLoginID like '%" + txtSelectUser.Text.Trim() + "%'");
            gvuser.DataSource = dt;
            gvuser.DataBind();
        }
    }
}