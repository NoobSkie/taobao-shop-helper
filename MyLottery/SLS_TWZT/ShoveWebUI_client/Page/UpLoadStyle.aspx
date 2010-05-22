<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.UpLoadStyle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传下载站点样式文件</title>
    <link href="../Style/css.css" type="text/css" rel="Stylesheet" />
    <base target="_self" />
</head>
<body style="background-color: buttonface;" onunload='window.returnValue = document.getElementById("tbResult").value;'>
    <form id="form1" runat="server" style="text-align: center;">
    <div>
        <br />
        <br />
        <strong>请选择上传的样式文件（*.css）：</strong><br />
        <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;<asp:Label runat="server" ForeColor="red" ID="MessageBox"></asp:Label><br />
        <br />
        <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" Width="82px" />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <input type="button" value="关闭窗口" onclick="javascript:window.close();" />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <asp:HyperLink ID="hlDownload" runat="server" Text="点击此处下载样式文件" ForeColor="Red" NavigateUrl="#" Target="frmDownload" />
        <br />
        <asp:TextBox ID="tbSiteID" runat="server" Visible="false" />
        <input type="hidden" id="tbResult" runat="server" value="" />
        <iframe id="frmDownload" name="frmDownload" height="0px" width="0px"></iframe>
    </div>
    </form>
</body>
</html>
