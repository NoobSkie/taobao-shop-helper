<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/7Xing/7X_HZheng.aspx.cs" inherits="_7Xing_7X_HZheng" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>七星彩和值走试图</title>
    <style type="text/css">
        body
        {
            font-family: tahoma;
            margin: 0px;
            margin-left: 10px;
            margin-right: 10px;
            text-align: center;
        }
        body, td, th
        {
            font-size: 12px;
            font-family: 宋体;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%; height: 40px; background-image: url(../Images/bg11111.jpg);"
        cellspacing="0" cellpadding="0">
        <tbody>
            <tr>
                <td align="center" valign="middle" style="width: 300px; font-weight: bold; font-size: 18px;
                    color: #CC0000">
                    七星彩&nbsp;&nbsp;和值横向分布图
                </td>
                <td style="width: 700px; color: blue; font-style: normal; height: 6px;" align="left">
                    选择最近期数
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="100期" AutoPostBack="True"
                        GroupName="group" OnCheckedChanged="RadioButton1_CheckedChanged1" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="50期" AutoPostBack="True"
                        OnCheckedChanged="RadioButton2_CheckedChanged" GroupName="group" />
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="30期" AutoPostBack="True"
                        Checked="true" OnCheckedChanged="RadioButton3_CheckedChanged" GroupName="group" />
                    <asp:RadioButton ID="RadioButton4" runat="server" Text="20期" AutoPostBack="True"
                        GroupName="group" OnCheckedChanged="RadioButton4_CheckedChanged1" />
                    <asp:RadioButton ID="RadioButton5" runat="server" Text="10期" AutoPostBack="True"
                        GroupName="group" OnCheckedChanged="RadioButton5_CheckedChanged1" />
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td align="center" style="background-color: #FFFFFF;">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr style="background-color: #EEEEEE">
                                <td style="background-color: #EFEFEF; text-align: left; font-size: 12px; width: 500px;">
                                    <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                                        padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_QXC.aspx") %>"
                                            target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">七星彩投注/合买</a>
                                    <a href="<%= ResolveUrl("~/WinQuery/3-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                                        text-decoration: none; color: Red;">七星彩中奖查询</a>
                                </td>
                                <td align="center" style="height: 24PX">
                                    <b>七星彩开奖号码和值[横向]分布图[<a href="7X_ZHZhong.aspx"><font color="#FF0000">点击切换到纵向分布图]</font></a></b>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr style="background-color: #FFFFFF">
                <td valign="top" style="border-color: #FFFFFF">
                    <table style="width: 100%" border="1" align="center" cellpadding="0" cellspacing="0"
                        bordercolorlight="#CCCCCC" bordercolordark="#FFFFFF">
                        <tr align="center" valign="middle">
                            <td valign="top">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="False"
                                    OnRowCreated="GridView1_RowCreated" ShowFooter="true" Width="100%" bordercolorlight="#808080"
                                    bordercolordark="#FFFFFF" align="center" CellPadding="0" CellSpacing="0">
                                    <Columns>
                                        <asp:BoundField DataField="Isuse" HeaderText="期 数">
                                            <ItemStyle Width="60px" Font-Names="宋体" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号码">
                                            <ItemStyle Width="60px" Font-Bold="True" Font-Names="宋体" ForeColor="#0000FF" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_Z" HeaderText="H_Z">
                                            <ItemStyle Width="30px" BackColor="#ffffff" Font-Bold="True" ForeColor="000000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_10" HeaderText="A_10">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_11" HeaderText="A_11">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_12" HeaderText="A_12">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_13" HeaderText="A_13">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_14" HeaderText="A_14">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_15" HeaderText="A_15">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_16" HeaderText="A_16">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_17" HeaderText="A_17">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_18" HeaderText="A_18">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_19" HeaderText="A_19">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_20" HeaderText="A_20">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_21" HeaderText="A_21">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_22" HeaderText="A_22">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_23" HeaderText="A_23">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_24" HeaderText="A_24">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_25" HeaderText="A_25">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_26" HeaderText="A_26">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_27" HeaderText="A_27">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_28" HeaderText="A_28">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_29" HeaderText="A_29">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_30" HeaderText="A_30">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_31" HeaderText="A_31">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_32" HeaderText="A_32">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_33" HeaderText="A_33">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_34" HeaderText="A_34">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_35" HeaderText="A_35">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_36" HeaderText="A_36">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_37" HeaderText="A_37">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_38" HeaderText="A_38">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_39" HeaderText="A_39">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_40" HeaderText="A_40">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_41" HeaderText="A_41">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_42" HeaderText="A_42">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_43" HeaderText="A_43">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_44" HeaderText="A_44">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_45" HeaderText="A_45">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_46" HeaderText="A_46">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_47" HeaderText="A_47">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_48" HeaderText="A_48">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_49" HeaderText="A_49">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_50" HeaderText="A_50">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="A_51" HeaderText="A_51">
                                            <ItemStyle Width="13px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
