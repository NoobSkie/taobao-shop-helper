using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Common
{
    public class PageNumber
    {
        public PageNumber(int number, HttpRequest request, bool isPost, string ctrlId)
        {
            Number = number;
            _request = request;
            _isPost = isPost;
            _doPostBackCtrlId = ctrlId;
        }

        private HttpRequest _request;
        private bool _isPost;
        private string _doPostBackCtrlId;

        public int PageIndex
        {
            get
            {
                if (string.IsNullOrEmpty(_request["page_index"]))
                {
                    return 0;
                }
                else
                {
                    return int.Parse(_request["page_index"]);
                }
            }
        }

        public bool Enable
        {
            get
            {
                if (PageIndex == Number)
                {
                    return false;
                }
                return true;
            }
        }

        public int Number { get; set; }

        public string DispalyName
        {
            get
            {
                if (Number != -1)
                {
                    return (Number + 1).ToString();
                }
                else
                {
                    return "…";
                }
            }
        }

        public string CssName
        {
            get
            {
                if (Number == -1)
                {
                    return "PageIndex More";
                }
                else if (PageIndex == Number)
                {
                    return "PageIndex Current";
                }
                else
                {
                    return "PageIndex Normal";
                }
            }
        }

        public string CurrentUrl
        {
            get
            {
                if (_isPost)
                {
                    if (Number == -1 || PageIndex == Number)
                    {
                        return string.Empty;
                    }
                    return "javascript:__doPostBack('" + _doPostBackCtrlId + "', '" + Number + "');";
                }
                else
                {
                    if (Number == -1 || PageIndex == Number)
                    {
                        return string.Empty;
                    }
                    string query = _request.Url.Query.TrimStart('?');
                    Dictionary<string, string> parameters = GetParameters(query);
                    if (parameters.ContainsKey("page_index"))
                    {
                        parameters["page_index"] = Number.ToString();
                    }
                    else
                    {
                        parameters.Add("page_index", Number.ToString());
                    }
                    string url = _request.Url.AbsolutePath;
                    query = GetQuery(parameters);
                    if (string.IsNullOrEmpty(query))
                    {
                        return url;
                    }
                    else
                    {
                        return url + "?" + query;
                    }
                }
            }
        }

        private string GetQuery(Dictionary<string, string> parameters)
        {
            string rtn = string.Empty;
            int i = 0;
            foreach (KeyValuePair<string, string> p in parameters)
            {
                if (i > 0)
                {
                    rtn += "&";
                }
                rtn += p.Key + "=" + p.Value;
                i++;
            }
            return rtn;
        }

        private Dictionary<string, string> GetParameters(string query)
        {
            Dictionary<string, string> rtn = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(query))
            {
                string[] parameters = query.Split('&');
                foreach (string p in parameters)
                {
                    string[] vs = p.Split('=');
                    if (vs.Length > 1)
                    {
                        rtn.Add(vs[0], vs[1]);
                    }
                    else if (vs.Length == 1)
                    {
                        rtn.Add(vs[0], string.Empty);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return rtn;
        }
    }

    public class ChangePageIndexArgs
    {
        public ChangePageIndexArgs(int index)
        {
            PageIndex = index;
        }

        public int PageIndex { get; set; }
    }

    public delegate void BeforeChangePageIndexHandler(ChangePageIndexArgs e);

    public partial class CtrlPager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitUrl();

                lblPageCount.Text = string.Format("共{0}页", PageCount);
                txtPageIndex.Text = (PageIndex + 1).ToString();
            }
        }

        public event BeforeChangePageIndexHandler BeforeChangePageIndex;

        public int PageIndex
        {
            get
            {
                if (string.IsNullOrEmpty(Request["page_index"]))
                {
                    return 0;
                }
                else
                {
                    return int.Parse(Request["page_index"]);
                }
            }
        }

        public int TotalCount { get; set; }

        public int PageCount
        {
            get
            {
                int module = TotalCount % PageSize;
                int count = TotalCount / PageSize;
                if (module == 0)
                {
                    return count;
                }
                return count + 1;
            }
        }

        private int pageSize;
        public int PageSize
        {
            get
            {
                if (pageSize <= 0)
                {
                    pageSize = 10;
                }
                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }

        private void InitUrl()
        {
            if (PageCount <= 1)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;

                if (IsFirst())
                {
                    hlnkPrev.Enabled = false;
                }
                else
                {
                    hlnkPrev.NavigateUrl = GetUrl(PageIndex - 1);
                }
                if (IsLast())
                {
                    hlnkNext.Enabled = false;
                }
                else
                {
                    hlnkNext.NavigateUrl = GetUrl(PageIndex + 1);
                }
                BindPageNumber();
            }
        }

        private void BindPageNumber()
        {
            List<PageNumber> pageNumberList = new List<PageNumber>();
            bool isPost = BeforeChangePageIndex != null;
            string ctrlId = lbtnGoPage.ClientID.Replace('_', '$');
            if (PageIndex <= 6)
            {
                for (int i = 0; i < PageIndex; i++)
                {
                    pageNumberList.Add(new PageNumber(i, Request, isPost, ctrlId));
                }
                for (int i = PageIndex; i < PageCount; i++)
                {
                    if (i > PageIndex + 4)
                    {
                        pageNumberList.Add(new PageNumber(-1, Request, isPost, ctrlId));
                        break;
                    }
                    pageNumberList.Add(new PageNumber(i, Request, isPost, ctrlId));
                }
            }
            else
            {
                pageNumberList.Add(new PageNumber(0, Request, isPost, ctrlId));
                pageNumberList.Add(new PageNumber(1, Request, isPost, ctrlId));
                pageNumberList.Add(new PageNumber(-1, Request, isPost, ctrlId));
                pageNumberList.Add(new PageNumber(PageIndex - 2, Request, isPost, ctrlId));
                pageNumberList.Add(new PageNumber(PageIndex - 1, Request, isPost, ctrlId));
                for (int i = PageIndex; i < PageCount; i++)
                {
                    if (i > PageIndex + 4)
                    {
                        pageNumberList.Add(new PageNumber(-1, Request, isPost, ctrlId));
                        break;
                    }
                    pageNumberList.Add(new PageNumber(i, Request, isPost, ctrlId));
                }
            }
            rptPageNumber.DataSource = pageNumberList;
            rptPageNumber.DataBind();
        }

        private bool IsFirst()
        {
            if (PageIndex == 0)
            {
                return true;
            }
            return false;
        }

        private bool IsLast()
        {
            if (PageIndex == PageCount - 1)
            {
                return true;
            }
            return false;
        }

        private Dictionary<string, string> parameters;
        private Dictionary<string, string> Parameters
        {
            get
            {
                if (parameters == null)
                {
                    string query = Request.Url.Query.TrimStart('?');
                    parameters = GetParameters(query);
                }
                return parameters;
            }
        }

        public string GetUrl(int index)
        {
            if (Parameters.ContainsKey("page_index"))
            {
                Parameters["page_index"] = index.ToString();
            }
            else
            {
                Parameters.Add("page_index", index.ToString());
            }
            string url = Request.Url.AbsolutePath;
            string query = GetQuery(Parameters);
            if (string.IsNullOrEmpty(query))
            {
                return url;
            }
            else
            {
                return url + "?" + query;
            }
        }

        private string GetQuery(Dictionary<string, string> parameters)
        {
            string rtn = string.Empty;
            int i = 0;
            foreach (KeyValuePair<string, string> p in parameters)
            {
                if (i > 0)
                {
                    rtn += "&";
                }
                rtn += p.Key + "=" + p.Value;
                i++;
            }
            return rtn;
        }

        private Dictionary<string, string> GetParameters(string query)
        {
            Dictionary<string, string> rtn = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(query))
            {
                string[] parameters = query.Split('&');
                foreach (string p in parameters)
                {
                    string[] vs = p.Split('=');
                    if (vs.Length > 1)
                    {
                        rtn.Add(vs[0], vs[1]);
                    }
                    else if (vs.Length == 1)
                    {
                        rtn.Add(vs[0], string.Empty);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return rtn;
        }

        public void GoToPageIndex(int pageIndex, params KeyValuePair<string, string>[] parameters)
        {
            foreach (KeyValuePair<string, string> p in parameters)
            {
                if (Parameters.ContainsKey(p.Key))
                {
                    Parameters[p.Key] = p.Value;
                }
                else
                {
                    Parameters.Add(p.Key, p.Value);
                }
            }
            Response.Redirect(GetUrl(pageIndex), true);
        }

        protected void lbtnGoPage_Click(object sender, EventArgs e)
        {
            string args = this.Request.Params["__EVENTARGUMENT"];
            if (!string.IsNullOrEmpty(args))
            {
                int index = int.Parse(args);
                if (BeforeChangePageIndex != null)
                {
                    BeforeChangePageIndex(new ChangePageIndexArgs(index));
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtPageIndex.Text.Trim()))
                {
                    txtPageIndex.Text = (PageIndex + 1).ToString();
                }
                int index;
                if (int.TryParse(txtPageIndex.Text, out index))
                {
                    index--;
                    if (index < 0)
                    {
                        index = 0;
                    }
                    else if (index >= PageCount)
                    {
                        index = PageCount - 1;
                    }
                }
                else
                {
                    index = PageIndex;
                }
                Response.Redirect(GetUrl(index), true);
            }
        }
    }
}