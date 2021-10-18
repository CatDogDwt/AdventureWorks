<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="UserManage" %>

<%@ Register Src="~/Controls/release.ascx" TagPrefix="uc1" TagName="release" %>
<%@ Register Src="~/Controls/UserNews.ascx" TagPrefix="uc1" TagName="UserNews" %>
<%@ Register Src="~/Controls/UserComment.ascx" TagPrefix="uc1" TagName="UserComment" %>
<%@ Register Src="~/Controls/Password.ascx" TagPrefix="uc1" TagName="Password" %>
<%@ Register Src="~/Controls/CategoryManagement.ascx" TagPrefix="uc1" TagName="CategoryManagement" %>
<%@ Register Src="~/Controls/CommentManagement.ascx" TagPrefix="uc1" TagName="CommentManagement" %>
<%@ Register Src="~/Controls/UserManagement.ascx" TagPrefix="uc1" TagName="UserManagement" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="stylesheet" href="layui-v2.6.8/layui-v2.6.8/layui/css/layui.css" media="all" />
    <link rel="shortcut icon" type="images/x.ico" href="images/adminicon.png" media="screen" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="layui-layout layui-layout-admin">
            <div class="layui-header">
                <div class="layui-logo layui-hide-xs layui-bg-black">新闻发布后台管理</div>
                <ul class="layui-nav layui-layout-right">
                    <li class="layui-nav-item layui-hide layui-show-md-inline-block">
                        <a href="javascript:;">
                            <img src="images/adminheader.png" class="layui-nav-img" />
                            管理员
                        </a>
                        <dl class="layui-nav-child">
                            <dd>
                                <asp:LinkButton ID="lbtnInfo" runat="server" OnClick="lbtnInfo_Click">个人设置</asp:LinkButton>
                            </dd>
                            <dd>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">退出登录</asp:LinkButton>
                            </dd>
                        </dl>
                    </li>
                </ul>
            </div>

            <div class="layui-side layui-bg-black">
                <div class="layui-side-scroll">
                    <ul class="layui-nav layui-nav-tree" lay-filter="test">
                        <li class="layui-nav-item layui-nav-itemed">
                            <a class="" href="javascript:;">新闻管理</a>
                            <dl class="layui-nav-child">
                                <dd>
                                    <asp:LinkButton ID="lbtnFaBu" runat="server" OnClick="lbtnFaBu_Click">发布新闻</asp:LinkButton>
                                </dd>
                                <dd>
                                    <asp:LinkButton ID="lbtnSort" runat="server" OnClick="lbtnSort_Click">分类管理</asp:LinkButton>
                                </dd>
                                <dd>
                                    <asp:LinkButton ID="lbtnNews" runat="server" OnClick="lbtnNews_Click">新闻管理</asp:LinkButton>
                                </dd>
                                <dd>
                                    <asp:LinkButton ID="lbtnComment" runat="server" OnClick="lbtnComment_Click">评论管理</asp:LinkButton>
                                </dd>
                            </dl>
                        </li>
                        <li class="layui-nav-item">
                            <asp:LinkButton ID="lblUM" runat="server" OnClick="lblUM_Click">用户管理</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="layui-body">
                <div style="padding: 15px;">
                    <uc1:CategoryManagement runat="server" ID="CategoryManagement" />
                    <uc1:release runat="server" ID="release" />
                    <uc1:CommentManagement runat="server" ID="CommentManagement" />
                    <uc1:UserNews runat="server" ID="UserNews" />
                    <%--<uc1:UserComment runat="server" ID="UserComment" />--%>
                    <uc1:Password runat="server" ID="Password" />
                    <uc1:UserManagement runat="server" ID="UserManagement" />
                </div>
            </div>

            <div class="layui-footer" style="text-align:center">
                @新闻发布管理系统 后台管理
            </div>
        </div>
        <script src="layui-v2.6.8/layui-v2.6.8/layui/layui.js"></script>
        <script>
            layui.use(['element', 'layer', 'util'], function () {
                var element = layui.element
                    , layer = layui.layer
                    , util = layui.util
                    , $ = layui.$;
                util.event('lay-header-event', {
                    menuLeft: function (othis) {
                        layer.msg('展开左侧菜单的操作', { icon: 0 });
                    }
                });

            });
        </script>
    </form>
</body>
</html>
