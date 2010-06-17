<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeFile="MenuEdit.aspx.cs"
    Inherits="Admins_MenuEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="menuedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function TopMenuChanged(menuId) {
            if (menuId != "") {
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
                BindChildrenHtml(document.getElementById("<%= ddlLinkList.ClientID %>"));
            }
            else if (menuType == "2") {
                document.getElementById("divInner").style.display = "none";
                document.getElementById("divOuter").style.display = "";
            }
            else {
                document.getElementById("divInner").style.display = "none";
                document.getElementById("divOuter").style.display = "none";
            }
            if (window.parent && window.parent.SetIframeHeight) {
                window.parent.SetIframeHeight();
            }
        }

        function ClearHtmlItems() {
            var obj = document.getElementById("<%= ddlLinkHtml.ClientID %>");
            while (obj.options.length > 0) {
                obj.remove(0);
            }
            var p = document.getElementById("<%= ddlLinkList.ClientID %>");
            var v = p.options[p.selectedIndex].value;
            if (v != "_NONE") {
                var o = document.createElement("option");
                o.value = "";
                o.text = "<无>";
                obj.add(o);
            }
        }

        var htmlCache = new Array();
        function BindChildrenHtml(parentObj) {
            ClearHtmlItems();
            var listId = parentObj.options[parentObj.selectedIndex].value;
            var obj = document.getElementById("<%= ddlLinkHtml.ClientID %>");
            var s0 = "<%= SplitChar0 %>";
            for (var i = 0; i < htmlCache.length; i++) {
                var items = htmlCache[i].split(s0);
                if (items[0] == listId) {
                    BindHtmlItems(items[1]);
                    return;
                }
            }
            try {
                var response = Admins_MenuEdit.GetHtmlItemsById(listId);
                if (response == null || response.value == null) {
                    return;
                }
                htmlCache.push(listId + s0 + response.value);
                BindHtmlItems(response.value);
            }
            catch (e) {
                alert("读取列表失败！");
            }
        }

        function BindHtmlItems(response) {
            var s1 = "<%= SplitChar1 %>";
            var s2 = "<%= SplitChar2 %>";
            var itemList = response.split(s1);
            var obj = document.getElementById("<%= ddlLinkHtml.ClientID %>");
            for (var i = 0; i < itemList.length; i++) {
                var infos = itemList[i].split(s2);
                if (infos.length == 3) {
                    var o = document.createElement("option");
                    o.value = infos[0];
                    o.text = infos[1] + "(" + infos[2] + ")";
                    obj.add(o);
                }
            }
        }

        function SaveMenu() {
            // public string SaveMenu(string name, string index, string topMenuId, bool isInner, string innerId, bool isNewWindow, string outerUrl)
            try {
                var id = document.getElementById("<%= hiddCurrentId.ClientID %>").value;
                var name = document.getElementById("<%= txtName.ClientID %>").value;
                var index = document.getElementById("<%= txtIndex.ClientID %>").value;
                var topMenuObj = document.getElementById("<%= ddlTopMenu.ClientID %>");
                var topMenuId = topMenuObj.options[topMenuObj.selectedIndex].value;

                var isInner = !document.getElementById("<%= rbtnOuter.ClientID %>").checked;
                var innerId = "";
                var innerObj = document.getElementById("<%= rbtnInner.ClientID %>");
                if (innerObj.checked) {
                    var htmlObj = document.getElementById("<%= ddlLinkHtml.ClientID %>");
                    var htmlId = htmlObj.options[htmlObj.selectedIndex].value;
                    if (htmlId == "") {
                        var listObj = document.getElementById("<%= ddlLinkList.ClientID %>");
                        var listId = htmlObj.options[htmlObj.selectedIndex].value;
                        innerId = listId;
                    }
                    else {
                        innerId = htmlId;
                    }
                }

                var isNewWindow = document.getElementById("<%= cbOpenNewWindow.ClientID %>").checked;
                var outerUrl = document.getElementById("<%= txtOuterUrl.ClientID %>").value;
                var response = Admins_MenuEdit.SaveMenu(id, name, index, topMenuId, isInner, innerId, isNewWindow, outerUrl);
                if (response == null || response.value == null) {
                    alert("保存菜单失败！");
                    return;
                }
                alert(response.value);
                window.location = "MenuManagement.aspx";
            }
            catch (e) {
                alert("保存菜单失败！");
            }
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="Summary">
        <asp:Label ID="lblTitle" runat="server" Text="编辑菜单"></asp:Label>
        <asp:HiddenField ID="hiddCurrentId" runat="server" />
    </div>
    <div class="Content">
        <div class="Operator">
            <asp:HyperLink ID="HyperLink1" NavigateUrl="javascript:SaveMenu();" runat="server"><span>保存</span></asp:HyperLink>
            <asp:HyperLink ID="hlnkCancel" runat="server"><span>返回</span></asp:HyperLink>
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
                <asp:DropDownList ID="ddlTopMenu" runat="server" Width="350" DataTextField="Name"
                    DataValueField="Id">
                </asp:DropDownList>
            </div>
            <div class="LayoutRow">
                <span class="Title">链接</span> <span id="rbtn1">
                    <asp:RadioButton ID="rbtnAuto" runat="server" GroupName="LinkType" Text="自动" ToolTip="将链接到第一个子目录对应的页面" /></span>
                <span>
                    <asp:RadioButton ID="rbtnInner" runat="server" GroupName="LinkType" Text="内部链接" />
                </span><span>
                    <asp:RadioButton ID="rbtnOuter" runat="server" GroupName="LinkType" Text="外部链接" /></span>
                <div id="divInner">
                    <asp:DropDownList ID="ddlLinkList" Width="250" CssClass="DdlList" DataTextField="Name"
                        DataValueField="Id" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlLinkHtml" Width="500" CssClass="DdlItem" DataTextField="Name"
                        DataValueField="Id" runat="server">
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

        document.getElementById("<%= ddlLinkList.ClientID %>").onchange = function() {
            BindChildrenHtml(this);
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
