<%@ page language="C#" autoeventwireup="true" CodeFile="LotteryInformation.aspx.cs" inherits="Admin_LotteryInformation" validaterequest="false" enableEventValidation="false" %>

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
                    <td style="height: 30px">
                        彩种
                        <asp:DropDownList ID="ddlLottery" runat="server" Width="145px" AutoPostBack="True" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <ShoveWebUI:ShoveTabView ID="tv" runat="server" Height="510px" Width="100%" SupportDir="../ShoveWebUI_client" SelectedTabCSSClass="" UnSelectedTabCSSClass="">
                            <ShoveWebUI:ShoveTabPage id="p1" Text="玩法规则" ScrollBars="Auto" Height="100%" Width="100%" runat="server">
                                <FTB:FreeTextBox ID="tbExplain" Width="100%" Height="400px" runat="server" SupportFolder="../FreeTextBox/" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print" ButtonSet="OfficeXP" ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}" Language="zh-cn" DesignModeCss="../Style/main.css" HtmlModeCssClass="../Style/main.css">
                                </FTB:FreeTextBox>
                            </ShoveWebUI:ShoveTabPage>
                            <ShoveWebUI:ShoveTabPage id="p2" Text="方案书写规则" ScrollBars="Auto" Height="100%" Width="100%" runat="server">
                                <FTB:FreeTextBox ID="tbLotteryExemple" Width="100%" Height="400px" runat="server" SupportFolder="../FreeTextBox/" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print" ButtonSet="OfficeXP" ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}" Language="zh-cn" DesignModeCss="../Style/main.css" HtmlModeCssClass="../Style/main.css">
                                </FTB:FreeTextBox>
                            </ShoveWebUI:ShoveTabPage>
                            <ShoveWebUI:ShoveTabPage id="p3" Text="用户电话短信投注协议" ScrollBars="Auto" Height="100%" Width="100%" runat="server">
                                <FTB:FreeTextBox ID="tbAgreement" Width="100%" Height="400px" runat="server" SupportFolder="../FreeTextBox/" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print" ButtonSet="OfficeXP" ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}" Language="zh-cn" DesignModeCss="../Style/main.css" HtmlModeCssClass="../Style/main.css">
                                </FTB:FreeTextBox>
                            </ShoveWebUI:ShoveTabPage>
                            <ShoveWebUI:ShoveTabPage id="p4" Text="开奖公告模板" ScrollBars="Auto" Height="100%" Width="100%" runat="server">
                                <FTB:FreeTextBox ID="tbOpenAfficheTemplate" Width="100%" Height="400px" runat="server" SupportFolder="../FreeTextBox/" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print" ButtonSet="OfficeXP" ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}" Language="zh-cn" DesignModeCss="../Style/main.css" HtmlModeCssClass="../Style/main.css">
                                </FTB:FreeTextBox>
                            </ShoveWebUI:ShoveTabPage>
                        </ShoveWebUI:ShoveTabView>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 60px">
                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" AlertText="您确信输入无误，并立即保存吗？" Text="保存" BackgroupImage="../Images/Admin/buttbg.gif" Width="60px" Height="20px" OnClick="btnOK_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
