<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="ResponseGetMoney.aspx.cs" Inherits="Admin_ResponseGetMoney" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div>
            <span>用户提款请求</span>
        </div>
        <asp:GridView ID="gvRequestList" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="用户" />
                <asp:BoundField DataField="RequestMoney" DataFormatString="{0:0.00}" 
                    HeaderText="提款金额" />
                <asp:BoundField DataField="RequestTime" 
                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="申请时间" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                    DataNavigateUrlFormatString="~/Admin/ResponseGetMoneyView.aspx?rid={0}" 
                    Text="处理提款申请" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
