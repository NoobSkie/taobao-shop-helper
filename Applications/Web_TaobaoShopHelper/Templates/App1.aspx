<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/_Template.master"
    AutoEventWireup="true" CodeBehind="App1.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.Templates.App1" %>

<%@ Register Src="~/WebControls/Common/CtrlPager.ascx" TagName="CtrlPager" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">

    <script type="text/javascript">

        function CheckAll(obj) {
            var baseId = '<%= rptItemList.ClientID %>';
            var index = 1;
            var id = baseId + "_ctl" + GetPadRight(index) + "_cbCheck";
            var cb = document.getElementById(id);
            while (cb) {
                cb.checked = obj.checked;
            
                index++;
                id = baseId + "_ctl" + GetPadRight(index) + "_cbCheck";
                cb = document.getElementById(id);
            }
        }

        function GetPadRight(num) {
            if (num < 10) {
                return '0' + num.toString();
            }
            else {
                return num.toString();
            }
        }
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeaderHolder" runat="server">
    <span>选择应用模板的宝贝</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentHolder" runat="server">
    <div class="LeftRightView">
        <div class="LeftArea">
            <asp:TreeView ID="tvCategory" CssClass="TreeView" runat="server" ImageSet="XPFileExplorer"
                NodeIndent="18" Width="180">
                <ParentNodeStyle Font-Bold="False" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                    VerticalPadding="0px" />
                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                    NodeSpacing="0px" VerticalPadding="2px" Height="22px" />
                <Nodes>
                    <asp:TreeNode Text="出售中的宝贝" Value="onsale" SelectAction="None">
                        <asp:TreeNode Text="全部" Value="all"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="仓库里的宝贝" Value="inventory" SelectAction="None">
                        <asp:TreeNode Text="全部" Value="all"></asp:TreeNode>
                        <asp:TreeNode Text="没卖出的" Value="unsold"></asp:TreeNode>
                        <asp:TreeNode Text="部分卖出的" Value="partly_sold"></asp:TreeNode>
                        <asp:TreeNode Text="全部卖完的" Value="sold_out"></asp:TreeNode>
                        <asp:TreeNode Text="我下架的" Value="off_shelf"></asp:TreeNode>
                        <asp:TreeNode Text="定时上架的" Value="regular_shelved"></asp:TreeNode>
                        <asp:TreeNode Text="从未上架的" Value="never_on_shelf"></asp:TreeNode>
                        <asp:TreeNode Text="等待所有上架的" Value="for_shelved"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
        <div class="RightArea">
            <div class="HeaderArea">
                <div class="Field FieldRow">
                    <div class="Field FieldItem">
                        <span class="Caption">宝贝名称</span>
                        <asp:TextBox ID="txtQuery" CssClass="Input" runat="server"></asp:TextBox>
                    </div>
                    <div class="Field FieldItem">
                        <asp:CheckBox ID="cbDiscount" CssClass="Input" runat="server" Text="参与会员折扣" />
                    </div>
                    <div class="Field FieldItem">
                        <asp:CheckBox ID="cbShowCase" CssClass="Input" runat="server" Text="橱窗推荐" />
                    </div>
                    <div class="Field FieldItem">
                        <asp:LinkButton ID="lbtnSearch" CssClass="Submit" runat="server" Text="搜索" OnClick="lbtnSearch_Click"></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="OptionArea">
            </div>
            <div class="ContentArea">
                <div class="ItemList">
                    <asp:Repeater ID="rptItemList" runat="server">
                        <HeaderTemplate>
                            <div class="ListHeader">
                                <asp:CheckBox ID="cbCheckAll" onclick="CheckAll(this);" runat="server" Text="全选" />
                                <asp:CheckBox ID="cbCheckUnTemplate" runat="server" Text="选择未设置过模板的宝贝" />
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="Item_List">
                                <div class="Partten CheckPartten">
                                    <asp:CheckBox ID="cbCheck" runat="server" />
                                    <asp:HiddenField ID="hiddIid" runat="server" Value='<%# Eval("Iid") %>' />
                                </div>
                                <div class="Partten ImagePartten">
                                    <asp:Image ID="imgItem" ImageUrl='<%# Eval("PicPath") %>' runat="server" />
                                </div>
                                <div class="Partten TitlePartten">
                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="PagerArea">
                <uc2:CtrlPager ID="ucCtrlPager" PageSize="20" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <asp:LinkButton ID="lblNext" runat="server" OnClick="lblNext_Click">下一步</asp:LinkButton>
</asp:Content>
