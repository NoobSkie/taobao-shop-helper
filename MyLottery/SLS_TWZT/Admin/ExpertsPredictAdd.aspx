<%@ page language="C#" autoeventwireup="true" CodeFile="ExpertsPredictAdd.aspx.cs" inherits="Admin_ExpertsPredictAdd" enableEventValidation="false" %>

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
    <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
            <tr>
                <td style="text-align: left; padding-bottom: 15px; padding-top: 15px;">
                彩&nbsp;&nbsp;&nbsp; 种
                   <asp:DropDownList ID="ddlLotteries" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    用 户 名
                        <asp:TextBox ID="tbName" runat="server" Width="141px" MaxLength="50"></asp:TextBox>
                        <asp:CheckBox
                        ID="cbisShow" runat="server" Text="是否显示" Checked="True"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td>
                    <font face="宋体">使用已存在的图片
                        <asp:DropDownList ID="ddlImage" runat="server" Width="250px">
                        </asp:DropDownList>
                    </font>
                </td>
            </tr>
             <tr>
                <td>
                   专家描述
                        <asp:TextBox ID="tbDescription" runat="server" Width="400px" MaxLength="150" 
                        Height="47px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
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
