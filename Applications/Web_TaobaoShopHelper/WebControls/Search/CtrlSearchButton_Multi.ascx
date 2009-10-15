<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSearchButton_Multi.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Search.CtrlSearchButton_Multi" %>

<script src="<%= GetRootUrl() %>/Scripts/PageOperate.js" type="text/javascript"></script>

<script type="text/javascript">
    function ShowSearchWin(url, width, height, resizable) {
        var selectedItemList = ShowModuleDialog(url, width, height, resizable);
        if (selectedItemList != null && selectedItemList.length > 0) {
            var json = '{"Number":"' + selectedItemList.length + '","Detail":[';
            for (var i = 0; i < selectedItemList.length; i++) {
                if (i > 0) {
                    json += ",";
                }
                json += GetItemJson(selectedItemList[i]);
            }
            json += "]}";
            if (__doPostBack) {
                __doPostBack('<%= PostButtonId %>', json);
            }
        }
    }

    function GetItemJson(item) {
        var json = '{"Id":"' + item.Id + '","Nick":"' + item.Nick + '","Title":"' + item.Title + '","DetailUrl":"' + item.DetailUrl + '","ImageUrl":"' + item.ImageUrl + '","Price":"' + item.Price + '"}';
        return json;
    }

    function PostBackPage(args) {
    }
</script>

<asp:HyperLink ID="hlnkSearch" runat="server" NavigateUrl="javascript:void(0);" Text="选择"></asp:HyperLink>
<asp:LinkButton ID="lbtnDoPostBack" runat="server" OnClick="lbtnDoPostBack_Click"></asp:LinkButton>