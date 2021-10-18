using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.BLL;
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否第一次进入
        if (!IsPostBack)
        {

            //绑定最新新闻（5条）
            gvNewNews.DataSource = new Maticsoft.BLL.tNews().GetTotalList(5, "tNews.Status='可发布'and usertype!='禁止用户'", "AddDate");
            gvNewNews.DataBind();

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

    protected void gvHotNews_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "详情")
        {
            Response.Redirect("newscontent.aspx?newsid=" + e.CommandArgument.ToString());
        }
    }
}