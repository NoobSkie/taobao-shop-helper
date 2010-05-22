<%@ page language="C#" autoeventwireup="true" CodeFile="UserDetail.aspx.cs" inherits="Admin_UserDetail" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfBankInProvince" runat="server" Value="true" />
        <asp:HiddenField ID="hfBankInCity" runat="server" Value="true" />
        <asp:HiddenField ID="hfBankTypeName" runat="server" Value="true" />
        <asp:HiddenField ID="hfBankName" runat="server" Value="true" />
        <div>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td align="center">
                        <div style="width: 584px; position: relative; height: 64px">
                            <asp:TextBox ID="tbUserName" Style="z-index: 100; left: 136px; position: absolute; top: 40px" runat="server" Width="150px" BorderWidth="1px"></asp:TextBox>
                             <ShoveWebUI:ShoveConfirmButton ID="EmptyQuestn" runat="server" Text="清空安全问题" AlertText="确信清空用户安全问题，并立即保存资料吗？"
                                OnClick="EmptyQuestn_Click" Style="z-index: 101; left: 320px; position: absolute; top: 40px; right: 156px;cursor: pointer;" />
                            <asp:Label ID="Label1" Style="z-index: 103; left: 8px; position: absolute; top: 11px" runat="server" ForeColor="Green" Font-Bold="True">用户基本资料：</asp:Label>
                            <asp:Label ID="Label2" Style="z-index: 104; left: 56px; position: absolute; top: 40px" runat="server">　用户名：</asp:Label>
                            <asp:TextBox ID="tbUserID" Style="z-index: 107; left: 128px; position: absolute; top: 13px" runat="server" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="tbSiteID" runat="server" Style="z-index: 107; left: 266px; position: absolute; top: 14px" Visible="False"></asp:TextBox>
                            <asp:LinkButton ID="btnUserAccount" Style="z-index: 109; left: 448px; position: absolute; top: 13px" runat="server" CssClass="li3" OnClick="btnUserAccount_Click">查看用户账户明细</asp:LinkButton>
                        </div>
                        <asp:Panel ID="Panel1" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <div style="width: 585px; position: relative; height: 800px; left: 0px; top: 0px;">
                                            <asp:RadioButton ID="rbUserType1" Style="z-index: 155; left: 136px; position: absolute; top: 80px" runat="server" Text="普通会员" GroupName="UserType"></asp:RadioButton>
                                            <asp:TextBox ID="tbUserEmail" Style="z-index: 155; left: 136px; position: absolute; top: 3px" runat="server" MaxLength="25" BorderWidth="1px" Width="150px"></asp:TextBox>
                                            <asp:Label ID="Label5" Style="z-index: 155; left: 58px; position: absolute; top: 2px" runat="server">电子邮箱：</asp:Label>
                                            <asp:TextBox ID="tbUserRealityName" Style="z-index: 155; left: 136px; position: absolute; top: 128px" runat="server" MaxLength="25" BorderWidth="1px" Width="150px"></asp:TextBox>
                                            <asp:TextBox ID="tbUserIDCardNumber" 
                                                Style="z-index: 155; left: 136px; position: absolute; top: 152px; bottom: 632px;" 
                                                runat="server" MaxLength="25" BorderWidth="1px" Width="192px"></asp:TextBox>
                                            <ShoveWebUI:ShoveProvinceCityInput ID="ddlUserCity" SupportDir="../ShoveWebUI_client" Style="z-index: 155; left: 136px; position: absolute; top: 176px" runat="server" Width="150px" />
                                            <asp:TextBox ID="tbUserTelephone" Style="z-index: 155; left: 136px; position: absolute; top: 256px" runat="server" MaxLength="25" BorderWidth="1px" Width="192px"></asp:TextBox>
                                            <asp:TextBox ID="tbUserMobile" Style="z-index: 155; left: 136px; position: absolute; top: 280px" runat="server" MaxLength="25" BorderWidth="1px" Width="192px"></asp:TextBox>
                                            <asp:TextBox ID="tbUserQQ" Style="z-index: 155; left: 136px; position: absolute; top: 304px" runat="server" MaxLength="25" BorderWidth="1px" Width="150px"></asp:TextBox>
                                            <asp:TextBox ID="tbUserAddress" Style="z-index: 155; left: 136px; position: absolute; top: 328px" runat="server" MaxLength="25" BorderWidth="1px" Width="192px"></asp:TextBox>
                                            <asp:RadioButton ID="rbUserSexM" Style="z-index: 155; left: 144px; position: absolute; top: 352px" runat="server" Text="男" GroupName="Sex"></asp:RadioButton>
                                            <asp:RadioButton ID="rbUserSexW" Style="z-index: 155; left: 200px; position: absolute; top: 352px" runat="server" Text="女" GroupName="Sex"></asp:RadioButton>
                                            <asp:TextBox ID="tbUserBirthDay" Style="z-index: 155; left: 136px; position: absolute; top: 376px" runat="server" MaxLength="25" BorderWidth="1px" Width="150px"></asp:TextBox>
                                            
                                            <select  id="selBankTypeName" name="selBankTypeName"  onchange="selBankTypeName_onchange(this)"
                                                style="z-index: 155; width:150px; left: 136px; position: absolute; top: 504px" 
                                                runat="server" >
                                            </select>
                                            <select id="selProvince" name="selProvince" 
                                                style="width:80px;z-index: 155; left: 136px; position: absolute; top: 452px; right: 369px; "  
                                                onchange="selProvince_onchange(this)">
                                                <option></option>
                                            </select>
                                            <select id="selCity" name="selCity" 
                                                style="width:80px;z-index: 155; left: 136px; position: absolute; top: 479px;" 
                                                onchange="selCity_onchange(this)">
                                                <option></option>
                                            </select>
                                            <select  id="selBankName" name="selBankName" style="width:250px;z-index: 155; left: 136px; position: absolute; top: 527px">
                                                <option></option>
                                            </select>
                                            
                                            <asp:TextBox ID="tbUserCradName" 
                                                Style="z-index: 155; left: 136px; position: absolute; top: 572px" 
                                                runat="server" MaxLength="25" BorderWidth="1px" Width="192px"></asp:TextBox>
                                            <asp:TextBox ID="tbUserBankCardNumber" 
                                                Style="z-index: 155; left: 136px; position: absolute; top: 549px" 
                                                runat="server" MaxLength="25" BorderWidth="1px" Width="192px"></asp:TextBox>
                                            <asp:TextBox ID="tbScoringOfSelfBuy" runat="server" BorderWidth="1px" MaxLength="5" Style="z-index: 155; left: 136px; position: absolute; top: 630px" Width="109px"></asp:TextBox>
                                            <asp:TextBox ID="tbScoringOfCommendBuy" runat="server" BorderWidth="1px" MaxLength="5" Style="z-index: 155; left: 136px; position: absolute; top: 654px" Width="109px"></asp:TextBox>
                                            <asp:Label ID="Label3" runat="server" Style="z-index: 155; left: 56px; position: absolute; top: 630px">购彩积分：</asp:Label>
                                            <asp:Label ID="Label8" runat="server" Style="z-index: 155; left: 258px; position: absolute; top: 630px">分/元</asp:Label>
                                            <asp:Label ID="Label11" runat="server" Style="z-index: 155; left: 258px; position: absolute; top:654px">分/元</asp:Label>
                                            <asp:Label ID="Label4" runat="server" Style="z-index: 155; left: 56px; position: absolute; top: 654px">下级购彩积分：</asp:Label>
                                            <asp:Label ID="Label12" runat="server" Style="z-index: 155; left: 56px; position: absolute; top: 678px">会员相片：</asp:Label>
                                            <asp:Label ID="Label6" Style="z-index: 155; left: 8px; position: absolute; top: 56px" runat="server" Font-Bold="True" ForeColor="Green">高级用户资料：</asp:Label>
                                            <asp:Label ID="Label10" Style="z-index: 155; left: 56px; position: absolute; top: 128px" runat="server">真实姓名：</asp:Label>
                                            <asp:Label ID="Label9" Style="z-index: 155; left: 56px; position: absolute; top: 152px" runat="server">身份证号：</asp:Label>
                                            <asp:Label ID="Label7" Style="z-index: 155; left: 56px; position: absolute; top: 177px" runat="server">　　城市：</asp:Label>
                                            <asp:Label ID="Label13" Style="z-index: 155; left: 24px; position: absolute; top: 104px" runat="server" ForeColor="Green">1、投注信息及投注密码： </asp:Label>
                                            <asp:Label ID="Label14" Style="z-index: 155; left: 24px; position: absolute; top: 232px" runat="server" ForeColor="Green">2、联系方式和个人信息：</asp:Label>
                                            <asp:Label ID="Label20" Style="z-index: 155; left: 56px; position: absolute; top: 256px" runat="server">联系电话：</asp:Label>
                                            <asp:Label ID="Label19" Style="z-index: 155; left: 56px; position: absolute; top: 280px" runat="server">手机号码：</asp:Label>
                                            <asp:Label ID="Label18" Style="z-index: 155; left: 56px; position: absolute; top: 304px" runat="server">　QQ号码：</asp:Label>
                                            <asp:Label ID="Label17" Style="z-index: 155; left: 56px; position: absolute; top: 328px" runat="server">联系地址：</asp:Label>
                                            <asp:Label ID="Label16" Style="z-index: 155; left: 56px; position: absolute; top: 352px" runat="server">　　性别：</asp:Label>
                                            <asp:Label ID="Label15" Style="z-index: 155; left: 56px; position: absolute; top: 376px" runat="server">　　生日：</asp:Label>
                                            <asp:Label ID="Label21" Style="z-index: 155; left: 24px; position: absolute; top: 432px" runat="server" ForeColor="Green">3、银行卡信息：</asp:Label>
                                            <asp:Label ID="Label26" runat="server" 
                                                Style="z-index: 155; left: 56px; position: absolute; top: 453px">银行所在省份：</asp:Label>
                                            <asp:Label ID="Label27" runat="server" 
                                                Style="z-index: 155; left: 56px; position: absolute; top: 479px">银行所在城市：</asp:Label>
                                            <asp:Label ID="Label23" runat="server" 
                                                Style="z-index: 155; left: 32px; position: absolute; top: 527px; height: 19px;">开户银行支行名称：</asp:Label>
                                            <asp:Label ID="Label22" runat="server" 
                                                Style="z-index: 155; left: 81px; position: absolute; top: 548px">银行卡号：</asp:Label>
                                            <asp:Label ID="Label25" runat="server" ForeColor="Green" 
                                                Style="z-index: 155; left: 24px; position: absolute; top: 606px">4、其他资料：</asp:Label>
                                            <asp:CheckBox ID="cbUserMobileValid" runat="server" 
                                                Style="z-index: 155; left: 336px; position: absolute; top: 280px" 
                                                Text="已通过验证" />
                                            <asp:RadioButton ID="rbUserType2" runat="server" GroupName="UserType" 
                                                Style="z-index: 154; left: 216px; position: absolute; top: 80px" Text="高级会员" />
                                            <asp:CheckBox ID="cbPrivacy" runat="server" 
                                                Style="z-index: 153; left: 136px; position: absolute; top: 750px" 
                                                Text="用户资料保密" />
                                            <asp:CheckBox ID="cbisCanLogin" runat="server" 
                                                Style="z-index: 153; left: 136px; position: absolute; top: 774px" Text="允许登录" />
                                            <asp:Button ID="btnResetPassword" runat="server" 
                                                onclick="btnResetPassword_Click" 
                                                Style="z-index: 155; left: 356px; position: absolute; top: 152px" Text="重置密码" Visible ="false "/>
                                            <asp:RadioButton ID="rbUserType3" runat="server" GroupName="UserType" 
                                                Style="z-index: 154; left: 310px; position: absolute; top: 77px" Text="VIP会员" />
                                            <asp:Label ID="Label28" runat="server" 
                                                Style="z-index: 155; left: 69px; position: absolute; top: 570px">持卡人姓名：</asp:Label>
                                            <asp:Label ID="Label24" 
                                                Style="z-index: 155; left: 80px; position: absolute; top: 504px" runat="server">发卡银行：</asp:Label>
                                            
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <ShoveWebUI:ShoveConfirmButton ID="btnSave" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" BorderWidth="0px" Width="60px" Text="保存修改" BorderStyle="None" AlertText="确信要保存所做的修改吗？" Height="20px" OnClick="btnSave_Click"  Visible ="false" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript" language="javascript">

    function OnInit_UserBindBankData()
    {
        //获取已经绑定的资料
        var curBankInProvince = document.getElementById("hfBankInProvince").value;
        var curBankInCity = document.getElementById("hfBankInCity").value;
        var curBankTypeName = document.getElementById("hfBankTypeName").value;
        var curBankName = document.getElementById("hfBankName").value;
        
        
        //绑定省份数据列表
        var selProvince = document.getElementById("selProvince");
        while (selProvince.options.length > 0)
        {
            selProvince.options[0] = null;
        }
        var listStr = Admin_UserDetail.GetProvinceList().value;
        var listNames = listStr.split("|");
        for (var i = 0; i < listNames.length; i++)
        {
            selProvince.options[selProvince.options.length] = new Option(listNames[i], listNames[i]);
        }
        selProvince.value = curBankInProvince;
        
        //绑定银行类名称列表
        var selBankTypeName = document.getElementById("selBankTypeName");
        while (selBankTypeName.options.length > 0)
        {
            selBankTypeName.options[0] = null;
        }
        var listBankNameStr = Admin_UserDetail.GetBankTypeList().value;
        var listBankNames = listBankNameStr.split("|");

        for (var i = 0; i < listBankNames.length; i++)
        {
            selBankTypeName.options[selBankTypeName.options.length] = new Option(listBankNames[i], listBankNames[i]);
        }
        selBankTypeName.value = curBankTypeName;



        
        
        //绑定市名
        selProvince_onchange(selProvince);
        var selCity = document.getElementById("selCity");
        selCity.value = curBankInCity;

        //显示支行
        GetBankBranchNameList(curBankInCity, curBankTypeName);
        var selBankName = document.getElementById("selBankName");
        selBankName.value=curBankName

       

    }

    function selProvince_onchange(obj)
    {
        var selProvince = obj;
        var selectProvinceName = selProvince.value;
        //alert(selProvince.value);
        //清空城市
        var selCity = document.getElementById("selCity");
        while (selCity.options.length > 0)
        {
            selCity.options[0] = null;
        }

        var listStr = Admin_UserDetail.GetCityList(selectProvinceName).value;
        //alert(listStr);
        var listNames = listStr.split("|");
        for (var i = 0; i < listNames.length; i++)
        {
            selCity.options[selCity.options.length] = new Option(listNames[i], listNames[i]);
        }
        selCity.value = "";
    }


    function selCity_onchange(objSender)
    {

        var selCityObj = document.getElementById("selCity");
        var selectCityName = selCityObj.value;

        var selBankTypeNameObj = document.getElementById("selBankTypeName");
        var selectBankName = selBankTypeNameObj.value;

        GetBankBranchNameList(selectCityName, selectBankName);
    }
    function selBankTypeName_onchange(objSender)
    {

        var selCityObj = document.getElementById("selCity");
        var selectCityName = selCityObj.value;

        var selBankTypeNameObj = document.getElementById("selBankTypeName");
        var selectBankTypeName = selBankTypeNameObj.value;

        GetBankBranchNameList(selectCityName, selectBankTypeName);
    }

    function GetBankBranchNameList(cityName, bankTypeName)
    {
        //alert(cityName + " | " + bankTypeName);

        //清空银行下拉表
        var selBankName = document.getElementById("selBankName");
        while (selBankName.options.length > 0)
        {
            selBankName.options[0] = null;
        }


        var listStr = Admin_UserDetail.GetBankBranchNameList(cityName, bankTypeName).value;
        //alert(listStr);
        var listNames = listStr.split("|");
        for (var i = 0; i < listNames.length; i++)
        {
            if (listNames[i] != "")
            {
                //支行下拉框
                selBankName.options[selBankName.options.length] = new Option(listNames[i], listNames[i])
            }

        }
        selBankName.value = "";
    }


    try 
    {
        OnInit_UserBindBankData();
    }
    catch (ex) 
    {
        alert("绑定数据出错:" + ex.message);
    }
</script>
