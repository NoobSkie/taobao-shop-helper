<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="CollectionManagement.aspx.cs" Inherits="Admin_CollectionManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div>
        <asp:HyperLink ID="hlnkAdd" runat="server">添加</asp:HyperLink>
    </div>
    <div>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="名称/标题" />
                <asp:BoundField DataField="PublishDate" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" HeaderText="发布时间" />
                <asp:BoundField DataField="LastUpdateDate" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" HeaderText="最后更新时间" />
                <asp:HyperLinkField DataNavigateUrlFields="ItsCollectionId,Id" DataNavigateUrlFormatString="CollectionEdit.aspx?t=e&cid={0}&id={1}"
                    Text="编辑" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>
</asp:Content>
