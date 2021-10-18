<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserManagement.ascx.cs" Inherits="Controls_UserManagement" %>
<h4>用户管理</h4>
<p style="text-align: left">
    用户查询：<asp:TextBox ID="txtSelectUser" runat="server" ValidationGroup="user"
        MaxLength="20"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Font-Size="X-Small" ForeColor="Red"
        Text="根据用户名查询"></asp:Label>
    <asp:Button ID="btnSelectUser" runat="server" OnClick="btnSelectUser_Click" Style="margin-left: 20px"
        Text="查询" ValidationGroup="user" />
</p>
<asp:GridView ID="gvuser" runat="server" AutoGenerateColumns="False"
    DataKeyNames="id"
    EmptyDataText="暂无用户数据" OnRowDeleting="gvuser_RowDeleting">
    <Columns>
        <asp:BoundField DataField="UserLoginID" HeaderText="用户名" />
        <asp:BoundField DataField="UserName" HeaderText="昵称" />
        <asp:BoundField DataField="UserEmail" HeaderText="Email" />
        <asp:BoundField DataField="UserType" HeaderText="用户组" />
        <asp:HyperLinkField DataNavigateUrlFields="id"
            DataNavigateUrlFormatString="~/UserCenter.aspx?id={0}" HeaderText="修改"
            Text="修改" />
        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
    </Columns>

</asp:GridView>
