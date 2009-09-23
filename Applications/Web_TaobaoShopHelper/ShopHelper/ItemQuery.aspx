<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemQuery.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ItemQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <script type="text/javascript">

        var queryType = "item";
        function Query() {
            var key = document.getElementById("<%= txtQuery.ClientID %>").value;
            location = "QueryResult.aspx?q=" + key + "&t=" + queryType;
        }

        function ChangeType(type) {
            queryType = type;
        }
    
    </script>

    <div>
        <div>
            <a href="javascript:void(0);" onclick="ChangeType('item');">宝贝</a> <a href="javascript:void(0);"
                onclick="ChangeType('shop');">店铺</a>
        </div>
        <div>
            <asp:TextBox ID="txtQuery" runat="server"></asp:TextBox><a href="javascript:void(0);" onclick="Query();">搜索</a>
        </div>
    </div>
    </form>
</body>
</html>
