<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/OnlinePay/Alipay01/Default.aspx.cs" inherits="Home_Room_OnlinePay_Alipay01_Default" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>֧�������߳�ֵ-<%=_Site.Name %>-�ֻ����Ʊ������<%=_Site.Name %></title>
    <meta name="keywords" content="֧�������߳�ֵ" />
    <meta name="description" content="<%=_Site.Name %>��Ʊ����һ�ҷ������й�����Ļ�������Ʊ�����������ƽ̨���漰�й���Ʊ������ȫ����վ������˫ɫ��ʱʱ�֡�ʱʱ�ʡ���ʵ��ڶ���ֵ�ʵʱ������Ϣ��ͼ�����ơ�����Ԥ��ȡ�"/>
    <link href="../../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../../Style/main.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        A
        {
            text-transform: none;
            text-decoration: none;
        }
        A:hover
        {
            text-decoration: underline;
        }
    </style>
</head><link rel="shortcut icon" href="../../../../favicon.ico"/>
<body>
    <form id="Form1" name="form1" runat="server">
    </form>
    <form id="Form2" name="form2" action="Send.aspx" method="post">
    <br />
    <table width="745" border="0" cellspacing="0" cellpadding="0" align="center" background="images/zhifu_bg.jpg">
        <tr>
            <td>
                <img src="images/zhifu_top.jpg" width="745" height="29" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 35px; font-weight: bold; font-size: 14px; vertical-align: middle;" height="35" align="left">
                ��ѡ���ֵ���>>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="710" border="0" cellspacing="0" cellpadding="0" style="border: 1px solid #CDCDCD;">
                    <tr>
                        <td style="padding: 10px 10px 10px 10px;">
                            <table width="690" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <img src="images/zhifu_pic_50.jpg" width="212" height="121" />
                                    </td>
                                    <td align="center">
                                        <img src="images/zhifu_pic_100.jpg" width="212" height="121" />
                                    </td>
                                    <td align="center">
                                        <img src="images/zhifu_pic_300.jpg" width="212" height="121" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" height="25">
                                        <input type="radio" name="CardType" value="50" checked="checked" />
                                    </td>
                                    <td align="center">
                                        <input type="radio" name="CardType" value="100" />
                                    </td>
                                    <td align="center">
                                        <input type="radio" name="CardType" value="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <img src="images/zhifu_pic_500.jpg" width="212" height="121" />
                                    </td>
                                    <td align="center">
                                        <img src="images/zhifu_pic_20.jpg" width="212" height="121" />
                                    </td>
                                    <td align="center">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" height="25">
                                        <input type="radio" name="CardType" value="500" />
                                    </td>
                                    <td align="center">
                                        <input type="radio" name="CardType" value="10" />
                                    </td>
                                    <td align="center">
                                        
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
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="710" border="0" cellspacing="0" cellpadding="0" style="border: 1px solid #CDCDCD;">
                    <tr>
                        <td style="background-color: #ECECEC">
                            <table width="710" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="182" height="60" style="color: #333333; font-weight: bold; font-size: 14px; padding-left: 16px;" align="left">
                                        �����빺��绰����������
                                    </td>
                                    <td width="154" align="left">
                                        <input type="text" name="Num" id="Num" style="height: 20px; width: 100px;" value="1" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
                                    </td>
                                    <td width="358" style="color: #666666; line-height: 16px;" align="left">
                                        ע��������ֵ10000,��ѡ��500��ֵ����������20�š�
                                        <br>
                                        ���绰Ͷע����һ�����򣬲�֧���˿��
                                        <br>
                                        �н�����Ϻ���������ֱ�ӷ�������Ա֧�����ʻ���
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
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <input type="image" name="imageField" src="images/zhifu_button.jpg" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <img src="images/zhifu_di.jpg" width="745" height="10" />
            </td>
        </tr>
    </table>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
