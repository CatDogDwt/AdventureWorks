<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="Controls_UserInfo" %>

<link href="../css/UserInfo.css" type="text/css" rel="stylesheet">

<table class="userinfotb">
    <tr>
        <td colspan="2">
            <img src="../images/userinfoheader.jpg" alt="头像">
        </td>
    </tr>
    <tr>
        <td class="userinfoleft">昵称:</td>
        <td>
            <asp:Label ID="lblUserPetName" CssClass="lblUserPetName" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="userinfoleft">等级:</td>
        <td>
            <asp:Label ID="lblUserType" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:LinkButton ID="LinkButton1" CssClass="usercenter" runat="server" OnClick="LinkButton1_Click">个人中心</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnCancel" CssClass="userinfocancel" runat="server" Text="注销" OnClick="btnCancel_Click" />
        </td>
    </tr>
</table>
