﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/_Template.master"
    AutoEventWireup="true" CodeBehind="Set.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.Templates.Set" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeaderHolder" runat="server">
    <span>模板配置</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentHolder" runat="server">
    <div class="WaittingList">
        <ul>
            <li class="New">
                <asp:HyperLink ID="hlinkCreate" runat="server" Text="添加模板" NavigateUrl="Set.aspx"></asp:HyperLink></li>
            <asp:Repeater ID="rptTemplateList" runat="server">
                <ItemTemplate>
                    <li class=''>
                        <asp:HyperLink ID="hlnk" runat="server" Text='<%# Eval("Name") %>' NavigateUrl=''></asp:HyperLink></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="TemplateArea">
        <div class="Title">
            <asp:Label ID="lblTitle" runat="server" Text="添加宝贝模板"></asp:Label>
        </div>
        <div class="Content">
            <div class="LayoutRow">
                <span>模板名称</span><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div class="LayoutRow">
                <span>模板文件</span><asp:FileUpload ID="fuFile" runat="server" />
                <span class="Description">* 支持*.html,*.htm,*.txt格式，文件大小限制50K。</span>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">保存模板</asp:LinkButton>
    <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">取消</asp:LinkButton>
</asp:Content>
