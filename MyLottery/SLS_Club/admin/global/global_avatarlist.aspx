<%@ page language="c#" inherits="Discuz.Web.Admin.avatarlist, SLS.Club" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Discuz.Common" %>
<%@ Import Namespace="Discuz.Forum" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>头像列表</title>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
</head>
<body>
    <table width="100%" border="0" cellpadding="4" class="table1" cellspacing="0" bgcolor="#cccccc">
        <tr>
            <td bgcolor="#ffffff">
                <form id="avatar" method="POST" action="">
                    <table width="100%" border="0" cellspacing="0" cellpadding="4" style="font-size: 12px;">
                        <tr>
                            <%			
                                foreach (DataRow avatarfile in avatarfilelist.Rows)
                                {
                                    Response.Write("			<td width=\"25%\" align=\"center\"><img height=\"75px\" src=\"../../" + avatarfile["filenamepath"].ToString().Trim() + "\" title=\"" + avatarfile["filename"].ToString() + "\" \r\n");
                                    if (avatarfile["filename"].ToString().Trim() == avatar)
                                    {
                                        Response.Write(" style=\"border-style:dashed;border-width:2px;border-color:#FF0000\"\r\n");
                                    }	//end if
                                    Response.Write("			/><br />\r\n");
                                    Response.Write("			  <input type=\"radio\" id=\"avatarfilename" + avatarfile["_id"].ToString() + "\" onclick=check(this.value) name=\"avatarfilename\" value=\"" + avatarfile["filename"].ToString().Trim() + "\"\r\n");
                                    if (avatarfile["filename"].ToString().Trim() == avatar)
                                    {
                                        Response.Write(" checked=\"checked\"\r\n");
                                    }	//end if
                                    Response.Write("			   /></td>\r\n");
                                    if (Utils.StrToInt(avatarfile["_id"].ToString().Trim(), 0) % 4 == 0)
                                    {
                                        Response.Write("			  </tr>\r\n");
                                        Response.Write("			  <tr>\r\n");
                                    }	//end if
                                }	//end loop
                            %>
                        </tr>
                    </table>
                </form>
                <br />
                <table width="100%" border="0" cellspacing="0" cellpadding="4">
                    <tr>
                        <td align="center">
                            <button type="button" class="ManagerButton" onclick="ShowMsg(document.forms[0].avatarfilename.value);">
                                <img src="../images/ok.gif" />提 交
                            </button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function check(browser)
        { 
           document.forms[0].avatarfilename.value=browser;
        }
    </script>
    <script type="text/javaScript">
        <!--
        function ShowMsg(selectvalue)
        {
            // alert(document.forms[0].avatarfilename.value);
	        var isMSIE= (navigator.appName == "Microsoft Internet Explorer");
        	
	        if (isMSIE)
	        {
		        window.dialogArguments.ShowMsg(selectvalue);
	        }
	        else
	        {
		        window.opener.ShowMsg(selectvalue);
	        }
            window.close();
        }
        //-->
    </script>
</body>
</html>
