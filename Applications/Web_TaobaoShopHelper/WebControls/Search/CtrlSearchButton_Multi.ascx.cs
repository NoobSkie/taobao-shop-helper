using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using Newtonsoft.Json.Linq;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Search
{
    public delegate void AfterReturnedEventHadler(SearchWinReturnedEventArg e);

    public class SearchWinReturnedEventArg
    {
        public SearchWinReturnedEventArg(SearchWinType searchWinType, string json)
        {
            PostData = json;
            SearchWinType = searchWinType;
        }

        public string PostData { get; set; }

        public SearchWinType SearchWinType { get; set; }
    }

    public partial class CtrlSearchButton_Multi : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (WindowWidth == 0)
                {
                    WindowWidth = 700;
                }
                if (WindowHeight == 0)
                {
                    WindowHeight = 500;
                }
                string url = SearchWinUrl;
                url += "?CtrlId=" + this.ClientID;
                url += "&Type=" + (int)SearchWinType;
                url += "&Title=" + Server.UrlEncode(SearchWinTitle);
                url += "&Info=" + Server.UrlEncode(Information);
                url += "&Demo=" + Server.UrlEncode(DemoInput);
                url += "&IsInTest=" + IsInTest;
                hlnkSearch.Attributes["onclick"] =
                    string.Format("ShowSearchWin('{0}', '{1}px', '{2}px', 'yes', '{3}');"
                    , url
                    , WindowWidth
                    , WindowHeight
                    , IsInTest);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID + "_SetSearchWinType", this.ClientID + "_SearchWinType = '" + SearchWinType.ToString() + "';", true);
            }
        }

        protected void lbtnDoPostBack_Click(object sender, EventArgs e)
        {
            string args = this.Request.Params["__EVENTARGUMENT"];
            if (AfterReturned != null)
            {
                AfterReturned(new SearchWinReturnedEventArg(SearchWinType, args));
            }
        }

        protected string PostButtonId
        {
            get
            {
                return lbtnDoPostBack.ClientID.Replace('_', '$');
            }
        }

        public bool IsInTest
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }

        public event AfterReturnedEventHadler AfterReturned;

        public SearchWinType SearchWinType
        {
            get
            {
                return (SearchWinType)ViewState[this.ClientID + ".SearchWinType"];
            }
            set
            {
                ViewState[this.ClientID + ".SearchWinType"] = value;
            }
        }

        public string SearchWinTitle { get; set; }

        /// <summary>
        /// 显示的提示信息
        /// </summary>
        public string Information { get; set; }

        public string DemoInput { get; set; }

        public string Text
        {
            set
            {
                hlnkSearch.Text = value;
            }
        }

        public int WindowWidth { get; set; }

        public int WindowHeight { get; set; }

        private string SearchWinUrl
        {
            get
            {
                string rootUrl = GetRootURI();
                string pageName;
                switch (SearchWinType)
                {
                    case SearchWinType.Multi_MyItems:
                        pageName = "SearchMyItems_Multi.aspx";
                        break;
                    case SearchWinType.Input_Text:
                        pageName = "Input_Text.aspx";
                        break;
                    case SearchWinType.Input_Image:
                        pageName = "Input_Image.aspx";
                        break;
                    default:
                        pageName = SearchWinType.ToString() + ".aspx";
                        break;
                }
                return rootUrl + "/SearchWin/" + pageName;
            }
        }
    }
}