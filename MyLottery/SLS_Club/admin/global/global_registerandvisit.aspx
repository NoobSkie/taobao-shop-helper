<%@ page language="c#" validaterequest="false" inherits="Discuz.Web.Admin.registerandvisit, SLS.Club" %>

<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../UserControls/TextareaResize.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>registerandvisit</title>

    <script type="text/javascript" src="../js/common.js"></script>

    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../js/modalpopup.js"></script>

</head>
<body>
    <div class="ManagerForm">
        <form id="Form1" method="post" runat="server">
        <fieldset>
            <legend style="background: url(../images/icons/icon21.jpg) no-repeat 6px 50%;">用户注册设置</legend>
            <table width="100%" style="line-height: 30px;">
                <tr>
                    <td style="width: 110px">
                        允许新用户注册:
                    </td>
                    <td>
                        <cc1:RadioButtonList ID="regstatus" runat="server" RepeatLayout="flow" HintTitle="提示"
                            HintInfo="选择&amp;quot;否&amp;quot;将禁止游客注册成为会员, 但不影响过去已注册的会员的使用">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </cc1:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户资料中是否必<br />
                        须填写实名选项:
                    </td>
                    <td>
                        <cc1:RadioButtonList ID="realnamesystem" runat="server" RepeatLayout="flow" HintTitle="提示"
                            HintInfo="选择&amp;quot;是&amp;quot;填写实名将出现在必填内容区,否则将出现在选填内容区">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </cc1:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户信息保<br />
                        留关键字:
                    </td>
                    <td>
                        <uc1:TextareaResize ID="censoruser" runat="server" cols="80" HintTopOffSet="-110"
                            controlname="censoruser" HintTitle="提示" HintInfo="用户在其用户信息(如用户名、昵称、自定义头衔等)中无法使用这些关键字. 每个关键字一行, 可使用通配符 &amp;quot;*&amp;quot; 如 &amp;quot;*版主*&amp;quot;(不含引号)">
                        </uc1:TextareaResize>
                    </td>
                </tr>
                <tr>
                    <td>
                        新用户注册验证:
                    </td>
                    <td>
                        <cc1:RadioButtonList ID="regverify" runat="server" RepeatColumns="3" RepeatLayout="flow"
                            HintTitle="提示" HintInfo="选择&amp;quot;无&amp;quot;用户可直接注册成功;选择&amp;quot;Email 验证&amp;quot;将向用户注册 Email 发送一封验证邮件以确认邮箱的有效性;选择&amp;quot;人工审核&amp;quot;将由管理员人工逐个确定是否允许新用户注册">
                            <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
                            <asp:ListItem Value="1">Email验证</asp:ListItem>
                            <asp:ListItem Value="2">人工审核</asp:ListItem>
                        </cc1:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email 允许地址:
                    </td>
                    <td>
                        <uc1:TextareaResize ID="accessemail" runat="server" cols="80" controlname="accessemail"
                            HintTitle="提示" HintInfo="只允许某些域名结尾的邮箱注册, 每行一个域名, 例如 @hotmail.com.注意:此项开启时, 下面的&amp;quot;Email 禁止地址&amp;quot;项设置无效">
                        </uc1:TextareaResize>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email 禁止地址:
                    </td>
                    <td>
                        <uc1:TextareaResize ID="censoremail" runat="server" cols="80" controlname="censoremail"
                            HintTitle="提示" HintInfo="由于一些大型邮件服务提供商会过滤论坛程序发送的有效邮件, 您可以要求新用户不得以某些域名结尾的邮箱注册, 每行一个域名, 例如 @hotmail.com">
                        </uc1:TextareaResize>
                    </td>
                </tr>
                <tr>
                    <td>
                        IP注册间隔限制:
                    </td>
                    <td>
                        <cc1:TextBox ID="regctrl" runat="server" CanBeNull="必填" Size="5" MaxLength="4" HintTitle="提示"
                            HintInfo="同一 IP 在本时间间隔内将只能注册一个帐号, 限制对自修改后的新注册用户生效, 0 为不限制"></cc1:TextBox>(单位:小时)
                        <asp:RegularExpressionValidator ID="mycheck" runat="SERVER" ControlToValidate="regctrl"
                            ErrorMessage="请输入正整数" ValidationExpression="^[0-9]*$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        新手见习期限:
                    </td>
                    <td>
                        <cc1:TextBox ID="newbiespan" runat="server" CanBeNull="必填" Size="5" MaxLength="4"
                            HintTitle="提示" HintInfo="新注册用户在本期限内将无法发帖, 不影响版主和管理员, 0 为不限制"></cc1:TextBox>(单位:分钟)
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="SERVER" ControlToValidate="newbiespan"
                            ErrorMessage="请输入正整数" ValidationExpression="^[0-9]*$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 110px">
                        注册时是否显<br />
                        示高级选项:
                    </td>
                    <td>
                        <cc1:RadioButtonList ID="regadvance" runat="server" RepeatLayout="flow" HintTitle="提示"
                            HintInfo="在注册页面是否显示选填内容">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </cc1:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        允许同一 Email<br />
                        注册不同用户:
                    </td>
                    <td>
                        <cc1:RadioButtonList ID="doublee" runat="server" RepeatLayout="flow" HintTitle="提示"
                            HintInfo="选择&amp;quot;否&amp;quot; ,一个 Email 地址只能注册一个用户名">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </cc1:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        特殊 IP 注册限制:
                    </td>
                    <td>
                        <uc1:TextareaResize ID="ipregctrl" runat="server" cols="80" controlname="ipregctrl"
                            HintTitle="提示" HintInfo="当用户处于本列表中的 IP 地址时, 每 72 小时将至多只允许注册一个帐号. 每个 IP 一行, 例如 &amp;quot;192.168.*.*&amp;quot;(不含引号) 可匹配 192.168.0.0~192.168.255.255范围内的所有地址, 留空为不设置">
                        </uc1:TextareaResize>
                    </td>
                </tr>
                <tr>
                    <td>
                        注册许可协议:
                    </td>
                    <td>
                        <cc1:RadioButtonList ID="rules" runat="server" RepeatLayout="flow" HintTitle="提示"
                            HintInfo="新用户注册时显示许可协议">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </cc1:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        许可协议内容:
                    </td>
                    <td>
                        <uc1:TextareaResize ID="rulestxt" runat="server" label="" controlname="rulestxt"
                            cols="80" HintTitle="提示" HintInfo="注册许可协议的详细内容"></uc1:TextareaResize>
                    </td>
                </tr>
                <tr>
                    <td>
                        发送欢迎短消息:
                    </td>
                    <td>
                        <cc1:RadioButtonList ID="welcomemsg" runat="server" RepeatLayout="flow" HintTitle="提示"
                            HintInfo="选择&amp;quot;是&amp;quot;将自动向新注册用户发送一条欢迎短消息">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </cc1:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        欢迎短消息内容:
                    </td>
                    <td>
                        <uc1:TextareaResize ID="welcomemsgtxt" runat="server" cols="80" HintTopOffSet="-50"
                            controlname="welcomemsgtxt" HintTitle="提示" HintInfo="系统发送的欢迎短消息的内容"></uc1:TextareaResize>
                    </td>
                </tr>
            </table>
        </fieldset>
        <cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
        <fieldset>
            <legend style="background: url(../images/icons/icon17.jpg) no-repeat 6px 50%;">访问控制</legend>
            <table width="100%" style="line-height: 30px;">
                <tr>
                    <td style="width: 110px">
                        隐藏无权访<br />
                        问的论坛:
                    </td>
                    <td>
                        <cc1:RadioButtonList ID="hideprivate" runat="server" RepeatLayout="Flow" HintTitle="提示"
                            HintInfo="不在列表中显示当前用户无权访问的论坛">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </cc1:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        IP 访问列表:
                    </td>
                    <td>
                        <uc1:TextareaResize ID="ipaccess" runat="server" cols="80" controlname="ipaccess"
                            HintTitle="提示" HintInfo="只有当用户处于本列表中的 IP 地址时才可以访问本论坛, 列表以外的地址访问将视为 IP 被禁止, 仅适用于诸如企业、学校内部论坛等极个别场合. 本功能对管理员没有特例, 如果管理员不在此列表范围内将同样不能登录, 请务必慎重使用本功能. 每个 IP 一行, 例如 &amp;quot;192.168.*.*&amp;quot;(不含引号) 可匹配 192.168.0.0~192.168.255.255 范围内的所有地址, 留空为所有 IP 除明确禁止的以外均可访问">
                        </uc1:TextareaResize>
                    </td>
                </tr>
                <tr>
                    <td style="width: 110px">
                        IP 禁止访问列表:
                    </td>
                    <td>
                        <uc1:TextareaResize ID="ipdenyaccess" runat="server" cols="80" controlname="ipdenyaccess"
                            HintTitle="提示" HintInfo="当用户处于本列表中的 IP 地址时将禁止访问本论坛. 每个 IP 一行, 例如 &amp;quot;192.168.*.*&amp;quot;(不含引号) 可匹配 192.168.0.0~192.168.255.255 范围内的所有地址">
                        </uc1:TextareaResize>
                    </td>
                </tr>
                <tr>
                    <td>
                        管理员后台<br />
                        IP访问列表:
                    </td>
                    <td>
                        <uc1:TextareaResize ID="adminipaccess" runat="server" cols="80" controlname="adminipaccess"
                            HintTitle="提示" HintInfo="只有当管理员(超级版主及版主不在此列)处于本列表中的 IP 地址时才可以访问论坛系统设置, 列表以外的地址访问将无法访问, 但仍可访问论坛前端用户界面, 请务必慎重使用本功能. 每个 IP 一行, 例如 &amp;quot;192.168.*.*&amp;quot;(不含引号) 可匹配 192.168.0.0~192.168.255.255 范围内的所有地址, 留空为所有 IP 除明确禁止的以外均可访问系统设置">
                        </uc1:TextareaResize>
                    </td>
                </tr>
            </table>
        </fieldset>
        <div class="Navbutton">
            <cc1:Button ID="SaveInfo" runat="server" Text=" 提 交 "></cc1:Button>
        </div>
        </form>
    </div>
</body>
</html>
