<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryManagement.ascx.cs" Inherits="Controls_CategoryManagement" %>
<%@ Register assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<h4>分类管理</h4>
<asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="False"
    DataKeyNames="id" OnRowDeleting="gvCategory_RowDeleting"
    EmptyDataText="暂无分类" OnRowCancelingEdit="gvCategory_RowCancelingEdit"
    OnRowEditing="gvCategory_RowEditing" OnRowUpdating="gvCategory_RowUpdating">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="类别序号" ReadOnly="true" />
        <asp:TemplateField HeaderText="类别名称">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" MaxLength="4" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>


        <asp:CommandField ShowEditButton="True" HeaderText="编辑" />
        <asp:TemplateField HeaderText="是否显示">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnYes" runat="server" CausesValidation="false"
                    CommandArgument='<%# Eval("id") %>' Text='<%# Eval("Status") %>' OnClick="lbtnYes_Click"></asp:LinkButton>

            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False" HeaderText="删除" Visible="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                    CommandName="Delete" OnClientClick="return confirm('所在类别下的新闻和评论将全部删除！')" Text="删除"></asp:LinkButton>
            </ItemTemplate>

        </asp:TemplateField>
    </Columns>
</asp:GridView>

<h4>添加类别</h4>
<table>
    <tr>
        <td style="text-align: right">类别名称：</td>
        <td style="text-align: left">
            <asp:TextBox ID="txtCategoryAdd" CssClass="text" runat="server" ValidationGroup="add"
                MaxLength="4"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtCategoryAdd" ErrorMessage="请输入类别名称" ValidationGroup="add">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td style="text-align: left">
            <asp:Button ID="btnAdd" runat="server" Text="添加" ValidationGroup="add"
                OnClick="btnAdd_Click" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="add" />
        </td>
    </tr>
</table>
