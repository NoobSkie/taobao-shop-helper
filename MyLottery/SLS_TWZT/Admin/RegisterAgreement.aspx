<%@ page language="C#" autoeventwireup="true" CodeFile="RegisterAgreement.aspx.cs" inherits="Admin_RegisterAgreement" validaterequest="false" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table id="Table1" cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
                <tr>
                    <td>
                        <FTB:FreeTextBox ID="tbContent" Width="100%" Height="500px" runat="server" SupportFolder="../FreeTextBox/" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print" ButtonSet="OfficeXP" ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}" Language="zh-cn" DesignModeCss="../Style/main.css" HtmlModeCssClass="../Style/main.css">
                        </FTB:FreeTextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 60px">
                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" AlertText="您确信输入无误，并立即保存吗？" Text="保存" BackgroupImage="../Images/Admin/buttbg.gif" Width="60px" Height="20px" OnClick="btnOK_Click" /></td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
