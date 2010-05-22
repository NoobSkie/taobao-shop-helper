<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../UserControls/TextareaResize.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="PageInfo" Src="../UserControls/PageInfo.ascx" %>
<%@ page language="c#" validaterequest="false" inherits="Discuz.Web.Admin.editmall, SLS.Club" autoeventwireup="false" %>

<html>
	<head>
		<title>编辑商城</title>
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
		<link href="../styles/tab.css" type="text/css" rel="stylesheet" />
	    <script type="text/javascript" src="../js/common.js"></script>
	    <script type="text/javascript" src="../js/tabstrip.js"></script>
	    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
        <script type="text/javascript" src="../js/AjaxHelper.js"></script>
	    <style type="text/css">
	    .td_alternating_item1{font-size: 12px;}
	    .td_alternating_item2{font-size: 12px;background-color: #F5F7F8;}
	    </style>
	    <script type="text/javascript">
		function editcredit(fid,fieldname)
		{
			window.location="forum_ScoreStrategy.aspx?fid="+fid+"&fieldname="+fieldname;
		}
		function Check(form,bCheck,findstring)
		{
			for (var i=0;i<form.elements.length;i++)
			{
			var e = form.elements[i];
			if (e.name.indexOf(findstring) >= 0)
				e.checked = bCheck;
			}
		}
		function CheckRow(form,bCheck,rowId)
		{
			for (var i=0;i<form.elements.length;i++)
			{
			var e = form.elements[i];
			if (e.name.indexOf(rowId + ":viewbyuser") >= 0 || e.name.indexOf(rowId + ":postbyuser") >= 0
				 || e.name.indexOf(rowId + ":replybyuser") >= 0 || e.name.indexOf(rowId + ":getattachbyuser") >= 0
				  || e.name.indexOf(rowId + ":postattachbyuser") >= 0)
				e.checked = bCheck;
			}
		}
		/*function AddTopicType()
		{
		    typename = $("typename").value;
		    typeorder = $("typeorder").value;
		    typedescription = $("typedescription").value;
		    if(typename == "")
		    {
		        alert("主题分类名称不能为空！");
		        $("typename").focus();
		        return false;
		    }
		    if(!(/^\d+$/.test(typeorder)))
		    {
		        alert("显示顺序不能为空并且只能为数字！");
		        $("typeorder").value = "";
		        $("typeorder").focus();
		        return false;
		    }
		    AjaxHelper.Updater('../UserControls/addtopictype','resultmessage','typename='+typename+'&typeorder='+typeorder+'&typedescription='+typedescription,ResultFun);
		}
		function ResultFun()
		{
		    resultstring = $("resultmessage").innerHTML;
		    if(resultstring.indexOf("false") == -1)
		    {
		        var maxId = resultstring.replace(" </FORM>","");
		        if(/\s+/.test(maxId))
		        {
		            maxId = maxId.substring(0,maxId.length - 3);
		        }
                var theDoc = document;
		        var typetable = $("TabControl1_tabPage5_TopicTypeDataGrid");
		        var tbody = typetable.lastChild;
		        lasttr = tbody.lastChild;
		        tbody.removeChild(tbody.childNodes[tbody.childNodes.length - 1]);
		        rowscount = tbody.childNodes.length - 1;
                
                tr = theDoc.createElement("tr");
                if(window.navigator.appName == "Netscape")
                {                
                    tr.setAttribute("onmouseover","this.className='mouseoverstyle'");                    
                    tr.setAttribute("onmouseout","this.className='mouseoutstyle'");                    
                    tr.setAttribute("style","cursor:hand;");
                }
                else
                {
                    tr.onmouseover = "this.className='mouseoverstyle'";
                    tr.onmouseout = "this.className='mouseoutstyle'";
                    tr.style.cursor = "hand";
                }
                
		        td = GetTd();
		        td.innerHTML = $("typename").value;
		        tr.appendChild(td);
		        
		        td = GetTd();
		        td.innerHTML = $("typedescription").value;
		        tr.appendChild(td);
		        
		        td = GetTd();
		        td.innerHTML = "<input type='hidden' name='oldtopictype" + rowscount + "' value='' /><input type='radio' name='type" + rowscount + "' value='-1' />";
		        tr.appendChild(td);
		        
		        td = GetTd();
		        td.innerHTML = "<input type='radio' name='type" + rowscount + "' checked value='" + maxId + "," + $("typename").value + ",0|' />";
		        tr.appendChild(td);
		        
		        td = GetTd();
		        td.innerHTML = "<input type='radio' name='type" + rowscount + "' value='" + maxId + "," + $("typename").value + ",1|' />";
		        tr.appendChild(td);
		        
		        tbody.appendChild(tr);
		        tbody.appendChild(lasttr);
		        $("typename").value = "";
		        $("typeorder").value = "";
		        $("typedescription").value = "";
		    }
		    else
		    {
		        alert("数据库中已存在相同的主题分类名称");
		    }
		}*/
		
		function GetTd()
		{
		        td = document.createElement("td");
		        td.setAttribute("nowrap","nowrap");
		        td.style.borderColor = "#EAE9E1";
		        td.style.borderWidth = "1px";
		        td.style.borderStyle = "solid";
		        return td;
		}
        </script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
	    <table width="100%">
	    <tr>
	    <td></td>
	    <td><br />
		    <span style="font-size:12px">当前商城版块为: <b><asp:literal id="forumname" runat="server"></asp:literal></b></span>
            <cc2:TabControl id="TabControl1" SelectionMode="Client" runat="server" TabScriptPath="../js/tabstrip.js"  height="100%">
                <cc2:TabPage Caption="基本信息" ID="tabPage1" >
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
							        <td style="width: 90px">交易版名称:</td>
							        <td>
								        <cc2:TextBox id="name" runat="server" CanBeNull="必填"  IsReplaceInvertedComma="false"   size="30"  MaxLength="49"></cc2:TextBox>
							        </td>
                                </tr>
                                <tr>
							        <td>是否显示:</td>
							        <td>
						                <cc2:RadioButtonList id="status" runat="server" RepeatColumns="2" HintInfo="设置本版块是否是隐藏版块" >
						                <asp:ListItem Value="1" Selected="True">显示</asp:ListItem>
						                <asp:ListItem Value="0" >不显示</asp:ListItem>
						                </cc2:RadioButtonList>
							        </td>
                                </tr>
                                <tr>
							        <td>版主列表:</td>
							        <td>
								        <uc1:TextareaResize id="moderators" runat="server" HintTitle="提示" HintInfo="当前版块版主列表，以&amp;quot;,&amp;quot;进行分割" 
								        controlname="TabControl1:tabPage1:moderators" Cols="30" Rows="5"></uc1:TextareaResize>
								        <br />以','进行分割,如:lisi,zhangsan
							        </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" align="right" width="50%">
                            <table width="100%">
						        <tr>
							        <td style="width: 90px">已继承的版主:</td>
							        <td><asp:Literal ID="inheritmoderators" runat="server"></asp:Literal></td>
						        </tr>
						        <!--tr>
							        <td>显示模式:</td>
							        <td>
							            <table>
							                <tr>
							                    <td>
								                    <cc2:RadioButtonList id="colcount" runat="server" RepeatColumns="1"  HintTitle="提示" 
								                    HintInfo="用来设置该论坛(或分类)的子论坛在列表中的显示方式,选择&amp;quot;子版块横排模式&amp;quot;,则子分类列表按每行按输入的数字个数出现">
									                    <asp:ListItem Value="1">传统模式[默认]</asp:ListItem>
									                    <asp:ListItem Value="2">子版块横排模式</asp:ListItem>
								                    </cc2:RadioButtonList>
								                </td>
								                <td valign="bottom">
				 		    	                    <div id="showcolnum" runat="server">
				 		    	                        <cc2:TextBox id="colcountnumber" runat="server" Size="2" Text="4" MaxLength="1"></cc2:TextBox>
				 		    	                    </div>
				 		                        </td>
				 		                    </tr>
				 		                </table>
				 	    	        </td>
						        </tr-->
						        <tr>
							        <td >交易版描述:</td>
							        <td>
							            <uc1:TextareaResize id="description" runat="server" controlname="TabControl1:tabPage1:description" Cols="30" Rows="5"></uc1:TextareaResize>
							        </td>
						        </tr>
                            </table>
                        </td>
                    </tr>
                    <!--span>
					<div id="templatestyle" runat="server">
					<tr>
                        <td class="panelbox" colspan="2">
                            <table width="100%">
                                <tr>
						            <td style="width: 90px">模板风格:</td>
						            <td><cc2:DropDownList id="templateid" runat="server" HintInfo="设置本版块使用的模板,将不受系统模板限制"></cc2:DropDownList></td>
						            <td>&nbsp;</td>
						            <td>&nbsp;</td>
					            </tr>
					        </table>
					    </td>
					</tr>
					</div>
					</span-->
                </table>
                </cc2:TabPage>
                <cc2:TabPage Caption="高级设置" ID="tabPage2">
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
							        <td style="width: 110px">访问本版块的密码:</td>
							        <td>
								        <cc2:textbox id="password" runat="server" HintTitle="提示" HintInfo="设置本版块的密码,留空则本版块不使用密码" RequiredFieldType="暂无校验" 
								        IsReplaceInvertedComma="false" MaxLength="16" Size="20"></cc2:textbox>
							        </td>
                                </tr>
                                <!--tr>
							        <td>发主题金币策略:</td>
							        <td>
							            <a href="#" class="TextButton" onclick="javascript:editcredit('<%=Request.Params["fid"]%>','postcredits');" >编 辑</a>
							        </td>
                                </tr-->
                                <tr>
							        <td>指向外部链接地址:</td>
							        <td>
								        <cc2:textbox id="redirect" runat="server" Width="250px" RequiredFieldType="暂无校验" IsReplaceInvertedComma="false"  MaxLength="253" HintInfo="设置版块为一个链接，当点击本版块是将跳转到指定的地址上"></cc2:textbox>
							        </td>
                                </tr>
                                <tr>
							        <td>本版规则:</td>
							        <td>
								        <cc2:textbox id="rules" runat="server" HintTitle="提示" HintInfo="支持Html" RequiredFieldType="暂无校验" width="250" height="100" 
								        TextMode="MultiLine" IsReplaceInvertedComma="false"></cc2:textbox>
							        </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" align="right" width="50%">
                             <table width="100%">
						        <tr>
							        <td style="width: 110px">交易版图标:</td>
							        <td>
								        <cc2:textbox id="icon" runat="server" HintTitle="提示" HintInfo="显示于首页论坛列表等" Width="250px" RequiredFieldType="暂无校验" 
								        IsReplaceInvertedComma="false"  MaxLength="253"></cc2:textbox>
							        </td>
						        </tr>
						        <!--tr>
							        <td>发回复金币策略:</td>
							        <td>
							            <a href="#" class="TextButton" onclick="javascript:editcredit('<%=Request.Params["fid"]%>','replycredits');" >编 辑</a>
							        </td>
						        </tr-->
						        <tr>
							        <td>允许的附件类型:</td>
							        <td>
								        <cc2:CheckBoxList id="attachextensions" runat="server" HintTitle="提示" 
								        HintInfo="允许在本版块上传的附件类型,留空为使用用户组设置, 且版块设置优先于用户组设置" RepeatColumns="4"></cc2:CheckBoxList>
							        </td>
						        </tr>
						        <!--tr>
							        <td>定期自动关闭主题:</td>
							        <td>
							            <table>
							                <tr>
							                    <td>
						                            <cc2:RadioButtonList id="autocloseoption" runat="server" RepeatColumns="1" HintInfo="设置主题关闭方式">
                                                        <asp:ListItem Value="0" Selected="True">不自动关闭</asp:ListItem>
                                                        <asp:ListItem Value="1">按发布时间</asp:ListItem>
				 		                            </cc2:RadioButtonList>
				 		                        </td>
				 		                        <td valign=bottom>
				 		                            <div id="showclose" runat="server">
				 		    	                        <cc2:TextBox id="autocloseday" runat="server" Size="4" MaxLength="3"></cc2:TextBox>
				 		    	                        <font style="font-size:12px">天自动关闭</font>	
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
	       		                </tr-->
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox" colspan="2">
                            <table width="100%">
                                <tr>
							        <td style="width: 110px">设置:</td>
							        <td>
								        <cc2:CheckBoxList id="setting" runat="server" RepeatColumns="4" >
									        <asp:ListItem Value="allowsmilies">允许使用表情符</asp:ListItem>
									        <asp:ListItem Value="allowrss">允许RSS</asp:ListItem>
									        <asp:ListItem Value="allowbbcode">允许Discuz!NT代码</asp:ListItem>
									        <asp:ListItem Value="allowimgcode">允许[img]代码</asp:ListItem>
									        <asp:ListItem Value="recyclebin">打开回收站</asp:ListItem>
									        <asp:ListItem Value="modnewposts">发帖需要审核</asp:ListItem>
									        <asp:ListItem Value="disablewatermark">禁止附件自动水印</asp:ListItem>
									        <asp:ListItem Value="inheritedmod">继承上级论坛或分类的版主设定</asp:ListItem>
									        <asp:ListItem Value="allowthumbnail">主题列表中显示缩略图</asp:ListItem>
									        <asp:ListItem Value="allowtags">允许标签</asp:ListItem>						        
								        </cc2:CheckBoxList>
							        </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </cc2:TabPage>
                <cc2:TabPage Caption="权限设定" ID="tabPage3">
                <uc1:PageInfo id="PageInfo1" runat="server" Icon="Information" Text="每个组的权限项不选择为使用用户组设置，且版块设置优先于用户组设置."></uc1:PageInfo>    			
                <table width="100%" id="powerset" align="center" class="table1" cellspacing="0" cellPadding="4"  bgcolor="#C3C7D1" runat="server">	
				    <tr>
					    <td class="td_alternating_item2" width="1%">&nbsp;</td>
					    <td class="td_alternating_item2" width="20%" style="word-wrap: break-word">&nbsp;</td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c1" onclick="seleCol('viewperm',this.checked)"/><label for="c1">浏览/交易商品</label></td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c2" onclick="seleCol('postperm',this.checked)"/><label for="c2">发布商品</label></td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c3" onclick="seleCol('replyperm',this.checked)"/><label for="c3">发表留言</label></td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c4" onclick="seleCol('getattachperm',this.checked)"/><label for="c4">下载/查看附件</label></td>
					    <td class="td_alternating_item2"><input type="checkbox" id="c5" onclick="seleCol('postattachperm',this.checked)"/><label for="c5">上传附件</label></td>
				    </tr>
                </table>
                </cc2:TabPage>
                <cc2:TabPage Caption="特殊用户" ID="tabPage4">
                    <table width="100%" align="center" class="table1" cellspacing="0" cellPadding="4"  bgcolor="#C3C7D1">
	                    <tr>
		                    <td class="category">
			                    <input title="选中/取消选中 本页所有Case" onclick="Check(this.form,this.checked,'userid')" type="checkbox" name="chkall" id="chkall" />全选/取消全选 &nbsp; 
			                    <cc2:Button id="DelButton" runat="server" Text=" 删 除 " ButtonImgUrl="../images/del.gif"></cc2:Button>
		                    </td>
	                    </tr>
                   </table>		
	
				    <cc2:datagrid id="SpecialUserList"  PageSize="25"  runat="server" Width="100%" ColumnSpan="7">
			            <Columns>
				            <asp:TemplateColumn HeaderText="选择">
				            <HeaderStyle Width="10%" /><ItemStyle width="10%"/>
					            <ItemTemplate>
						            <asp:CheckBox id="userid" runat="server"></asp:CheckBox>
						            <%# SpecialUserList.LoadSelectedCheckBox(DataBinder.Eval(Container, "DataItem.uid").ToString())%>
					            </ItemTemplate>
				            </asp:TemplateColumn>
				            <asp:TemplateColumn><HeaderStyle Width="15%" /><ItemStyle width="15%"/>
					            <HeaderTemplate>
						            用户名
					            </HeaderTemplate>
					            <ItemTemplate>
						            <input type="checkbox" onclick="CheckRow(this.form,this.checked,<%# Convert.ToInt32(DataBinder.Eval(Container, "DataItem.id")) + 2%>)" />&nbsp;
						            <%# (DataBinder.Eval(Container, "DataItem.name"))%>
					            </ItemTemplate>
				            </asp:TemplateColumn>
				            <asp:TemplateColumn ><HeaderStyle Width="15%" /><ItemStyle width="15%"/>
					            <HeaderTemplate>
						            <input type="checkbox" onclick="Check(this.form,this.checked,':viewbyuser')" />&nbsp;浏览论坛
					            </HeaderTemplate>
					            <ItemTemplate>
						            <asp:CheckBox id="viewbyuser" runat="server" Checked='<%# (DataBinder.Eval(Container, "DataItem.viewbyuser"))%>'></asp:CheckBox>
					            </ItemTemplate>
				            </asp:TemplateColumn>
				            <asp:TemplateColumn><HeaderStyle Width="15%" /><ItemStyle width="15%"/>
					            <HeaderTemplate>
						            <input type="checkbox" onclick="Check(this.form,this.checked,':postbyuser')" />&nbsp;发布商品
					            </HeaderTemplate>
					            <ItemTemplate>
						            <asp:CheckBox id="postbyuser" runat="server" Checked='<%# (DataBinder.Eval(Container, "DataItem.postbyuser"))%>'></asp:CheckBox>
					            </ItemTemplate>
				            </asp:TemplateColumn>
				            <asp:TemplateColumn ><HeaderStyle Width="15%" /><ItemStyle width="15%"/>
					            <HeaderTemplate>
						            <input type="checkbox" onclick="Check(this.form,this.checked,':replybyuser')" />&nbsp;发表留言
					            </HeaderTemplate>
					            <ItemTemplate>
						            <asp:CheckBox id="replybyuser" runat="server" Checked='<%# (DataBinder.Eval(Container, "DataItem.replybyuser"))%>'></asp:CheckBox>
					            </ItemTemplate>
				            </asp:TemplateColumn>
				            <asp:TemplateColumn ><HeaderStyle Width="15%" /><ItemStyle width="15%"/>
					            <HeaderTemplate>
						            <input type="checkbox" onclick="Check(this.form,this.checked,':getattachbyuser')" />&nbsp;下载/查看附件
					            </HeaderTemplate>
					            <ItemTemplate>
						            <asp:CheckBox id="getattachbyuser" runat="server" Checked='<%# (DataBinder.Eval(Container, "DataItem.getattachbyuser"))%>'></asp:CheckBox>
					            </ItemTemplate>
				            </asp:TemplateColumn>
				            <asp:TemplateColumn ><HeaderStyle Width="15%" /><ItemStyle width="15%"/>
					            <HeaderTemplate>
						            <input type="checkbox" onclick="Check(this.form,this.checked,':postattachbyuser')" />&nbsp;上传附件
					            </HeaderTemplate>
					            <ItemTemplate>
						            <asp:CheckBox id="postattachbyuser" runat="server" Checked='<%# (DataBinder.Eval(Container, "DataItem.postattachbyuser"))%>'></asp:CheckBox>
					            </ItemTemplate>
				            </asp:TemplateColumn>			
			            </Columns>
	                </cc2:datagrid>
                    <br />
                    <uc1:PageInfo id="info1" runat="server" Icon="Information"
                    Text="授予某些用户在本版块一些特殊权限,在下面输入框用中输入要给予特殊权限的用户列表,以&quot;,&quot;分隔"></uc1:PageInfo>
                    <table cellspacing="0" cellpadding="4" width="100%" align="center">
                        <tr>
                            <td class="panelbox" colspan="2">
                                <table width="100%">
	                                <tr>
		                                <td style="width: 110px">增加特殊用户列表:</td>
		                                <td>
			                                <uc1:TextareaResize id="UserList" runat="server" controlname="TabControl1:tabPage4:UserList" Cols="40" Rows="2"></uc1:TextareaResize>            	
			                                &nbsp;&nbsp;<cc2:Button id="BindPower" runat="server" Text=" 增加 "></cc2:Button>
		                                </td>
	                                </tr>
                                </table>
                            </td>
                        </tr>
                    </table>					
                </cc2:TabPage>
                <cc2:TabPage Caption="主题分类" ID="tabPage5">
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
					                <td style="width: 90px">启用主题分类:</td>
					                <td>
						                <cc2:RadioButtonList id="applytopictype" runat="server" HintTitle="提示" HintInfo="设置是否在本版块启用主题分类功能,您需要同时设定相应的分类选项,才能启用本功能">
							                <asp:ListItem Value="1">是</asp:ListItem>
							                <asp:ListItem Value="0">否</asp:ListItem>
						                </cc2:RadioButtonList>
					                </td>
                                </tr>
                                <tr>
					                <td>允许按类别浏览:</td>
					                <td>
						                <cc2:RadioButtonList id="viewbytopictype" runat="server" HintTitle="提示" 
						                HintInfo="如果选择&amp;quot;是&amp;quot;,用户将可以在本论坛中按照不同的类别浏览主题.注意: 本功能必须&amp;quot;启用主题分类&amp;quot;后才可使用并会加重服务器负担">
							                <asp:ListItem Value="1">是</asp:ListItem>
							                <asp:ListItem Value="0">否</asp:ListItem>
						                </cc2:RadioButtonList>
					                </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" align="right" width="50%">
                            <table width="100%">
				                <tr>
					                <td style="width: 90px">发帖必须归类:</td>
					                <td>
						                <cc2:RadioButtonList id="postbytopictype" runat="server" HintTitle="提示" HintInfo="如果选择&amp;quot;是&amp;quot;,作者发新主题时,必须选择主题对应的类别才能发表.本功能必须&amp;quot;启用主题分类&amp;quot;后才可使用">
							                <asp:ListItem Value="1">是</asp:ListItem>
							                <asp:ListItem Value="0">否</asp:ListItem>
						                </cc2:RadioButtonList>
					                </td>
				                </tr>
				                <tr>
					                <td>类别前缀:</td>
					                <td>
						                <cc2:RadioButtonList id="topictypeprefix" runat="server" HintTitle="提示" HintInfo="设置是否在主题列表中,给已分类的主题前加上类别的显示.注意: 本功能必须&amp;quot;启用主题分类&amp;quot;后才可使用">
							                <asp:ListItem Value="1">是</asp:ListItem>
							                <asp:ListItem Value="0">否</asp:ListItem>
						                </cc2:RadioButtonList>
					                </td>
				                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
		        <br />
		        <cc2:datagrid id="TopicTypeDataGrid" OnSortCommand="Sort_Grid" PageSize="10" runat="server">
			        <Columns>
				        <asp:BoundColumn DataField="id" HeaderText="id" Visible="false"></asp:BoundColumn>
				        <asp:BoundColumn DataField="name" HeaderText="主题分类"><HeaderStyle Width="15%" /></asp:BoundColumn>
				        <asp:BoundColumn DataField="description" HeaderText="描述"><HeaderStyle Width="40%" /></asp:BoundColumn>
				        <asp:BoundColumn HeaderText="不使用"><HeaderStyle Width="15%" /></asp:BoundColumn>
				        <asp:BoundColumn HeaderText="使用(平板显示)"><HeaderStyle Width="15%" /></asp:BoundColumn>	
				        <asp:BoundColumn HeaderText="使用(下拉显示)"><HeaderStyle Width="15%" /></asp:BoundColumn>				
			        </Columns>
	          </cc2:datagrid>
	          <table cellspacing="0" cellpadding="4" width="100%" align="center">
	                <tr>
                        <td class="panelbox" colspan="2">
                            <table width="100%">
			                    <tr>
				                    <td width="25%">
				                    主题分类名:
				                    <input name="typename" type="text" maxlength="200" id="typename" class="FormBase" onfocus="this.className='FormFocus';" onblur="this.className='FormBase';" maxlength="200" size="10" />
				                    </td>
				                    <td width="25%">
				                    显示顺序:
				                    <input name="typeorder" type="text" maxlength="4" id="typeorder" class="FormBase" onfocus="this.className='FormFocus';" onblur="this.className='FormBase';" maxlength="4" size="3" />
				                    </td>
				                    <td width="25%">
				                    描述:
				                    <input name="typedescription" type="text" maxlength="500" id="typedescription" class="FormBase" onfocus="this.className='FormFocus';" onblur="this.className='FormBase';" maxlength="500" size="10" />
				                    </td>
				                    <td width="25%">
				                    <button type="button" class="ManagerButton" id="AddNewRec" onclick="AddTopicType();"><img src="../images/submit.gif"/> 新增主题分类 </button>
				                    </td>
			                    </tr>
                            </table>
                        </td>
                    </tr>
                </table>
		        <div id="resultmessage" style="display:none"></div>
                </cc2:TabPage>
                <cc2:TabPage Caption="统计信息" ID="tabPage6">
		            <asp:Label id="forumsstatic" runat="server" Visible="true"></asp:Label>
					<br />
					<br /><cc2:Button ID="RunForumStatic" runat="server" ButtontypeMode="Normal" Text="统计最新信息" />
					<%=runforumsstatic%>
				</cc2:TabPage>	
                </cc2:TabControl>
					
			     <div id="topictypes" style="display:none;width:100%;">
			         <table>
			        	
						<tr>
							<td><b>显示顺序:</b></td>
							<td>
								<cc2:TextBox id="displayorder" runat="server"  CanBeNull="必填" RequiredFieldType="数据校验"></cc2:TextBox></td>
						</tr>
						<tr>
							<td><b>主题分类:</b></td>
							<td>
								<cc2:textbox id="topictypes" runat="server" RequiredFieldType="暂无校验" width="370" height="50" TextMode="MultiLine"></cc2:textbox></td>
						</tr>
						
						</table>
				   </div>
			<div class="Navbutton">
			    <cc2:Button id="SubmitInfo" runat="server" Text=" 提 交 "></cc2:Button>&nbsp;&nbsp;
			    <button onclick="window.location='forum_forumstree.aspx';" id="Button3" class="ManagerButton" type="button"><img src="../images/arrow_undo.gif"/> 返 回 </button>
			</div>
			</td>
		</tr>
		</table>
		<cc2:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc2:Hint>							
        <script type="text/javascript">
            function editcredit(fid,fieldname)
            {
                window.location="forum_ScoreStrategy.aspx?fid="+fid+"&fieldname="+fieldname;
            }
        </script>					
		</form>
		
	</body>
</html>
