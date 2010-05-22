<%@ page language="C#" autoeventwireup="true" CodeFile="~/Error.aspx.cs" inherits="Error" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>出错啦！</title>
    <link href="Style/Surrogate.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .STYLE1
        {
            color: Red;
            font-size: 15px;
            font-weight: bold;
            padding-left: 20px;
        }
        .STYLE2
        {
            color: #6B6B6B;
            font-size: 13px;
            font-weight: bold;
            padding-left: 20px;
        }
    </style>

    <script language="javascript" type="text/javascript">

        function tbOnMouseover() {
            var o_tdHistory = document.getElementById("tdHistory");

            o_tdHistory.style.backgroundColor = "#FF3300";
            o_tdHistory.style.cursor = "hand";
        }

        function tbOnMouseout() {
            var o_tdHistory = document.getElementById("tdHistory");

            o_tdHistory.style.backgroundColor = "#FD9A00";
        }
    
    </script>

    <link rel="shortcut icon" href="favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
   <table width="508" border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td style="background-image:url(Images/NotExists/Arrow.gif);height:39px">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="background-image:url(Images/NotExists/News_success_bg3.gif)">
                            <table id="tabError" runat="server" width="508" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="120" align="center" valign="middle">
                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 60%">
                                            <tr>
                                             <td width="20%">
                                                    &nbsp;<img src="Images/Cry_036.gif" alt="<%=_Site.Name %>-双色球、大乐透" />
                                                </td>
                                                <td width="80%" valign="middle">
                                                    <font color="#ff6600"><strong>对不起，访问出错！请重新打开网站！ </strong></font>
                                                    <br />
                                                    <asp:Label ID="labClassName1" runat="server" ForeColor="white"></asp:Label>
                                                    <br />
                                                    请参考以下原因后再做此操作：
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td align="left" height="34px" style="padding-left: 20px;" colspan="2">
                                                    <asp:Label ID="labTip" runat="server" ForeColor="Red"> </asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table id="tabErrorForNoIsuse" visible="false" runat="server" width="508" border="0"
                                cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="120" align="center" valign="middle">
                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 60%">
                                            <tr>
                                            <td width="20%">
                                                    &nbsp;<img src="Images/Cry_036.gif" alt="<%=_Site.Name %>-双色球、大乐透" />
                                                </td>
                                                <td width="80%" valign="middle">
                                                    <font color="#ff6600"><strong>提示：请稍后访问，谢谢！ </strong></font>
                                                    <br />
                                                    <asp:Label ID="labClassName2" runat="server" ForeColor="white"></asp:Label>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td align="left" height="34px" style="padding-left: 20px;" colspan="2">
                                                    <asp:Label ID="labTipForNoIsuse" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" valign="top" align="center" style="background-image:url(Images/NotExists/News_success_bg3.gif)">
                            <button onclick="javascript:window.history.go(-1);" id="tdHistory" style="background-color: #FD9A00;
                                color: White; width: 120px; border: solid #CCCCCC 1px;" onmouseout="return tbOnMouseout();"
                                onmouseover="return tbOnMouseover();">
                                返回（5 秒跳转）</button>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-image:url(Images/NotExists/news_success_bg2.gif); background-repeat:no-repeat; height:9px">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
    </form>
    <!--#includefile="Html/TrafficStatistics/1.htm"-->

    <script language="javascript" type="text/javascript"><%= script %></script>

</body>
</html>
