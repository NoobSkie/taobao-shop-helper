<%@ page language="c#" inherits="Discuz.Web.Admin.shortcut, SLS.Club" autoeventwireup="false" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Import NameSpace="Discuz.Common"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>shortcut</title>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet">   
		<script type="text/javascript" src="../js/common.js"></script>
		<script type="text/javascript">       
            var currentid=0;
            var bar=0;
            var filenameliststr='<%=filenamelist%>';
            var filenamelist=new Array();
            filenamelist= filenameliststr.split('|');
            function runstatic()
            {  
                 if(filenamelist[currentid]!="")
                 {
		         document.getElementById('Layer5').innerHTML =  '<br /><table><tr><td valign=top><img border=\"0\" src=\"../images/ajax_loading.gif\"  /></td><td valign=middle style=\"font-size: 14px;\" >正在更新'+filenamelist[currentid]+'.htm模板, 请稍等...<BR /></td></tr></table><BR />';
                 document.getElementById('Layer5').style.witdh='350';
                 document.getElementById('success').style.witdh='400';
                 document.getElementById('success').style.display ="block"; 
               
                 getReturn('updatesingletemplate.aspx?path='+document.getElementById('Templatepath').value+'&filename='+filenamelist[currentid]);
                 currentid++;
                 }
                 else//filenamelist.count<=currentid
                 {
                    document.getElementById('Layer5').innerHTML="<br />模板更新成功, 请稍等...";
                    document.getElementById('success').style.display = "block";
		            count(); 
		            document.getElementById('Form1').submit();
                 }
           }
           
           function count()
           { 
		        bar=bar+2;
		        if (bar<99) {setTimeout("count()",100);} 
		        else { document.getElementById('success').style.display ="none"; } 
           }
           
           function run()
           {
              bar=0;
              document.getElementById('Layer5').innerHTML="<BR /><table><tr><td valign=top><img border=\"0\" src=\"../images/ajax_loading.gif\"  /></td><td valign=middle style=\"font-size: 14px;\" >正在提交数据, 请稍等...<BR /></td></tr></table><BR />";
              document.getElementById('success').style.display = "block";
              setInterval('runstatic()',5000); //每次提交时间为6秒
           }
           
           function validateform(theform)
           {
              document.getElementById('Form1').submit();
 	          return true;
           }
           
           function validate(theform)
           {
              if(document.getElementById('createtype').checked)
              {
                  run();
                  return false;
              }
              else
              {
 	              return true;
	          }
           }
    
   </script>
		
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
	        <tr>
                <td class="panelbox">
                    <table width="100%">
                        <tr>
                            <td style="width:120px">编辑用户:</td>
                            <td style="width: 120px"><cc1:textbox ID="Username" runat="server" RequiredFieldType="暂无校验" width="200"></cc1:textbox></td>
                            <td><cc1:Button ID="EditUser" runat="server" Text="提 交"></cc1:Button></td>
                        </tr>                        
                        <tr>
                            <td>编辑论坛:</td>
                            <td><cc1:dropdowntreelist ID="forumid" runat="server"></cc1:dropdowntreelist></td>
                            <td><cc1:Button ID="EditForum" runat="server" Text="提 交"></cc1:Button></td>
                        </tr>                        
                        <tr>
                            <td>编辑用户组:</td>
                            <td><cc1:dropdownlist id="Usergroupid" runat="server"></cc1:dropdownlist></td>
                            <td><cc1:Button id="EditUserGroup" runat="server" Text="提 交"></cc1:Button></td>
                        </tr>                        
                        <tr>
                            <td>更新缓存:</td>
                            <td></td>
                            <td><cc1:Button id="UpdateCache" runat="server" Text="提 交"></cc1:Button></td>
                        </tr>
                        <tr>
                            <td>生成模板:</td>
                            <td><cc1:dropdownlist id="Templatepath" runat="server"></cc1:dropdownlist> <input type="checkbox" id="createtype" name="createtype" >降低CPU占用</td>
                            <td><cc1:Button id="CreateTemplate" runat="server" Text="提 交" ValidateForm="true"></cc1:Button></td>
                        </tr>
                        <tr>
                            <td>更新论坛统计:</td>
                            <td></td>
                            <td><cc1:Button id="UpdateForumStatistics" runat="server" Text="提 交"></cc1:Button></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
		</form>
	</body>
</html>
