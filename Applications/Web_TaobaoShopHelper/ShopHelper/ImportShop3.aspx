<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHelper/_ShopHelper.master"
    AutoEventWireup="true" CodeBehind="ImportShop3.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ImportShop3" %>

<%@ Register Src="~/WebControls/Common/CtrlCredit.ascx" TagName="CtrlCredit" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeaderHolder" runat="server">
    <span>导入店铺 - 设置</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentHolder" runat="server">
    <div>
        <div class="DisplayBlock">
            <div class="BlockHeader">
                <span>导入信息预览</span></div>
            <div class="BlockShopImage">
                <asp:Image ID="imgShop" runat="server" /></div>
            <div class="BlockList">
                <ul>
                    <li><span class="Caption">卖家昵称</span><asp:Label ID="lblNick" runat="server"></asp:Label></li>
                    <li><span class="Caption">店铺标题</span><asp:Label ID="lblShopTitle" runat="server"></asp:Label></li>
                    <li><span class="Caption">店铺宝贝总数</span><asp:Label ID="lblItemCount" runat="server"></asp:Label></li>
                    <li><span class="Caption">即将导入的宝贝总数</span><asp:Label ID="lblImportCount" runat="server"></asp:Label></li>
                    <li><span class="Caption">创建日期：</span><asp:Label ID="lblCreateDate" runat="server"></asp:Label></li>
                    <li><span class="Caption">最后更新日期：</span><asp:Label ID="lblUpdateDate" runat="server"></asp:Label></li>
                </ul>
            </div>
        </div>
        <div class="DisplayBlock">
            <div class="BlockHeader">
                <span>导入配置</span></div>
            <div class="BlockContent">
                <div>
                    <span>如果宝贝曾经导入过</span>
                </div>
                <div>
                    <asp:RadioButton ID="rbtnIgnore" runat="server" Text="跳过" GroupName="ItemOption"
                        Checked="true" />
                    <asp:RadioButton ID="rbtnNew" runat="server" GroupName="ItemOption" Text="新增导入" />
                    <asp:RadioButton ID="rbtnUpdate" runat="server" GroupName="ItemOption" Text="更新宝贝" />
                    <asp:CheckBox ID="cbNew" runat="server" Text="如果淘宝中没有此宝贝，则添加一个" />
                </div>
                <div>
                    <span>宝贝导入以后</span>
                </div>
                <div>
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="放入仓库" GroupName="ItemLocation"
                        Checked="true" />
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="ItemLocation" Text="直接上架" />
                </div>
                <div>
                    <span>宝贝价格调整</span>
                </div>
                <div>
                    <asp:RadioButton ID="rbtnPrice_Copy" runat="server" Text="保持原价格" GroupName="ItemPrice"
                        Checked="true" />
                    <asp:RadioButton ID="rbtnPrice_Add" runat="server" GroupName="ItemPrice" Text="在原价格基础上增加/减少" />
                    <span>要增加的价格：</span><asp:TextBox ID="txtPriceAdd" runat="server"></asp:TextBox><span
                        class="Tip">* 负数表示减少</span>
                    <asp:RadioButton ID="rbtnPrice_Rate" runat="server" GroupName="ItemPrice" Text="在原价格基础上乘以百分比" />
                    <span>要乘以的百分比：</span><asp:TextBox ID="txtPriceRate" runat="server"></asp:TextBox><span
                        class="Tip">* 只需要输入数字部分。如：120%，只需要输入120即可。</span>
                </div>
                <div>
                    <span>宝贝名称调整</span>
                </div>
                <div>
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="保持原名称" GroupName="ItemName"
                        Checked="true" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="ItemName" Text="如果名称包含指定文字，则做替换" />
                    <span>将文字：</span><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><span>替换为</span><asp:TextBox
                        ID="TextBox2" runat="server"></asp:TextBox><span
                        class="Tip">* 可指定多个文本替换，以","分开，并匹配对应的文本。如要将"沙发"替换为"茶几"，以及将"格格屋"替换为"小店"：前面的文本框输入"沙发,格格屋"，被替换的文本框输入"茶几,小店"。</span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <ul>
        <li>
            <asp:HyperLink ID="hlnkPrev" runat="server"><span>上一步</span></asp:HyperLink></li>
        <li>
            <asp:LinkButton ID="lbtnImport" runat="server" OnClick="lbtnImport_Click"><span>导入店铺</span></asp:LinkButton></li>
    </ul>
</asp:Content>
