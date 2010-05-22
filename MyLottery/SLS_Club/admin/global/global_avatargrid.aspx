<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.avatargrid, SLS.Club" %>
<%@ Register Src="../UserControls/PageInfo.ascx" TagName="PageInfo" TagPrefix="uc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>头像管理</title>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
    <script type="text/javascript">
        function Check(form)
        {
            CheckAll(form);
            checkedEnabledButton(form,'id','DeleteAvatar')
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table width="100%" border="0" cellpadding="4" class="table1" cellspacing="0">
            <tr>
                <td class="td1">
                    <table width="100%" border="0" cellspacing="0" cellpadding="4">
                        <tr>
                            <asp:Literal ID="vatarshow" runat="server"></asp:Literal>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc1:PageInfo ID="info1" runat="server" Icon="information" Text="您可以直接将头像文件用FTP软件直接上传到系统目录下的avatars/common/文件夹中,并单击更新系统头像缓存即可" />
        <p style="text-align:right;">
            <input title="选中/取消选中 本页所有Case" onclick="Check(this.form)" type="checkbox" name="chkall" id="chkall" />全选/取消&nbsp; &nbsp;
            <cc1:Button ID="DeleteAvatar" runat="server" Text=" 删 除 " ButtonImgUrl="../images/del.gif" Enabled="false"></cc1:Button>&nbsp; &nbsp; &nbsp;
            <cc1:Button ID="UpdateAvatarCache" runat="server" Text=" 更新系统头像缓存 "></cc1:Button>&nbsp; &nbsp;
            <button type="button" class="ManagerButton" onclick="javascript:window.location.href='global_uploadavatar.aspx';">
                <img src="../images/add.gif" />上传头像
            </button>
        </p>
    </form>
    
</body>
</html>
