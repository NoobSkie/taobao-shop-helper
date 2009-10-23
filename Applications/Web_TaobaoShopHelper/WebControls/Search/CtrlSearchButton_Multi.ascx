<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSearchButton_Multi.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Search.CtrlSearchButton_Multi" %>

<script src="<%= GetRootUrl() %>/Scripts/PageOperate.js" type="text/javascript"></script>

<script type="text/javascript">

    function ShowSearchWin(url, width, height, resizable, isInTest) {
        if (isInTest) {
            OpenWindow(url);
        }
        else {
            ShowModuleDialog(url, width, height, resizable);
        }
    }

    function AfterReturnData(ctrlId, type, postData) {
        if (type == "1") {
            if (postData != null && postData.length > 0) {
                PostBackPage(postData[0]);
            }
        }
        else {
            var json = new String();
            if (postData != null && postData.length > 0) {
                json += '{"Number":"' + postData.length + '","Detail":[';
                for (var i = 0; i < postData.length; i++) {
                    if (i > 0) {
                        json += ",";
                    }
                    json += GetItemJson(postData[i]);
                }
                json += "]}";
            }
            PostBackPage(json);
        }
    }

    function GetItemJson(item) {
        var json = '{"Id":"' + item.Id + '","Nick":"' + item.Nick + '","Title":"' + item.Title + '","DetailUrl":"' + item.DetailUrl + '","ImageUrl":"' + item.ImageUrl + '","Price":"' + item.Price + '"}';
        return json;
    }

    function PostBackPage(args) {
        if (__doPostBack) {
            __doPostBack('<%= PostButtonId %>', args);
        }
    }
</script>

<asp:HyperLink ID="hlnkSearch" runat="server" NavigateUrl="javascript:void(0);" Text="选择"></asp:HyperLink>
<asp:LinkButton ID="lbtnDoPostBack" runat="server" OnClick="lbtnDoPostBack_Click"></asp:LinkButton>