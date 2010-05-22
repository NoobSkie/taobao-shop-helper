<%@ page language="C#" autoeventwireup="true" CodeFile="~/Lottery/Buy_SFC_9_D.aspx.cs" inherits="Lottery_Buy_SFC_9_D" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../Home/Room/UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>任九场：看足球买彩票，2元可中￥500万！-任九场选号投注、合买、玩法介绍－<%=_Site.Name %></title>
    <meta name="keywords" content="任九场选号投注、任九场合买、任九场玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供任九场选号投注、合买、玩法介绍等服务。" />
    
    <link href="../Home/Room/style/css.css" rel="stylesheet" type="text/css" />
    <link href="../Home/Room/Buy_ZC.css" rel="stylesheet" type="text/css" />

    <script src="../Home/Room/JavaScript/Public.js" type="text/javascript"></script>

    <script src="../Home/Room/JavaScript/Buy_SFC_9_D.js" type="text/javascript"></script>

    <script type="text/javascript" src="../Home/Room/JavaScript/ExplorerCheck.js"></script>
     <link rel="shortcut icon" href="../favicon.ico" />

</head>
<body onload="showSameHeight();">
    <form id="form1" runat="server">
    <input id="tbPlayTypeID" name="tbPlayTypeID" type="hidden" />
    <asp:HiddenField ID="HidIsuseEndTime" runat="server" />
    <asp:HiddenField ID="HidIsuseID" runat="server" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
            <div id="cz_center">
                <div style="margin-bottom: 10px;">
                    
                        <img src="../Home/Room/Images/cz_banner_zc.gif" border="0" /></div>
                <!-- 期信息开始 -->
                <div style="border: #C0DBF9 1px solid; background-image: url(../Home/Room/Images/bg_hui.jpg);
                    background-repeat: repeat-x; background-position: top; background-color: #F9FDFF;
                    margin-bottom: 5px; height: 100%; overflow: hidden;">
                    <div style="float: left; width: 19%; text-align: center;">
                        <img id="LotteryImg" src="../Home/Room/Images/logo_1.jpg" alt="任九场" width="105"
                            height="108" />
                    </div>
                    <div style="float: left; width: 81%; margin-top: 0px;">
                        <div id="lastIsuseInfo" style="line-height: 25px;">
                            <img src='../Home/Room/Images/londing.gif' style="position: relative; left: 25%;" alt="" />
                        </div>
                        <div id="tdLotteryIntroduce" class="hui12" style="padding: 0px 0px 2px 0px;">
                            <h1 class='blue18' style="display:inline; ">任九场：看足球买彩票，2元可中￥500万！ </h1> 
                        </div>
                        <div class="black12" style="width: 100%; height: 24px; line-height: 24px;">
                            第<span id='currIsuseName' class='red12' style='font-weight: bold;'></span>期投注截止时间:&nbsp;<span
                                id="currIsuseEndTime" class="black12"></span>离投注截止还有:<span id='toCurrIsuseEndTime'
                                    style='background-color: Black; font-weight: bold; color: #00FF00; padding: 2px;
                                    font-size: 13px; font-family: 宋体; text-align: center; border-right: 1px solid red;'></span>
                            &nbsp;&nbsp;<span id="testNumber"></span>
                        </div>
                        <div class="red12" style="width: 100%; height: 24px; line-height: 24px;">
                            <a href="<%= ResolveUrl("~/TrendCharts/SSQ/SSQ_CGXMB.aspx") %>" target="_blank">任九场走势图</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="<%= ResolveUrl("~/WinQuery/1-0-0.aspx") %>" target="_blank">任九场中奖查询</a>
                        </div>
                    </div>
                </div>
                <!-- 期信息结束 -->
                <!-- 选项卡开始 -->
                <div id="TabMenu" style="margin-top: 15px; border-bottom: #FF6600 2px solid; text-align: center;
                    padding-bottom: 0px; width: 100%;">
                    <div style="float: left; width: 10px;">
                    </div>
                    <div class="redMenu" onclick="newBuy(<%=LotteryID %>,<%=Number %>);showSameHeight();">
                        选号投注
                    </div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu" onclick="newCoBuy(<%=LotteryID %>,<%=Number %>);showSameHeight();">
                        参与合买</div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu" onclick="followScheme(<%=LotteryID %>,<%=Number %>);showSameHeight();">
                        定制跟单</div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu" onclick="schemeAll(<%=LotteryID %>,<%=Number %>);showSameHeight();">
                        全部方案</div>
                    <div style="float: left; width: 2px;">
                    </div>
                </div>
                <!-- 选项卡结束 -->
                <div id="divNewBuy">
                    <table width="612" cellspacing="1" cellpadding="0" bgcolor="#C0DBF9" style="margin-top: 10px;">
                        <tbody>
                          <tr ><td width='70' height='28' align='center' bgcolor='#F7F7F7' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>
                            <input type='radio' name='playType' id='playType103' value='103'  onclick='clickPlayType(this.value)' />任九场单式
                            <input type='radio' name='playType' id='playType104' value='104' onclick='clickPlayType(this.value)' />任九场复式
                            <input type='radio' name='playType' id='playType1033' value='1033'  onclick='clickPlayType(this.value)' />任九场单式预投
                            <input type='radio' name='playType' id='playType1044' value='1044' onclick='clickPlayType(this.value)' />任九场复式预投
</td></tr>
                        </tbody>
                        <tr id="trXH">
                            <td height="30" align="center" bgcolor="#F7FCFF" class="black12">
                                选号
                            </td>
                            <td valign="top" bgcolor="#FFFFFF">
                                <iframe id="iframe_playtypes" name="iframe_playtypes" width="100%" frameborder="0"
                                    scrolling="no" onload="document.getElementById('iframe_playtypes').style.height=iframe_playtypes.document.body.scrollHeight;showSameHeight();">
                                </iframe>
                            </td>
                        </tr>
                        <tr id="trTZNR">
                            <td align="center" bgcolor="#ECF9FF" class="black12">
                                投注内容
                            </td>
                            <td valign="top" bgcolor="#FFFFFF">
                                <table width="95%" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                                    <tr>
                                        <td width="426" valign="top">
                                            <select size="8" name="list_LotteryNumber" multiple="multiple" id="list_LotteryNumber"
                                                style="width: 100%; height: 150px;">
                                            </select>
                                        </td>
                                        <td width="134" style="padding-left: 10px;">
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
                                </table>
                                <table width="95%" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
                                    style="margin-top: 10px; margin-bottom: 10px;">
                                    <tr>
                                        <td height="30" bgcolor="#F9F9F9" class="hui12" style="padding-left: 8px;">
                                            <table cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        您选择了 <span class="red12" id="lab_Num">0</span> 注，倍数：
                                                    </td>
                                                    <td>
                                                        <input type="text" onkeypress="return InputMask_Number();" id="tb_Multiple" name="tb_Multiple"
                                                            onblur="CheckMultiple();" value="1" maxlength="3" style="width: 30px;" />
                                                    </td>
                                                    <td>
                                                        &nbsp;总金额 <span class="red12" id="lab_SumMoney">0.00</span> 元。<span class="red12">【注】</span>投注倍数最高为
                                                        999 倍。
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="center" bgcolor="#FEDEDE" class="black12">
                                合买代购
                            </td>
                            <td bgcolor="#FEECEC" class="red12" style="padding-left: 5px;">
                                <div id="DivBuy" style="float: left;">
                                    <input id="CoBuy" name="CoBuy" type="checkbox" onclick="oncbInitiateTypeClick();"
                                        value="2" />我要发起合买方案 <span style="margin-left: 50px;"></span>
                                </div>
                            </td>
                        </tr>
                        <tbody id="trShowJion" style="display: none; line-height: 2; height: 36px; background-color: #FFEEEE;
                            text-align: center; padding-left: 10px; padding-right: 10px;">
                            <tr id="trSchemeMoney">
                                <td>
                                    方案金额
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_SchemeMoney" name="tb_SchemeMoney"
                                        onblur="return checkSchemeMoney(this);" style="width: 56px;" value="2" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;只能是2的倍数。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    佣金比率
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_SchemeBonusScale"
                                        name="tb_SchemeBonusScale" onblur="return SchemeBonusScale();" style="width: 56px;"
                                        maxlength="10" />% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;佣金比例只能为0~10。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    我要分成
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_Share" name="tb_Share"
                                        onblur="return CheckShare();" style="width: 56px;" maxlength="10" value="1" />份，每份
                                    <span id="lab_ShareMoney" style="color: Red">0.00</span>&nbsp;元。&nbsp;&nbsp; <font
                                        color="#ff0000">【注】</font>份数不能为空，且能整除总金额。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    我要认购
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_BuyShare" name="tb_BuyShare"
                                        onblur="return CheckBuyShare();" style="width: 56px;" value="1" />份，金额 <span id="lab_BuyMoney"
                                            style="color: Red">0.00</span>&nbsp;元。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    我要保底
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_AssureShare" name="tb_AssureShare"
                                        onblur="return CheckAssureShare();" style="width: 56px;" value="0">份，保底 <span id="lab_AssureMoney"
                                            style="color: Red">0.00</span>&nbsp;元。&nbsp; <font color="#ff0000">【注】</font>保底资金将被暂时冻结,在当期截止销售时、或根据此方案的销售、撤单情况,冻结资金将返还到您的电话投注卡账户中。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    招股对象
                                </td>
                                <td align="left">
                                    <input type="text" id="tb_OpenUserList" name="tb_OpenUserList" style="width: 99%;"
                                        maxlength="4000" /><br />
                                    <font color="#ff0000">【注】</font>您可以选择一些用户作为招股对象，用户名之间用 , 隔开。<br />
                                    如：icaile,中个500万,双色球高手,...填写错误的用户名、格式不正确、或者没有填写则表示向全部会员招股。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    方案标题
                                </td>
                                <td align="left">
                                    <input type="text" id="tb_Title" name="tb_Title" style="width: 99%;" maxlength="50" /><font
                                        color="#ff0000">【注】</font>标题不能为空,长度不能超过 <font color="#ff0000">50</font> 个字符。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    方案描述
                                </td>
                                <td align="left" style="padding: 10px;">
                                    <textarea id="tb_Description" name="tb_Description" style="width: 99%; height: 100px;"></textarea>
                                </td>
                            </tr>
                        </tbody>
                        <tr>
                            <td height="30" align="center" bgcolor="#F7FCFF" class="black12">
                                方案保密
                            </td>
                            <td valign="middle" bgcolor="#FFFFFF" style="padding-left: 5px;">
                                <input type="radio" name="SecrecyLevel" id="SecrecyLevel0" value="0" checked="checked" />
                                <span>不保密</span>
                                <input type="radio" name="SecrecyLevel" id="SecrecyLevel1" value="1" />
                                <span>保密到截止</span>
                                <input type="radio" name="SecrecyLevel" id="SecrecyLevel2" value="2" />
                                <span>保密到开奖</span>
                                <input type="radio" name="SecrecyLevel" id="SecrecyLevel3" value="3" />
                                <span>永久保密</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" colspan="2" bgcolor="#F7F7F7" align="center" style="padding-bottom: 20px;
                                padding-top: 20px">
                                <ShoveWebUI:ShoveConfirmButton ID="btn_OK" Style="cursor: pointer;" runat="server"
                                    Width="170px" Height="32px" CausesValidation="False" BackgroupImage="../Home/Room/Images/zfb_bt_touzhu.jpg"
                                    BorderStyle="None" OnClientClick="return CreateLogin('btn_OKClick();');" OnClick="btn_OK_Click" />
                                <asp:CheckBox ID="chkAgrrement" runat="server" Checked="true" />
                                我已经阅读并同意 <span class="blue12">
                                    <asp:HyperLink runat="server" ID="hlAgreement" Target="_blank">《用户电话短信投注协议》</asp:HyperLink></span>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divCoBuy" style="display: none;">
                    <iframe id="iframeCoBuy" name="iframeCoBuy" width="100%" frameborder="0" scrolling="no"
                        onload="document.getElementById('iframeCoBuy').style.height=iframeCoBuy.document.body.scrollHeight;showSameHeight();">
                    </iframe>
                </div>
                <div id="divFollowScheme" style="display: none;">
                    <iframe id="iframeFollowScheme" name="iframeFollowScheme" width="100%" frameborder="0"
                        scrolling="no" onload="document.getElementById('iframeFollowScheme').style.height=iframeFollowScheme.document.body.scrollHeight;showSameHeight();">
                    </iframe>
                </div>
                <div id="divSchemeAll" style="display: none;">
                    <div id="divLoding" style="line-height: 35px; height: 100%; overflow: hidden;">
                        <img src='../Home/Room/images/londing.gif' style="position: relative; top: 10%; left: 40%;" alt="" />
                    </div>
                    <iframe id="iframeSchemeAll" name="iframeSchemeAll" width="100%" frameborder="0"
                        scrolling="no" onload="$Id('iframeSchemeAll').style.display ='';document.getElementById('divLoding').style.display='none';document.getElementById('iframeSchemeAll').style.height=iframeSchemeAll.document.body.scrollHeight;showSameHeight();">
                    </iframe>
                </div>
            </div>
            <div id="cz_right">
                <!-- 足彩专家栏 开始-->
                <div style="width: 218px; background-image: url(../Home/Room/Images/title_bg_blue.jpg); border: solid 1px #BCD2E9;">
                    <div style="float: left; width: 140px; line-height: 28px; padding-left: 15px;" class="blue12_1">
                        <strong>足彩专家栏</strong>
                    </div>
                    <div style="float: left; width: 60px; margin-top: 7px; text-align: right;" class="hui12">
                        <span style="cursor: pointer" onclick="BindZCExpertList(0);">
                            <img src='../Home/Room/Images/page_first.gif' width='9' alt="" height='8' /></span> <span style="cursor: pointer"
                                onclick="BindZCExpertList(1);">
                                <img src='../Home/Room/Images/page_previous.gif' width='9' height='8' alt="" /></span><span style="padding-left: 10px;
                                    cursor: pointer" onclick="BindZCExpertList(2);"><img src='../Home/Room/Images/page_next.gif' width='9'
                                        alt="" height='8' /></span> <span style="cursor: pointer" onclick="BindZCExpertList(3);">
                                            <img src='../Home/Room/Images/page_last.gif' width='9' alt="" height='8' /></span>
                    </div>
                </div>
                <div id="ExpertList" style="width: 210px; border: solid 1px #BCD2E9; border-top: none;
                    text-align: center; height: 100%; overflow: hidden; margin-bottom: 10px; padding: 4px;">
                    <br />
                    <img src='../Home/Room/Images/londing.gif' alt="" />
                    <br />
                    <br />
                    <br />
                </div>
                <!-- 足彩专家栏 结束-->
                <!-- 资讯开始-->
                <div id="divCaiyouZiXun" style="width: 218px; background-color: #E7F1FA; border: solid 1px #BCD2E9;">
                    <div style="float: left; width: 120px; line-height: 28px; padding-left: 15px;" class="blue12_1">
                        <strong>足彩资讯</strong>
                    </div>
                 
                </div>
                <div id="tbNews" style="width: 218px; border: solid 1px #BCD2E9; border-top: none;
                    height: 100%; overflow: hidden; margin-bottom: 10px;">
                    <br />
                    <img src='../Home/Room/Images/londing.gif' style="position: relative; left: 15%;" alt="" />
                    <br />
                    <br />
                    <br />
                </div>
           
                <!-- 资讯结束-->
              
                <!--合买热单推荐 开始-->
                <div style="width: 218px; background-color: #6699CC; border: solid 1px #BCD2E9;">
                    <div style="float: left; width: 120px; line-height: 28px; padding-left: 15px;" class="white14">
                        <strong>合买热单推荐</strong>
                    </div>
                    <div style="float: right; width: 60px; line-height: 28px; text-align: right;" class="hui12">
                        <a href="javascript:;"  onclick="newCoBuy(<%=LotteryID %>,<%=Number %>);showSameHeight();">更多&gt;&gt;</a>
                    </div>
                </div>
                <div style="width: 218px; border: solid 1px #BCD2E9; border-top: none; margin-bottom: 10px;
                    overflow: hidden;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" background="../Home/Room/Images/ssq_qh_bg.jpg">
                        <tr>
                            <td width="4" height="29">
                                &nbsp;
                            </td>
                            <td width="63" align="center" background="../Home/Room/Images/ZC50.jpg" class="blue12">
                                <a href="javascript:;" id="hrefSFC" onclick="return ClickHMTJ(this)">任九场</a>
                            </td>
                            <td width="1">
                                &nbsp;
                            </td>
                            <td width="63" align="center" class="blue12">
                                <a href="javascript:;" id="hrefRJC" onclick="return ClickHMTJ(this)">任九场</a>
                            </td>
                            <td width="1">
                                &nbsp;
                            </td>
                            <td width="63" align="center" class="blue12">
                                <a href="javascript:;" id="hrefJQC" onclick="return ClickHMTJ(this)">进球彩</a>
                            </td>
                            <td width="4">
                                &nbsp;
                            </td>
                            <td width="65" align="center" class="blue12">
                                <a href="javascript:;" id="hrefLCJQC" onclick="return ClickHMTJ(this)">六场进球</a>
                            </td>
                            <td width="1">
                                &nbsp;
                            </td>
                        </tr>
                        <%--   <tr>
                            <td colspan="10" runat="server" id="tdLuckNumber">
                            </td>
                                    </tr>--%>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-repeat: repeat-x;
                        background-position: center bottom;">
                        <tr>
                            <td style="padding: 4px;">
                                 <table cellspacing="1" cellpadding="0" style="text-align: center; margin: 1%;" width="98%">
                        <tr>
                         
                            <td width='31%' bgcolor='#D2E3FF' height='25'>
                                用户名
                            </td>
                            <td width='20%' bgcolor='#D2E3FF'>
                                金额
                            </td>
                            <td width='13%' bgcolor='#D2E3FF'>
                                进度
                            </td>
                            <td width='13%' bgcolor='#D2E3FF'>
                                合买
                            </td>
                        </tr>
                        <tbody id="tbSFC" runat="server">
                        </tbody>
                        <tbody id="tbRJC" runat="server" style="display:none">
                        </tbody>
                        <tbody id="tbJQC" runat="server" style="display:none">
                        </tbody>
                        <tbody id="tbLCJQC" runat="server" style="display:none">
                        </tbody>
                    </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--合买热单推荐 结束-->
                <div style="margin-top: 10px; margin-bottom: 10px;">
                    
                        <img src="../Home/Room/Images/ad_250_80.gif" width="220" height="80" alt="时时乐代购/合买" border="0" />
                </div>
                 <!-- 中奖排行榜 开始-->
                <div style="width: 218px; background-color: #E7F1FA; border: solid 1px #BCD2E9; overflow: hidden;">
                    <div style="width: 100%; line-height: 28px; float: left;padding-left: 15px;" class="blue12_1">
                        <strong>中奖排行榜</strong>
                    </div>
                   
                </div>
                <div style="width: 210px; border: solid 1px #BCD2E9; border-top: none; height: 100%;
                    overflow: hidden; margin-bottom: 10px; padding: 4px;">
                    <table cellspacing="1" cellpadding="0" style="text-align: center; margin: 1%;" width="98%">
                        <tbody id="tbWin1" runat="server">
                        </tbody>
                     
                    </table>
                </div>
                <!-- 中奖排行榜 结束-->
            </div>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    <input id="tb_LotteryNumber" name="tb_LotteryNumber" type="hidden" />
    <input id="tb_hide_SumMoney" name="tb_hide_SumMoney" type="hidden" />
    <input id="tb_hide_AssureMoney" name="tb_hide_AssureMoney" type="hidden" />
    <input id="tb_hide_SumNum" name="tb_hide_SumNum" type="hidden" />
    <input id="HidMaxTimes" name="HidMaxTimes" type="hidden" value="1000" />
    <input id="HidLotteryID" name="HidLotteryID" type="hidden" value="<%=LotteryID %>" />
    <input id="tbAddone" name="tbAddone" type="hidden" runat="server" />
    <input id="tbPlayTypeName" name="tbPlayTypeName" type="hidden" value="单式" />
    <input id="HidSelectedLotteryNumber" name="HidSelectedLotteryNumber" type="hidden" />
    <asp:HiddenField ID="HidType" runat="server" Value="1" />
    <asp:HiddenField ID="HidLuckNumber" runat="server" />
    </form>
    <!--#includefile="../Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript">

    checkExplorerAndTip();

    setTimeout("Page_load(<%= LotteryID %>, <%= Number %>);",500);
    
    <%=DZ %>
    
</script>

<%=script %>
