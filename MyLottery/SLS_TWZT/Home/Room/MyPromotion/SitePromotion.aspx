<%@ page language="C#" autoeventwireup="true" CodeFile="SitePromotion.aspx.cs" inherits="Home_Room_MyPromotion_SitePromotion" enableEventValidation="false" %>
    <%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="../UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>站长推广-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="keywords" content="站长推广" />
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <link href="../Style/css.css" rel="stylesheet" type="text/css" />
</head><link rel="shortcut icon" href="../../../favicon.ico"/>
<body>
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
                <td width="100" align="center" background="../images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;" id="tdSitePromotion1" onclick="ClickMenu(this)">
                    我的商家圈
                </td>
               
                <td width="6">
                    &nbsp;
                </td>
                <td width="100" align="center" background="../images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;"  id="tdSitePromotion2" onclick="ClickMenu(this)">
                    我推广的商家
                </td>
                <td width="6">
                    &nbsp;
                </td>
                <td width="100" align="center" background="../images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;" id="tdSitePromotion3" onclick="ClickMenu(this)">
                    我要推广
                </td>
                <td width="6">
                    &nbsp;
                </td>
                <td width="100" align="center" background="../images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;" id="tdSitePromotion4" onclick="ClickMenu(this)">
                    我的拥金
                </td>
               
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="1" colspan="15" bgcolor="#FFFFFF">
                </td>
            </tr>
            <tr>
                <td height="2" colspan="15" bgcolor="#6699CC">
                </td>
            </tr>
        </table>
          <div id="divSitePromotion1">
                <table width="100%" border="0" cellspacing="1" cellpadding="0">
        <tr>
            <td align="center" bgcolor="#FFFFFF" class="black12" style="padding: 10px 0px 10px 0px;">
                <img src="../images/ad_tuiguang_2.jpg" width="740" height="80" />
            </td>
        </tr>
        <tr>
            <td bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                1、什么是“商家圈”？
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px; text-indent: 20px;">
                推荐有一定用户流量的网站，成为<%=_Site.Name %>的广告商家，那么通过这个网站广告注册的所有的会员的交易量你都可以获得0.5%的佣金。
            </td>
        </tr>
        <tr>
            <td bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                2、如何通过“商家圈”赚钱？<br />
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px; text-indent: 20px;">
                把自己的“站长商家推广链接”发给身边有网站的好友，让他们注册成为“站长商家”，在网站上给<%=_Site.Name %>做广告，所以通过广告注册的会员的交易量，都可以获得0.5%的佣金。<br />
                <span class="red12">注意：每一个商家也算你推广的一个消费会员！</span><br />
            </td>
        </tr>
        <tr>
            <td bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                3、“商家圈”赚到的佣金如何提现？
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px; text-indent: 20px;">
                商家圈的推广佣金随时进行结算。点击“提款申请”就可以了，<%=_Site.Name %>平台就会在规定的时间内把钱结算到你的支付宝帐户。
            </td>
        </tr>
        <tr>
        <td align="center" bgcolor="#f7f7f7" style="padding: 15px;">
                <img src="../images/button_tuiguang.jpg" width="204" height="40" border="0" style="cursor:pointer" onclick="tdSitePromotion3.click();" />
        </td>
        </tr>
    </table>
          </div> 
          <div id="divSitePromotion2" style="display:none">
              <table  width="842" border="0" cellpadding="0" cellspacing="0"
            bgcolor="#DDDDDD" style="padding-left: 0px; padding-top: 0px; border-left: 1px solid #DDDDDD;
            border-right: 1px solid #DDDDDD;">
            <tr>
                <td height="30" colspan="10" align="left" bgcolor="#EEEEEE" style="padding: 5px 10px 5px 10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="black12" style="padding-left:50px">
                                 <asp:TextBox ID="tbUserName" runat="server" Text="请输入商家用户名" CssClass="in_text" size="30"
                                onfocus="if(this.value=='请输入商家用户名') this.value='';" onblur="if(this.value=='') this.value='请输入商家用户名'"></asp:TextBox>
                                
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
                <asp:BoundColumn HeaderText="商家用户名" DataField="UserName">
                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="商家名称" DataField="CpsName">
                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="会员类型">
                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Type").ToString()=="3"?"联盟商家":"站长商家"%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="商家状态">
                            <HeaderStyle HorizontalAlign="Center" Width="6%"></HeaderStyle>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "On").ToString() == "True" ? "开通" : "未开通"%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateColumn>
                <asp:BoundColumn HeaderText="今日交易量" DataField="TodayTradeMoney" DataFormatString ="{0:N2}">
                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="昨日交易量" DataField="YesterdayTradeMoney" DataFormatString ="{0:N2}">
                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                 <asp:BoundColumn HeaderText="本月交易量" DataField="ThisMonthTradeMoney" DataFormatString ="{0:N2}">
                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                 <asp:BoundColumn HeaderText="累计交易量" DataField="TotalTradeMoney" DataFormatString ="{0:N2}">
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
                        <asp:BoundColumn HeaderText="CpsID" DataField="CpsID" Visible ="false" />
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
                    <asp:Label ID="lbAllTodaySales" runat="server" Text ="0.00"  CssClass="red12"/>
                </td>
                 <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    昨日消费总计：
                    <asp:Label ID="lbAllYesterdaySales" runat="server" Text ="0.00"  CssClass="red12"/>
                </td>
            </tr>
            <tr>
                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    本月消费总计：
                    <asp:Label ID="lbAllMonthSales" runat="server" Text="0.00" CssClass="red12" />
                </td>
                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    总消费总计：
                    <asp:Label ID="lbAllTotalSales" runat="server" Text="0.00" CssClass="red12" />
                </td>
            </tr>
        </table>
          </div> 
          <div id="divSitePromotion3" style="display:none">
              <table width="100%" border="0" cellspacing="1" cellpadding="0">
        <tr>
            <td width="16%" align="right" bgcolor="#E9F1F8" class="black12" style="padding: 15px;">
                站长商家推广链接：
            </td>
            <td width="84%" bgcolor="#E9F1F8" class="black12" style="padding: 15px;">
                <asp:TextBox TextMode="MultiLine" ID="tbUrl" Columns="70" Rows="3" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" bgcolor="#f7f7f7" style="padding: 15px;">
                <img src="../images/button_fuzhi.jpg" width="204" height="40" border="0" style="cursor: hand"
                    onclick="doufucopy('tbUrl')" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                1、怎样进行站长商家推广？
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px;
                text-indent: 20px;">
                复制“站长推广链接”给好友，然后站长通过链接地址注册成广告商家后，就成为了“我推广的商家”，就可以获得他的网站广告用户交易量的0.5%作为佣金啦！<br />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                2、推广方式有哪些？
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px;
                text-indent: 20px;">
                可以在论坛发贴、回贴的时候留下链接；可以给QQ站长好友发链接；可以给站长群发邮件等，只要他们收到推广链接后，不关闭浏览器的情况下，在任一页面完成注册都会算作“我推广的商家”。
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" bgcolor="#E9F1F8" class="blue14" style="padding: 5px 10px 5px 10px;">
                3、推广10个站长商家可以赚多少钱？
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding: 5px 10px 5px 10px;
                text-indent: 20px;">
                推广了10个站长商家后，按照每个站长商家的广告每天注册5个会员,那每个月一个站长就产生150个会员，10个站长就是1500个会员，会员每天购彩50元算，每天可以赚375元佣金，一个月就可以赚到11250元啦！
                <br />
            </td>
        </tr>
    </table>
          </div>
          <div id="divSitePromotion4" style="display:none">
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
             Font-Names="Tahoma" onitemdatabound="g1_ItemDataBound"
            CellSpacing="1" GridLines="None">
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
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundColumn>
              <asp:TemplateColumn HeaderText="查看">
                            <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                    <asp:Label ID="lbShow" runat="server" Text="本月"></asp:Label>会员交易量总计：
                    <asp:Label ID="lbTradeSum" runat="server" Text ="0.00"  CssClass="red12"/>
                </td>
                 <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    佣金收入总计：
                    <asp:Label ID="lbBonusSum" runat="server" Text ="0.00"  CssClass="red12"/>
                </td>
            </tr>
        </table>
          </div>
         
          <div id="divSiteBuyDetail" style="display:none">
            <iframe id="SiteBuyDetailIframe" frameborder="no" width="100%" onload="this.height=this.Document.body.scrollHeight;" name="SiteBuyDetailIframe" 
                                                border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
                                            </iframe>
        </div>
        <div id="divSitePromotionDetail" style="display:none">
            <iframe id="SitePromotionDetailIframe" frameborder="no" width="100%" onload="this.height=this.Document.body.scrollHeight;" name="SitePromotionDetailIframe" 
                                                border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
                                            </iframe>
                                            </div>
           <div id="divSitePromotion5" style="display:none">
            <iframe id="DistillListIframe" frameborder="no" width="100%" onload="this.height=this.Document.body.scrollHeight;"  
                                                border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
                                            </iframe>
                                            </div>
                                              <div id="divSitePromotion6" style="display:none">
            <iframe id="AppDistillIframe" frameborder="no" width="100%" onload="this.height=this.Document.body.scrollHeight;"  
                                                border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes">
                                            </iframe>
                                            </div>                                   
        </div>
        </div>
   <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
   <asp:HiddenField ID="HidType" runat="server"  Value="tdSitePromotion1"/>
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

    var lastid = document.getElementById("tdSitePromotion1");
    function ClickMenu(obj) {
            lastid.background = "../images/admin_qh_100_2.jpg";
            lastid.style.fontWeight = "normal";
            document.getElementById(lastid.id.replace("td","div")).style.display = "none";

        obj.background = "../images/admin_qh_100_1.jpg";
        obj.style.fontWeight = "bold";
        document.getElementById(obj.id.replace("td", "div")).style.display = "";
        
        lastid = obj;

        document.getElementById("HidType").value = obj.id;
        
        document.getElementById("divSiteBuyDetail").style.display = "none";
        document.getElementById("divSitePromotionDetail").style.display = "none";

        if (obj.id == "tdSitePromotion5") {
            DistillListIframe.location.href = "UserDistillList.aspx";
        }

        if (obj.id == "tdSitePromotion6") {
            AppDistillIframe.location.href = "UserAppDistill.aspx";
        }
    }
    ClickMenu(document.getElementById(document.getElementById("HidType").value));

    function GetSiteBuyDetail(id) {
        document.getElementById("divSiteBuyDetail").style.display = "";
        document.getElementById("divSitePromotion2").style.display = "none";
        document.getElementById("SiteBuyDetailIframe").src = "PromoteSiteBuyDetail.aspx?CpsID=" + id;

        return false;
    }

    function GetSitePromotionDetail(time) {
        document.getElementById("divSitePromotionDetail").style.display = "";
        document.getElementById("divSitePromotion4").style.display = "none";
        document.getElementById("SitePromotionDetailIframe").src = "SitePromotionDetail.aspx?dt=" + time;

        return false;
    }

    function GetSitePromotionDetailByYear(month) {
        var ddl = document.getElementById("ddlMonth");
        ddl.value = month;

        __doPostBack("btnSearch1", "");
        return false;
    }
    </script>

