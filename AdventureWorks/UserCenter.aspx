<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="UserCenter.aspx.cs" Inherits="UserCenter" EnableEventValidation="false" %>

<%@ Register Src="~/Controls/Password.ascx" TagPrefix="uc1" TagName="Password" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/UserCenter.css" type="text/css" rel="stylesheet">
    <div class="UC-content">
        <div class="UC-side">
            <ul>
                <li>
                    <asp:LinkButton ID="lbPinfo" runat="server" OnClick="lbPinfo_Click">个人信息</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="lblPpwd" runat="server" OnClick="lblPpwd_Click">修改密码</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="lblPcomment" runat="server" OnClick="lblPcomment_Click">评论管理</asp:LinkButton>
                </li>
            </ul>
        </div>
        <div class="UCp">
            <asp:Panel ID="UCPinfo" CssClass="UCPinfo" runat="server">
                <table>
                    <tr style="border-bottom: 1px solid;">
                        <td >
                            <img src="../images/userinfoheader.jpg" alt="头像">
                        </td>
                        <td>
                            <asp:Label ID="UClbID" CssClass="UClbID" runat="server"></asp:Label>
                        </td>
                        <td style="width:100%"></td>
                    </tr>
                    <tr>
                        <td class="UClefttd">
                            <div class="UClefttdcon">
                                用户名：
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="UCtxtname" CssClass="UCtxt ban" runat="server" disabled="disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="UClefttd">
                            <div class="UClefttdcon">
                                邮箱：
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="UCtxtEmail" CssClass="UCtxt" runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="UCtxtEmail" Display="Dynamic" ValidationGroup="info"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="邮箱格式不正确" ControlToValidate="UCtxtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="info"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="UClefttd">
                            <div class="UClefttdcon">
                                昵称：
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="UCtxtID" CssClass="UCtxt" runat="server" Text="" ReadOnly="true" AutoPostBack="True" OnTextChanged="UCtxtID_TextChanged"></asp:TextBox>
                        </td>
                        <td class="aabc">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UCtxtID" ErrorMessage="*" ValidationGroup="info"></asp:RequiredFieldValidator>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="UCtxtID" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="UCbtnOK" CssClass="UCbtn UCbtnOK" runat="server" Text="确认" OnClick="UCbtnOK_Click" />
                            <asp:Button ID="UCbtnCancle" CssClass="UCbtn UCbtnCancle" runat="server" Text="取消" OnClick="UCbtnCancle_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="UCbtnchangeinfo" CssClass="UCbtn wid" runat="server" Text="修改个人信息" OnClick="UCbtnchangeinfo_Click" />
                        </td>
                    </tr>
                </table>

            </asp:Panel>
            <asp:Panel ID="UCPpwd" runat="server">
                <uc1:Password runat="server" ID="Password" />
            </asp:Panel>
            <asp:Panel ID="UCPcomment" runat="server">
                comment
            </asp:Panel>
        </div>
    </div>

    <script>
        //登陆注册弹出框开始

        const body = document.querySelector('body');
        const modal = document.querySelector('.modal');
        const modalButton = document.querySelector('.modal-button');
        const closeButton = document.querySelector('.UC-content');
        let isOpened = false;

        const openModal = () => {
            modal.classList.add('is-open');
            /*body.style.overflow = 'hidden';*/
        };

        const closeModal = () => {
            modal.classList.remove('is-open');
            /*body.style.overflow = 'initial';*/
        };

        //window.addEventListener('scroll', () => {
        //  if (window.scrollY > window.innerHeight / 3 && !isOpened) {
        //    isOpened = true;
        //    scrollDown.style.display = 'none';
        //    openModal();
        //  }
        //});

        modalButton.addEventListener('mouseover', openModal);
        closeButton.addEventListener('mouseover', closeModal);

        document.onkeydown = (evt) => {
            evt = evt || window.event;
            evt.keyCode === 27 ? closeModal() : false;
        };
    </script>
</asp:Content>

