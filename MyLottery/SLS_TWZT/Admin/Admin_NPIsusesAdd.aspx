<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" validaterequest="false" CodeFile="Admin_NPIsusesAdd.aspx.cs" inherits="Admin_Admin_NPIsusesAdd" %>
    
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="Table1" cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
            <tr>
                <td align="center">
                    <div style="width: 645px; position: relative; height: 150px">
                       
                        <asp:Label ID="Label3" Style="z-index: 104; left: 24px; position: absolute; top: 72px"
                            runat="server">截止时间</asp:Label>
                        <asp:Label ID="Label2" Style="z-index: 103; left: 24px; position: absolute; top: 40px"
                            runat="server">开始时间</asp:Label>
                        <asp:Label ID="Label1" Style="z-index: 102; left: 24px; position: absolute; top: 8px"
                            runat="server"> 彩友报期号</asp:Label>
                           
                        <asp:TextBox ID="tbEndTime" Style="z-index: 101; left: 88px; position: absolute;
                            top: 72px" runat="server" Width="232px" MaxLength="19"></asp:TextBox>
                        <asp:TextBox ID="tbIsuse" Style="z-index: 100; left: 88px; position: absolute; top: 8px"
                            runat="server" Width="128px" MaxLength="10"></asp:TextBox>
                        <asp:TextBox ID="tbStartTime" Style="z-index: 105; left: 88px; position: absolute;
                            top: 40px" runat="server" Width="232px" MaxLength="19"></asp:TextBox>
                        <asp:Label ID="Label4" Style="z-index: 106; left: 344px; position: absolute; top: 40px"
                            runat="server" ForeColor="Red">时间格式: 0000-00-00</asp:Label>
                       
                        <ShoveWebUI:ShoveConfirmButton ID="btnAdd" Style="z-index: 106; left: 344px; position: absolute;
                            top: 104px" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px"
                            Height="20px" AlertText="确认书写无误并增加一期吗？" Text="增加" onclick="btnAdd_Click" /> 
                     
                        <asp:LinkButton ID="btnBack" Style="z-index: 109; left: 576px; position: absolute;
                            top: 8px" runat="server" onclick="btnBack_Click">【返回】</asp:LinkButton>
                          
                    </div> 
                    

                        <FCKeditorV2:FCKeditor ID="tbContent" runat="server" BasePath="../FCKeditor/"  Height="400px" Width="100%" >
                        </FCKeditorV2:FCKeditor>
                   
                </td>
            </tr>
        </table>
        
    </div>
    <asp:HiddenField ID="HidID" runat="server" />
    </form>
</body>
</html>
