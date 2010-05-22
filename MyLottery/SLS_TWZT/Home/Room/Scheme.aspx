<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/Scheme.aspx.cs" inherits="Home_Room_Scheme" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>彩票购买方案-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。" />
    <meta name="keywords" content="双色球开奖，双色球走势图，3d走势图，福彩3d，时时彩" />
    <style type="text/css">
        body
        {
            min-width: 970x;
            font-family: "tahoma";
            font-size: 12px;
            text-align: center;
        }
        .mOver
        {
            border: #FF9900 1px solid;
            background-color: #FFF5D0;
        }
        .mOut
        {
            border: #95C2E8 1px solid;
            background-color: #E9F1F8;
        }
        .mClick
        {
            border: #FF9900 1px solid;
            background-color: #FFF5D0;
        }
        .s1
        {
            color: #999;
        }
        .s2
        {
            font-weight: bold;
            color: #693;
        }
        .tzhei12
        {
            font-size: 12px;
            color: #333333;
            line-height: 20px;
        }
        .tzhui12
        {
            font-size: 12px;
            color: #666666;
            line-height: 20px;
        }
        .tzblue12
        {
            font-size: 12px;
            color: #103875;
            line-height: 20px;
        }
        .tzred14
        {
            font-size: 14px;
            color: #cc0000;
            line-height: 22px;
            font-weight: bold;
        }
        .tzred12
        {
            font-size: 12px;
            color: #cc0000;
            line-height: 20px;
        }
        .tzbai14
        {
            font-size: 14px;
            color: #ffffff;
            line-height: 20px;
            font-weight: bold;
        }
        .tzbai12
        {
            font-size: 12px;
            color: #ffffff;
            line-height: 18px;
            font-weight: bold;
        }
        .td14
        {
            font-size: 14px;
            color: #000000;
            line-height: 20px;
        }
        .red14
        {
            font-size: 14px;
            color: #ff0000;
            line-height: 22px;
            font-weight: 600;
        }
        .blue
        {
            font-size: 12px;
            color: #3D5B96;
            line-height: 20px;
        }
        .blue14
        {
            font-size: 14px;
            color: #3D5B96;
            line-height: 20px;
            font-weight: 600;
        }
        .blue14 A:hover
        {
            font-family: "tahoma";
            color: #cc0000;
            text-decoration: none;
        }
        .red
        {
            font-size: 12px;
            color: #cc0000;
            line-height: 20px;
        }
        .in_text_hui
        {
            height: 16px;
            border: 1px solid #cccccc;
            background-color: #FFFFFF;
            color: #666666;
            font-size: 12px;
        }
    </style>
    <link href="Style/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../JavaScript/Public.js" language="javascript"
        charset="gbk"></script>

    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">

    <script type="text/javascript">
        <!--
        var o_labBalance;
        var o_labShare;
        var o_labShareMoney;
        var o_tbShare;
        var o_labSumMoney;
        var o_btnOK;
        var o_labWinNumber;
        var o_labReward;

        function Init() {
            o_labBalance = document.getElementById("<%=labBalance.ClientID%>");
            o_labShare = document.getElementById("<%=labShare.ClientID%>");
            o_labShareMoney = document.getElementById("<%=labShareMoney.ClientID%>");
            o_tbShare = document.getElementById("<%=tbShare.ClientID%>");
            o_labSumMoney = document.getElementById("<%=labSumMoney.ClientID%>");
            o_btnOK = document.getElementById("<%=btnOK.ClientID%>");

            o_labWinNumber = document.getElementById("<%=lbWinNumber.ClientID%>");
            o_labReward = document.getElementById("<%=lbReward.ClientID%>");

            var o_trWinNumber = document.getElementById("trWinNumber");

            if (o_labWinNumber.innerHTML != "") {
                trWinNumber.style.display = "";
            }
            else {
                trWinNumber.style.display = "none";
            }

            var o_trReward = document.getElementById("trReward");
            
            if(o_trReward)
            {
                if (o_labReward.innerHTML != "") {
                    trReward.style.display = "";
                }
                else {
                    trReward.style.display = "none";
                }
            }
        }

        function SetbtnOKFocus() {
            o_btnOK.focus();
            return true;
        }

        function onUserListClick() {
            var obj1 = document.getElementById("trUserListDetail");

            if (obj1.style.display == "none") {
                obj1.style.display = "";
            }
            else {
                obj1.style.display = "none";
            }
        }

        function InputMask_Number() {
            if (window.event.keyCode < 48 || window.event.keyCode > 57)
                return false;
            return true;
        }

        function CheckShare(sender) {
            var BuyShare = StrToInt(sender.value);
            var SpareShare = StrToInt(o_labShare.innerText);

            if ((BuyShare < 1) || (BuyShare > SpareShare)) {
                if (confirm("份数不正确，按“确定”重新输入，按“取消”自动更正为 " + SpareShare + " 份，请选择。")) {
                    sender.focus();
                    return;
                }
                else {
                    BuyShare = SpareShare;
                    sender.value = SpareShare;
                }
            }

            o_labSumMoney.innerText = Round(BuyShare * StrToFloat(o_labShareMoney.innerText), 2);

            SetbtnOKFocus();
        }

        function btnOKClick() {

            var BuyShare = StrToInt(o_tbShare.value);
            var SpareShare = StrToInt(o_labShare.innerText);
            var SumMoney = StrToFloat(o_labSumMoney.innerText);

            if ((BuyShare < 1) || (BuyShare > SpareShare)) {
                alert("请输入正确的认购份数。");

                o_tbShare.focus();
                return false;
            }
            if (SumMoney < 0) {
                alert("输入有错误。");
                return false;
            }
            o_labBalance.innerText = Home_Room_Scheme.GetUserBalance().value;
            var Balance = StrToFloat(o_labBalance.innerText);
            if (Balance < SumMoney) {
                if (confirm("您的账户余额不足，请先充值，谢谢。您要立即在线购买吗？"))
                    window.document.location.href = "MyIcaile.aspx?SubPage=OnlinePay/Default.aspx";
                return false;
            }

            var TipStr = "您要入伙此合买方案，详细内容：\n\n";
            TipStr += "　　份　数：　" + BuyShare + " 份\n";
            TipStr += "　　每　份：　" + o_labShareMoney.innerText + " 元\n";
            TipStr += "　　总金额：　" + SumMoney + " 元\n\n";

            if (!confirm(TipStr + "按“确定”即表示您已阅读《用户电话短信投注协议》并立即参与合买方案，确定要入伙吗？"))
                return false;

            __doPostBack("btnOK", "");
        }

        function CreateUplaodDialog() {
            var msgw, msgh, bordercolor;
            msgw = 580; //提示窗口的宽度 
            msgh = 450; //提示窗口的高度 
            //titleheight=25 //提示窗口标题高度 
            //bordercolor="#336699";//提示窗口的边框颜色
            //titlecolor="#99CCFF";//提示窗口的标题颜色
            var sWidth, sHeight;
            sWidth = document.body.offsetWidth;
            sHeight = document.body.offsetHeight;
            var bgObj = document.createElement("div");
            bgObj.setAttribute('id', 'bgDiv2');
            bgObj.style.position = "absolute";
            bgObj.style.top = "0";
            bgObj.style.background = "#777";
            bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75";
            bgObj.style.opacity = "0.6";
            bgObj.style.left = "0";
            bgObj.style.width = sWidth + "px";
            bgObj.style.height = sHeight + "px";
            bgObj.style.zIndex = "10000";
            document.body.appendChild(bgObj);

            var msgObj = document.createElement("div")
            msgObj.setAttribute("id", "msgDiv2");
            msgObj.setAttribute("align", "center");
            msgObj.style.backcolor = "white";
            //msgObj.style.border="1px solid " + bordercolor; 
            msgObj.style.position = "absolute";
            msgObj.style.left = "50%";
            msgObj.style.top = "20%";
            msgObj.style.font = "12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif";
            msgObj.style.marginLeft = "-225px";
            msgObj.style.marginTop = document.documentElement.scrollTop + "px";
            msgObj.style.width = msgw + "px";
            msgObj.style.height = msgh + "px";
            msgObj.style.textAlign = "center";
            msgObj.style.lineHeight = "25px";
            msgObj.style.zIndex = "10001";

            document.body.appendChild(msgObj);

            var txt = document.createElement("p");
            txt.style.margin = "1em 0"
            txt.setAttribute("id", "msgTxt2");

            var dialog = '<table><tr><td style="background-color: #AFBCD6; padding: 10px;font-size:12px"><table style="width: 100%;background-color:White;" border="0" cellpadding="0" cellspacing="1"><tr><td height="36" bgcolor="#6D84B4" class="bai14" style="padding: 0px 10px 0px 15px;text-align:left;"><span id="lbLotteryName"></span> 第 <span id="lbIsuse"></span>&nbsp;期 粘贴投注</td></tr><tr><td style="padding: 5px;" align="center"><textarea id="tbLotteryNumbers" style="width:98%; height:160px;"></textarea></td></tr><tr><td><table width="100%" border="0" align="right" cellpadding="0" cellspacing="0"><tr><td style="text-align:left;"><table cellpadding="0" cellspacing="0" style="width:100%;"><tr><td style="text-align:right;">方案上传：</td><td colspan="2"><iframe id="frame_Upload" name="frame_Upload" frameborder="0" src="SchemeUpload.aspx?id=<%=LotteryID %>&PlayType=<%=PlayTypeID %>" width="100%" scrolling="no" height="30"></iframe></td></tr></table></td></tr><tr><td style="text-align:right; padding-right:10px;"><font color="#ff0000">【注】</font>如果选择方案文件<font color="#ff0000">(.txt格式)</font>上传,上面的投注内容将被清除并被替换成方案文件里面的内容。<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 方案文件中请输入规范的投注内容，多注请用回车换行。 <span class="blue12"><a href="SchemeExemple.aspx?id=' + <%=LotteryID %> + '" target="_blank">请参看格式规范</a></span></td></tr><tr><td style="background-color:#f2f2f2; padding:10px;"><table width="280" border="0" align="right" cellpadding="0" cellspacing="0"><tbody style="cursor: pointer; color: White;"><tr><td width="19%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_OK();">确定</td></tr></table></td><td width="32%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_Close();">取消</td></tr></table></td><td width="32%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_Close();">关闭窗口</td></tr></table></td></tr></tbody></table></td></tr></table></td></tr></table></td></tr></table>';

            txt.innerHTML = dialog;

            document.getElementById("msgDiv2").appendChild(txt);
            document.getElementById("tbLotteryNumbers").focus();

            document.getElementById("lbIsuse").innerHTML = document.getElementById('labTitle').innerHTML;
            document.getElementById("lbLotteryName").innerHTML = '<%=LotteryName %>';
            
            return false;
        }

        function btn_Close() {
            document.body.removeChild(bgDiv2);
            document.body.removeChild(msgDiv2);
        }

        function btn_OK() {
            try {
                var LotteryNumber = Home_Room_Scheme.AnalyseScheme(document.getElementById("tbLotteryNumbers").value, '<%=LotteryID %>', <%=PlayTypeID %>);
                if (LotteryNumber == null || LotteryNumber.value == null) {
                    document.body.removeChild(bgDiv2);
                    document.body.removeChild(msgDiv2);
                    alert("从方案文件中没有提取到符合书写规则的投注内容。");

                    return;
                }

                var r = LotteryNumber.value;

                if (typeof (r) != "string") {
                    document.body.removeChild(bgDiv2);
                    document.body.removeChild(msgDiv2);
                    alert("从方案文件中没有提取到符合书写规则的投注内容。");

                    return;
                }
            }
            catch (e) {
                document.body.removeChild(bgDiv2);
                document.body.removeChild(msgDiv2);
                alert("从方案文件中没有提取到符合书写规则的投注内容。");

                return;
            }

            var Lotterys = r.split("\n");
            var Num=0;
            var Content="";
            for (var i = 0; i < Lotterys.length; i++) {
                var str = Lotterys[i].trim();
                if (str == "")
                    continue;
                strs = str.split("|");

                if (strs.length != 2) {
                    continue;
                }

                str = strs[0].trim();
                if (str == "") {
                    continue;
                }
                
                Content += str+"\n";
                Num += StrToInt(strs[1]);
            }
            
            if(Num*2!=StrToInt(labSchemeMoney.innerHTML))
            {
                alert("上传的金额与方案金额不相符！");
                
                return;
            }
            
            var result = Home_Room_Scheme.UpdateLotteryNumber(String(<%=SchemeID %>),Content).value;
            alert(result);
            
            document.body.removeChild(bgDiv2);
            document.body.removeChild(msgDiv2);
            window.location.href = window.location.href;
        }
        -->
    </script>

    <asp:HiddenField ID="HidSchedule" runat="server" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <asp:HiddenField ID="hfID" runat="server" />
    <table cellpadding="0" cellspacing="0" width="1002">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px;">
                <table width="1002" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
                    <tr style="display: none;">
                        <td height="50" background="images/bg_58.jpg">
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <asp:Image ID="ImageLogo" runat="server" />
                                    </td>
                                    <td class="td14" style="padding-right: 50px; padding-left: 20px;">
                                        第<span class="red14"><asp:Label ID="labTitle" runat="server" Text=""></asp:Label></span>期
                                        <asp:TextBox ID="tbIsuseID" runat="server" Width="30px" Visible="False"></asp:TextBox><asp:TextBox
                                            ID="tbLotteryID" runat="server" Width="30px" Visible="False"></asp:TextBox><asp:TextBox
                                                ID="tbSchemeID" runat="server" Width="30px" Visible="False"></asp:TextBox><asp:TextBox
                                                    ID="tbStop" runat="server" Width="30px" Visible="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        认购开始时间：
                                        <asp:Label ID="labStartTime" runat="server" ForeColor="Red"></asp:Label></span>
                                        认购截止时间：
                                        <asp:Label ID="labEndTime" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#FFFFFF">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#E2EAED"
                                id="Table2" style="width: 100%">
                                <tr>
                                    <td height="36" colspan="2" align="center" bgcolor="#f7f7f7" class="blue14">
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" colspan="2" bgcolor="#E9F1F8" class="blue" style="padding-left: 12px;">
                                        <strong>方案基本信息</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">方案发起人：</font>
                                    </td>
                                    <td align="left" valign="top" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="labInitiateUser" runat="server"></asp:Label>
                                                    &nbsp;&nbsp;
                                                    <ShoveWebUI:ShoveConfirmButton ID="btnQuashScheme" BackgroupImage="../images/btnBack02.gif"
                                                        Style="font-size: 9pt; cursor: hand; border-top-style: none; font-family: Tahoma;
                                                        border-right-style: none; border-left-style: none; border-bottom-style: none"
                                                        runat="server" Height="20px" Width="84px" Text="我要撤消方案" Visible="False" CommandName="QuashIsuse"
                                                        AlertText="确信要撤消此方案吗？" OnClick="btnQuashScheme_Click" onblur="return SetbtnOKFocus();" />&nbsp;
                                                    <asp:CheckBox ID="cbAtTopApplication" runat="server" Text="申请置顶" AutoPostBack="True"
                                                        Visible="False" OnCheckedChanged="cbAtTopApplication_CheckedChanged"></asp:CheckBox>
                                                    <span class="red">
                                                        <asp:Label ID="labAtTop" runat="server" Visible="False">方案已置顶</asp:Label></span>
                                                </td>
                                                <td width="300px;" style="margin-right: 0px;">
                                                    <asp:ImageButton ID="btn_Single" ImageUrl="../web/images/btnzzThis.jpg" runat="server"
                                                        Width="133px" Height="28px" OnClientClick="return CreateLogin('');" OnClick="btn_Single_Click" />
                                                    <asp:ImageButton ID="btn_All" ImageUrl="../web/images/btnzzAll.jpg" runat="server"
                                                        Width="133px" Height="28px" OnClientClick="return CreateLogin('');" OnClick="btn_All_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">方案状态：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <span class="red">
                                            <asp:Label ID="labState" runat="server"></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">投注内容：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-right: 2px; padding-left: 12px;
                                        padding-bottom: 2px; padding-top: 2px">
                                        <asp:Label ID="labLotteryNumber" runat="server"></asp:Label>
                                        <asp:HyperLink ID="linkDownloadScheme" runat="server" Visible="False" CssClass="li3"
                                            Target="_blank">下载方案</asp:HyperLink>
                                        <asp:LinkButton ID="lbUploadScheme" runat="server" Visible="False" CssClass="li3"
                                            OnClientClick="return CreateUplaodDialog()">上传方案</asp:LinkButton>
                                        <asp:Repeater ID="rptScheme" runat="server" Visible="false">
                                            <HeaderTemplate>
                                                <table id="tbl_1" cellpadding="0" cellspacing="1" bgcolor="#666666" width="600">
                                                    <tr class="trbg2" align="center" bgcolor="#ffffff">
                                                        <td style="width: 50px">
                                                            场次
                                                        </td>
                                                        <td style="width: 70px">
                                                            赛事
                                                        </td>
                                                        <td style="width: 100px">
                                                            主队
                                                        </td>
                                                        <td style="width: 30px">
                                                            VS
                                                        </td>
                                                        <td style="width: 100px">
                                                            客队
                                                        </td>
                                                        <td style="width: 200px">
                                                            投注内容
                                                        </td>
                                                        <td style="width: 50px">
                                                            彩果
                                                        </td>
                                                        <td style="width: 50px">
                                                            sp值
                                                        </td>
                                                    </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="trbg2" align="center" bgcolor="#ffffff">
                                                    <td style="width: 50px">
                                                        <%# Eval("No")%>
                                                    </td>
                                                    <td class="gameTypeFont" bgcolor='<%# Eval("MarkersColor")%>' style="width: 70px">
                                                        <%# Eval("LeagueTypeName")%>
                                                    </td>
                                                    <td style="width: 100px">
                                                        <%# Eval("HostTeam") %>
                                                    </td>
                                                    <td style="width: 30px">
                                                        VS
                                                    </td>
                                                    <td style="width: 100px">
                                                        <%# Eval("QuestTeam") %>
                                                    </td>
                                                    <td style="width: 200px">
                                                        <%# Eval("Content") %>
                                                    </td>
                                                    <td style="width: 50px">
                                                        <%# Eval("LotteryResult")%>
                                                    </td>
                                                    <td style="width: 50px">
                                                        <%# Eval("sp")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                <tr id="trWinNumber">
                                    <td height="25" align="right" bgcolor="#F6F9FE" id="td1" style="width: 120px; height: 19px">
                                        <font face="Tahoma">开奖号码：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" id="td2" style="padding-left: 12px;">
                                        <span class="red">
                                            <asp:Label ID="lbWinNumber" runat="server" Font-Bold="true"></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px; height: 19px">
                                        <font face="Tahoma">投注倍数：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labMultiple" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">方案编号：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labSchemeNumber" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trBonusScale" runat="server" visible="false">
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">佣金比例：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="lbSchemeBonus" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">方案发起时间：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labSchemeDateTime" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">方案总金额：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labSchemeMoney" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" colspan="2" bgcolor="#E9F1F8" class="blue" style="padding-left: 12px;">
                                        <strong>方案投注信息</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">方案标题：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labSchemeTitle" runat="server" Style="word-break: break-all; word-wrap: break-word"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">方案描述：</font>
                                    </td>
                                    <td align="left" valign="top" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labSchemeDescription" runat="server" Style="word-break: break-all;
                                            word-wrap: break-word"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">广告地址：</font>
                                    </td>
                                    <td align="left" valign="top" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labSchemeADUrl" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">方案详细情况：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labSchemeDetail" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">彩票标识：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labLotteryCode" runat="server"></asp:Label>
                                        <asp:HyperLink ID="linkDownloadLotteryIdentifiers" runat="server" Visible="False"
                                            Target="_blank" CssClass="li3">查看电子凭证</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">保底金额：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labAssureMoney" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="36" align="right" bgcolor="#FFF2F2" style="width: 120px">
                                        <font face="Tahoma">我要认购：</font>
                                    </td>
                                    <td align="left" bgcolor="#FFF2F2" style="padding-left: 12px;">
                                        <asp:Label ID="labCannotBuyTip" runat="server" Visible="False"></asp:Label><asp:Panel
                                            ID="pBuy" runat="server" Visible="False" Width="100%">
                                            我的账户余额
                                            <asp:Label ID="labBalance" runat="server" ForeColor="Red">0.00</asp:Label>&nbsp;,此方案还有
                                            <asp:Label ID="labShare" runat="server" ForeColor="Red">0</asp:Label>&nbsp;份可以认购,每份
                                            <asp:Label ID="labShareMoney" runat="server" ForeColor="Red">0.00</asp:Label>&nbsp;元,我想认购&nbsp;
                                            <asp:TextBox onkeypress="return InputMask_Number();" class="in_text_hui" ID="tbShare"
                                                onblur="return CheckShare(this);" runat="server" Width="64px"></asp:TextBox>&nbsp;份,总金额
                                            <asp:Label ID="labSumMoney" runat="server" ForeColor="Red">0.00</asp:Label>&nbsp;元</asp:Panel>
                                        【<a href="OnlinePay/Default.aspx" target="_blank">用户充值</a>】【<a href="AccountDetail.aspx"
                                            target="_blank">账户明细</a>】
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; margin: 20px; background-color: #ffffff; padding-bottom: 5px;
                                        padding-top: 5px;" id="divOK" runat="server" colspan="2">
                                        <asp:Panel ID="panelInvestPassword" runat="server" Width="250px">
                                            请输入投注密码：
                                            <asp:TextBox ID="tbInvestPassword" runat="server" Width="100px" TextMode="Password"
                                                onblur="return SetbtnOKFocus();"></asp:TextBox></asp:Panel>
                                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" BackgroupImage="images/button_qxgm.jpg"
                                            runat="server" Style="cursor: pointer;" Height="38" Width="127" OnClick="btnOK_Click"
                                            OnClientClick="return CreateLogin('btnOKClick()');" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="red" style="text-align: center; background-color: #ffffff;" id="divqueding"
                                        runat="server" colspan="2">
                                        【注】点击的“确定购买”按钮即表示您已阅读了《用户电话短信投注协议》并同意其中条款。
                                    </td>
                                </tr>
                                <tbody id="tbgcjl" runat="server">
                                    <tr>
                                        <td height="25" colspan="2" bgcolor="#E9F1F8" class="blue" style="padding-left: 12px;">
                                            <strong>方案认购信息</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                            <font face="Tahoma">参与用户列表：</font>
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                            <asp:Label ID="labUserList" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trUserListDetail">
                                        <td height="25" bgcolor="#F6F9FE">
                                        </td>
                                        <td bgcolor="#FFFFFF" align="left" style="padding-left: 8px; padding-bottom: 8px;
                                            padding-right: 8px; padding-top: 8px;">
                                            <ShoveWebUI:ShoveDataList ID="gUserList" runat="server" Width="100%" RepeatColumns="2"
                                                AllowPaging="true" PageSize="60" NextPageText="下一页" PageMode="NextPrev" PrevPageText="上一页"
                                                OnPageIndexChanged="gUserList_PageIndexChanged" PagerPosition="Bottom">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>
                                                            <td class="s2">
                                                                <%# Eval("Name")%>：
                                                            </td>
                                                            <td>
                                                                <font color="red">
                                                                    <%# Eval("Share")%>
                                                                </font>份
                                                            </td>
                                                            <td class="red">
                                                                <font color="red">
                                                                    <%# double.Parse(Eval("DetailMoney").ToString()).ToString("N")%>
                                                                </font>元
                                                            </td>
                                                            <td class="s1">
                                                                <%# Eval("DateTime")%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </ShoveWebUI:ShoveDataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                            <font face="Tahoma">我的认购记录：</font>
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                            <asp:Label ID="labMyBuy" runat="server"></asp:Label>
                                            <asp:DataGrid ID="g" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None"
                                                ShowHeader="False" OnItemCommand="g_ItemCommand" OnItemDataBound="g_ItemDataBound">
                                                <Columns>
                                                    <asp:BoundColumn DataField="Share">
                                                        <HeaderStyle Width="5%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="DetailMoney">
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn>
                                                        <HeaderStyle Width="35%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="DateTime">
                                                        <HeaderStyle Width="20%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn>
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn>
                                                        <HeaderStyle Width="20%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <ShoveWebUI:ShoveConfirmButton ID="btnQuashBuy" BackgroupImage="images/btnBack02.gif"
                                                                Style="font-size: 9pt; cursor: hand; border-top-style: none; font-family: Tahoma;
                                                                border-right-style: none; border-left-style: none; border-bottom-style: none"
                                                                runat="server" Height="20px" Width="84px" Text="我要撤消" CommandName="QuashBuy"
                                                                AlertText="确信要撤消此认购记录吗？" onblur="return SetbtnOKFocus();" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn Visible="False" DataField="QuashStatus">
                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="Buyed">
                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="IsuseID"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="Code"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="BuyedShare"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="Schedule"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="id"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="isWhenInitiate"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="SchemeShare"></asp:BoundColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" colspan="2" bgcolor="#E9F1F8" class="blue" style="padding-left: 12px;">
                                            <strong>方案中奖信息</strong>
                                        </td>
                                    </tr>
                                </tbody>
                                <tr>
                                    <td height="25" align="right" bgcolor="#F6F9FE" style="width: 120px">
                                        <font face="Tahoma">中奖情况：</font>
                                    </td>
                                    <td align="left" valign="top" bgcolor="#FFFFFF" style="padding-left: 12px;">
                                        <asp:Label ID="labWin" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trReward" runat="server">
                                    <td height="25" align="right" bgcolor="#F6F9FE" id="td5" style="width: 120px">
                                        <font face="Tahoma">我的奖金：</font>
                                    </td>
                                    <td align="left" valign="top" bgcolor="#FFFFFF" id="td6" style="padding-left: 12px;">
                                        <asp:Label ID="lbReward" runat="server" ForeColor="red"></asp:Label>
                                        元
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script src="JavaScript/Public.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">
    Init();
</script>

