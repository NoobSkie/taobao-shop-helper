<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="OnlineEditor" Src="../UserControls/OnlineEditor.ascx" %>
<%@ page language="c#" validaterequest="false" inherits="Discuz.Web.Admin.editannounce, SLS.Club" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑公告</title>
    <script type="text/javascript" src="../js/common.js"></script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/modalpopup.js"></script>
</head>
<body>
    <div class="ManagerForm">
        <form id="Form1" method="post" runat="server" onsubmit="return validate(this);">
            <fieldset>
                <legend style="background: url(../images/icons/icon33.jpg) no-repeat 6px 50%;">编辑公告</legend>
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">显示顺序:</td>
                                    <td>
                                        <cc1:TextBox ID="displayorder" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" Text="0" MaxLength="6" Size="3"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">公告标题:</td>
                                    <td>
                                        <cc1:TextBox ID="tbtitle" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验" MaxLength="249" Size="60"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">起始时间:</td>
                                    <td>
                                        <cc1:TextBox ID="starttime" runat="server" CanBeNull="必填" RequiredFieldType="日期时间" Width="200"></cc1:TextBox>格式:2005-5-5 13:22:02
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">结束时间:</td>
                                    <td>
                                        <cc1:TextBox ID="endtime" runat="server" CanBeNull="必填" RequiredFieldType="日期时间" Width="200"></cc1:TextBox>格式:2005-5-5 13:22:02
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">公告内容:</td>
                                    <td>
                                        <uc1:OnlineEditor ID="message" runat="server" controlname="message" postminchars="0" postmaxchars="200"></uc1:OnlineEditor>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div style="display: none">
                    <tr>
                        <td class="td1">发布者用户名</td>
                        <td class="td1">
                            <cc1:TextBox ID="poster" runat="server" RequiredFieldType="暂无校验" CanBeNull="必填" MaxLength="20"
                                Enabled="false"></cc1:TextBox></td>
                    </tr>
                </div>
            </fieldset>
            <div class="Navbutton">
                <cc1:Button id="UpdateAnnounceInfo" runat="server" Text=" 提 交 " ValidateForm="true"></cc1:Button>&nbsp;&nbsp;
                <cc1:Button id="DeleteAnnounce" runat="server" Text=" 删 除 " ButtonImgUrl="../images/del.gif"></cc1:Button>&nbsp;&nbsp;
                <button type="button" class="ManagerButton" id="Button3" onclick="window.history.back();"><img src="../images/arrow_undo.gif"/> 返 回 </button>
            </div>
        </form>
    </div>
    
</body>
</html>
