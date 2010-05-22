<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/WinNotice.aspx.cs" inherits="Home_Room_WinNotice" enableviewstate="false" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     
    <link href="style/css.css" rel="stylesheet" type="text/css" />

    <script src="JavaScript/Marquee.js" type="text/javascript"></script>

    <style type="text/css">
        .CSSWinNotice
        {
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr style="background-color:#F7F7F7;" height="33px">
            <td>
                <div id="demo" style=" overflow: hidden; margin-top: 5px; margin-bottom: 0px;
                    padding-left: 20px; padding-right: 20px;">
                    <asp:DataList ID="dlWinNotice" RepeatColumns="4" runat="server" CssClass="CSSWinNotice">
                        <ItemTemplate>
                            <asp:Label ID="lbWinNoticeDetail" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="260px" Height="19px" />
                    </asp:DataList>
                </div>
            </td>
        </tr>
        <tr style="background-color: #DDDDDD;">
            <td height="1px">
            </td>
        </tr>
    </table>
    

    <script type="text/javascript" language="javascript">
        var sampleDiv = new scrollingAD("demo");
        sampleDiv.width = 1002;
        sampleDiv.height = 22;
        sampleDiv.delay = 20;
        sampleDiv.bgColor = "#F7F7F7";
        sampleDiv.pauseTime = 2000;
        sampleDiv.move();
    </script>

    </form>
</body>
</html>
