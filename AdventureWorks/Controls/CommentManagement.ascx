<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentManagement.ascx.cs" Inherits="Controls_CommentManagement" %>
<h4>评论管理</h4>
<p style="text-align: left">评论状态：<asp:DropDownList ID="DropDownList1" 
        runat="server" AutoPostBack="True">
    <asp:ListItem Selected="True">可发布</asp:ListItem>
    <asp:ListItem>未通过</asp:ListItem>
    </asp:DropDownList>
</p>
<asp:GridView ID="gvcommentyes" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="ID" DataSourceID="SqlDataSource1" EmptyDataText="暂无可管理的评论" 
    >
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="评论序号" InsertVisible="False" 
            ReadOnly="True" SortExpression="ID" />
        <asp:TemplateField HeaderText="新闻ID">
            <ItemTemplate>
                    <a href='newscontent.aspx?newsid=<%# Eval("NewsID") %>'><%# Eval("NewsID") %></a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="评论内容" SortExpression="Contents">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Contents") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
              <%--  <asp:Label ID="Label1" runat="server" Text='<%# Bind("Contents") %>'></asp:Label>--%>
                 <a href='newscontent.aspx?newsid=<%#Eval("newsID") %>' target="_blank" title='<%# Eval("Contents") %>'>
                                <%#StringTruncat(Eval("Contents").ToString(), 18, "...")%></a>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="status" HeaderText="审核结果" ReadOnly="true" />

        <asp:CommandField HeaderText="操作" ShowDeleteButton="True" 
            ShowEditButton="True" />
    </Columns>
           
        
</asp:GridView>

<h4>评论审核</h4>
<asp:GridView ID="gvStatus" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="ID" EmptyDataText="暂无需审核的评论">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="评论序号" InsertVisible="False" 
            ReadOnly="True" SortExpression="ID" />
        <asp:TemplateField HeaderText="新闻ID">
            <ItemTemplate>
                    <a href='newscontent.aspx?newsid=<%# Eval("NewsID") %>'><%# Eval("NewsID") %></a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="评论内容" SortExpression="Contents">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1"  runat="server"  Text='<%# Bind("Contents") %>'></asp:TextBox>
             
            </EditItemTemplate>
            <ItemTemplate>
<%--                <asp:Label ID="Label1" runat="server"  Text='<%# Eval("Contents") %>'><%#StringTruncat(Eval("Contents").ToString(),18,"...") %></asp:Label>
--%>       <a href='newscontent.aspx?newsid=<%#Eval("newsID") %>' target="_blank" title='<%# Eval("Contents") %>'>
                                <%#StringTruncat(Eval("Contents").ToString(), 18, "...")%></a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="status" HeaderText="是否审核" />
        <asp:TemplateField HeaderText="审核">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnYes" runat="server" CausesValidation="false" 
                     CommandArgument='<%# Eval("ID") %>' Text="通过" OnClick="lbtnYes_Click"></asp:LinkButton> |
                     
                     <asp:LinkButton ID="lbtnNo" runat="server" CausesValidation="false" 
                     CommandArgument='<%# Eval("ID") %>' Text="未通过" OnClick="lbtnNo_Click"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:CMSConnectionString %>" 
    DeleteCommand="DELETE FROM [tComment] WHERE [ID] = @ID" 
    InsertCommand="INSERT INTO [tComment] ([NewsID], [Contents], [Status]) VALUES (@NewsID, @Contents, @Status)" 
    SelectCommand="SELECT [ID], [NewsID], [Contents], [Status] FROM [tComment] WHERE (([Status] NOT LIKE '%' + @Status + '%') AND ([Status] = @Status2)) ORDER BY [AddDate] DESC" 
    
    
    
    UpdateCommand="UPDATE [tComment] SET [Contents] = @Contents WHERE [ID] = @ID">
   
    <SelectParameters>
        <asp:Parameter DefaultValue="未审核" Name="Status" Type="String" />
        <asp:ControlParameter ControlID="DropDownList1" Name="Status2" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="NewsID" Type="Int32" />
        <asp:Parameter Name="Contents" Type="String" />
        <asp:Parameter Name="Status" Type="String" />
        <asp:Parameter Name="ID" Type="Int32" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="NewsID" Type="Int32" />
        <asp:Parameter Name="Contents" Type="String" />
        <asp:Parameter Name="Status" Type="String" />
    </InsertParameters>
</asp:SqlDataSource>