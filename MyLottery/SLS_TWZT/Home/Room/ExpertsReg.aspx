<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ExpertsReg.aspx.cs" inherits="Home_Room_ExpertsReg" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=_Site.Name %>中专家申请-我的资料-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link href="Style/div.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function clickTabMenu1(obj, backgroundImage, id) {
            var tabMenu = obj.offsetParent.cells;
            var tabId = document.getElementById(id);
            for (var i = 0; i < tabMenu.length; i++) {
                if (obj == tabMenu[i]) {
                    obj.style.backgroundImage = backgroundImage;
                    tabId.style.display = "";
                }
                else {
                    tabMenu[i].style.backgroundImage = "";
                    tabId.style.display = "none";
                }
            }
        }
        function ShowOrHiddenDiv1(id) {
            switch (id) {
                case 'ZC':
                    ZC.style.display = "block";
                    FC.style.display = "none";
                    document.getElementById("hdCurDiv").value = "ZC";
                    break;
                case 'FC':
                    FC.style.display = "block";
                    ZC.style.display = "none";
                    document.getElementById("hdCurDiv").value = "FC";
                    break;
                default:
                    ZC.style.display = "block";
                    FC.style.display = "none";
                    document.getElementById("hdCurDiv").value = "ZC";
                    break;
            }
        }
        function mOver1(obj, type) {
            if (type == 1) {
                obj.style.textDecoration = "underline";
                obj.style.color = "#FF0065";
            }
            else {
                obj.style.textDecoration = "none";
                obj.style.color = "#226699";


            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            font-size: 12px;
            color: #000000;
            font-family: tahoma;
            line-height: 18px;
            height: 63px;
        }
    </style>
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    
    
       
     <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 10px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
    
    <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
        <tr>
            <td width="40" height="30" align="right" valign="middle" class="red14">
                <img src="images/user_icon_man.gif" width="19" height="16" />
            </td>
            <td valign="middle" class="red14" style="padding-left: 10px;">
                我的资料
            </td>
        </tr>
    </table>
    <table width="842" border="0"  cellspacing="0" cellpadding="0" style="margin-top: 10px;" id="LotteryList">
        <tr>
            <td width="130" height="29">
               <table width="842" border="0" cellspacing="0" cellpadding="0" background="images/zfb_left_bg_2.jpg">
        <tr>
           
            <td id="tdZC"  width="100" height="29" align="center" background="images/admin_qh_100_2.jpg"
                 onclick="clickTabMenu1(this,'url(images/admin_qh_100_1.jpg)','ZC');ShowOrHiddenDiv1('ZC');"
                style="cursor: pointer;" class="blue12" onmouseover="mOver1(this,1)" onmouseout="mOver1(this,2)">
                足彩专家申请
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td width="100" id="tdFC" height="29" align="center" background="images/admin_qh_100_2.jpg"
                onclick="clickTabMenu1(this,'url(images/admin_qh_100_1.jpg)','FC');ShowOrHiddenDiv1('FC');"
                style="cursor: pointer;" class="blue12" onmouseover="mOver1(this,1)" onmouseout="mOver1(this,2)">
                福彩专家申请
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
            </td>
        </tr>
        <tr>
            <td height="1"  bgcolor="#FFFFFF">
            </td>
        </tr>
        <tr>
            <td height="2"  bgcolor="#6699CC">
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" style="margin-top:10px;" cellspacing="0" bgcolor="#C0DBF9">
        <tr>
            <td width="100%" height="30" align="center" bgcolor="#FFFFFF" class="black12">
            
        <div>
                                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA" >
                                    <tr>
                                        <td height="30" align="right" bgcolor="f7f7f7" class="black12" style="width:100px;">
                                            选择彩种：
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 15px;">
                                            <div id="ZC" style="display:none;">
                                            <asp:CheckBoxList ID="cblLotteryListZC"  runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow" CssClass="black12">
                                            </asp:CheckBoxList>
                                            </div>
                                            <div id="FC" style="display:none" class="black12">
                                            <asp:CheckBoxList ID="cblLotteryListFC"  runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                            </asp:CheckBoxList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" bgcolor="f7f7f7" class="style1">
                                            专家简介：<br />
                                            (300字以内)
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="style1" 
                                            style="padding: 8px 15px 8px 15px;">
                                            <label>
                                                <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Rows="10" MaxLength="300"
                                                    Width="700"></asp:TextBox>
                                            </label>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="10">
                                    <tr>
                                        <td align="center" class="black12">
                                            <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" Font-Size="Smaller" Style="cursor: pointer;" Text="确定申请" OnClick="btnOK_Click" />
                                        </td>
                                    </tr>
                                </table>
        </div>
            
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
        <tr>
            <td width="100%" bgcolor="#FFFEDF" class="blue14" style="padding: 5px 10px 5px 10px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span class="blue14" style="padding: 5px 10px 5px 10px;">如有其他问题，请联系网站客服：<span class="red14"><%= _Site.ServiceTelephone %>
                            </span></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
              </div>
    </div>
    <input type="hidden" id="hdCurDiv" runat="server" value="ZC" />
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
    
</body>
</html>
    <script type="text/javascript">
        var curDiv = document.getElementById("hdCurDiv").value;
        switch (curDiv) {
            case 'ZC':
                clickTabMenu1(document.getElementById("tdZC"), "url(images/admin_qh_100_1.jpg)", "ZC");
                break;
            case 'FC':
                clickTabMenu1(document.getElementById("tdFC"), "url(images/admin_qh_100_1.jpg)", "FC");
                break;
            default:
                clickTabMenu1(document.getElementById("tdZC"), "url(images/admin_qh_100_1.jpg)", "ZC");
                break;

        }
        ShowOrHiddenDiv1(curDiv);
    </script>
