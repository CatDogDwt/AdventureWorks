<%@ Control Language="C#" AutoEventWireup="true" CodeFile="release.ascx.cs" Inherits="Controls_release" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<link href="../css/release.css" type="text/css" rel="stylesheet" />
<table class="releasetb">
    <tr>
        <td>新闻标题：</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="40" Width="395px" CssClass="text"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtTitle" ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>新闻类别：</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server"
                DataSourceID="SqlDataSource1" DataTextField="CategoryName"
                DataValueField="CategoryName">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:CMSConnectionString2 %>"
                SelectCommand="SELECT [CategoryName] FROM [tNewsCategory]"></asp:SqlDataSource>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>新闻内容：</td>
        <td>
            <FTB:FreeTextBox ID="ftxtContents" runat="server" Height="250px"
                ImageGalleryPath="~/image/"
                ImageGalleryUrl="../ftb.imagegallery.aspx?rif={0}&amp;cif={0}" Language="zh-CN"
                RemoveServerNameFromUrls="True"
                ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                Width="350px">
            </FTB:FreeTextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>新闻出处：</td>
        <td>
            <asp:TextBox ID="txtReferInfo" runat="server" MaxLength="40" CssClass="text"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnRelease" runat="server" OnClick="btnRelease_Click"
                Text="发布新闻" ValidationGroup="1" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
