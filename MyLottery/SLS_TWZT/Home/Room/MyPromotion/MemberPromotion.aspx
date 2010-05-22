<%@ page language="C#" autoeventwireup="true" CodeFile="MemberPromotion.aspx.cs" inherits="Home_Room_MyPromotion_MemberPromotion" enableEventValidation="false" %>
    <%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="../UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员推广-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="keywords" content="会员推广" />
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
     <link href="../Style/css.css" rel="stylesheet" type="text/css" />
    
</head><link rel="shortcut icon" href="../../../favicon.ico"/>
<body >
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
         <div id="menu_right" style="margin-top:0px">
          <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr>
                <td width="40" height="30" align="right" valign="middle" class="red14">
                    <img src="../images/icon_13.gif" width="19" height="16" />
                </td>
                <td valign="middle" class="red14" style="padding-left: 10px;">
                    我的推广拥金
                </td>
            </tr>
        </table>
        <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr>
                <td width="20" height="29">
                    &nbsp;
                </td>
                <td width="100" align="center" background="../images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;" id="tdMemberPromotion1" onclick="ClickMenu(this)">
                    我的彩友圈
                </td>
               
                <td width="6">
                    &nbsp;
                </td>
                <td width="100" align="center" background="../images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;"  id="tdMemberPromotion2" onclick="ClickMenu(this)">
                    我推广的会员
                </td>
                <td width="6">
                    &nbsp;
                </td>
                <td width="100" align="center" background="../images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;" id="tdMemberPromotion3" onclick="ClickMenu(this)">
                    我要推广
                </td>
                <td width="6">
                    &nbsp;
                </td>
                <td width="100" align="center" background="../images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;" id="tdMemberPromotion4" onclick="ClickMenu(this)">
                    我的拥金
                </td>
               
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="1" colspan="17" bgcolor="#FFFFFF">
                </td>
            </tr>
            <tr>
                <td height="2" colspan="17" bgcolor="#6699CC">
                </td>
            </tr>
        </table>
          <div id="divMemberPromotion1">
              <table width="100%" border="0" cellspacing="1" cellpadding="0">
        <tr>
            <td align="center" bgcolor="#FFFFFF" class="black12" style="padding: 10px 0px 10px 0px;">
                <img src="../images/ad_tuiguang.jpg" width="740" height="80" />
            </td>
        </tr>
        <tr>
            <td bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                1、什么是“彩友圈”？
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px; text-indent: 20px;">
                <%=_Site.Name %>推出的“彩友圈”功能，可以把你平时一起购彩的好友推荐到<%=_Site.Name %>来购彩，同时可以通过推荐获得推广佣金。
            </td>
        </tr>
        <tr>
            <td bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                2、如何通过“彩友圈”赚钱？
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px; text-indent: 20px;">
                凡是<%=_Site.Name %>会员，每推荐一个会员，就可以获得这个会员购彩金额的0.5%作为佣金。只要推荐的会员当月销售金额超过300元，超出部分的推荐佣金高达1%。

            </td>
        </tr>
        <tr>
            <td bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                3、彩友圈赚到的佣金如何提现？
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px; text-indent: 20px;">
                彩友圈的推广佣金按自然月进行结算。每个月的1号系统自动将计算会员上个月的推广佣金后，可将您推广的佣金轻松提款至您指定的银行账户或支付宝账户。
            </td>
        </tr>
        <tr>
            <td align="center" bgcolor="#f7f7f7" style="padding: 15px;">
                <a href="javascript:;" onclick="tdMemberPromotion3.click();">
                    <img src="../images/button_tuiguang.jpg" width="204" height="40" border="0" /></a>
            </td>
        </tr>
    </table>
          </div> 
          <div id="divMemberPromotion2" style="display:none">
              <table  width="842" border="0" cellpadding="0" cellspacing="0"
            bgcolor="#DDDDDD" style="padding-left: 0px; padding-top: 0px; border-left: 1px solid #DDDDDD;
            border-right: 1px solid #DDDDDD;">
            <tr>
                <td height="30" colspan="10" align="left" bgcolor="#EEEEEE" style="padding: 5px 10px 5px 10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="black12" style="padding-left:50px">
                                 <asp:TextBox ID="tbUserName" runat="server" Text="请输入用户名" CssClass="in_text" size="30"
                                onfocus="if(this.value=='请输入用户名') this.value='';" onblur="if(this.value=='') this.value='请输入用户名'"></asp:TextBox>
                                
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
            CellSpacing="1" GridLines="None" onitemdatabound="g_ItemDataBound">
            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
            <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                CssClass="blue12_2"></HeaderStyle>
            <AlternatingItemStyle BackColor="#F8F8F8" />
            <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                CssClass="black12" />
            <Columns>
                <asp:BoundColumn DataField="Count" HeaderText="序号">
                    <HeaderStyle HorizontalAlign="Center" Width="4%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="用户名" DataField="Name">
                    <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="注册时间" DataField="RegisterTime" SortExpression="RegisterTime">
                    <HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="今日消费" DataField="TodayTradeMoney" SortExpression="TodayTradeMoney" DataFormatString ="{0:N2}">
                    <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="昨日消费" DataField="YesterdayTradeMoney" SortExpression="YesterdayTradeMoney" DataFormatString ="{0:N2}">
                    <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                 <asp:BoundColumn HeaderText="本月消费" DataField="ThisMonthTradeMoney" SortExpression="ThisMonthTradeMoney" DataFormatString ="{0:N2}">
                    <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="累计总消费" DataField="TotalTradeMoney" SortExpression="TotalTradeMoney" DataFormatString ="{0:N2}">
                    <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
               <asp:TemplateColumn HeaderText="查看">
                            <HeaderStyle HorizontalAlign="Center" Width="28%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbDetail" runat="server" Text="交易明细" style="cursor:pointer" CssClass="red12_2"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="MemberID" DataField="MemberID" Visible ="false" />
            </Columns>
            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
            </PagerStyle>
        </asp:DataGrid>
        <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 15px;">
            <tr>
                <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="798" PageSize="30" ShowSelectColumn="False"
                    DataGrid="g" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0" HotColor="MistyRose"
                    Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore"
                    RowCursorStyle="" AllowShorting="true" />
            </tr>
        </table>
          <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
            <tr>
                <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    今日消费总计：
                    <asp:Label ID="lbTodaySales1" runat="server" Text ="0.00"  CssClass="red12"/>
                </td>
                 <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    昨日消费总计：
                    <asp:Label ID="lbYesterdaySales1" runat="server" Text ="0.00"  CssClass="red12"/>
                </td>
            </tr>
            <tr>
                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    本月消费总计：
                    <asp:Label ID="lbMonthSales1" runat="server" Text="0.00" CssClass="red12" />
                </td>
                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    总消费总计：
                    <asp:Label ID="lbSales1" runat="server" Text="0.00" CssClass="red12" />
                </td>
            </tr>
        </table>
          </div> 
          <div id="divMemberPromotion3" style="display:none">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="16%" align="right" bgcolor="#E9F1F8"  style="padding: 15px;">
                会员推广链接：
            </td>
            <td width="84%" bgcolor="#E9F1F8"  style="padding: 15px;">
                <asp:TextBox TextMode="MultiLine" ID="tbUrl" Columns="70" Rows="3" 
                    runat="server"  ReadOnly="True" /><br /><asp:Label ID ="lbShowInfo" runat="server" CssClass="red12"></asp:Label>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#E9F1F8" >
                    <tr>
                        <td  height="30"  align="left"   >
                            <asp:CheckBox ID="cbIsSend" runat="server" Text="给好友送红包：" onclick="isSend()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [<a href="javascript:;" onclick="HongBaoClick()">查看红包记录</a>]
                        </td>
                    </tr>
                    <tr id="trMoney" runat="server" style="display: none">
                        <td align="left">
                            <table  >
                                <tr>
                                    <td >
                                        <asp:RadioButtonList ID="rblMoney" runat="server" RepeatDirection="Horizontal" onclick="select()">
                                            <asp:ListItem Value="1" Selected="True">1元</asp:ListItem>
                                            <asp:ListItem Value="2">2元</asp:ListItem>
                                            <asp:ListItem Value="5">5元</asp:ListItem>
                                            <asp:ListItem Value="10">10元</asp:ListItem>
                                            <asp:ListItem Value="0">其它</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td >
                                        <div id = "divOther" style="display:none" runat="server">
                                            <asp:TextBox ID="tbMoney" runat="server" Width="40"  onkeypress="return InputMask_Number();" />元
                                        </div>
                                    </td>
                                    <td >
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;有效期：
                                        <asp:DropDownList ID="ddlDate" runat="server">
                                            <asp:ListItem Value="7">一个星期</asp:ListItem>
                                            <asp:ListItem Value="14">二个星期</asp:ListItem>
                                            <asp:ListItem Value="30">一个月</asp:ListItem>
                                            <asp:ListItem Value="60">二个月</asp:ListItem>
                                            <asp:ListItem Value="90">三个月</asp:ListItem>
                                        </asp:DropDownList>
                                        
                                    </td>
                                </tr>
                             </table>
                        </td>
                    </tr>
                    <tr id="trLink" runat="server" style="display: none">
                        <td align="left"  style="padding: 15px;" >
                            <asp:Button ID="btnOK" runat="server" Text="生成红包链接" OnClick="btnOK_Click" />
                            <asp:Label ID ="lbShowCreateResult" runat="server" CssClass="red12"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" bgcolor="#f7f7f7" style="padding: 15px;">
                <img src="../images/button_fuzhi.jpg" width="204" height="40" border="0" style="cursor: hand"
                    onclick="doufucopy('tbUrl')" />
            </td>
        </tr>
        
        <tr>
            <td colspan="4" align="left" bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                1、怎么样进行推广？
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px;
                text-indent: 20px;">
                复制“会员推广链接”给好友，然后好友通过链接地址注册会员后，就成为了“我的推广会员”，就可以获得他的购彩金额的1%作为佣金啦！
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                2、推广的方式有哪些？
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px;
                text-indent: 20px;">
                可以在论坛发贴、回贴的时候留下链接；可以给QQ好友发链接；可以给好友群发邮件等，只要他们收到推广链接后，不关闭浏览器的情况下，在任一页面完成注册都会算作“我的推广会员”。
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                3、推广100个购彩会员可以赚多少钱？
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px;
                text-indent: 20px;">
                推广了100个购彩会员后，按照每个会员每天购彩50元算，每个月可以赚1500元佣金，我们可以每个月不断的推荐会员，这些会员佣金结算是终身制的，我们推荐了1000个会员收入就会达到每月10000元以上啦！
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hidLink" runat="server" />
          </div>
          <div id="divMemberPromotion4" style="display:none">
                 <table  width="842" border="0" cellpadding="0" cellspacing="0"
            bgcolor="#DDDDDD" style="padding-left: 0px; padding-top: 0px; border-left: 1px solid #DDDDDD;
            border-right: 1px solid #DDDDDD;">
            <tr>
                <td height="30" colspan="10" align="left" bgcolor="#EEEEEE" style="padding: 5px 10px 5px 10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="black12" style="padding-left:50px">
                            请选择查询月份：<asp:DropDownList ID="ddlYear" runat="server" Width="88px">
                            </asp:DropDownList>
                                <asp:DropDownList ID="ddlMonth" runat="server" Width="50px">
                                <asp:ListItem Value="0">全部</asp:ListItem>
                                <asp:ListItem Value="1">1 月</asp:ListItem>
                                <asp:ListItem Value="2">2 月</asp:ListItem>
                                <asp:ListItem Value="3">3 月</asp:ListItem>
                                <asp:ListItem Value="4">4 月</asp:ListItem>
                                <asp:ListItem Value="5">5 月</asp:ListItem>
                                <asp:ListItem Value="6">6 月</asp:ListItem>
                                <asp:ListItem Value="7">7 月</asp:ListItem>
                                <asp:ListItem Value="8">8 月</asp:ListItem>
                                <asp:ListItem Value="9">9 月</asp:ListItem>
                                <asp:ListItem Value="10">10月</asp:ListItem>
                                <asp:ListItem Value="11">11月</asp:ListItem>
                                <asp:ListItem Value="12">12月</asp:ListItem>
                            </asp:DropDownList>
                                
                             <ShoveWebUI:ShoveConfirmButton ID="btnSearch1" runat="server" BackgroupImage="../images/button_sousuo.jpg"
                                Style="cursor: hand;" BorderStyle="None" Height="23px" Width="72px" 
                                onclick="btnSearch1_Click" />
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
                <asp:DataGrid ID="g1" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
            PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
             Font-Names="Tahoma" 
            CellSpacing="1" GridLines="None" onitemdatabound="g1_ItemDataBound">
            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
            <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                CssClass="blue12_2"></HeaderStyle>
            <AlternatingItemStyle BackColor="#F8F8F8" />
            <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                CssClass="black12" />
            <Columns>
                <asp:BoundColumn HeaderText="时间" DataField="DayDate" DataFormatString="{0:d}" >
                            <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
               <asp:BoundColumn HeaderText="今日会员交易量" DataField="DayTradeMoney" DataFormatString="{0:N2}">
                            <HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="佣金收入" DataField="DayBonusMoney" DataFormatString="{0:N2}">
                            <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
               <asp:TemplateColumn HeaderText="查看">
                            <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="red12_2"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lbDetail" runat="server" Text="[查看明细]" style="cursor:pointer"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
            </Columns>
            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
            </PagerStyle>
        </asp:DataGrid>
        <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 15px;">
            <tr>
                <ShoveWebUI:ShoveGridPager ID="gPager1" runat="server" Width="798" PageSize="30" ShowSelectColumn="False"
                    DataGrid="g1" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0" HotColor="MistyRose"
                    Visible="False" OnPageWillChange="gPager1_PageWillChange" OnSortBefore="gPager1_SortBefore"
                    RowCursorStyle="" AllowShorting="true" />
            </tr>
        </table>
          <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
            <tr>
                <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    <asp:Label ID="lbShow" runat="server" Text="本月"/>会员交易量总计：
                    <asp:Label ID="lbTradeSum" runat="server" Text ="0.00"  CssClass="red12"/>
                </td>
                 <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    佣金收入总计：
                    <asp:Label ID="lbBonusSum" runat="server" Text ="0.00"  CssClass="red12"/>
                </td>
            </tr>
            <tr>
                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;" colspan="2">
                    累计推广佣金： <asp:Label ID="lbTotalBonus" runat="server"  Text ="0.00" 
                                ForeColor="#CC0000"/> &nbsp;(元<span>)&nbsp; (包含推广的会员和商家) </span> 
                </td>
            </tr>
        </table>
          </div>
          <div id="divHongBao" style="display:none">
            <iframe id="contentFrame" frameborder="no" width="100%" onload="this.height=this.Document.body.scrollHeight;" name="contentFrame" 
                                                border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
                                            </iframe>
          </div>
          <div id="divUserAccountDetail" style="display:none">
            <iframe id="UserAccountDetailIframe" frameborder="no" width="100%" onload="this.height=this.Document.body.scrollHeight;" name="UserAccountDetailIframe" 
                                                border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
                                            </iframe>
        </div>
        <div id="divUserPromotionDetail" style="display:none">
            <iframe id="UserPromotionDetailIframe" frameborder="no" width="100%" onload="this.height=this.Document.body.scrollHeight;" name="UserPromotionDetailIframe" 
                                                border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
                                            </iframe>
        </div>
        <div id="divMemberPromotion5" style="display:none">
            <iframe id="DistillListIframe" frameborder="no" width="100%" onload="this.height=this.Document.body.scrollHeight;"  
                                                border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
                                            </iframe>
                                            </div>
                                              <div id="divMemberPromotion6" style="display:none">
            <iframe id="AppDistillIframe" frameborder="no" width="100%" onload="this.height=this.Document.body.scrollHeight;"  
                                                border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
                                            </iframe>
                                            </div>     
        </div>
   <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
   <asp:HiddenField ID="HidType" runat="server"  Value="tdMemberPromotion1"/>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function doufucopy(text) {
        text = document.getElementById(text);
        textRange = text.createTextRange();
        textRange.execCommand("Copy");
        alert("已复制到剪粘板上");

        return false;
    }
    
    function mOver(obj, type) {
        if (type == 1) {
            obj.style.textDecoration = "underline";
            obj.style.color = "#FF0065";
        }
        else {
            obj.style.textDecoration = "none";
            obj.style.color = "#226699";
        }
    }

    var lastid = document.getElementById("tdMemberPromotion1");
    function ClickMenu(obj) {
            lastid.background = "../images/admin_qh_100_2.jpg";
            lastid.style.fontWeight = "normal";
            document.getElementById(lastid.id.replace("td","div")).style.display = "none";

        obj.background = "../images/admin_qh_100_1.jpg";
        obj.style.fontWeight = "bold";
        document.getElementById(obj.id.replace("td", "div")).style.display = "";
        
        lastid = obj;

        document.getElementById("HidType").value = obj.id;
        document.getElementById("divHongBao").style.display = "none";
        document.getElementById("divUserAccountDetail").style.display = "none";
        document.getElementById("divUserPromotionDetail").style.display = "none";

        if (obj.id == "tdMemberPromotion5") {
            DistillListIframe.location.href = "UserDistillList.aspx";
        }

        if (obj.id == "tdMemberPromotion6") {
            AppDistillIframe.location.href = "UserAppDistill.aspx";
        }
    }
    ClickMenu(document.getElementById(document.getElementById("HidType").value));

    function select() {
        var rb = document.getElementById("rblMoney_4");

        if (rb.checked) {
            document.getElementById("divOther").style.display = "";
        } else {
            document.getElementById("divOther").style.display = "none";
        }
    }

    function isSend() {
        var cb = document.getElementById("cbIsSend");
        if (cb.checked) {
            document.getElementById("trMoney").style.display = "";
            document.getElementById("trLink").style.display = "";
            if (document.getElementById("tbUrl").value == document.getElementById("hidLink").value) {
                document.getElementById("lbShowInfo").innerHTML = "";           //普通链接不显示多少钱
                document.getElementById("lbShowCreateResult").innerHTML = "";   //生成红包链接结果
            }

            //"其它"选项时,钱数输入框的显示和隐藏
            var rb = document.getElementById("rblMoney_4");
            if (rb.checked) {
                document.getElementById("divOther").style.display = "";
            }
            else {
                document.getElementById("divOther").style.display = "none";
            }
        }
        else {
            document.getElementById("trMoney").style.display = "none";
            document.getElementById("trLink").style.display = "none";
            document.getElementById("lbShowInfo").innerHTML = "";
            document.getElementById("lbShowCreateResult").innerHTML = "";

            document.getElementById("tbUrl").value = document.getElementById("hidLink").value; //恢复为普通链接
        }
    }

    function InputMask_Number() {
        if (window.event.keyCode < 48 || window.event.keyCode > 57)
            return false;
        return true;
    }

    function HongBaoClick() {
        document.getElementById("divHongBao").style.display = "";
        document.getElementById("divMemberPromotion3").style.display = "none";
        document.getElementById("contentFrame").src = "HongBaoRecord.aspx";
    }

    function GetUserAccountDetail(id) {
        document.getElementById("divUserAccountDetail").style.display = "";
        document.getElementById("divMemberPromotion2").style.display = "none";
        document.getElementById("UserAccountDetailIframe").src = "UserAccountDetail.aspx?id=" + id;

        return false;
    }

    function GetUserPromotionDetail(time) {
        document.getElementById("divUserPromotionDetail").style.display = "";
        document.getElementById("divMemberPromotion4").style.display = "none";
        document.getElementById("UserPromotionDetailIframe").src = "UserPromotionDetail.aspx?dt=" + time;
        
        return false;
    }

    function GetUserPromotionDetailByYear(month) {
        var ddl = document.getElementById("ddlMonth");
        ddl.value = month;

        __doPostBack("btnSearch1","");
        return false;
    }
    </script>