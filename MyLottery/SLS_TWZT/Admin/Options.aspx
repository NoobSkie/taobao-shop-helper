<%@ page language="C#" autoeventwireup="true" CodeFile="Options.aspx.cs" inherits="Admin_Options" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" Style="z-index: 104; left: 32px; position: absolute; top: 30px"
            runat="server" ForeColor="#C00000" Font-Bold="True">系统参数设置</asp:Label>
        <asp:TextBox ID="tbForumUrl" runat="server" Style="z-index: 134; left: 216px; position: absolute;
            top: 73px" Width="304px" MaxLength="50"></asp:TextBox>
        <asp:TextBox ID="tbInitiateSchemeBonusScale" runat="server" Style="z-index: 134;
            left: 215px; position: absolute; top: 354px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:Label ID="Label17" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 354px">方案制作佣金(盈利时)</asp:Label>
        <asp:TextBox ID="tbInitiateSchemeMinBuyScale" runat="server" Style="z-index: 134;
            left: 215px; position: absolute; top: 378px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:Label ID="Label46" runat="server" Style="z-index: 129; left: 308px; position: absolute;
            top: 378px">第二种方式：</asp:Label>
        <asp:Label ID="Label47" runat="server" Style="z-index: 129; left: 390px; position: absolute;
            top: 378px">底值金额：</asp:Label>
        <asp:Label ID="Label48" runat="server" Style="z-index: 129; left: 538px; position: absolute;
            top: 378px">底值比例：</asp:Label>
        <asp:Label ID="Label49" runat="server" Style="z-index: 129; left: 697px; position: absolute;
            top: 378px; right: 450px;">顶值金额：</asp:Label>
        <asp:TextBox ID="tbInitiateSchemeLimitLowerScaleMoney" runat="server" Style="z-index: 134;
            left: 447px; position: absolute; top: 378px; right: 685px; width: 75px;" MaxLength="10"></asp:TextBox>
        <asp:TextBox ID="tbInitiateSchemeLimitLowerScale" runat="server" Style="z-index: 134;
            left: 603px; position: absolute; top: 378px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:TextBox ID="tbInitiateSchemeLimitUpperScaleMoney" runat="server" Style="z-index: 134;
            left: 762px; position: absolute; top: 378px; right: 371px;" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:TextBox ID="tbInitiateSchemeLimitUpperScale" runat="server" Style="z-index: 134;
            left: 920px; position: absolute; top: 378px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:TextBox ID="tbInitiateSchemeMinBuyAndAssureScale" runat="server" Style="z-index: 134;
            left: 215px; position: absolute; top: 403px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:Label ID="Label19" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 403px">发起人最少认购(含保底)</asp:Label>
        <asp:TextBox ID="tbInitiateSchemeMaxNum" runat="server" Style="z-index: 134; left: 215px;
            position: absolute; top: 427px" Width="74px" MaxLength="5"></asp:TextBox>
        <asp:TextBox ID="tbSchemeMinMoney" runat="server" Style="z-index: 134; left: 215px;
            position: absolute; top: 501px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 501px">方案最小金额</asp:Label>
        <asp:TextBox ID="tbSchemeMaxMoney" runat="server" Style="z-index: 134; left: 215px;
            position: absolute; top: 525px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 525px">方案最大金额</asp:Label>
        <asp:Label ID="Label32" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 427px">每人每期最多发起方案</asp:Label>
        <asp:Label ID="Label18" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 378px">发起人最少认购</asp:Label>
        <asp:TextBox ID="tbMobileCheckStringLength" runat="server" Style="z-index: 134; left: 216px;
            position: absolute; top: 135px" Width="74px" MaxLength="2"></asp:TextBox>
        <asp:TextBox ID="tbSMSPrice" runat="server" Style="z-index: 134; left: 216px; position: absolute;
            top: 182px" Width="74px" MaxLength="5"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Style="z-index: 129; left: 72px; position: absolute;
            top: 182px">价格</asp:Label>
        <asp:Label ID="Label15" runat="server" Style="z-index: 129; left: 303px; position: absolute;
            top: 182px">元/条</asp:Label>
        <asp:Label ID="Label7" runat="server" Style="z-index: 125; left: 71px; position: absolute;
            top: 159px">短信费</asp:Label>
        <asp:DropDownList ID="ddlSMSPayType" Style="z-index: 124; left: 216px; position: absolute;
            top: 159px" runat="server" Width="168px">
            <asp:ListItem Value="1">网站支付</asp:ListItem>
            <asp:ListItem Value="2">会员支付</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label4" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 135px">长度</asp:Label>
        <asp:Label ID="Label2" runat="server" Style="z-index: 129; left: 72px; position: absolute;
            top: 73px">外部论坛 Url</asp:Label>
        <asp:Label ID="Label13" runat="server" ForeColor="Red" Style="z-index: 129; left: 442px;
            position: absolute; top: 17px">(系统重要参数，请谨慎设置)</asp:Label>
        <asp:TextBox ID="tbFirstPageUnionBuyMaxRows" runat="server" Style="z-index: 134;
            left: 215px; position: absolute; top: 574px" Width="74px" MaxLength="5"></asp:TextBox>
        <asp:TextBox ID="tbLotteryCountOfMenuBarRow" runat="server" Style="z-index: 134;
            left: 215px; position: absolute; top: 624px" Width="74px" MaxLength="5"></asp:TextBox>
        <asp:Label ID="Label26" runat="server" Style="z-index: 129; left: 70px; position: absolute;
            top: 624px">主导航条每行彩种个数</asp:Label>
        <asp:TextBox ID="tbScoringOfSelfBuy" runat="server" Style="z-index: 134; left: 215px;
            position: absolute; top: 730px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:Label ID="Label35" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 730px">会员购彩积分默认值</asp:Label>
        <asp:Label ID="Label37" runat="server" Style="z-index: 129; left: 303px; position: absolute;
            top: 731px">分/元</asp:Label>
        <asp:Label ID="Label38" runat="server" Style="z-index: 129; left: 303px; position: absolute;
            top: 756px">分/元</asp:Label>
        <asp:Label ID="Label41" runat="server" Style="z-index: 129; left: 303px; position: absolute;
            top: 781px">元/分</asp:Label>
        <asp:TextBox ID="tbScoringExchangeRate" runat="server" Style="z-index: 118; left: 215px;
            position: absolute; top: 780px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:TextBox ID="tbSchemeChatRoom_MaxChatNumberOf" runat="server" Style="z-index: 118;
            left: 215px; position: absolute; top: 892px" Width="74px" MaxLength="5"></asp:TextBox>
        <asp:Label ID="Label27" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 892px">方案最大聊天人数</asp:Label>
        <asp:TextBox ID="tbSchemeChatRoom_StopChatDaysAfterOpened" runat="server" Style="z-index: 118;
            left: 215px; position: absolute; top: 867px" Width="74px" MaxLength="5"></asp:TextBox>
        <asp:Label ID="Label42" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 780px">积分兑换比率</asp:Label>
        <asp:TextBox ID="tbScoringOfCommendBuy" runat="server" Style="z-index: 118; left: 215px;
            position: absolute; top: 755px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:Label ID="Label36" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 755px">下级购彩积分默认值</asp:Label>
        <asp:CheckBox ID="cbScoring_Status_ON" runat="server" Style="z-index: 115; left: 212px;
            position: absolute; top: 803px" Text="是否启用积分功能？" />
        <asp:TextBox ID="tbPromotionMemberBonusScale" runat="server" Style="z-index: 118; left: 215px;
            position: absolute; top: 920px" Width="74px" MaxLength="10"></asp:TextBox>
             <asp:TextBox ID="tbPromotionSiteBonusScale" runat="server" Style="z-index: 118; left: 215px;
            position: absolute; top: 940px" Width="74px" MaxLength="10"></asp:TextBox>
            <asp:TextBox ID="tbCpsBonusScale" runat="server" Style="z-index: 118; left: 215px;
            position: absolute; top: 960px" Width="74px" MaxLength="10"></asp:TextBox>
        <asp:TextBox ID="tbBettingStationName" runat="server" Style="z-index: 118; left: 215px;
            position: absolute; top: 1255px" Width="304px" MaxLength="50"></asp:TextBox>
        <asp:TextBox ID="tbBettingStationNumber" runat="server" MaxLength="20" Style="z-index: 118;
            left: 215px; position: absolute; top: 1280px" Width="304px"></asp:TextBox>
        <asp:TextBox ID="tbBettingStationTelephone" runat="server" MaxLength="20" Style="z-index: 118;
            left: 215px; position: absolute; top: 1330px" Width="304px"></asp:TextBox>
        <asp:TextBox ID="tbBettingStationContactPreson" runat="server" MaxLength="20" Style="z-index: 118;
            left: 215px; position: absolute; top: 1355px" Width="304px"></asp:TextBox>
        <asp:Label ID="Label28" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 1355px">投注站联系人</asp:Label>
        <asp:Label ID="Label31" runat="server" Style="z-index: 117; left: 377px; position: absolute;
            top: 1428px"> </asp:Label>
        <asp:Label ID="Label33" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 1330px">投注站电话</asp:Label>
        <asp:TextBox ID="tbBettingStationAddress" runat="server" MaxLength="50" Style="z-index: 118;
            left: 215px; position: absolute; top: 1305px" Width="304px"></asp:TextBox>
        <asp:Label ID="Label24" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 1305px">投注站地址</asp:Label>
        <asp:Label ID="Label23" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 1280px">投注站编号</asp:Label>
        <asp:Label ID="Label20" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 1255px">投注站名称</asp:Label>
       <asp:Label ID="Label44" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 920px">推广会员佣金比例</asp:Label>
            <asp:Label ID="Label51" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 940px">推广站长佣金比例</asp:Label>
            <asp:Label ID="Label52" runat="server" Style="z-index: 117; left: 70px; position: absolute;
            top: 960px">联盟推广佣金比例默认值</asp:Label>
            <asp:CheckBox ID="cbPromotion_Status_ON" runat="server" Style="z-index: 115; left: 310px;
            position: absolute; top: 936px" Text="是否启用推荐功能？" />
        <asp:CheckBox ID="cbCps_Status_ON" runat="server" Style="z-index: 115; left: 212px;
            position: absolute; top: 983px" Text="是否启用联盟推广功能？" />
        <asp:Label ID="Label12" runat="server" Style="z-index: 129; left: 70px; position: absolute;
            top: 674px">投注密码</asp:Label>
        <asp:Label ID="Label25" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 574px">首页合买区方案行数</asp:Label>
        <asp:TextBox ID="tbPageTitle" runat="server" Style="z-index: 134; left: 213px; position: absolute;
            top: 1014px" Width="466px" MaxLength="500"></asp:TextBox>
        <asp:TextBox ID="tbPageKeywords" runat="server" Height="76px" Style="z-index: 134;
            left: 213px; position: absolute; top: 1036px" TextMode="MultiLine" Width="465px"
            MaxLength="500"></asp:TextBox>
        <asp:Label ID="Label21" runat="server" Style="z-index: 129; left: 70px; position: absolute;
            top: 1036px">页面 Keyword</asp:Label>
        <asp:Label ID="Label43" runat="server" Style="z-index: 129; left: 70px; position: absolute;
            top: 1153px">页面对联广告</asp:Label>
        <asp:Label ID="Label45" runat="server" Style="z-index: 129; left: 70px; position: absolute;
            top: 1199px">支付宝会员共享</asp:Label>
        <asp:Label ID="Label22" runat="server" Style="z-index: 129; left: 70px; position: absolute;
            top: 1014px">页面 Title</asp:Label>
        <asp:Label ID="Label14" runat="server" Style="z-index: 125; left: 71px; position: absolute;
            top: 229px">验证码字符集</asp:Label>
        <asp:Label ID="Label16" Style="z-index: 125; left: 71px; position: absolute; top: 305px"
            runat="server">登录日志</asp:Label>
        <asp:CheckBox ID="cbisUseCheckCode" Style="z-index: 123; left: 213px; position: absolute;
            top: 253px" runat="server" Text="登录是否需要验证码？"></asp:CheckBox>
        <asp:CheckBox ID="cbisShowFloatAD" Style="z-index: 123; left: 212px; position: absolute;
            top: 1153px" runat="server" Text="是否显示页面浮动对联广告？"></asp:CheckBox>
        <asp:CheckBox ID="cbMemberSharing_Alipay_Status_ON" Style="z-index: 123; left: 212px;
            position: absolute; top: 1198px" runat="server" Text="是否启用支付宝会员共享功能？"></asp:CheckBox>
        <asp:Label ID="Label11" runat="server" Style="z-index: 119; left: 304px; position: absolute;
            top: 599px">行，将不显示彩票号码，而改用“下载方案”</asp:Label>
        <asp:Label ID="Label30" Style="z-index: 119; left: 309px; position: absolute; top: 866px"
            runat="server" ForeColor="Red">-1 表示永不关闭</asp:Label>
        <asp:TextBox ID="tbMaxShowLotteryNumberRows" Style="z-index: 118; left: 215px; position: absolute;
            top: 599px" runat="server" Width="74px" MaxLength="5"></asp:TextBox>
        <asp:Label ID="Label10" Style="z-index: 117; left: 70px; position: absolute; top: 599px"
            runat="server">方案表格中彩票号超过</asp:Label>
        <asp:CheckBox ID="cbisBuyValidPasswordAdv" Style="z-index: 116; left: 215px; position: absolute;
            top: 674px" runat="server" Text="发起方案、参与合买、发起追号等是否需要验证投注密码？"></asp:CheckBox>
        <asp:CheckBox ID="cbisFirstPageUnionBuyWithAll" runat="server" Style="z-index: 115;
            left: 304px; position: absolute; top: 573px" Text="首页合买区是否包含满员方案？" />
        <asp:CheckBox ID="cbisWriteLog" Style="z-index: 103; left: 213px; position: absolute;
            top: 304px" runat="server" Text="是否记录用户登录日志？"></asp:CheckBox>
        <asp:CheckBox ID="cbFullSchemeCanQuash" Style="z-index: 100; left: 306px; position: absolute;
            top: 475px" runat="server" Text="满员方案是否允许用户撤单？" Enabled="False"></asp:CheckBox>
        <ShoveWebUI:ShoveConfirmButton ID="btnOK" Style="z-index: 101; left: 374px; position: absolute;
            top: 1405px" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px"
            Height="20px" Text="保存" AlertText="确认书写无误吗？" OnClick="btnOK_Click" />
        <asp:Label ID="Label9" Style="z-index: 114; left: 373px; position: absolute; top: 305px"
            runat="server" ForeColor="Red">提示：不记录日志，将不能分析与监控用户登录情况</asp:Label>
        <asp:DropDownList ID="ddlCheckCodeCharset" Style="z-index: 124; left: 215px; position: absolute;
            top: 229px" runat="server" Width="168px">
            <asp:ListItem Value="0">大小写字母和数字混合</asp:ListItem>
            <asp:ListItem Value="1">大小写字母</asp:ListItem>
            <asp:ListItem Value="2">小写字母</asp:ListItem>
            <asp:ListItem Value="3">大写字母</asp:ListItem>
            <asp:ListItem Value="4">数字</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Style="z-index: 125; left: 71px; position: absolute;
            top: 112px">手机验证字符集</asp:Label>
        <asp:DropDownList ID="ddlMobileCheckCharset" Style="z-index: 124; left: 216px; position: absolute;
            top: 112px" runat="server" Width="168px">
            <asp:ListItem Value="1">数字</asp:ListItem>
            <asp:ListItem Value="2">大写字母</asp:ListItem>
            <asp:ListItem Value="3">小写字母</asp:ListItem>
            <asp:ListItem Value="4">混合</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="tbInitiateFollowSchemeMaxNum" runat="server" Style="z-index: 134;
            left: 215px; position: absolute; top: 452px" Width="74px" MaxLength="5"></asp:TextBox>
        <asp:Label ID="Label39" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 452px">超级发起人最多发起方案</asp:Label>
        <asp:TextBox ID="tbQuashSchemeMaxNum" runat="server" Style="z-index: 134; left: 215px;
            position: absolute; top: 476px" Width="74px" MaxLength="5"></asp:TextBox>
        <asp:Label ID="Label40" runat="server" Style="z-index: 129; left: 71px; position: absolute;
            top: 476px">每期最大撤单次数</asp:Label>
        <asp:Label ID="Label34" runat="server" ForeColor="Red" Style="z-index: 129; left: 308px;
            position: absolute; top: 353px">( 0-1 ) 例如0.03</asp:Label>
        <asp:Label ID="Label50" runat="server" Style="z-index: 129; left: 856px; position: absolute;
            top: 378px">顶值比例：</asp:Label>
    </div>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label29" runat="server" Style="z-index: 117; left: 66px; position: absolute;
            top: 869px; height: 16px;">开奖几天后方案聊天关闭</asp:Label>
        </p>
    </form>
    </body>
</html>
