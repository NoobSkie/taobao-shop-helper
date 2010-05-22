<%@ page language="C#" autoeventwireup="true" CodeFile="InputOpenAffiche2.aspx.cs" inherits="Admin_InputOpenAffiche2" validaterequest="false" enableEventValidation="false" %>

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
                <td style="height: 21px">
                    请选择
                    <asp:DropDownList ID="ddlLottery" runat="server" AutoPostBack="True" Width="140px"
                        OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:DropDownList ID="ddlIsuse" runat="server" AutoPostBack="True" Width="120px"
                        OnSelectedIndexChanged="ddlIsuse_SelectedIndexChanged">
                    </asp:DropDownList>
                    <span style="margin-left: 30px;"><a href="InputOpenAffiche.aspx">录入已开启彩种开奖公告</a></span>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <FTB:FreeTextBox ID="tbOpenAffiche" Width="100%" Height="340px" runat="server" SupportFolder="../FreeTextBox/"
                        ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                        ButtonSet="OfficeXP" ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}"
                        Language="zh-cn" DesignModeCss="../Style/main.css" HtmlModeCssClass="../Style/main.css">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                    上传开奖视频文件
                    <input id="fileVideo" runat="server" name="fileVideo" style="width: 500px; height: 21px"
                        type="file" />
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 50px">
                    <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" BackgroupImage="../Images/Admin/buttbg.gif"
                        Width="60px" Height="20px" Text="保存" AlertText="确信输入无误，并立即保存吗？" OnClick="btnOK_Click" />
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
