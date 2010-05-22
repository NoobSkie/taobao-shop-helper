<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/FollowFriendSchemeAdd.aspx.cs" inherits="Home_Room_FollowFriendSchemeAdd" enableEventValidation="false" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link href="Style/div.css" rel="stylesheet" type="text/css" />

    <script src="../../javaScript/Public.js" type="text/javascript"></script>


    <script language="javascript" type="text/javascript">
        function ShowOrHideDZUserList()
        {
            if(document.all["FollowUseList"].style.display == "")
            {
                document.all["FollowUseList"].style.display = "none";
            }
            else
            {
                document.all["FollowUseList"].style.display = "";
            }
        }

        function InputMask_Number()
        {
	        if (window.event.keyCode < 48 || window.event.keyCode > 57)
		        return false;
	        return true;
        }

        function CheckMultiple(sender)
        {
            var multiple = StrToInt(sender.value);
            
            sender.value = multiple;
            
            if (multiple < 1)
            {
	            if (confirm("输入不正确，按“确定”重新输入，按“取消”自动更正为 1 ，请选择。"))
	            {
		            sender.focus();
		            return;
	            }
	            else
	            {
		            multiple = 1;
		            sender.value = 1;
	            }
            }
        }
    </script>

    <base target="_self" />
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF" >
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#F4F9FC" style="border-left: 1px solid #DDDDDD;
                        border-right: 1px solid #DDDDDD;" >
                        <tr >
                            <td height="29">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-right-color:#D8D8D8; border-left-color:#D8D8D8;">
                                    <tr>
                                        <td width="40" height="29" align="center">
                                            <img src="images/jiantou_5.gif" width="12" height="8" />
                                        </td>
                                        <td class="blue_num" >
                                            定制自动跟单
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <table width="100%" align="center" cellpadding="5" cellspacing="1" bgcolor="#D8D8D8" >
                            <tr>
                                <td width="130" bgcolor="#f5f5f5" style="text-align: right; height:25px">
                                    好友用户名
                                </td>
                                <td bgcolor="#FFFFFF">
                                    <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#f5f5f5" style="text-align: right;">
                                    定制自动跟单玩法
                                </td>
                                <td bgcolor="#FFFFFF">
                                    <asp:DropDownList ID="ddlLotteries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLotteries_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlPlayTypes" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#f5f5f5" style="text-align: right;">
                                    跟单金额范围
                                </td>
                                <td bgcolor="#FFFFFF">
                                                <asp:TextBox ID="tbMinMoney" runat="server" Width="50px" onkeypress="return InputMask_Number();"
                                                    onblur="CheckMultiple(this);" Text="1"></asp:TextBox> 至 <asp:TextBox ID="tbMaxMoney" Text="1"
                                                        runat="server" Width="50px" onkeypress="return InputMask_Number();" onblur="CheckMultiple(this);"></asp:TextBox>&nbsp;元
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#f5f5f5" style="text-align: right;">
                                    每次认购份数
                                </td>
                                <td bgcolor="#FFFFFF">
                                    <asp:TextBox ID="tbBuyShareStart" runat="server" Width="50px" onkeypress="return InputMask_Number();"
                                        onblur="CheckMultiple(this);" Text="1"></asp:TextBox> 至 
                                        <asp:TextBox ID="tbBuyShareEnd" runat="server" Width="50px" onkeypress="return InputMask_Number();" Text="1"
                                        onblur="CheckMultiple(this);"></asp:TextBox>&nbsp;份
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#f5f5f5">
                                </td>
                                <td bgcolor="#FFFFFF">
                                    <ShoveWebUI:ShoveConfirmButton ID="btn_OK" runat="server" Text=" 确定 " OnClick="btn_OK_Click"
                                        AlertText="您确认输入无误并定制跟单吗?" />
                                    <span style="margin-left: 100px;"></span>
                                    <asp:Button ID="btnCancel" runat="server" Text=" 取消 " 
                                        onclick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                        
                    </div>
                </td>
            </tr>
        </table>
        <br />
           <table width="100%" border="0" cellspacing="1" cellpadding="0" 
                    bgcolor="#BCD2E9">
                    <tr>
                        <td height="28" colspan="6" bgcolor="#E7F1FA" class="blue12_1" style="padding-left: 15px;">
                            <strong>总跟单人次排行TOP10</strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="8%" height="28" align="center" bgcolor="#F4F9FC" class="blue12">
                            排名
                        </td>
                        <td width="30%" height="28" align="center" bgcolor="#F4F9FC" class="blue12">
                            发起人
                        </td>
                        <td width="11%"  align="center" bgcolor="#F4F9FC" class="blue12">
                            被定制人气
                        </td>
                        <td width="22%"  align="center" bgcolor="#F4F9FC" class="blue12">
                            跟单总金额
                        </td>
                        <td width="20%"  align="center" bgcolor="#F4F9FC" class="blue12">
                            当前期方案
                        </td>
                        <td width="9%" align="center" bgcolor="#F4F9FC" class="blue12">
                            自动跟单
                        </td>
                    </tr>
                    <tbody id="tbFollowList" runat="server">
       
                    </tbody>
                </table>
    </div>
    <asp:HiddenField ID="HidFollowUserID" runat="server" />
    <asp:HiddenField ID="HidNumber" runat="server" />
    </form>
</body>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</html>
<script type="text/javascript" language="javascript">
    parent.document.getElementById('iframeFollowScheme').style.height = parent.iframeFollowScheme.document.body.scrollHeight;
    </script>
