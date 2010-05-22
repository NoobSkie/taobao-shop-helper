<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/EditFriendFollowScheme.aspx.cs" inherits="Home_Room_EditFriendFollowScheme" enableEventValidation="false" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" charset="gbk">
        function showDialog(url)
        {
            var dialogWidth = 550;
            var dialogHeight = 250;
            var w = window.showModalDialog(url + "&r=" + Math.random(),"","dialogWidth:"+dialogWidth+"px;dialogHeight="+dialogHeight+"px;center:yes;status:no;help:no;");
            
            if(w == "1")
            {
                __doPostBack('btnSearch','');
            }
            else
            {
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg_blue_30.jpg">
                        <tr>
                            <td height="30">
                                <table width="738" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="40" height="30" align="center">
                                            <img src="images/jiantou_5.gif" width="12" height="8" />
                                        </td>
                                        <td class="blue_num">
                                            我定制的好友定制自动跟单
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tr>
                            <td valign="top">
                                <div style="padding-top: 10px; padding-bottom: 10px;">
                                    <asp:DataGrid ID="g" runat="server" Width="100%" BorderStyle="None" AllowSorting="True"
                AllowPaging="True" PageSize="22" AutoGenerateColumns="False" CellPadding="2"
                BackColor="#9FC8EA" Font-Names="Tahoma" OnItemDataBound="g_ItemDataBound" CellSpacing="1"
                OnItemCommand="g_ItemCommand" GridLines="None" BorderColor="#E0E0E0" BorderWidth="2px">
                <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                    BackColor="#E9F1F8" Height="25px"></HeaderStyle>
                <ItemStyle Height="21px"></ItemStyle>
                <Columns>
                    <asp:BoundColumn DataField="Name" HeaderText="好友">
                        <HeaderStyle HorizontalAlign="Center" Width="16%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="战绩">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="已定制/可定制">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="所有跟单人">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="我的定制状态">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="定制自动跟单">
                        <ItemTemplate>
                            <asp:Label ID="lbEdit" runat="server"></asp:Label>
                            <ShoveWebUI:ShoveLinkButton ID="Cancel" runat="server" CommandName="Cancel" AlertText="您确认取消此定制跟单吗?" Visible="false">取消</ShoveWebUI:ShoveLinkButton>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                    <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                </Columns>
                <PagerStyle Visible="False"></PagerStyle>
            </asp:DataGrid>
                                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="30"
                                        ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="#F7FEFA" GridColor="#E0E0E0"
                                        HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange"
                                        OnSortBefore="gPager_SortBefore" RowCursorStyle="" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HidLotteryID" runat="server" Value="5" />
    </form>
        <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
