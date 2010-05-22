<%@ page language="C#" autoeventwireup="true" CodeFile="User.aspx.cs" inherits="Admin_User" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="96%" height="34" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#85BDE2">
                <tr>
                    <td height="32" bgcolor="#B0D5EC" class="STYLE14">
                        <div align="left" class="STYLE4">
                            <div align="center">
                                祖国60年注册充值赠送活动</div>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
						<asp:datagrid id="g" runat="server" CellPadding="0" BackColor="White" BorderWidth="2px" BorderStyle="None"
							BorderColor="#E0E0E0" Font-Names="宋体" PageSize="20" AllowSorting="True" AutoGenerateColumns="False"
							AllowPaging="True" OnItemDataBound="g_ItemDataBound" Width="100%">
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="LightGray" Wrap="True" Height="28px"></HeaderStyle>
							<ItemStyle Height="28px" />
							<Columns>
								<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="用户名">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RealityName" SortExpression="RealityName" HeaderText="真实姓名">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IDCardNumber" SortExpression="IDCardNumber" HeaderText="身份证">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="邮箱">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="QQ" SortExpression="QQ" HeaderText="QQ">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Telephone" SortExpression="Telephone" HeaderText="电话">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Mobile" SortExpression="Mobile" HeaderText="手机">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RegisterTime" SortExpression="RegisterTime" HeaderText="注册时间">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BankName" SortExpression="BankName" HeaderText="开户行">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BankCardNumber" SortExpression="BankCardNumber" HeaderText="银行卡号">
									<HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
							</Columns>
							<PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                            <ItemStyle Wrap="True" />
						</asp:datagrid>
						<ShoveWebUI:ShoveGridPager id="gPager" runat="server" Width="100%" ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="Linen"
							GridColor="#E0E0E0" HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore"></ShoveWebUI:ShoveGridPager>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>

