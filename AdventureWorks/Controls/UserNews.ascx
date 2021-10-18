<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserNews.ascx.cs" Inherits="Controls_UserNews" %>
<h4>新闻管理</h4>
<asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="False"
    BorderWidth="0px" GridLines="None" EmptyDataText="暂无新闻" DataKeyNames="id" OnRowDeleting="gvNews_RowDeleting">
    <Columns>
        <asp:TemplateField HeaderText="新闻类别">
            <ItemTemplate>
                <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>--%>

                <a href='list.aspx?CategoryID=<%# Eval("CategoryID") %>'>[<%# Eval("CategoryName") %>]</a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="新闻标题">
            <ItemTemplate>
                <%--<asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>'></asp:Label>--%>
                <a href='newscontent.aspx?newsid=<%#Eval("ID") %>' target="_blank" title='<%# Eval("Title") %>'><%#StringTruncat(Eval("Title").ToString(),18,"...") %></a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="发布时间">
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("AddDate") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Status" HeaderText="审核结果"
            SortExpression="tNews.Status" />
        <asp:HyperLinkField DataNavigateUrlFields="id"
            DataNavigateUrlFormatString="~/modifynews.aspx?id={0}" HeaderText="编辑"
            Text="编辑" />
        <asp:ButtonField CommandName="Delete" HeaderText="删除" ShowHeader="True"
            Text="删除" />
    </Columns>
</asp:GridView>
