<%@ page language="C#" autoeventwireup="true" inherits="Discuz.Web.Admin.edithelpclass, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../styles/default.css" rel="stylesheet" type="text/css" id="css" />
    <link href="../styles/editor.css" rel="stylesheet" type="text/css" id="Link1" />
    <script type="text/javascript" src="../js/common.js"></script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/modalpopup.js"></script>
</head>
<body>
    <div class="ManagerForm">
        <form id="Form1" runat="server">
            <fieldset>
                <legend style="background: url(../images/icons/legendimg.jpg) no-repeat 6px 50%;">编辑类别</legend>
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left">
                            <table width="100%">
                                <tr>
                                    <td style="width: 60px">帮助标题:</td>
                                    <td>
                                        <cc1:TextBox ID="tbtitle" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验" MaxLength="249" Size="20"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" align="right">
                            <table width="100%">
                                <tr>
                                    <td style="width: 60px">排序号:</td>
                                    <td>
                                        <cc1:TextBox ID="orderby" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验" MaxLength="6" Size="3"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <div class="Navbutton">
                <cc1:Button ID="updateclass" runat="server" Text=" 提 交 " OnClick="updateclass_Click"></cc1:Button>&nbsp;&nbsp;
                <button type="button" class="ManagerButton" id="Button3" onclick="window.history.back();"><img src="../images/arrow_undo.gif"/> 返 回 </button>
            </div>
            <div style="display: none">
                <tr>
                    <td class="td1">
                        发布者用户名</td>
                    <td class="td1">
                        <cc1:TextBox ID="poster" runat="server" RequiredFieldType="暂无校验" CanBeNull="必填" MaxLength="20"
                            Enabled="false"></cc1:TextBox></td>
                </tr>
            </div>
        </form>
    </div>
    
</body>
</html>
