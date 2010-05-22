<%@ page language="C#" autoeventwireup="true" CodeFile="UserAccountDetail.aspx.cs" inherits="Home_Room_MyPromotion_UserAccountDetail" enableEventValidation="false" %>


<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" rel="stylesheet" type="text/css" />
    
    <script language="javascript" type="text/javascript" src="../../../Components/My97DatePicker/WdatePicker.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table  width="842" border="0" cellpadding="0" cellspacing="0"
            bgcolor="#DDDDDD" style="padding-left: 0px; padding-top: 0px; border-left: 1px solid #DDDDDD;
            border-right: 1px solid #DDDDDD;">
            <tr>
                <td height="30" colspan="10" align="left" bgcolor="#EEEEEE" style="padding: 5px 10px 5px 10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="black12" style="padding-left:50px">
                                 按出票日期查询: &nbsp;开始日期：
                <asp:TextBox runat="server" ID="tbBeginTime"    CssClass="in_text" size="20" onblur="if(this.value=='') this.value=document.getElementById('tbBeginTime').value"
                    name="tbBeginTime" onFocus="WdatePicker({el:'tbBeginTime',dateFmt:'yyyy-MM-dd', maxDate:'%y-%M-%d'})"
                    Height="15px" />
                &nbsp;&nbsp; 结束日期：
                <asp:TextBox runat="server" ID="tbEndTime"   CssClass="in_text" size="20" name="tbEndTime" onblur="if(this.value=='') this.value=document.getElementById('tbEndTime').value"
                    onFocus="WdatePicker({el:'tbEndTime',dateFmt:'yyyy-MM-dd', maxDate:'%y-%M-%d'})"
                    Height="15px" />
                <ShoveWebUI:ShoveConfirmButton ID="btnSearch" runat="server" BackgroupImage="../images/button_sousuo.jpg"
                                Style="cursor: hand;" BorderStyle="None" Height="23px" Width="72px" 
                                onclick="btnSearch_Click" />
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
           
        <asp:DataGrid ID="g" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
            PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
             Font-Names="Tahoma"  
            CellSpacing="1" GridLines="None">
            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
            <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                CssClass="blue12_2"></HeaderStyle>
            <AlternatingItemStyle BackColor="#F8F8F8" />
            <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                CssClass="black12" />
            <Columns>
                <asp:BoundColumn DataField="Name" HeaderText="会员">
                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="IsuseName" HeaderText="期号">
                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:HyperLinkColumn DataNavigateUrlField="SchemeID" DataTextField="SchemeNumber" Target="_blank" 
                    HeaderText="方案号" DataNavigateUrlFormatString="../Scheme.aspx?id={0}">
                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                    <ItemStyle HorizontalAlign="Center"   CssClass="red12_2"/>
                </asp:HyperLinkColumn>
                <asp:BoundColumn DataField="LotteryName" HeaderText="彩种">
                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="PlayTypeName" HeaderText="方案类型">
                    <HeaderStyle HorizontalAlign="Center" Width="140px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Money" HeaderText="方案金额" DataFormatString="{0:N2}">
                    <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="right"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="DetailMoney" HeaderText="购买金额" DataFormatString="{0:N2}">
                    <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="right"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="DateTime" HeaderText="购买时间" DataFormatString="{0:yyyy-MM-dd}">
                    <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                
            </Columns>
            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
            </PagerStyle>
        </asp:DataGrid>
        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="798" PageSize="30" ShowSelectColumn="False"
                    DataGrid="g" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0" HotColor="MistyRose"
                    Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore"
                    RowCursorStyle="" AllowShorting="true" />
    </div>
   
    </form>
</body>
</html>

