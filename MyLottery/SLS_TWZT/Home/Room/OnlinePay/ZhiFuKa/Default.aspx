<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/OnlinePay/ZhiFuKa/Default.aspx.cs" inherits="Home_Room_OnlinePay_ZhiFuKa_Default" enableEventValidation="false" %>

<%@ Register Src="../../UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>手机充值卡充值-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="keywords" content="手机充值卡充值" />
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <link href="../../Style/css.css" type="text/css" rel="stylesheet" />

    <script src="../../JavaScript/Public.js" type="text/javascript"></script>

    <script type="text/javascript">
		<!--
        function showOrHidArae(sender) {

            if (sender.checked) {

                $Id("tb_szx").style.display = (sender.id == "radSZX" ? "" : "none");

                $Id("tb_51zfk").style.display = (sender.id == "rad51ZFK" ? "" : "none");

            }

        }

        function CheckMultiple(sender) {

            if (sender != undefined && sender != null) {

                switch (sender.id) {

                    case "txtCardNum_szx":

                        if (sender.value.length != 17) {
                            // alert("神州行卡必须是17位（全国卡）、16位（江苏卡）、10位（浙江卡），请填写正确的卡号！"); && sender.value.length != 16 && sender.value.length != 10
                            alert("神州行卡，卡号必须是17位，请填写正确的卡号！");
                            sender.focus();
                            return false;
                        }

                        break;
                    case "txtCardPass_szx":

                        if (sender.value.length != 18) {

                            //                            alert("神州行（全国）卡，密码必须18位，请填写正确的密码！"); $Id("txtCardNum_szx").value.length == 17 &&
                            alert("神州行卡，密码必须18位，请填写正确的密码！");
                            sender.focus();
                            return false;
                        }

//                        if ($Id("txtCardNum_szx").value.length == 16 && sender.value.length != 17) {
//                            alert("神州行（江苏）卡，密码必须17位，请填写正确的密码！");
//                            sender.focus();
//                            return;
//                        }

//                        if ($Id("txtCardNum_szx").value.length == 10 && sender.value.length != 8) {
//                            alert("神州行（浙江）卡，密码必须8位，请填写正确的密码！");
//                            sender.focus();
//                            return false;
//                        }

                        break;
                    case "txtCardNum_zfk":

                        if (sender.value.length != 15) {
                            alert("51支付卡，卡号必须是15位，请填写正确的卡号！");
                            sender.focus();
                            return false;
                        }

                        break;
                    case "txtCardPass_zfk":

                        if (sender.value.length != 10) {
                            alert("51支付卡，密码必须是10位，请填写正确的卡号！");
                            sender.focus();
                            return false;
                        }


                        break;

                    case "rblist_zfk":

                        var sels = document.getElementsByName(sender.id);
                        if (sels != undefined && sels != null) {
                            var i = 0;
                            for (i = 0; i < sels.length; i++) {
                                if (sels[i].checked) {
                                    return true;
                                }
                            }

                        }

                        alert("请选择51支付卡面值！");

                        return false;
                        break;

                    case "rblist_szx":

                        var sels = document.getElementsByName(sender.id);
                        if (sels != undefined && sels != null) {
                            var i = 0;
                            for (i = 0; i < sels.length; i++) {
                                if (sels[i].checked) {
                                    return true;
                                }
                            }

                        }

                        alert("请选择神州行卡的面值！");
                        return false;
                        break;

                }
            }
            else {
                return false;
            }

            return true;
        }

        //控制输入字母和数字
        function InputMask_Number() {
            if (window.event.keyCode < 48 || window.event.keyCode > 57)
                return false;
            return true;
        }


        //提交
        function btn_OK() {


            if ($Id("labCardType").innerText != "51支付卡充值") {

                if (CheckMultiple($Id("txtCardNum_szx")) && CheckMultiple($Id("txtCardPass_szx"))) {
                    //&& CheckMultiple($Id("rblist_szx"))
                    return true;
                }

            }
            else {
                //&& CheckMultiple($Id("rblist_zfk"))
                if (CheckMultiple($Id("txtCardNum_zfk")) && CheckMultiple($Id("txtCardPass_zfk"))) {

                    return true;
                }
            }

            return false;

        }
    

		-->
    </script>

    <style type="text/css">
        .sp_money
        {
            color: Red;
            font-weight: bold;
        }
    </style>
</head><link rel="shortcut icon" href="../../../../favicon.ico"/>
<body>
    <form id="Form1" name="Form1" method="post" runat="server">
    <asp:HiddenField ID="hdBankCode" runat="server" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="40" height="30" align="right" valign="middle" class="red14">
                        <img src="../../Images/icon_5.gif" width="19" height="16" />
                    </td>
                    <td valign="middle" class="red14" style="padding-left: 10px;">
                        我的帐户
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="20" height="29">
                        &nbsp;
                    </td>
                    <td width="100" align="center" background="../../images/admin_qh_100_1.jpg" class="blue12">
                        <a href="Send.aspx"><strong>我要充值</strong></a>
                    </td>
                    <td width="4">
                        &nbsp;
                    </td>
                    <td width="6">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="1" colspan="11" bgcolor="#FFFFFF">
                    </td>
                </tr>
                <tr>
                    <td height="2" colspan="11" bgcolor="#6699CC">
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
                <tr>
                    <td height="30" colspan="2" align="left" bgcolor="#E9F1F8" class="black12" style="padding-left: 20px;">
                        您好，<span class="red12"><%=UserName%></span>！您当前帐户余额为：￥<span class="red12"><%= Balance%>
                        </span>元
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#C0DBF9">
                <tr>
                    <td height="10" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="93" height="36" align="right" bgcolor="#FFFFFF" class="black12">
                        <span class="red12">*</span> 充值卡类型：
                    </td>
                    <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                        <label style="display: none;">
                                                      <asp:RadioButton ID="radSZX" GroupName="payWay" Visible="false" runat="server"
                                onclick="showOrHidArae(this)" />神州行充值卡
                        </label>
                        <label style="display: none;">
                            <asp:RadioButton ID="rad51ZFK" GroupName="payWay" Visible="false" runat="server"
                                onclick="showOrHidArae(this)" />
                            51支付卡
                        </label>
                       <asp:Image ImageUrl="../Alipay02/images/bank_logo/logo_szx.gif" ID="imgCardType" runat="server" Width="121px" Height="27px" />
                        <asp:LinkButton ID="lbReturn" runat="server" Text="【重选支付方式】" OnClick="lbReturn_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tbody id="tb_szx" runat="server">
                    <tr>
                        <td width="93" height="36" align="right" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span> 神州行卡号：
                        </td>
                        <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <label>
                                <asp:TextBox ID="txtCardNum_szx" runat="server" MaxLength="17" CssClass="in_text"
                                    onkeypress="InputMask_Number()" Style="width: 160px;"></asp:TextBox>
                            </label>
                            【注意：卡号17位，请填写正确的卡号！】
                        </td>
                    </tr>
                    <tr>
                        <td width="93" height="36" align="right" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span> 神州行密码：
                        </td>
                        <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <label>
                                <asp:TextBox ID="txtCardPass_szx" runat="server" MaxLength="18" TextMode="Password"
                                    CssClass="in_text" onkeypress="InputMask_Number()" Style="width: 160px;"></asp:TextBox>
                            </label>
                            【注意：密码18位，请填写正确的密码！】
                        </td>
                    </tr>
                    <tr>
                        <td width="93" height="40" align="right" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span> 手续费率：
                        </td>
                        <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:Label ID="labFeesScale_szx" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                            &nbsp;<asp:RadioButtonList ID="rblist_szx" runat="server" RepeatDirection="Horizontal"
                                Visible="False">
                                <asp:ListItem Value="10">10 元</asp:ListItem>
                                <asp:ListItem Value="30">30 元</asp:ListItem>
                                <asp:ListItem Value="50">50 元</asp:ListItem>
                                <asp:ListItem Value="100">100 元</asp:ListItem>
                                <asp:ListItem Value="300" Selected="True">300 元</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#FFFEDF" colspan="2" class="black12" style="padding: 5px 10px 5px 10px;">
                            <span class="blue12">注意说明：</span><br />
                            1.支持10、30、50、100、300元面值的神州行充值卡支付；<br />
                            2.序列号17位、密码18位，标明能为“神州行”充值的“中国移动”发行的神州行充值卡都可以支付；<br />
                            3.面值--实充：<span class="red12">10</span>元--<span class="red12"><%=getReallityMoney(10)%></span>元、<span
                                class="red12">30</span>元--<span class="red12"><%=getReallityMoney(30)%></span>元、<span
                                    class="red12">50</span>元--<span class="red12"><%=getReallityMoney(50)%></span>元、<span
                                        class="red12">100</span>元--<span class="red12"><%=getReallityMoney(100)%></span>元、<span
                                            class="red12">300</span>元--<span class="red12"><%=getReallityMoney(300)%></span>元。<br />
                        </td>
                    </tr>
                </tbody>
                <tbody id="tb_51zfk" runat="server">
                    <tr>
                        <td width="93" height="36" align="right" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span> 支付卡卡号：
                        </td>
                        <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <label>
                                <asp:TextBox ID="txtCardNum_zfk" runat="server" MaxLength="15" CssClass="in_text"
                                    Style="width: 160px;"></asp:TextBox>
                            </label>
                            【注意：卡号15位，请填写正确的卡号！】
                        </td>
                    </tr>
                    <tr>
                        <td width="93" height="36" align="right" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span> 支付卡密码：
                        </td>
                        <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <label>
                                <asp:TextBox ID="txtCardPass_zfk" runat="server" TextMode="Password" MaxLength="10"
                                    CssClass="in_text" onchange="CheckMultiple(this);" Style="width: 160px;"></asp:TextBox>
                            </label>
                            【注意：密码10位，请填写正确的密码！】
                        </td>
                    </tr>
                    <tr>
                        <td width="93" height="40" align="right" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span> 手续费率：
                        </td>
                        <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:Label ID="labFeesScale_zfk" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                            <asp:RadioButtonList ID="rblist_zfk" runat="server" RepeatDirection="Horizontal"
                                Visible="False">
                                <asp:ListItem Value="10">10 元</asp:ListItem>
                                <asp:ListItem Value="30">30 元</asp:ListItem>
                                <asp:ListItem Value="50">50 元</asp:ListItem>
                                <asp:ListItem Value="53">53 元</asp:ListItem>
                                <asp:ListItem Value="100">100 元</asp:ListItem>
                                <asp:ListItem Value="105">105 元</asp:ListItem>
                                <asp:ListItem Value="200">200 元</asp:ListItem>
                                <asp:ListItem Value="210">210 元</asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">测试卡</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#FFFEDF" colspan="2" class="black12" style="padding: 5px 10px 5px 10px;">
                            <span class="blue12">注意说明：</span><br />
                            1.支持10、30、50、53、100、105、200、210元面值的51支付卡支付；<br />
                            2.序列号15位、密码10位，标明能为“星启天”发行的51支付卡都可以支付；<br />
                            3.面值--实充：<span class="red12">10</span>元--<span class="red12"><%=getReallityMoney(10)%></span>元、<span
                                class="red12">30</span>元--<span class="red12"><%=getReallityMoney(30)%></span>元、<span
                                    class="red12">50</span>元--<span class="red12"><%=getReallityMoney(50)%></span>元、<span
                                        class="red12">53</span>元--<span class="red12"><%=getReallityMoney(53)%></span>元、<span
                                            class="red12">100</span>元--<span class="red12"><%=getReallityMoney(100)%></span>元、<span
                                                class="red12">105</span>元--<span class="red12"><%=getReallityMoney(105)%></span>元、<span
                                                    class="red12">200</span>元--<span class="red12"><%=getReallityMoney(200)%></span>元、<span
                                                        class="red12">210</span>元--<span class="red12"><%=getReallityMoney(210)%></span>元。<br />
                        </td>
                    </tr>
                </tbody>
                <tr>
                    <td height="30" align="right" valign="top" bgcolor="#FFFFFF" class="black12">
                    </td>
                    <td height="30" align="left" valign="top" bgcolor="#FFFFFF" class="black12" style="padding: 10px 0px 10px 10px;">
                        <div style="">
                        </div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 15px;">
                            <tr>
                                <td>
                                    <asp:ImageButton ID="imgbtn_OK" runat="server" ImageUrl="../Alipay02/images/bt_wy.jpg"
                                        OnClientClick="return btn_OK();" OnClick="btnNext_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
