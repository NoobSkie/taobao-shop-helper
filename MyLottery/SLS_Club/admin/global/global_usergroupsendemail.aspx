<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../UserControls/TextareaResize.ascx" %>
<%@ Register TagPrefix="cc3" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" validaterequest="false" inherits="Discuz.Web.Admin.usergroupsendemail, SLS.Club" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>用户组邮件群发</title>
    <link href="../styles/tab.css" type="text/css" rel="stylesheet" />
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
    <script type="text/javascript" src="../js/modalpopup.js"></script>
    <script type="text/javascript">
        function nodeCheckChanged(node)
        {
            var status = "未选取"; 
            if (node.Checked) status = "选取"; 
        }  
    </script>
    <script type="text/javascript">
        function changelayer(objectname)
        {
            if(objectname == "user")
            {
                document.getElementById("user").style.display = 'block';
                document.getElementById("usernamelist").focus();
                document.getElementById("chkall").checked = false;
                CheckByName(document.getElementById("Form1"),'Usergroups','null');
                document.getElementById("usergroup").style.display = 'none';
            }
            else
            {
                document.getElementById("usergroup").style.display = 'block';
                document.getElementById("usernamelist").value = "";
                document.getElementById("user").style.display = 'none';
            }
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
        <div class="ManagerForm">
            <fieldset>
                <legend style="background: url(../images/icons/icon41.jpg) no-repeat 6px 50%;">批量邮件发送</legend>
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 100px">要邮件发送给谁?</td>
                                    <td>
                                        <input type="radio" name="sendobject" onclick="changelayer('user');" checked="checked" />&nbsp;用户&nbsp;&nbsp;&nbsp;&nbsp;
                                        <input type="radio" name="sendobject" onclick="changelayer('usergroup');" />&nbsp;用户组
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div id="user">
                <table align="center" cellpadding="4" cellspacing="0" width="100%">
                    <tr>
                        <td  class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td class="td2" style="width: 100px">接收邮件用户名称:</td>
                                    <td class="td2">
                                        <cc1:TextBox ID="usernamelist" runat="server" HintTitle="提示" HintInfo="要发送的用户名列表,以&amp;quot;,&amp;quot;进行分割"
                                            CanBeNull="可为空" RequiredFieldType="暂无校验" Width="400" Height="40" TextMode="MultiLine"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
                <div id="usergroup" style="display:none">
                <table align="center" cellpadding="4" cellspacing="0" width="100%">
                    <tr>
                        <td  class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 100px">接收邮件的用户组:</td>
                                    <td>
                                        <input type="checkbox" id="chkall" name="chkall" onclick="CheckAll(this.form);" />选择全部/取消
                                        <br />
                                        <cc1:CheckBoxList ID="Usergroups" runat="server" RepeatColumns="4"></cc1:CheckBoxList>
                                        <input type="hidden" name="flag" id="flag" />
                                        <br /><a href = "#" onclick="document.getElementById('flag').value=1;Form1.submit()">导出所有选中用户组用户的Email</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
                <table align="center" cellpadding="4" cellspacing="0" width="100%">
                    <tr>
                        <td  class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 100px">邮件标题:</td>
                                    <td>
                                        <cc1:TextBox ID="subject" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验" Width="400"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 100px">邮件内容:</td>
                                    <td>
                                        <uc1:TextareaResize ID="body" runat="server" controlname="TabControl1:tabPage51:body" rows="18" cols="80"></uc1:TextareaResize>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="Navbutton">
            <cc1:Button ID="BatchSendEmail" runat="server" Text=" 提 交 "></cc1:Button>
        </div>
        <asp:Label ID="lblClientSideCheck" runat="server" CssClass="hint">&nbsp;</asp:Label>
        <asp:Label ID="lblCheckedNodes" runat="server" CssClass="hint">&nbsp;</asp:Label>
        <asp:Label ID="lblServerSideCheck" runat="server" CssClass="hint">&nbsp;</asp:Label>
        <script type="text/javascript">
            document.getElementById("lblClientSideCheck").innerText = document.getElementById("lblServerSideCheck").innerText;
        </script>
    </form>
    
</body>
</html>
