<%@ page language="C#" autoeventwireup="true" CodeFile="Send.aspx.cs" inherits="Home_Room_OnlinePay_007ka_Send" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>007ka充值接口</title>
</head>
<body>
    <form id="form1" action="http://www.007ka.cn/interface/cardpay/index.php" runat="server">
    <div>
        <input type="hidden" id="type" name="type" value="<%=type %>"  />
        <input type="hidden" id="version" name="version" value="<%=version %>"  />
        <input type="hidden" id="merchantId" name="merchantId" value="<%=merchantId %>"  />
        <input type="hidden" id="meraccount" name="meraccount" value="<%=meraccount %>"  />
        <input type="hidden" id="orderId" name="orderId" value="<%=orderId %>" />
        <input type="hidden" id="orderDate" name="orderDate" value="<%=orderDate %>"  />
        <input type="hidden" id="amount" name="amount" value="<%=amount %>"  />
        <input type="hidden" id="curId" name="curId" value="<%=curId %>"  />
        <input type="hidden" id="payInterfaceId" name="payInterfaceId" value="<%=payInterfaceId %>"  />
        <input type="hidden" id="productName" name="productName" value="<%=productName %>"  />
        <input type="hidden" id="productDesc" name="productDesc" value="<%=productDesc %>"  />
        <input type="hidden" id="reserved" name="reserved" value="<%=reserved %>"  />
        <input type="hidden" id="merName" name="merName" value="<%=merName %>"  />
        <input type="hidden" id="backUrl" name="backUrl" value="<%=backUrl %>"  />
        <input type="hidden" id="hmac" name="hmac" value="<%=hmac %>"  />
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    document.getElementById("form1").submit();
</script>
