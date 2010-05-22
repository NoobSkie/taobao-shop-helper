<%@ page language="C#" autoeventwireup="true" inherits="News_News, SLS.Club" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../templates/default/dnt.css" type="text/css" media="all"  />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Div1"  align="left" runat="server" style="padding: 20px;border-style: none; border-width: 0px; width: 900px; height: 100%;">
        <div  align="left"  style="padding: 20px;border-style: none; border-width: 0px; height:30px">
               <asp:Label ID="lblTitle" runat="server" Text=" " Font-Bold="True" Font-Size="18"></asp:Label><br /><br />
                本文发表于 <asp:Label ID="lblDatetime" runat="server" Text=""></asp:Label>  
                | 作者 <asp:Label ID="lblAuthor" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
        </div>
        <div  id="content"  align="left" runat="server" style="padding: 20px;border-style: none; border-width: 0px; width: 900px; height: 100%;">
        </div>
    </div>
    </form>
</body>
</html>

