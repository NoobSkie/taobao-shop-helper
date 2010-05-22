<%@ WebHandler Language="C#" Class="Buy_Handler" %>

using System;
using System.Web;
using System.Text;
using Microsoft.JScript;
using System.Text.RegularExpressions;
using System.Web.SessionState;

using Shove.Database;

/// <summary>
/// 单场的投注处理程序
/// </summary>
public class Buy_Handler : IHttpHandler, IReadOnlySessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        Buy(context);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    /// <summary>
    /// 购买彩票
    /// </summary>
    private void Buy(HttpContext context)
    {

        Users _User = Users.GetCurrentUser(1);
        if (_User == null)
        {
            context.Response.Write(GlobalObject.escape("您的登录信息丢失，请重新登录。"));

            return;
        }

        #region 获取表单数据

        string lotId = Shove._Web.Utility.GetRequest(context, "lotid");                         //彩票编号
        string playid = Shove._Web.Utility.GetRequest(context, "playid");                     //玩法              
        string expect = Shove._Web.Utility.GetRequest(context, "expect");                       //期号
        string isuseid = Shove._Web.Utility.GetRequest(context, "isuseid");                       //期号编号        
        string ggtypegroupid = Shove._Web.Utility.GetRequest(context, "ggtypegroupid");         //过关类型（1,2,3）
        string ggtypeid = Shove._Web.Utility.GetRequest(context, "ggtypeid");                   //过关方式（M串N）
        string ggtypename = Shove._Web.Utility.GetRequest(context, "ggtypename");               //过关方式名称

        string codes = Shove._Web.Utility.GetRequest(context, "codes");                         //投注内容
        string zhushu = Shove._Web.Utility.GetRequest(context, "zhushu");                       //基本注数
        string multiple = Shove._Web.Utility.GetRequest(context, "multiple");                   //投注倍数
        string totalMoney = Shove._Web.Utility.GetRequest(context, "totalMoney");               //投注总金额    

        string ishm = Shove._Web.Utility.GetRequest(context, "ishm");                           //是否合买
        string bonusScale = Shove._Web.Utility.GetRequest(context, "bonusScale");               //佣金比例
        string divideCount = Shove._Web.Utility.GetRequest(context, "divideCount");             //合买份数
        string buyCount = Shove._Web.Utility.GetRequest(context, "buyCount");                   //认购份数      
        string baodiCount = Shove._Web.Utility.GetRequest(context, "baodiCount");               //保底份数 
        string buyUser = Shove._Web.Utility.GetRequest(context, "buyUser");                     //招股会员
        string caseTitle = Shove._Web.Utility.GetRequest(context, "caseTitle");                 //方案标题
        string caseDescription = Shove._Web.Utility.GetRequest(context, "caseDescription");     //方案说明    

        string secrecyLevel = Shove._Web.Utility.GetRequest(context, "secrecyLevel");           //方案保密   
        string zh_stopTime = Shove._Web.Utility.GetRequest(context, "zh_stopTime");               //本次投注中组合过关的停售时间
        string normal_stopTime = Shove._Web.Utility.GetRequest(context, "normal_stopTime");       //本次投注中普通过关的停售时间

        #endregion

        //StringBuilder rslStr = new StringBuilder();

        //rslStr.AppendLine("lotId=" + lotId)
        //    .AppendLine("expect=" + expect)
        //    .AppendLine("playType=" + playid)
        //    .AppendLine("ggtypegroupid=" + ggtypegroupid)
        //    .AppendLine("ggtypeid=" + ggtypeid)
        //    .AppendLine("ggtypename=" + ggtypename)
        //    .AppendLine("codes=" + codes)
        //    .AppendLine("zhushu=" + zhushu)
        //    .AppendLine("multiple=" + multiple)
        //    .AppendLine("totalMoney=" + totalMoney)
        //    .AppendLine("ishm=" + ishm)
        //    .AppendLine("bonusScale=" + bonusScale)
        //    .AppendLine("divideCount=" + divideCount)
        //    .AppendLine("buyCount=" + buyCount)
        //    .AppendLine("baodiCount=" + baodiCount)
        //    .AppendLine("buyUser=" + buyUser)
        //    .AppendLine("caseTitle=" + caseTitle)
        //    .AppendLine("caseDescription=" + caseDescription)
        //    .AppendLine("caseDescription=我是中国人")
        //    .AppendLine("zh_stopTime=" + zh_stopTime)
        //    .AppendLine("normal_stopTime=" + normal_stopTime)
        //    .AppendLine("SecrecyLevel=" + secrecyLevel);

        //context.Response.Write(GlobalObject.escape(rslStr.ToString()));

        //return;


        #region 数据验证区

        //************局部变量

        //彩种信息
        int LotteryID = 0;              //彩种
        int PlayTypeID = 0;             //玩法
        string IsuseName = "";               //期号
        long IsuseId = 0;                   //期号ID
        double Price = 2.00;                  //彩票单价

        //方案信息
        int BaseCount = 0;              //投注基本注数
        int Multiple = 0;               //投注倍数，       
        int SumNum = 0;                 //总的注数（基本注数*倍数）
        double SumMoney = 0;            //方案总金额
        short SecrecyLevel = 0;         //彩票单价

        //合买信息
        bool IsHm = false;              //是否合买
        double SchemeBonusScale = 0;    //佣金提成比例
        int Share = 0;                  //总的份数 
        int BuyShare = 0;               //认购份数
        double BuyMoney = 0;            //认购金额
        int AssureCount = 0;            //保底份数
        double AssureMoney = 0;         //保底金额 

        double TotalBuyMoney = 0;       //总购买金（认购+保底）

        DateTime ZH_endTime = DateTime.MinValue;               //本次投注中组合过关的停售时间
        DateTime Normal_endTime = DateTime.MinValue;       //本次投注中普通过关的停售时间

        int GGTGID = 1;                   //过关类型（1,2,3）

        //验证数据格式是否正确
        try
        {
            LotteryID = int.Parse(lotId);
            PlayTypeID = int.Parse(playid);
            IsuseName = expect;
            IsuseId = long.Parse(isuseid);

            BaseCount = int.Parse(zhushu);
            Multiple = int.Parse(multiple);
            SumNum = BaseCount * Multiple;
            SumMoney = double.Parse(totalMoney);
            SecrecyLevel = short.Parse(secrecyLevel);

            IsHm = ishm == "1" ? true : false;
            SchemeBonusScale = double.Parse(bonusScale);
            Share = int.Parse(divideCount);
            BuyShare = int.Parse(buyCount);
            AssureCount = int.Parse(baodiCount);

            Normal_endTime = DateTime.Parse(normal_stopTime);
            ZH_endTime = DateTime.Parse(zh_stopTime);

            GGTGID = int.Parse(ggtypegroupid);

        }
        catch
        {
            context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。01"));

            return;
        }

        //验证投注内容
        if (string.IsNullOrEmpty(IsuseName) || string.IsNullOrEmpty(codes))
        {
            context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。02"));

            return;
        }

        //验证彩种和玩法
        if (LotteryID != 45 || (PlayTypeID != 4501 && PlayTypeID != 4502 && PlayTypeID != 4503 && PlayTypeID != 4504 && PlayTypeID != 4505))
        {
            context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。03"));

            return;
        }

        //验证期号和赛事是否过期
        object endTime = MSSQL.ExecuteScalar("SELECT EndTime FROM dbo.T_Isuses WHERE LotteryID=" + Shove._Web.Utility.FilteSqlInfusion(LotteryID.ToString()) + " and Name='" +  Shove._Web.Utility.FilteSqlInfusion(IsuseName) + "'");

        if (endTime == null)
        {
            context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。04"));

            return;
        }

        //服务器现在的时间
        DateTime now = Shove._Convert.StrToDateTime(new DAL.Views.V_GetDate().Open("", "", "").Rows[0]["Now"].ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        //判断本期是否全部结束投注
        DateTime EndTime = Shove._Convert.StrToDateTime(endTime.ToString(), DateTime.MinValue.ToString());

        if (now >= EndTime)
        {
            context.Response.Write(GlobalObject.escape("本期投注已截止，谢谢。"));

            return;
        }

        //判断投注的赛事是否存在结束投注的赛事
        if (GGTGID > 3 || GGTGID < 1)
        {
            context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。04"));

            return;
        }

        if (GGTGID == 1 && Normal_endTime < now)
        {
            context.Response.Write(GlobalObject.escape("对不起，您方案中存在停售赛事，请重新投注。"));

            return;
        }

        if (GGTGID > 1 && ZH_endTime < now)
        {
            context.Response.Write(GlobalObject.escape("对不起，您方案中存在停售赛事，请重新投注。"));

            return;
        }

        //验证方案基本信息
        if (BaseCount < 1 || Multiple < 1 || SumMoney < 2 || SumNum < 1)
        {
            context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。05"));

            return;
        }

        if (SumMoney != BaseCount * Multiple * Price)
        {
            context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。06"));

            return;
        }

        //验证购买和总份数
        if (!IsHm || (IsHm && (BuyShare == Share) && (AssureCount == 0)))
        {
            Share = 1;
            BuyShare = 1;
            SchemeBonusScale = 4;
            AssureCount = 0;
        }

        //佣金比例
        if (SchemeBonusScale.ToString().IndexOf("-") > -1 || SchemeBonusScale.ToString().IndexOf(".") > -1 || SchemeBonusScale <= 0 || SchemeBonusScale >= 10)
        {
            context.Response.Write(GlobalObject.escape("佣金比例输入有误，只能输入0~10之间的数字！"));

            return;
        }

        //转换比例
        SchemeBonusScale = SchemeBonusScale / 100;

        //单份金额
        double perMoney = SumMoney / Share;

        Regex reg = new Regex(@"^\d+(?:\.\d\d?)?$");

        if (!reg.Match(perMoney.ToString()).Success || perMoney < 1)
        {
            context.Response.Write(GlobalObject.escape("方案单份金额小于1元或者不能精确计算单份金额值。"));

            return;
        }

        //份数
        if (Share < 1 || BuyShare < 1 || BuyShare > Share || AssureCount >= Share || AssureCount > (Share - BuyShare))
        {
            context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。07"));

            return;
        }

        //金额
        BuyMoney = BuyShare * perMoney;
        AssureMoney = AssureCount * perMoney;

        if (BuyMoney <= 0 || BuyMoney > SumMoney || AssureMoney >= SumMoney || AssureMoney > (SumMoney - BuyMoney))
        {
            context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。08"));

            return;
        }

        TotalBuyMoney = BuyMoney + AssureMoney;

        //余额判断
        if (TotalBuyMoney > _User.Balance)
        {
            //SaveDataForAliBuy();
            context.Response.Write(GlobalObject.escape("您的余额不足，请充值后再投注！"));

            return;
        }

        if (TotalBuyMoney > PF.SchemeMaxBettingMoney)
        {
            context.Response.Write(GlobalObject.escape("投注金额不能大于" + PF.SchemeMaxBettingMoney.ToString() + "，谢谢！"));

            return;
        }

        if (Multiple > 99)
        {
            context.Response.Write(GlobalObject.escape("投注倍数不能大于 99 倍，谢谢。"));

            return;
        }

        #endregion

        #region 投注区域

        //第一步：构造投注号码（目标格式：4501;[5(3)|15(3)|17(0)|19(0)|21(0)];[N2]，原始格式：59:[胜,平,负]/60:[胜]/61:[平,负]）

        switch (PlayTypeID)
        {
            case 4501:
                codes = "[" + codes.Replace(":", "").Replace("[", "(").Replace("]", ")").Replace("胜", "3").Replace("平", "1").Replace("负", "0").Replace("/", "|") + "]";

                break;
            case 4502:
                codes = "[" + codes.Replace(":", "").Replace("[", "(").Replace("]", ")").Replace("7 ", "7").Replace("/", "|") + "]";

                break;
            case 4503:
                codes = "[" + codes.Replace(":", "").Replace("[", "(").Replace("]", ")").Replace("上 单", "1").Replace("上 双", "2").Replace("下 单", "3").Replace("下 双", "4").Replace("/", "|") + "]";

                break;
            case 4504:
                codes = "[" + codes.Replace("[", "(").Replace("]", ")").
                    Replace("负其他", "25").Replace("2:4", "24").Replace("1:4", "23").Replace("0:4", "22").Replace("2:3", "21").
                    Replace("1:3", "20").Replace("0:3", "19").Replace("1:2", "18").Replace("0:2", "17").Replace("0:1", "16").
                    Replace("平其他", "15").Replace("3:3", "14").Replace("2:2", "13").Replace("1:1", "12").Replace("0:0", "11").
                    Replace("胜其他", "10").Replace("4:2", "9").Replace("4:1", "8").Replace("4:0", "7").Replace("3:2", "6").
                    Replace("3:1", "5").Replace("3:0", "4").Replace("2:1", "3").Replace("2:0", "2").Replace("1:0", "1").Replace(":", "").
                    Replace("/", "|") + "]";

                break;
            case 4505:
                codes = "[" + codes.Replace(":", "").Replace("[", "(").Replace("]", ")").
                    Replace("胜-胜", "1").Replace("胜-平", "2").Replace("胜-负", "3").
                    Replace("平-胜", "4").Replace("平-平", "5").Replace("平-负", "6").
                    Replace("负-胜", "7").Replace("负-平", "8").Replace("负-负", "9").
                    Replace("/", "|") + "]";

                break;
        }

        string[] types = ggtypeid.Split(',');

        string typeStr = "";

        for (int i = 0; i < types.Length; i++)
        {
            if (types[i] != string.Empty)
            {
                typeStr += (i == 0 ? "[" : "") + types[i] + multiple.ToString() + (i == types.Length - 1 ? "]" : ",");
            }
            else
            {
                context.Response.Write(GlobalObject.escape("输入有错误，请仔细检查。07"));

                return;
            }
        }

        codes = playid + ";" + codes + ";" + typeStr;

        //第二步：保存到数据库

        string ReturnDescription = "";
        long SchemeID = _User.InitiateScheme(IsuseId, PlayTypeID, caseTitle.Trim() == "" ? "(无标题)" : caseTitle.Trim(), caseDescription.Trim(), codes, "", Multiple, SumMoney, AssureMoney, Share, BuyShare, buyUser, SecrecyLevel, SchemeBonusScale, ref ReturnDescription);
        if (SchemeID < 0)
        {
            context.Response.Write(GlobalObject.escape("方案提交失败。错误描述：" + ReturnDescription));

            return;
        }

        context.Response.Write("true");

        #endregion
    }


}