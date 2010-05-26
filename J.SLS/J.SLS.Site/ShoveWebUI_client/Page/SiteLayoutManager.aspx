<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.SiteLayoutManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>站点布局管理</title>
    <link href="../Style/css.css" type="text/css" rel="Stylesheet" />
    <base target="_self" />
</head>
<body style="background-color: buttonface;" onunload='window.returnValue = document.getElementById("tbResult").value;'>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="background-image: url(../Images/top_bg.jpg)" width="100%">
            <tr>
                <td height="48" valign="bottom">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="right">
                                <asp:ImageButton ImageUrl="../Images/top_botton_1.jpg" runat="server" ID="btnResumption" OnClick="btnResumption_Click" />
                            </td>
                            <td align="center">
                                <asp:ImageButton ImageUrl="../Images/top_botton_2.jpg" runat="server" ID="btnDelete" OnClick="btnDelete_Click" />
                            </td>
                            <td align="left">
                                <img alt="" src="../Images/top_botton_3.jpg" width="104" height="25" border="0" style="cursor:hand" onclick="javascript:window.close();" />
                            </td>
                        </tr>
                        <tr>
                            <td height="10" colspan="3">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="25" align="right" bgcolor="#f0f0f0" class="sdw_1">
                    站点备份文件目录：
                </td>
                <td class="sdw_2">
                    (1、请选择复选框 → 2、选择上面操作按钮)
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td height="25">
                    <asp:TreeView ID="tvFiles" runat="server" Font-Size="Small" ForeColor="#000000" ShowCheckBoxes="Leaf">
                    </asp:TreeView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;<input type="hidden" id="tbResult" runat="server" value="" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
