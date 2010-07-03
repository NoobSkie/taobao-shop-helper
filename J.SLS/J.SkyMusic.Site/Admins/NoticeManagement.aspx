<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="NoticeManagement.aspx.cs" Inherits="Admins_NoticeManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="noticemanagement.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="Summary">
        <asp:Label ID="lblTitle" runat="server" Text="通知管理"></asp:Label>
    </div>
    <div class="Content">
        <div class="Operator">
            <asp:HyperLink ID="hlnkAdd" NavigateUrl="EditNotice.aspx" runat="server"><span>新增通知</span></asp:HyperLink>
        </div>
        <div class="ListDiv">
            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                <HeaderTemplate>
                    <div class="THeader">
                        <span class="Name">列表名称</span><span class="Code">开始时间</span><span class="Code">结束时间</span><span
                            class="Boolean">有明细</span><span class="Boolean">标红</span><span class="Boolean">加粗</span><span
                                class="Boolean">已结束</span><span class="Link"></span>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="TRow">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="Code" runat="server"><%# Eval("StartTime")%></asp:Label>
                        <asp:Label ID="Label1" CssClass="Code" runat="server"><%# Eval("EndTime")%></asp:Label>
                        <asp:Label ID="Label2" CssClass="Boolean" runat="server"><%# Eval("IsHasDetail")%></asp:Label>
                        <asp:Label ID="Label3" CssClass="Boolean" runat="server"><%# Eval("IsForeBold")%></asp:Label>
                        <asp:Label ID="Label4" CssClass="Boolean" runat="server"><%# Eval("IsForeRed")%></asp:Label>
                        <asp:Label ID="Label5" CssClass="Boolean" runat="server"><%# Eval("IsEnd")%></asp:Label>
                        <span class="Link">
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# Eval("Id", "EditNotice.aspx?id={0}") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                OnClientClick=<%# Eval("Name", "return confirm('确定删除此通知吗？ - {0}');") %> runat="server">删除</asp:LinkButton></span>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="TRow Alternating">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="Code" runat="server"><%# Eval("StartTime")%></asp:Label>
                        <asp:Label ID="Label1" CssClass="Code" runat="server"><%# Eval("EndTime")%></asp:Label>
                        <asp:Label ID="Label2" CssClass="Boolean" runat="server"><%# Eval("IsHasDetail")%></asp:Label>
                        <asp:Label ID="Label3" CssClass="Boolean" runat="server"><%# Eval("IsForeBold")%></asp:Label>
                        <asp:Label ID="Label4" CssClass="Boolean" runat="server"><%# Eval("IsForeRed")%></asp:Label>
                        <asp:Label ID="Label5" CssClass="Boolean" runat="server"><%# Eval("IsEnd")%></asp:Label>
                        <span class="Link">
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# Eval("Id", "EditNotice.aspx?id={0}") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                OnClientClick=<%# Eval("Name", "return confirm('确定删除此通知吗？ - {0}');") %> runat="server">删除</asp:LinkButton></span>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
