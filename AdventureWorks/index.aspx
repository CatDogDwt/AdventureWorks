<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/index.css" rel="stylesheet" />
    <link href="css/UserInfo.css" rel="stylesheet" />
    <div class="index_content">
        <div class="top">
            <div class="new-title">最新新闻</div>
            <div class="new-left">
                <div class="b"></div>
                <div class="c">
                    <div class="d dd">
                        <img src="images/1.jpg" alt="">
                    </div>
                    <div class="d">
                        <img src="images/2.jpg" alt="">
                    </div>
                    <div class="d">
                        <img src="images/3.jpg" alt="">
                    </div>
                    <div class="d">
                        <img src="images/4.jpg" alt="">
                    </div>
                    <div class="d">
                        <img src="images/5.jpg" alt="">
                    </div>
                </div>
            </div>
            <div class="new-right">
                <asp:GridView ID="gvNewNews" CssClass="gvNewNews" runat="server" AutoGenerateColumns="False" GridLines="None" EmptyDataText="暂无新闻">
                    <columns>
                        <%--新闻类别--%>
                        <asp:TemplateField ItemStyle-CssClass="gvNewNewsID">
                            <itemtemplate>
                                <a href='list.aspx?CategoryID=<%# Eval("CategoryID") %>'><%# Eval("CategoryName") %></a>
                            </itemtemplate>
                        </asp:TemplateField>
                        <%--新闻标题--%>
                        <asp:TemplateField ItemStyle-CssClass="gvNewNewsTit">
                            <itemtemplate>
                                <a href='newscontent.aspx?newsid=<%#Eval("ID") %>' target="_blank" title='<%# Eval("Title") %>'>
                                    <%#StringTruncat(Eval("Title").ToString(),18,"...") %></a>
                            </itemtemplate>
                        </asp:TemplateField>
                    </columns>
                </asp:GridView>
            </div>
        </div>
        <div class="down">
            <div class="hot-title">热点新闻</div>
            <div class="hot-news">
                <div class="hot-news-content">
                    <asp:DataList ID="gvHotNews" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" OnItemCommand="gvHotNews_ItemCommand" RepeatColumns="4">
                        <itemtemplate>
                            <div class="HOTDL">
                                <div class="pic">
                                    <asp:ImageButton CssClass="HOTDL-IMG" ID="ImageButton1" runat="server" CommandArgument='<%# Eval("ID") %>' ImageUrl='<%# Eval("Photo") %>' CommandName="详情"></asp:ImageButton>
                                </div>
                                <div class="info">
                                    <h1 class="downhotnewstitle">
                                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' ></asp:Label>
                                    </h1>
                                    <p class="downhotnewscontent">
                                        <asp:Label ID="ContentLabel" runat="server" Text='<%# Eval("Contents") %>' ></asp:Label>
                                    </p>
                                    <span class="hotsp">
                                        <asp:Label ID="ReferInfoLabel" runat="server" Text='<%# Eval("ReferInfo") %>' ></asp:Label>
                                        <b>
                                            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("AddDate") %>'></asp:Label>
                                        </b>
                                    </span>
                                </div>
                            </div>
                        </itemtemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMSConnectionString %>" SelectCommand="SELECT [Title], [ReferInfo], [ID], [Photo], [AddDate], [Contents] FROM [tNews]"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
    <script>
        // 获取左边大图的元素
        let b = document.querySelector(".b")
        // 获取右边小图的所有元素
        let d = document.getElementsByClassName("d")

        let time
        let index = 0

        // 设置一个重置函数
        let a = function () {
            for (let i = 0; i < d.length; i++) {
                d[i].className = "d"
            }
        }
        // 设置一个选中函数
        let aa = function () {
            // 先代入重置函数
            a()
            d[index].className = "d dd"
        }
        // 设置启动轮播图的时间函数
        function ts() {
            time = setInterval(function () {
                aa()
                index++
                b.style.backgroundImage = "url('images/" + [index] + ".jpg')"
                if (index == 5) {
                    index = 0
                }
            }, 1600);
        }
        for (let i = 0; i < d.length; i++) {
            // 鼠标移动到当前小图片上时触发
            d[i].onmousemove = function () {
                // 鼠标移动到当前小图片时右边大图片变成当前的小图片
                b.style.backgroundImage = "url('images/" + [i + 1] + ".jpg')"
                // 鼠标移动到小图片上面时关闭定时器并重置定时，
                // 鼠标移开后再继续执行
                a()
                clearInterval(time)
                index = i + 1
                ts()
            }
        }
        // 执行轮播图
        ts()

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
    </script>
</asp:Content>

