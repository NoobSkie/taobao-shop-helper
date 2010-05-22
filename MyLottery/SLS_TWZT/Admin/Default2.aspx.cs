using Alipay.Gateway;
using ASP;
using DAL;
using Shove;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Default2 : Page, IRequiresSessionState
{


    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Label1.Text = "";
        this.Label2.Text = "";
        string alipayPaymentNumber = "";
        string returnDescription = "";
        OnlinePay pay = new OnlinePay();
        DataTable table = new Views.V_UserPayDetails().Open("ID, Name, DateTime, Money, PayType, FormalitiesFees, UserID", "Result = 1", "");
        double num2 = 0.0;
        foreach (DataRow row in table.Rows)
        {
            alipayPaymentNumber = "";
            if ((pay.Query(row["PayType"].ToString().Trim(), row["ID"].ToString(), ref alipayPaymentNumber, ref returnDescription) != 0) && (returnDescription == "等待买家付款"))
            {
                num2 += _Convert.StrToDouble(row["Money"].ToString(), 0.0);
                string text = this.Label1.Text;
                this.Label1.Text = text + "用户名：" + row["Name"].ToString() + "， 用户ID：" + row["UserID"].ToString() + "， 系统交易号：" + row["ID"].ToString() + "， 金额：" + row["Money"].ToString() + "<br />";
            }
        }
        this.Label2.Text = "合计总金额：" + num2.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        base.Response.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}

