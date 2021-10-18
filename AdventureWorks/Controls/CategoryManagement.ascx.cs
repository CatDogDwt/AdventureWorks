using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Data;

public partial class Controls_CategoryManagement : System.Web.UI.UserControl
{
    Maticsoft.Model.tNewsCategory model = new Maticsoft.Model.tNewsCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    protected void Bind()
    {
        gvCategory.DataSource = new Maticsoft.BLL.tNewsCategory().GetAllList();
        gvCategory.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        model.CategoryName = txtCategoryAdd.Text.Trim();
        bool a = new Maticsoft.BLL.tNewsCategory().Exists(model.CategoryName);
        if (a)
        {

            Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('类别名称不能重复存在！');</script>");
        }
        else
        {
            int b = new Maticsoft.BLL.tNewsCategory().Add(model);
            if (b > 0)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('添加成功！');{window.location.reload()}</script>");
            }
            else
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('添加失败！');</script>");

            }

        }
    }

    protected void gvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bool b = new Maticsoft.BLL.tNewsCategory().Delete(Convert.ToInt32(gvCategory.DataKeys[e.RowIndex].Value));
        if (b)
        {



            Response.Write("<script>alert('删除成功！');window.location.reload();</script>");
            Bind();

        }
        else
        {
            Response.Write("<script>alert('删除失败！')</script>");
        }
    }

    protected void gvCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.gvCategory.EditIndex = e.NewEditIndex;
        Bind();
    }

    protected void gvCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.gvCategory.EditIndex = -1;
        Bind();
    }

    protected void gvCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        model.ID = Convert.ToInt32(gvCategory.DataKeys[e.RowIndex].Value);
        //model.CategoryName = ((TextBox)(gvCategory.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();

        model.CategoryName = ((TextBox)(gvCategory.Rows[e.RowIndex].FindControl("TextBox1"))).Text.ToString().Trim();
        string categoryName = ((TextBox)(gvCategory.Rows[e.RowIndex].FindControl("TextBox1"))).Text.ToString().Trim();
        bool a = new Maticsoft.BLL.tNewsCategory().Exists(model.CategoryName);
        if (a && categoryName != model.CategoryName)
        {

            Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('类别名称不能重复存在！');</script>");

        }
        else
        {
            bool b = new Maticsoft.BLL.tNewsCategory().Update(model);
            if (b)
            {


                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('更新成功！');{window.location.reload()}</script>");


                // this.gvCategory.EditIndex = -1;
                //Bind();
            }
            else
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('更新失败！');</script>");

            }
        }
    }

    protected void lbtnYes_Click(object sender, EventArgs e)
    {
        LinkButton status = (LinkButton)sender;
        string id = status.CommandArgument;
        model.ID = Convert.ToInt32(id);
        if (status.Text == "显示")
        {
            model.Status = "不显示";

            bool b = new Maticsoft.BLL.tNewsCategory().Update(model);


        }
        else
        {

            model.Status = "显示";

            bool b = new Maticsoft.BLL.tNewsCategory().Update(model);



        }


        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('类别显示状态已更新!');{window.location.reload()}</script>");

        Bind();
    }
}