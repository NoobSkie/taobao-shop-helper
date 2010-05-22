<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register Src="../UserControls/PageInfo.ascx" TagName="PageInfo" TagPrefix="uc1" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.combinationusergroup, SLS.Club" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>组合并</title>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <uc1:PageInfo ID="info1" runat="server" Icon="warning" Text="合并组功能会将当前组下的所有用户合并到目标组中去, 同时删除当前组的所有信息" />
        <uc1:PageInfo ID="PageInfo1" runat="server" Icon="warning" Text="要合并的用户组必须是金币相连的两个用户组" />
        <div class="ManagerForm">
            <fieldset>
                <legend style="background: url(../images/icons/icon6.jpg) no-repeat 6px 50%;">合并用户组</legend>
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" width="50%" align="center">
                            &nbsp;<b>把</b>&nbsp;<cc1:DropDownList ID="sourceusergroup" runat="server"></cc1:DropDownList>
                            &nbsp;&nbsp;<b>合并到:&nbsp;&nbsp;</b><cc1:DropDownList ID="targetusergroup" runat="server"></cc1:DropDownList>
                            &nbsp;&nbsp;<cc1:Button ID="ComUsergroup" runat="server" Text=" 提交 "></cc1:Button>
                        </td>
                        <td  class="panelbox" width="50%" align="center">
                            &nbsp;<b>把</b>&nbsp;<cc1:DropDownList ID="sourceadminusergroup" runat="server"></cc1:DropDownList>
                            &nbsp;&nbsp;<b>合并到:&nbsp;&nbsp;</b><cc1:DropDownList ID="targetadminusergroup" runat="server"></cc1:DropDownList>
                            &nbsp;&nbsp;<cc1:Button ID="ComAdminUsergroup" runat="server" Text=" 提交 "></cc1:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
    
</body>
</html>
