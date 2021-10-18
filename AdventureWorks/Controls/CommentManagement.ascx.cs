using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_CommentManagement : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvStatus.DataSource = new Maticsoft.BLL.tComment().GetList("status='待审核'");
            gvStatus.DataBind();
        }
    }

    public static string StringTruncat(string oldStr, int maxLength, string endWith)
    {
        if (string.IsNullOrEmpty(oldStr))
            //   throw   new   NullReferenceException( "原字符串不能为空 "); 
            return oldStr + endWith;
        if (maxLength < 1)
            throw new Exception("返回的字符串长度必须大于[0] ");
        if (oldStr.Length > maxLength)
        {
            string strTmp = oldStr.Substring(0, maxLength);
            if (string.IsNullOrEmpty(endWith))
                return strTmp;
            else
                return strTmp + endWith;
        }
        return oldStr;
    }

    protected void lbtnYes_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;//注意控件类型的转换

        string id = lbtn.CommandArgument;//获取得到控件绑定的对应值

        Maticsoft.Model.tComment tcomment = new Maticsoft.Model.tComment();
        tcomment.Status = "可发布";
        tcomment.ID = Convert.ToInt32(id);
        DataSet dt = new Maticsoft.BLL.tComment().GetList("id='" + id + "'");
        tcomment.AuthorID = Convert.ToInt32(dt.Tables[0].Rows[0]["AuthorID"]);
        tcomment.NewsID = Convert.ToInt32(dt.Tables[0].Rows[0]["NewsID"]);
        bool b = new Maticsoft.BLL.tComment().Update(tcomment);
        if (b)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('该评论已通过审核！');</script>");

            gvcommentyes.DataBind();

            gvStatus.DataSource = new Maticsoft.BLL.tComment().GetList("status='待审核'");
            gvStatus.DataBind();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('审核评论失败！');</script>");
        }
    }

    protected void lbtnNo_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;//注意控件类型的转换

        string id = lbtn.CommandArgument;//获取得到控件绑定的对应值

        Maticsoft.Model.tComment tcomment = new Maticsoft.Model.tComment();
        tcomment.Status = "未通过";
        tcomment.ID = Convert.ToInt32(id);
        DataSet dt = new Maticsoft.BLL.tComment().GetList("id='" + id + "'");
        tcomment.AuthorID = Convert.ToInt32(dt.Tables[0].Rows[0]["AuthorID"]);
        tcomment.NewsID = Convert.ToInt32(dt.Tables[0].Rows[0]["NewsID"]);
        bool b = new Maticsoft.BLL.tComment().Update(tcomment);
        if (b)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('该评论未通过审核！');</script>");


            gvcommentyes.DataBind();

            gvStatus.DataSource = new Maticsoft.BLL.tComment().GetList("status='待审核'");
            gvStatus.DataBind();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('审核评论失败！');</script>");
        }
    }
}