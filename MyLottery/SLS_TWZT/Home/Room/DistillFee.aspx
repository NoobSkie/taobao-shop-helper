<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/DistillFee.aspx.cs" inherits="Home_Room_DistillFee" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <script language = "javascript" type="text/javascript" >
        function Show() {
            parent.document.getElementById("tb_remind").style.display = "";
            parent.document.getElementById("tb_times").style.display = "";
            parent.document.getElementById("td_Tips").style.display = "";
            parent.document.getElementById("tb_mains").style.backgroundColor = "#DDDDDD";
        }
    </script>
</head>
<body onload = "Show();">
    <form id="form1" runat="server">
    <table width="98%" border="0" cellspacing="1" cellpadding="0" style="margin-top: 10px;margin-left:1%;"
        bgcolor="#CCCCCC">
        <tr>
            <td width="105" bgcolor="#E9F1F8" class="black12" style="padding: 3px 5px 3px 10px;">
                银行名称
            </td>
            <td width="222" bgcolor="#E9F1F8" class="black12" style="padding: 3px 5px 3px 10px;">
                到账时间
            </td>
            <td width="440" bgcolor="#E9F1F8" class="black12" style="padding: 3px 5px 3px 10px;">
                提款手续费(此手续费实为银行收取，非深圳地区为异地)
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                工商银行
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                申请提款+24小时内到帐（银行系统正常）
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                小于300元手续费每笔1元；300-5000（含）以内的手续费每笔3元；5001-50000（含）以内的手续费每笔5元； 
                <br />
                50001－200000（含）手续费每笔10元；200001-500000手续费每笔20元；<br />
                500000以上请联系客服人员。</td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                农业银行</td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                申请提款+24小时内到帐（银行系统正常）
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                 小于300元手续费每笔1元；300-5000（含）以内的手续费每笔3元；5001-50000（含）以内的手续费每笔5元； 
                <br />
                50001－200000（含）手续费每笔10元；200001-500000手续费每笔20元；<br />
                500000以上请联系客服人员。</td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                招商银行
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                申请提款+24小时内到帐（银行系统正常）
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                 小于300元手续费每笔1元；300-5000（含）以内的手续费每笔3元；5001-50000（含）以内的手续费每笔5元； 
                <br />
                50001－200000（含）手续费每笔10元；200001-500000手续费每笔20元；<br />
                500000以上请联系客服人员。</td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                建设银行
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                申请提款+24小时内到帐（银行系统正常）
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                 小于300元手续费每笔1元；300-5000（含）以内的手续费每笔3元；5001-50000（含）以内的手续费每笔5元； 
                <br />
                50001－200000（含）手续费每笔10元；200001-500000手续费每笔20元；<br />
                500000以上请联系客服人员。</td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                中国银行
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                申请提款+24小时内到帐（银行系统正常）
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                 小于300元手续费每笔1元；300-5000（含）以内的手续费每笔3元；5001-50000（含）以内的手续费每笔5元； 
                <br />
                50001－200000（含）手续费每笔10元；200001-500000手续费每笔20元；<br />
                500000以上请联系客服人员。</td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                其它银行
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                申请提款+24小时内到帐（银行系统正常）
            </td>
            <td bgcolor="#FFFFFF" class="black12" style="padding: 3px 5px 3px 10px;">
                小于300元手续费每笔1元；300-5000（含）以内的手续费每笔3元；5001-50000（含）以内的手续费每笔5元； 
                <br />
                50001－200000（含）手续费每笔10元；200001-500000手续费每笔20元；<br />
                500000以上请联系客服人员。</td>
        </tr>
       
    </table>
    <br />
    </form>
        <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
