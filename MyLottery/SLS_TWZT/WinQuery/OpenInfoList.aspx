<%@ page language="C#" autoeventwireup="true" CodeFile="~/WinQuery/OpenInfoList.aspx.cs" inherits="WinQuery_OpenInfoList" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=LotteryName %>第<%=IsusesName%>期开奖查询—<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %>！
    </title>
    <meta name="keywords" content="双色球第<%=IsusesName%>期开奖查询、双色球第<%=IsusesName%>期开奖结果、福彩开奖查询" />
    <meta name="description" content="<%=_Site.Name %>提供福彩双色球第<%=IsusesName%>期开奖号码及开奖公告详情信息。" />
    <link href="../Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .hei12
        {
            font-size: 12px;
            color: #333333;
            font-family: "tahoma";
            line-height: 20px;
        }
        .hei12 A:link
        {
            font-family: "tahoma";
            color: #333333;
            text-decoration: none;
        }
        .hei12 A:active
        {
            font-family: "tahoma";
            color: #333333;
            text-decoration: none;
        }
        .hei12 A:visited
        {
            font-family: "tahoma";
            color: #333333;
            text-decoration: none;
        }
        .hei12 A:hover
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .bg_shang
        {
            font-size: 12px;
            color: #333333;
            font-family: "tahoma";
            line-height: 20px;
            background-image: url(../Home/Room/Images/right_bg_line.jpg);
            background-repeat: repeat-x;
            background-position: center top;
        }
        /*布局样式*/#box
        {
            overflow: hidden;
            width: 1002px;
            margin-right: auto;
            margin-left: auto;
            padding: 0px;
        }
        #head
        {
            width: 980px;
            padding: 0px;
            overflow: hidden;
        }
        .content
        {
            width: 1002px;
            padding: 0px;
            overflow: hidden;
            margin-top: 10px;
        }
        .content1_l
        {
            float: left;
            width: 200px;
            padding: 0px;
            overflow: hidden;
        }
        .content1_770
        {
            float: left;
            width: 790px;
            padding: 0px 0px 0px 10px;
            overflow: hidden;
        }
        .red0
        {
            color: Red;
        }
    </style>
    <link rel="shortcut icon" href="../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="HidLotteryID" runat="server" />
    <asp:HiddenField ID="HidIsuseID" runat="server" />
    <asp:HiddenField ID="HidPlayType" runat="server" />
    <asp:HiddenField ID="HidSearch" runat="server" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <div id="box">
        <div class="content">
            <div class="content1_l" style="padding-left: 0px; margin-left: 0px;">
                <table width="200" border="0" cellspacing="0" cellpadding="0" background="../Home/Room/Images/left_bg.jpg">
                    <tr>
                        <td>
                            <img src="../Home/Room/Images/left_title_200_1.jpg" width="200" height="25" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 3px 0px 3px 0px;">
                            <table width="170" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span5" class="hei12"><a href="5-0-0.aspx" onclick="ChangeSelect(5)">双色球</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span6" class="hei12"><a href="6-0-0.aspx" onclick="ChangeSelect(6)">福彩3D</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span29" class="hei12"><a href="29-0-0.aspx" onclick="ChangeSelect(29)">时时乐(高频)</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span61" class="hei12"><a href="61-0-0.aspx" onclick="ChangeSelect(61)">时时彩(高频)</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span13" class="hei12"><a href="13-0-0.aspx" onclick="ChangeSelect(13)">七乐彩</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span59" class="hei12"><a href="59-0-0.aspx" onclick="ChangeSelect(59)">15选5</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span58" class="hei12"><a href="58-0-0.aspx" onclick="ChangeSelect(58)">东方6+1</a></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="../Home/Room/Images/left_title_200_2.jpg" width="200" height="25" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 3px 0px 3px 0px;">
                            <table width="170" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span1" class="hei12"><a href="1-0-0.aspx" onclick="ChangeSelect(1)">胜负彩(任九)</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span2" class="hei12"><a href="2-0-0.aspx" onclick="ChangeSelect(2)">四场进球</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian_2.gif" style="padding-left: 22px;">
                                        <span id="span15" class="hei12"><a href="15-0-0.aspx" onclick="ChangeSelect(15)">六场半全场</a></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="../Home/Room/Images/left_title_200_3.jpg" width="200" height="25" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 3px 0px 0px 0px;">
                            <table width="170" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span70" class="hei12"><a href="70-0-0.aspx" onclick="ChangeSelect(70)">11选5(高频)</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span62" class="hei12"><a href="62-0-0.aspx" onclick="ChangeSelect(62)">十一运夺金(高频)</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="td39" height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span39" class="hei12"><a href="39-0-0.aspx" onclick="ChangeSelect(39)">超级大乐透</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="td63" height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span63" class="hei12"><a href="63-0-0.aspx" onclick="ChangeSelect(63)">排列3</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="td64" height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span64" class="hei12"><a href="64-0-0.aspx" onclick="ChangeSelect(64)">排列5</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="td3" height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span3" class="hei12"><a href="3-0-0.aspx" onclick="ChangeSelect(3)">七星彩</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="td9" height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span9" class="hei12"><a href="9-0-0.aspx" onclick="ChangeSelect(9)">22选5</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="td65" height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span65" class="hei12"><a href="65-0-0.aspx" onclick="ChangeSelect(65)">31选7</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="td1" height="22" background="../Home/Room/Images/bg_xuxian.jpg" style="padding-left: 22px;">
                                        <span id="span41" class="hei12"><a href="41-0-0.aspx" onclick="ChangeSelect(41)">浙江体彩6+1</a></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="../Home/Room/Images/left_foot.jpg" width="200" height="3" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="content1_770">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9BBFCA">
                    <tr>
                        <td height="50" background="../Home/Web/Images/bg_title_blue_52.jpg" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td bgcolor="#FFFFFF" class="bg_shang" style="padding: 15px 20px 15px 20px;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="283">
                                                    <asp:Image ID="imgLogo" runat="server" Height="45px" Width="283px" />
                                                </td>
                                                <td class="blue12">
                                                    第<span class="red14">&nbsp;<asp:Label ID="lbIsuse" runat="server"></asp:Label>
                                                    </span>期
                                                </td>
                                                <td width="340" align="right" class="blue12">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                选择期号：
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlIsuses" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIsuses_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding-left: 5px;">
                                                                选择玩法：
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPlayTypes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPlayTypes_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" bgcolor="#FFFFFF" style="padding: 10px;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="104" align="right" class="blue14">
                                                    开奖结果：
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="6" cellpadding="0">
                                                        <tr>
                                                            <td id="tbWinNumber" runat="server" height="25">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="407" class="black12">
                                                    开奖日期：<asp:Label ID="lbOpenDate" runat="server"></asp:Label>
                                                    兑奖截止日期：<asp:Label ID="lbGetPrizeEndTime" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lbWinInfo" runat="server"></asp:Label>
                                        <div class="red12" style="width: 100%; height: 24px; line-height: 24px; padding-left: 30px;">
                                            <a href="<%= BuyUrl %>">
                                                <%=LotteryName %>投注/合买</a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="<%= TrendUrl %>">
                                                    <%=LotteryName %>走势图</a>
                                        </div>
                                        <hr style="border-bottom: #cccccc 1px dashed; border-left: #cccccc 1px dashed; width: 100%;
                                            border-top: #cccccc 1px dashed; border-right: #cccccc 1px dashed; height: 1px;" />
                                        <table align="center" width="80%" border="0" height="100px">
                                            <tr>
                                                <td id="LatestOpenInfo" runat="server" class="blue12">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9BBFCA"
                    style="margin-top: 10px">
                    <tr>
                        <td height="36" background="../Home/Web/Images/bg_blue_36.jpg" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="45" align="center">
                                        <img src="../Home/Web/Images/icon_jiangzhuang_2.gif" width="17" height="24" />
                                    </td>
                                    <td width="379" class="blue14">
                                        本站中奖情况
                                    </td>
                                    <td width="231" class="blue12">
                                        <asp:TextBox ID="tbSearch" runat="server" class="in_text" size="40" value="(可输入发起人ID或方案编号搜索)"
                                            onfocus="if(this.value=='(可输入发起人ID或方案编号搜索)')this.value='';" onblur="if(this.value=='')this.value='(可输入发起人ID或方案编号搜索)';"></asp:TextBox>
                                    </td>
                                    <td width="83" class="blue12">
                                        <ShoveWebUI:ShoveConfirmButton ID="btnSearch" Style="cursor: pointer;" BackgroupImage="../Home/Room/Images/button_sousuo.jpg"
                                            runat="server" Height="23px" Width="72px" CausesValidation="False" BorderStyle="None"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" bgcolor="#FFFFFF" class="bg_x" style="padding: 12px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#add3ef">
                                <tbody class="blue12" style="background-color: White; text-align: left; height: 25px;
                                    padding-left: 10px;">
                                    <asp:Repeater ID="rptWinDetail" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td width="15%" height="28" align="right" bgcolor="#ecf5fc">
                                                    发起人：
                                                </td>
                                                <td width="85%" bgcolor="#ecf5fc">
                                                    <table>
                                                        <tr>
                                                            <td width="30%">
                                                                <strong>
                                                                    <%#Eval("InitiateName")%></strong>
                                                            </td>
                                                            <td align="right" width="30%">
                                                                <asp:ImageButton ID="btn_Single" ImageUrl="../Home/Web/Images/btnzzThis.jpg" runat="server"
                                                                    Width="133px" Height="28px" OnClientClick="return CreateLogin('');" OnClick="btn_Single_Click"
                                                                    CommandArgument='<%#Eval("InitiateUserID")%>' />
                                                                <asp:ImageButton ID="btn_All" ImageUrl="../Home/Web/Images/btnzzAll.jpg" runat="server"
                                                                    Width="133px" Height="28px" OnClientClick="return CreateLogin('');" OnClick="btn_All_Click"
                                                                    CommandArgument='<%#Eval("InitiateUserID")%>' />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="25" align="right">
                                                    方案类型：
                                                </td>
                                                <td>
                                                    <%#Eval("PlayTypeName")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    方案编号：
                                                </td>
                                                <td>
                                                    <a href="../Home/Room/Scheme.aspx?id=<%#Eval("ID") %>" target="_blank">
                                                        <%#Eval("SchemeNumber")%></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    金额：
                                                </td>
                                                <td>
                                                    共
                                                    <%#Eval("Money")%>
                                                    元 共
                                                    <%#Eval("Share")%>
                                                    份，<%#Eval("EachMonney")%>
                                                    元/份
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    中奖情况：
                                                </td>
                                                <td>
                                                    <%#Eval("WinDescription2")%><span class="red">
                                                        <%#Eval("Multiple")%></span> 倍，共计 <span class="red0"><strong>
                                                            <%#Convert.ToDouble(Eval("WinMoneyNoWithTax")).ToString("N")%></strong></span>
                                                    元（税后）
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    每份派奖金额：
                                                </td>
                                                <td>
                                                    <%#Eval("ShareWinMoney")%>
                                                    元/份
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    <asp:HyperLink ID="FollowUser" runat="server" NavigateUrl='<%#"FollowFriendSchemeAdd_User.aspx?FollowUserID="+DataBinder.Eval(Container.DataItem,"InitiateUserID").ToString()+"&FollowUserName="+ HttpUtility.UrlEncode(DataBinder.Eval(Container.DataItem,"InitiateName").ToString())+"&LotteryID=-1"%>'><span class="red12_2">定制自动跟单</span></asp:HyperLink>
                                                </td>
                                            </tr>--%>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 12px;">
                                <tbody id="tbPaging" runat="server" enableviewstate="false">
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>

    <script src="../Home/Room/JavaScript/Public.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function showPage(p, l, i, t, s) {
            if (String(s) != "") {
                location.href = String(l) + "-" + String(i) + "-" + String(t) + "-" + String(s) + "-" + String(p) + ".aspx";
            }
            else {
                location.href = String(l) + "-" + String(i) + "-" + String(t) + "-0-" + String(p) + ".aspx";
            }
            //location.href = "Default.aspx?PID=" + String(p) + "&LotteryID=" + String(l) + "&IsuseID=" + String(i) + "&PlayTypeID=" + String(t) + "&Search=" + String(s);
        }

        function ChangeSelect(lotteryID) {
            var arr = new Array(5, 6, 13, 59, 58, 29, 1, 2, 15, 39, 62, 63, 64, 3, 9, 65, 61,70,41);
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == lotteryID) {
                    document.getElementById("span" + arr[i]).className = "red12";
                }
                else {
                    document.getElementById("span" + arr[i]).className = "hei12";
                }
            }
        }

       ChangeSelect(<%=LotteryID %>);
    </script>

    <!--#includefile="../Html/TrafficStatistics/1.htm"-->
</body>
</html>
