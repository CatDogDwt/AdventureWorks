<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Password.ascx.cs" Inherits="Controls_Password" %>
<h4>修改密码</h4>
<table>
    <tr>
        <td>用户名：</td>
        <td>
            <asp:Label ID="lblUserLoginID" runat="server"></asp:Label>
        </td>
        <td></td>
    </tr>
    <tr>
        <td style="text-align: right">旧密码：</td>
        <td style="text-align: left">
            <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="txtOldPwd" ErrorMessage="*" ValidationGroup="pwd"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>新密码：</td>
        <td style="text-align: left">
            <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ControlToValidate="txtNewPwd" ErrorMessage="*" ValidationGroup="pwd"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>确认密码：</td>
        <td>
            <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ControlToValidate="txtNewPwd2" ErrorMessage="*" Display="Dynamic"
                ValidationGroup="pwd"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server"
                ControlToCompare="txtNewPwd" ControlToValidate="txtNewPwd2" Display="Dynamic"
                ErrorMessage="两次输入不一致" ValidationGroup="pwd"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnPwdSave" runat="server" OnClick="btnPwdSave_Click"
                Text="保存" ValidationGroup="pwd" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
