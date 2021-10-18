<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserComment.ascx.cs" Inherits="Controls_UserComment" %>
<h4>评论管理</h4>
<asp:GridView ID="gvcomment" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" EmptyDataText="暂无可管理的评论" AllowPaging="True">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="评论序号" InsertVisible="False"
            ReadOnly="True" SortExpression="ID" />
        <asp:TemplateField HeaderText="新闻ID">
            <ItemTemplate>
                <a href='newscontent.aspx?newsid=<%# Eval("NewsID") %>'><%# Eval("NewsID") %></a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="评论内容" SortExpression="Contents">
            <ItemTemplate>

                <a href='newscontent.aspx?newsid=<%#Eval("newsID") %>' target="_blank" title='<%# Eval("Contents") %>'>
                    <%#StringTruncat(Eval("Contents").ToString(), 18, "...")%></a>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Contents") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="status" ReadOnly="True" HeaderText="是否审核" />

        <asp:CommandField HeaderText="操作" ShowDeleteButton="True"
            ShowEditButton="True" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMSConnectionString %>" DeleteCommand="DELETE FROM [tComment] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tComment] ([NewsID], [Contents], [Status]) VALUES (@NewsID, @Contents, @Status)" SelectCommand="SELECT [ID], [NewsID], [Contents], [Status] FROM [tComment] WHERE ([AuthorID] = @AuthorID) ORDER BY [AddDate]" UpdateCommand="UPDATE [tComment] SET [Contents] = @Contents WHERE [ID] = @ID">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="NewsID" Type="Int32" />
        <asp:Parameter Name="Contents" Type="String" />
        <asp:Parameter Name="Status" Type="String" />
    </InsertParameters>
    <SelectParameters>
        <asp:SessionParameter Name="AuthorID" SessionField="userid" Type="Int32" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="Contents" Type="String" />
        <asp:Parameter Name="ID" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

