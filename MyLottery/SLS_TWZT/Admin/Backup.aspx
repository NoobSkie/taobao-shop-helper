<%@ page language="C#" autoeventwireup="true" CodeFile="Backup.aspx.cs" inherits="Admin_Backup" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Table1" cellspacing="0" cellpadding="0" width="672" height="117" align="center" border="0" style="width: 672px; height: 117px">
                <tr>
                    <td valign="top">
                        <p>
                            <font face="宋体"><strong>
                                <br />
                                &nbsp; &nbsp; “备份数据表”功能可以将数据库的所有数据通过转换为 XML 格式的文本，再经过 Zip 压缩技术进行压缩成二进制的流文件，并下载到客户机器保存。<br />
                                <br />
                                &nbsp; &nbsp; &nbsp; “备份数据表”的备份工作十分必要，当发生服务器意外、网络意外等等事故时，从备份文件我们恢复到备份时的数据状态，使损失减少到最小。所以，请每天进行 <span style="color: red">1</span> 次此“备份数据表”操作，并将下载的文件保存在安全的媒介上。<br />
                                <br />
                                &nbsp; &nbsp; <span style="color: red">提醒：由于备份的时候，会造成服务器瞬间繁忙而影响其他用户的正常访问，所以请尽量选择闲时进行备份。也不要随意无休止的使用本系统。当系统检测到无休止的随意大量进行无意义的备份操作时，网站可能会出现短时关闭现象。<br />
                                    <br />
                                    <span style="color: #000000">&nbsp; &nbsp; “备份数据库”将压缩、截断数据库访问、更新日志。此操作不仅备份数据表，同时备份整个数据库。此备份方法不要经常使用，因为它很消耗服务器资源。建议每周执行 <span style="color: #ff0000">1</span> 次。</span></span></strong></font></p>
                    </td>
                </tr>
                <tr>
                    <td style="height: 80px" align="center">
                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" Text="备份表" AlertText="确认要备份数据表吗？" OnClick="btnOK_Click" />
                        &nbsp;
                        <ShoveWebUI:ShoveConfirmButton ID="btnOK_2" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" Text="备份数据库" AlertText="确认要备份数据库吗？" OnClick="btnOK_2_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
