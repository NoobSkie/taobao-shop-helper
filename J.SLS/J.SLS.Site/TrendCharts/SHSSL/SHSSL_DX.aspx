<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WithTopLotteryMenu.master"
    AutoEventWireup="true" CodeFile="SHSSL_DX.aspx.cs" Inherits="TrendCharts_SHSSL_SHSSL_DX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/Core/css.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <table style="width: 100%; height: 40px; background-image: url(../Images/bg11111.jpg);"
        cellspacing="0" cellpadding="0">
        <tbody>
            <tr>
                <td style="width: 280px" align="center" valign="middle">
                    <h1 class="td" style="font-weight: bold; font-size: 18px; display: inline;">
                        上海时时乐&nbsp;&nbsp;大小走势图</h1>
                </td>
                <td align="right" class="black12">
                    起始期数：<asp:TextBox ID="tb1" runat="server" Height="20px" Width="100px" CssClass="in_text_hui"></asp:TextBox>&nbsp;至&nbsp;<asp:TextBox
                        ID="tb2" runat="server" Height="20px" Width="100px" CssClass="in_text_hui"></asp:TextBox>
                </td>
                <td align="center" width="100" valign="middle">
                    <asp:Button ID="btnSearch" runat="server" Text="搜索" />
                </td>
                <td align="center" valign="middle">
                    <asp:Button ID="btnTop30" runat="server" Text="显示30期" />
                    <asp:Button ID="btnTop50" runat="server" Text="显示50期" />
                    <asp:Button ID="btnTop100" runat="server" Text="显示100期" />
                </td>
            </tr>
        </tbody>
    </table>
    <div id="div2" style="margin: 2px">
    </div>
    <table cellpadding="0" cellspacing="0" border="0" align="center">
        <tr>
            <td>
                <asp:GridView ID="GridView1" Width="980" runat="server" AutoGenerateColumns="false"
                    FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" align="center"
                    bordercolorlight="#808080" bordercolordark="#FFFFFF" RowStyle-HorizontalAlign="Center"
                    CellPadding="0" ShowHeader="true" OnRowCreated="GridView1_RowCreated" ShowFooter="true">
                    <Columns>
                        <asp:BoundField DataField="Isuse" HeaderText="期号">
                            <ItemStyle Font-Bold="true" CssClass="Isuse" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号码" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle Width="80" Font-Bold="true" ForeColor="#0000FF" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D1_0" HeaderText="B_0">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D1_1" HeaderText="B_1">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D2_0" HeaderText="B_2">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D2_1" HeaderText="B_3">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D3_0" HeaderText="B_4">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D3_1" HeaderText="S_0">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D_X" HeaderText="S_1">
                            <ItemStyle Width="60" BackColor="#ffe8eb" ForeColor="#0000ff" Font-Bold="true" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Z_A" HeaderText="S_2">
                            <ItemStyle CssClass="itemstyle2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Z_B" HeaderText="S_3">
                            <ItemStyle CssClass="itemstyle2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Z_C" HeaderText="S_4">
                            <ItemStyle CssClass="itemstyle2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Z_D" HeaderText="G_0">
                            <ItemStyle CssClass="itemstyle2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D_A" HeaderText="G_1">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D_B" HeaderText="G_2">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D_C" HeaderText="G_3">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D_D" HeaderText="G_4">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D_E" HeaderText="Z_0">
                            <ItemStyle CssClass="itemstyle2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D_F" HeaderText="Z_1">
                            <ItemStyle CssClass="itemstyle2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D_G" HeaderText="Z_2">
                            <ItemStyle CssClass="itemstyle2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D_H" HeaderText="Z_3">
                            <ItemStyle CssClass="itemstyle2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="H_Z_W" HeaderText="D_0">
                            <ItemStyle Width="24" BackColor="#ffe8eb" ForeColor="#0000ff" Font-Bold="true" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HZ_WJ" HeaderText="D_1">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HZ_WO" HeaderText="D_2">
                            <ItemStyle CssClass="itemstyle1" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="background-color: #1576c7; text-align: left"
                height="60" width="980">
                <br />
                <font color="#FF0000">说明：</font>1.组选：<font color="#0000ff"><strong>A.</strong></font>全小，<font
                    color="#0000FF"><strong>B.</strong></font>两小一大，<font color="#0000FF"><strong>C.</strong></font>一小两大，<font
                        color="#0000FF"><strong>D.</strong></font>全大，<font color="#0000FF"></font><br />
                &nbsp;&nbsp; &nbsp;&nbsp; 2.单选：<font color="#0000ff"><strong>A.</strong></font>小小小，<strong><font
                    color="#0000FF">B.</font></strong>小小大，<font color="#0000FF"><strong>C.</strong></font>小大小，<font
                        color="#0000FF"><strong>D.</strong></font>小大大，<font color="#0000FF"><strong>E.</strong></font>大小小，<font
                            color="#0000FF"><strong>F.</strong></font>大小大，<font color="#0000FF"><strong>G.</strong></font>大大小，<font
                                color="#0000FF"><strong>H.</strong></font>大大大
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
