<%@ page language="C#" autoeventwireup="true" CodeFile="ProcessingMoney.aspx.cs" inherits="Admin_ProcessingMoney" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="../Components/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <table width="90%" height="34" border="0" align="center" cellpadding="0" cellspacing="1"
            bgcolor="#85BDE2">
            <tr>
                <td height="32" bgcolor="#B0D5EC" class="STYLE14">
                    <div align="left" class="STYLE4">
                        <div align="center">
                            处理用户充值
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbName" runat="server" Text="姓名"></asp:Label>
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>&nbsp;
                    开始日期
                    <asp:TextBox runat="server" ID="tbBeginTime" Width="140px" onblur="if(this.value=='') this.value=document.getElementById('hBeginTime').value"
                                                        name="tbBeginTime" onFocus="WdatePicker({el:'tbBeginTime',dateFmt:'yyyy-MM-dd HH:mm:ss', maxDate:'%y-%M-%d'})"
                                                        Height="15px" />&nbsp;
                    结束日期
                    <asp:TextBox runat="server" ID="tbEndTime" Width="140px" name="tbEndTime" onblur="if(this.value=='') this.value=document.getElementById('hEndTime').value"
                    onFocus="WdatePicker({el:'tbEndTime',dateFmt:'yyyy-MM-dd HH:mm:ss', maxDate:'%y-%M-%d'})"
                    Height="15px" />
                    &nbsp;<asp:Button ID="btn_name" runat="server" Text="查找" Width="89px" OnClick="btn_Search_Click" />
                </td>
            </tr>
        </table>
        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
            <td valign="middle">
                <iframe id="frmmain" runat="server" name="frmmain" scrolling="no" style="width: 0px;
            height: 0px;"></iframe>
            </td>
                <td align="center">
                    <asp:DataGrid ID="g" runat="server" CellPadding="0" BackColor="White" BorderWidth="2px"
                        BorderStyle="None" BorderColor="#E0E0E0" Font-Names="宋体" PageSize="20" AllowSorting="True"
                        AutoGenerateColumns="False" AllowPaging="True" OnItemDataBound="g_ItemDataBound"
                        Width="100%" OnItemCommand="g_ItemCommand">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                            BackColor="LightGray"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="订单号">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:HyperLinkColumn DataNavigateUrlField="UserID" DataTextField="Name" HeaderText="用户名"
                                DataNavigateUrlFormatString="UserDetail.aspx?id={0}" SortExpression="Name"></asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="充值时间">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Money" SortExpression="Money" HeaderText="充值金额">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PayType" SortExpression="PayType" HeaderText="充值类型">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FormalitiesFees" SortExpression="FormalitiesFees" HeaderText="手续费">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="描述">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:TextBox ID="tbDescription" runat="server" Width="336px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <ShoveWebUI:ShoveLinkButton ID="btnQuery" runat="server" CommandName="Query">查询是否到帐</ShoveWebUI:ShoveLinkButton>
                                    <ShoveWebUI:ShoveLinkButton ID="btnAccept" runat="server" CommandName="Accept" AlertText="您确信输入无误，并立即处理这个用户的充值？"
                                        Visible="false">同意</ShoveWebUI:ShoveLinkButton>
                                    <ShoveWebUI:ShoveLinkButton ID="btnDel" runat="server" CommandName="Del" AlertText="您确信输入无误，并立即处理这个用户的充值？">删除</ShoveWebUI:ShoveLinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="UserID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="payType" Visible="False"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" ShowSelectColumn="False"
                        DataGrid="g" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose"
                        Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore">
                    </ShoveWebUI:ShoveGridPager>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
    
    <%--    刘美慧添加 用于判断财付通查询是否出错，即查询过程中被导航到财付通的错误提示页面，而没有正常返回信息 --%>

    <script language="javascript" type="text/javascript">

        var isError = true;//如果成功有返回信息，此值被修改为False

        function IsError(payNumber) {

            var frm = document.getElementById("frmmain");

            if (isError && frm.src != "") {

                frm.src = "";

                alert("支付号为 " + payNumber + " 的支付记录没有充值成功，描述：该支付记录未支付成功！");
            }

        }
    
    </script>

</body>
</html>
