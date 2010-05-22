<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.auditpost, SLS.Club" %>
<%@ Register TagPrefix="uc1" TagName="AjaxPostInfo" Src="../UserControls/AjaxPostInfo.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>审核帖子</title>
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
	    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" /> 		
		<script type="text/javascript" src="../js/common.js"></script>
		<script type="text/javascript" src="../js/AjaxHelper.js"></script>		
        <script type="text/javascript">	
            function  LoadInfo(istopic,pid,tid)
            {
                AjaxHelper.Updater('../UserControls/AjaxPostInfo','AjaxPostInfo','istopic='+istopic+'&pid='+pid+'&tid='+tid);
                document.getElementById('PostInfo').style.display = "block";
            }
          
            function Check(form)
            {
                CheckAll(form);
                checkedEnabledButton(form,'pid','SelectPass','SelectDelete');
            }
        </script>		
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<table class="table1" cellSpacing="0" cellPadding="4" width="100%" align="center">
				<tr>
					<td class="multi"><b>当前帖子表:</b>
						<cc1:DropDownList id="postlist" runat="server"></cc1:DropDownList></td>
				</tr>
			</table>
			
			<cc1:datagrid id="DataGrid1" runat="server" OnPageIndexChanged="DataGrid_PageIndexChanged" OnSortCommand="Sort_Grid">
				<Columns>
				    <asp:TemplateColumn HeaderText="<input title='选中/取消' onclick='Check(this.form)' type='checkbox' name='chkall' id='chkall'>">
				        <HeaderStyle Width="20px" />
						<ItemTemplate>
							<input id="pid" type="checkbox" onclick="checkedEnabledButton(this.form,'pid','SelectPass','SelectDelete')" value="<%# DataBinder.Eval(Container, "DataItem.pid").ToString() %>|<%# DataBinder.Eval(Container, "DataItem.tid").ToString() %>" name="pid" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="pid" SortExpression="pid" HeaderText="帖子ID" Visible="false"></asp:BoundColumn>
					 <asp:TemplateColumn HeaderText="标题">
					    <ItemStyle HorizontalAlign="Left" />
						<ItemTemplate>
						    <a href="javascript:void(0);" onclick="javascript:LoadInfo('false','<%# DataBinder.Eval(Container, "DataItem.pid").ToString() %>','<%# DataBinder.Eval(Container, "DataItem.tid").ToString().Trim() %>');">
						    <%# DataBinder.Eval(Container, "DataItem.title").ToString().Trim() == "" ? "(无标题)" : DataBinder.Eval(Container, "DataItem.title").ToString().Trim()%></a>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="postdatetime" SortExpression="postdatetime" HeaderText="发布日期"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="发帖人">
                        <itemtemplate>
                            <%# (DataBinder.Eval(Container, "DataItem.posterid").ToString() != "-1") ? "<a href='../../userinfo.aspx?userid=" + DataBinder.Eval(Container, "DataItem.posterid").ToString() + "' target='_blank'>" + DataBinder.Eval(Container, "DataItem.poster").ToString() + "</a>" : DataBinder.Eval(Container, "DataItem.poster").ToString()%>
						</itemtemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="attachment" SortExpression="attachment" HeaderText="附件数"></asp:BoundColumn>
					<asp:BoundColumn DataField="rate" SortExpression="rate" HeaderText="评分分数"></asp:BoundColumn>
					<asp:BoundColumn DataField="ratetimes" SortExpression="ratetimes" HeaderText="评分次数"></asp:BoundColumn>
				</Columns>
			</cc1:datagrid>
			<p style="text-align:right;">
			    <cc1:Button id="SelectPass" runat="server" Text=" 通 过 " Enabled="false"></cc1:Button>&nbsp;&nbsp;
				<cc1:Button id="SelectDelete" runat="server" Text=" 删 除 " ButtonImgUrl="../images/del.gif" Enabled="false"></cc1:Button>
			</p>			
		
			<div id="AjaxPostInfo" style="OVERFLOW-Y: auto;" valign="top">
				<uc1:AjaxPostInfo id="AjaxPostInfo1" runat="server"></uc1:AjaxPostInfo>
			</div>			
			
			<div id="Div1" style="display:none">
			<tr>
			    <td bgColor="#f8f8f8" colSpan="2"><asp:literal id="msg" runat="server" Text="没有等待审核新主题" Visible="False"></asp:literal></td>
			</tr>
			</div>
		</form>
		
	</body>
</html>
