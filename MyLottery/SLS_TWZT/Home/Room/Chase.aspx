<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/Chase.aspx.cs" inherits="Home_Room_Chase" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <link href="../Style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table height="30" border="0" align="center" cellpadding="0" cellspacing="0" width="98%">
            <tr>
                <td width="19%" align="center" background="../Images/daihe_03.gif" class="hei">
                    <span class="STYLE9"><strong>
                        <%=LotteryName%>
                        追号 </strong></span>
                </td>
                <td width="81%" height="31px" align="right" background="../Images/daihe_04.gif" class="bai">
                    <a href="../Agreement.aspx?id=<%=LotteryID%>" target="_blank" class="red">《<%=LotteryName%>电话短信投注协议》</a>
                </td>
            </tr>
        </table>
        <br />
        <table border="0" align="center" cellpadding="0" cellspacing="1" width="98%" bgcolor="#CCDDCC">
            <tr>
                <td bgcolor="white" style="height: 30px; padding-left: 10px;">
                    <asp:Label ID="LbPlay" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 152px" bgcolor="white">
                    <iframe width="100%" id="iframeplay" name="iframeplay" style="height: 600px;" src="<%=IframeUrl%>" frameborder="0" marginheight="0" marginwidth="0"></iframe>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
