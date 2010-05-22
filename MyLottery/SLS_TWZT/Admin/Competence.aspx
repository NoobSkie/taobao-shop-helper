<%@ page language="C#" autoeventwireup="true" CodeFile="Competence.aspx.cs" inherits="Admin_Competence" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 166px;
            height: 21px;
        }
        .style2
        {
            height: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="707" height="34" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#85BDE2">
                <tr>
                    <td height="32" bgcolor="#B0D5EC" class="STYLE14">
                        <div align="left" class="STYLE4">
                            <div align="center">
                                权限管理</div>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="707" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#85BDE2" style="color: #000000; height: 160px;">
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF" style="height: 18px;" class="hon">
                        </td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 187px" rowspan="25" valign="top" align="center">
                        <asp:ListBox ID="lbUser" runat="server" Width="96%" Height="470px" AutoPostBack="True" OnSelectedIndexChanged="lbUser_SelectedIndexChanged"></asp:ListBox></td>
                    <td bgcolor="#B0D5EC" align="center" colspan="2">
                        用户组</td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup1" runat="server" Text="超级管理员组" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">
                        拥有本站最高的、所有操作权限的用户组。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup2" runat="server" Text="管理员组" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">
                        拥有本站较高的操作权限，如：编辑资讯、内容；查询修改会员信息；修改彩票期号、出票、开奖等功能。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup3" runat="server" Text="销售员组"/></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">
                        拥有本站彩票销售(出票)的操作权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup4" runat="server" Text="客服组"/></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">
                        拥有本站接受、回复、处理客户服务的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup5" runat="server" Text="内容资讯管理组"/></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">
                        拥有本站新闻、资讯、内容填充的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup6" runat="server" Text="财务管理组"/></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">拥有本站财务往来、会员资金充值、提款等权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup7" runat="server" Text="页面布局设计组"/></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">拥有通过 ShoveWebPart 修改站点页面布局、设计页面的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup8" runat="server" Text="CPS组"/></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">CPS内容管理，拥有CPS资讯和商家管理。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup9" runat="server" Text="数据查询组"/></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">C拥有所有页面访问的权限，但是只能查看，不能进行其它操作。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbGroup10" runat="server" Text="积分系统组"/></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">拥有对积分系统后台的管理设置。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#B0D5EC" align="center" colspan="2">
                        用户权限</td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence1" runat="server" Text="超级管理" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">超级管理权限，拥有对网站的全部控制权。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence2" runat="server" Text="权限管理" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">管理网站会员的权限、控制、设置等权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence3" runat="server" Text="填充网站内容" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">填充网站的各种内容的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px; height: 20px;">
                        &nbsp;<asp:CheckBox ID="cbCompetence4" runat="server" Text="编辑新闻资讯" /></td>
                    <td bgcolor="#ffffff" style="height: 20px">
                        <span style="color: #cc0033">编辑、发布网站的各种新闻资讯栏目；编辑网站公告的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence5" runat="server" Text="会员管理" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">查询、修改会员信息的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" class="style1">
                        &nbsp;<asp:CheckBox ID="cbCompetence6" runat="server" Text="账户充值" /></td>
                    <td bgcolor="#ffffff" class="style2">
                        <span style="color: #cc0033">会员账户充值的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence7" runat="server" Text="账户提款" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">接受、处理会员提款的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF" style="width: 166px; height: 12px;">
                        &nbsp;<asp:CheckBox ID="cbCompetence8" runat="server" Text="客户服务" /></td>
                    <td bgcolor="#ffffff" style="height: 12px">
                        <span style="color: #cc0033">查阅会员提问、反馈答复会员资讯、解决客户问题的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence9" runat="server" Text="发送消息" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">发送站内短消息、向会员群发邮件、发送手机短信的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence10" runat="server" Text="系统日志管理" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">管理系统日志的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence11" runat="server" Text="期号方案管理" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">管理彩票销售期号、方案置顶、撤单等权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence12" runat="server" Text="销售出票" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">销售彩票、出票打印的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" class="style1">
                        &nbsp;<asp:CheckBox ID="cbCompetence13" runat="server" Text="开奖派奖" /></td>
                    <td bgcolor="#ffffff" class="style2">
                        <span style="color: #cc0033">彩票开奖、奖金派发的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" rowspan="6" style="width: 187px">
                        增加用户：<br />
                        <asp:TextBox ID="tbUserName" runat="server" Width="111px"></asp:TextBox>
                        <ShoveWebUI:ShoveConfirmButton ID="btnAdd" runat="server" BackgroupImage="../Images/Admin/buttbg.gif" BorderStyle="None" Height="20px" Text="增加" Width="60px" OnClick="btnAdd_Click" /></td>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence14" runat="server" Text="基本数据设置" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">网站各参数设置的高级权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence15" runat="server" Text="财务查询" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">网站财务报表查询的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence16" runat="server" Text="页面布局设计" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">通过 ShoveWebPart 修改站点页面布局、设计页面的权限。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence17" runat="server" Text="CPS管理" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">CPS内容管理，拥有CPS资讯和商家管理。</span></td>
                </tr>
                 <tr>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence18" runat="server" Text="数据查询" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">查看所有页面数据。</span></td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="width: 166px">
                        &nbsp;<asp:CheckBox ID="cbCompetence19" runat="server" Text="积分系统管理" /></td>
                    <td bgcolor="#ffffff">
                        <span style="color: #cc0033">拥有对积分系统后台的管理设置。</span></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF" align="center" style="height: 40px"><ShoveWebUI:ShoveConfirmButton ID="btnSave" runat="server" BackgroupImage="../Images/Admin/buttbg.gif" BorderStyle="None" Height="20px" Text="保存" Width="60px" AlertText="确信设置无误，并立即保存吗？" OnClick="btnSave_Click" /></td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
