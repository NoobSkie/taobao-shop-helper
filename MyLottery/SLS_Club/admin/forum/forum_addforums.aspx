<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../UserControls/TextareaResize.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="cc3" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc2" TagName="PageInfo" Src="../UserControls/PageInfo.ascx" %>
<%@ page language="c#" validaterequest="false" inherits="Discuz.Web.Admin.addforums, SLS.Club" autoeventwireup="false" %>
<html>
  <head>
		<title>添加版块</title>
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />		
		<link href="../styles/tab.css" type="text/css" rel="stylesheet" />
		<style type="text/css">
	    .td_alternating_item1{font-size: 12px;}
	    .td_alternating_item2{font-size: 12px;background-color: #F5F7F8;}
	    </style>
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>
<body>
    <form id="Form1" method="post" runat="server">
	    <div class="Navbutton" style="width:98%;">
	    <table width="100%">
	    <tr>
        <td>	
	    <cc3:TabControl id="TabControl1" SelectionMode="Client" runat="server" TabScriptPath="../js/tabstrip.js" height="100%">
		    <cc3:TabPage Caption="基本信息" ID="tabPage51">
		    <table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
						    <td style="width: 90px">论坛名称:</td>
						    <td>
							    <cc2:TextBox id="name" runat="server" CanBeNull="必填" IsReplaceInvertedComma="false" size="20"  MaxLength="49"></cc2:TextBox>
							</td>
                        </tr>
                        <tr>
						    <td>显示模式:</td>
						    <td>
						        <table>
						            <tr>
						                <td>
						                    <cc2:RadioButtonList id="colcount" runat="server" AutoPostBack="false" RepeatColumns="1"  HintTitle="提示"
						                     HintInfo="用来设置该论坛(或分类)的子论坛在列表中的显示方式">
								                <asp:ListItem Value="1">传统模式[默认]</asp:ListItem>
								                <asp:ListItem Value="2">子版块横排模式</asp:ListItem>
							                </cc2:RadioButtonList>
						                </td>
					                    <td valign=bottom>
			 		    	                <div id="showcolnum" runat="server">
			 		    	                <cc2:TextBox id="colcountnumber" runat="server" Size="2" Text="4" MaxLength="1"></cc2:TextBox>
			 		    	                </div>
			 		                   </td>
			 		               </tr>
			 		           </table>
			 	    	    </td>
                        </tr>
					    <tr>
						    <td >论坛描述:</td>
						    <td>
						        <uc1:TextareaResize id="description" runat="server" controlname="TabControl1:tabPage51:description" Cols="40" Rows="5"></uc1:TextareaResize>
						    </td>
					    </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
                        <tr>
						    <td style="width: 90px">是否显示:</td>
						    <td>
						        <cc2:RadioButtonList id="status" runat="server" RepeatColumns="2"  HintInfo="设置本版块是否是隐藏版块" >
						        <asp:ListItem Value="1" Selected="True">显示</asp:ListItem>
						        <asp:ListItem Value="0" >不显示</asp:ListItem>
						        </cc2:RadioButtonList>
						    </td>
                        </tr>
					    <tr>
						    <td>所属类别:</td>
						    <td>
						        <table>
						          <tr>
						            <td>
								        <cc2:RadioButtonList id="addtype" runat="server" RepeatColumns="2">
								            <asp:ListItem Value="0" >论坛分类</asp:ListItem>
								            <asp:ListItem Value="1" Selected="True">论坛版块</asp:ListItem>
								        </cc2:RadioButtonList>
							        </td>
							      </tr>
							      <tr>	
							        <td>
								        &nbsp;&nbsp;
								        <div id="showtargetforum" runat="server">
								            <cc2:DropDownTreeList id="targetforumid" runat="server" Visible="true"></cc2:DropDownTreeList>
								        </div>
								    </td>
							      </tr>
							     </table>
					        </td>
					    </tr>
					    <tr>
						    <td>版主列表:</td>
						    <td>
							    <uc1:TextareaResize id="moderators" runat="server" HintTitle="提示" HintInfo="当前版块版主列表，以&amp;quot;,&amp;quot;进行分割" 
							    controlname="TabControl1:tabPage51:moderators" Cols="40" Rows="5"></uc1:TextareaResize>
							    <br />以','进行分割,如:lisi,zhangsan
							</td>
					    </tr>
                    </table>
                </td>
            </tr>
            </table>
			</cc3:TabPage>
			
            <cc3:TabPage Caption="高级设置" ID="tabPage22">
            <table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
						    <td style="width: 90px">访问本论<br />坛的密码:</td>
						    <td>
							    <cc2:textbox id="password" runat="server" HintTitle="提示" HintInfo="设置本版块的密码,留空则本版块不使用密码" RequiredFieldType="暂无校验" 
							    IsReplaceInvertedComma="false" MaxLength="16" Size="20"></cc2:textbox>
							</td>
                        </tr>
                        <tr>
						    <td>指向外部链<br />接的地址:</td>
						    <td>
							    <cc2:textbox id="redirect" runat="server" Width="250px" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false"  MaxLength="253" HintInfo="设置版块为一个链接，当点击本版块是将跳转到指定的地址上"></cc2:textbox>
							</td>
                        </tr>
                        <tr>
						    <td>本版规则:</td>
						    <td>
							    <cc2:textbox id="rules" runat="server" HintTitle="提示" HintInfo="支持Html" RequiredFieldType="暂无校验" 
							    width="250" height="100" TextMode="MultiLine" IsReplaceInvertedComma="false" ></cc2:textbox>
							</td>
                        </tr>
                        <tr>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
					    <tr>
						    <td style="width: 90px">论坛图标:</td>
						    <td>
							    <cc2:textbox id="icon" runat="server" HintTitle="提示" HintInfo="显示于首页论坛列表等" Width="250px" RequiredFieldType="暂无校验"
							     IsReplaceInvertedComma="false"  MaxLength="253"></cc2:textbox>
							</td>
					    </tr>
					    <tr>
						    <td>允许的附<br />件类型:</td>
						    <td>
								    <cc2:CheckBoxList id="attachextensions" runat="server" HintTitle="提示" 
								    HintInfo="允许在本论坛上传的附件类型,留空为使用用户组设置, 且版块设置优先于用户组设置" RepeatColumns="4"></cc2:CheckBoxList>
						    </td>
					    </tr>
					    <tr>
						    <td>定期自动<br />关闭主题:</td>
						    <td>
						        <table>
						            <tr>
						                <td>
					                        <cc2:RadioButtonList id="autocloseoption" runat="server" RepeatColumns="1">
                                            <asp:ListItem Value="0" Selected="True">不自动关闭</asp:ListItem>
                                            <asp:ListItem Value="1">按发布时间</asp:ListItem>
			 		                        </cc2:RadioButtonList>
			 		                    </td>
			 		                    <td valign=bottom>
	 		                                <div id="showclose" runat="server">
	 		    	                            <cc2:TextBox id="autocloseday" runat="server" RequiredFieldType="数据校验" Size="4" MaxLength="3"></cc2:TextBox>天自动关闭	
	 		                                </div>
			 		    	            </td>
			 		    	        </tr>
			 		    	    </table>
		       			    </td>
		       		    </tr>
	       		        <tr>
	       		            <td>只允许发布特<br />殊类型主题:</td>
	       		            <td>
	       		                <cc2:RadioButtonList id="allowspecialonly" runat="server" RepeatColumns="2" HintInfo="设置本版是否只允许发布特殊类型主题">
						            <asp:ListItem Value="1">是</asp:ListItem>
						            <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
						        </cc2:RadioButtonList>
	       		            </td>
	       		        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr>
						    <td style="width: 90px">设置:</td>
						    <td>
							    <cc2:CheckBoxList id="setting" runat="server" RepeatColumns="4" >
								    <asp:ListItem Value="allowsmilies">允许使用表情符</asp:ListItem>
								    <asp:ListItem Value="allowrss">允许RSS</asp:ListItem>
								    <asp:ListItem Value="allowbbcode">允许Discuz!NT代码</asp:ListItem>
								    <asp:ListItem Value="allowimgcode">允许[img]代码</asp:ListItem>
								    <asp:ListItem Value="recyclebin">打开回收站</asp:ListItem>
								    <asp:ListItem Value="modnewposts">发帖需要审核</asp:ListItem>
								    <asp:ListItem Value="jammer">帖子中添加干扰码</asp:ListItem>
								    <asp:ListItem Value="disablewatermark">禁止附件自动水印</asp:ListItem>
								    <asp:ListItem Value="inheritedmod">继承上级论坛或分类的版主设定</asp:ListItem>
								    <asp:ListItem Value="allowthumbnail">主题列表中显示缩略图</asp:ListItem>
								    <asp:ListItem Value="allowtags">允许标签</asp:ListItem>
								    <asp:ListItem Value="allowpostpoll">允许发投票</asp:ListItem>
							        <asp:ListItem Value="allowdebate">允许辩论</asp:ListItem>
							        <asp:ListItem Value="allowbonus">允许悬赏</asp:ListItem>
							    </cc2:CheckBoxList>
							</td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
		    </cc3:TabPage>

            <cc3:TabPage Caption="权限设定" ID="tabPage33">
            <uc2:PageInfo id="info1" runat="server" Icon="Information" Text="每个组的权限项不选择时,权限为使用本版块用户的用户组权限设置,且版块权限设置优先于用户组权限设置."></uc2:PageInfo>    			
                <table width="100%" id="powerset" align="center" class="table1" cellspacing="0" cellPadding="4"  bgcolor="#C3C7D1" runat="server">	
				    <tr>
					    <td class="td_alternating_item2">全选</td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c1" onclick="seleCol('viewperm',this.checked)"/><label for="c1">浏览论坛</label></td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c2" onclick="seleCol('postperm',this.checked)"/><label for="c2">发新话题</label></td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c3" onclick="seleCol('replyperm',this.checked)"/><label for="c3">发表回复</label></td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c4" onclick="seleCol('getattachperm',this.checked)"/><label for="c4">下载/查看附件</label></td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c5" onclick="seleCol('postattachperm',this.checked)"/><label for="c5">上传附件</label></td>
				    </tr>
                </table>
		    </cc3:TabPage>
		</cc3:TabControl>
    		
		      <div id="topictypes" style="display:none;width:100%;">
		           <table>
					    <tr>
						    <td>主题分类:</td>
						    <td>
							    <cc2:textbox id="topictypes" runat="server" RequiredFieldType="暂无校验" width="370" height="50" TextMode="MultiLine"></cc2:textbox></td>
					    </tr>
					    <tr>
						    <td>模板风格:</td>
						    <td>
							    <cc2:DropDownList id="templateid" runat="server"></cc2:DropDownList></td>
					    </tr>
				    </table>
			       </div>
		    <div class="Navbutton">
		        <cc2:Button id="SubmitAdd" runat="server" Text=" 添 加 "></cc2:Button>&nbsp;&nbsp;
			    <button onclick="window.location='forum_forumstree.aspx';" id="Button3" class="ManagerButton" type="button"><img src="../images/arrow_undo.gif"/> 返 回 </button>
			</div>
			</td>
		    </tr>
		    </table>    		
	    </div>
	    <cc2:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc2:Hint>
	    </form>
		
</body>
</html>
