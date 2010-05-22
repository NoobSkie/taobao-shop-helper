<%@ page language="C#" autoeventwireup="true" CodeFile="QuestionAnswer.aspx.cs" inherits="Admin_QuestionAnswer" validaterequest="false" enableEventValidation="false" %>

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
            <table id="Table1" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tr>
                    <td>
                        <font face="宋体"><strong>时间</strong>
                            <asp:TextBox ID="tbDateTime" runat="server" Width="200px"></asp:TextBox>
                            <asp:TextBox ID="tbID" runat="server" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="tbUserID" runat="server" Visible="False"></asp:TextBox>&nbsp; <strong>电话</strong>&nbsp;
                            <asp:TextBox ID="tbTelphone" runat="server" Width="200px" MaxLength="50"></asp:TextBox></font></td>
                </tr>
                <tr>
                    <td>
                        <font face="宋体"><strong>问题</strong></font></td>
                </tr>
                <tr>
                    <td>
                        <font face="宋体">
                            <asp:Label ID="labContent" runat="server"></asp:Label></font></td>
                </tr>
                <tr>
                    <td>
                        <font face="宋体"><strong>回答</strong></font></td>
                </tr>
                <tr>
                    <td align="center">
                        <FTB:FreeTextBox ID="tbAnswer" Width="100%" Height="400px" runat="server" SupportFolder="../FreeTextBox/" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print" ButtonSet="OfficeXP" ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}" Language="zh-cn" DesignModeCss="../Style/main.css" HtmlModeCssClass="../Style/main.css">
                        </FTB:FreeTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 49px" align="center">
                        <ShoveWebUI:ShoveConfirmButton ID="btnAnswer" runat="server" Width="60px" Height="20px" BackgroupImage="../Images/Admin/buttbg.gif" Text="立即答复" AlertText="确信书写无误并立即答复吗？" OnClick="btnAnswer_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
