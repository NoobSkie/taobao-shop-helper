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
        public SearchWinReturnedEventArg(string json)
        {
            Json = json;
        }

        public string Json { get; set; }
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
                hlnkSearch.Attributes["onclick"] =
                    string.Format("ShowSearchWin('{0}', '{1}px', '{2}px', 'yes');"
                    , SearchWinUrl
                    , WindowWidth
                    , WindowHeight);
            }
        }

        protected void lbtnDoPostBack_Click(object sender, EventArgs e)
        {
            string args = this.Request.Params["__EVENTARGUMENT"];
            if (AfterReturned != null)
            {
                AfterReturned(new SearchWinReturnedEventArg(args));
            }
        }

        protected string PostButtonId
        {
            get
            {
                return lbtnDoPostBack.ClientID.Replace('_', '$');
            }
        }

        public event AfterReturnedEventHadler AfterReturned;

        public SearchWinType SearchWinType { get; set; }

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
                string rootUrl = GetRootUrl();
                string pageName;
                switch (SearchWinType)
                {
                    case SearchWinType.Multi_MyItems:
                        pageName = "SearchMyItems_Multi.aspx";
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