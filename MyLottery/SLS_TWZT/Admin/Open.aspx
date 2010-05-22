<%@ page language="C#" autoeventwireup="true" CodeFile="Open.aspx.cs" inherits="Admin_Open" validaterequest="false" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../JavaScript/Public.js"></script>

    <script type="text/javascript">

        function CalcMoneyNoWithTax(sender) {
            var WinMoney = StrToFloat(sender.value);

            var tbMoneyNoWithTax = document.getElementById(sender.id.replace("tbMoney", "tbMoneyNoWithTax"));

            if (!tbMoneyNoWithTax) {
                return;
            }

            if (WinMoney < 10000) {
                tbMoneyNoWithTax.value = WinMoney;
                
                return;
            }

            tbMoneyNoWithTax.value = Round(WinMoney * 0.8, 2);
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table id="Table1" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
            <tr>
                <td style="height: 30px">
                    <font face="宋体">&nbsp; 请选择
                        <asp:DropDownList ID="ddlLottery" runat="server" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList ID="ddlIsuse" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ddlIsuse_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="ReBuildWinDescription.aspx">重构中奖描述</asp:HyperLink>
                    </font>
                </td>
            </tr>
            <tr>
                <td style="height: 30px">
                    <table id="WinNumberZCDC" runat="server" visible="false" cellspacing="0" cellpadding="0" width="94%" align="center" border="0">
                        <tr>
                            <td align="center">
                                <asp:DataList ID="DataListZCDC" runat="server" RepeatColumns="1" ShowFooter="False" OnItemCommand="DataListZCDC_ItemCommand" OnItemDataBound="DataListZCDC_ItemDataBound">
                                    <HeaderTemplate>
                                        <table id="tableZCDCHeader" align="center" style="width: 672px">
                                            <tr>
                                                <td align="center" width="40" style="height: 21px; width: 40px;">
                                                    场次
                                                </td>
                                                <td align="center" style="height: 21px; width: 126px;">
                                                    联赛类别
                                                </td>
                                                <td align="center" style="height: 21px; width: 129px;">
                                                    主队
                                                </td>
                                                <td style="height: 21px; width: 18px;">
                                                </td>
                                                <td align="center" style="height: 21px; width: 129px;">
                                                    客队
                                                </td>
                                                <td align="center" style="width: 245px; height: 21px">
                                                    比赛时间(2007-07-08 12:00)
                                                </td>
                                                <td align="center" style="width: 120px; height: 21px">
                                                    修改/更新
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table align="center" style="width: 672px">
                                            <tr>
                                                <td align="center" width="40" style="height: 21px">
                                                    <asp:Label ID="lbZCDC" runat="server" Text='<%# Eval("[No]")%>'></asp:Label>
                                                </td>
                                                <td align="center" style="height: 21px; width: 126px;" bgcolor='<%# Eval("MarkersColor")%>'>
                                                    <asp:Label ID="lbType" runat="server" Text='<%# Eval("LeagueTypeName")%>'></asp:Label>
                                                </td>
                                                <td align="center" style="height: 21px; width: 129px;">
                                                    <asp:Label ID="lbZCDC1" runat="server" Text='<%# Eval("[HostTeam]")%>'></asp:Label>
                                                </td>
                                                <td style="height: 21px; width: 14px;" align="center">
                                                    <font color="red"><b>VS</b></font>
                                                </td>
                                                <td align="center" style="height: 21px; width: 129px;">
                                                    <asp:Label ID="lbZCDC2" runat="server" Text='<%# Eval("[QuestTeam]")%>'></asp:Label>
                                                </td>
                                                <td align="center" style="width: 245px; height: 21px">
                                                    <asp:Label ID="lbZCDC3" runat="server" Text='<%# DateTime.Parse(Eval("DateTime", "{0:yyyy-MM-dd HH:mm:ss}").ToString()).ToString("yy-MM-dd HH:mm")%>'></asp:Label>
                                                </td>
                                                <td align="center" style="width: 120px; height: 21px">
                                                    <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("id")%>' />
                                                    <ShoveWebUI:ShoveConfirmButton ID="btEdit" CommandName="btEdit" runat="server" Text='<%# Eval("Result").ToString() == "" ? ("输入结果"):("修改结果")%>' />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <table align="center" style="width: 672px">
                                            <tr>
                                                <td align="center" width="40" style="height: 21px">
                                                    <asp:Label ID="lbZCDC" runat="server" Text='<%# Eval("[No]")%>'></asp:Label>
                                                </td>
                                                <td align="center" style="height: 21px; width: 126px;" bgcolor='<%# Eval("MarkersColor")%>'>
                                                    <asp:Label ID="lbType" runat="server" Text='<%# Eval("LeagueTypeName")%>'></asp:Label>
                                                </td>
                                                <td align="center" style="height: 21px; width: 129px;">
                                                    <asp:Label ID="lbZCDC1" runat="server" Text='<%# Eval("[HostTeam]")%>'></asp:Label>
                                                </td>
                                                <td style="height: 21px; width: 14px;" align="center">
                                                    <font color="red"><b>VS</b></font>
                                                </td>
                                                <td align="center" style="height: 21px; width: 129px;">
                                                    <asp:Label ID="lbZCDC2" runat="server" Text='<%# Eval("[QuestTeam]")%>'></asp:Label>
                                                </td>
                                                <td align="center" style="width: 245px; height: 21px">
                                                    <asp:Label ID="lbZCDC3" runat="server" Text='<%# DateTime.Parse(Eval("DateTime", "{0:yyyy-MM-dd HH:mm:ss}").ToString()).ToString("yy-MM-dd HH:mm")%>'></asp:Label>
                                                </td>
                                                <td align="center" style="width: 60px; height: 81px">
                                                    <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("id")%>' />
                                                    <ShoveWebUI:ShoveConfirmButton ID="btUpdate" CommandName="btUpdate" runat="server" Text="确定" />
                                                    <ShoveWebUI:ShoveConfirmButton ID="btOpenWin" CommandName="btOpenWin" runat="server" Text="开奖" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table align="center" style="width: 672px">
                                            <tr>
                                                <td width="152" align="center" style="height: 21px">
                                                    是否延时：
                                                </td>
                                                <td align="left" style="height: 21px" colspan="3">
                                                    <asp:CheckBox ID="cbResultDelay" runat="server" />
                                                    是 <font color="red">注意：选中此项时，下面的结果无需录入！</font> 主队让球：
                                                    <asp:DropDownList ID="ddlLetBall" runat="server">
                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="-1">-1</asp:ListItem>
                                                        <asp:ListItem Value="-2">-2</asp:ListItem>
                                                        <asp:ListItem Value="-3">-3</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="152" align="center" style="height: 21px">
                                                    比赛结果：
                                                </td>
                                                <td align="left" style="height: 21px">
                                                    <asp:DropDownList ID="ddlGame1" runat="server">
                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                    </asp:DropDownList>
                                                    :
                                                    <asp:DropDownList ID="ddlGame2" runat="server">
                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="tbResult" runat="server" Text='<%# Eval("Result")%>' Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="tbHalftimeResult" runat="server" Text='<%# Eval("HalftimeResult")%>' Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="tbLetBall" runat="server" Text='<%# Eval("LetBall")%>' Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="tbSPFResult" runat="server" Text='<%# Eval("SPFResult")%>' Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="tbZJQResult" runat="server" Text='<%# Eval("ZJQResult")%>' Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="tbSXDSResult" runat="server" Text='<%# Eval("SXDSResult")%>' Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="tbZQBFResult" runat="server" Text='<%# Eval("ZQBFResult")%>' Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="tbBQCSPFResult" runat="server" Text='<%# Eval("BQCSPFResult")%>' Visible="false"></asp:TextBox>
                                                </td>
                                                <td width="202" align="center" style="height: 21px">
                                                    半场结果
                                                </td>
                                                <td width="132" align="left" style="height: 21px">
                                                    <asp:DropDownList ID="ddlHalftime1" runat="server">
                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                    </asp:DropDownList>
                                                    :
                                                    <asp:DropDownList ID="ddlHalftime2" runat="server">
                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 21px">
                                                    胜 平 负：
                                                </td>
                                                <td width="166" align="left" style="height: 21px">
                                                    <asp:DropDownList ID="ddlSPF" runat="server" Enabled="false">
                                                        <asp:ListItem Value="">无需编辑</asp:ListItem>
                                                        <asp:ListItem Value="3">胜</asp:ListItem>
                                                        <asp:ListItem Value="1">平</asp:ListItem>
                                                        <asp:ListItem Value="0">负</asp:ListItem>
                                                        <asp:ListItem Value="*">比赛延时</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="202" align="center" style="height: 21px">
                                                    胜 平 负开奖SP值
                                                </td>
                                                <td width="132" align="left" style="height: 21px">
                                                    <asp:TextBox ID="tbSPF_SP" runat="server" Text='<%# Eval("SPF_Sp")%>' MaxLength="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 21px">
                                                    总 进 球：
                                                </td>
                                                <td align="left" style="height: 21px">
                                                    <asp:DropDownList ID="ddlZJQ" runat="server" Enabled="false">
                                                        <asp:ListItem Value="">无需编辑</asp:ListItem>
                                                        <asp:ListItem Value="0">0球</asp:ListItem>
                                                        <asp:ListItem Value="1">1球</asp:ListItem>
                                                        <asp:ListItem Value="2">2球</asp:ListItem>
                                                        <asp:ListItem Value="3">3球</asp:ListItem>
                                                        <asp:ListItem Value="4">4球</asp:ListItem>
                                                        <asp:ListItem Value="5">5球</asp:ListItem>
                                                        <asp:ListItem Value="6">6球</asp:ListItem>
                                                        <asp:ListItem Value="7">7球以上</asp:ListItem>
                                                        <asp:ListItem Value="*">比赛延时</asp:ListItem>
                                                    </asp:DropDownList>
                                                    (7球以上：7+)
                                                </td>
                                                <td align="center" style="height: 21px">
                                                    总 进 球开奖SP值
                                                </td>
                                                <td align="left" style="height: 21px">
                                                    <asp:TextBox ID="tbZJQ_SP" runat="server" Text='<%# Eval("ZJQ_Sp")%>' MaxLength="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 21px">
                                                    上下单双：
                                                </td>
                                                <td align="left" style="height: 21px">
                                                    <asp:DropDownList ID="ddlSXDS" runat="server" Enabled="false">
                                                        <asp:ListItem Value="">无需编辑</asp:ListItem>
                                                        <asp:ListItem Value="1">上盘+单数</asp:ListItem>
                                                        <asp:ListItem Value="2">上盘+双数</asp:ListItem>
                                                        <asp:ListItem Value="3">下盘+单数</asp:ListItem>
                                                        <asp:ListItem Value="4">下盘+双数</asp:ListItem>
                                                        <asp:ListItem Value="*">比赛延时</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center" style="height: 21px">
                                                    上下单双开奖SP值
                                                </td>
                                                <td align="left" style="height: 21px">
                                                    <asp:TextBox ID="tbSXDS_SP" runat="server" Text='<%# Eval("SXDS_Sp")%>' MaxLength="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 21px">
                                                    正确比分：
                                                </td>
                                                <td align="left" style="height: 21px">
                                                    <asp:DropDownList ID="ddlZQBF" runat="server">
                                                        <asp:ListItem Value="1">1:0</asp:ListItem>
                                                        <asp:ListItem Value="2">2:0</asp:ListItem>
                                                        <asp:ListItem Value="3">2:1</asp:ListItem>
                                                        <asp:ListItem Value="4">3:0</asp:ListItem>
                                                        <asp:ListItem Value="5">3:1</asp:ListItem>
                                                        <asp:ListItem Value="6">3:2</asp:ListItem>
                                                        <asp:ListItem Value="7">4:0</asp:ListItem>
                                                        <asp:ListItem Value="8">4:1</asp:ListItem>
                                                        <asp:ListItem Value="9">4:2</asp:ListItem>
                                                        <asp:ListItem Value="10">胜其他</asp:ListItem>
                                                        <asp:ListItem Value="11">0:0</asp:ListItem>
                                                        <asp:ListItem Value="12">1:1</asp:ListItem>
                                                        <asp:ListItem Value="13">2:2</asp:ListItem>
                                                        <asp:ListItem Value="14">3:3</asp:ListItem>
                                                        <asp:ListItem Value="15">平其他</asp:ListItem>
                                                        <asp:ListItem Value="16">0:1</asp:ListItem>
                                                        <asp:ListItem Value="17">0:2</asp:ListItem>
                                                        <asp:ListItem Value="18">1:2</asp:ListItem>
                                                        <asp:ListItem Value="19">0:3</asp:ListItem>
                                                        <asp:ListItem Value="20">1:3</asp:ListItem>
                                                        <asp:ListItem Value="21">2:3</asp:ListItem>
                                                        <asp:ListItem Value="22">0:4</asp:ListItem>
                                                        <asp:ListItem Value="23">1:4</asp:ListItem>
                                                        <asp:ListItem Value="24">2:4</asp:ListItem>
                                                        <asp:ListItem Value="25">负其他</asp:ListItem>
                                                        <asp:ListItem Value="*">比赛延时</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center" style="height: 21px">
                                                    正确比分开奖SP值
                                                </td>
                                                <td align="left" style="height: 21px">
                                                    <asp:TextBox ID="tbZQBF_SP" runat="server" Text='<%# Eval("ZQBF_Sp")%>' MaxLength="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 21px">
                                                    半全场胜平负：
                                                </td>
                                                <td align="left" style="height: 21px">
                                                    <asp:DropDownList ID="ddlBQCSPF" runat="server">
                                                        <asp:ListItem Value="1">胜-胜</asp:ListItem>
                                                        <asp:ListItem Value="2">胜-平</asp:ListItem>
                                                        <asp:ListItem Value="3">胜-负</asp:ListItem>
                                                        <asp:ListItem Value="4">平-胜</asp:ListItem>
                                                        <asp:ListItem Value="5">平-平</asp:ListItem>
                                                        <asp:ListItem Value="6">平-负</asp:ListItem>
                                                        <asp:ListItem Value="7">负-胜</asp:ListItem>
                                                        <asp:ListItem Value="8">负-平</asp:ListItem>
                                                        <asp:ListItem Value="9">负-负</asp:ListItem>
                                                        <asp:ListItem Value="*">比赛延时</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center" style="height: 21px">
                                                    半全场胜平负开奖SP值
                                                </td>
                                                <td align="left" style="height: 21px">
                                                    <asp:TextBox ID="tbBQCSPF_SP" runat="server" Text='<%# Eval("BQCSPF_Sp")%>' MaxLength="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </EditItemTemplate>
                                    <EditItemStyle BackColor="#99CCFF" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                </asp:DataList>
                            </td>
                        </tr>
                    </table>
                    <table id="WinNumberOther" runat="server" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
                            <td style="height: 36px">
                                &nbsp;
                                <asp:Label ID="Label1" runat="server">开奖号码</asp:Label>
                                <asp:TextBox ID="tbWinNumber" runat="server" Width="216px"></asp:TextBox>
                                <asp:Label ID="labTip" runat="server" ForeColor="Red">格式：31032200111220</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                请输入各奖级的中奖金额<br />
                                <asp:GridView ID="g" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="g_RowDataBound" Width="331px" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="DefaultMoney,DefaultMoneyNoWithTax">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="奖级" />
                                        <asp:TemplateField HeaderText="奖金">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbMoney" runat="server" onblur="CalcMoneyNoWithTax(this);" Width="80"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="税后奖金">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbMoneyNoWithTax" runat="server" Width="80"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 39px" align="center">
                    <ShoveWebUI:ShoveConfirmButton ID="btnGO" runat="server" 
                        BackgroupImage="../Images/Admin/buttbg.gif" Width="60px" Height="20px" 
                        Text="开奖" AlertText="确信输入无误，并立即开奖吗？" OnClick="btnGO_Click" Visible="false" />
                </td>
            </tr>
            <tr>
                <td style="height: 39px" align="center">
                    <ShoveWebUI:ShoveConfirmButton ID="btnGO_Step1" runat="server" BackgroupImage="../Images/Admin/buttbg.gif" Width="60px" Height="20px" Text="开奖1"  onclick="btnGO_Step1_Click" />
                    &nbsp;
                    <ShoveWebUI:ShoveConfirmButton ID="btnGO_Step2" Enabled="false" runat="server" BackgroupImage="../Images/Admin/buttbg.gif" Width="60px" Height="20px" Text="开奖2" onclick="btnGO_Step2_Click" />
                     &nbsp;
                    <ShoveWebUI:ShoveConfirmButton ID="btnGO_Step3" Enabled="false" runat="server" BackgroupImage="../Images/Admin/buttbg.gif" Width="60px" Height="20px" Text="开奖3" onclick="btnGO_Step3_Click" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    请填写此期的开奖公告<br />
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
                            <td align="left">
                                <FTB:FreeTextBox ID="tbOpenAffiche" Width="100%" Height="340px" runat="server" 
                                    SupportFolder="../FreeTextBox/" 
                                    ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print" 
                                    ButtonSet="OfficeXP" 
                                    ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}" 
                                    Language="zh-cn" DesignModeCss="../Style/main.css" 
                                    HtmlModeCssClass="../Style/main.css" Focus="True">
                                </FTB:FreeTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input id="h_SchemeID" type="hidden" runat="server" />
        <br />
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
