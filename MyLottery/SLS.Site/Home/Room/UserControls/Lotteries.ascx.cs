using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SLS.Site.App_Code;
using Shove.Database;
using SLS.Site.App_Code.DAL;

namespace SLS.Site.Home.Room.UserControls
{
    public partial class Lotteries : UserControlBase
    {
        public string F_GetUsedLotteryList(long SiteID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUsedLotteryList", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string cacheAsString = Shove._Web.Cache.GetCacheAsString("Site_UseLotteryList" + base._Site.ID, "");
            string[] strArray = null;
            if (cacheAsString == "")
            {
                cacheAsString = Functions.F_GetUsedLotteryList(base._Site.ID);
                if (cacheAsString != "")
                {
                    Shove._Web.Cache.SetCache("Site_UseLotteryList" + base._Site.ID, cacheAsString);
                }
            }
            strArray = cacheAsString.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Equals("5"))
                {
                    this.aHref5.Disabled = false;
                    this.aHref5.HRef = "~/Lottery/Buy_SSQ.aspx";
                    this.aHref5a.Disabled = false;
                    this.aHref5a.HRef = "~/Lottery/Buy_SSQ.aspx";
                }
                else if (strArray[i].Equals("6"))
                {
                    this.aHref6.Disabled = false;
                    this.aHref6.HRef = "~/Lottery/Buy_3D.aspx";
                }
                else if (strArray[i].Equals("13"))
                {
                    this.aHref13.Disabled = false;
                    this.aHref13.HRef = "~/Lottery/Buy_QLC.aspx";
                }
                else if (strArray[i].Equals("59"))
                {
                    this.aHref59.Disabled = false;
                    this.aHref59.HRef = "~/Lottery/Buy_15X5.aspx";
                }
                else if (strArray[i].Equals("58"))
                {
                    this.aHref58.Disabled = false;
                    this.aHref58.HRef = "~/Lottery/Buy_DF6J1.aspx";
                }
                else if (strArray[i].Equals("3"))
                {
                    this.aHref3.Disabled = false;
                    this.aHref3.HRef = "~/Lottery/Buy_QXC.aspx";
                }
                else if (strArray[i].Equals("39"))
                {
                    this.aHref39.Disabled = false;
                    this.aHref39.HRef = "~/Lottery/Buy_CJDLT.aspx";
                    this.aHref39a.Disabled = false;
                    this.aHref39a.HRef = "~/Lottery/Buy_CJDLT.aspx";
                }
                else if (strArray[i].Equals("9"))
                {
                    this.aHref9.Disabled = false;
                    this.aHref9.HRef = "~/Lottery/Buy_22X5.aspx";
                }
                else if (strArray[i].Equals("63"))
                {
                    this.aHref63.Disabled = false;
                    this.aHref63.HRef = "~/Lottery/Buy_PL3.aspx";
                }
                else if (strArray[i].Equals("64"))
                {
                    this.aHref64.Disabled = false;
                    this.aHref64.HRef = "~/Lottery/Buy_PL5.aspx";
                }
                else if (strArray[i].Equals("65"))
                {
                    this.aHref65.Disabled = false;
                    this.aHref65.HRef = "~/Lottery/Buy_31X7.aspx";
                }
                else if (strArray[i].Equals("1"))
                {
                    this.aHref1.Disabled = false;
                    this.aHref1_9.Disabled = false;
                    this.aHref1.HRef = "~/Lottery/Buy_SFC.aspx";
                    this.aHref1_9.HRef = "~/Lottery/Buy_SFC_9_D.aspx";
                    this.aHref1a.Disabled = false;
                    this.aHref1a.HRef = "~/Lottery/Buy_SFC.aspx";
                }
                else if (strArray[i].Equals("2"))
                {
                    this.aHref2.Disabled = false;
                    this.aHref2.HRef = "~/Lottery/Buy_JQC.aspx";
                }
                else if (strArray[i].Equals("15"))
                {
                    this.aHref15.Disabled = false;
                    this.aHref15.HRef = "~/Lottery/Buy_LCBQC.aspx";
                }
                else if (strArray[i].Equals("29"))
                {
                    this.aHref29.Disabled = false;
                    this.aHref29.HRef = "~/Lottery/Buy_SSL.aspx";
                    this.aHref29a.Disabled = false;
                    this.aHref29a.HRef = "~/Lottery/Buy_SSL.aspx";
                }
                else if (strArray[i].Equals("62"))
                {
                    this.aHref62.Disabled = false;
                    this.aHref62.HRef = "~/Lottery/Buy_SYYDJ.aspx";
                }
                else if (strArray[i].Equals("61"))
                {
                    this.aHref61.Disabled = false;
                    this.aHref61.HRef = "~/Lottery/Buy_SSC.aspx";
                }
                else if (strArray[i].Equals("28"))
                {
                    this.aHref61.Disabled = false;
                    this.aHref61.HRef = "~/Lottery/Buy_CQSSC.aspx";
                }
                else if (strArray[i].Equals("70"))
                {
                    this.aHref70.Disabled = false;
                    this.aHref70.HRef = "~/Lottery/Buy_JX11X5.aspx";
                }
                else if (strArray[i].Equals("41"))
                {
                    this.aHref41.Disabled = false;
                    this.aHref41.HRef = "~/Lottery/Buy_ZJTC6J1.aspx";
                }
            }
        }
    }
}