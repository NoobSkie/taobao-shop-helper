<%@ page language="c#" inherits="Discuz.Web.Admin.postgrid, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
  <head>
		<title>postgrid</title>
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />  
        <script type="text/javascript" src="../js/common.js"></script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
		    <cc1:datagrid id="DataGrid1" runat="server" OnPageIndexChanged="DataGrid_PageIndexChanged" >
			    <Columns>				
			  	    <asp:BoundColumn DataField="pid" SortExpression="pid" HeaderText="帖子ID" Visible="false" ></asp:BoundColumn>
				    <asp:BoundColumn DataField="title" HeaderText="显示顺序"></asp:BoundColumn>
				     <asp:TemplateColumn HeaderText="标题">
				  	    <ItemTemplate>
			         	    <a href="../../showtopic.aspx?topicid=<%=Request["tid"]%>"  target="_blank"><%# DataBinder.Eval(Container, "DataItem.title").ToString()%></a>
					    </ItemTemplate>
				    </asp:TemplateColumn>					
				    <asp:BoundColumn DataField="postdatetime"  HeaderText="发布日期"></asp:BoundColumn>
				    <asp:BoundColumn DataField="poster"  HeaderText="发帖人" ></asp:BoundColumn>					
				     <asp:TemplateColumn HeaderText="标题">
				  	    <ItemTemplate>
			         	    <%# Invisible(DataBinder.Eval(Container, "DataItem.invisible").ToString())%>
					    </ItemTemplate>
				    </asp:TemplateColumn>					
				    <asp:BoundColumn DataField="attachment" HeaderText="附件数"></asp:BoundColumn>
				    <asp:BoundColumn DataField="rate" HeaderText="评分分数"></asp:BoundColumn>
				    <asp:BoundColumn DataField="ratetimes" HeaderText="评分次数"></asp:BoundColumn>							
			    </Columns>
		    </cc1:datagrid>
		<br />
		</form>
		
	</body>
</html>
