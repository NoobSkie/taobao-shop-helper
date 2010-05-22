<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/Export.aspx.cs" inherits="Home_Room_Export" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table >
     <tr>
     <td id="tbWinNumbers"></td>
     </tr>
     </table>
    </div>
       <asp:HiddenField ID="LotteryID" runat="server" />
    </form>
</body>
</html>
<script type="text/javascript">

    tbWinNumbers.innerHTML = Home_Room_Export.GetData(document.getElementById("LotteryID").value).value;

</script>