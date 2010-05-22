<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/SSL_WinNotice.aspx.cs"inherits="Home_Room_SSL_WinNotice" enableviewstate="false" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
 
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="demo" style="overflow: hidden; width: 100%; color: #ffffff;float:left">
        <table cellpadding="0" cellspacing="0" style="width:'<%=width%>'; margin-bottom: 5px; height: 25px; background: url(images/ssl_zjbb_bg.gif)">
            <tbody>
                <tr>
                    <td id="demo1" valign="top" width="84%">
                        <table width="<%=width%>" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100%">
                                <label id="divWinNotice" runat ="server" class ="hui12"></label>
                            </td>
                        </tr>
                        </table>
                    </td>
                    <td id="demo2" valign="top" width="94%">
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <script type="text/javascript">
        var speed3 = 30//速度数值越大速度越慢
        demo2.innerHTML = demo1.innerHTML
        function Marquee() {
            if (demo2.offsetWidth - demo.scrollLeft <= 0)
                demo.scrollLeft -= demo1.offsetWidth
            else {
                demo.scrollLeft++
            }
        }
        var MyMar = setInterval(Marquee, speed3)
        demo.onmouseover = function() { clearInterval(MyMar) }
        demo.onmouseout = function() { MyMar = setInterval(Marquee, speed3) }
    </script>
    </form>
</body>
</html>
