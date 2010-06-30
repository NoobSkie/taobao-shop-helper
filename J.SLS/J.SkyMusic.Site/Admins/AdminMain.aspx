<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminMain.aspx.cs" Inherits="Admins_AdminMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理 - <%= SiteName %></title>
    <link href="layout.css" rel="stylesheet" type="text/css" />
    <link href="min.css" rel="stylesheet" type="text/css" />

    <script src="min.js" type="text/javascript"></script>

    <script type="text/javascript">

        function ShowSubPage(url) {
            iframe_sub.location.href = url;
            window.location.hash = "#" + url;
        }

        function AutoLoad() {
            var innerUrl = window.location.hash;
            if (innerUrl) {
                innerUrl = innerUrl.substr(1);
            }
            else {
                innerUrl = "Default.aspx";
            }
            ShowSubPage(innerUrl);
        }

        function SetIframeHeight() {
            // var a = iframe_sub.document.body.scrollHeight;
            var c = iframe_sub.document.documentElement.scrollHeight;
            document.getElementById('iframe_sub').style.height = c;
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div class="LogoDiv">
            <span>logo</span>
        </div>
        <div id="header" class="MenuDiv">
            <div id="nav-main" class="yuimenubar">
                <div class="bd">
                    <ul>
                        <li id="menu_products1"><a href="javascript:void(0);">添加子页面</a>
                            <div class="yuimenu">
                                <div class="bd">
                                    <ul>
                                        <asp:Repeater ID="rptAddPageMenu" runat="server">
                                            <ItemTemplate>
                                                <li id="menu_products2">
                                                    <asp:HyperLink ID="hlnkMenu1" NavigateUrl='<%# Eval("Id", "EditContent.aspx?lid={0}") %>'
                                                        Target="iframe_sub" runat="server"><%# Eval("Name") %></asp:HyperLink>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </li>
                        <li id="Li6"><a href="MenuManagement.aspx" target="iframe_sub">菜单管理</a>
                            <div class="yuimenu">
                                <div class="bd">
                                    <ul>
                                        <li id="Li7" class="yuimenuitem"><a href="MenuEdit.aspx" target="iframe_sub">添加菜单</a></li></ul>
                                </div>
                            </div>
                        </li>
                        <li id="Li1"><a href="ListManagement.aspx" target="iframe_sub">列表管理</a>
                            <div class="yuimenu">
                                <div class="bd">
                                    <ul>
                                        <li id="Li5" class="yuimenuitem"><a href="EditList.aspx" target="iframe_sub">添加新列表</a></li>
                                        <asp:Repeater ID="rptListManagerMenu" runat="server">
                                            <ItemTemplate>
                                                <li id="menu_products2">
                                                    <asp:HyperLink ID="hlnkMenu1" NavigateUrl='<%# Eval("Id", "EditList.aspx?id={0}") %>'
                                                        Target="iframe_sub" runat="server"><%# Eval("Name") %></asp:HyperLink>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </li>
                        <li id="Li8"><a href="javascript:void(0);">系统配置</a>
                            <div class="yuimenu">
                                <div class="bd">
                                    <ul>
                                        <li id="Li9" class="yuimenuitem"><a href="javascript:void(0);">修改后台管理密码</a></li>
                                        <li id="Li10" class="yuimenuitem"><a target="iframe_sub" href="SystemConfig.aspx">系统参数设置</a></li>
                                        <li id="Li2" class="yuimenuitem"><a href="javascript:void(0);">文件上传管理</a></li></ul>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <%--<div id="header" class="MenuDiv">
            <div id="nav-main" class="yuimenubar">
                <div class="bd">
                    <ul>
                        <li id="menu_products"><a href="javascript:void(0);">关于我们</a>
                            <div class="yuimenu">
                                <div class="bd">
                                    <ul>
                                        <li id="submenu_firefox" class="yuimenuitem"><a href="javascript:void(0);">企业简介</a></li><li
                                            id="submenu_mobile" class="yuimenuitem"><a href="javascript:void(0);">师资情况</a></li><li
                                                id="submenu_thunderbird" class="yuimenuitem"><a href="javascript:void(0);">基地分布</a></li></ul>
                                </div>
                            </div>
                        </li>
                        <li id="menu_addons" class="yuimenubaritem"><a href="javascript:void(0);">课程设置</a>
                            <div class="yuimenu">
                                <div class="bd">
                                    <ul>
                                        <li id="submenu_addons_all" class="yuimenuitem"><a href="javascript:void(0);">成人音乐教育</a></li><li
                                            id="submenu_addons_mobile" class="yuimenuitem"><a href="javascript:void(0);">中小学生音乐教育</a></li><li
                                                id="submenu_addons_recommended" class="yuimenuitem"><a href="javascript:void(0);">幼儿及家长音乐教育</a></li></ul>
                                </div>
                            </div>
                        </li>
                        <li id="menu_support" class="yuimenubaritem"><a href="javascript:void(0);">乐器租售</a>
                            <div class="yuimenu">
                                <div class="bd">
                                    <ul>
                                        <li id="submenu_support_kb" class="yuimenuitem"><a href="javascript:void(0);">钢琴</a></li><li
                                            id="submenu_support_mobile" class="yuimenuitem"><a href="javascript:void(0);">民族乐器</a></li><li
                                                id="submenu_support_thunderbird" class="yuimenuitem"><a href="javascript:void(0);">西洋乐器</a></li></ul>
                                </div>
                            </div>
                        </li>
                        <li id="menu_community" class="yuimenubaritem"><a href="javascript:void(0);">成果展示</a>
                            <div class="yuimenu">
                                <div class="bd">
                                    <ul>
                                        <li id="submenu_community_addons" class="yuimenuitem"><a href="javascript:void(0);">
                                            公司资讯</a></li><li id="submenu_community_bugzilla" class="yuimenuitem"><a href="javascript:void(0);">
                                                学员动态</a></li><li id="submenu_community_devmo" class="yuimenuitem"><a href="javascript:void(0);">
                                                    社会公益</a></li></ul>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>--%>
        <div class="Content">
            <iframe id="iframe_sub" name="iframe_sub" width="100%" frameborder="0" scrolling="no"
                onload="SetIframeHeight();"></iframe>
        </div>
        <div class="Footer">
            <span>footer</span>
        </div>
    </center>

    <script type="text/javascript">

        AutoLoad();
        
    </script>

    </form>
</body>
</html>
