<%@ page language="C#" autoeventwireup="true" CodeFile="IsuseEdit.aspx.cs" inherits="Admin_IsuseEdit" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Table1" cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                <tr>
                    <td align="center">
                        <div style="width: 645px; position: relative; height: 160px">
                            <asp:Label ID="Label3" Style="z-index: 104; left: 24px; position: absolute; top: 72px" runat="server">截止时间</asp:Label>
                            <asp:TextBox ID="tbIsuseID" 
                                Style="z-index: 108; left: 312px; position: absolute; top: 8px; right: 253px;" 
                                runat="server" Width="80px" Visible="False"></asp:TextBox>
                            <asp:Label ID="Label2" Style="z-index: 103; left: 24px; position: absolute; top: 40px" runat="server">开始时间</asp:Label>
                            <asp:Label ID="Label1" Style="z-index: 102; left: 24px; position: absolute; top: 8px" runat="server"> 期号</asp:Label>
                            <asp:TextBox ID="tbEndTime" Style="z-index: 101; left: 88px; position: absolute; top: 72px" runat="server" Width="232px" MaxLength="19"></asp:TextBox>
                            <asp:TextBox ID="tbIsuse" Style="z-index: 100; left: 88px; position: absolute; top: 8px" runat="server" Width="128px" MaxLength="10"></asp:TextBox>
                            <asp:TextBox ID="tbStartTime" Style="z-index: 105; left: 88px; position: absolute; top: 40px" runat="server" Width="232px" MaxLength="19"></asp:TextBox>
                            <asp:Label ID="Label4" Style="z-index: 106; left: 344px; position: absolute; top: 40px" runat="server" ForeColor="Red">时间格式: 0000-00-00 00:00:00</asp:Label>
                            <ShoveWebUI:ShoveConfirmButton ID="btnEdit" Style="left: 376px; position: absolute; top: 102px;" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" Text="保存" AlertText="确认书写无误吗？" OnClick="btnEdit_Click" />
                            <asp:TextBox ID="tbLotteryID" Style="z-index: 109; left: 408px; position: absolute; top: 8px" runat="server" Width="88px" Visible="False"></asp:TextBox>
                            <asp:LinkButton ID="btnBack" Style="z-index: 110; left: 576px; position: absolute; top: 8px" runat="server" OnClick="btnBack_Click">【返回】</asp:LinkButton>
                            <asp:Label ID="Label75" 
                                Style="z-index: 104; left: 24px; position: absolute; top: 102px" runat="server">试机号</asp:Label>
                                    <asp:Label ID="Label15" 
                                Style="z-index: 104; left: 24px; position: absolute; top: 135px" runat="server">奖池累金额</asp:Label>
                                <asp:TextBox ID="tbMoney" 
                                Style="z-index: 101; left: 88px; position: absolute; top: 135px" runat="server" 
                                Width="232px" MaxLength="19"></asp:TextBox>
                            <asp:TextBox ID="tbTestNumber" 
                                Style="z-index: 101; left: 88px; position: absolute; top: 102px" runat="server" 
                                Width="232px" MaxLength="19"></asp:TextBox>
                        </div>
                        <asp:Panel ID="pSFC" runat="server" Visible="False">
                            <div style="width: 644px; position: relative; height: 482px">
                                <asp:Label ID="Label5" Style="z-index: 100; left: 24px; position: absolute; top: 8px" runat="server">主客队</asp:Label>
                                <asp:TextBox ID="tbSFC11_1" Style="z-index: 167; left: 248px; position: absolute; top: 352px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label38" Style="z-index: 164; left: 232px; position: absolute; top: 352px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC11" Style="z-index: 163; left: 88px; position: absolute; top: 352px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label32" Style="z-index: 155; left: 232px; position: absolute; top: 288px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC9_1" Style="z-index: 154; left: 248px; position: absolute; top: 288px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:TextBox ID="tbSFC9" Style="z-index: 151; left: 88px; position: absolute; top: 288px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:TextBox ID="tbSFC2" Style="z-index: 115; left: 88px; position: absolute; top: 64px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label9" Style="z-index: 114; left: 232px; position: absolute; top: 64px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC2_1" Style="z-index: 113; left: 248px; position: absolute; top: 64px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label8" Style="z-index: 106; left: 72px; position: absolute; top: 32px" runat="server">1</asp:Label>
                                <asp:Label ID="Label7" Style="z-index: 105; left: 400px; position: absolute; top: 32px" runat="server">比赛时间</asp:Label>
                                <asp:Label ID="Label6" Style="z-index: 102; left: 232px; position: absolute; top: 32px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC1" Style="z-index: 101; left: 88px; position: absolute; top: 32px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:TextBox ID="tbSFC1_1" Style="z-index: 103; left: 248px; position: absolute; top: 32px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:TextBox ID="tbSFC1_2" Style="z-index: 104; left: 456px; position: absolute; top: 32px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label11" Style="z-index: 108; left: 72px; position: absolute; top: 64px" runat="server">2</asp:Label>
                                <asp:TextBox ID="tbSFC2_2" Style="z-index: 110; left: 456px; position: absolute; top: 64px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label10" Style="z-index: 111; left: 400px; position: absolute; top: 64px" runat="server">比赛时间</asp:Label>
                                <asp:Label ID="Label12" Style="z-index: 117; left: 72px; position: absolute; top: 96px" runat="server">3</asp:Label>
                                <asp:TextBox ID="tbSFC3" Style="z-index: 118; left: 88px; position: absolute; top: 96px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label13" Style="z-index: 120; left: 232px; position: absolute; top: 96px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC3_1" Style="z-index: 122; left: 248px; position: absolute; top: 96px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label14" Style="z-index: 124; left: 400px; position: absolute; top: 96px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC3_2" Style="z-index: 126; left: 456px; position: absolute; top: 96px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:TextBox ID="tbSFC5_2" Style="z-index: 109; left: 456px; position: absolute; top: 160px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label16" Style="z-index: 112; left: 400px; position: absolute; top: 160px" runat="server">比赛时间</asp:Label>
                                <asp:Label ID="Label17" Style="z-index: 116; left: 72px; position: absolute; top: 128px" runat="server">4</asp:Label>
                                <asp:TextBox ID="tbSFC4" Style="z-index: 119; left: 88px; position: absolute; top: 128px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label18" Style="z-index: 121; left: 232px; position: absolute; top: 128px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC4_1" Style="z-index: 123; left: 248px; position: absolute; top: 128px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label19" Style="z-index: 125; left: 400px; position: absolute; top: 128px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC4_2" Style="z-index: 127; left: 456px; position: absolute; top: 128px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label20" Style="z-index: 128; left: 72px; position: absolute; top: 160px" runat="server">5</asp:Label>
                                <asp:TextBox ID="tbSFC5" Style="z-index: 130; left: 88px; position: absolute; top: 160px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label21" Style="z-index: 133; left: 232px; position: absolute; top: 160px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC5_1" Style="z-index: 134; left: 248px; position: absolute; top: 160px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label22" Style="z-index: 143; left: 72px; position: absolute; top: 192px" runat="server">6</asp:Label>
                                <asp:TextBox ID="tbSFC6" Style="z-index: 136; left: 88px; position: absolute; top: 192px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label25" Style="z-index: 142; left: 232px; position: absolute; top: 192px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC6_1" Style="z-index: 141; left: 248px; position: absolute; top: 192px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label26" Style="z-index: 137; left: 400px; position: absolute; top: 192px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC6_2" Style="z-index: 144; left: 456px; position: absolute; top: 192px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label24" Style="z-index: 140; left: 72px; position: absolute; top: 224px" runat="server">7</asp:Label>
                                <asp:TextBox ID="tbSFC7" Style="z-index: 138; left: 88px; position: absolute; top: 224px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label28" Style="z-index: 139; left: 232px; position: absolute; top: 224px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC7_1" Style="z-index: 135; left: 248px; position: absolute; top: 224px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label23" Style="z-index: 131; left: 400px; position: absolute; top: 224px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC7_2" Style="z-index: 132; left: 456px; position: absolute; top: 224px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label27" Style="z-index: 129; left: 72px; position: absolute; top: 256px" runat="server">8</asp:Label>
                                <asp:TextBox ID="tbSFC8" Style="z-index: 145; left: 88px; position: absolute; top: 256px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label29" Style="z-index: 146; left: 232px; position: absolute; top: 256px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC8_1" Style="z-index: 147; left: 248px; position: absolute; top: 256px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label30" Style="z-index: 148; left: 400px; position: absolute; top: 256px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC8_2" Style="z-index: 149; left: 456px; position: absolute; top: 256px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label33" Style="z-index: 150; left: 72px; position: absolute; top: 288px" runat="server">9</asp:Label>
                                <asp:Label ID="Label31" Style="z-index: 152; left: 400px; position: absolute; top: 288px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC9_2" Style="z-index: 153; left: 456px; position: absolute; top: 288px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label34" Style="z-index: 156; left: 72px; position: absolute; top: 320px" runat="server">10</asp:Label>
                                <asp:TextBox ID="tbSFC10" Style="z-index: 157; left: 88px; position: absolute; top: 320px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label35" Style="z-index: 158; left: 232px; position: absolute; top: 320px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC10_1" Style="z-index: 159; left: 248px; position: absolute; top: 320px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label36" Style="z-index: 160; left: 400px; position: absolute; top: 320px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC10_2" Style="z-index: 161; left: 456px; position: absolute; top: 320px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label39" Style="z-index: 162; left: 72px; position: absolute; top: 352px" runat="server">11</asp:Label>
                                <asp:Label ID="Label37" Style="z-index: 165; left: 400px; position: absolute; top: 352px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC11_2" Style="z-index: 166; left: 456px; position: absolute; top: 352px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label40" Style="z-index: 168; left: 72px; position: absolute; top: 384px" runat="server">12</asp:Label>
                                <asp:TextBox ID="tbSFC12" Style="z-index: 169; left: 88px; position: absolute; top: 384px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label41" Style="z-index: 170; left: 232px; position: absolute; top: 384px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC12_1" Style="z-index: 171; left: 248px; position: absolute; top: 384px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label42" Style="z-index: 172; left: 400px; position: absolute; top: 384px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC12_2" Style="z-index: 173; left: 456px; position: absolute; top: 384px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label43" Style="z-index: 174; left: 72px; position: absolute; top: 416px" runat="server">13</asp:Label>
                                <asp:TextBox ID="tbSFC13" Style="z-index: 175; left: 88px; position: absolute; top: 416px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label44" Style="z-index: 176; left: 232px; position: absolute; top: 416px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC13_1" Style="z-index: 177; left: 248px; position: absolute; top: 416px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label45" Style="z-index: 178; left: 400px; position: absolute; top: 416px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC13_2" Style="z-index: 180; left: 456px; position: absolute; top: 416px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label46" Style="z-index: 181; left: 72px; position: absolute; top: 448px" runat="server">14</asp:Label>
                                <asp:TextBox ID="tbSFC14" Style="z-index: 182; left: 88px; position: absolute; top: 448px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label47" Style="z-index: 183; left: 232px; position: absolute; top: 448px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbSFC14_1" Style="z-index: 184; left: 248px; position: absolute; top: 448px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label48" Style="z-index: 185; left: 400px; position: absolute; top: 448px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbSFC14_2" Style="z-index: 186; left: 456px; position: absolute; top: 448px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pJQC" runat="server" Visible="False">
                            <div style="width: 646px; position: relative; height: 288px; left: 0px; top: 0px;">
                                <asp:Label ID="Label49" Style="z-index: 100; left: 24px; position: absolute; top: 8px" runat="server">球队</asp:Label>
                                <asp:TextBox ID="tbJQC2" Style="z-index: 115; left: 88px; position: absolute; top: 64px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label53" Style="z-index: 106; left: 72px; position: absolute; top: 32px" runat="server">1</asp:Label>
                                <asp:Label ID="Label54" Style="z-index: 105; left: 264px; position: absolute; top: 49px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbJQC1" Style="z-index: 101; left: 88px; position: absolute; top: 32px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:TextBox ID="tbJQC1_2" Style="z-index: 104; left: 320px; position: absolute; top: 49px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label56" Style="z-index: 108; left: 72px; position: absolute; top: 64px" runat="server">2</asp:Label>
                                <asp:TextBox ID="tbJQC2_2" Style="z-index: 110; left: 498px; position: absolute; top: 50px" runat="server" MaxLength="19" Width="3px" Visible="False"></asp:TextBox>
                                &nbsp;
                                <asp:Label ID="Label58" Style="z-index: 117; left: 72px; position: absolute; top: 96px" runat="server">3</asp:Label>
                                <asp:TextBox ID="tbJQC3" Style="z-index: 118; left: 88px; position: absolute; top: 96px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label60" Style="z-index: 124; left: 264px; position: absolute; top: 113px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbJQC3_2" Style="z-index: 126; left: 320px; position: absolute; top: 113px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label61" Style="z-index: 107; left: 72px; position: absolute; top: 64px" runat="server">1</asp:Label>
                                <asp:TextBox ID="tbJQC5_2" Style="z-index: 109; left: 320px; position: absolute; top: 177px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label62" Style="z-index: 112; left: 264px; position: absolute; top: 177px" runat="server">比赛时间</asp:Label>
                                <asp:Label ID="Label63" Style="z-index: 116; left: 72px; position: absolute; top: 128px" runat="server">4</asp:Label>
                                <asp:TextBox ID="tbJQC4" Style="z-index: 119; left: 88px; position: absolute; top: 128px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="tbJQC4_2" Style="z-index: 127; left: 500px; position: absolute; top: 113px" runat="server" MaxLength="19" Width="1px" Visible="False"></asp:TextBox>
                                <asp:Label ID="Label66" Style="z-index: 128; left: 72px; position: absolute; top: 160px" runat="server">5</asp:Label>
                                <asp:TextBox ID="tbJQC5" Style="z-index: 130; left: 88px; position: absolute; top: 160px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label68" Style="z-index: 143; left: 72px; position: absolute; top: 192px" runat="server">6</asp:Label>
                                <asp:TextBox ID="tbJQC6" Style="z-index: 136; left: 88px; position: absolute; top: 192px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="tbJQC6_2" Style="z-index: 144; left: 492px; position: absolute; top: 178px" runat="server" MaxLength="19" Width="1px" Visible="False"></asp:TextBox>
                                <asp:Label ID="Label71" Style="z-index: 140; left: 72px; position: absolute; top: 224px" runat="server">7</asp:Label>
                                <asp:TextBox ID="tbJQC7" Style="z-index: 138; left: 88px; position: absolute; top: 224px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label73" Style="z-index: 131; left: 264px; position: absolute; top: 241px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbJQC7_2" Style="z-index: 132; left: 320px; position: absolute; top: 241px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label74" Style="z-index: 129; left: 72px; position: absolute; top: 256px" runat="server">8</asp:Label>
                                <asp:TextBox ID="tbJQC8" Style="z-index: 145; left: 88px; position: absolute; top: 256px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="tbJQC8_2" Style="z-index: 149; left: 497px; position: absolute; top: 242px" runat="server" MaxLength="19" Width="1px" Visible="False"></asp:TextBox>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pLCBQC" runat="server" Visible="False">
                            <div style="width: 644px; position: relative; height: 223px">
                                <asp:Label ID="Label_LCBQC_5" Style="z-index: 100; left: 24px; position: absolute; top: 8px" runat="server">主客队</asp:Label>
                                <asp:TextBox ID="tbLCBQC2" Style="z-index: 115; left: 88px; position: absolute; top: 64px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_9" Style="z-index: 114; left: 232px; position: absolute; top: 64px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbLCBQC2_1" Style="z-index: 113; left: 248px; position: absolute; top: 64px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_8" Style="z-index: 106; left: 72px; position: absolute; top: 32px" runat="server">1</asp:Label>
                                <asp:Label ID="Label_LCBQC_7" Style="z-index: 105; left: 400px; position: absolute; top: 32px" runat="server">比赛时间</asp:Label>
                                <asp:Label ID="Label_LCBQC_6" Style="z-index: 102; left: 232px; position: absolute; top: 32px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbLCBQC1" Style="z-index: 101; left: 88px; position: absolute; top: 32px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:TextBox ID="tbLCBQC1_1" Style="z-index: 103; left: 248px; position: absolute; top: 32px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:TextBox ID="tbLCBQC1_2" Style="z-index: 104; left: 456px; position: absolute; top: 32px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_11" Style="z-index: 108; left: 72px; position: absolute; top: 64px" runat="server">2</asp:Label>
                                <asp:TextBox ID="tbLCBQC2_2" Style="z-index: 110; left: 456px; position: absolute; top: 64px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_10" Style="z-index: 111; left: 400px; position: absolute; top: 64px" runat="server">比赛时间</asp:Label>
                                <asp:Label ID="Label_LCBQC_12" Style="z-index: 117; left: 72px; position: absolute; top: 96px" runat="server">3</asp:Label>
                                <asp:TextBox ID="tbLCBQC3" Style="z-index: 118; left: 88px; position: absolute; top: 96px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_13" Style="z-index: 120; left: 232px; position: absolute; top: 96px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbLCBQC3_1" Style="z-index: 122; left: 248px; position: absolute; top: 96px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_14" Style="z-index: 124; left: 400px; position: absolute; top: 96px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbLCBQC3_2" Style="z-index: 126; left: 456px; position: absolute; top: 96px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:TextBox ID="tbLCBQC5_2" Style="z-index: 109; left: 456px; position: absolute; top: 160px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_16" Style="z-index: 112; left: 400px; position: absolute; top: 160px" runat="server">比赛时间</asp:Label>
                                <asp:Label ID="Label_LCBQC_17" Style="z-index: 116; left: 72px; position: absolute; top: 128px" runat="server">4</asp:Label>
                                <asp:TextBox ID="tbLCBQC4" Style="z-index: 119; left: 88px; position: absolute; top: 128px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_18" Style="z-index: 121; left: 232px; position: absolute; top: 128px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbLCBQC4_1" Style="z-index: 123; left: 248px; position: absolute; top: 128px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_19" Style="z-index: 125; left: 400px; position: absolute; top: 128px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbLCBQC4_2" Style="z-index: 127; left: 456px; position: absolute; top: 128px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_20" Style="z-index: 128; left: 72px; position: absolute; top: 160px" runat="server">5</asp:Label>
                                <asp:TextBox ID="tbLCBQC5" Style="z-index: 130; left: 88px; position: absolute; top: 160px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_21" Style="z-index: 133; left: 232px; position: absolute; top: 160px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbLCBQC5_1" Style="z-index: 134; left: 248px; position: absolute; top: 160px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_22" Style="z-index: 143; left: 72px; position: absolute; top: 192px" runat="server">6</asp:Label>
                                <asp:TextBox ID="tbLCBQC6" Style="z-index: 136; left: 88px; position: absolute; top: 192px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_25" Style="z-index: 142; left: 232px; position: absolute; top: 192px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbLCBQC6_1" Style="z-index: 141; left: 248px; position: absolute; top: 192px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:Label ID="Label_LCBQC_26" Style="z-index: 137; left: 400px; position: absolute; top: 192px" runat="server">比赛时间</asp:Label>
                                <asp:TextBox ID="tbLCBQC6_2" Style="z-index: 144; left: 456px; position: absolute; top: 192px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pLCDC" runat="server" Visible="False">
                            <div style="width: 644px; position: relative; height: 60px; left: 0px; top: 0px;">
                                <asp:Label ID="Label_LCDC_5" Style="z-index: 100; left: 24px; position: absolute; top: 8px" runat="server">主客队</asp:Label>
                                <asp:Label ID="Label_LCDC_8" Style="z-index: 106; left: 72px; position: absolute; top: 32px" runat="server">1</asp:Label>
                                <asp:Label ID="Label_LCDC_7" Style="z-index: 105; left: 400px; position: absolute; top: 32px" runat="server">比赛时间</asp:Label>
                                <asp:Label ID="Label_LCDC_6" Style="z-index: 102; left: 232px; position: absolute; top: 32px" runat="server">VS</asp:Label>
                                <asp:TextBox ID="tbLCDC1" Style="z-index: 101; left: 88px; position: absolute; top: 32px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:TextBox ID="tbLCDC1_1" Style="z-index: 103; left: 248px; position: absolute; top: 32px" runat="server" MaxLength="10" Width="136px"></asp:TextBox>
                                <asp:TextBox ID="tbLCDC1_2" Style="z-index: 104; left: 456px; position: absolute; top: 32px" runat="server" MaxLength="19" Width="160px"></asp:TextBox>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="ZCDC" runat="server" Visible="False">
                            <asp:DataList ID="DataListZCDC" runat="server" RepeatColumns="1" ShowFooter="False" OnItemCommand="DataListZCDC_ItemCommand" OnItemDataBound="DataListZCDC_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="tableZCDC" align="center" style="width: 642px">
                                        <tr>
                                            <td align="center" style="height: 21px; width: 40px;">
                                                场次
                                            </td>
                                            <td align="center" style="height: 21px; width: 126px;">
                                                联赛类别
                                            </td>
                                            <td align="center" style="height: 21px; width: 160px;">
                                                主队/让球
                                            </td>
                                            <td style="height: 21px; width: 45px;" align="center">
                                                <font color="red"><b>VS</b></font>
                                            </td>
                                            <td align="center" style="height: 21px; width: 110px;">
                                                客队
                                            </td>
                                            <td align="center" style="width: 110px; height: 21px">
                                                比赛时间<br />
                                                (0000-00-00 00:00:00)
                                            </td>
                                            <td align="center" style="width: 40px; height: 21px; display: none;">
                                                更新
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table align="center" style="width: 642px">
                                        <tr>
                                            <td align="center" style="height: 21px; width: 40px;">
                                                <asp:Label ID="lbZCDC" runat="server" Text='<%# Eval("[No]")%>'></asp:Label>
                                            </td>
                                            <td align="center" style="height: 21px; width: 126px;">
                                                <asp:DropDownList ID="ddlLeagueType" runat="server">
                                                </asp:DropDownList><asp:HiddenField ID="hfTypeid" runat="server" Value='<%# Eval("LeagueTypeID")%>' />
                                                <asp:HiddenField ID="hfLetBall" runat="server" Value='<%# Eval("LetBall")%>' />
                                            </td>
                                            <td align="center" style="height: 21px; width: 180px;">
                                                <asp:TextBox ID="tb1ZCDC" MaxLength="20" runat="server" Width="110px" Text='<%# Eval("HostTeam")%>'></asp:TextBox>
                                                <asp:DropDownList ID="ddlLetBall" runat="server" Width="40px">
                                                    <asp:ListItem Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="-1">-1</asp:ListItem>
                                                    <asp:ListItem Value="-2">-2</asp:ListItem>
                                                    <asp:ListItem Value="-3">-3</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 21px; width: 45px;" align="center">
                                                <font color="red"><b>VS</b></font>
                                            </td>
                                            <td align="center" style="height: 21px; width: 110px;">
                                                <asp:TextBox ID="tb2ZCDC" runat="server" MaxLength="20" Width="110px" Text='<%# Eval("QuestTeam")%>'></asp:TextBox>
                                            </td>
                                            <td align="center" style="width: 110px; height: 21px">
                                                <asp:TextBox ID="tb3ZCDC" runat="server" Width="110px" Text='<%# Eval("DateTime")%>' MaxLength="20"></asp:TextBox>
                                            </td>
                                            <td align="center" style="width: 60px; height: 21px; display: none;">
                                                <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("id")%>' />
                                                <ShoveWebUI:ShoveConfirmButton ID="btEdit" CommandName="btEdit" Visible="false" runat="server" Text="修改" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <table align="center" style="width: 642px">
                                        <tr>
                                            <td align="center" style="height: 21px; width: 40px;">
                                                <asp:Label ID="lbZCDC" runat="server" Text='<%# Eval("[No]")%>'></asp:Label>
                                            </td>
                                            <td align="center" style="height: 21px; width: 126px;">
                                                <asp:DropDownList ID="ddlLeagueType" runat="server">
                                                </asp:DropDownList><asp:HiddenField ID="hfTypeid" runat="server" Value='<%# Eval("LeagueTypeID")%>' />
                                                <asp:HiddenField ID="hfLetBall" runat="server" Value='<%# Eval("LetBall")%>' />
                                            </td>
                                            <td align="center" style="height: 21px; width: 180px;">
                                                <asp:TextBox ID="tb1ZCDC" Width="110px" runat="server" MaxLength="20" Text='<%# Eval("HostTeam")%>'></asp:TextBox>
                                                <asp:DropDownList ID="ddlLetBall" runat="server" Width="40px">
                                                    <asp:ListItem Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="-1">-1</asp:ListItem>
                                                    <asp:ListItem Value="-2">-2</asp:ListItem>
                                                    <asp:ListItem Value="-3">-3</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 21px; width: 45px;" align="center">
                                                <font color="red"><b>VS</b></font>
                                            </td>
                                            <td align="center" style="height: 21px; width: 110px;">
                                                <asp:TextBox ID="tb2ZCDC" runat="server" Width="110px" MaxLength="20" Text='<%# Eval("QuestTeam")%>'></asp:TextBox>
                                            </td>
                                            <td align="center" style="width: 110px; height: 21px">
                                                <asp:TextBox ID="tb3ZCDC" runat="server" Width="110px" MaxLength="20" Text='<%# Eval("DateTime").ToString()%>'></asp:TextBox>
                                            </td>
                                            <td align="center" style="width: 60px; height: 21px">
                                                <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("id")%>' />
                                                <ShoveWebUI:ShoveConfirmButton ID="btUpdate" CommandName="btUpdate" Visible="false" runat="server" Text="确定" />
                                            </td>
                                        </tr>
                                    </table>
                                </EditItemTemplate>
                                <EditItemStyle BackColor="#99CCFF" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                            </asp:DataList>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
         <asp:HiddenField ID="hidID" runat="server" />
             <asp:HiddenField ID="moneyID" runat="server" />
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
