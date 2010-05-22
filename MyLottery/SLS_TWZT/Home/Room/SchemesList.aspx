<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/SchemesList.aspx.cs" inherits="Home_Room_SchemesList" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="black12" style="padding-top: 2px; padding-left: 2px;
    padding-right: 2px;">
    <div style="text-align: center;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="padding-top: 10px;
            background-color: #9FC8EA;">
            <tr align="right" style="background-color: #FFFFFF;">
                <td class="blue12">
                    <asp:LinkButton ID="btnType_1" runat="server" OnClick="btnType_1_Click">千元以上</asp:LinkButton>
                    |
                    <asp:LinkButton ID="btnType_2" runat="server" OnClick="btnType_1_Click">千元以下</asp:LinkButton>
                    |
                    <asp:LinkButton ID="btnType_5" runat="server" OnClick="btnType_1_Click">已撤单</asp:LinkButton>
                    |
                    <asp:LinkButton ID="btnType_7" runat="server" OnClick="btnType_1_Click">全部方案</asp:LinkButton>
                </td>
            </tr>
            <tr style="background-color: #FFFFFF; padding-bottom: 10px;">
                <td align="center">
                    <asp:DataGrid ID="g" runat="server" Width="99%" BorderStyle="None" AllowSorting="True"
                        AllowPaging="True" AutoGenerateColumns="False" bordercolorlight="#BCD2E9" bgcolor="#E9F1F8"
                        CellPadding="0" BackColor="#E9F1F8" OnItemDataBound="g_ItemDataBound" CellSpacing="0"
                        GridLines="None">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" CssClass="blue12_line" Height="30px" ForeColor="#0066BA">
                        </HeaderStyle>
                        <ItemStyle Height="30px" HorizontalAlign="Center" BackColor="#FFFFFF" CssClass="blue12">
                        </ItemStyle>
                        <Columns>
                            <asp:BoundColumn DataField="SchemeNumber" HeaderText="方案号" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="InitiateName" HeaderText="发起人">
                                <HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Level" HeaderText="战绩">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="LotteryNumber" HeaderText="投注内容">
                                <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Money" HeaderText="总金额">
                                <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PlayTypeName" HeaderText="玩法">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IsuseName" HeaderText="期号">
                                <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Schedule" HeaderText="进度">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="QuashStatus" HeaderText="状态">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="InitiateUserID"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="QuashStatus"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="PlayTypeID"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="Buyed"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="SecrecyLevel"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="EndTime"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="IsOpened"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False"></PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="16"
                        ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="#F8F8F8" GridColor="#FFFFFF"
                        HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore"
                        RowCursorStyle="" />
                </td>
            </tr>
        </table>
    </div>
    <input id="labEndTime" runat="server" name="labEndTime" type="hidden" />
    <input id="tbIsuseID" runat="server" name="tbIsuseID" type="hidden" />
    <input id="HidLotteryID" runat="server"  type="hidden" />
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    document.getElementById("g").setAttribute("border", "1");
    document.getElementById("g").removeAttribute("style");
    document.getElementById("g").setAttribute("width", "100%");
</script>