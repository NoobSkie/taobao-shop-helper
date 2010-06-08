<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="MenuEdit.aspx.cs" Inherits="Admins_MenuEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="menuedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function TopMenuChanged(menuId) {
            if (menuId == "") {
                if (document.getElementById("<%= rbtnAuto.ClientID %>").checked) {
                    document.getElementById("<%= rbtnInner.ClientID %>").checked = true;
                    document.getElementById("<%= rbtnInner.ClientID %>").click();
                }
                document.getElementById("rbtn1").style.display = "none";
            }
            else {
                document.getElementById("rbtn1").style.display = "";
            }
        }

        function MenuTypeChanged(menuType) {
            if (menuType == "1") {
                document.getElementById("divInner").style.display = "";
                document.getElementById("divOuter").style.display = "none";
            }
            else if (menuType == "2") {
                document.getElementById("divInner").style.display = "none";
                document.getElementById("divOuter").style.display = "";
            }
            else {
                document.getElementById("divInner").style.display = "none";
                document.getElementById("divOuter").style.display = "none";
            }
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="Summary">
        <asp:Label ID="lblTitle" runat="server" Text="编辑菜单"></asp:Label>
    </div>
    <div class="Content">
        <div class="Operator">
            <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click"><span>保存</span></asp:LinkButton><asp:HyperLink
                ID="hlnkCancel" runat="server"><span>返回</span></asp:HyperLink>
        </div>
        <div class="TipDiv">
            <span id="lblJsErrorMsg"></span>
        </div>
        <div class="ContentLayout">
            <div class="LayoutRow">
                <span class="Title">菜单名称</span>
                <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox>
            </div>
            <div class="LayoutRow">
                <span class="Title">序号</span>
                <asp:TextBox ID="txtIndex" runat="server" Width="150"></asp:TextBox>
            </div>
            <div class="LayoutRow">
                <span class="Title">上级菜单</span>
                <asp:DropDownList ID="ddlTopMenu" runat="server" Width="350" DataTextField="Name" DataValueField="Id">
                </asp:DropDownList>
            </div>
            <div class="LayoutRow">
                <span class="Title">链接</span> <span id="rbtn1">
                    <asp:RadioButton ID="rbtnAuto" runat="server" GroupName="LinkType" Text="自动" ToolTip="将链接到第一个子目录对应的页面" /></span>
                <span>
                    <asp:RadioButton ID="rbtnInner" runat="server" GroupName="LinkType" Text="内部链接" />
                </span><span>
                    <asp:RadioButton ID="rbtnOuter" runat="server" GroupName="LinkType" Text="外部链接" /></span>
            </div>
            <div class="LayoutContainer">
                <div id="divInner">
                    <asp:DropDownList ID="ddlInnerLink" Width="350" runat="server">
                    </asp:DropDownList>
                </div>
                <div id="divOuter">
                    <span>链接地址</span>
                    <asp:TextBox ID="txtOuterUrl" Width="550" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="LayoutRow">
                <span class="Title">在新窗口中打开</span>
                <asp:CheckBox ID="cbOpenNewWindow" runat="server" /></div>
        </div>
    </div>

    <script type="text/javascript">

        document.getElementById("<%= ddlTopMenu.ClientID %>").onchange = function() {
            var menuId = this.options[this.selectedIndex].value;
            TopMenuChanged(menuId);
        }

        document.getElementById("<%= rbtnAuto.ClientID %>").onclick = function() {
            MenuTypeChanged("0");
        }

        document.getElementById("<%= rbtnInner.ClientID %>").onclick = function() {
            MenuTypeChanged("1");
        }

        document.getElementById("<%= rbtnOuter.ClientID %>").onclick = function() {
            MenuTypeChanged("2");
        }

        document.getElementById("<%= rbtnAuto.ClientID %>").click();
    
    </script>

</asp:Content>
