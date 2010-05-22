using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_007ka_QueryResult : Page, IRequiresSessionState
{
    private string Attach = "";
    private string CardType = "";
    private string Command = "";
    private string Datetime = "";
    private string errorMessage = "";

    private string InterfaceName = "";
    private string InterfaceNumber = "";
    private string key = "";
    private string MerAccount = "";
    private string MerID = "";
    private string OrderID = "";
    private string Orderinfo = "";
    private string SignCounterpart = "";
    private SystemOptions so = new SystemOptions();
    private string TranInfo = "";
    private string TranOrder = "";
    private string TranStat = "";
    private string Value = "";

    private string GetMD5(string encypStr)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
        return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "").ToUpper();
    }

    private string GetTranStatToStringCH(int state)
    {
        switch (state)
        {
            case 1:
                return "交易成功";

            case 4:
                return "交易处理中";

            case 5:
                return "错误交易指令";

            case 6:
                return "接口版本号错误";

            case 7:
                return "代理商校验错误";

            case 8:
                return "代理商不存在";

            case 9:
                return "本次查询出现未知错误";

            case 14:
                return "交易已经过期";

            case 0x12:
                return "交易结果不能确定";

            case 0x13:
                return "无效充值卡";

            case 0x15:
                return "代理商已经暂停交易";

            case 0x18:
                return "不能为该用户充值";

            case 0x1c:
                return "成功金额小于申报金额";

            case 0x1d:
                return "成功金额大于申报价格，交易成功";

            case 0x1f:
                return "本条交易信息不存在";
        }
        return state.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.key = this.so["OnlinePay_007Ka_Key"].ToString("");
        try
        {
            this.SettingParams();
        }
        catch
        {
            this.errorMessage = "007订单查询结果：回调参数有误！";
            new Log("OnlinePay").Write(this.errorMessage);
            JavaScript.Alert(this.Page, this.errorMessage);
            return;
        }
        try
        {
            if (base.Request.QueryString.AllKeys.Length < 1)
            {
                this.errorMessage = this.OrderID + "订单查询结果：该数据传输丢失！";
                new Log("OnlinePay").Write(this.errorMessage);
                JavaScript.Alert(this.Page, this.errorMessage);
            }
            else if (this.SignCounterpart != this.GetMD5(this.Orderinfo + "|" + this.key))
            {
                this.errorMessage = this.OrderID + "订单查询结果：认证签名失败！";
                new Log("OnlinePay").Write(this.errorMessage);
                JavaScript.Alert(this.Page, this.errorMessage);
            }
            else if ((this.TranStat.ToString().Trim() != "1") && (this.TranStat.ToString().Trim() != "29"))
            {
                this.errorMessage = this.OrderID + "订单查询结果：007手机卡充值失败！错误号：" + this.TranStat.ToString() + " 错误描述：" + this.TranInfo + "(" + this.GetTranStatToStringCH(_Convert.StrToInt(this.TranStat.ToString(), 0)) + ")";
                new Log("OnlinePay").Write(this.errorMessage);
                JavaScript.Alert(this.Page, this.errorMessage);
            }
            else
            {
                DataTable table = new Tables.T_UserPayDetails().Open("Result,UserID", "ID=" + this.OrderID, "");
                if ((table == null) || (table.Rows.Count < 1))
                {
                    this.errorMessage = this.OrderID + "订单查询结果：支付号不存在，数据可能已近丢失！";
                    new Log("OnlinePay").Write(this.errorMessage);
                    JavaScript.Alert(this.Page, this.errorMessage);
                }
                else if (_Convert.StrToInt(table.Rows[0][1].ToString(), 0) != 0)
                {
                    if (_Convert.StrToInt(table.Rows[0][0].ToString(), 0) == 1)
                    {
                        this.errorMessage = this.OrderID + "订单充值已经成功!";
                        base.Response.Write("OK");
                        new Log("OnlinePay").Write(this.errorMessage);
                        JavaScript.Alert(this.Page, this.errorMessage);
                    }
                    else
                    {
                        int returnValue = -20000;
                        string returnDescription = "";
                        double num2 = this.so["OnlinePay_007Ka_FormalitiesFees"].ToDouble(0.0) / 100.0;
                        double formalitiesFees = Math.Round((double)((_Convert.StrToDouble(this.Value, 0.0) / 100.0) * num2), 2);
                        long userID = _Convert.StrToLong(table.Rows[0][1].ToString(), 0L);
                        Procedures.P_UserAddMoney(1L, userID, (_Convert.StrToDouble(this.Value, 0.0) / 100.0) - formalitiesFees, formalitiesFees, this.OrderID, "007KA", "007KA系统交易号" + this.OrderID, ref returnValue, ref returnDescription);
                        if (returnValue < 0)
                        {
                            this.errorMessage = this.OrderID + "订单查询结果：增加电子货币错误。错误原因：" + returnDescription;
                            new Log("OnlinePay").Write(this.errorMessage);
                            JavaScript.Alert(this.Page, this.errorMessage);
                        }
                        else
                        {
                            this.errorMessage = this.OrderID + "订单充值成功!";
                            base.Response.Write("OK");
                            new Log("OnlinePay").Write(this.errorMessage);
                            JavaScript.Alert(this.Page, this.errorMessage);
                        }
                    }
                }
                else
                {
                    this.errorMessage = this.OrderID + "订单查询结果：充值未完成！错误原因：用户不存在";
                    new Log("OnlinePay").Write(this.errorMessage);
                    JavaScript.Alert(this.Page, this.errorMessage);
                }
            }
        }
        catch
        {
            this.errorMessage = this.OrderID + "订单查询结果：错误描述：出现未知异常！";
            new Log("OnlinePay").Write(this.errorMessage);
            JavaScript.Alert(this.Page, this.errorMessage);
        }
    }

    private void SettingParams()
    {
        this.Orderinfo = Utility.GetRequest("Orderinfo");
        this.Orderinfo = HttpUtility.UrlDecode(this.Orderinfo);
        string[] strArray = this.Orderinfo.Split(new char[] { '|' });
        this.MerID = strArray[0];
        this.MerAccount = strArray[1];
        this.OrderID = strArray[2];
        this.TranStat = strArray[3];
        this.TranInfo = strArray[4];
        this.CardType = strArray[5];
        this.Value = strArray[6];
        this.Command = strArray[7];
        this.InterfaceName = strArray[8];
        this.InterfaceNumber = strArray[9];
        this.Datetime = strArray[10];
        this.TranOrder = strArray[11];
        this.Attach = strArray[12];
        this.SignCounterpart = strArray[13];
        this.Orderinfo = this.Orderinfo.Replace("|" + this.SignCounterpart, "");
    }

   
}

