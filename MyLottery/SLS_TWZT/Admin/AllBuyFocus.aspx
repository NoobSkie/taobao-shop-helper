<%@ page language="C#" autoeventwireup="true" CodeFile="AllBuyFocus.aspx.cs" inherits="Admin_AllBuyFocus" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function Cleartb() {
            document.getElementById("tbUserName").value = "";
            document.getElementById("tbOrder").value = "";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        请选择彩种
        <asp:DropDownList ID="ddlLottery" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlLottery_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
    </div>
    <br />
    <div>
        合买活跃明星 : <asp:TextBox ID="tbUserName" runat="server" Width="674px"></asp:TextBox>
        <br/>
        <font style="color:#B7B7B7 ; font-size:12px ;padding-left:30px;">多个用户请用" ,"隔开 
        如  张三 , 李四 , 王五</font>
    </div>
    <div> 
        彩种 排序 : <asp:TextBox ID="tbOrder" runat="server" ></asp:TextBox>
        <font style="color:#B7B7B7 ; font-size:12px ;padding-left:30px;">根据输入的数字排序,输入的数字越大排在越前面.</font>
    </div>
    <div style="padding-left:15px;">
        <asp:Button ID="btnSubMit" runat="server" Text="确定" 
            onclick="btnSubMit_Click" />&nbsp;&nbsp;
        <input type="button" onclick="Cleartb()" value="清空" />
    </div>
    </form>
</body>
</html>
