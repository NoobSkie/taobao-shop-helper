using AjaxPro;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using SLS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Lottery_Buy : RoomPageBase, IRequiresSessionState
{
    public string DZ = "";
    public string InforMationName = "";
    public static Dictionary<int, string> LotteriesIntro = new Dictionary<int, string>();
    public int LotteryID;
    public string LotteryName;
    public static Dictionary<int, string> LotteryPlayTypes = new Dictionary<int, string>();
    public static Dictionary<int, string> LotteryPlayTypesPages = new Dictionary<int, string>();
    public static Dictionary<int, string[]> NewsType = new Dictionary<int, string[]>();
    private static Dictionary<int, int[]> NumberCount = new Dictionary<int, int[]>();
    public string script = "";

    static Lottery_Buy()
    {
        NewsType[5] = new string[] { "双色球预测", "双色球花絮", "双色球技巧" };
        NewsType[6] = new string[] { "3D预测", "3D喜报", "3D技巧" };
        NumberCount[5] = new int[] { 6, 1 };
        int[] numArray2 = new int[2];
        numArray2[0] = 7;
        NumberCount[3] = numArray2;
        int[] numArray3 = new int[2];
        numArray3[0] = 3;
        NumberCount[6] = numArray3;
        NumberCount[0x27] = new int[] { 5, 2 };
        NumberCount[0x3a] = new int[] { 6, 1 };
        int[] numArray6 = new int[2];
        numArray6[0] = 5;
        NumberCount[0x3b] = numArray6;
        int[] numArray7 = new int[2];
        numArray7[0] = 7;
        NumberCount[13] = numArray7;
        int[] numArray8 = new int[2];
        numArray8[0] = 5;
        NumberCount[9] = numArray8;
        int[] numArray9 = new int[2];
        numArray9[0] = 3;
        NumberCount[0x3f] = numArray9;
        int[] numArray10 = new int[2];
        numArray10[0] = 5;
        NumberCount[0x40] = numArray10;
        int[] numArray11 = new int[2];
        numArray11[0] = 7;
        NumberCount[0x41] = numArray11;
        LotteriesIntro[3] = "<span class='blue18'>七星彩：2元可中￥500万</span> 每周二、五、日开奖";
        LotteriesIntro[5] = "<span class='blue18'>双色球：2元赢取￥1500万</span> 每周二、四、日20:45开奖";
        LotteriesIntro[6] = "<span class='blue18'>福彩3D：2元赢取￥1000元</span> 多种玩法,更多中奖机会,每日20:30开奖";
        LotteriesIntro[0x27] = "<span class='blue18'>大乐透：3元赢取￥2400万</span> 每周一、三、六开奖";
        LotteriesIntro[0x3a] = "<span class='blue18'>东方6+1：2元最高可达￥500万</span> 每周一、三、六18:55开奖";
        LotteriesIntro[0x3b] = "<span class='blue18'>15选5：2元最高可达￥500万</span> 每日19:45开奖";
        LotteriesIntro[13] = "<span class='blue18'>七乐彩：2元最高可达￥500万</span> 每周一、三、五20:45开奖";
        LotteriesIntro[9] = "<span class='blue18'>22选5：2元最高可达￥500万</span> 每日开奖";
        LotteriesIntro[0x3f] = "<span class='blue18'>排列3：2元赢取￥1000元</span> 每日开奖";
        LotteriesIntro[0x40] = "<span class='blue18'>排列5：2元赢取￥10万</span> 每日开奖";
        LotteriesIntro[0x41] = "<span class='blue18'>31选7：2元最高可达￥500万</span> 每周一、四、六开奖";
        LotteryPlayTypes[3] = "<tr><td width='70' height='28' align='center' bgcolor='#F7FCFF' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <input type='radio' name='playType' id='playType301' value='301' checked='checked' onclick='clickPlayType(this.value)' />单式\r\n                            <input type='radio' name='playType' id='playType302' value='302' onclick='clickPlayType(this.value)' />复式</td></tr>";
        LotteryPlayTypes[5] = "<tr><td width='70' height='28' align='center' bgcolor='#F7FCFF' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <input type='radio' name='playType' id='playType501' value='501' checked='checked' onclick='clickPlayType(this.value)' />单式\r\n                            <input type='radio' name='playType' id='playType502' value='502' onclick='clickPlayType(this.value)' />复式\r\n                            <input type='radio' name='playType' id='playType503' value='503' onclick='clickPlayType(this.value)' />胆拖\r\n                            <input type='radio' name='playType' id='playType504' value='504' onclick='clickPlayType(this.value)' /><span class='blue12'>智能机选</span><sup><img src='../Home/Room/Images/ico_new.gif'></sup></td></tr>";
        LotteryPlayTypes[6] = "<tr><td width='70' height='28' align='center' bgcolor='#F7FCFF' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <strong>直选:</strong>\r\n                            <input type='radio' name='playType' id='playType601' value='601' checked='checked' onclick='clickPlayType(this.value)' />单式<input type='radio' name='playType' id='playType602' value='602' onclick='clickPlayType(this.value)' />复式<input type='radio' name='playType' id='playType606' value='606' onclick='clickPlayType(this.value)' />包点\r\n                            <span style='margin-left: 10px;'></span><strong>组选:</strong>\r\n                            <input type='radio' name='playType' id='playType603' value='603' onclick='clickPlayType(this.value)' />单式<input type='radio' name='playType' id='playType604' value='604' onclick='clickPlayType(this.value)' />组6复式<input type='radio' name='playType' id='playType605' value='605' onclick='clickPlayType(this.value)' />组3复式<input type='radio' name='playType' id='playType607' value='607' onclick='clickPlayType(this.value)' />包点</td></tr>";
        LotteryPlayTypes[0x27] = "<tr><td width='70' height='28' align='center' bgcolor='#F7F7F7' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <input type='radio' name='playType' id='playType3901' value='3901' checked='checked' onclick='clickPlayType(this.value)' />单式\r\n                            <input type='radio' name='playType' id='playType3902' value='3902' onclick='clickPlayType(this.value)' />复式\r\n                            <input type='radio' name='playType' id='playType3903' value='3903' onclick='clickPlayType(this.value)' />追加单式\r\n                            <input type='radio' name='playType' id='playType3904' value='3904' onclick='clickPlayType(this.value)' />追加复式\r\n                            <input type='radio' name='playType' id='playType3905' value='3905' onclick='clickPlayType(this.value)' />12选2单式\r\n                            <input type='radio' name='playType' id='playType3906' value='3906' onclick='clickPlayType(this.value)' />12选2复式\r\n                            <input type='radio' name='playType' id='playType3907' value='3907' onclick='clickPlayType(this.value)' /><span class='blue12'>智能机选</span><sup><img src='../Home/Room/Images/ico_new.gif'></sup></td></tr>";
        LotteryPlayTypes[0x3a] = "<tr><td width='70' height='28' align='center' bgcolor='#F7F7F7' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <input type='radio' name='playType' id='playType5801' value='5801' checked='checked' onclick='clickPlayType(this.value)' />单式\r\n                            <input type='radio' name='playType' id='playType5802' value='5802' onclick='clickPlayType(this.value)' />复式\r\n</td></tr>";
        LotteryPlayTypes[0x3b] = "<tr><td width='70' height='28' align='center' bgcolor='#F7F7F7' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <input type='radio' name='playType' id='playType5901' value='5901' checked='checked' onclick='clickPlayType(this.value)' />单式\r\n                            <input type='radio' name='playType' id='playType5902' value='5902' onclick='clickPlayType(this.value)' />复式\r\n                            <input type='radio' name='playType' id='playType5903' value='5903' onclick='clickPlayType(this.value)' />胆拖</td></tr>";
        LotteryPlayTypes[13] = "<tr><td width='70' height='28' align='center' bgcolor='#F7F7F7' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <input type='radio' name='playType' id='playType1301' value='1301' checked='checked' onclick='clickPlayType(this.value)' />单式\r\n                            <input type='radio' name='playType' id='playType1302' value='1302' onclick='clickPlayType(this.value)' />复式\r\n</td></tr>";
        LotteryPlayTypes[9] = "<tr><td width='70' height='28' align='center' bgcolor='#F7F7F7' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <input type='radio' name='playType' id='playType901' value='901' checked='checked' onclick='clickPlayType(this.value)' />单式\r\n                            <input type='radio' name='playType' id='playType902' value='902' onclick='clickPlayType(this.value)' />复式\r\n</td></tr>";
        LotteryPlayTypes[0x3f] = "<tr><td width='70' height='28' align='center' bgcolor='#F7F7F7' class='black12'>选择玩法</td>\r\n                                 <td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;padding-top:5px;'>\r\n                                  <table width='100%' cellpadding='0'border='0' cellspacing='0' style='text-align: center;margin-top:5px;' id='tbPlayTypeMenu63'>\r\n                                    <tr>\r\n                                        <td width='10' height='29'>&nbsp;</td>\r\n                                        <td class='msplay' onclick='clickPlayClass(0,this)' onmouseover='mOver(this,1)' onmouseout='mOver(this,2)'>\r\n                                            直选\r\n                                        </td>\r\n                                        <td width='1'></td>\r\n                                        <td class='nsplay' onclick='clickPlayClass(1,this)' onmouseover='mOver(this,1)' onmouseout='mOver(this,2)'>\r\n                                            组选单式\r\n                                        </td>\r\n                                        <td width='1'></td>\r\n                                        <td class='nsplay' onclick='clickPlayClass(2,this)' onmouseover='mOver(this,1)' onmouseout='mOver(this,2)'>\r\n                                            组选6\r\n                                        </td>\r\n                                        <td width='1'></td>\r\n                                        <td class='nsplay' onclick='clickPlayClass(3,this)' onmouseover='mOver(this,1)' onmouseout='mOver(this,2)'>\r\n                                            组选3\r\n                                        </td>\r\n                                         <td width='1'></td>\r\n                                        <td class='nsplay' onclick='clickPlayClass(4,this)'onmouseover='mOver(this,1)' onmouseout='mOver(this,2)'>\r\n                                            和值\r\n                                        </td>\r\n                                        <td>&nbsp;</td>\r\n                                    </tr>\r\n                                  </table>\r\n                                       <table width='100%' border='0' cellspacing='0' cellpadding='0'>\r\n                                         <tr>\r\n                                           <td height='1'  bgcolor='#FFFFFF'></td>\r\n                                         </tr>\r\n                                         <tr>\r\n                                           <td height='2'  bgcolor='#6699CC'></td>\r\n                                         </tr>\r\n                                    </table>\r\n                                </td>\r\n                              </tr>\r\n                              <tr id='playTypes'>\r\n                                <td height='30' bgcolor='#F7F7F7' align='center'>\r\n                                    投注方式\r\n                                </td>\r\n                                <td bgcolor='#FFFFFF' style='padding-left: 5px; text-align: left;'>\r\n                                    <span id='playTypes0'>\r\n                                        <input type='radio' name='playType' id='playType6301' value='6301' checked='checked'\r\n                                            onclick='clickPlayType(this.value)' />直选单式\r\n                                        <input type='radio' name='playType' id='playType6302' value='6302' onclick='clickPlayType(this.value)' />直选复式\r\n                                    </span><span id='playTypes1' style='display: none;'>\r\n                                        <input type='radio' name='playType' id='playType6303' value='6303' onclick='clickPlayType(this.value)' />组选单式\r\n                                    </span><span id='playTypes2' style='display: none;'>\r\n                                        <input type='radio' name='playType' id='playType6304' value='6304' onclick='clickPlayType(this.value)' />组选6\r\n                                    </span><span id='playTypes3' style='display: none;'>\r\n                                        <input type='radio' name='playType' id='playType6305' value='6305' onclick='clickPlayType(this.value)' />组选3\r\n                                    </span><span id='playTypes4' style='display: none;'>\r\n                                        <input type='radio' name='playType' id='playType6306' value='6306' onclick='clickPlayType(this.value)' />直选\r\n                                        <input type='radio' name='playType' id='playType6307' value='6307' onclick='clickPlayType(this.value)' />组选\r\n                                    </span>\r\n                                </td>\r\n                            </tr>";
        LotteryPlayTypes[0x40] = "<tr><td width='70' height='28' align='center' bgcolor='#F7F7F7' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <input type='radio' name='playType' id='playType6401' value='6401'  onclick='clickPlayType(this.value)' />单式\r\n                            <input type='radio' name='playType' id='playType6402' value='6402' onclick='clickPlayType(this.value)' />复式\r\n</td></tr>";
        LotteryPlayTypes[0x41] = "<tr><td width='70' height='28' align='center' bgcolor='#F7F7F7' class='black12'>选择玩法</td><td bgcolor='#FFFFFF' class='black12' style='padding-left: 5px;'>\r\n                            <input type='radio' name='playType' id='playType6501' value='6501' checked='checked' onclick='clickPlayType(this.value)' />单式\r\n                            <input type='radio' name='playType' id='playType6502' value='6502' onclick='clickPlayType(this.value)' />复式</td></tr>";
        LotteryPlayTypesPages[3] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '302':\r\n            playTypeName = '复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/QXC/QXC_F.htm';\r\n            break;\r\n\r\n        default:\r\n            t = '301';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/QXC/QXC_D.htm';\r\n            break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n        \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
        LotteryPlayTypesPages[5] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '502':\r\n            document.getElementById('spanJX').style.display = 'none';\r\n            document.getElementById('btnPaste').style.display = '';\r\n            playTypeName = '复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/ssq/SSQ_F.htm';\r\n            break;\r\n\r\n        case '503':\r\n            document.getElementById('spanJX').style.display = 'none';\r\n            document.getElementById('btnPaste').style.display = '';\r\n            playTypeName = '胆拖';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/ssq/SSQ_DanT.htm';\r\n            break;\r\n\r\n        case '504':\r\n            document.getElementById('spanJX').style.display = '';\r\n            document.getElementById('btnPaste').style.display = 'none';\r\n            document.getElementById('tbPlayTypeID').value = '501';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/ssq/SSQ_ZNJX.htm';\r\n            break;\r\n\r\n        default:\r\n            document.getElementById('spanJX').style.display = 'none';\r\n            document.getElementById('btnPaste').style.display = '';\r\n            t = '501';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/ssq/SSQ_D.htm';\r\n            break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n         \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
        LotteryPlayTypesPages[6] = "$Id('tbPlayTypeName').value = '直选单式';\r\n        function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '602':\r\n            playTypeName = '直选复式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/fc3d/FC3D_ZhiF.htm';\r\n        break;\r\n        \r\n        case '603':\r\n            playTypeName = '组选单式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/fc3d/FC3D_ZuD.htm';\r\n        break;\r\n        \r\n        case '604':\r\n            playTypeName = '组选6复式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/fc3d/FC3D_Zu6F.htm';\r\n        break;\r\n        \r\n        case '605':\r\n            playTypeName = '组选3复式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/fc3d/FC3D_Zu3F.htm';\r\n        break;\r\n        \r\n        case '606':\r\n            playTypeName = '直选包点';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/fc3d/FC3D_ZhiB.htm';\r\n        break;\r\n        \r\n        case '607':\r\n            playTypeName = '组选包点';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/fc3d/FC3D_ZuB.htm';\r\n        break;\r\n        \r\n        default:\r\n            t='601';\r\n            playTypeName = '直选单式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/fc3d/FC3D_ZhiD.htm';\r\n        break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n           \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
        LotteryPlayTypesPages[0x27] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '3902':\r\n            document.getElementById('spanJX').style.display = 'none';\r\n            document.getElementById('btnPaste').style.display = '';\r\n            playTypeName = '复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/dlt/DLT_F.htm';\r\n            $Id('HidPrice').value = '2';\r\n            break;\r\n\r\n        case '3903':\r\n            document.getElementById('spanJX').style.display = 'none';\r\n            document.getElementById('btnPaste').style.display = '';\r\n            playTypeName = '追加单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/dlt/DLT_ZJ_D.htm';\r\n            $Id('HidPrice').value = '3';\r\n            break;\r\n\r\n        case '3904':\r\n            document.getElementById('spanJX').style.display = 'none';\r\n            document.getElementById('btnPaste').style.display = '';\r\n            playTypeName = '追加复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/dlt/DLT_ZJ_F.htm';\r\n            $Id('HidPrice').value = '3';\r\n            break;\r\n\r\n        case '3905':\r\n            document.getElementById('spanJX').style.display = 'none';\r\n            document.getElementById('btnPaste').style.display = '';\r\n            playTypeName = '12选2单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/dlt/DLT_2_D.htm';\r\n            $Id('HidPrice').value = '2';\r\n            break;\r\n\r\n        case '3906':\r\n            document.getElementById('spanJX').style.display = 'none';\r\n            document.getElementById('btnPaste').style.display = '';\r\n            playTypeName = '12选2复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/dlt/DLT_2_F.htm';\r\n            $Id('HidPrice').value = '2';\r\n            break;\r\n        \r\n          case '3907':\r\n            document.getElementById('spanJX').style.display = '';\r\n            document.getElementById('btnPaste').style.display = 'none';\r\n            document.getElementById('tbPlayTypeID').value = '3901';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/dlt/DLT_ZNJX.htm';\r\n            $Id('HidPrice').value = '2';\r\n            break;\r\n\r\n        default:\r\n            document.getElementById('spanJX').style.display = 'none';\r\n            document.getElementById('btnPaste').style.display = '';\r\n            t='3901';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/dlt/DLT_D.htm';\r\n            $Id('HidPrice').value = '2';\r\n            break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n            \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
        LotteryPlayTypesPages[0x3a] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '5802':\r\n            playTypeName = '复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/DF6J1/DF6J1_F.htm';\r\n            break;\r\n\r\n        default:\r\n            t = '5801';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/DF6J1/DF6J1_D.htm';\r\n            break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n           \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
        LotteryPlayTypesPages[0x3b] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '5902':\r\n            playTypeName = '复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/AHFC15X5/AHFC15X5_F.htm';\r\n            break;\r\n\r\n        case '5903':\r\n            playTypeName = '胆拖';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/AHFC15X5/AHFC15X5_DT.htm';\r\n            break;\r\n\r\n        default:\r\n            t = '5901';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/AHFC15X5/AHFC15X5_D.htm';\r\n            break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n         \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
        LotteryPlayTypesPages[13] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '1302':\r\n            playTypeName = '复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/QLC/QLC_F.htm';\r\n            break;\r\n\r\n        default:\r\n            t = '1301';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/QLC/QLC_D.htm';\r\n            break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n           \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
        LotteryPlayTypesPages[9] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '902':\r\n            playTypeName = '复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/TC22X5/TC22X5_F.htm';\r\n            break;\r\n\r\n        default:\r\n            t = '901';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/TC22X5/TC22X5_D.htm';\r\n            break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n          \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
        LotteryPlayTypesPages[0x3f] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '6302':\r\n            playTypeName = '排列3直选复式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/SZPL3/SZPL3_ZhiF.htm';\r\n        break;\r\n        \r\n        case '6303':\r\n            playTypeName = '排列3组选单式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/SZPL3/SZPL3_ZuD.htm';\r\n        break;\r\n        \r\n        case '6304':\r\n            playTypeName = '排列3组选6复式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/SZPL3/SZPL3_Zu6F.htm';\r\n        break;\r\n        \r\n        case '6305':\r\n            playTypeName = '排列3组选3复式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/SZPL3/SZPL3_Zu3F.htm';\r\n        break;\r\n        \r\n        case '6306':\r\n            playTypeName = '排列3直选和值';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/SZPL3/SZPL3_ZhiH.htm';\r\n        break;\r\n        \r\n        case '6307':\r\n            playTypeName = '排列3组选和值';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/SZPL3/SZPL3_ZuH.htm';\r\n        break;\r\n       \r\n        default:\r\n            t='6301';\r\n            playTypeName = '直选单式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/SZPL3/SZPL3_ZhiD.htm';\r\n        break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n          \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }\r\n        \r\n        function clickPlayClass(i,obj)\r\n        {\r\n            var tds = obj.offsetParent.rows[0].cells;\r\n            for(var a=0; a<tds.length-1; a++)\r\n            {\r\n                    if(a%2==1)\r\n                    {\r\n                        tds[a].className = 'nsplay';\r\n                    }\r\n                    if($Id('playTypes' + String(a))!=null)\r\n                    {\r\n                         $Id('playTypes' + String(a)).style.display = 'none'\r\n                    }\r\n            }\r\n            \r\n            var pt = $Id('playTypes' + String(i));\r\n            pt.style.display = ''\r\n            $Id('playTypes').style.display = ((i == 1 || i == 2 || i == 3) ? 'none':'');\r\n            obj.className = 'msplay';\r\n            pt.childNodes[0].checked = true;\r\n            clickPlayType(pt.childNodes[0].value);\r\n        }";
        LotteryPlayTypesPages[0x40] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n      \r\n        case '6402':\r\n            playTypeName = '排列5复式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/SZPL5/SZPL5_F.htm';\r\n        break;\r\n\r\n        default:\r\n            t='6401';\r\n            playTypeName = '排列5单式';\r\n            iframe_playtypes.location.href='../Home/Room/playtypes/SZPL5/SZPL5_D.htm';\r\n        break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n          \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
        LotteryPlayTypesPages[0x41] = "function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;\r\n        var playTypeName = '';\r\n        switch (t) {\r\n        case '6502':\r\n            playTypeName = '复式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/TC31X7/TC31X7_F.htm';\r\n            break;\r\n\r\n        default:\r\n            t = '6501';\r\n            playTypeName = '单式';\r\n            iframe_playtypes.location.href = '../Home/Room/playtypes/TC31X7/TC31X7_D.htm';\r\n            break;\r\n        }\r\n\r\n            $Id('tbPlayTypeName').value = playTypeName;\r\n          \r\n            HidBtnRand(playTypeName);\r\n\r\n            resetPage();\r\n        }";
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string AnalyseScheme(string Content, string LotteryID, int PlayTypeID)
    {
        return new Lottery()[_Convert.StrToInt(LotteryID, 0)].AnalyseScheme(Content, PlayTypeID).Trim();
    }

    private void BindDataForAliBuy(long BuyID)
    {
        DataTable table = new Tables.T_AlipayBuyTemp().Open("", "ID=" + BuyID.ToString(), "");
        if ((table != null) && (table.Rows.Count != 0))
        {
            DataRow row = table.Rows[0];
            string s = row["IsuseID"].ToString();
            string str2 = row["PlayTypeID"].ToString();
            bool flag = _Convert.StrToBool(row["IsChase"].ToString(), false);
            bool flag2 = _Convert.StrToBool(row["IsCoBuy"].ToString(), false);
            string str3 = row["Share"].ToString();
            string str4 = row["BuyShare"].ToString();
            string str5 = row["AssureShare"].ToString();
            string str6 = row["OpenUsers"].ToString();
            string str7 = row["Title"].ToString();
            string str8 = row["Description"].ToString();
            string str9 = row["StopwhenwinMoney"].ToString();
            string str10 = row["SecrecyLevel"].ToString();
            string str11 = row["LotteryNumber"].ToString();
            string str12 = row["SumMoney"].ToString();
            string str13 = row["AssureMoney"].ToString();
            string str14 = row["LotteryID"].ToString();
            string str15 = row["Multiple"].ToString();
            string xml = row["AdditionasXml"].ToString();
            if (str15 == "")
            {
                str15 = "1";
            }
            double num = 0.0;
            int num2 = 0;
            int num3 = 0;
            double num4 = 0.0;
            int num5 = 0;
            short num6 = 0;
            int playType = 0;
            int num8 = 0;
            try
            {
                num = double.Parse(str12);
                num2 = int.Parse(str3);
                num3 = int.Parse(str4);
                num4 = double.Parse(str13);
                num5 = int.Parse(str15);
                num6 = short.Parse(str10);
                playType = int.Parse(str2);
                num8 = int.Parse(str14);
                long.Parse(s);
                double.Parse(str9);
            }
            catch
            {
            }
            if ((num3 == num2) && (num4 == 0.0))
            {
                num2 = 1;
                num3 = 1;
            }
            double num1 = num / ((double)num2);
            if (flag)
            {
                double.Parse(str12);
            }
            string str17 = str11;
            if (str17[str17.Length - 1] == '\n')
            {
                str17 = str17.Substring(0, str17.Length - 1);
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<script type='text/javascript' defer='defer'>");
            if (num8 == 0x3f)
            {
                builder.AppendLine("function clickPlayClass(i,obj)").AppendLine("{").AppendLine("var tds = obj.offsetParent.rows[0].cells;").AppendLine("for(var a=0; a<tds.length-1; a++)").AppendLine("{").AppendLine("if(a%2==1)").AppendLine("{").AppendLine("tds[a].className = 'nsplay';").AppendLine("}").AppendLine("if($Id('playTypes' + String(a))!=null)").AppendLine("{").AppendLine("$Id('playTypes' + String(a)).style.display = 'none';").AppendLine("}").AppendLine("}").AppendLine("var pt = $Id('playTypes' + String(i));").AppendLine("pt.style.display = '';");
                builder.AppendLine("$Id('playTypes').style.display = ((i == 1 || i == 2 || i == 3) ? 'none':'');");
                builder.AppendLine("obj.className = 'msplay';").AppendLine("}");
                builder.Append("var playclass =").Append("$Id('playType").Append(playType.ToString()).AppendLine("').parentNode.id.substr(9,1);");
                builder.Append("clickPlayClass(playclass,").Append("$Id('tbPlayTypeMenu").Append(num8.ToString()).AppendLine("').rows[0].cells[playclass*2+1]);");
            }
            builder.Append("$Id('playType").Append(playType.ToString()).AppendLine("').checked = true;");
            builder.AppendLine("clickPlayType('" + playType.ToString() + "');");
            builder.AppendLine("function BindDataForFromAli(){");
            if (flag)
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                foreach (XmlNode node in document.ChildNodes[0].ChildNodes)
                {
                    builder.Append("$Id('times").Append(node.Attributes["IsuseID"].Value).Append("').value = '").Append(node.Attributes["Multiple"].Value).AppendLine("';");
                    builder.Append("$Id('money").Append(node.Attributes["IsuseID"].Value).Append("').value = '").Append(node.Attributes["Money"].Value).AppendLine("';");
                    builder.Append("$Id('check").Append(node.Attributes["IsuseID"].Value).AppendLine("').checked = true;");
                    builder.Append("$Id('times").Append(node.Attributes["IsuseID"].Value).AppendLine("').disabled = '';");
                }
            }
            str17 = str17.Replace("\r", "");
            int num9 = 0;
            string canonicalNumber = "";
            foreach (string str19 in str17.Split(new char[] { '\n' }))
            {
                num9 += new Lottery()[num8].ToSingle(str19, ref canonicalNumber, playType).Length;
                builder.AppendLine("var option = document.createElement('option');");
                builder.AppendLine("$Id('list_LotteryNumber').options.add(option);");
                builder.Append("option.innerText = '").Append(str19).AppendLine("';");
                builder.Append("option.value = '").Append(str19).AppendLine("';");
            }
            if (flag)
            {
                builder.AppendLine("$Id('Chase').checked = true;");
                builder.AppendLine("oncbInitiateTypeClick($Id('Chase'));");
            }
            if (flag2)
            {
                builder.AppendLine("$Id('CoBuy').checked = true;");
                builder.AppendLine("oncbInitiateTypeClick($Id('CoBuy'));");
            }
            builder.Append("$Id('tb_LotteryNumber').value = '").Append(str11.Replace("\r", @"\r").Replace("\n", @"\n")).AppendLine("';");
            builder.Append("$Id('tb_Share').value = '").Append(str3).AppendLine("';");
            builder.Append("$Id('tb_BuyShare').value = '").Append(str4).AppendLine("';");
            builder.Append("$Id('tb_AssureShare').value = '").Append(str5).AppendLine("';");
            builder.Append("$Id('tb_OpenUserList').value = '").Append(str6).AppendLine("';");
            builder.Append("$Id('tb_Title').value = '").Append(str7).AppendLine("';");
            builder.Append("$Id('tb_Description').value = '").Append(str8.Replace("\r", @"\r").Replace("\n", @"\n")).AppendLine("';");
            builder.Append("$Id('tbAutoStopAtWinMoney').value = '").Append(str9).AppendLine("';");
            builder.Append("$Id('SecrecyLevel").Append(num6.ToString()).AppendLine("').checked = true;");
            builder.Append("$Id('tb_hide_SumMoney').value = '").Append(str12).AppendLine("';");
            builder.Append("$Id('tb_hide_AssureMoney').value = '").Append(num4.ToString("N0")).AppendLine("';");
            builder.Append("$Id('tb_Multiple').value = '").Append(num5.ToString()).AppendLine("';");
            builder.Append("$Id('lab_AssureMoney').innerText = '").Append(num4.ToString("N0")).AppendLine("';");
            builder.Append("$Id('lab_SumMoney').innerText = '").Append(num.ToString("N0")).AppendLine("';");
            builder.Append("$Id('LbSumMoney').innerText = '").Append(num.ToString("N0")).AppendLine("';");
            builder.Append("$Id('lab_Num').innerText = '").Append(num9.ToString()).AppendLine("';");
            builder.AppendLine("CalcResult();");
            builder.AppendLine("}");
            builder.AppendLine("</script>");
            this.script = builder.ToString();
        }
    }

    private string BindNewsForLottery(string TypeName)
    {
        string lotteryName = this.LotteryName;
        if (lotteryName == "福彩3D")
        {
            lotteryName = "3D";
        }
        string key = "Home_Room_Buy_BindNewsForLottery" + this.LotteryID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Views.V_News().Open("Title,Content,DateTime,TypeName", "IsShow=1 and TypeName like '" + lotteryName + "%'", "");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                return "";
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        DataRow[] rowArray = cacheAsDataTable.Select("TypeName='" + TypeName + "'", "DateTime desc");
        StringBuilder builder = new StringBuilder();
        builder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
        string input = "";
        string str4 = "";
        int num = 0;
        foreach (DataRow row in rowArray)
        {
            num++;
            if ((num % 6) == 0)
            {
                builder.Append("<tr><td colspan='2'><div id='hr' style=\"margin-top: 5px;margin-bottom: 5px;\" ></div> </td></tr>");
            }
            input = row["Title"].ToString().Trim();
            if ((input.IndexOf("<font class=red12>") > -1) || (input.IndexOf("<font class=black12>") > -1))
            {
                if (input.Contains("<font class=red12>"))
                {
                    str4 = "red12";
                }
                if (input.Contains("<font class=black12>"))
                {
                    str4 = "black12";
                }
                input = input.Replace("<font class=red12>", "").Replace("<font class=black12>", "").Replace("</font>", "");
                builder.Append("<tr>").Append("<td width=\"5%\" height=\"22\" align=\"center\" class=\"hui14\">").Append("<img src=\"../Home/Room/Images/jiantou_3.gif\" width=\"4\" height=\"8\" />").Append("</td>").Append("<td width=\"95%\" height=\"22\" class=\"hui12\">").Append("<a href='" + row["Content"].ToString() + "' target='_blank'>").Append("<font class = '" + str4 + "'>").Append(_String.Cut(input, 20)).Append("</font>").Append("</a></td></tr>");
            }
            else
            {
                builder.Append("<tr>").Append("<td width=\"5%\" height=\"22\" align=\"center\" class=\"hui14\">").Append("<img src=\"../Home/Room/Images/jiantou_3.gif\" width=\"4\" height=\"8\" />").Append("</td>").Append("<td width=\"95%\" height=\"22\" class=\"hui12\">").Append("<a href='" + row["Content"].ToString() + "' target='_blank'>").Append(_String.Cut(input, 20)).Append("</a></td></tr>");
            }
        }
        builder.Append("</table>");
        return builder.ToString();
    }

    private void BindSchemeUpload(int LotteryID)
    {
        string key = "Home_Room_Buy_BindSchemeUpload_" + LotteryID.ToString();
        this.HidSchemeUpload.Value = Shove._Web.Cache.GetCacheAsString(key, "");
        if (this.HidSchemeUpload.Value == "")
        {
            DataTable table = new Tables.T_SchemeUpload().Open("SchemeContent", "LotteryID=" + LotteryID.ToString(), "");
            if ((table != null) && (table.Rows.Count != 0))
            {
                IEnumerator enumerator = table.Rows.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    this.HidSchemeUpload.Value = table.Rows[0]["SchemeContent"].ToString();
                }

                Shove._Web.Cache.SetCache(key, this.HidSchemeUpload.Value, 0x1770);
            }
        }
    }

    private string BindWinList(string s, DataTable dt)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<tr>").Append("<td width='8%' height='25' bgcolor='#E8E8E8'>").Append("</td>").Append("<td width='31%' bgcolor='#E8E8E8'>").Append("用户名").Append("</td>").Append("<td width='30%' bgcolor='#E8E8E8'>").Append(s).Append("</td>").Append("<td width='13%' bgcolor='#E8E8E8'>").Append("跟单").Append("</td>").Append("</tr>");
        int num = 0;
        foreach (DataRow row in dt.Rows)
        {
            num++;
            string str = row["InitiateName"].ToString();
            str = (str.Length > 5) ? (str.Substring(0, 4) + "*") : str;
            builder.Append("<tr><td height='25'><img src='../Home/Room/Images/num_").Append(num.ToString()).Append(".gif'/></td><td class='black12' title='" + row["InitiateName"].ToString() + "'>").Append(string.Concat(new object[] { "<a href='../Web/Score.aspx?id=", row["InitiateUserID"].ToString(), "&LotteryID=", this.LotteryID, "'target='_blank'>" })).Append(str).Append("</a>").Append("</td><td class='black12'>").Append(_Convert.StrToDouble(row["Win"].ToString(), 0.0).ToString("N0")).Append("</td><td class='red12_2'><a href='javascript:;' onclick=\"if(CreateLogin()){followScheme(" + this.LotteryID + ");$Id('iframeFollowScheme').src='").Append("FollowFriendSchemeAdd.aspx?LotteryID=").Append(this.LotteryID.ToString()).Append("&FollowUserID=").Append(row["InitiateUserID"].ToString()).Append("&FollowUserName=").Append(HttpUtility.UrlEncode(row["InitiateName"].ToString())).Append("'}\">定制</a></td></tr>");
        }
        return builder.ToString();
    }

    private void BindWinNumber(int LotteryID)
    {
        string key = "Home_Room_Buy_BindWinNumber" + LotteryID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = MSSQL.Select("select  a.WinDescription ,b.Name from T_Schemes as a INNER JOIN T_Isuses as b on a.IsuseID =b.ID where IsuseID = (SELECT TOP 1 ID FROM dbo.T_Isuses WHERE LotteryID=" + LotteryID.ToString() + " AND GETDATE()>EndTime and IsOpened = 1 AND ISNULL(WinLotteryNumber, '')<>'' ORDER BY EndTime DESC) and ISNULL(WinDescription,'')<>'' and WinMoney > 0", new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                new Log("BindWinNumber方法出错");
                return;
            }
            if (cacheAsDataTable.Rows.Count > 0)
            {
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
            }
        }
        StringBuilder builder = new StringBuilder();
        if (cacheAsDataTable.Rows.Count == 0)
        {
            builder.Append("<tr>").Append("<td align=\"center\" class=\"blue12\" width=\"218\">").Append("暂无数据").Append("</td>").Append("</tr>");
        }
        else
        {
            builder.AppendLine("<div id='divwen' style='overflow: hidden;height:22px;'>");
            foreach (DataRow row in this.GetWinNumberLotteryID(LotteryID).Rows)
            {
                int num = 0;
                DataRow[] rowArray = cacheAsDataTable.Select("WinDescription like '%" + row["Name"].ToString() + "%'");
                foreach (DataRow row2 in rowArray)
                {
                    foreach (string str2 in row2["WinDescription"].ToString().Trim().Replace("，", ",").Split(new char[] { ',' }))
                    {
                        if (str2.Contains(row["Name"].ToString()))
                        {
                            num += _Convert.StrToInt(Regex.Replace(str2.Trim(), @"[^\d.\d]", ""), 0);
                        }
                    }
                }
                if (num > 0)
                {
                    builder.AppendLine("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  style='padding-left:5px;margin-top:1px;'>").Append("<tr>").AppendLine("<td width=\"1%\" height=\"22\" class=\"hui14\">&#9642;</td>").Append("<td align=\"center\" class=\"hui12\" height=\"22\" width=\"58%\">").Append(cacheAsDataTable.Rows[0]["Name"].ToString()).Append("&nbsp期中出").Append("</td>").Append("<td align=\"center\" class=\"blue12\" width=\"28%\">").Append(row["Name"].ToString()).Append("</td>").Append("<td width=\"10%\">").Append("<font color=\"red\">").Append(num.ToString()).Append("</font>").Append("</td>").Append("<td width=\"5%\" class=\"hui12\" >").Append("注&nbsp").Append("</td>").Append("</tr>").Append("</table>");
                }
            }
        }
        builder.Append("</div>");
        this.divNumber.InnerHtml = builder.ToString();
    }

    protected void btn_OK_Click(object sender, EventArgs e)
    {
        if (!PF.IsSystemRegister())
        {
            PF.GoError(4, "请联系网站管理员输入软件序列号", base.GetType().BaseType.FullName);
        }
        else
        {
            this.Buy(base._User);
        }
    }

    private void Buy(Users _User)
    {
        string request = Shove._Web.Utility.GetRequest("HidIsuseID");
        string str2 = Shove._Web.Utility.GetRequest("HidIsuseEndTime");
        string s = Shove._Web.Utility.GetRequest("tbPlayTypeID");
        string str4 = Shove._Web.Utility.GetRequest("Chase");
        Shove._Web.Utility.GetRequest("CoBuy");
        string str5 = Shove._Web.Utility.GetRequest("tb_Share");
        string str6 = Shove._Web.Utility.GetRequest("tb_BuyShare");
        Shove._Web.Utility.GetRequest("tb_AssureShare");
        string str7 = Shove._Web.Utility.GetRequest("tb_OpenUserList");
        string str8 = Shove._Web.Utility.GetRequest("tb_Title");
        string str9 = Shove._Web.Utility.GetRequest("tb_Description");
        string str10 = Shove._Web.Utility.GetRequest("tbAutoStopAtWinMoney");
        string str11 = Shove._Web.Utility.GetRequest("SecrecyLevel");
        string str12 = Shove._Web.Utility.FilteSqlInfusion(base.Request["tb_LotteryNumber"]);
        string str13 = Shove._Web.Utility.GetRequest("tb_hide_SumMoney");
        string str14 = Shove._Web.Utility.GetRequest("tb_hide_AssureMoney");
        string str15 = Shove._Web.Utility.GetRequest("tb_hide_SumNum");
        Shove._Web.Utility.GetRequest("HidIsuseCount");
        string str16 = Shove._Web.Utility.GetRequest("HidLotteryID");
        Shove._Web.Utility.GetRequest("HidIsAlipay");
        string str17 = Shove._Web.Utility.GetRequest("tb_Multiple");
        Shove._Web.Utility.GetRequest("HidIsuseName");
        Shove._Web.Utility.GetRequest("tbPlayTypeName");
        string str18 = Shove._Web.Utility.GetRequest("tb_hide_ChaseBuyedMoney");
        string str19 = Shove._Web.Utility.GetRequest("tb_SchemeBonusScale");
        string str20 = Shove._Web.Utility.GetRequest("tb_SchemeBonusScalec");
        int num = 2;
        if ((s == "3903") || (s == "3904"))
        {
            num = 3;
        }
        else
        {
            num = 2;
        }
        if (str17 == "")
        {
            str17 = "1";
        }
        double money = 0.0;
        int share = 0;
        int buyShare = 0;
        double assureMoney = 0.0;
        int multiple = 0;
        int num7 = 0;
        short num8 = 0;
        int playType = 0;
        int lotteryID = 0;
        long isuseID = 0L;
        double stopWhenWinMoney = 0.0;
        double schemeBonusScale = 0.0;
        double schemeBonusScalec = 0.0;
        try
        {
            money = double.Parse(str13);
            share = int.Parse(str5);
            buyShare = int.Parse(str6);
            assureMoney = double.Parse(str14);
            multiple = int.Parse(str17);
            num7 = int.Parse(str15);
            num8 = short.Parse(str11);
            playType = int.Parse(s);
            lotteryID = int.Parse(str16);
            isuseID = long.Parse(request);
            stopWhenWinMoney = double.Parse(str10);
            schemeBonusScale = double.Parse(str19);
            schemeBonusScalec = double.Parse(str20);
        }
        catch
        {
            JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
            return;
        }
        if ((money > 0.0) && (num7 >= 1))
        {
            if (assureMoney < 0.0)
            {
                JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
            }
            else if (share < 1)
            {
                JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
            }
            else
            {
                if ((buyShare == share) && (assureMoney == 0.0))
                {
                    share = 1;
                    buyShare = 1;
                }
                if ((money / ((double)share)) < 1.0)
                {
                    JavaScript.Alert(this.Page, "每份金额最低不能少于 1 元。");
                }
                else
                {
                    double num15 = (buyShare * (money / ((double)share))) + assureMoney;
                    if (str4 != "")
                    {
                        num15 = double.Parse(str18);
                    }
                    if (num15 > _User.Balance)
                    {
                        this.SaveDataForAliBuy();
                    }
                    else if (num15 > 10000000.0)
                    {
                        JavaScript.Alert(this.Page, "投注金额不能大于" + 0x989680.ToString() + "，谢谢。");
                    }
                    else if (multiple > 0x3e7)
                    {
                        JavaScript.Alert(this.Page, "投注倍数不能大于 999 倍，谢谢。");
                    }
                    else if ((schemeBonusScale < 0.0) && (schemeBonusScale > 10.0))
                    {
                        JavaScript.Alert(this.Page, "佣金比例只能在0~10之间");
                    }
                    else if ((schemeBonusScale.ToString().IndexOf("-") > -1) || (schemeBonusScale.ToString().IndexOf(".") > -1))
                    {
                        JavaScript.Alert(this.Page, "佣金比例输入有误");
                    }
                    else if ((schemeBonusScalec < 0.0) && (schemeBonusScalec > 10.0))
                    {
                        JavaScript.Alert(this.Page, "佣金比例只能在0~10之间");
                    }
                    else if ((schemeBonusScalec.ToString().IndexOf("-") > -1) || (schemeBonusScalec.ToString().IndexOf(".") > -1))
                    {
                        JavaScript.Alert(this.Page, "佣金比例输入有误");
                    }
                    else
                    {
                        schemeBonusScale /= 100.0;
                        schemeBonusScalec /= 100.0;
                        string number = str12;
                        if (number[number.Length - 1] == '\n')
                        {
                            number = number.Substring(0, number.Length - 1);
                        }
                        Lottery lottery = new Lottery();
                        string[] strArray = this.SplitLotteryNumber(number);
                        if ((strArray == null) || (strArray.Length < 1))
                        {
                            JavaScript.Alert(this.Page, "选号发生异常，请重新选择号码投注，谢谢。(-694)");
                        }
                        else
                        {
                            int num17 = 0;
                            foreach (string str22 in strArray)
                            {
                                string str23 = lottery[lotteryID].AnalyseScheme(str22, playType);
                                if (!string.IsNullOrEmpty(str23))
                                {
                                    string[] strArray3 = str23.Split(new char[] { '|' });
                                    if ((strArray3 != null) && (strArray3.Length >= 1))
                                    {
                                        num17 += _Convert.StrToInt(strArray3[strArray3.Length - 1], 0);
                                    }
                                }
                            }
                            if (num17 != num7)
                            {
                                JavaScript.Alert(this.Page, "选号发生异常，请重新选择号码投注，谢谢。");
                            }
                            else
                            {
                                StringBuilder builder = new StringBuilder();
                                int num19 = 0;
                                string detailXML = "";
                                string returnDescription = "";
                                if (str4 == "1")
                                {
                                    foreach (string str26 in base.Request.Form.AllKeys)
                                    {
                                        if (str26.IndexOf("check") > -1)
                                        {
                                            int num20 = _Convert.StrToInt(str26.Replace("check", ""), -1);
                                            if (num20 > 0)
                                            {
                                                num19++;
                                                int num21 = (_Convert.StrToInt(base.Request.Form["tb_hide_SumNum"], -1) * num) * _Convert.StrToInt(base.Request.Form["times" + num20.ToString()], -1);
                                                builder.Append(base.Request.Form[str26]).Append(",").Append(base.Request.Form["times" + num20.ToString()]).Append(",").Append(num21.ToString()).Append(";");
                                            }
                                        }
                                    }
                                    if (builder.Length > 0)
                                    {
                                        builder.Remove(builder.Length - 1, 1);
                                    }
                                    if (number[number.Length - 1] == '\n')
                                    {
                                        number = number.Substring(0, number.Length - 1);
                                    }
                                    try
                                    {
                                        money = double.Parse(str13);
                                    }
                                    catch
                                    {
                                        JavaScript.Alert(this.Page, "输入有错误，请仔细检查。(-1325)");
                                        return;
                                    }
                                    if (money < 2.0)
                                    {
                                        JavaScript.Alert(this.Page, "输入有错误，请仔细检查。(-1332)");
                                    }
                                    else
                                    {
                                        string[] strArray5 = builder.ToString().Split(new char[] { ';' });
                                        int length = strArray5.Length;
                                        string[] str = new string[length * 6];
                                        DateTime time2 = DateTime.Parse(Functions.F_GetIsuseSystemEndTime(long.Parse(strArray5[0].Split(new char[] { ',' })[0]), playType).ToString());
                                        if (DateTime.Now >= time2)
                                        {
                                            JavaScript.Alert(this.Page, "您选择的追号期号中包含已截止的期，请重新选择。");
                                        }
                                        else
                                        {
                                            for (int i = 0; i < length; i++)
                                            {
                                                str[i * 6] = strArray5[i].Split(new char[] { ',' })[0];
                                                str[(i * 6) + 1] = playType.ToString();
                                                str[(i * 6) + 2] = number;
                                                str[(i * 6) + 3] = strArray5[i].Split(new char[] { ',' })[1];
                                                str[(i * 6) + 4] = strArray5[i].Split(new char[] { ',' })[2];
                                                str[(i * 6) + 5] = num8.ToString();
                                                if ((_Convert.StrToDouble(str[(i * 6) + 3], 0.0) * money) != _Convert.StrToDouble(str[(i * 6) + 4], 1.0))
                                                {
                                                    JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                                                    return;
                                                }
                                                if (_Convert.StrToDouble(str[(i * 6) + 3], 0.0) < multiple)
                                                {
                                                    JavaScript.Alert(this.Page, "追号倍数有错误，请仔细检查！");
                                                    return;
                                                }
                                                if (((double.Parse(str[(i * 6) + 3]) * num7) * num) != double.Parse(str[(i * 6) + 4]))
                                                {
                                                    JavaScript.Alert(this.Page, "追号金额有错误，请仔细检查！可能原因：浏览器不兼容，建议使用IE 7.0");
                                                    return;
                                                }
                                            }
                                            detailXML = PF.BuildIsuseAdditionasXmlForChase(str);
                                            if (detailXML == "")
                                            {
                                                JavaScript.Alert(this.Page, "追号发生错误。");
                                            }
                                            else if (_User.InitiateChaseTask(str8.Trim(), str9.Trim(), lotteryID, stopWhenWinMoney, detailXML, number, schemeBonusScalec, ref returnDescription) < 0)
                                            {
                                                PF.GoError(1, returnDescription, base.GetType().FullName + "(-754)");
                                            }
                                            else
                                            {
                                                Shove._Web.Cache.ClearCache("Home_Room_CoBuy_BindDataForType" + isuseID.ToString());
                                                Shove._Web.Cache.ClearCache("Home_Room_SchemeAll_BindData" + isuseID.ToString());
                                                Shove._Web.Cache.ClearCache(base._Site.ID.ToString() + "AccountFreezeDetail_" + _User.ID.ToString());
                                                base.Response.Redirect("UserBuySuccess.aspx?LotteryID=" + lotteryID.ToString() + "&Type=2&Money=" + num15.ToString());
                                            }
                                        }
                                    }
                                }
                                else if (DateTime.Now >= _Convert.StrToDateTime(str2.Replace("/", "-"), DateTime.Now.AddDays(-1.0).ToString()))
                                {
                                    JavaScript.Alert(this.Page, "本期投注已截止，谢谢。");
                                }
                                else if (((num * num7) * multiple) != money)
                                {
                                    JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                                }
                                else
                                {
                                    long num25 = _User.InitiateScheme(isuseID, playType, (str8.Trim() == "") ? "(无标题)" : str8.Trim(), str9.Trim(), number, "", multiple, money, assureMoney, share, buyShare, str7.Trim(), short.Parse(num8.ToString()), schemeBonusScale, ref returnDescription);
                                    if (num25 < 0L)
                                    {
                                        PF.GoError(1, returnDescription, base.GetType().FullName + "(-755)");
                                    }
                                    else
                                    {
                                        Shove._Web.Cache.ClearCache("Home_Room_CoBuy_BindDataForType" + isuseID.ToString());
                                        Shove._Web.Cache.ClearCache("Home_Room_SchemeAll_BindData" + isuseID.ToString());
                                        if ((money > 50.0) && (share > 1))
                                        {
                                            Shove._Web.Cache.ClearCache("Home_Room_JoinAllBuy_BindData");
                                        }
                                        base.Response.Redirect("UserBuySuccess.aspx?LotteryID=" + lotteryID.ToString() + "&&Money=" + num15.ToString() + "&SchemeID=" + num25.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
        }
    }

    private string FilterRepeated(string NumberPart)
    {
        string str = "";
        for (int i = 0; i < NumberPart.Length; i++)
        {
            if ((str.IndexOf(NumberPart.Substring(i, 1)) == -1) && ("0123456789".IndexOf(NumberPart.Substring(i, 1)) >= 0))
            {
                str = str + NumberPart.Substring(i, 1);
            }
        }
        return str;
    }

    private string FormatLuckLotteryNumber(int LotteryID, string LotteryNumber)
    {
        if (string.IsNullOrEmpty(LotteryNumber))
        {
            return "";
        }
        string str = null;
        string str2 = null;
        if ((((LotteryID == 5) || (LotteryID == 0x3b)) || ((LotteryID == 13) || (LotteryID == 0x27))) || ((LotteryID == 9) || (LotteryID == 0x41)))
        {
            LotteryNumber = LotteryNumber.Replace(" + ", " ");
        }
        if (((LotteryID == 0x3a) || (LotteryID == 6)) || (((LotteryID == 3) || (LotteryID == 0x3f)) || (LotteryID == 0x40)))
        {
            str = LotteryNumber.Split(new char[] { '+' })[0];
            try
            {
                str2 = LotteryNumber.Split(new char[] { '+' })[1];
            }
            catch
            {
                str2 = "";
            }
            LotteryNumber = "";
            for (int i = 0; i < str.Length; i++)
            {
                LotteryNumber = LotteryNumber + str.Substring(i, 1) + " ";
            }
            LotteryNumber = LotteryNumber + str2;
            LotteryNumber = LotteryNumber.Trim();
        }
        return LotteryNumber;
    }

    private string FormatWinNumber(int LotteryID, string winNumber)
    {
        StringBuilder builder = new StringBuilder();
        switch (LotteryID)
        {
            case 0x3a:
                if (winNumber.IndexOf("+") > 0)
                {
                    for (int i = 0; i < winNumber.Length; i++)
                    {
                        if (i < (winNumber.Length - 2))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(i, 1));
                        }
                        else if (i == (winNumber.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(winNumber.Substring(i, 1));
                        }
                    }
                }
                break;

            case 0x3b:
                if (winNumber.Length > 0)
                {
                    string[] strArray3 = winNumber.Split(new char[] { ' ' });
                    for (int j = 0; (j < strArray3.Length) && (j < 5); j++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray3[j]);
                    }
                }
                break;

            case 0x3f:
                if (winNumber.Length > 0)
                {
                    for (int k = 0; k < winNumber.Length; k++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(k, 1));
                    }
                }
                break;

            case 0x40:
                if (winNumber.Length > 0)
                {
                    for (int m = 0; m < winNumber.Length; m++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(m, 1));
                    }
                }
                break;

            case 0x41:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray6 = winNumber.Split(new char[] { ' ' });
                    for (int n = 0; n < strArray6.Length; n++)
                    {
                        if (n < (strArray6.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray6[n]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(strArray6[n]);
                        }
                    }
                }
                break;

            case 0x27:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray2 = winNumber.Split(new char[] { ' ' });
                    for (int num5 = 0; num5 < strArray2.Length; num5++)
                    {
                        if (num5 < (strArray2.Length - 2))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray2[num5]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(strArray2[num5]);
                        }
                    }
                }
                break;

            case 3:
                if (winNumber.Length > 0)
                {
                    for (int num2 = 0; num2 < winNumber.Length; num2++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(num2, 1));
                    }
                }
                break;

            case 5:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray = winNumber.Split(new char[] { ' ' });
                    for (int num3 = 0; num3 < strArray.Length; num3++)
                    {
                        if (num3 < (strArray.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray[num3]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(strArray[num3]);
                        }
                    }
                }
                break;

            case 6:
                if (winNumber.Length > 0)
                {
                    for (int num4 = 0; num4 < winNumber.Length; num4++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(num4, 1));
                    }
                }
                break;

            case 9:
                if (winNumber.Length > 0)
                {
                    string[] strArray5 = winNumber.Split(new char[] { ' ' });
                    for (int num9 = 0; num9 < strArray5.Length; num9++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray5[num9]);
                    }
                }
                break;

            case 13:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray4 = winNumber.Split(new char[] { ' ' });
                    for (int num8 = 0; num8 < strArray4.Length; num8++)
                    {
                        if (num8 < (strArray4.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray4[num8]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(strArray4[num8]);
                        }
                    }
                }
                break;
        }
        return builder.ToString();
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string GenerateLuckLotteryNumber(int LotteryID, string Type, string Name)
    {
        string key = "Home_Room_Buy_GenerateLuckLotteryNumber" + LotteryID.ToString();
        Type = Shove._Web.Utility.FilteSqlInfusion(Type);
        Name = Shove._Web.Utility.FilteSqlInfusion(Name);
        if (Type == "3")
        {
            try
            {
                DateTime time = Convert.ToDateTime(Name);
                Name = time.ToString("yyyy-MM-dd");
                if (time > DateTime.Now)
                {
                    return "出生日期不能超过当前日期！";
                }
            }
            catch
            {
                return "日期格式不正确！";
            }
        }
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            cacheAsDataTable = new Tables.T_LuckNumber().Open("", "datediff(d,getdate(),DateTime)=0 and LotteryID=" + LotteryID.ToString(), "");
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        string lotteryNumber = "";
        DataRow[] rowArray = cacheAsDataTable.Select("Type=" + Type + " and Name='" + Name + "'");
        if ((rowArray != null) && (rowArray.Length > 0))
        {
            lotteryNumber = rowArray[0]["LotteryNumber"].ToString();
        }
        else
        {
            if (LotteryID == 5)
            {
                lotteryNumber = new Lottery()[LotteryID].BuildNumber(6, 1, 1);
            }
            else if (LotteryID == 0x27)
            {
                lotteryNumber = new Lottery()[LotteryID].BuildNumber(5, 2, 1);
            }
            else
            {
                lotteryNumber = new Lottery()[LotteryID].BuildNumber(1);
            }
            Tables.T_LuckNumber number = new Tables.T_LuckNumber
            {
                LotteryID = { Value = LotteryID },
                LotteryNumber = { Value = lotteryNumber },
                Name = { Value = Name },
                Type = { Value = Type }
            };
            number.Insert();
            number.Delete("datediff(d,DateTime,getdate())>0");
            Shove._Web.Cache.ClearCache(key);
        }
        return (lotteryNumber + "|" + this.FormatLuckLotteryNumber(LotteryID, lotteryNumber));
    }

    private void Get3DBaoDianMiss()
    {
        string key = "Home_Room_Buy_Get3DBaoDianMiss";
        this.lbMiss.Text = Shove._Web.Cache.GetCacheAsString(key, "");
        this.lbMiss.Text = "";
        if (this.lbMiss.Text == "")
        {
            DataTable table = new Tables.T_Isuses().Open("EndTime,WinLotteryNumber", "LotteryID = 6 and GETDATE()>EndTime and ISNULL(WinLotteryNumber,'')<>'' and IsOpened=1", "EndTime asc");
            if (table == null)
            {
                new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(Get3DBaoDianMiss)");
            }
            else
            {
                int[] numArray = new int[0x1c];
                int[] numArray2 = new int[] { 
                    0x3e8, 0x14d, 0xa7, 100, 0x43, 0x30, 0x24, 0x1c, 0x16, 0x12, 0x10, 14, 14, 13, 13, 14, 
                    14, 0x10, 0x12, 0x16, 0x1c, 0x24, 0x30, 0x43, 100, 0xa7, 0x14d, 0x3e8
                 };
                foreach (DataRow row in table.Rows)
                {
                    string str2 = row["WinLotteryNumber"].ToString();
                    int num = 0;
                    if (str2.Length == 3)
                    {
                        for (int k = 0; k < str2.Length; k++)
                        {
                            num += _Convert.StrToInt(str2.Substring(k, 1), 0);
                        }
                        for (int m = 0; m < numArray.Length; m++)
                        {
                            if (m == num)
                            {
                                numArray[m] = 0;
                            }
                            else
                            {
                                numArray[m]++;
                            }
                        }
                    }
                }
                double num4 = 0.0;
                double num5 = 0.0;
                for (int i = 0; i < 0x1c; i++)
                {
                    num5 = _Convert.StrToDouble(numArray[i].ToString(), 0.0);
                    if ((num5 / ((double)numArray2[i])) >= num4)
                    {
                        num4 = num5 / ((double)numArray2[i]);
                    }
                }
                StringBuilder builder = new StringBuilder();
                int num7 = numArray.Length / 14;
                for (int j = 0; j < num7; j++)
                {
                    builder.Append(" <table border=\"0\" cellpadding=\"0\" cellspacing=\"4\">").Append("<tr>").Append("<td class='blue' width='80px' align='center'>").Append("本期遗漏").Append("</td>");
                    for (int n = j * 14; n < ((j + 1) * 14); n++)
                    {
                        if ((_Convert.StrToDouble(numArray[n].ToString(), 0.0) / ((double)numArray2[n])) >= num4)
                        {
                            builder.Append("<td class='red12'>");
                        }
                        else
                        {
                            builder.Append("<td class='hui12'>");
                        }
                        builder.Append(numArray[n].ToString()).Append("</td>");
                    }
                    builder.Append("</tr>").Append("<tr>").Append("<td class='blue' width='80px' align='center'>").Append("理论遗漏").Append("</td>");
                    for (int num10 = j * 14; num10 < ((j + 1) * 14); num10++)
                    {
                        if ((_Convert.StrToDouble(numArray[num10].ToString(), 0.0) / ((double)numArray2[num10])) >= num4)
                        {
                            builder.Append("<td class='red12'>");
                        }
                        else
                        {
                            builder.Append("<td class='hui12'>");
                        }
                        builder.Append(numArray2[num10].ToString()).Append("</td>");
                    }
                    builder.Append("</tr>").Append("</table>-");
                }
                this.lbMiss.Text = builder.ToString();
                Shove._Web.Cache.SetCache(key, this.lbMiss.Text, 600);
            }
        }
    }

    private string Get3DMiss()
    {
        string key = "Home_Room_Buy_Get3DMiss";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        string str2 = "";
        if (cacheAsDataTable == null)
        {
            int returnValue = 0;
            string returnDescptrion = "";
            DataSet ds = new DataSet();
            if (Procedures.P_Analysis_3D_Miss(ref ds, ref returnValue, ref returnDescptrion) < 0)
            {
                new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(P_Analysis_3D_Miss)");
                return "";
            }
            if (ds.Tables.Count < 1)
            {
                new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(P_Analysis_3D_Miss)");
                return "";
            }
            cacheAsDataTable = ds.Tables[0];
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
        }
        for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
        {
            string str4 = str2;
            string str5 = str4 + cacheAsDataTable.Rows[i]["Number_0"].ToString() + "," + cacheAsDataTable.Rows[i]["Number_1"].ToString() + "," + cacheAsDataTable.Rows[i]["Number_2"].ToString() + "," + cacheAsDataTable.Rows[i]["Number_3"].ToString() + ",";
            str2 = ((str5 + cacheAsDataTable.Rows[i]["Number_4"].ToString() + "," + cacheAsDataTable.Rows[i]["Number_5"].ToString() + "," + cacheAsDataTable.Rows[i]["Number_6"].ToString() + "," + cacheAsDataTable.Rows[i]["Number_7"].ToString() + ",") + cacheAsDataTable.Rows[i]["Number_8"].ToString() + "," + cacheAsDataTable.Rows[i]["Number_9"].ToString()) + ";";
        }
        if (str2.EndsWith(";"))
        {
            str2 = str2.Substring(0, str2.Length - 1);
        }
        return str2;
    }

    private string Get3DZu3MissCount()
    {
        string key = "Home_Room_Buy_Get3DZu3MissCount";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Isuses().Open("top 40 WinLotteryNumber", "LotteryID = 6 and WinLotteryNumber <> '' and IsOpened = 1", "EndTime desc");
            if (cacheAsDataTable == null)
            {
                new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(Get3DZu3MissCount)");
                return "";
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
        }
        int num = 0;
        for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
        {
            if (this.FilterRepeated(cacheAsDataTable.Rows[i]["WinLotteryNumber"].ToString()).Length == 2)
            {
                break;
            }
            num++;
        }
        return num.ToString();
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetFCExpertList(int lotteryID)
    {
        DataTable fCExpertListCache = this.GetFCExpertListCache(lotteryID);
        StringBuilder builder = new StringBuilder();
        if ((fCExpertListCache != null) && (fCExpertListCache.Rows.Count > 0))
        {
            int num = 1;
            foreach (DataRow row in fCExpertListCache.Rows)
            {
                string str = row["UserName"].ToString();
                str = (str.Length > 6) ? (str.Substring(0, 5) + "*") : str;
                builder.AppendLine("<tr align=\"center\">").AppendLine("<td  height=\"22\"  bgcolor=\"#FFFFFF\" class=\"black12\" title='" + row["UserName"].ToString() + "'>").Append(@"<a href='..\Web\Score.aspx?id=").Append(row["UserID"].ToString()).Append("&LotteryID=").Append(lotteryID + "' target='_blank'>").AppendLine(str).Append("</a>").AppendLine("</td>").AppendLine("<td  align=\"center\" bgcolor=\"#FFFFFF\" class=\"black12\">").AppendLine(row["LotteryName"].ToString()).Append("</td>").Append("<td bgcolor=\"#FFFFFF\" class='red12_2'><a href='javascript:;' onclick=\"if(CreateLogin()){followScheme(" + this.LotteryID + ");$Id('iframeFollowScheme').src='").Append("FollowFriendSchemeAdd.aspx?LotteryID=").Append(lotteryID).Append("&FollowUserID=").Append(row["UserID"]).Append("&FollowUserName=").Append(HttpUtility.UrlEncode(row["UserName"].ToString())).Append("'}\">定制</a></td></tr>");
                if (((num % 10) == 0) && (num != fCExpertListCache.Rows.Count))
                {
                    builder.Append("|");
                }
                num++;
            }
        }
        else
        {
            builder.AppendLine("<tr>").AppendLine("<td colspan=\"3\" height=\"22\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">").AppendLine("<span style=\"color:red;\">暂无数据</span>").AppendLine("</td>");
        }
        return builder.ToString();
    }

    public DataTable GetFCExpertListCache(int lID)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("FCExpert" + lID);
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            cacheAsDataTable = new Views.V_Experts().Open("UserName,UserID,LotteryName,LotteryID", "[ON]=1 and [isCommend]=1 and LotteryID =" + lID, "");
            if (cacheAsDataTable == null)
            {
                return cacheAsDataTable;
            }
            cacheAsDataTable.Columns.Add("ID", typeof(int));
            int num = 1;
            foreach (DataRow row in cacheAsDataTable.Rows)
            {
                row["ID"] = num;
                num++;
            }
            Shove._Web.Cache.SetCache("FCExpert" + lID, cacheAsDataTable, 60);
        }
        return cacheAsDataTable;
    }

    private void GetInforMationListAndIsShow(int LotteryID)
    {
        if (LotteryID == 5)
        {
            this.InforMation.Visible = false;
        }
        else if (LotteryID == 6)
        {
            this.InforMation.Visible = false;
        }
        else if (LotteryID == 0x27)
        {
            this.InforMationName = "超级大乐透资讯";
        }
        else if ((LotteryID == 0x3f) || (LotteryID == 0x40))
        {
            this.InforMationName = "排列3/5资讯";
        }
        else
        {
            this.InforMation.Visible = false;
        }
    }

    private string GetIsuseChase(int LotteryID)
    {
        try
        {
            DataTable isusesInfo = DataCache.GetIsusesInfo(LotteryID);
            int num = DataCache.LotteryEndAheadMinute[LotteryID];
            DataRow[] rowArray = isusesInfo.Select("('" + DateTime.Now.ToString() + "' < StartTime or ('" + DateTime.Now.ToString() + "'>StartTime and '" + DateTime.Now.AddMinutes((double)num).ToString() + "'<EndTime))", "EndTime");
            if (rowArray.Length == 0)
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            int num2 = 0;
            builder.Append("<table cellpadding='0' cellspacing='1' style='width: 100%; text-align: center; background-color: #E2EAED;'><tbody style='background-color: White;'>");
            foreach (DataRow row in rowArray)
            {
                num2++;
                builder.Append("<tr>").Append("<td style='width: 10%;'>").Append("<input id='check").Append(row["ID"].ToString()).Append("' type='checkbox' name='check").Append(row["ID"].ToString()).Append("' onclick='check(this);' value='").Append(row["ID"].ToString()).Append("'/>").Append("</td>").Append("<td style='width: 40%;'>").Append("<span>").Append(row["Name"].ToString()).Append("</span>").Append("<span>").Append((num2 == 1) ? "<font color='red'>[本期]</font>" : ((num2 == 2) ? "<font color='red'>[下期]</font>" : "")).Append("</span>").Append("</td>").Append("<td style='width: 20%;'>").Append("<input name='times").Append(row["ID"].ToString()).Append("' type='text' value='1' id='times").Append(row["ID"].ToString()).Append("' class='TextBox' onchange='onTextChange(this);' onkeypress='return InputMask_Number();' disabled='disabled' onblur='CheckMultiple2(this);' style='width: 45px;' />倍").Append("</td>").Append("<td style='width: 30%;'>").Append("<input name='money").Append(row["ID"].ToString()).Append("' type='text' value='0' id='money").Append(row["ID"].ToString()).Append("' class='TextBox' disabled='disabled' style='width: 45px;' />元").Append("</td>").Append("</tr>");
            }
            builder.Append("</tbody></table>");
            return builder.ToString();
        }
        catch (Exception exception)
        {
            new Log("TWZT").Write("AlipayTask Running Error: " + exception.Message);
            return "";
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetIsuseInfo(int LotteryID)
    {
        try
        {
            DataTable isusesInfo = DataCache.GetIsusesInfo(LotteryID);
            string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataRow[] rowArray = isusesInfo.Select("'" + str + "' > StartTime and '" + str + "' < EndTime", "EndTime desc");
            DataRow[] rowArray2 = isusesInfo.Select("EndTime < '" + str + "' and WinLotteryNumber<>''", "EndTime desc");
            if ((rowArray.Length == 0) && (rowArray2.Length == 0))
            {
                return "";
            }
            if (rowArray.Length == 0)
            {
                rowArray = isusesInfo.Select("EndTime < '" + str + "'", "EndTime desc");
            }
            if (rowArray2.Length == 0)
            {
                rowArray2 = rowArray;
            }
            int num = _Convert.StrToInt(rowArray[0]["ID"].ToString(), -1);
            string str3 = rowArray[0]["Name"].ToString();
            int num2 = DataCache.LotteryEndAheadMinute[LotteryID];
            string str4 = Convert.ToDateTime(rowArray[0]["EndTime"]).AddMinutes((double)(num2 * -1)).ToString("yyyy/MM/dd HH:mm:ss");
            string str5 = rowArray2[0]["Name"].ToString();
            string winNumber = rowArray2[0]["WinLotteryNumber"].ToString().Trim();
            winNumber = this.FormatWinNumber(LotteryID, winNumber);
            string str7 = "";
            if (LotteryID == 6)
            {
                str7 = this.Get3DZu3MissCount();
            }
            if (LotteryID == 0x3f)
            {
                str7 = "<span id='SZPL3Zu3MissCount' class='num_1'></span>";
            }
            StringBuilder builder = new StringBuilder();
            builder.Append(num.ToString()).Append(",").Append(str3).Append(",").Append(str4).Append("|<table  cellspacing='5' cellpadding='0' style='text-align: center; font-weight: bold;'><tr><td align='left'  height='25' class='hui12'>").Append(str5).Append("&nbsp;期开奖:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;").Append(winNumber).Append("</td>");
            if ((LotteryID == 6) || (LotteryID == 0x3f))
            {
                builder.Append("<td>").Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;温馨提示：组选三连续").Append("<span class='num_1'>" + str7 + "</span>").Append("期未开出").Append("</td></tr>");
            }
            if (LotteryID == 6)
            {
                string testNumber = this.GetTestNumber(num.ToString());
                if (testNumber != "")
                {
                    builder.Append(string.Concat(new object[] { "<tr><td colspan='", this.GetWinNumberCellNumber(6, rowArray2[0]["WinLotteryNumber"].ToString().Trim()), "' align='left'><span style='color: #ff0000;'>", testNumber, "</span></td></tr>" })).Append("");
                }
            }
            if ((LotteryID == 5) || (LotteryID == 0x27))
            {
                string totalMoney = this.GetTotalMoney(num.ToString());
                if (totalMoney != "")
                {
                    double d = _Convert.StrToDouble(totalMoney, 0.0) / 5000000.0;
                    double num4 = Math.Floor(d);
                    builder.Append(string.Concat(new object[] { "<tr style='font-weight:normal;'><td colspan='", this.GetWinNumberCellNumber(LotteryID, rowArray2[0]["WinLotteryNumber"].ToString().Trim()), "' align='left'><span class=\"hui12\">奖池累积奖金已达</span><span class='red12' style='font-weight: bold;'>", totalMoney, "</span><span class=\"hui12\">元</span>" }));
                    if (num4 > 0.0)
                    {
                        builder.Append("<span class=\"hui12\">，可开出</span><span class='red12' style='font-weight: bold;'>" + Math.Floor(d) + "</span><span class=\"hui12\">个足额500万</span>");
                    }
                    builder.Append("</td></tr>");
                }
            }
            builder.Append("</table>").Append("|").Append(this.GetIsuseChase(LotteryID));
            if (LotteryID == 6)
            {
                builder.Append("|").Append(this.Get3DMiss());
            }
            return builder.ToString();
        }
        catch (Exception exception)
        {
            new Log("TWZT").Write(base.GetType() + exception.Message);
            return "";
        }
    }

    private void GetMiss()
    {
        if (this.LotteryID == 0x3f)
        {
            this.GetSZPL3Miss();
        }
        if (this.LotteryID == 6)
        {
            this.Get3DBaoDianMiss();
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetNewsInfo(int LotteryID)
    {
        return DataCache.GetLotteryNews(LotteryID);
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string GetSchemeBonusScalec(int lotteryId)
    {
        DataTable table = new Tables.T_Sites().Open("Opt_InitiateSchemeBonusScale,Opt_InitiateSchemeLimitLowerScaleMoney,Opt_InitiateSchemeLimitLowerScale,Opt_InitiateSchemeLimitUpperScaleMoney,Opt_InitiateSchemeLimitUpperScale", "", "");
        string str = (_Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeBonusScale"].ToString(), 0.0) * 100.0).ToString();
        string str2 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitLowerScaleMoney"].ToString(), 100.0).ToString();
        string str3 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitLowerScale"].ToString(), 0.2).ToString();
        string str4 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitUpperScaleMoney"].ToString(), 10000.0).ToString();
        string str5 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitUpperScale"].ToString(), 0.05).ToString();
        string str6 = DataCache.Lotteries[lotteryId];
        return (str + "|" + str2 + "|" + str3 + "|" + str4 + "|" + str5 + "|" + lotteryId.ToString() + "|" + str6);
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetSysTime()
    {
        return _Convert.StrToDateTime(new Views.V_GetDate().Open("", "", "").Rows[0]["Now"].ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")).ToString("yyyy/MM/dd HH:mm:ss");
    }

    private void GetSZPL3Miss()
    {
        string key = "Home_Room_Buy_GetSZPL3Miss";
        this.lbMiss.Text = Shove._Web.Cache.GetCacheAsString(key, "");
        if (this.lbMiss.Text == "")
        {
            DataTable table = new Tables.T_Isuses().Open("top 100 EndTime,WinLotteryNumber", "LotteryID = 63 and GETDATE()>EndTime and ISNULL(WinLotteryNumber,'')<>'' and IsOpened=1", "EndTime desc");
            if (table == null)
            {
                new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(GetSZPL3Miss)");
            }
            else
            {
                int[,] numArray = new int[3, 10];
                int num = 0;
                foreach (DataRow row in table.Select("", "EndTime asc"))
                {
                    string str2 = row["WinLotteryNumber"].ToString();
                    if (str2.Length == 3)
                    {
                        for (int i = 0; i < str2.Length; i++)
                        {
                            int num4 = _Convert.StrToInt(str2.Substring(i, 1), 0);
                            for (int j = 0; j < 10; j++)
                            {
                                if (j == num4)
                                {
                                    numArray[i, j] = 0;
                                }
                                else
                                {
                                    numArray[i, j]++;
                                }
                            }
                        }
                    }
                }
                foreach (DataRow row2 in table.Select("1=1", "EndTime desc"))
                {
                    if (this.FilterRepeated(row2["WinLotteryNumber"].ToString()).Length == 2)
                    {
                        break;
                    }
                    num++;
                }
                this.lbMiss.Text = this.GetSZPL3Miss(numArray) + "|" + num.ToString();
                Shove._Web.Cache.SetCache(key, this.lbMiss.Text, 600);
            }
        }
    }

    private string GetSZPL3Miss(int[,] SZPL3)
    {
        StringBuilder builder = new StringBuilder();
        int[] source = new int[10];
        for (int i = 0; i < 3; i++)
        {
            builder.Append("<table cellpadding=\"0\" cellspacing=\"4\" width='338px'>").Append("<tr>").Append("<td  class=\"black35\" width=\"40px\" align=\"left\">").Append("遗漏").Append("</td>");
            for (int j = 0; j < 10; j++)
            {
                source[j] = SZPL3[i, j];
            }
            for (int k = 0; k < 10; k++)
            {
                if (SZPL3[i, k] == source.Max())
                {
                    builder.Append("<td class='black30'>").Append("<font color='red'>").Append(SZPL3[i, k].ToString()).Append("</font></td>");
                }
                else
                {
                    builder.Append("<td class='black30'>").Append(SZPL3[i, k].ToString()).Append("</td>");
                }
            }
            builder.Append("</tr>").Append("</table>").Append("-");
        }
        return builder.ToString();
    }

    private string GetTestNumber(string IsuseID)
    {
        string str = "";
        string key = "Home_Room_Buy_GetTestNumber_" + IsuseID;
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_TestNumber().Open("", "IsuseID=" + IsuseID, "");
            if (cacheAsDataTable == null)
            {
                new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(GetTestNumber)");
                return "";
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 120);
        }
        if (cacheAsDataTable.Rows.Count > 0)
        {
            str = cacheAsDataTable.Rows[0]["TestNumber"].ToString();
        }
        return str;
    }

    private string GetTotalMoney(string IsuseID)
    {
        string str = "";
        string key = "Home_Room_Buy_GetTotalMoneySSQ_" + IsuseID;
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_TotalMoney().Open("", "IsuseID=" + IsuseID, "");
            if (cacheAsDataTable == null)
            {
                new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(GetTotalMoneySSQ)");
                return "";
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 120);
        }
        if (cacheAsDataTable.Rows.Count > 0)
        {
            str = cacheAsDataTable.Rows[0]["TotalMoney"].ToString();
        }
        return str;
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetWinNumber(int lotteryID)
    {
        DataTable winNumber = DataCache.GetWinNumber(lotteryID);
        StringBuilder builder = new StringBuilder();
        if ((winNumber != null) && (winNumber.Rows.Count > 0))
        {
            int num = 1;
            foreach (DataRow row in winNumber.Rows)
            {
                builder.AppendLine("<tr>").AppendLine("<td  height=\"22\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">").AppendLine(row["Name"].ToString()).AppendLine("</td>");
                if (((lotteryID != 0x27) && (lotteryID != 13)) && ((lotteryID != 0x41) && (lotteryID != 5)))
                {
                    builder.AppendLine("<td  align=\"center\" bgcolor=\"#FFFFFF\" class=\"hui12\">").AppendLine(_Convert.StrToDateTime(row["EndTime"].ToString(), DateTime.Now.ToString()).ToString("M-dd")).AppendLine("</td>");
                }
                builder.AppendLine("<td  align=\"center\" bgcolor=\"#FFFFFF\" class=\"red2\">").AppendLine(row["WinLotteryNumber"].ToString()).AppendLine("</td>").AppendLine("</tr>");
                if (((num % 10) == 0) && (num != winNumber.Rows.Count))
                {
                    builder.Append("|");
                }
                num++;
            }
        }
        return builder.ToString();
    }

    private int GetWinNumberCellNumber(int LotteryID, string winNumber)
    {
        int length = 0;
        if (LotteryID == 6)
        {
            length = winNumber.Length;
        }
        else if (((LotteryID == 5) || (LotteryID == 0x27)) && (winNumber.IndexOf(" + ") > 0))
        {
            winNumber = winNumber.Replace(" + ", " ");
            length = winNumber.Split(new char[] { ' ' }).Length;
        }
        return (length + 1);
    }

    private DataTable GetWinNumberLotteryID(int LotteryID)
    {
        string key = "Home_Room_Buy_GetWinNumberLotteryID" + LotteryID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_WinTypes().Open("Name", "LotteryID=" + LotteryID.ToString(), "ID desc");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                return null;
            }
        }
        Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x57e40);
        return cacheAsDataTable;
    }

    private string InitLuckLotteryNumber()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin-top: 10px;\">").AppendLine("<tr>").AppendLine("<td height=\"22\" align=\"center\">").AppendLine("&nbsp;</td>");
        for (int i = 0; i < NumberCount[this.LotteryID][0]; i++)
        {
            builder.AppendLine("<td align=\"center\">").AppendLine("<table width=\"22\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" background=\"../Home/Room/Images/ssq_bg_td.jpg\">").AppendLine("<tr>").AppendLine("<td height=\"22\" align=\"center\" class=\"red12\" id='tdLuckNumber" + i.ToString() + "'>").AppendLine("-").AppendLine("</td></tr></table></td>");
        }
        for (int j = 0; j < NumberCount[this.LotteryID][1]; j++)
        {
            int num3 = NumberCount[this.LotteryID][0] + j;
            builder.AppendLine("<td align=\"center\">").AppendLine("<table width=\"22\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" background=\"../Home/Room/Images/ssq_bg_td.jpg\">").AppendLine("<tr>").AppendLine("<td height=\"22\" align=\"center\" class=\"blue12\" id='tdLuckNumber" + num3.ToString() + "'>").AppendLine("-").AppendLine("</td></tr></table></td>");
        }
        builder.AppendLine("<td>&nbsp;</td>").AppendLine("</tr>").AppendLine("</table>");
        return builder.ToString();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Lottery_Buy), this.Page);
        this.LotteryID = 5;
        if (!DataCache.Lotteries.ContainsKey(this.LotteryID))
        {
            this.LotteryID = DataCache.Lotteries.First<KeyValuePair<int, string>>().Key;
        }
        this.hlAgreement.NavigateUrl = "BuyProtocol.aspx?LotteryID=" + this.LotteryID;
        this.LotteryName = DataCache.Lotteries[this.LotteryID];
        if (this.LotteryID == 0x1d)
        {
            base.Response.Redirect("Buy_SSL.aspx");
        }
        else if (this.LotteryID == 0x3e)
        {
            base.Response.Redirect("Buy_SYYDJ.aspx");
        }
        else if (((this.LotteryID == 1) || (this.LotteryID == 2)) || (this.LotteryID == 15))
        {
            base.Response.Redirect(string.Concat(new object[] { "Buy_ZC.aspx?LotteryID=", this.LotteryID, "&Number=", Shove._Web.Utility.GetRequest("Number") }));
        }
        if (!base.IsPostBack)
        {
            long buyID = _Convert.StrToLong(Shove._Web.Utility.GetRequest("BuyID"), -1L);
            if (buyID > 0L)
            {
                this.BindDataForAliBuy(buyID);
            }
            this.tbWin1.InnerHtml = this.BindWinList("金额", DataCache.GetWinInfo(this.LotteryID));
            this.GetMiss();
            this.DZ = Encrypt.UnEncryptString(PF.GetCallCert(), Shove._Web.Utility.GetRequest("DZ"));
            this.GetInforMationListAndIsShow(this.LotteryID);
            if ((this.LotteryID == 5) || (this.LotteryID == 0x27))
            {
                this.BindSchemeUpload(this.LotteryID);
            }
            this.tdLuckNumber.InnerHtml = this.InitLuckLotteryNumber();
            if ((((this.LotteryID != 5) && (this.LotteryID != 0x3a)) && ((this.LotteryID != 0x3b) && (this.LotteryID != 6))) && (this.LotteryID != 13))
            {
                this.FC.Visible = false;
            }
            if ((this.LotteryID == 5) || (this.LotteryID == 6))
            {
                this.divLotteryNews.Visible = true;
                this.tdYC.InnerHtml = this.BindNewsForLottery(NewsType[this.LotteryID][0]);
                this.tdXB.InnerHtml = this.BindNewsForLottery(NewsType[this.LotteryID][1]);
                this.tdJQ.InnerHtml = this.BindNewsForLottery(NewsType[this.LotteryID][2]);
            }
            if (this.LotteryID == 5)
            {
                this.divWinNotice.Visible = true;
                this.divSSQ.Visible = true;
                this.div3D.Visible = false;
                this.tdNumber.Visible = true;
            }
            if (this.LotteryID == 6)
            {
                this.divWinNotice.Visible = true;
                this.divSSQ.Visible = false;
                this.div3D.Visible = true;
            }
            if (this.LotteryID == 13)
            {
                this.tdNumber.Visible = true;
            }
            this.BindWinNumber(this.LotteryID);
        }
    }

    private void SaveDataForAliBuy()
    {
        string request = Shove._Web.Utility.GetRequest("HidIsuseID");
        Shove._Web.Utility.GetRequest("HidIsuseEndTime");
        string s = Shove._Web.Utility.GetRequest("tbPlayTypeID");
        string str3 = Shove._Web.Utility.GetRequest("Chase");
        string str4 = Shove._Web.Utility.GetRequest("Cobuy");
        string str5 = Shove._Web.Utility.GetRequest("tb_Share");
        string str6 = Shove._Web.Utility.GetRequest("tb_BuyShare");
        string str7 = Shove._Web.Utility.GetRequest("tb_AssureShare");
        string str8 = Shove._Web.Utility.GetRequest("tb_OpenUserList");
        string str9 = Shove._Web.Utility.GetRequest("tb_Title");
        string str10 = Shove._Web.Utility.GetRequest("tb_Description");
        string str11 = Shove._Web.Utility.GetRequest("tbAutoStopAtWinMoney");
        string str12 = Shove._Web.Utility.GetRequest("SecrecyLevel");
        Shove._Web.Utility.GetRequest("tbPlayTypeName");
        string str13 = Shove._Web.Utility.FilteSqlInfusion(base.Request["tb_LotteryNumber"]);
        string str14 = Shove._Web.Utility.GetRequest("tb_hide_SumMoney");
        string str15 = Shove._Web.Utility.GetRequest("tb_hide_AssureMoney");
        string str = Shove._Web.Utility.GetRequest("tb_hide_SumNum");
        Shove._Web.Utility.GetRequest("HidIsuseCount");
        string str17 = Shove._Web.Utility.GetRequest("HidLotteryID");
        Shove._Web.Utility.GetRequest("HidIsAlipay");
        string str18 = Shove._Web.Utility.GetRequest("tb_Multiple");
        string str19 = "";
        StringBuilder builder = new StringBuilder();
        int num = 0;
        int num2 = 2;
        switch (s)
        {
            case "3903":
            case "3904":
                num2 = 3;
                break;

            default:
                num2 = 2;
                break;
        }
        if (str18 == "")
        {
            str18 = "1";
        }
        if (str3 == "1")
        {
            foreach (string str20 in base.Request.Form.AllKeys)
            {
                if (str20.IndexOf("check") > -1)
                {
                    int num4 = _Convert.StrToInt(str20.Replace("check", ""), -1);
                    if (num4 > 0)
                    {
                        num++;
                        int num5 = (_Convert.StrToInt(str, -1) * num2) * _Convert.StrToInt(base.Request.Form["times" + num4.ToString()], -1);
                        builder.Append(base.Request.Form[str20]).Append(",").Append(base.Request.Form["times" + num4.ToString()]).Append(",").Append(num5.ToString()).Append(";");
                    }
                }
            }
            string str21 = str13;
            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            if (str21[str21.Length - 1] == '\n')
            {
                str21 = str21.Substring(0, str21.Length - 1);
            }
            string[] strArray2 = builder.ToString().Split(new char[] { ';' });
            int length = strArray2.Length;
            string[] strArray3 = new string[length * 6];
            DateTime time2 = DateTime.Parse(Functions.F_GetIsuseSystemEndTime(long.Parse(strArray2[0].Split(new char[] { ',' })[0]), int.Parse(s)).ToString());
            if (DateTime.Now >= time2)
            {
                JavaScript.Alert(this.Page, "您选择的追号期号中包含已截止的期，请重新选择。");
                return;
            }
            for (int i = 0; i < length; i++)
            {
                strArray3[i * 6] = strArray2[i].Split(new char[] { ',' })[0];
                strArray3[(i * 6) + 1] = s;
                strArray3[(i * 6) + 2] = str21;
                strArray3[(i * 6) + 3] = strArray2[i].Split(new char[] { ',' })[1];
                strArray3[(i * 6) + 4] = strArray2[i].Split(new char[] { ',' })[2];
                strArray3[(i * 6) + 5] = str12;
            }
            str19 = PF.BuildIsuseAdditionasXmlForChase(strArray3);
        }
        long num8 = new Tables.T_AlipayBuyTemp
        {
            SiteID = { Value = 1 },
            UserID = { Value = -1 },
            Money = { Value = str14 },
            HandleResult = { Value = 0 },
            IsChase = { Value = str3 == "1" },
            IsCoBuy = { Value = str4 == "2" },
            LotteryID = { Value = str17 },
            IsuseID = { Value = request },
            PlayTypeID = { Value = s },
            StopwhenwinMoney = { Value = str11 },
            AdditionasXml = { Value = str19 },
            Title = { Value = str9 },
            Description = { Value = str10 },
            LotteryNumber = { Value = str13 },
            UpdateloadFileContent = { Value = "" },
            Multiple = { Value = str18 },
            BuyMoney = { Value = str6 },
            SumMoney = { Value = str14 },
            AssureMoney = { Value = str15 },
            Share = { Value = str5 },
            BuyShare = { Value = str6 },
            AssureShare = { Value = str7 },
            OpenUsers = { Value = str8 },
            SecrecyLevel = { Value = str12 }
        }.Insert();
        if (num8 < 0L)
        {
            new Log("System").Write("T_AlipayBuyTemp 数据库读写错误。");
        }
        JavaScript.Alert(this.Page, "您的账户余额不足，请先充值，谢谢。", "OnlinePay/Alipay02/Send.aspx?BuyID=" + num8.ToString());
    }

    private string[] SplitLotteryNumber(string Number)
    {
        string[] strArray = Number.Split(new char[] { '\n' });
        if (strArray.Length == 0)
        {
            return null;
        }
        for (int i = 0; i < strArray.Length; i++)
        {
            strArray[i] = strArray[i].Trim();
        }
        return strArray;
    }
}

