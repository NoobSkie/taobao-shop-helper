<%@ page language="c#" validaterequest="false" inherits="Discuz.Web.Admin.edituser, SLS.Club" autoeventwireup="false" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="cc3" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register Src="../UserControls/PageInfo.ascx" TagName="PageInfo" TagPrefix="uc1" %>
<%@ Import Namespace="Discuz.Common" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>编辑用户组</title>
    <link href="../styles/tab.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/modalpopup.js"></script>
    <link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        function checkSetting()
	    {
		    if (document.getElementById('TabControl1_tabPage22_newsletter_0').checked)
		    {  
			    document.getElementById('TabControl1_tabPage22_newsletter_1').disabled = false;
		    }
		    else
		    {			
			    document.getElementById('TabControl1_tabPage22_newsletter_1').checked = false;
			    document.getElementById('TabControl1_tabPage22_newsletter_1').disabled = true;
		    }
	    }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <br />
        <table class="table1" cellspacing="0" cellpadding="4" width="100%" border="0">
            <tr>
                <td></td>
                <td width="99%">
                    <cc3:TabControl ID="TabControl1" SelectionMode="Client" runat="server" TabScriptPath="../js/tabstrip.js" Width="760" Height="100%">
                        <cc3:TabPage Caption="常规基本信息" ID="tabPage11">
                            <table cellspacing="0" cellpadding="4" width="100%" align="center">
                                <tr>
                                    <td  class="panelbox" width="50%" align="left">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 90px">用户名:</td>
                                                <td>
                                                    <cc1:TextBox ID="userName" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验"
                                                        Enabled="false" IsReplaceInvertedComma="false" MaxLength="20" Size="10"></cc1:TextBox>
                                                    <asp:CheckBox ID="IsEditUserName" runat="server" Text="允许修改用户名">
                                                    </asp:CheckBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>所属用户组:</td>
                                                <td>
                                                    <cc1:DropDownList ID="groupid" runat="server">
                                                    </cc1:DropDownList>
                                                    <cc1:Button ID="ReSendEmail" runat="server" Text="重发验证email" ButtontypeMode="Normal">
                                                    </cc1:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>清除用户安全提问:</td>
                                                <td>
                                                    <cc1:RadioButtonList ID="secques" runat="server" RepeatColumns="2">
                                                        <asp:ListItem Value="1">是</asp:ListItem>
                                                        <asp:ListItem Value="0" Selected="true">否</asp:ListItem>
                                                    </cc1:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>发帖数:</td>
                                                <td>
                                                    <cc1:TextBox ID="posts" runat="server" Width="56px" RequiredFieldType="数据校验" CanBeNull="必填"
                                                        MaxLength="9"></cc1:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="panelbox" width="50%" align="right">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 90px">UID:</td>
                                                <td>
                                                    <%=Discuz.Common.DNTRequest.GetString("uid")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>昵称:</td>
                                                <td>
                                                    <cc1:TextBox ID="nickname" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false"
                                                        MaxLength="20" Size="10"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>注册IP:</td>
                                                <td>
                                                    <cc1:TextBox ID="regip" runat="server" RequiredFieldType="IP地址" MaxLength="15" Size="11"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>精华帖数:</td>
                                                <td>
                                                    <cc1:TextBox ID="digestposts" runat="server" Width="56px" RequiredFieldType="数据校验"
                                                        CanBeNull="必填" MaxLength="4"></cc1:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <uc1:PageInfo ID="info1" runat="server" Icon="information" Text="以下为对该用户的管理操作, 操作后无法撤消, 请谨重! " />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="panelbox" align="left">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <cc1:Button ID="ResetPassWord" runat="server" Text="重设密码 "></cc1:Button>&nbsp;&nbsp;&nbsp;
                                                    <cc1:Button ID="ResetUserPost" runat="server" Text="重建用户发帖数"></cc1:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <cc1:Button ID="StopTalk" runat="server" Text="禁言该用户" HintInfo="该操作将会把当前用户放入系统 \'禁止发言\' 组中"></cc1:Button>&nbsp;&nbsp;&nbsp;
                                                    <cc1:Button ID="ResetUserDigestPost" runat="server" Text="重建用户精华帖数"></cc1:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="panelbox" align="right">
                                        <table width="100%">
                                            <tr>
                                                <td> 
                                                    <cc1:Button ID="DelPosts" runat="server" Text="删除该用户帖子" HintInfo="该操作将会删除该用户发表过的所有帖子" ButtonImgUrl="../images/del.gif"></cc1:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td><cc1:Button ID="DelUserInfo" runat="server" Text="删除该用户" ButtonImgUrl="../images/del.gif"></cc1:Button>&nbsp;</td>
                                                            <td>
                                                                <cc1:CheckBoxList ID="deltype" runat="server" RepeatColumns="1" RepeatLayout="flow">
                                                                    <asp:ListItem Value="1">保留用户所发帖子</asp:ListItem>
                                                                    <asp:ListItem Value="2">保留用户已发送的短消息</asp:ListItem>
                                                                </cc1:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </cc3:TabPage>
                        <cc3:TabPage Caption="用户信息" ID="tabPage22">
                            <table cellspacing="0" cellpadding="4" width="100%" align="center">
                                <tr>
                                    <td class="panelbox" width="50%" align="left">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 120px">真实姓名:</td>
                                                <td>
                                                    <cc1:TextBox ID="realname" runat="server" RequiredFieldType="暂无校验" MaxLength="10" Size="10"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>移动电话号码:</td>
                                                <td>
                                                    <cc1:TextBox ID="mobile" runat="server" MaxLength="20" Size="20"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>性别:</td>
                                                <td>
                                                    <cc1:RadioButtonList ID="gender" runat="server" RepeatColumns="3">
                                                        <asp:ListItem Value="1">男</asp:ListItem>
                                                        <asp:ListItem Value="2">女</asp:ListItem>
                                                        <asp:ListItem Value="0">保密</asp:ListItem>
                                                    </cc1:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>上次登录IP:</td>
                                                <td>
                                                    <cc1:TextBox ID="lastip" runat="server" RequiredFieldType="IP地址" MaxLength="15" Size="10"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>最后活动时间:</td>
                                                <td>
                                                    <cc1:TextBox ID="lastactivity" runat="server" Size="15" RequiredFieldType="日期时间"
                                                        CanBeNull="必填"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>在线时间:</td>
                                                <td>
                                                    <cc1:TextBox ID="oltime" runat="server" Width="96px" RequiredFieldType="数据校验" MaxLength="8" CanBeNull="必填"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>生日:</td>
                                                <td>
                                                    <cc1:TextBox ID="bday" runat="server" RequiredFieldType="暂无校验" MaxLength="10" Size="12"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>每页主题数</td>
                                                <td>
                                                    <cc1:TextBox ID="tpp" runat="server" Width="88px" HintInfo="论坛每页显示的主题数,0为论坛默认设置" RequiredFieldType="数据校验" MaxLength="4" CanBeNull="必填"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>风格:</td>
                                                <td>
                                                    <cc1:DropDownList ID="templateid" runat="server" HintInfo="该用户查看论坛时使用的模板">
                                                    </cc1:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>消息接收设置:</td>
                                                <td>
                                                    <cc1:CheckBoxList ID="newsletter" runat="server" RepeatColumns="1">
                                                        <asp:ListItem Value="2" onclick="checkSetting();">接收用户短消息</asp:ListItem>
                                                        <asp:ListItem Value="4" onclick="checkSetting();">显示短消息提示框</asp:ListItem>
                                                    </cc1:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>网站:</td>
                                                <td>
                                                    <cc1:TextBox ID="website" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false" MaxLength="80" Size="25"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>QQ号码:</td>
                                                <td>
                                                    <cc1:TextBox ID="qq" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false" MaxLength="12" Size="13"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>MSN Messenger帐号:</td>
                                                <td>
                                                    <cc1:TextBox ID="msn" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false" MaxLength="40" Size="20"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>来自:</td>
                                                <td>
                                                    <cc1:TextBox ID="location" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false" MaxLength="50" Size="20"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="67">头像:</td>
                                                <td valign="middle" align="left">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <cc1:TextBox ID="avatar" runat="server" RequiredFieldType="暂无校验" Size="20"></cc1:TextBox>
                                                            </td>
                                                            <td valign="middle">&nbsp;
                                                                <%if (avatar.Text == "")
                                                                  {%>
                                                                <img id="avatarimg" height="45" src="../../avatars/common/0.gif" valign="middle" style="cursor:hand" onclick="javascript:ShowWindow('global_avatarlist.aspx?path=2');" title="从头像库中选择">
                                                                <%}
                                                                  else
                                                                  {
                                                                      if (avatar.Text.ToLower().IndexOf("http") >= 0)
                                                                      {%>
                                                                <img id="avatarimg" height="45" src="<%=avatar.Text%>" valign="middle" style="cursor:hand" onclick="javascript:ShowWindow('global_avatarlist.aspx?path=2');" title="从头像库中选择">
                                                                <%}
                                                                  else
                                                                  {%>
                                                                <img id="avatarimg" height="45" src="../../<%=avatar.Text%>" valign="middle" style="cursor:hand" onclick="javascript:ShowWindow('global_avatarlist.aspx?path=2');" title="从头像库中选择">
                                                                <%}
                                                              }%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <script type="text/javascript">
								                        function ShowWindow(strUrl)
								                        {
									                        var isMSIE= (navigator.appName == "Microsoft Internet Explorer");
									                        if (isMSIE)
									                        {
										                        window.showModalDialog(strUrl,self,'width=600,height=500,resizable=no,scrollbars=no');
									                        }
									                        else
									                        {
										                        window.open(strUrl,'newWin','modal=yes,width=600,height=500,resizable=no,scrollbars=no');
									                        }
								                        }

								                        function ShowMsg(vatarpath)
								                        {
									                        //alert(vatarpath);
								                           if(typeof(vatarpath)=="undefined")
								                           {
								                              Form1.TabControl1_tabPage22_avatar.value="avatars\\common\\0.gif";
								                              Form1.avatarimg.src="../../avatars/common/0.gif";
								                           }
								                           else
								                           {
								                              Form1.TabControl1_tabPage22_avatar.value=vatarpath;
								                              Form1.avatarimg.src="../../"+vatarpath;
								                           }
								                        }
                                                    </script>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="panelbox" width="50%" align="right">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 130px">身份证号:</td>
                                                <td>
                                                    <cc1:TextBox ID="idcard" runat="server" RequiredFieldType="身份证号码" MaxLength="20" Size="20"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>固定电话号码:</td>
                                                <td>
                                                    <cc1:TextBox ID="phone" runat="server" CanBeNull="可为空" MaxLength="20" Size="20"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>注册时间:</td>
                                                <td>
                                                    <cc1:TextBox ID="joindate" runat="server" Size="15" RequiredFieldType="日期时间" CanBeNull="必填"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>上次访问时间:</td>
                                                <td>
                                                    <cc1:TextBox ID="lastvisit" runat="server" Size="15" RequiredFieldType="日期时间" CanBeNull="必填"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>最后发帖时间:</td>
                                                <td>
                                                    <cc1:TextBox ID="lastpost" runat="server" Size="15" RequiredFieldType="日期时间" CanBeNull="必填"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>邮件地址:</td>
                                                <td>
                                                    <cc1:TextBox ID="email" runat="server" CanBeNull="可为空" RequiredFieldType="电子邮箱" MaxLength="50" Size="20"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>签名:</td>
                                                <td>
                                                    <cc1:RadioButtonList ID="sigstatus" runat="server" RepeatColumns="2">
                                                        <asp:ListItem Value="1" Selected>显示</asp:ListItem>
                                                        <asp:ListItem Value="0">不显示</asp:ListItem>
                                                    </cc1:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>每页帖数:</td>
                                                <td>
                                                    <cc1:TextBox ID="ppp" runat="server" Width="88px" HintInfo="查看主题时每页显示的帖子数,0为论坛默认设置" RequiredFieldType="数据校验" MaxLength="4" CanBeNull="必填"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>是否显示邮箱:</td>
                                                <td>
                                                    <cc1:RadioButtonList ID="showemail" runat="server">
                                                        <asp:ListItem Value="1">是</asp:ListItem>
                                                        <asp:ListItem Value="0">否</asp:ListItem>
                                                    </cc1:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>是否隐身:</td>
                                                <td>
                                                    <cc1:RadioButtonList ID="invisible" runat="server">
                                                        <asp:ListItem Value="1">是</asp:ListItem>
                                                        <asp:ListItem Value="0">否</asp:ListItem>
                                                    </cc1:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>ICQ号码:</td>
                                                <td>
                                                    <cc1:TextBox ID="icq" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false" MaxLength="12" Size="13"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Yahoo Messenger帐号:</td>
                                                <td>
                                                    <cc1:TextBox ID="yahoo" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false" MaxLength="40" Size="20"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Skype帐号:</td>
                                                <td>
                                                    <cc1:TextBox ID="skype" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false" MaxLength="40" Size="20"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>自定义头衔:</td>
                                                <td>
                                                    <cc1:TextBox ID="customstatus" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false" MaxLength="50" Size="20"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>头像宽度:</td>
                                                <td>
                                                    <cc1:TextBox ID="avatarwidth" runat="server" RequiredFieldType="数据校验" Width="50" MaxLength="2" CanBeNull="必填"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>头像高度:</td>
                                                <td>
                                                    <cc1:TextBox ID="avatarheight" runat="server" RequiredFieldType="数据校验" Width="50" MaxLength="2" CanBeNull="必填"></cc1:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="panelbox" colspan="2">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 120px;height: 19px">自我介绍:</td>
                                                <td>
                                                    <cc1:TextBox ID="bio" runat="server" Width="496px" RequiredFieldType="暂无校验" TextMode="MultiLine" 
                                                    Height="92px" IsReplaceInvertedComma="false"></cc1:TextBox>
                                                </td>                                        
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="panelbox" colspan="2">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 120px">签名:</td>
                                                <td>
                                                    <cc1:TextBox ID="signature" runat="server" RequiredFieldType="暂无校验" Width="496px" TextMode="MultiLine" 
                                                    Height="50px" IsReplaceInvertedComma="false">
                                                    </cc1:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </cc3:TabPage>
                        <cc3:TabPage Caption="金币设置" ID="tabPage33">
                            <table cellspacing="0" cellpadding="4" width="100%" align="center">
                                <tr>
                                    <td class="panelbox" width="50%" align="left">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 90px">金币数:</td>
                                                <td>
                                                    <cc1:TextBox ID="credits" runat="server" Width="64px" RequiredFieldType="数据校验" MaxLength="9"></cc1:TextBox>
                                                    <cc1:Button ID="CalculatorScore" runat="server" Text="以系统标准计算用户金币" ButtontypeMode="Normal">
                                                    </cc1:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="extcredits2name" runat="server" Text="extcredits2"></asp:Literal>:</td>
                                                <td><cc1:TextBox ID="extcredits2" runat="server" RequiredFieldType="数据校验" Width="64px" MaxLength="7"></cc1:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="extcredits4name" runat="server" Text="extcredits4"></asp:Literal>:</td>
                                                <td><cc1:TextBox ID="extcredits4" runat="server" Width="64px" RequiredFieldType="数据校验" MaxLength="7"></cc1:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="extcredits6name" runat="server" Text="extcredits6"></asp:Literal>:</td>
                                                <td><cc1:TextBox ID="extcredits6" runat="server" Width="64px" RequiredFieldType="数据校验" MaxLength="7"></cc1:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="extcredits8name" runat="server" Text="extcredits8"></asp:Literal>:</td>
                                                <td><cc1:TextBox ID="extcredits8" runat="server" Width="64px" RequiredFieldType="数据校验" MaxLength="7"></cc1:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="panelbox" width="50%" align="right">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 90px"><asp:Literal ID="extcredits1name" runat="server" Text="extcredits1"></asp:Literal>:</td>
                                                <td><cc1:TextBox ID="extcredits1" runat="server" RequiredFieldType="数据校验" Width="64px" MaxLength="7"></cc1:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="extcredits3name" runat="server" Text="extcredits3"></asp:Literal>:</td>
                                                <td><cc1:TextBox ID="extcredits3" runat="server" Width="64px" RequiredFieldType="数据校验" MaxLength="7"></cc1:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="extcredits5name" runat="server" Text="extcredits5"></asp:Literal>:</td>
                                                <td><cc1:TextBox ID="extcredits5" runat="server" Width="64px" RequiredFieldType="数据校验" MaxLength="7"></cc1:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="extcredits7name" runat="server" Text="extcredits7"></asp:Literal>:</td>
                                                <td><cc1:TextBox ID="extcredits7" runat="server" Width="64px" RequiredFieldType="数据校验" MaxLength="7"></cc1:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </cc3:TabPage>
                        <cc3:TabPage Caption=" 勋 章 " ID="tabPage44">
                            <table class="ntcplist">
                            <tr>
                            <td>
                            <table class="datalist" id="DataGrid1" style="border-collapse: collapse;" align="center" border="1" cellspacing="0" rules="all">
                                <tr class="category">
                                    <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap" width="40%">勋章图片</td>
                                    <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap" width="40%">名称</td>
                                    <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap" width="20%"><input title="选中/取消选中 本页所有Case" onclick="CheckAll(this.form)" type="checkbox" name="chkall" id="chkall" />授予该勋章</td>
                                </tr>
                                <cc1:Repeater ID="medalslist" runat="server">
                                    <ItemTemplate>
                                        <tr class="mouseoutstyle" onmouseover="this.className='mouseoverstyle'" onmouseout="this.className='mouseoutstyle'">
                                            <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap"><img src="../../images/medals/<%# DataBinder.Eval(Container.DataItem,"image").ToString()%>" height="25px" /></td>
                                            <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap"><%# DataBinder.Eval(Container.DataItem,"name").ToString()%></td>
                                            <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap">
                                                <%# BeGivenMedal(DataBinder.Eval(Container.DataItem,"isgiven").ToString(),DataBinder.Eval(Container.DataItem,"medalid").ToString())%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="mouseoutstyle" onmouseover="this.className='mouseoverstyle'" onmouseout="this.className='mouseoutstyle'">
                                            <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap"><img src="../../images/medals/<%# DataBinder.Eval(Container.DataItem,"image").ToString()%>" height="25px"></td>
                                            <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap"><%# DataBinder.Eval(Container.DataItem,"name").ToString()%></td>
                                            <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap">
                                                <%# BeGivenMedal(DataBinder.Eval(Container.DataItem,"isgiven").ToString(),DataBinder.Eval(Container.DataItem,"medalid").ToString())%>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </cc1:Repeater>
                            </table>
                            </td>
                            </tr>
                            </table>
                            
                            <table width="100%">
                            <tr>
                            <td class="panelbox">
                            <table class="table1" cellspacing="0" cellpadding="4" width="100%" align="center" border="0">
                                <tr>
                                    <td style="width: 130px">授予/收回勋章的理由:</td>
                                    <td>
                                        <cc1:TextBox ID="reason" runat="server" HintTitle="提示" HintInfo="如果您修改了用户的勋章资料, 请输入操作理由, 系统将把理由记录在勋章授予记录中, 以供日后查看"
                                            TextMode="MultiLine" RequiredFieldType="暂无校验" Width="60%" Height="112px"></cc1:TextBox>
                                        <cc1:Button ID="GivenMedal" runat="server" Text="仅修改勋章设置"></cc1:Button>
                                    </td>
                                </tr>
                            </table>
                            </td>
                            </tr>
                            </table>
                        </cc3:TabPage>
                    </cc3:TabControl>
                </td>
            </tr>
        </table>
        <div class="Navbutton">
            <cc1:Button ID="SaveUserInfo" runat="server" Text=" 提 交 "></cc1:Button>&nbsp;&nbsp;
            <button type="button" class="ManagerButton" id="Button3" onclick="window.history.back();"><img src="../images/arrow_undo.gif"/> 返 回 </button>
        </div>
        <div id="topictypes" style="display: none; width: 100%;">
            <tr>
                <td>页面浏览量</td>
                <td><cc1:TextBox ID="pageviews" runat="server" Width="96px" RequiredFieldType="暂无校验"></cc1:TextBox></td>
            </tr>
            <tr>
                <td class="td2">日期格式</td>
                <td class="td2"><cc1:TextBox ID="smalldatetimeformat" runat="server" Width="208px" RequiredFieldType="暂无校验"></cc1:TextBox></td>
            </tr>
            <tr>
                <td>时间格式</td>
                <td><cc1:TextBox ID="timeformat" runat="server" Width="208px" RequiredFieldType="暂无校验"></cc1:TextBox></td>
            </tr>
            <tr>
                <td class="td2">短消息铃声</td>
                <td class="td2"><cc1:TextBox ID="pmsound" runat="server" Width="208px" RequiredFieldType="暂无校验"></cc1:TextBox></td>
            </tr>
            <tr>
                <td>是否使用特殊权限</td>
                <td>
                    <cc1:RadioButtonList ID="accessmasks" runat="server">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </cc1:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>组过期时间</td>
                <td><cc1:TextBox ID="groupexpiry" runat="server" Width="192px" RequiredFieldType="暂无校验"></cc1:TextBox></td>
            </tr>
            <tr>
                <td class="td2">扩展用户组</td>
                <td class="td2">
                    <cc1:CheckBoxList ID="extgroupids" runat="server" RepeatColumns="4">
                    </cc1:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="td2">是否有新消息</td>
                <td class="td2">
                    <cc1:RadioButtonList ID="newpm" runat="server">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </cc1:RadioButtonList></td>
            </tr>
        </div>
        <div style="display: none">
            <tr>
                <td>当前用户:<asp:Literal ID="givenusername" runat="server"></asp:Literal></td>
                <td></td>
                <td></td>
            </tr>
        </div>
        <cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
    </form>
    
</body>
</html>
