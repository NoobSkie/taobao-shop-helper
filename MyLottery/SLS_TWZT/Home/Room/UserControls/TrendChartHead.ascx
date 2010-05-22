<%@ control language="C#" autoeventwireup="true" CodeFile="TrendChartHead.ascx.cs" inherits="Home_Room_UserControls_TrendChartHead" %>
<style type="text/css">
    body
    {
        min-width: 1000px;
    }
    .mOver
    {
        color: white;
        padding-left: 20px;
        padding-right: 20px;
    }
    .mOut
    {
        color: #226699;
        padding-left: 15px;
        padding-right: 15px;
    }
</style>
<div>
    <table cellpadding="0" cellspacing="0" style="width: 1002px;" align="center">
        <tr>
            <td style="padding-top: 1px;">
                <div style="background-image: url(../../Home/Room/images/cz_blue_bg.jpg); padding-left: 20px;
                    border: 1px solid #9BBFCA;">
                    <table cellpadding="0" cellspacing="0" style="text-align: center; cursor: pointer;
                        line-height: 20px; font-weight: bold; color: White;">
                        <tbody style="padding-top: 5px;">
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </tbody>
                        <tbody id="tbLotteries" style="padding-left: 10px; padding-right: 10px;">
                            <tr>
                                <td class="blue12" id='Loottery_5' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(5);'>
                                    双色球
                                </td>
                                <td class="blue12" id='Loottery_39' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(39);'>
                                    超级大乐透
                                </td>
                                <td class="blue12" id='Loottery_62' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(62);'>
                                    十一运夺金
                                </td>
                                <td class="blue12" id='Loottery_29' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(29);'>
                                    时时乐
                                </td>
                                <td class="blue12" id='Loottery_6' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(6);'>
                                    福彩3D
                                </td>
                                <td class="blue12" id='Loottery_13' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(13);'>
                                    七乐彩
                                </td>
                                <td id='Loottery_61' class="blue12" onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(61);'>
                                    时时彩
                                </td>
                                <td class="blue12" id='Loottery_63' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(63);'>
                                    排列3
                                </td>
                                <td class="blue12" id='Loottery_64' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(64);'>
                                    排列5
                                </td>
                                <td class="blue12" id='Loottery_3' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(3);'>
                                    七星彩
                                </td>
                                <td class="blue12" id='Loottery_9' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(9);'>
                                    22选5
                                </td>
                                <td class="blue12" id='Loottery_58' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(58);'>
                                    东方6+1
                                </td>
                                <td class="blue12" id='Loottery_59' onmouseover='mOver(this)' onmouseout='mOut(this)'
                                    onclick='mChangeLottery(59);'>
                                    华东15选5
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px;">
                <table id="Charts" align="left" cellpadding="3" cellspacing="0">
                    <tbody id="tbCharts" class="black12" style="line-height: 25px;">
                        <tr>
                            <td id='Charts5' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>双色球:</span><a
                                    href='../SSQ/SSQ_CGXMB.aspx' target="_top">常规项目表走势图</a> | <a href='../SSQ/SSQ_ZHFB.aspx'
                                        target="_top">综合分布走势图</a> | <a href='../SSQ/SSQ_3FQ.aspx' target="_top">3分区分布走势图</a>
                                | <a href='../SSQ/SSQ_DX.aspx' target="_top">大小分析走势图</a> | <a href='../SSQ/SSQ_JO.aspx'
                                    target="_top">奇偶分析走势图</a> | <a href='../SSQ/SSQ_ZH.aspx' target="_top">质合分析走势图</a>
                                | <a href='../SSQ/SSQ_HL.aspx' target="_top">红蓝球走势图</a> | <a href='../SSQ/SSQ_BQZST.aspx'
                                    target="_top">蓝球综合走势图</a>
                            </td>
                            <td id='Charts6' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-right: 8px;'>福彩3D:</span><a href='../FC3D/FC3D_ZHXT.aspx'
                                    target="_top">综合分布遗漏走势图</a> | <a href='../FC3D/FC3D_C3YS.aspx' target="_top">除三余数形态遗漏走势图</a>
                                | <a href='../FC3D/FC3D_ZHZST.aspx' target="_top">质合形态遗漏走势图</a> | <a href='../FC3D/FC3D_XTZST.aspx'
                                    target="_top">形态走势遗漏走势图</a> | <a href='../FC3D/FC3D_KDZST.aspx' target="_top">跨度走势遗漏走势图</a>
                                | <a href='../FC3D/FC3D_HZZST.aspx' target="_top">和值走势遗漏走势图</a> | <a href='../FC3D/FC3D_DZXZST.aspx'
                                    target="_top">大中小形态遗漏走势图</a> | <a href='../FC3D/FC3D_C3YS_HTML.aspx' target="_top">除三余数号码分区表走势图</a>
                                | <a href='../FC3D/FC3D_2CHW.aspx' target="_top">二次和尾差尾查询表走势图</a> | <a href='../FC3D/FC3D_DSHM.aspx'
                                    target="_top">单双点号码分区表走势图</a><br />
                                <a href='../FC3D/FC3D_DTHM.aspx' target="_top">胆托号码分区表走势图</a> | <a href='../FC3D/FC3D_DX_JO.aspx'
                                    target="_top">大小—奇偶号码分区表走势图</a> | <a href='../FC3D/FC3D_HSWH.aspx' target="_top">和数尾号码分区表走势图</a>
                                | <a href='../FC3D/FC3D_HSZ.aspx' target="_top">和数值号码分区表走势图</a> | <a href='../FC3D/FC3D_KDZH.aspx'
                                    target="_top">跨度组合分区表走势图</a> | <a href='../FC3D/FC3D_JO_DX.aspx' target="_top">奇偶—大小号码分区表走势图</a>
                                | <a href='../FC3D/FC3D_LHZH.aspx' target="_top">连号组合分区表走势图</a> | <a href='../FC3D/FC3D_ZS.aspx'
                                    target="_top">质数号码分区表走势图</a>
                            </td>
                            <td id='Charts13' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>七乐彩:</span><a
                                    href='../QLC/7LC_CGXMB.aspx' target="_top">七乐彩常规项目表走势图</a> | <a href='../QLC/7LC_ZHFB.aspx'
                                        target="_top">七乐彩综合分布走势图</a>
                            </td>
                            <td id='Charts61' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-right: 8px;'>时时彩:</span><a href='../JXSSC/SSC_5X_ZHFB.aspx'
                                    target="_top">标准五星综合走势图</a> | <a href='../JXSSC/SSC_5X_ZST.aspx' target="_top">标准五星走势图</a>
                                | <a href='../JXSSC/SSC_5X_HZZST.aspx' target="_top">五星和值走势图</a> | <a href='../JXSSC/SSC_5X_KDZST.aspx'
                                    target="_top">五星跨度走势图</a> | <a href='../JXSSC/SSC_5X_PJZZST.aspx' target="_top">五星平均值走势图</a>
                                | <a href='../JXSSC/SSC_5X_DXZST.aspx' target="_top">五星大小走势图</a> | <a href='../JXSSC/SSC_5X_JOZST.aspx'
                                    target="_top">五星奇偶走势图</a> | <a href='../JXSSC/SSC_5X_ZHZST.aspx' target="_top""'">五星质合走势图</a>
                                | <a href='../JXSSC/SSC_4X_ZHFB.aspx' target="_top">标准四星综合走势图</a> | <a href='../JXSSC/SSC_4X_ZST.aspx'
                                    target="_top">标准四星走势图</a> | <a href='../JXSSC/SSC_4X_HZZST.aspx' target="_top">四星和值走势图</a>
                                |
                                <br />
                                <a href='../JXSSC/SSC_4X_KDZST.aspx' target="_top">四星跨度走势图</a> | <a href='../JXSSC/SSC_4X_PJZZST.aspx'
                                    target="_top">四星平均值走势图</a> | <a href='../JXSSC/SSC_4X_DXZST.aspx' target="_top">四星大小走势图</a>
                                | <a href='../JXSSC/SSC_4X_JOZST.aspx' target="_top">四星奇偶走势图</a> | <a href='../JXSSC/SSC_4X_ZHZST.aspx'
                                    target="_top">四星质合走势图</a> | <a href='../JXSSC/SSC_3X_ZHZST.aspx' target="_top">标准三星综合</a>
                                | <a href='../JXSSC/SSC_3X_ZST.aspx' target="_top">标准三星走势图</a> | <a href='../JXSSC/SSC_3X_HZZST.aspx'
                                    target="_top">三星和值走势图</a> | <a href='../JXSSC/SSC_3X_HZWZST.aspx' target="_top">三星和值尾走势图</a>
                                | <a href='../JXSSC/SSC_3X_KDZST.aspx' target="_top">三星跨度走势图</a> | <a href='../JXSSC/SSC_3X_DXZST.aspx'
                                    target="_top">三星大小走势图</a> | <a href='../JXSSC/SSC_3X_JOZST.aspx' target="_top">三星奇偶走势图</a>
                                <br />
                                <a href='../JXSSC/SSC_3X_ZhiHeZST.aspx' target="_top">三星质合走势图</a> | <a href='../JXSSC/SSC_3X_DX_012_ZST.aspx'
                                    target="_top">单选012路走势图</a> | <a href='../JXSSC/SSC_3X_ZX_012_ZST.aspx' target="_top">
                                        组选012路走势图</a> | <a href='../JXSSC/SSC_2X_ZHFBZST.aspx' target="_top">标准二星综合走势图</a>
                                | <a href='../JXSSC/SSC_2X_HZZST.aspx' target="_top">二星和值走势图</a> | <a href='../JXSSC/SSC_2X_HZWZST.aspx'
                                    target="_top">二星和尾走势图</a> | <a href='../JXSSC/SSC_2XPJZZST.aspx' target="_top">二星均值走势图</a>
                                | <a href='../JXSSC/SSC_2X_KDZST.aspx' target="_top">二星跨度走势图</a> | <a href='../JXSSC/SSC_2X_012ZST.aspx'
                                    target="_top">二星012路走势图</a> | <a href='../JXSSC/SSC_2X_MaxZST.aspx' target="_top">二星最大值走势图</a>
                                | <a href='../JXSSC/SSC_2X_MinZST.aspx' target="_top">二星最小值走势图</a> | <a href='../JXSSC/SSC_2X_DXDSZST.aspx'
                                    target="_top">大小单双走势图</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <a target="_blank" href="../../Home/Room/Export.aspx?LotteryID=61" style="color: Red;
                                    font-size: 14px; font-weight: bold; text-decoration: underline; text-align: right;">
                                    历史开奖号码下载</a>
                            </td>
                            <td id='Charts29' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>时时乐:</span><a
                                    href='../SHSSL/SHSSL_ZHFB.aspx' target="_top">综合分布图（基本走势图）</a> | <a href='../SHSSL/SHSSL_012.aspx'
                                        target="_top">012路（除3余数）走势图</a> | <a href='../SHSSL/SHSSL_DX.aspx' target="_top">大小分析走势图</a>
                                | <a href='../SHSSL/SHSSL_JO.aspx' target="_top">奇偶分析走势图</a> | <a href='../SHSSL/SHSSL_ZH.aspx'
                                    target="_top">质合分析走势图</a> | <a href='../SHSSL/SHSSL_HZ.aspx' target="_top">和值走势图</a>
                                &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp <a target="_blank" href="../../Home/Room/Export.aspx?LotteryID=29"
                                    style="color: Red; font-size: 14px; font-weight: bold; text-decoration: underline;
                                    text-align: right;">历史开奖号码下载</a>
                            </td>
                            <td id='Charts62' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>十一运夺金:</span><a
                                    class="link_b" href="../SYYDJ/SYDJ_FBZS.aspx" onclick="setAColor(this);" target="_top">分布走势图</a>
                                | <a href="../SYYDJ/SYDJ_DWZS.aspx" onclick="setAColor(this);" target="_top">定位走势图</a>
                                | <a href="../SYYDJ/SYDJ_HZFB.aspx" onclick="setAColor(this);" target="_top">和值分布走势图</a>
                                | <a href="../SYYDJ/SYDJ_Q2FBT.aspx" onclick="setAColor(this);" target="_top">前二分布走势图</a>
                                | <a href="../SYYDJ/SYDJ_Q2ZXDYB.aspx" onclick="setAColor(this);" target="_top">前二组选对应表走势图</a>
                                | <a href="../SYYDJ/SYDJ_Q2HZ.aspx" onclick="setAColor(this);" target="_top">前二和值走势图</a>
                                | <a href="../SYYDJ/SYDJ_Q3FWT.aspx" onclick="setAColor(this);" target="_top">前三分位图走势图</a>
                                | <a href="../SYYDJ/SYDJ_Q3FBT.aspx" onclick="setAColor(this);" target="_top">前三分布走势图</a>
                                | <a href="../SYYDJ/SYDJ_Q3HZT.aspx" onclick="setAColor(this);" target="_top">前三和值图走势图</a>
                                &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp <a
                                    target="_blank" href="../../Home/Room/Export.aspx?LotteryID=62" style="color: Red;
                                    font-size: 14px; font-weight: bold; text-decoration: underline; text-align: right;">
                                    历史开奖号码下载</a>
                            </td>
                            <td id='Charts58' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>东方6+1:</span><a
                                    href='../DF6J1/DF61_ZHFB.aspx' target="_top">东方6+1综合分布走势图</a>
                            </td>
                            <td id='Charts59' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>华东15选5:</span><a
                                    href='../HD15X5/C15X5_CGXMB.aspx' target="_top">15选5常规项目表走势图</a> | <a href='../HD15X5/C15X5_ZHZST.aspx'
                                        target="_top">15选5综合分布走势图</a>
                            </td>
                            <td id='Charts60' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>天天彩选4:</span><a
                                    href='../TTCX4/4D_CGXMB.aspx' target="_top">4D常规项目表走势图</a> | <a href='../TTCX4/4D_ZHFB.aspx'
                                        target="_top">4D综合分布走势图</a>
                            </td>
                            <td id='Charts39' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>超级大乐透:</span><a
                                    href='../CJDLT/CJDLT_HMFB.aspx' target='mainFrame'>
                                    分布走势图</a> | <a href='CJDLT_jima.aspx' target='mainFrame'>
                                        前区走势图</a> | <a href='CJDLT_TeMa.aspx' target='mainFrame'>
                                            后区走势图</a> | <a href='CJDLT_JimaLengRe.aspx'
                                                target='mainFrame'>前区冷热走势图</a> | <a href='CJDLT_TemaLengRe.aspx'
                                                    target='mainFrame'>后区冷热走势图</a> | <a href='CJDLT_JO.aspx'
                                                        target='mainFrame'>奇偶走势图</a> | <a href='CJDLT_YS.aspx'
                                                            target='mainFrame'>余数走势图</a> | <a href='CJDLT_JiMaWeihao.aspx'
                                                                target='mainFrame'>前区尾号分布走势图</a> | <a href='CJDLT_HZZong.aspx'
                                                                    target='mainFrame'>和值分析走势图</a> | <a href='CJDLT_LH.aspx'
                                                                        target='mainFrame'>连号分析走势图</a>
                            </td>
                            <td id='Charts3' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>七星彩:</span><a
                                    href='7X_HMFB.aspx' target='mainFrame'>分布走势图</a>
                                | <a href='7X_CF.aspx' target='mainFrame'>重复分布走势图</a>
                                | <a href='7X_LH.aspx' target='mainFrame'>连号分布走势图</a>
                                | <a href='7X_DX.aspx' target='mainFrame'>大小分布走势图</a>
                                | <a href='7X_JO.aspx' target='mainFrame'>奇偶分布走势图</a>
                                | <a href='7X_YS.aspx' target='mainFrame'>余数分布走势图</a>
                                | <a href='7X_HZheng.aspx' target='mainFrame'>
                                    和值分布走势图</a> | <a href='X7_012.aspx' target='mainFrame'>
                                        012路分布走势图</a> | <a href='7X_ZH.aspx' target='mainFrame'>
                                            质合分布走势图</a> | <a href='X7_DZX.aspx' target='mainFrame'>
                                                大中小分布走势图</a>
                            </td>
                            <td id='Charts9' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>22选5:</span><a
                                    href='http://www.hb-win.com/TrendCharts/TC22X5/22X5_HMFB.aspx' target='mainFrame'>
                                    分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/TC22X5/22X5_LH.aspx' target='mainFrame'>
                                        连号分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/TC22X5/22X5_JO.aspx' target='mainFrame'>
                                            奇偶分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/TC22X5/22X5_WeiHaoCF.aspx'
                                                target='mainFrame'>重复分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/TC22X5/22X5_HMLR.aspx'
                                                    target='mainFrame'>号码历史冷热走势图</a> | <a href='http://www.hb-win.com/TrendCharts/TC22X5/22X5_WeiHao.aspx'
                                                        target='mainFrame'>尾号分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/TC22X5/22X5_YS.aspx'
                                                            target='mainFrame'>余数分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/TC22X5/22X5_HZ_Zong.aspx'
                                                                target='mainFrame'>和值分布走势图</a>
                            </td>
                            <td id='Charts63' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>排列3:</span><a
                                    href='http://www.hb-win.com/TrendCharts/PL3/PL3_HMFB.aspx' target='mainFrame'> 排列三分布走势图
                                </a>| <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_CF.aspx' target='mainFrame'>
                                    排列三重复分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_LH.aspx' target='mainFrame'>
                                        排列三连号分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_DX.aspx' target='mainFrame'>
                                            排列三大小分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_JO.aspx' target='mainFrame'>
                                                排列三奇偶分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_YS.aspx' target='mainFrame'>
                                                    排列三余数分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_HZ.aspx' target='mainFrame'>
                                                        排列三和值分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_012.aspx' target='mainFrame'>
                                                            排列三012路分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_KD.aspx' target='mainFrame'>
                                                                排列三跨度分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_ZX.aspx' target='mainFrame'>
                                                                    排列三组选分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_ZH.aspx' target='mainFrame'>
                                                                        排列三质合数分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_DZX.aspx' target='mainFrame'>
                                                                            排列三大中小分布走势图</a> | <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_WH.aspx' target='mainFrame'>
                                                                                排列三位和分布走势图 </a>| <a href='http://www.hb-win.com/TrendCharts/PL3/PL3_GD.aspx' target='mainFrame'>
                                                                                    排列三固定分析图走势图</a>
                            </td>
                            <td id='Charts64' style="padding-left: 30px; text-align: left;">
                                <span class='blue14' style='padding-left: 30px; padding-right: 8px;'>排列5:</span><a
                                    href='http://www.hb-win.com/TrendCharts/PL5/PL5_KJFB.aspx' target='mainFrame'> 排列五开奖分布走势图</a>
                                | <a href='http://www.hb-win.com/TrendCharts/PL5/PL5_CF.aspx' target='mainFrame'>排列五重复分布走势图</a>
                                | <a href='http://www.hb-win.com/TrendCharts/PL5/PL5_LH.aspx' target='mainFrame'>排列五连号分布走势图</a>
                                | <a href='http://www.hb-win.com/TrendCharts/PL5/PL5_DX.aspx' target='mainFrame'>排列五大小分布走势图</a>
                                | <a href='http://www.hb-win.com/TrendCharts/PL5/PL5_JO.aspx' target='mainFrame'>排列五奇偶分布走势图</a>
                                | <a href='http://www.hb-win.com/TrendCharts/PL5/PL5_YS.aspx' target='mainFrame'>排列五余数分布走势图</a>
                                | <a href='http://www.hb-win.com/TrendCharts/PL5/PL5_HZ.aspx' target='mainFrame'>排列五和值分布走势图</a>
                                | <a href='http://www.hb-win.com/TrendCharts/PL5/PL5_012.aspx' target='mainFrame'>排列五大中小分布走势图</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</div>

<script type="text/javascript" language="javascript">

    var lastClickTabMenu = null;

    //特显样式
    if (location.href.indexOf("/SSQ/") >= 0) {
        mClick(document.getElementById('Loottery_5'), 'Charts5');
    }
    else if (location.href.indexOf("/CJDLT/") >= 0) {
        mClick(document.getElementById('Loottery_39'), 'Charts39');
    }
    else if (location.href.indexOf("/SYYDJ/") >= 0) {
        mClick(document.getElementById('Loottery_62'), 'Charts62');
    }
    else if (location.href.indexOf("/SHSSL/") >= 0) {
        mClick(document.getElementById('Loottery_29'), 'Charts29');
    }
    else if (location.href.indexOf("/FC3D/") >= 0) {
        mClick(document.getElementById('Loottery_6'), 'Charts6');
    }
    else if (location.href.indexOf("/QLC/") >= 0) {
        mClick(document.getElementById('Loottery_13'), 'Charts13');
    }
    else if (location.href.indexOf("/JXSSC/") >= 0) {
        mClick(document.getElementById('Loottery_61'), 'Charts61');
    }
    else if (location.href.indexOf("/HD15X5/") >= 0) {
        mClick(document.getElementById('Loottery_59'), 'Charts59');
    }
    else if (location.href.indexOf("/DF6J1/") >= 0) {
        mClick(document.getElementById('Loottery_58'), 'Charts58');
    }
    else if (location.href.indexOf("/FC3D/") >= 0) {
        mClick(document.getElementById('Loottery_6'), 'Charts6');
    }
    else if (location.href.indexOf("/PL3/") >= 0) {
        mClick(document.getElementById('Loottery_63'), 'Charts63');
    }
    else if (location.href.indexOf("/PL5/") >= 0) {
        mClick(document.getElementById('Loottery_64'), 'Charts64');
    }
    else if (location.href.indexOf("/7Xing/") >= 0) {
        mClick(document.getElementById('Loottery_3'), 'Charts3');
    }
    else if (location.href.indexOf("/TC22X5/") >= 0) {
        mClick(document.getElementById('Loottery_9'), 'Charts9');
    }
    else {
        mClick(document.getElementById('Loottery_5'), 'Charts5');
    }

    function setAColor(k) {
        var coll = document.all.tags("A");
        if (coll != null) {
            for (i = 0; i < coll.length; i++)
                coll[i].className = "";
        }

        k.className = "link_b";
    }

    function mOver(obj) {
        obj.className = 'mOver';
    }

    function mOut(obj) {

        if (lastClickTabMenu != obj) {
            obj.className = 'mOut';
        }
    }

    function mClick(obj, id) {

        mOver(obj);
        lastClickTabMenu = obj;

        var charts = document.getElementById("Charts").cells;
        var l = charts.length;

        for (var i = 0; i < l; i++) {
            charts[i].style.display = "none";
        }

        document.getElementById(id).style.display = "";
    }

    //点击彩种
    function mChangeLottery(lid) {

        var dir = "";

        switch (lid) {

            case 5:
                dir = "SSQ/SSQ_CGXMB.aspx";
                break;
            case 39:
                dir = "CJDLT/Default.aspx";
                break;
            case 62:
                dir = "SYYDJ/SYDJ_FBZS.aspx";
                break;
            case 29:
                dir = "SHSSL/SHSSL_ZHFB.aspx";
                break;
            case 6:
                dir = "FC3D/FC3D_ZHXT.aspx";
                break;
            case 13:
                dir = "QLC/7LC_CGXMB.aspx";
                break;
            case 61:
                dir = "JXSSC/SSC_5X_ZHFB.aspx";
                break;
            case 63:
                dir = "PL3/Default.aspx";
                break;
            case 64:
                dir = "PL5/Default.aspx";
                break;
            case 3:
                dir = "7Xing/Default.aspx";
                break;
            case 9:
                dir = "TC22X5/Default.aspx";
                break;
            case 58:
                dir = "DF6J1/DF61_ZHFB.aspx";
                break;
            case 59:
                dir = "HD15X5/C15X5_CGXMB.aspx";
                break;

        }

        var url = location.href;

        if (url.indexOf(dir) < 0) {
            url = url.substring(0, url.indexOf("TrendCharts") + 12) + dir;
            window.location.href = url;
        }

    }
   
</script>

