<%@ page language="c#" inherits="Discuz.Web.Admin.forumaggset, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="AjaxTopicInfo" Src="../UserControls/AjaxTopicInfo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>websitesetting</title>
		<link href="../styles/gridStyle.css" type="text/css" rel="stylesheet" />
		<link href="../styles/calendar.css" type="text/css" rel="stylesheet" />
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />		
		<script type="text/javascript" src="../js/common.js"></script>
		<script type="text/javascript" src="../js/AjaxHelper.js"></script>
	    <script type="text/javascript" src="../js/calendar.js"></script>
	    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
	    <script type="text/javascript" src="../js/draglist.js"></script>
        <link href="../styles/draglist.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript">
            function validate(theform)
            {
                var idColl = $("dom0").getElementsByTagName("input");
                var idlist = "";
                for(i = 0 ; i < idColl.length ; i++)
                {
                    if(idlist=="")
                    {
                       idlist = idColl[i].value;
                    }
                    else
                    {
                       idlist = idlist + "," + idColl[i].value;
                    }
                }
                $("forumtopicstatus").value = idlist;
                return true;
            } 
        </script>
    </head>
	<body >
		<form id="Form1" runat="server">
		<div class="ManagerForm">
		<fieldset>		
		<legend style="background:url(../images/legendimg.jpg) no-repeat 6px 50%;">聚合首页BBS显示设置</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td  class="panelbox" width="50%" align="left">
                    <table width="100%">
                        <tr>
			                <td style="width: 100px">主题显示方式:</td>
                            <td>
                                <cc1:DropDownList ID="showtype" runat="server">
                                    <asp:ListItem Value="1">按最新主题显示</asp:ListItem>
                                    <asp:ListItem Value="2">按精华主题显示</asp:ListItem>
                                    <asp:ListItem Value="3">按版块列表显示</asp:ListItem>
                                </cc1:DropDownList>                        
                            </td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" width="50%" align="right">
                    <table width="100%">
                        <tr>
                            <td style="width: 100px">显示主题条数:</td>
                            <td>
                                <cc1:TextBox id="topnumber" runat="server" Width="40" MaxLength="2" RequiredFieldType="数据校验" HintTitle="提示" HintInfo="当显示方式为&amp;quot;按版块列表显示&amp;quot;时, 则当前文本框数据无效!"></cc1:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr><td align="center" colspan="2"><cc1:Button ID="SaveTopicDisplay" runat="server" Text=" 保存 " OnClick="SaveTopicDisplay_Click" /></td></tr>
        </table>
		</fieldset>
		<fieldset>
		<legend style="background:url(../images/legendimg.jpg) no-repeat 6px 50%;">搜索帖子</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td  class="panelbox" width="50%" align="left">
                    <table width="100%">
                        <tr>
			                <td style="width: 100px">所在表:</td>
                            <td><cc1:DropDownList ID="tablelist" runat="server" /></td>
                        </tr>
                        <tr>
					        <td>所在论坛:</td>
					        <td><cc1:dropdowntreelist id="forumid" runat="server"></cc1:dropdowntreelist></td>
                        </tr>
                        <tr>
					        <td>标题关键字:</td>
					        <td><cc1:TextBox id="tbtitle" runat="server" HintTitle="提示" HintInfo="多关键字之间请用半角逗号 &amp;quot;,&amp;quot; 分割" Width="150px" RequiredFieldType="暂无校验"></cc1:TextBox></td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" width="50%" align="right">
                    <table width="100%">
				        <tr>
					        <td style="width: 100px">原帖作者:</td>
					        <td><cc1:TextBox id="poster" runat="server" HintTitle="提示" HintInfo="多个用户名之间请用半角逗号&amp;quot;,&amp;quot; 分割" Width="150px" RequiredFieldType="暂无校验"></cc1:TextBox></td>
				        </tr>
				        <tr>
					        <td>帖子发表时间范围:</td>
					        <td>
                                开始日期:<cc1:Calendar id="postdatetimeStart" runat="server" HintTitle="提示" HintInfo="格式 yyyy-mm-dd, 不限制请留空" ReadOnly="False" ScriptPath="../js/calendar.js" HintLeftOffSet="-20" HintHeight="0"></cc1:Calendar><br />
                                结束日期:<cc1:Calendar ID="postdatetimeEnd" runat="server" HintInfo="格式 yyyy-mm-dd, 不限制请留空" HintTitle="提示" ReadOnly="False" ScriptPath="../js/calendar.js" HintLeftOffSet="-20" HintHeight="0"/>
				             </td>
				        </tr>
                        <tr>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr><td align="center" colspan="2"><cc1:Button id="SearchTopicAudit" runat="server" Text=" 搜索符合条件的帖子 "></cc1:Button></td></tr>
        </table>
	    </fieldset>
	    </div>
		<div id="topiclistgrid" style="width:98%;margin:0 auto;"><uc1:AjaxTopicInfo id="AjaxTopicInfo1" runat="server"></uc1:AjaxTopicInfo></div>
		<br />
		<span>&nbsp;&nbsp;<b>已选择主题列表</b></span>
		<div class="content">
	            <div class="left" id="dom0">
	                <asp:Literal id="forumlist" runat="server"></asp:Literal>
	            </div>
         </div>
         <br />
		<table class="table1" cellspacing="0" cellpadding="4" width="100%">
            <tr><td align="center">
            <cc1:Button id="SaveTopic" runat="server" Text=" 保存 "></cc1:Button>
            </td></tr> 
		  </table>
		  <cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		  
		  <input id="forumtopicstatus" type="hidden" runat="server" />
		</form>
		
	</body>
</html>


