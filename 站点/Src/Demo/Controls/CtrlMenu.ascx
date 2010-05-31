<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlMenu.ascx.cs" Inherits="Controls_CtrlMenu" %>
<div id="header" class="MenuDiv">
    <div id="nav-main" class="yuimenubar">
        <div class="bd">
            <ul>
                <asp:Repeater ID="rptMenus" runat="server">
                    <ItemTemplate>
                        <li id="menu_products">
                            <asp:HyperLink ID="hlnkMenu1" runat="server" Text='<%# Eval("Name") %>'></asp:HyperLink>
                            <div class="yuimenu">
                                <div class="bd">
                                    <ul>
                                        <li id="submenu_firefox" class="yuimenuitem"><a href="javascript:void(0);">企业简介</a></li><li
                                            id="submenu_mobile" class="yuimenuitem"><a href="javascript:void(0);">师资情况</a></li><li
                                                id="submenu_thunderbird" class="yuimenuitem"><a href="javascript:void(0);">基地分布</a></li></ul>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
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
</div>
