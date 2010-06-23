<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    EnableViewState="false" %>

<%@ Register Src="Controls/CtrlHeader.ascx" TagName="CtrlHeader" TagPrefix="uc1" %>
<%@ Register Src="Controls/CtrlMenu.ascx" TagName="CtrlMenu" TagPrefix="uc2" %>
<%@ Register Src="Controls/CtrlFooter.ascx" TagName="CtrlFooter" TagPrefix="uc3" %>
<%@ Register Src="Controls/CtrlSubMenu.ascx" TagName="CtrlSubMenu" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%= SiteName %></title>
    <link href="Styles/MainLayout.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function SetIframeHeight() {
            var a = iframe_sub.document.body.scrollHeight;
            // var c = iframe_sub.document.documentElement.scrollHeight;
            document.getElementById('iframe_sub').style.height = a;
        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div class="MainForm">
            <div class="Header">
                <uc1:CtrlHeader ID="ctrlHeader" runat="server" />
                <div class="Menu1">
                    <uc2:CtrlMenu ID="ctrlMenu1" runat="server" />
                </div>
            </div>
            <div class="TitleImage">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"
                    width="165" height="37" style="float: right; margin-right: 3px; margin-top: 208px;"
                    id="niftyPlayer1" align="bottom">
                    <param name="movie" value="Player/niftyplayer.swf?file=Player/liangzhu.mp3&as=<%= AutoPlayMusic %>">
                    <param name="quality" value="high">
                    <param name="bgcolor" value="#FFFFFF">
                    <embed src="Player/niftyplayer.swf?file=Player/liangzhu.mp3&as=0" quality="high"
                        bgcolor="#FFFFFF" width="165" height="37" name="niftyPlayer1" align="" type="application/x-shockwave-flash"
                        swliveconnect="true" pluginspage="http://www.macromedia.com/go/getflashplayer">
		</embed>
                </object>
            </div>
            <div id="divSubMenu" class="Menu2">
                <uc4:CtrlSubMenu ID="ctrlSubMenu4" runat="server" />
            </div>
            <div class="SplitLeft" style="height: 600px;">
            </div>
            <div class="Content">
                <iframe id="iframe_sub" name="iframe_sub" width="600px" frameborder="0" scrolling="no"
                    onload="SetIframeHeight();"></iframe>
            </div>
            <div class="Footer">
                <uc3:CtrlFooter ID="ctrlFooter" runat="server" />
            </div>
        </div>
    </center>
    </form>
</body>
</html>
