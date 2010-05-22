<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/TC22X5/22X5_WeiHao.aspx.cs" inherits="TC22X5_22X5_WeiHao" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>22选5尾号走势图</title>
    <style type="text/css">
         body
        {
            font-family: tahoma;
            margin: 0px;
            margin-left: 10px;
            margin-right: 10px;
            text-align: center;
        }
        body, td, th
        {
            font-size: 12px;
            font-name: 宋体;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%; height: 40px; background-image: url(../Images/bg11111.jpg);"
        cellspacing="0" cellpadding="0">
        <tbody>
            <tr>
                <td align="center" valign="middle" style="width: 300px; font-weight: bold; font-size: 18px;
                    color: #CC0000">
                    22选5&nbsp;&nbsp;尾号分布图
                </td>
                <td style="width: 700px; color: blue; font-style: normal; height: 6px;" align="left">
                    选择最近期数
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="100期" AutoPostBack="True"
                        GroupName="group" OnCheckedChanged="RadioButton1_CheckedChanged1" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="50期" AutoPostBack="True"
                        OnCheckedChanged="RadioButton2_CheckedChanged" GroupName="group" />
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="30期" AutoPostBack="True"
                        Checked="true" OnCheckedChanged="RadioButton3_CheckedChanged" GroupName="group" />
                    <asp:RadioButton ID="RadioButton4" runat="server" Text="20期" AutoPostBack="True"
                        GroupName="group" OnCheckedChanged="RadioButton4_CheckedChanged1" />
                    <asp:RadioButton ID="RadioButton5" runat="server" Text="10期" AutoPostBack="True"
                        GroupName="group" OnCheckedChanged="RadioButton5_CheckedChanged1" />
                </td>
            </tr>
        </tbody>
    </table>
            <table border="0" cellpadding="1" cellspacing="1" style="background-color:#CCCCCC; width:100%">
            <tbody>
                <tr style="background-color:#EEEEEE">
                    <td align="center">
                        <table cellspacing="0 "cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr style="background-color:#EEEEEE" >
                                <td height="24" align="center"><b>22选5开奖号码尾号分布图</b></td>
                            </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr style="background-color:#FFFFFF">
                    <td valign="top" style="border-color:#ffffff">
                        <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                           <tr align="center" valign="middle">
                                <td valign="top" colspan="11" >
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        UseAccessibleHeader="False" OnRowCreated="GridView1_RowCreated"
                                        ShowFooter="True" Width="100%" bordercolorlight="#808080" bordercolordark="#FFFFFF" align="center" cellpadding="0">
                                        <Columns>
                                            <asp:BoundField DataField="Isuse" HeaderText="期  数">
                                                <ItemStyle Width="30px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_1" HeaderText="B_1" >
                                             <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_11" HeaderText="B_11" >
                                             <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_21" HeaderText="B_21" >
                                            <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_2" HeaderText="B_2" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_12" HeaderText="B_12" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_22" HeaderText="B_22" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_3" HeaderText="B_3" >
                                            <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_13" HeaderText="B_13" >
                                            <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_4" HeaderText="B_4" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_14" HeaderText="B_14" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>  
                                            <asp:BoundField DataField="B_5" HeaderText="B_5" >
                                            <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_15" HeaderText="B_15" >
                                            <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_6" HeaderText="B_6" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_16" HeaderText="B_16" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_7" HeaderText="B_7" >
                                            <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_17" HeaderText="B_17" >
                                            <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_8" HeaderText="B_8" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_18" HeaderText="B_18" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_9" HeaderText="B_9" >
                                            <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_19" HeaderText="B_19" >
                                            <ItemStyle Width="15px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_10" HeaderText="B_10" >
                                             <ItemStyle Width="15px" BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_20" HeaderText="B_20" >
                                          <ItemStyle Width="15px"  BackColor="#E7FEEB"/>
                                            </asp:BoundField>
                                          
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </tbody>
            </table>         
        </div>
    </form>
</body>
</html>
