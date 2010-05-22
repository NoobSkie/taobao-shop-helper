<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/QuestionnaireSurvey.aspx.cs" inherits="Home_Room_QuestionnaireSurvey" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title><%=_Site.Name %>用户特征调查问卷-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-family: "宋体";
            font-size: 12px;
            color: #085e7a;
            margin: 0px;
            padding: 0px;
        }
        .hui12
        {
            font-family: "宋体";
            font-size: 12px;
            line-height: 28px;
            color: #333333;
        }
        .form1
        {
            margin: 0px;
            padding: 0px;
        }
        .wenben
        {
            border: 1px solid #b3eaf8;
            height: 14px;
            width: 120px;
        }
        .wenben1
        {
            border: 1px solid #b3eaf8;
            height: 100px;
            width: 810px;
        }
        </style>
        <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <table width="1002" border="00" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="5">
            </td>
        </tr>
        <tr>
            <td>
                <table width="1002" border="00" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="24%">
                                        <img src="images/index_03.gif" width="240" height="75" />
                                    </td>
                                    <td width="34%">
                                        <img src="images/index_04.gif" width="460" height="75" />
                                    </td>
                                    <td width="42%">
                                        <img src="images/index_05.gif" width="302" height="75" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td background="images/index_33.jpg">
                            <table width="1000" border="00" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="113">
                                        <img src="images/index_07.gif" width="113" height="161" />
                                    </td>
                                    <td width="711" background="images/index_08.gif">
                                        <table width="100%" border="00" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="15" class="hui12">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="hui12">
                                                    尊敬的先生/女士：您好！<br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;为了给您提供一个舒适、便捷的购彩环境，我们特意进行此次针对用户特征的调查。希望您协助我们搞好这次调查<br />
                                                    您的回答对调查信息的完整性非常重要。<br />
                                                    该问卷所有信息只用于数据分析，请您放心填写。
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="176" align="right"><img src="images/inex_09.gif" width="176" height="161" style="vertical-align:bottom"/></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td><img src="images/index_10.gif" width="1002" height="73" style="vertical-align:bottom"/></td>
                    </tr>
                    <tr>
                        <td  valign="top" background="images/index_12-16.gif">
                            <table width="837" border="00" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center">
                                        <img src="images/index_19.gif" width="798" height="1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tbody id="tbQuestion" runat="server"></tbody>
                                 <tr>
            <td height="20">&nbsp;</td>
          </tr>
           <tr>
            <td align="center"><img src="images/index_19.gif" width="798" height="1" /></td>
          </tr>
           <tr>
             <td height="30" align="left" valign="middle" style="text-indent:10px;"><strong>您认为我们还有哪些需要改进的地方:</strong></td>
           </tr>
           <tr>
             <td height="15" align="left">
               <table width="800" border="00" align="center" cellpadding="0" cellspacing="0">
                 <tr>
                   <td><textarea name="textarea" id="tbSuggestion" cols="45" rows="5"  class="wenben1"></textarea>
                   </td>
                 </tr>
                 <tr>
                   <td height="50" align="center">
                      <img src="images/index_29.gif" width="117" height="35" style="cursor:pointer" onclick="submits();"/>
                   </td>
                 </tr>
               </table>
             </td>
           </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/index_15-18.gif" width="1002" height="52" />
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
<script language="javascript">
    function submits() {
       var checks = "";
       var intput = "";
        var inputs = document.getElementsByTagName("INPUT");

        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type == "checkbox" || inputs[i].type == "radio") {
                if (inputs[i].checked) {
                    checks += inputs[i].value + ","; 
                }
            }

            if (inputs[i].type == "text" && inputs[i].id.indexOf("tbQuestion") > -1) {
                intput += inputs[i].id.replace("tbQuestion", "") + "|" + inputs[i].value + ",";
            }
        }

        Home_Room_QuestionnaireSurvey.SubmitQuestionnaireSurvey(checks, intput, document.getElementById("tbSuggestion").value);

        alert("提交成功！谢笔您参与问卷调查！");
    }
</script>