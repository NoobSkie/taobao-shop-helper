<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CoBuy.aspx.cs" Inherits="Lottery_CoBuy" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>参与合买-<%=SiteName %>-手机买彩票，就上<%=SiteName%>！</title>
    <meta name="description" content="<%=SiteName %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。" />
    <meta name="keywords" content="3D参与合买" />
    <link href="../CSS/Core/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="HidIsuseID" runat="server" />
    <asp:HiddenField ID="HidLotteryID" runat="server" />
    <asp:HiddenField ID="HidNumber" runat="server" />
    <div style="padding-bottom: 8px;">
        <table cellpadding="0" cellspacing="0" style="width: 100%;" bgcolor="#F2F2F2" style="height: 50px">
            <tr>
                <td style="width: 100px;">
                    <a href="javascript:newCoBuy();" style="font-weight: bold; color: #FF0065; padding-left: 10px">
                        发起合买方案</a>
                </td>
                <td style="padding-left: 5px; width: 100px">
                    <asp:TextBox ID="TxtName" runat="server" CssClass="in_text" value="输入用户名" size="18"
                        onfocus="if(this.value=='输入用户名')this.value='';" onblur="if(this.value=='')this.value='输入用户名';"></asp:TextBox>
                </td>
                <td style="padding-left: 8px;" width="80px">
                    <ShoveWebUI:ShoveConfirmButton ID="btnSearch" runat="server" BackgroupImage="../Images/Button/button_sousuo.jpg"
                        Style="cursor: hand;" BorderStyle="None" Height="23px" OnClick="btnSearch_Click"
                        Width="72px" />
                </td>
                <td style="padding-left: 8px;" id="Personages" runat="server">
                </td>
            </tr>
        </table>
    </div>
    <div runat="server" id="divData" visible="false">
        <asp:DataGrid ID="g" runat="server" Width="100%" AllowSorting="True" bordercolorlight="#BCD2E9"
            bgcolor="#E9F1F8" AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
            CellPadding="0" BackColor="#E9F1F8" OnItemDataBound="g_ItemDataBound" CellSpacing="0"
            GridLines="None" BorderStyle="None">
            <HeaderStyle HorizontalAlign="Center" CssClass="blue12_line" Height="30px" ForeColor="#0066BA">
            </HeaderStyle>
            <ItemStyle Height="30px" HorizontalAlign="Center" BackColor="#FFFFFF" CssClass="blue12">
            </ItemStyle>
            <Columns>
                <asp:BoundColumn DataField="SchemeNumber" HeaderText="方案号" Visible="False">
                    <HeaderStyle HorizontalAlign="Center" Width="16%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="InitiateName" HeaderText="发起">
                    <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Level" HeaderText="战绩" SortExpression="Level">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Money" HeaderText="总金额" SortExpression="Money">
                    <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="PlayTypeName" HeaderText="玩法" SortExpression="Money">
                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="LotteryNumber" HeaderText="投注内容">
                    <HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Share" HeaderText="份数" SortExpression="Share">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="每份">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Schedule" HeaderText="进度" SortExpression="Schedule">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="状态">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="入伙">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" ForeColor="Red"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="讨论" Visible="false">
                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" ForeColor="Red"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="AssureMoney"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="InitiateUserID"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="QuashStatus"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="PlayTypeID"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="Buyed"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="SecrecyLevel"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="EndTime"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="IsOpened"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="LotteryID"></asp:BoundColumn>
            </Columns>
            <PagerStyle Visible="False"></PagerStyle>
        </asp:DataGrid>
        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="10"
            ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="#F8F8F8" GridColor="#FFFFFF"
            HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore"
            RowCursorStyle="" />
    </div>
    <div id="divLoding" runat="server" style="line-height: 35px; height: 100%; overflow: hidden;"
        visible="true">
        <img src='../Images/londing.gif' style="position: relative; top: 10%; left: 40%;"
            alt="" />
    </div>
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
    function newCoBuy() {
       parent.document.getElementById("TabMenu").childNodes(1).click();
    }

    function personages(name) {
        document.getElementById("TxtName").value = name;

    }

    function postback() {
        __doPostBack('btnSearch', '');
    }
    
    function document.onreadystatechange()
        {
            if (document.readyState=="complete") {
            <%= script.ToString() %>
            }
    }

</script>

