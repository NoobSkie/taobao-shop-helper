<%@ page language="C#" autoeventwireup="true" inherits="admin_global_global_News_Edit, SLS.Club" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />      
</head>
<body>
   
    <form id="form1" runat="server"> 
    <asp:HiddenField ID="hdIsusesId" runat="server" Value="1" />
        <div>
            <br />
            <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tr>
                    <td>
                        <font face="宋体">类别
                            <asp:DropDownList ID="ddlTypes" runat="server" Width="140px">
                            </asp:DropDownList>
                            &nbsp;&nbsp; 时间
                            <asp:TextBox ID="tbDateTime" runat="server" Width="200px"></asp:TextBox>&nbsp;&nbsp; &nbsp; &nbsp;阅读
                            <asp:TextBox ID="tbReadCount" runat="server" Width="80px"></asp:TextBox>
                            &nbsp; &nbsp; &nbsp;<asp:CheckBox ID="cbisShow" runat="server" Text="是否显示" />&nbsp;
                            <asp:CheckBox ID="cbisCanComments" runat="server" Text="允许评论" />&nbsp;
                            <asp:CheckBox ID="cbisCommend" runat="server" Text="重点推荐" />&nbsp;
                            <asp:CheckBox ID="cbisHot" runat="server" Text="热点新闻" /><asp:TextBox ID="tbID" runat="server" Visible="False"></asp:TextBox></font></td>
                </tr>
                <tr>
                    <td>
                        <font face="宋体">标题
                            <asp:TextBox ID="tbTitle" runat="server" Width="668px" MaxLength="50"></asp:TextBox></font>
                        &nbsp;&nbsp;标题颜色<asp:DropDownList ID="ddlTitleColor" runat="server">
                            <asp:ListItem>none</asp:ListItem>
                            <asp:ListItem>red</asp:ListItem>
                            <asp:ListItem>black</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            AutoPostBack="True" OnSelectedIndexChanged="rblType_SelectedIndexChanged">
                            <asp:ListItem Value="1" Selected="True">地址型</asp:ListItem>
                            <asp:ListItem Value="2">内容型</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr id="trUrl" runat="server">
                    <td>
                        地址
                        <asp:TextBox ID="tbUrl" runat="server" Width="668px" MaxLength="200"></asp:TextBox>
                    </td>
                </tr>
                <tbody id="trContent" runat="server">
                    <tr>
                        <td>
                            内容
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <FTB:FreeTextBox ID="tbContent" Width="100%" Height="400px" runat="server" SupportFolder="../FreeTextBox/"
                                ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                                ButtonSet="OfficeXP" ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}"
                                Language="zh-cn" DesignModeCss="../Style/main.css" HtmlModeCssClass="../Style/main.css">
                            </FTB:FreeTextBox>
                        </td>
                    </tr>
                </tbody>
                <tr>
                    <td>
                        <font face="宋体">使用一个新的图片
                            <input id="tbImage" style="width: 600px; height: 21px" type="file" size="80" name="tbImage" runat="server"><br />
                            <font color="#ff0000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (如果选择了新图片，下面“已存在的图片”选择将无效)</font></font></td>
                </tr>
                <tr>
                    <td>
                        <font face="宋体">使用已存在的图片
                            <asp:DropDownList ID="ddlImage" runat="server" Width="160px">
                            </asp:DropDownList>&nbsp;&nbsp;
                            <asp:CheckBox ID="cbNoEditImage" runat="server" Text="不修改图片" Checked="True"></asp:CheckBox>
                            <asp:TextBox ID="tbOldImage" runat="server" Visible="False"></asp:TextBox>
                        </font>
                    </td>
                </tr>
                <tr>
                    <td style="height: 49px" align="center">
                        <ShoveWebUI:ShoveConfirmButton ID="btnSave" runat="server" Width="60px" Height="20px" BackgroupImage="../images/buttbg.gif" Text="保存" AlertText="确信输入无误，并立即保存此资讯吗？" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
