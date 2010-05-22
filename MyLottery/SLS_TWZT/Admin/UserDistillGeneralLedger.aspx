<%@ page language="C#" autoeventwireup="true" CodeFile="UserDistillGeneralLedger.aspx.cs" inherits="Admin_UserDistillGeneralLedger" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../Components/My97DatePicker/WdatePicker.js"></script>

    <style type="text/css">
        .red142
        {
            font-size: 14px;
            color: #cc0000;
            font-family: "tahoma";
            line-height: 22px;
        }
        .red142 A:link
        {
            font-family: "tahoma";
            color: #cc0000;
            text-decoration: underline;
        }
        .red142 A:active
        {
            font-family: "tahoma";
            color: #cc0000;
            text-decoration: none;
        }
        .red142 A:visited
        {
            font-family: "tahoma";
            color: #cc0000;
            text-decoration: none;
        }
        .red142 A:hover
        {
            font-family: "tahoma";
            color: #cc0000;
            text-decoration: none;
        }
        .blue12
        {
            font-family: "tahoma";
            color: #cc0000;
            text-decoration: none;
        }
        
        .SelectedTab
        {
        	 cursor: pointer;
        	 background-image: url('../Home/Room/Images/admin_qh_100_1.jpg'); 
        	 background-repeat: no-repeat;
        }
        .NotSelectedTab
        {
        	 cursor: pointer;
        	 background-image: url('../Home/Room/Images/admin_qh_100_2.jpg'); 
        	 background-repeat: no-repeat;
        }
        .style1
        {
            width: 262px;
        }
        </style>

    <script language="javascript" type="text/javascript">
        function clickTab(obj)
        {

            ChangeBackgroundImg();

            switch (obj.id)
            {
                case 'PayByAlipay':
                    document.getElementById("PayByAlipay").className = 'blue12';
                    document.getElementById("PayByAlipay").style.fontWeight = "bold";
                    document.getElementById("PayByAlipay").style.backgroundImage = "url('../Home/Room/images/admin_qh_100_1.jpg')";
                    break;
                case 'PayByBank':
                    document.getElementById("PayByBank").className = 'blue12';
                    document.getElementById("PayByBank").style.fontWeight = "bold";
                    document.getElementById("PayByBank").style.backgroundImage = "url('../Home/Room/images/admin_qh_100_1.jpg')";

                    break;
                case 'AllPay':
                    document.getElementById("AllPay").className = 'blue12';
                    document.getElementById("AllPay").style.fontWeight = "bold";
                    document.getElementById("AllPay").style.backgroundImage = "url('../Home/Room/images/admin_qh_100_1.jpg')";
            }

        }

        function ChangeBackgroundImg()
        {
            var arrCells = new Array('PayByAlipay', 'PayByBank', 'AllPay');
            var length = arrCells.length;

            for (var i = 0; i < length; i++)
            {
                document.getElementById(arrCells[i]).style.backgroundImage = "url('../Home/Room/Images/admin_qh_100_2.jpg')";
                document.getElementById(arrCells[i]).className = 'blue12';
                document.getElementById("PayByAlipay").style.fontWeight = "normal";
            }
        }
    </script>

</head>
<body style="margin-left: 10px">
    <form id="form1" runat="server">
        <asp:HiddenField  ID="hfCurPayType" runat="server" Value="银行" />
           
        <div style="border: 1px solid #BCD2E9; width: 99%; margin-top: 10px; margin-bottom: 8px; background-color: #F4F9FC; height: 60px; vertical-align: middle;" >
            <div style="border-color: #BCD2E9; width: 100%;  height: 25px; vertical-align: middle; " align="center">
                <span style="font-size: 14px; font-weight: bold; margin-top: 5px; color: #226699">提款对帐单</span>  
            </div>
            <div style="border-color: #BCD2E9; width: 100%; margin-top: 2px; margin-bottom: 8px; background-color: #F4F9FC; height: 25px; vertical-align: middle; border-top-style: solid; border-top-width: 1px;" align="left" >
                 <table cellspacing="0" cellpadding="0" width="99%" border="0" >
                    <tr>
                        <td style="height: 30px">
                            &nbsp;开始日期
                                <asp:TextBox runat="server" ID="tbBeginTime" Width="100px" onblur="if(this.value=='') this.value=document.getElementById('hBeginTime').value"
                                    name="tbBeginTime" onFocus="WdatePicker({el:'tbBeginTime',dateFmt:'yyyy-MM-dd', maxDate:'%y-%M-%d'})"
                                    Height="15px" />
                                &nbsp;结束日期
                                <asp:TextBox runat="server" ID="tbEndTime" Width="100px" name="tbEndTime" onblur="if(this.value=='') this.value=document.getElementById('hEndTime').value"
                                    onFocus="WdatePicker({el:'tbEndTime',dateFmt:'yyyy-MM-dd', maxDate:'%y-%M-%d'})"
                                    Height="15px" />
                                &nbsp;&nbsp;<span style="color: #ff0000"><asp:Button ID="btnSearch" runat="server" Text="搜索" Height="22px" Width="40px"
                                        BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" OnClick="btnSearch_Click" />
                                </span>&nbsp;<span style="color: #ff0000">&nbsp;</span>
                         </td>
                    </tr>
                </table>
            </div>
         </div>
           
   
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
           
        <table border="0" cellspacing="0" cellpadding="0" width="99%">
            <tr>
                <td>
                      <table border="0" cellspacing="0" cellpadding="0" background="../Home/Room/images/zfb_left_bg_2.jpg" style="margin-top: 5px;">
                        <tr>
                            <td width="6px" height="29" align="left">&nbsp;
                                
                            </td>
                            <td id="tdDuiZhangDan" runat="server" class="NotSelectedTab" width="100px" align="center"  >
                                <asp:LinkButton runat="server" ID="lbtnDuiZhangDan" 
                                    OnClientClick="return true;" onclick="lbtnDuiZhangDan_Click">提款对帐单</asp:LinkButton>
                            </td>
                            <td width="6px">&nbsp;
                                
                            </td>
                            <td id="tdBankDetail" runat="server"  class="NotSelectedTab" width="100px" align="center" >
                                <asp:LinkButton runat="server" ID="lbtnBankDetail" OnClientClick="return true;" 
                                    onclick="lbtnBankDetail_Click">银行明细</asp:LinkButton>
                            </td>
              
                            <td width="6px">&nbsp;
                                
                            </td>
                            <td align="center" >&nbsp;
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
               <td height="1" bgcolor="#FFFFFF">
               
               <div id="DuiZhangDan" runat="server">
                  <asp:DataGrid ID="dgDuiZhangDan" runat="server" Width="100%" 
                       AutoGenerateColumns="False" CellPadding="1"
                    BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#E0E0E0"
                    Font-Names="宋体" AllowPaging="True" 
                    AllowSorting="True">
                    <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                    <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                    <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                        BackColor="#E7F1FA"></HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="序号">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <%# Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DistillTypeName" HeaderText="栏目" SortExpression="DistillTypeName">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SumMoney" HeaderText="总额"  DataFormatString="{0:N2}"  SortExpression="SumMoney">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DistillCount" HeaderText="提款笔数" DataFormatString="{0:N2}" SortExpression="DistillCount">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" ForeColor="#FF0000"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AverageMoney" HeaderText="平均每笔金额" DataFormatString="{0:N2}" SortExpression="AverageMoney">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" ForeColor="#FF0000"></ItemStyle>
                        </asp:BoundColumn>
                        
                        <asp:BoundColumn DataField="SumFormalitiesFees" HeaderText="手续费累计" DataFormatString="{0:N2}"
                            SortExpression="SumFormalitiesFees">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AverageFormalitiesFees" HeaderText="平均每笔手续费" DataFormatString="{0:N2}" SortExpression="AverageFormalitiesFees">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" ForeColor="#FF0000"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AverageHandleTime" HeaderText="平均受理周期(小时)" SortExpression="AverageHandleTime">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
    
                         <asp:TemplateColumn HeaderText="备注">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                               
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                    </PagerStyle>
                </asp:DataGrid>
                
                  <table width="100%" >
                    <tr>
                        <td >
                             当前累计充值收款:
                               <asp:Label ID="lblSumAddMoneyByDate1" runat="server" Text="lblSumAddMoneyByDate1"></asp:Label>
                        </td>
                        <td>
                         当前累计提款金额:
                           <asp:Label ID="lblSumDistillMoneyByDate1" runat="server" Text="lblSumDistillMoneyByDate1"></asp:Label>
                        </td>
                        <td>
                        当前累计手续费:
                          <asp:Label ID="lblSumFormalitiesFeesByDate1" runat="server" Text="lblSumFormalitiesFeesByDate1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            历史累计充值收款:
                              <asp:Label ID="lblSumAddMoney1" runat="server" Text="lblSumAddMoney1"></asp:Label>
                        </td>
                        <td>
                            历史累计提款金额:
                              <asp:Label ID="lblSumDistillMoney1" runat="server" Text="lblSumDistillMoney1"></asp:Label>
                        </td>
                        <td>
                            历史累计手续费:
                            <asp:Label ID="lblSumFormalitiesFees1" runat="server" Text="lblSumFormalitiesFees1"></asp:Label>
                        </td>
                    </tr>
                </table>
               </div>
               
               <div id="BankDetail" runat="server">
                <asp:DataGrid ID="dgBankDetail" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
                    BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#E0E0E0"
                    Font-Names="宋体" PageSize="30" AllowPaging="True" 
                    AllowSorting="True">
                    <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                    <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                    <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                        BackColor="#E7F1FA"></HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="序号">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <%# Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="AccountName" HeaderText="银行" SortExpression="AccountName">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SumMoney" HeaderText="总额" DataFormatString="{0:N2}" SortExpression="SumMoney">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DistillCount" HeaderText="提款笔数" DataFormatString="{0:N2}" SortExpression="DistillCount">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" ForeColor="#FF0000"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AverageMoney" HeaderText="平均每笔金额" DataFormatString="{0:N2}" SortExpression="AverageMoney">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" ForeColor="#FF0000"></ItemStyle>
                        </asp:BoundColumn>
                        
                        <asp:BoundColumn DataField="SumFormalitiesFees" HeaderText="手续费累计" DataFormatString="{0:N2}"
                            SortExpression="SumFormalitiesFees">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AverageFormalitiesFees" HeaderText="平均每笔手续费" DataFormatString="{0:N2}" SortExpression="AverageFormalitiesFees">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" ForeColor="#FF0000"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AverageHandleTime" HeaderText="平均受理周期(小时)" SortExpression="AverageHandleTime">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>



    
                    </Columns>
                    <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                    </PagerStyle>
                </asp:DataGrid>

                   
                <table style="width:100%;">
                    <tr>
                    <td class="style1">
                         当前累计充值收款：<asp:Label ID="lblSumAddMoneyByDate2" runat="server" Text="lblSumAddMoneyByDate2"></asp:Label>
                    </td>
                        <td>
                         当前累计提款金额：<asp:Label ID="lblSumDistillMoneyByDate2" runat="server" Text="lblSumDistillMoneyByDate2"></asp:Label>
                        </td>
                        <td>
                        当前累计手续费：<asp:Label ID="lblSumFormalitiesFeesByDate2" runat="server" Text="lblSumFormalitiesFeesByDate2"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            历史累计充值收款：<asp:Label ID="lblSumAddMoney2" runat="server" Text="lblSumAddMoney2"></asp:Label>
                        </td>
                        <td>
                            历史累计提款金额：<asp:Label ID="lblSumDistillMoney2" runat="server" Text="lblSumDistillMoney2"></asp:Label>
                        </td>
                        <td>
                            历史累计手续费：<asp:Label ID="lblSumFormalitiesFees2" runat="server" Text="lblSumFormalitiesFees2"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">&nbsp;
                            </td>
                        <td>&nbsp;
                            </td>
                        <td>&nbsp;
                            </td>
                    </tr>
                </table>

               </div>
               
                </td>
            </tr>
        </table>
                   
   

    </form>
    
    
    </body>
</html>
