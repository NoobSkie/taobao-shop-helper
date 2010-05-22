<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/FollowFriendSchemeEdit.aspx.cs" inherits="Home_Room_FollowFriendSchemeEdit" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />

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
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg_blue_30.jpg">
                        <tr>
                            <td height="30">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="40" height="30" align="center">
                                            <img src="images/jiantou_5.gif" width="12" height="8" />
                                        </td>
                                        <td class="blue_num">
                                            定制自动跟单
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <table width="100%" align="center" cellpadding="5" cellspacing="1" bgcolor="#9FC8EA">
                            <tr>
                                <td width="150" bgcolor="#f5f5f5" style="text-align: right;">
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
                                    
                                    <asp:TextBox ID="tbMinMoney" runat="server" Width="80px" onkeypress="return InputMask_Number();"
                                        onblur="CheckMultiple(this);"></asp:TextBox> 至 <asp:TextBox ID="tbMaxMoney"
                                            runat="server" Width="80px" onkeypress="return InputMask_Number();" onblur="CheckMultiple(this);"></asp:TextBox>&nbsp;元
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#f5f5f5" style="text-align: right;">
                                    每次认购份数
                                </td>
                                <td bgcolor="#FFFFFF">
                                    <asp:TextBox ID="tbBuyShareStart" runat="server" Width="80px" onkeypress="return InputMask_Number();"
                                        onblur="CheckMultiple(this);"></asp:TextBox> 至 <asp:TextBox ID="tbBuyShareEnd" runat="server" Width="80px" onkeypress="return InputMask_Number();"
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
                                    <input id="btnCancel" type="button" value=" 取消 " onclick="window.close();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HidUserID" runat="server" />
    <asp:HiddenField ID="HidFollowUserID" runat="server" />
    <asp:HiddenField ID="HidPlayTypeID" runat="server" />
    
    </form>
        <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
