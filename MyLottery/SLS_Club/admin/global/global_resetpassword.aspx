<%@ page language="c#" inherits="Discuz.Web.Admin.resetpassword, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>添加用户</title>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div class="ManagerForm">
            <fieldset>
                <legend style="background: url(../images/icons/legendimg.jpg) no-repeat 6px 50%;">重置密码</legend>
                <table align="center" border="0" class="table1" cellspacing="0" cellpadding="4" width="100%">
                    <tr>
                        <td class="td2" width="10%">用户名:</td>
                        <td class="td2">
                            <cc1:TextBox ID="userName" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验"
                                MaxLength="30" Size="25" Enabled="False"></cc1:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1" width="10%">新密码:</td>
                        <td class="td1" width="40%">
                            <cc1:TextBox ID="password" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验"
                                TextMode="Password" MaxLength="32" Size="25"></cc1:TextBox>
                        </td>
                        <td class="td2" width="10%">重复输入密码:</td>
                        <td class="td2" width="40%">
                            <cc1:TextBox ID="passwordagain" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验"
                                MaxLength="32" Size="25" TextMode="Password"></cc1:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <div class="Navbutton">
                <cc1:Button ID="ResetUserPWs" runat="server" Text=" 提 交 "></cc1:Button>
            </div>
        </div>
    </form>
    
</body>
</html>
