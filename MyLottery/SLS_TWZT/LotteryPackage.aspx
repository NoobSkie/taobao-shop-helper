<%@ page language="C#" autoeventwireup="true" CodeFile="~/LotteryPackage.aspx.cs" inherits="LotteryPackage" enableEventValidation="false" %>
<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<%@ Register Src="Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>彩票套餐购买服务-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="吉祥套餐(包月)、如意套餐(包季)、幸福套餐(半年)、安康套餐(包年)"/>
    <link href="Home/Room/Style/css.css" rel="stylesheet" type="text/css" />

    <script src="JavaScript/LotteryPackage.js" type="text/javascript"></script>
    <script src="Home/Room/JavaScript/Marquee.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="favicon.ico" />
    <style type="text/css">
        .blue24
        {
            font-size: 14px;
            color: #216699;
            font-family: "tahoma";
            line-height: 20px;
        }
        .blue24 A:link
        {
            font-family: "tahoma";
            color: #216699;
            text-decoration: none;
        }
        .blue24 A:active
        {
            font-family: "tahoma";
            color: #216699;
            text-decoration: none;
        }
        .blue24 A:visited
        {
            font-family: "tahoma";
            color: #216699;
            text-decoration: none;
        }
        .blue24 A:hover
        {
            font-family: "tahoma";
            color: #FF0065;
            text-decoration: none;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px"
        align="center">
        <tr>
            <td colspan="2">
                <img src="Home/Room/Images/222.jpg" />
            </td>
        </tr>
        <tr>
            <td width="717" valign="top" style="padding-top: 20px;">
                <table width="715" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="715" align="left">
                            <table cellspacing="0" cellpadding="0" width="720" border="0">
                                <tbody>
                                    <tr>
                                        <td width="15" height="30">
                                            &nbsp;
                                        </td>
                                        <td width="90" align="center" bgcolor="#FFFFFF" class="hui14" id="tdLottery5">
                                            <a href="javascript:;" onclick="ClickLottery(this,0)">双色球</a>
                                        </td>
                                        <td width="5">
                                            &nbsp;
                                        </td>
                                        <td width="90" align="center" bgcolor="#FFFFFF" class="hui14" id="tdLottery6">
                                            <a href="javascript:;" onclick="ClickLottery(this,1)">福彩3D</a>
                                        </td>
                                        <td width="5">
                                            &nbsp;
                                        </td>
                                        <td width="90" align="center" bgcolor="#FFFFFF" class="hui14" id="tdLottery39">
                                            <a href="javascript:;" onclick="ClickLottery(this,2)">大乐透</a>
                                        </td>
                                        <td width="5">
                                            &nbsp;
                                        </td>
                                        <td width="90" align="center" bgcolor="#FFFFFF" class="hui14" id="tdLottery63">
                                            <a href="javascript:;" onclick="ClickLottery(this,3)">排列3</a>
                                        </td>
                                        <td width="5">
                                            &nbsp;
                                        </td>
                                        <td width="90" align="center" bgcolor="#FFFFFF" class="hui14" id="tdLottery64">
                                            <a href="javascript:;" onclick="ClickLottery(this,4)">排列5</a>
                                        </td>
                                        <td width="5">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="2" colspan="20" bgcolor="#FF6600">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="700" align="left" border="0">
                                <tbody>
                                    <tr>
                                        <td width="800" height="10">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="15" align="left">
                                            <table style="margin-top: 10px" cellspacing="0" cellpadding="0" width="720" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td width="150" height="29" class="red14">
                                                            <span id="spanLotteryName"></span>套餐服务
                                                        </td>
                                                        <td width="4">
                                                            &nbsp;
                                                        </td>
                                                        <td width="120" align="center" bgcolor="#E1F1FF" class="blue24" id="tdTC1">
                                                            <a href="javascript:;" onclick="ClickTC(this,1);">吉祥套餐(包月)</a>
                                                        </td>
                                                        <td width="4">
                                                            &nbsp;
                                                        </td>
                                                        <td width="120" align="center" bgcolor="#E1F1FF" class="blue24" id="tdTC2">
                                                            <a href="javascript:;" onclick="ClickTC(this,2);">如意套餐(包季)</a>
                                                        </td>
                                                        <td width="2">
                                                            &nbsp;
                                                        </td>
                                                        <td width="120" align="center" bgcolor="#E1F1FF" class="blue24" id="tdTC3">
                                                            <a href="javascript:;" onclick="ClickTC(this,3);">幸福套餐(半年)</a>
                                                        </td>
                                                        <td width="2">
                                                            &nbsp;
                                                        </td>
                                                        <td width="120" align="center" bgcolor="#E1F1FF" class="blue24" id="tdTC4">
                                                            <a href="javascript:;" onclick="ClickTC(this,4);">安康套餐(包年)</a>
                                                        </td>
                                                        <td align="right" class="hui14_2">
                                                            &nbsp;
                                                        </td>
                                                        <td width="19">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="2" colspan="11" bgcolor="#6699CC">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="15">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <div id="CustomChaseOne" runat="server">
                                                <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="36" colspan="2" align="left" class="hui14_2">
                                                            套餐时长：约<span class="red14" id="spanMonthCount"></span>个月 投注期数：<span class="red14"
                                                                id="spanIsuseCount1"></span> 期 投注注数：每期<span class="red14" id="spanLotteryNum1"></span>注
                                                            套餐单价：<span class="red14" id="spanMoney1"></span>元
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="36" align="left" class="black12" colspan="2">
                                                            <img src="Home/Room/images/1_1.jpg" width="19" height="14" />&nbsp;&nbsp; 投注方式：
                                                            <input type="radio" name="radio" id="radioJX" value="1" checked="checked" onclick="changeBetType(this)" />
                                                            机选号码
                                                            <input type="radio" name="radio" id="radioZX" value="2" onclick="changeBetType(this)" />
                                                            自选号码 投注<span id="spanNumOrMultiple1">倍</span>数：
                                                            <select name="selectMultiple" id="selectMultiple" onchange="changeMultiple(this.value);">
                                                                <option selected="selected" value="1">1</option>
                                                                <option value="2">2</option>
                                                                <option value="5">5</option>
                                                                <option value="10">10</option>
                                                                <option value="20">20</option>
                                                            </select>
                                                            <span id="spanNumOrMultiple2">倍</span>&nbsp;&nbsp;&nbsp;&nbsp;终止条件：<span class="red12">完成方案</span>
                                                            <span style="padding-left:10px;display:none" id="spanZJ"><input type="checkbox" id="cbZJ" onclick="if(this.checked){document.getElementById('HidPlayTypeID').value='3903';}else {document.getElementById('HidPlayTypeID').value='3901';}calculateMoney();"/>是否追加</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="36" colspan="2" align="left" class="black12">
                                                            <img src="Home/Room/images/1_2.jpg" width="19" height="14" />&nbsp;&nbsp; 追号标题：<input type="text"
                                                                id="tbTitle" name="tbTitle" size="45" />&nbsp;&nbsp;选取一个好的追号标题,也会有意外的幸运收获哦！
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="36" colspan="2" align="left" class="black12">
                                                            <img src="Home/Room/images/1_3.jpg" width="19" height="14" />&nbsp;&nbsp; 选择号码：
                                                        </td>
                                                    </tr>
                                                    <tr id="trPlayTypes">
                                                        <td height="36" colspan="2" align="left" class="black12">
                                                            <iframe id="iframe_playtypes" name="iframe_playtypes" width="100%" frameborder="0"
                                                                src="Home/Room/Chase/SSQ.htm" scrolling="no" onload="document.getElementById('iframe_playtypes').style.height=iframe_playtypes.document.body.scrollHeight;">
                                                            </iframe>
                                                        </td>
                                                    </tr>
                                                    <tr id="trPlayTypes_JX">
                                                        <td height="9" colspan="2" align="left" class="black12" style="padding-left: 28px;">
                                                            <table width="525" border="0" align="left" cellpadding="0" cellspacing="0" bgcolor="#C0D0E9"
                                                                class="table">
                                                                <tr>
                                                                    <td width="152" height="29" align="left" background="Home/Room/images/by_bg_r1_c3.jpg" bgcolor="#e7f1fa"
                                                                        style="padding-left: 5px">
                                                                        <table width="168" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="84" height="29" align="center" valign="bottom" id="tdXYXH">
                                                                                    <table width="78%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="25" align="center">
                                                                                                <span class="blue14_2"><a href="javascript:;" id="hrefXYXH" class="bai12" onclick="return ClickSJXH(this,2)">
                                                                                                    幸运选号</a></span>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td width="84" align="center" valign="bottom" height="29" id="tdSJXH">
                                                                                    <table width="89%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="25" align="center">
                                                                                                <span class="blue14_2"><a href="javascript:;" id="hrefSJXH" class="bai12" onclick="return ClickSJXH(this,1)">
                                                                                                    随机选号</a></span>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trXYXH" style="display: none">
                                                                    <td height="81" bgcolor="#ffffff">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" background="Home/Room/images/ssq_qh_bg.jpg"
                                                                            border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td width="6" height="29">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td class="blue12" align="middle" width="40" background="Home/Room/images/ssq_qh_1.jpg">
                                                                                        <a href="javascript:;" id="hrefXZ" onclick="return ClickXYJX(this,1)">星座</a>
                                                                                    </td>
                                                                                    <td width="4">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td class="blue12" align="middle" width="40">
                                                                                        <a href="javascript:;" id="hrefSX" onclick="return ClickXYJX(this,2)">生肖</a>
                                                                                    </td>
                                                                                    <td width="4">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td class="blue12" align="middle" width="70">
                                                                                        <a href="javascript:;" id="hrefCSRQ" onclick="return ClickXYJX(this,3)">出生日期</a>
                                                                                    </td>
                                                                                    <td width="4">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td class="blue12" align="middle" width="40">
                                                                                        <a href="javascript:;" id="hrefXM" onclick="return ClickXYJX(this,4)">姓名</a>
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table style="background-position: center bottom; background-image: url(Home/Room/images/ssq_bg_di.jpg);
                                                                            background-repeat: repeat-x" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td height="50" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
                                                                                        padding-top: 5px">
                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td width="20%" height="30" valign="bottom">
                                                                                                        <span id="spanXZ">
                                                                                                            <asp:DropDownList ID="ddlXiZuo" runat="server">
                                                                                                                <asp:ListItem Value="1">白羊座</asp:ListItem>
                                                                                                                <asp:ListItem Value="2">金牛座</asp:ListItem>
                                                                                                                <asp:ListItem Value="3">双子座</asp:ListItem>
                                                                                                                <asp:ListItem Value="4">巨蟹座</asp:ListItem>
                                                                                                                <asp:ListItem Value="5">狮子座</asp:ListItem>
                                                                                                                <asp:ListItem Value="6">处女座</asp:ListItem>
                                                                                                                <asp:ListItem Value="7">天秤座</asp:ListItem>
                                                                                                                <asp:ListItem Value="8">天蝎座</asp:ListItem>
                                                                                                                <asp:ListItem Value="9">射手座</asp:ListItem>
                                                                                                                <asp:ListItem Value="10">摩羯座</asp:ListItem>
                                                                                                                <asp:ListItem Value="11">水瓶座</asp:ListItem>
                                                                                                                <asp:ListItem Value="12">双鱼座</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </span><span id="spanSX" style="display: none">
                                                                                                            <asp:DropDownList ID="ddlSX" runat="server">
                                                                                                                <asp:ListItem Value="1">鼠</asp:ListItem>
                                                                                                                <asp:ListItem Value="2">牛</asp:ListItem>
                                                                                                                <asp:ListItem Value="3">虎</asp:ListItem>
                                                                                                                <asp:ListItem Value="4">兔</asp:ListItem>
                                                                                                                <asp:ListItem Value="5">龙</asp:ListItem>
                                                                                                                <asp:ListItem Value="6">蛇</asp:ListItem>
                                                                                                                <asp:ListItem Value="7">马</asp:ListItem>
                                                                                                                <asp:ListItem Value="8">羊</asp:ListItem>
                                                                                                                <asp:ListItem Value="9">猴</asp:ListItem>
                                                                                                                <asp:ListItem Value="10">鸡</asp:ListItem>
                                                                                                                <asp:ListItem Value="11">狗</asp:ListItem>
                                                                                                                <asp:ListItem Value="12">猪</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </span><span id="spanCSRQ" style="display: none">
                                                                                                            <asp:TextBox ID="tbDate" runat="server" Width="80" CssClass="hui12" ToolTip="格式：1980-01-01"
                                                                                                                Text="1980-01-01" onfocus="this.className='';this.value='';" onblur="if(this.value==''){this.className='hui12'; this.value='1980-01-01';}"></asp:TextBox>
                                                                                                        </span><span id="spanXM" style="display: none">
                                                                                                            <asp:TextBox ID="tbName" runat="server" Width="80" CssClass="hui12" ToolTip="支持中英文"
                                                                                                                Text="支持中英文" onfocus="if(this.value=='支持中英文') {this.className='';this.value='';}"
                                                                                                                onblur="if(this.value=='') {this.className='hui12';this.value='支持中英文';}"></asp:TextBox>
                                                                                                        </span>
                                                                                                    </td>
                                                                                                    <td width="24%" style="padding-top:10px">
                                                                                                        <img src="Home/Room/images/ssq_bt_1.jpg" width="100" height="21" alt="" border="0" style="cursor: pointer"
                                                                                                            onclick="return GetLuckNumber()" />
                                                                                                    </td>
                                                                                                    <td width="56%" valign="middle" id="tdLuckNumber">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trSJXH" style="display: none">
                                                                    <td height="50" bgcolor="#ffffff">
                                                                        <table style="background-position: center bottom; background-image: url(Home/Room/images/ssq_bg_di.jpg);
                                                                            background-repeat: repeat-x;" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td width="11%" height="50" align="center" class="blue12" style="padding-right: 10px;
                                                                                        padding-left: 10px; padding-bottom: 10px; padding-top: 5px">
                                                                                        <img src="Home/Room/images/1.gif" width="18" height="16" />
                                                                                    </td>
                                                                                    <td width="89%" class="blue12" style="padding-right: 10px; padding-left: 0px; padding-bottom: 3px;
                                                                                        padding-top: 3px; text-indent: 24px;">
                                                                                        <span class="black12" style="padding-top: 0px;">选择随机选号购买追号套餐时，系统将自动为您在指定追号期间内，每期随机选出一或者多注号码进行投注。
                                                                                        </span>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="36" align="left" colspan="2" class="black12">
                                                            <span class="red12_2"><strong>注：</strong></span> 您的追号套餐详情记录可在<span class="red12_2">用户中心
                                                                → 我的彩票记录 → 我的追号 → 我的套餐</span>中查询追号状态
                                                        </td>
                                                    </tr>
                                                    <tr id="trPlayTypes1">
                                                    <td height="40" colspan="2" align="center" class="black12"><img src="Home/Room/images/zfb_bt_queren.jpg" width="110" height="28" id="btn_2_Add" style="cursor:pointer" onclick="if(this.disabled){this.style.cursor='';return false;}return iframe_playtypes.btn_2_AddClick();"/></td>
                                                    </tr>
                                                    <tr id="trPlayTypes2">
                                        <td  width="460px" valign="top" style="padding-left:28px" align="left">
                                            <select  name="list_LotteryNumber" multiple="multiple" id="list_LotteryNumber"
                                                style="width: 550px; height: 150px;">
                                            </select>
                                        </td>
                                        <td width="134" style="padding-left: 10px;padding-bottom:10px">
                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="30">
                                                        <input id="btn_2_Rand" name="btn_2_Rand" type="button" value="机选1注" onclick="if(this.disabled){this.style.cursor='';return false;}return iframe_playtypes.btn_2_RandClick();"
                                                            style="cursor: pointer; width: 80px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                        <input id="btn_2_Rand5" name="btn_2_Rand5" type="button" value="机选5注" onclick="if(this.disabled){this.style.cursor='';return false;}return iframe_playtypes.btn_2_RandManyClick(5);"
                                                            style="cursor: pointer; width: 80px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                        <input id="btnPaste" name="btnPaste" type="button" value="粘贴上传" onclick="CreateUplaodDialog();"
                                                            style="cursor: pointer; width: 80px;" />
                                                        <span id="spanJX" style="display: none">
                                                            <input id="tbJXNumbers" type="text" value="5" maxlength="3" style="width: 22px" onkeypress="return InputMask_Number();" />注<input
                                                                id="btn_2_Randn" style="color: Blue" name="btn_2_Randn" type="button" value="机选"
                                                                onclick="if(this.disabled){this.style.cursor='';return false;}if(StrToInt(tbJXNumbers.value)<1) {alert('请输入注数！'); tbJXNumbers.focus();return false;}else{return iframe_playtypes.btn_2_RandManyClick(StrToInt(tbJXNumbers.value));}"
                                                                style="cursor: pointer; width: 40px;" class="red2" /></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                        <input type="button" name="btn_ClearSelect" id="btn_ClearSelect" value="删除选择" style="cursor: pointer;
                                                            width: 80px;" onclick="return btn_ClearSelectClick();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                        <input type="button" name="btn_Clear" id="btn_Clear" value="清空全部" style="cursor: pointer;
                                                            width: 80px;" onclick="return btn_ClearClick();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <a href="javascript:;" onclick="return btnNext_OK()">
                                                                <img src="Home/Room/images/bt_xiayibu.jpg" width="91" height="28" border="0" alt="" /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="CustomChaseTwo" runat="server" style="display: none">
                                                <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="36" align="left" class="hui14_2">
                                                            <p>
                                                                您购买的是：<span id="spanChaseType"></span></p>
                                                            <p>
                                                                追号标题是：<input type="text" id="tbTitle1" name="tbTitle1" size="50" /></p>
                                                            <p>
                                                                您设定的具体内容是：每期<span id="spanBetType"></span><span class="red14" id="spanLotteryNum2">1</span>注、投注期为<span
                                                                    class="red14" id="spanIsuseCount2"></span>期、每期投注倍数为<span class="red14" id="spanMultiple">1</span>倍、截止条件为<span
                                                                        class="red14">完成方案</span></p>
                                                            <p>
                                                                合计金额：<span class="red14" id="spanMoney2"></span>元
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20" align="left" class="hui14_2">
                                                            <div id="hr">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div id="NoLogin" runat="server">
                                                    <iframe id="iframe_Login" name="iframe_Login" width="100%" frameborder="0" scrolling="no"
                                                        height="240px"></iframe>
                                                </div>
                                                <div id="Login" runat="server">
                                                    <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="54" align="left" class="hui12" style="padding-left: 36px;" width="20%">
                                                                <asp:ImageButton ID="btnOK" runat="server" ImageUrl="Home/Room/images/bt_tijiao.jpg" Width="120px"
                                                                    Height="32px" OnClick="btnOK_Click"  />
                                                            </td>
                                                            <td class="hui12" style="padding-left: 10px" align="left" width="80%">
                                                                <a href="javascript:;" style="text-decoration: underline;" onclick="document.getElementById('CustomChaseOne').style.display='';document.getElementById('CustomChaseTwo').style.display='none';">
                                                                    返回修改套餐</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="285" align="right" valign="top" style="padding-top: 20px;">
                <table width="260" border="0" align="right" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                    <tr>
                        <td height="34" align="left" bgcolor="#6699CC" class="bai12" style="padding-left: 10px;">
                            <strong>追号套餐小喇叭</strong>
                        </td>
                    </tr>
                    <tr>
                        <td height="302" valign="top" bgcolor="#FFFFFF" style="padding-top: 3px; padding-bottom: 5px;">
                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td width="23%" height="30" align="center" bgcolor="#e1f1ff" class="blue12">
                                        会员名
                                    </td>
                                    <td width="25%" height="30" align="center" bgcolor="#e1f1ff" class="blue12">
                                        彩种
                                    </td>
                                    <td width="24%" height="30" align="center" bgcolor="#e1f1ff" class="blue12">
                                        套餐类型
                                    </td>
                                    <td width="28%" align="center" bgcolor="#e1f1ff" class="blue12">
                                        套餐金额
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center" valign="top" id="tdUsers" runat="server">
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
    <asp:HiddenField ID="HidLotteryID" runat="server" Value="5" />
    <asp:HiddenField ID="HidType" runat="server" Value="4" />
    <asp:HiddenField ID="HidLotteryNumber" runat="server" />
    <asp:HiddenField ID="HidIsuseCount" runat="server" Value="168" />
    <asp:HiddenField ID="HidNums" runat="server" Value="0" />
    <asp:HiddenField ID="HidMultiple" runat="server" Value="1" />
    <asp:HiddenField ID="HidBetType" runat="server" Value="2" />
    <asp:HiddenField ID="HidMoney" runat="server" />
    <asp:HiddenField ID="HidPlayTypeID" runat="server"  Value="501"/>
    <asp:HiddenField ID="HidXYXHType" runat="server" Value="1" />
    </form>
</body>
</html>
<script type="text/javascript">
    function document.onreadystatechange()
        {
            if (document.readyState=="complete") {
                init();
               document.getElementById('tdLottery'+document.getElementById("HidLotteryID").value).children(0).click();
               document.getElementById('tdTC' + document.getElementById("HidType").value).children(0).click();
               
               document.getElementById("hrefXYXH").click();
                <%=script %>
                var up = new scrolls("scrollWinUsers","up");
                up.addNodes();
                up.scrollPro();
            }
        }
</script>