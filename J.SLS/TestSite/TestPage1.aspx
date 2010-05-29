<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPage1.aspx.cs" Inherits="TestPage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="a" type="text" />
        <input id="b" type="text" />
        <button onclick="Test();" value="Test"></button>
    </div>
    </form>

    <script type="text/javascript">

        function Test() {
            var a = document.getElementById("a").value;
            var b = document.getElementById("b").value;
            alert(TestPage1);
            var c = TestPage1.TestMethod(a, b).value;
            alert(c);
        }
    
    </script>
</body>
</html>
