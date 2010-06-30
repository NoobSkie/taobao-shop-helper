<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index"
    EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%= SiteName %></title>
    <link href="Styles/IndexLayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div>
            <asp:Image ID="imgLogo" CssClass="Logo" runat="server" ImageUrl="~/Images/logo.png" /></div>
        <div>
            <span style="line-height: 30px;">重庆天子之歌钢琴公司</span>
            <br />
            <span style="line-height: 30px;">重庆天之歌钢琴学校</span>
        </div>
        <div>
            <span style="color: Red; line-height: 50px;"><b>让艺术完美你的人生</b></span>
        </div>
        <div style="display: none;">
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"
                width="165" height="37" id="niftyPlayer1" align="bottom">
                <param name="movie" value="Player/niftyplayer.swf?file=Player/liangzhu.mp3&as=<%= AutoPlayMusic %>">
                <param name="quality" value="high">
                <param name="bgcolor" value="#FFFFFF">
                <embed src="Player/niftyplayer.swf?file=Player/liangzhu.mp3&as=0" quality="high"
                    bgcolor="#FFFFFF" width="165" height="37" name="niftyPlayer1" align="" type="application/x-shockwave-flash"
                    swliveconnect="true" pluginspage="http://www.macromedia.com/go/getflashplayer">
		</embed>
            </object>
        </div>
        <div class="Menu1">
            <asp:Repeater ID="rptMenuList" runat="server">
                <ItemTemplate>
                    <a href="<%# Eval("Id", "Default.aspx?m={0}") %>">
                        <%# Eval("Name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </center>
    </form>
</body>
</html>
