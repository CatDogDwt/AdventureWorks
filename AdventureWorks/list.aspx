<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/list.css" type="text/css" rel="stylesheet" />
    <div class="listcontent">
        <h2>
            <asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label>
        </h2>
        <asp:GridView ID="gvListNews" CssClass="gvListNews" runat="server" AutoGenerateColumns="False" BorderWidth="0px" GridLines="None" EmptyDataText="该分类下暂无新闻" AllowPaging="True">
            <columns>
                <asp:TemplateField>
                    <itemtemplate>
                        <div class="listicon">
                        </div>
                        <a href='newscontent.aspx?newsid=<%#Eval("ID") %>' target="_blank" title='<%# Eval("Title") %>'><%#StringTruncat(Eval("Title").ToString(),18,"...") %></a>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <itemtemplate>
                        <asp:Label ID="Label3" CssClass="date-views-color" runat="server" Text='<%# Bind("AddDate") %>'></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <itemtemplate>
                        <asp:Label ID="Label4" CssClass="date-views-color" runat="server" Text='<%# Bind("LiuLan") %>'></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
            </columns>
        </asp:GridView>
    </div>
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
        const closeButton = document.querySelector('.listcontent');
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

