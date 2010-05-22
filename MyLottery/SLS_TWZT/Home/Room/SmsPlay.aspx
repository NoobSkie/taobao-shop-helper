<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/SmsPlay.aspx.cs" inherits="Home_Room_SmsPlay" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <style type="text/css">
        body
        {
            margin-top: 20px;
            margin-left: 20px;
            margin-bottom: 0px;
            margin-right: 0px;
            background-image: url(../images/box_bg.jpg);
            background-repeat: repeat-x;
            background-position: top;
            background-color: #ffffff;
        }
        .black12
        {
            font-size: 12px;
            color: #000000;
            font-family: "tahoma";
            line-height: 18px;
        }
        .black12 A:link
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .black12 A:active
        {
            font-family: "tahoma";
            color: #000000;
            text-decoration: none;
        }
        .black12 A:visited
        {
            font-family: "tahoma";
            color: #000000;
            text-decoration: none;
        }
        .black12 A:hover
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .red
        {
            font-size: 12px;
            color: #ff0000;
            font-family: "tahoma";
            line-height: 18px;
        }
        .black14
        {
            font-size: 14px;
            color: #000000;
            font-family: "tahoma";
            line-height: 18px;
        }
        .black14 A:link
        {
            font-family: "tahoma";
            color: #000000;
            text-decoration: none;
        }
        .black14 A:active
        {
            font-family: "tahoma";
            color: #000000;
            text-decoration: none;
        }
        .black14 A:visited
        {
            font-family: "tahoma";
            color: #000000;
            text-decoration: none;
        }
        .black14 A:hover
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .td14
        {
            font-size: 14px;
            color: #ff6600;
            font-family: "tahoma";
            line-height: 18px;
            font-weight: bold;
        }
        .td14 A:link
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .td14 A:active
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .td14 A:visited
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .td14 A:hover
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .num
        {
            font-size: 22px;
            color: #ff6600;
            font-family: "tahoma";
            line-height: 30px;
        }
        .style2
        {
            font-size: 17px;
            color: #ff6600;
            font-family: "tahoma";
            line-height: 30px;
        }
        .style3
        {
            font-size: 11pt;
            color: #ff6600;
            font-family: "tahoma";
            line-height: 30px;
        }
    </style>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="550" border="0" cellpadding="0" cellspacing="0" bgcolor="#FF6600">
            <tr>
                <td style="padding: 3px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td bgcolor="#F5F5F5" style="padding: 5px;">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="50%" valign="top" bgcolor="#FFFFFF">
                                            <table width="300px" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                <tr>
                                                    <td valign="top" bgcolor="#FFFFFF" style="padding: 5px;">
                                                        <div style="height: 10px;">
                                                        </div>
                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="20%" align="center">
                                                                    <img src="images/num_1.jpg" width="42" height="49" />
                                                                </td>
                                                                <td width="80%" class="black12">
                                                                    <span class="td14">您本次投注的短信编码内容如下：</span><br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="height: 10px;">
                                                        </div>
                                                        <table border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <img src="images/sms_top.jpg" width="280" style="vertical-align: bottom;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="258" valign="top" background="images/sms_bg.jpg" style="width: 280px;">
                                                                    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td class="black12" style="padding-left: 10px; padding-right: 10px;">
                                                                                <div style="width: 260px; word-wrap: break-word; text-align: left; vertical-align: top;"
                                                                                    id="labShortNote">
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <img src="images/sms_foot.jpg" width="280" height="31px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="height: 10px;">
                                                        </div>
                                                        <table width="280" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td height="30" bgcolor="#FFFFFF" class="black12" style="padding: 5px;">
                                                                    投注短信发送成功请点击 <span onclick="btn_OK_Click()" style="color: #ff6600; cursor: hand;">确定</span><br />
                                                                    重新选号请点击 <span onclick="btn_CanleClick()" style="color: #ff6600; cursor: hand;">取消</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="height: 13px;">
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="50%" valign="top">
                                            <div style="height: 10px;">
                                            </div>
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="16%" align="center">
                                                        <img src="images/num_2.jpg" alt="" width="42" height="49" />
                                                    </td>
                                                    <td width="84%" class="black14" style="padding-left: 10px;">
                                                        <span class="td14">请将短信编码发送到<br />
                                                            手机投注特服号：</span><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <div style="height: 10px;">
                                                        </div>
                                                        <span class="black14"><span class="style3">106 5710 9095665167</span></span><span
                                                            class="black12"> (移动)</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <span class="black14"><span class="style2">106 5516 887 3167 </span></span><span
                                                            class="black12">&nbsp;(联通)</span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="height: 10px;">
                                            </div>
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <span class="td14">投注详情：</span><br />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="height: 10px;">
                                            </div>
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                <tr>
                                                    <td width="84" height="22" align="right" bgcolor="#FFFFC8" class="black12">
                                                        彩&nbsp;&nbsp;&nbsp;种：
                                                    </td>
                                                    <td bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                        <span class="red"><span id="lbLotteryName"></span><span id="labIsuse"></span>期</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="22" align="right" bgcolor="#FFFFC8" class="black12">
                                                        玩&nbsp;&nbsp;&nbsp;法：
                                                    </td>
                                                    <td bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                        <span class="red"><span id="ddlPlayType"></span></span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="height: 10px;">
                                            </div>
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                <tr>
                                                    <td width="102" height="22" align="right" bgcolor="#FFFFC8" class="black12">
                                                        注&nbsp;&nbsp;&nbsp;数：
                                                    </td>
                                                    <td width="193" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                        <span id="divSMS_Num" class="red"></span>&nbsp;&nbsp;注
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="22" align="right" bgcolor="#FFFFC8" class="black12">
                                                        倍&nbsp;&nbsp;&nbsp;数：
                                                    </td>
                                                    <td bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                        <span id="divSMS_Multiple" class="red"></span>&nbsp;&nbsp;倍
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="22" align="right" bgcolor="#FFFFC8" class="black12">
                                                        总金额：
                                                    </td>
                                                    <td bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                        <span id="divSMS_Money" class="red"></span>&nbsp;&nbsp;元
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="height: 10px;">
                                            </div>
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                <tr>
                                                    <td width="102" height="22" align="right" bgcolor="#FFFFC8" class="black12">
                                                        总份数：
                                                    </td>
                                                    <td width="193" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                        <span id="divSMS_SumShare" class="red"></span>&nbsp;&nbsp;份
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="22" align="right" bgcolor="#FFFFC8" class="black12">
                                                        每&nbsp;&nbsp;&nbsp;份：
                                                    </td>
                                                    <td bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                        <span id="divSMS_Money1" class="red"></span>&nbsp;&nbsp;元
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="height: 10px;">
                                            </div>
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                <tr>
                                                    <td width="102" height="22" align="right" bgcolor="#FFFFC8" class="black12">
                                                        保&nbsp;&nbsp;&nbsp;底：
                                                    </td>
                                                    <td width="193" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                        <span class="red">0</span> 份 <span class="red">0</span>&nbsp;&nbsp;元
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="22" align="right" bgcolor="#FFFFC8" class="black12">
                                                        购&nbsp;&nbsp;&nbsp;买：
                                                    </td>
                                                    <td bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                        <span id="divSMS_Share" class="red"></span>&nbsp;&nbsp;份 <span id="divSMS_Money2"
                                                            class="red"></span>&nbsp;&nbsp;元
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="height: 10px;">
                                            </div>
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                <tr>
                                                    <td height="22" bgcolor="#FFFFFF" class="black12" style="padding: 8px;">
                                                        如果您不想手动发送短信编码进行投注，您可以点击 <span onclick="btn_OK_SmsClick()" style="color: #ff6600;
                                                            cursor: hand;">短信代发投注</span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

    <script language="javascript" type="text/javascript">  
    var str_s = window.dialogArguments.split('&');
    var lbLotteryName = str_s[0];
    var labIsuse = str_s[1];
    var ddlPlayType = str_s[2];
    var Num = str_s[3];
    var Multiple = str_s[4];
    var Money = str_s[5];
    var str_sms = str_s[6];
    var SumShare = str_s[7];
    var Share = str_s[8];
    
    document.all["lbLotteryName"].innerText = lbLotteryName;    
    document.all["lbLotteryName"].innerText = lbLotteryName;
    document.all["labIsuse"].innerText = labIsuse;
    document.all["ddlPlayType"].innerText = ddlPlayType;
    document.all["divSMS_Num"].innerText = Num;
    document.all["divSMS_Multiple"].innerText = Multiple;
    document.all["divSMS_Money"].innerText = Money;
    document.all["divSMS_Money1"].innerText = Money;
    document.all["divSMS_Money2"].innerText = Money;
    document.all["labShortNote"].innerText = str_sms;
    document.all["divSMS_SumShare"].innerText = SumShare;
    document.all["divSMS_Share"].innerText = Share;
    
    function btn_OK_Click()
    {
        window.returnValue = "1";
        window.close();
    }
    function btn_CanleClick()
    {
        window.returnValue = "2";
        window.close();
    }
    function btn_OK_SmsClick()
    {
        window.returnValue = "3";
        window.close();
    }
    </script>

    </form>
<!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
