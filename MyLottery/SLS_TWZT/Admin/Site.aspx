<%@ page language="C#" autoeventwireup="true" CodeFile="Site.aspx.cs" inherits="Admin_Site" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
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
                                修改站点资料</div>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="707" height="151" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#85BDE2" style="color: #000000">
                <tr>
                    <td colspan="4" bgcolor="#FFFFFF" style="height: 27px" class="hon">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 站点资料：站点名称：<asp:Label ID="labName" runat="server" ForeColor="Red"></asp:Label>
                        级别：<asp:Label ID="labLevel" runat="server" ForeColor="Red"></asp:Label>
                        状态：<asp:Image ID="imgON" runat="server" /></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            公司名称：</div>
                    </td>
                    <td bgcolor="#FFFFFF" style="width: 212px">
                        <asp:TextBox ID="tbCompany" runat="server" Enabled="False"></asp:TextBox>
                        <span style="color: #ff0000">*</span></td>
                    <td bgcolor="#FFFFFF" style="width: 105px">
                        <div align="right">
                            地址：</div>
                    </td>
                    <td width="231" bgcolor="#FFFFFF">
                        <div align="left">
                            <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
                            <span style="color: #ff0000">*</span></div>
                    </td>
                </tr>
                <tr>
                    <td height="25" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            邮编：</div>
                    </td>
                    <td bgcolor="#FFFFFF" style="width: 212px">
                        <asp:TextBox ID="tbPostCode" runat="server"></asp:TextBox>
                        <span style="color: #ff0000">*</span></td>
                    <td bgcolor="#FFFFFF" style="width: 105px">
                        <div align="right">
                            负责人：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <div align="left">
                            <asp:TextBox ID="tbResponsiblePerson" runat="server" Enabled="False"></asp:TextBox>
                            <span style="color: #ff0000">*</span></div>
                    </td>
                </tr>
                <tr>
                    <td height="27" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            联系人：</div>
                    </td>
                    <td bgcolor="#FFFFFF" style="width: 212px">
                        <asp:TextBox ID="tbContactPerson" runat="server"></asp:TextBox>
                        <span style="color: #ff0000">*</span></td>
                    <td bgcolor="#FFFFFF" style="width: 105px">
                        <div align="right">
                            电话号码：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <div align="left">
                            <asp:TextBox ID="tbTelephone" runat="server"></asp:TextBox>
                            <span style="color: #ff0000">*</span></div>
                    </td>
                </tr>
                <tr>
                    <td height="27" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            传真：</div>
                    </td>
                    <td bgcolor="#FFFFFF" style="width: 212px">
                        <asp:TextBox ID="tbFax" runat="server"></asp:TextBox></td>
                    <td bgcolor="#FFFFFF" style="width: 105px">
                        <div align="right">
                            手机号码：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <div align="left">
                            <asp:TextBox ID="tbMobile" runat="server"></asp:TextBox>
                            <span style="color: #ff0000">*</span></div>
                    </td>
                </tr>
                <tr>
                    <td height="27" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            Email：</div>
                    </td>
                    <td bgcolor="#FFFFFF" style="width: 212px">
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                        <span style="color: #ff0000">*</span></td>
                    <td bgcolor="#FFFFFF" style="width: 105px">
                        <div align="right">
                            QQ号码：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <div align="left">
                            <asp:TextBox ID="tbQQ" runat="server"></asp:TextBox> <span style="color: #ff0000">用","分隔多个号码</span></div>
                    </td>
                </tr>
                <tr>
                    <td height="27" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            服务电话：</div>
                    </td>
                    <td bgcolor="#FFFFFF" style="width: 212px">
                        <asp:TextBox ID="tbServiceTelephone" runat="server"></asp:TextBox>
                        <span style="color: #ff0000">*</span></td>
                    <td bgcolor="#FFFFFF" style="width: 105px">
                        <div align="right">
                            ICP证书号：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <div align="left">
                            <asp:TextBox ID="tbICPCert" runat="server"></asp:TextBox></div>
                    </td>
                </tr>
                <tr>
                    <td height="27" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            代理佣金比例：</div>
                    </td>
                    <td bgcolor="#FFFFFF" style="width: 212px">
                        <asp:TextBox ID="tbBonusScale" runat="server" Enabled="False"></asp:TextBox></td>
                    <td bgcolor="#FFFFFF" style="width: 105px">
                        <div align="right">
                            最大子站点数：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <div align="left">
                            <asp:TextBox ID="tbMaxSubSites" runat="server" Enabled="False"></asp:TextBox>&nbsp;</div>
                    </td>
                </tr>
                <tr>
                    <td height="27" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            站点域名：</div>
                    </td>
                    <td bgcolor="#FFFFFF" colspan="3">
                        <div align="left">
                            <asp:TextBox ID="tbUrls" runat="server" Width="486px"></asp:TextBox>
                            <span style="color: #ff0000">*</span></div>
                    </td>
                </tr>
                <tr>
                    <td height="27" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            使用彩种：</div>
                    </td>
                    <td bgcolor="#FFFFFF" colspan="3" align="center">
                        <asp:GridView ID="g" runat="server" Width="100%" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" ForeColor="#333333" GridLines="None">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="彩种" />
                                <asp:TemplateField HeaderText="使用">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbisUsed" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="id" />
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td height="27" bgcolor="#FFFFFF" style="width: 115px">
                        <div align="right">
                            快速投注彩种：</div>
                    </td>
                    <td bgcolor="#FFFFFF" colspan="3" align="center">
                        <asp:GridView ID="g2" runat="server" Width="100%" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" ForeColor="#333333" GridLines="None">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="彩种" />
                                <asp:TemplateField HeaderText="使用">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbisUsed" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="id" />
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" bgcolor="#FFFFFF" style="height: 38px" align="center">
                        &nbsp;<ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" AlertText="确信输入的资料无误，并立即保存资料吗？" BackgroupImage="../Images/Surrogate/buttbg.gif" BorderStyle="None" Height="20px" OnClick="btnOK_Click" Text="修改" Width="60px" /></td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
