<%@ page language="c#" inherits="Discuz.Web.Admin.forum_tagmanage, SLS.Club" autoeventwireup="true" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>标签管理</title>	
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />		
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript">
		    function Check(form)
            {
                CheckAll(form);
                checkedEnabledButton(form,'tagid','DisableRec');
            }
		</script>
	</head>
	<body>
			<form id="Form1" method="post" runat="server">
			<div class="ManagerForm">
			<fieldset>
		    <legend style="background:url(../images/icons/icon32.jpg) no-repeat 6px 50%;">标签查询</legend>
			<table cellspacing="1" cellpadding="3" width="100%" align="center" class="table1">
				<tr>
					<td width="10%">标签名称:</td>
					<td width="20%"><cc1:TextBox id="tagname" runat="server" Width="150px" onBlur></cc1:TextBox></td>
					<td align="left" width="70%"><!--<cc1:Button id="search" runat="server" Text="标签查询" OnClick="search_Click"/>--></td>
				</tr>
				<br />
				<tr><td align="center" colspan="3"></td></tr>
				<tr>
				<td align="left">主题数介于:</td>
					<td colspan="2" align="left"><cc1:TextBox id="txtfrom" runat="server" Width="150px"></cc1:TextBox>--<cc1:TextBox id="txtend" runat="server" Width="150px"></cc1:TextBox></td>
                </tr>
            	<tr>
			    <td colspan="3" rowspan="2" align="left"><br />
	                <cc1:RadioButtonList id="radstatus" runat="server" RepeatColumns = "3" RepeatDirection="Vertical"  HintTitle="提示" HintInfo="请选择">
	                    <asp:ListItem Value="0"  Selected="True">全部</asp:ListItem>
		                <asp:ListItem Value="1">锁定</asp:ListItem>
		                <asp:ListItem Value="2">开放</asp:ListItem>
	                </cc1:RadioButtonList><br />
	                <cc1:Button id="searchtag" runat="server" Text="搜索标签" OnClick="searchtag_Click"/>
                </td>
                </tr>
			</table>
			</fieldset>
			</div>
			<cc1:datagrid id="DataGrid1" runat="server" IsFixConlumnControls="true" OnPageIndexChanged="DataGrid_PageIndexChanged" OnSortCommand="Sort_Grid" PageSize="15">
				<Columns>
				    <asp:TemplateColumn HeaderText="<input title='选中/取消' onclick='Check(this.form)' type='checkbox' name='chkall' id='chkall' />">
					    <HeaderStyle Width="20px" />
						<ItemTemplate>
							<input id="tagid" type="checkbox" onclick="checkedEnabledButton(this.form,'tagid','DisableRec')" value="<%# DataBinder.Eval(Container, "DataItem.tagid").ToString() %>" name="tagid"/>
						</ItemTemplate>
					</asp:TemplateColumn>
				    <asp:TemplateColumn HeaderText="标签名称">
                        <itemtemplate>
                            <a href="../../topictag-<%# DataBinder.Eval(Container, "DataItem.tagid").ToString()%>.aspx" target="_blank"><%# DataBinder.Eval(Container, "DataItem.tagname").ToString()%></a> | <%# DataBinder.Eval(Container, "DataItem.fcount").ToString()%>
					        <%# DataGrid1.LoadSelectedCheckBox(DataBinder.Eval(Container, "DataItem.tagid").ToString())%>
                        </itemtemplate>
                    </asp:TemplateColumn>
					<asp:BoundColumn DataField="orderid" HeaderText="显示顺序"></asp:BoundColumn>
					<asp:BoundColumn DataField="color" HeaderText="颜色"></asp:BoundColumn>
				</Columns>
			</cc1:datagrid>
			<cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
            <p style="text-align:right;">
                <cc1:Button ID="savetags" runat="server" Text="保存标签修改" OnClick="savetags_Click"></cc1:Button>&nbsp;&nbsp;
                <cc1:Button id="DisableRec" runat="server" Text=" 禁 用 " Enabled="false" ButtonImgUrl="../images/del.gif" OnClick="DisableRec_Click"></cc1:Button>
            </p>
		</form>
		
	</body>
</html>
