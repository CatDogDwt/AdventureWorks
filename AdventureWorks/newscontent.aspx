<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="newscontent.aspx.cs" Inherits="newscontent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/newscontent.css" type="text/css" rel="stylesheet" />
    <div class="middlecontentnews">
        <div class="newscontent">
            <h4>
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </h4>
            <p class="con_time">
                作者:<asp:Label ID="lblAuthor" runat="server" Text=""></asp:Label>发布时间:<asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
            </p>
            <br />
            <p class="con">
                <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
            </p>
        </div>
        <div id="newsreplay" class="commonfrm">
            <h4>评论</h4>
            <div class="addcomment">
                <asp:TextBox ID="txtComment" runat="server" CssClass="txtcomment" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:Button ID="btnSub" runat="server" CssClass="btnSub" Text="评论" OnClick="btnSub_Click" ValidationGroup="2" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="renc" ControlToValidate="txtComment" ErrorMessage="超出字符限制" ForeColor="Red" ValidationExpression="(\w|\W){1,50}" ValidationGroup="2"></asp:RegularExpressionValidator>
            </div>
            <asp:Repeater ID="repComment" runat="server">
                <ItemTemplate>
                    <div class="replay">
                        <div class="avtarbox">
                            <div class="avtarhead">
                                <%--此处应有用户头像--%>
                            </div>
                        </div>
                        <div class="newsrightcommon">
                            <p class="replay_time">
                                <%#Eval("username") %>
                            </p>
                            <p class="con">
                                <%#Eval("contents")%>
                            </p>
                            <p class="commentdate">
                                <%#Eval("adddate") %>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <br />

    <script>
        //搜索框滚动动画开始
        $(window).scroll(function () {
            if ($(window).scrollTop() > 100) {//这里100代表要动画的元素离最顶层的距离
                $('.returntop').addClass('returntop-active')
                $('.top-search').addClass('top-search-active txtsearchactive')
                /*$('.topimg').addClass('toprightactive')*/
                $('.txtSearch').addClass('disactive')
                $('.btnSearch').addClass('disactive')
            } else {
                $('.returntop').removeClass('returntop-active')
                $('.top-search').removeClass('top-search-active txtsearchactive')
                /*$('.topimg').removeClass('toprightactive')*/
                $('.txtSearch').removeClass('disactive')
                $('.btnSearch').removeClass('disactive')
            }

            if ($(window).scrollTop() > 1000) {
                $('.returntop').addClass('returntopposition')
            } else {
                $('.returntop').removeClass('returntopposition')
            }
        });
        //搜索框滚动动画结束

        //回到顶部按钮开始
        $(function () {
            //当点击跳转链接后，回到页面顶部位置
            $("#backtop").click(function () {
                if ($('html').scrollTop()) {
                    $('html').animate({ scrollTop: 0 }, 350);//动画效果
                    return false;
                }
                $('body').animate({ scrollTop: 0 }, 350);
                return false;
            });
        });
        //回到顶部按钮结束
        const body = document.querySelector('body');
        const modal = document.querySelector('.modal');
        const modalButton = document.querySelector('.modal-button');
        const closeButton = document.querySelector('.middlecontentnews');
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

        let login = document.querySelector(".login");
        let signup = document.querySelector(".signup");

        let loginbtn = document.querySelector(".loginbtn");
        let siginupbtn = document.querySelector(".signupbtn");

        let user = document.querySelector(".head");

        siginupbtn.addEventListener("click", () => {
            login.style.transform = "rotateY(180deg)"
            signup.style.transform = "rotateY(0deg)";

            user.innerHTML = "create account"
        })

        loginbtn.addEventListener("click", () => {
            login.style.transform = "rotateY(0deg)"
            signup.style.transform = "rotateY(-180deg)";

            user.innerHTML = "account login"
        })
    </script>
</asp:Content>

