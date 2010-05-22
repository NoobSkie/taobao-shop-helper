<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="cc2" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.ratescorelog, SLS.Club" %>
<%@ Register TagPrefix="cc4" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
    <head>
		<title>用户评分日志</title>
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />		
		<link href="../styles/calendar.css" type="text/css" rel="stylesheet" />
	 	<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
	    <script type="text/javascript" src="../js/common.js"></script>	    
        <script type="text/javascript" src="../js/modalpopup.js"></script>
        <script type="text/javascript">
            function Check(form)
            {
                CheckAll(form);
                checkedEnabledButton(form,'id','DelRec');
            }
        </script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
		    <cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
			<div class="ManagerForm">
		    <fieldset>
		        <legend style="background:url(../images/icons/icon19.jpg) no-repeat 6px 50%;">搜索日志</legend>
		        <table cellspacing="0" cellpadding="4" width="100%" align="center">
		            <tr>
                        <td class="panelbox" colspan="2">
                            <table width="100%">
                                <tr>
					                <td style="width: 90px">发生时间范围:</td>
					                <td>
					                    <cc4:Calendar id="postdatetimeStart" runat="server" ReadOnly="True" ScriptPath="../js/calendar.js"></cc4:Calendar> -
						                <cc4:Calendar id="postdatetimeEnd" runat="server" ReadOnly="True" ScriptPath="../js/calendar.js"></cc4:Calendar>
						            </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
					                <td style="width: 90px">搜索内容:</td>
					                <td><cc2:TextBox id="others" runat="server" RequiredFieldType="暂无校验" width="200"></cc2:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td class="panelbox" align="right" width="50%">
                            <table width="100%">
                                <tr>
					                <td style="width: 90px">管理员名称:<br /></td>
					                <td>
					                    <cc2:TextBox id="Username" runat="server" HintTitle="提示" HintInfo="多用户名中间请用半角逗号 &amp;quot;,&amp;quot; 分割" RequiredFieldType="暂无校验" width="200">
					                    </cc2:TextBox>
					                </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2"><cc1:Button ID="SearchLog" runat="server" Text="开始搜索" ButtonImgUrl="../images/search.gif"></cc1:Button></td>
                    </tr>
                </table>
		    </fieldset>
		    </div>	

		    <cc1:datagrid id="DataGrid1" runat="server" OnPageIndexChanged="DataGrid_PageIndexChanged" PageSize="15" >
			      <Columns>
				    <asp:TemplateColumn HeaderText="<input title='选中/取消' onclick='Check(this.form)' type='checkbox' name='chkall' id='chkall' />">
				        <HeaderStyle Width="20px" />
					    <ItemTemplate>
						    <input id="id" type="checkbox" onclick="checkedEnabledButton(this.form,'id','DelRec')" value="<%# DataBinder.Eval(Container, "DataItem.id").ToString() %>"	name="id" />
					    </ItemTemplate>
				    </asp:TemplateColumn>					
				    <asp:BoundColumn DataField="id" HeaderText="id [递增]" Visible="false" ></asp:BoundColumn>
				    <asp:BoundColumn DataField="username" HeaderText="用户名" ></asp:BoundColumn>
				    <asp:BoundColumn DataField="grouptitle" HeaderText="用户组"></asp:BoundColumn>
				    <asp:BoundColumn DataField="postdatetime" HeaderText="时间" ></asp:BoundColumn>
				    <asp:BoundColumn DataField="poster"  HeaderText="被评价用户" ></asp:BoundColumn>				
				    <asp:TemplateColumn HeaderText="扩展金币名">
					    <ItemTemplate>
						    <%# ExtcreditsStr(DataBinder.Eval(Container, "DataItem.extcredits").ToString(),DataBinder.Eval(Container, "DataItem.score").ToString())%>
					    </ItemTemplate>
				    </asp:TemplateColumn>
				    <asp:BoundColumn DataField="score"  HeaderText="分数" visible="false"></asp:BoundColumn>
				    <asp:BoundColumn DataField="title"  HeaderText="标题"></asp:BoundColumn>
				    <asp:BoundColumn DataField="reason"  HeaderText="原因"></asp:BoundColumn>
			     </Columns>
			</cc1:datagrid>
		    <p style="text-align:right;">
				<input type="radio" name="deleteMode" checked="checked" onclick="changeDeleteModeState(1,this.form)" value="chkall" />
				<input title="选中/取消" type="checkbox" name="chkall1" id="chkall1" onclick="document.getElementById('chkall').click()" />全选/取消全选
				&nbsp;&nbsp;<input type="radio" name="deleteMode" onclick="changeDeleteModeState(2,this.form)" value="deleteNum">
				保留最新<cc2:TextBox id="deleteNum" runat="server" RequiredFieldType="暂无校验" size="5" MaxLength="5" Enabled="true"></cc2:TextBox>条记录
				&nbsp;&nbsp;<input type="radio" name="deleteMode" onclick="changeDeleteModeState(3,this.form)" value="deleteFrom">
				删除<cc4:Calendar id="deleteFrom" runat="server" ReadOnly="True" ScriptPath="../js/calendar.js" Enabled="False"></cc4:Calendar>之前的记录
				&nbsp;&nbsp;<cc1:Button id="DelRec" runat="server" Text=" 删 除 "   ButtonImgUrl="../images/del.gif" Enabled="false"></cc1:Button>
			</p>
		</form>
		
	</body>
</html>
