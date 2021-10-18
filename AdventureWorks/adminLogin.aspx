<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="adminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/adminloginpage.css" type="text/css" rel="stylesheet" />
    <link rel="shortcut icon" type="images/x.ico" href="images/adminicon.png" media="screen" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login-form">
                <div class="text">管理员</div>
                <div class="form-item">
                    <table class="admintb">
                        <tr>
                            <td class="adminLogin-left">用户名:</td>
                            <td>
                                <asp:TextBox ID="txtAdminName" CssClass="Admintxt" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="adminLogin-left">密码:</td>
                            <td>
                                <asp:TextBox ID="txtAdminPwd" CssClass="Admintxt" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Button ID="Button1" CssClass="btn" runat="server" Text="登录" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>
