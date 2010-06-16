<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WithMenuPage.master" AutoEventWireup="true"
    CodeFile="WithdrawView.aspx.cs" Inherits="Users_WithdrawView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div style="clear: both;">
        <div>
            <span>提款记录</span></div>
        <asp:GridView ID="gvRequestList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvRequestList_RowDataBound">
            <Columns>
                <asp:BoundField DataField="RequestMoney" DataFormatString="{0:0.00}" HeaderText="提款金额" />
                <asp:BoundField DataField="RequestTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"
                    HeaderText="申请时间" />
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="审核时间" DataField="ResponseTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                <asp:BoundField HeaderText="审核者" DataField="ResponseUserName" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
