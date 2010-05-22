<%@ page language="c#" inherits="Discuz.Web.Admin.seachtopic, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="cc4" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
    <head>
		<title>seachcondition</title>
		<link href="../styles/calendar.css" type="text/css" rel="stylesheet" />		
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
	    <div class="ManagerForm">
        <fieldset>
		    <legend style="background:url(../images/icons/icon19.jpg) no-repeat 6px 50%;">搜索主题</legend>
		    <table cellspacing="0" cellpadding="4" width="100%" align="center">
		    <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr>
					        <td style="width: 110px">所在论坛:</td>
					        <td><cc1:dropdowntreelist id="forumid" runat="server"></cc1:dropdowntreelist></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
					        <td style="width: 110px">被浏览次数小于:</td>
				            <td><cc1:textbox id="viewsmin" runat="server" RequiredFieldType="数据校验" Size="5"></cc1:textbox></td>
                        </tr>
                        <tr>
					        <td>被回复次数小于:</td>
					        <td><cc1:textbox id="repliesmin" runat="server" RequiredFieldType="数据校验" Size="5"></cc1:textbox></td>
                        </tr>
                        <tr>
					        <td>所需阅读权限高于:</td>
				            <td><cc1:textbox id="rate" runat="server" RequiredFieldType="数据校验" Size="5"></cc1:textbox></td>
                        </tr>
                        <tr>
					        <td>多少天内无新回复:</td>
					        <td> <cc1:textbox id="lastpost" runat="server" RequiredFieldType="数据校验" Size="5"></cc1:textbox></td>
                        </tr>
                        <tr>
					        <td>标题关键字:</td>
				            <td>
				                <cc1:TextBox id="keyword" runat="server" HintTitle="提示" HintInfo="多关键字中间请用半角逗号&amp;quot;,&amp;quot; 分割" 
				                RequiredFieldType="暂无校验" Width="100"></cc1:TextBox>
				            </td>
                        </tr>
                        <tr>
					        <td>是否包含精华帖:</td>
					        <td>
					            <cc1:radiobuttonlist id="digest" runat="server" RepeatColumns="3">
							        <asp:Listitem Value="0" selected="true">无限制</asp:Listitem>
							        <asp:Listitem Value="1">包含且仅包含</asp:Listitem>
							        <asp:Listitem Value="20">不包含</asp:Listitem>
				                </cc1:radiobuttonlist>
				            </td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
				        <tr>
					        <td style="width: 110px">被浏览次数大于:</td>
				            <td><cc1:textbox id="viewsmax" runat="server" RequiredFieldType="数据校验" Size="5"></cc1:textbox></td>
				        </tr>
				        <tr>
					        <td>被回复次数大于:</td>
				            <td><cc1:textbox id="repliesmax" runat="server" RequiredFieldType="数据校验" Size="5"></cc1:textbox></td>
				        </tr>
				        <tr>
					        <td>发表时间范围:</td>
					        <td>
			                    起始日期:<cc4:Calendar id="postdatetimeStart" runat="server" ReadOnly="True" ScriptPath="../js/calendar.js"></cc4:Calendar><br />
					            结束日期:<cc4:Calendar id="postdatetimeEnd" runat="server" ReadOnly="True" ScriptPath="../js/calendar.js"></cc4:Calendar>
				            </td>
				        </tr>
				        <tr>
					        <td>主题作者:</td>
					        <td>
						        <cc1:TextBox id="poster" runat="server" HintTitle="提示" HintInfo="多用户名中间请用半角逗号 &amp;quot;,&amp;quot; 分割" 
						        RequiredFieldType="暂无校验" Width="100"></cc1:TextBox>&nbsp;
						        <input id="lowerupper" type="checkbox" value="1" name="cins" runat="server" checked="checked" />不区分大小写
				            </td>
				        </tr>
				        <tr>
					        <td>是否包含置顶帖:</td>
					        <td>
					            <cc1:radiobuttonlist id="displayorder" runat="server" RepeatColumns="3">
							        <asp:Listitem Value="0" selected="true">无限制</asp:Listitem>
							        <asp:Listitem Value="1">包含且仅包含</asp:Listitem>
							        <asp:Listitem Value="20">不包含</asp:Listitem>
				                </cc1:radiobuttonlist>
				            </td>
				        </tr>
				        <tr>
					        <td>是否包含附件:</td>
					        <td>
					            <cc1:radiobuttonlist id="attachment" runat="server" RepeatColumns="3">
							        <asp:Listitem Value="0" selected="true">无限制</asp:Listitem>
							        <asp:Listitem Value="1">包含且仅包含</asp:Listitem>
							        <asp:Listitem Value="20">不包含</asp:Listitem>
				                </cc1:radiobuttonlist>
				            </td>
				        </tr>
                    </table>
                </td>
            </tr>
            </table>
		</fieldset>
		  <cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		  <div class="Navbutton"><cc1:Button id="SaveSearchCondition" runat="server" Text="搜索符合条件主题" ButtonImgUrl="../images/search.gif"></cc1:Button></div>
		</div>
        <div id="topictypes" style="display:none;width:100%;">
            <tr>
                <td >所在分类:</td>
                <td ><cc1:dropdownlist id="typeid" runat="server"></cc1:dropdownlist></td>
            </tr>
        </div>
	    </form>
		
	</body>
</html>
