<%@ page language="C#" autoeventwireup="true" CodeFile="ExpertsPredictNewsEdit.aspx.cs" inherits="Admin_ExpertsPredictNewsEdit" enableEventValidation="false" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:HiddenField ID="hidID" runat="server" />
     <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
            <tr>
                <td style="text-align: left; padding-bottom: 15px; padding-top: 15px;">
                专&nbsp;&nbsp;&nbsp; 家
                   <asp:DropDownList ID="ddlExpertsPredictNews" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                      <asp:CheckBox ID="cbisShow" runat="server" Text="是否显示" Checked="True"></asp:CheckBox>
                      <asp:CheckBox ID="cbisWinning" runat="server" Text="是否中奖" Checked="True"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td>
                    文字描述
                    <asp:TextBox ID="tbDescription" runat="server" Width="400px" MaxLength="150" Height="47px"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <%--<tr>
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
                    链接地址
                    <asp:TextBox ID="tbUrl" runat="server" Width="400px" MaxLength="150"></asp:TextBox>
                </td>
            </tr>--%>
            <tbody id="trContent" runat="server">
                <tr>
                    <td>
                        <font face="宋体">内容</font>
                    </td>
                </tr>
                <tr>
                    <td>
                        <ftb:freetextbox id="tbContent" width="100%" height="360px" runat="server" supportfolder="../FreeTextBox/"
                            toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                            buttonset="OfficeXP" imagegalleryurl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}"
                            language="zh-cn" designmodecss="../Style/main.css" htmlmodecssclass="../Style/main.css">
                        </ftb:freetextbox>
                    </td>
                </tr>
            </tbody>
            <tr>
                <td style="height: 50px" align="center">
                    <ShoveWebUI:ShoveConfirmButton ID="btnAdd" runat="server" Width="60px" Height="20px"
                        BackgroupImage="../Images/Admin/buttbg.gif" Text="保存" OnClick="btnAdd_Click" />
                    <span style="margin-left: 100px;"></span>
                    <ShoveWebUI:ShoveConfirmButton ID="btnCancel" runat="server" Width="60px" Height="20px"
                        BackgroupImage="../Images/Admin/buttbg.gif" Text="取消" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
