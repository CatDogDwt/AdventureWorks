using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_release : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


        }
    }

    protected void btnRelease_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (ftxtContents.Text == "")
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('新闻内容不能为空');</script>");

            }
            else
            {
                Maticsoft.Model.tNews tNews = new Maticsoft.Model.tNews();
                DataSet dt = new Maticsoft.BLL.tNewsCategory().GetList("CategoryName='" + DropDownList1.SelectedValue + "'");
                DataSet ds = new Maticsoft.BLL.tUsers().GetList("UserName='" + Session["userName"].ToString() + "'");
                tNews.Title = txtTitle.Text.Trim();
                tNews.CategoryID = Convert.ToInt32(dt.Tables[0].Rows[0][0]);
                tNews.Contents = ftxtContents.Text.Trim();
                tNews.ReferInfo = txtReferInfo.Text.Trim();
                tNews.LiuLan = 0;
                tNews.AuthorID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                if (Session["usertype"] != null && Session["usertype"].ToString() == "管理员")
                {
                    tNews.Status = "可发布";
                }
                int b = new Maticsoft.BLL.tNews().Add(tNews);
                if (b > 0)
                {
                    if (Session["usertype"].ToString() == "管理员")
                    {

                        Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('恭喜您,发布新闻成功!');</script>");
                        txtTitle.Text = "";
                        DropDownList1.SelectedIndex = 0;
                        ftxtContents.Text = "";
                        txtReferInfo.Text = "";

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('发布新闻成功！请等待审核');</script>");
                        txtTitle.Text = "";
                        DropDownList1.SelectedIndex = 0;
                        ftxtContents.Text = "";
                        txtReferInfo.Text = "";
                    }
                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('发布新闻失败！');</script>");
                }
            }
        }
    }
}