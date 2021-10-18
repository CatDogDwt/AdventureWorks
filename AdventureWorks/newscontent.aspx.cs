using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class newscontent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string newsid = Request.QueryString["newsid"];//获取newsid的值
        if (!IsPostBack)
        {
            DataSet dt = new Maticsoft.BLL.tNews().GetListnews("tnews.id='" + newsid + "'");
            Maticsoft.Model.tNews model = new Maticsoft.BLL.tNews().GetModel(Convert.ToInt32(newsid));

            model.LiuLan = model.LiuLan + 1;

            new Maticsoft.BLL.tNews().Update(model);

            lblTitle.Text = dt.Tables[0].Rows[0]["title"].ToString();
            lblContent.Text = dt.Tables[0].Rows[0]["contents"].ToString();
            lblTime.Text = dt.Tables[0].Rows[0]["adddate"].ToString();
            lblAuthor.Text = dt.Tables[0].Rows[0]["username"].ToString();

            repComment.DataSource = new Maticsoft.BLL.tComment().GetCommentList("newsid='" + newsid + "'and status='可发布'and usertype!='禁止用户'");
            repComment.DataBind();

            if (Session["userID"] == null || dt.Tables[0].Rows[0]["commentstatus"].ToString() == "禁止评论")
            {
                if (Session["userID"] == null)
                {
                    txtComment.Text = "请登录后再进行评论";
                    btnSub.Enabled = false;
                    txtComment.ReadOnly = true;
                }
                else
                {
                    txtComment.Text = "该新闻禁止评论";
                    btnSub.Enabled = false;
                    txtComment.ReadOnly = true;
                }
            }
            else
            {
                txtComment.ReadOnly = false;
                btnSub.Enabled = true;
                txtComment.Text = "";
            }
        }
    }

    protected void btnSub_Click(object sender, EventArgs e)
    {
        if (txtComment.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入评论内容！')</script>");
            return;
        }
        if (Page.IsValid)
        {
            try
            {
                string newsid = Request.QueryString["newsid"];
                Maticsoft.Model.tComment tComment = new Maticsoft.Model.tComment();
                tComment.NewsID = Convert.ToInt32(newsid);
                tComment.AuthorID = Convert.ToInt32(Session["userID"].ToString());
                tComment.Contents = txtComment.Text.Trim();
                if (Session["usertype"] != null && Session["usertype"].ToString() == "管理员")
                {
                    tComment.Status = "可发布";
                }
                int b = new Maticsoft.BLL.tComment().Add(tComment);
                if (b > 0)
                {
                    if (Session["usertype"] != null && Session["usertype"].ToString() == "管理员")
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('恭喜您，评论成功!')</script>");
                    }
                    else if (Session["usertype"] != null && Session["usertype"].ToString() == "普通用户")
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('发表评论成功,请等待审核!')</script>");
                    }
                    txtComment.Text = "";
                    repComment.DataSource = new Maticsoft.BLL.tComment().GetCommentList("newsid='" + newsid + "'and status='可发布'and usertype!='禁止用户'");
                    repComment.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('发表评论失败!');window.location.reload();</script>");
                }
            }
            catch
            {
                Response.Redirect("~/index.aspx");
            }
        }
    }
}