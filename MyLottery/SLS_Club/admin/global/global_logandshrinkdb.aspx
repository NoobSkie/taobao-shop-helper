<%@ page language="c#" inherits="Discuz.Web.Admin.logandshrinkdb, SLS.Club" %>

<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>logandshrinkdb</title>
    <script type="text/javascript" src="../js/common.js"></script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/modalpopup.js"></script>
</head>
<body>
    <div class="ManagerForm">
        <form id="Form1" method="post" runat="server">
            <fieldset>
                <legend style="background: url(../images/icons/icon26.jpg) no-repeat 6px 50%;">日志管理</legend>
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
	                <tr>
	                    <td  class="panelbox" align="left" width="50%">
	                        <table width="100%">
	                            <tr>
                                    <td style="width: 80px">数据库名称:</td>
                                    <td>
                                        <cc1:TextBox ID="strDbName" runat="server" Text="" CanBeNull="必填" Width="100px" RequiredFieldType="暂无校验" Enabled="false"></cc1:TextBox>
                                    </td>
	                            </tr>
	                        </table>
	                    </td>
	                    <td align="right" class="panelbox" width="50%">
	                        <table width="100%">
	                            <tr>
                                    <td style="width: 100px">要收缩的大小范围:</td>
                                    <td>
                                        <cc1:TextBox ID="size" runat="server" HintTitle="提示" HintInfo="此值仅供程序压缩时进行参考" Text="0" Width="100px" RequiredFieldType="数据校验"></cc1:TextBox>单位: M (兆字节)
                                    </td>
	                            </tr>
	                        </table>
	                    </td>
	                </tr>
	                <tr>
	                    <td class="panelbox" colspan="2" align="center">
                            <cc1:Button ID="ClearLog" runat="server" Text="清空日志"></cc1:Button>&nbsp;
                            <cc1:Button ID="ShrinkDB" runat="server" Text="收缩数据库"></cc1:Button>
	                    </td>
	                </tr>
	            </table>
            </fieldset>
            <cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
        </form>
    </div>
    
</body>
</html>
