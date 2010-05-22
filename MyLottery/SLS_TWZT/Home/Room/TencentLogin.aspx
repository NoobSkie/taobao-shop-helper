<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/TencentLogin.aspx.cs" inherits="Home_Room_TencentLogin" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
</head>
<body>
    <form id="form1">
    <div>
        <input type="hidden" name="sign_type" value="<%=sign_type %>" />
        <input type="hidden" name="sign_encrypt_keyid" value="<%=sign_encrypt_keyid %>" />
        <input type="hidden" name="input_charset" value="<%=input_charset %>" />
        <input type="hidden" name="service" value="<%=service %>" />
        <input type="hidden" name="chnid" value="<%=chnid %>" />
        <input type="hidden" name="chtype" value="<%=chtype %>" />
        <input type="hidden" name="attach" value="<%=attach %>" />
        <input type="hidden" name="tmstamp" value="<%=tmstamp %>" />
        <input type="hidden" name="sign" value="<%=sign %>" />
        <input type="hidden" name="redirect_url" value="<%=redirect_url %>" />
    </div>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
<script type="text/javascript">
    var web = document.getElementById("form1");
    web.action = "<%=requestUrl %>";
    web.submit();
</script>
