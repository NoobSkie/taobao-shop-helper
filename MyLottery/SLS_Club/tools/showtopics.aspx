<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="Discuz.Forum" %>
<%@ Import Namespace="Discuz.Common" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Discuz.Entity" %>

<script runat="server">
    /**
     * 本程序版权归官方所有
     * R-Author:Richie.eng
     * Date: 2007-09-10
     * URL: http://www.jygbbs.com
     * */
    //-------------------------------------------------------------------------------------------
    /*  模板代码开始 在此调整样式 请注意备份.
	{0}代表帖子ID, 
	{1}代表帖子标题, 
	{2}代表帖子所属论坛ID, 
	{3}代表帖子所属论坛名称 , 
	{4}代表帖子未截字的完整标题,双引号用\"表示，建议使用单引号 , 
	{5}代表图片缩略图路径(从根路径开始输出，设置type参数为1(正方形)或2(原比例)或onlyimg参数为1时有效)
    {6}代表帖子序号。
	{7}代表发帖用户id
	{8}代表发帖用户名称
     $代表帖子前显示的列表图片
    */
    public string[] Templates = {
	    //模板0 奇数行模板
        "<span>[<a href=\"showforum-{2}.aspx\" title=\"{4}\">{3}</a>]<a href=\"showtopic-{0}.aspx\" title=\"{4}\">{1}</a></span>",
	    //模板1 奇数行模板			
        "<a href=\"showforum-{2}.aspx\" title=\"{4}\">{1}</a>",
	    //模板2 奇数行图片调用模板
        "<img src=\"{5}\" title=\"{4}\" />",
        //模板3 奇数行只显示图片链接地址
        "{5}",
        //模板4 奇数行只显示贴子标题
        "{4}",        
        //模板5 奇数行取得贴子URL地址
        "/showtopic-{0}.aspx",
        //模板6 奇数行取得贴子URL地址
        "/showtopic-{0}.aspx",
        //模板7 奇数行以标题形式显示贴子
        "<li><img src=\"Richie/images/c_$.gif\" align=\"absmiddle\" width=\"11\" height=\"11\" />&nbsp;<a href=\"showtopic-{0}.aspx\" title=\"{4}\">{1}</a></li>"
        //"<li><a href=\"/showtopic-{0}.aspx\"  title=\"{4}\">{1}</a></li>"
        
    };

    public string[] AlternatingTemplates = {
	    //模板0 偶数行模板			
        "<span style=\"background-color: #ffffcc;\">[<a href=\"showforum-{2}.aspx\" title=\"{4}\">{3}</a>]<a href=\"showtopic-{0}.aspx\"title=\"{4}\">{1}</a></span>",
	    //模板1 偶数行模板			
        "<a href=\"showforum-{2}.aspx\" title=\"{4}\"><b>{1}</b></a>",
	    //模板2 偶数行图片调用模板
        "<img src=\"{5}\" title=\"{4}\" />",
        //模板3 偶数行只显示图片链接地址
        "|{5}|",
        //模板4 偶数行只显示贴子标题
        "|{4}|",
        //模板5 偶数行取得贴子URL地址
        "|/showtopic-{0}.aspx|",
        //模板6 偶数行取得贴子URL地址
        "|/showtopic-{0}.aspx|",
        //模板7 偶数行以标题形式显示贴子
        "<li><img src=\"Richie/images/c_$.gif\" align=\"absmiddle\" width=\"11\" height=\"11\" />&nbsp;<a href=\"showtopic-{0}.aspx\"title=\"{4}\">{1}</a></li>"
        //"<li><a href=\"/showtopic-{0}.aspx\"  title=\"{4}\">{1}</a></li>"
    };

    /* 模板代码结束 */

    override protected void OnInit(EventArgs e)
    {
        int count = DNTRequest.GetQueryInt("count", 10);
        int views = DNTRequest.GetQueryInt("views", -1);
        int fid = DNTRequest.GetQueryInt("fid", 0);
        int tType = DNTRequest.GetQueryInt("time", 0);
        int oType = DNTRequest.GetQueryInt("order", 0);
        bool isDigest = DNTRequest.GetQueryInt("digest", 0) == 1;
        int mid = DNTRequest.GetQueryInt("template", 0);
        int cachetime = DNTRequest.GetQueryInt("cachetime", 20);
        bool onlyimg = DNTRequest.GetQueryInt("onlyimg", 0) == 1;



        try
        {
            if (Request.QueryString["encoding"] != null)
                Response.ContentEncoding = System.Text.Encoding.GetEncoding(Request.QueryString["encoding"]);

            string template = Templates[mid];
            string alternatingTemplate = AlternatingTemplates[mid];

            TopicTimeType timeType = ConvertTimeType(tType);
            TopicOrderType orderType = ConvertOrderType(oType);

            /*  
            Focuss.GetTopicList(count, views, fid, timetype, ordertype, isdigest, timespan, onlyimg)方法说明
            <summary>
            获得帖子列表
            </summary>
            <param name="count">最大数量</param>
            <param name="views">最小浏览量, -1为不限制</param>
            <param name="fid">板块ID,0为全部板块</param>
            <param name="timetype">期限类型，一天(TopicTimeType.Day)、一周(TopicTimeType.Week)、一月(TopicTimeType.Month)、不限制(TopicTimeType.All)</param>
            <param name="ordertype">排序类型，id倒序(TopicOrderType.ID)、访问量倒序(TopicOrderType.Views)、最后回复排序(TopicOrderType.LastPost)</param>
            <param name="isdigest">是否精华</param>
            <param name="timespan">缓存时间</param>
            <param name="onlyimg">是否只为图片</param>
            <returns></returns>
            */
            if (mid == 6)
            {
                DataTable dt = Discuz.Forum.Users.GetUserList(10, 1, "[posts]", "");
                OutPut1(dt, template, alternatingTemplate, count);
            }
            else if (mid == 3 || mid == 5)
            {
                string imagsBanner = "";
                string linksBanner = "";
                string CacheKey = "dtNews_ForumIndex";
                DataTable dt = Shove._Web.Cache.GetCacheAsDataTable(CacheKey);
                dt = null;
                if (dt == null)
                {
                    dt = new DAL.Tables.T_News().Open("top 6 [ID],[Title],[Content],ImageUrl", "isShow = 1 and ImageUrl <> '' and SiteID = 1", "DateTime Desc");
                    dt.Columns.Add(new DataColumn("Url"));

                    string url = null;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        url = dt.Rows[i]["Content"].ToString();

                        Regex regex = new Regex(@"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        Match m = regex.Match(url);

                        if (m.Success)
                        {
                            dt.Rows[i]["Url"] = url;
                        }
                        else
                        {
                            dt.Rows[i]["Url"] = "";
                        }
                    }

                    Shove._Web.Cache.SetCache(CacheKey, dt, 600);
                }

                if (dt != null && dt.Rows.Count > 0)
                {

                    int i = 0;

                    foreach (DataRow dr in dt.Rows)
                    {
                        imagsBanner += "cache/thumbnail/" + dr["ImageUrl"].ToString() + "|";

                        if (dr["Url"].ToString() == "")
                        {
                            linksBanner += "'ShowNews.aspx?id=" + dr["ID"].ToString() + "'|";
                        }
                        else
                        {
                            linksBanner += dr["Url"].ToString() + "|";
                        }
                        i++;

                    }
                }
                if (imagsBanner != "")
                {
                    Response.Write("var pics=\"" + imagsBanner.Substring(0, imagsBanner.Length - 1) + "\";");
                    Response.Write("var links=\"" + linksBanner + "\";");
                }
            }
            else
            {
                DataTable dt = Focuses.GetTopicList(count, views, fid, timeType, orderType, isDigest, cachetime, onlyimg);
                OutPut(dt, template, alternatingTemplate);
            }

        }
        catch
        {
            Response.Write("document.write(\"参数错误，请检查！\");");
        }
        finally
        {
            Response.End();
        }
        base.OnInit(e);
    }

    /// <summary>
    /// 按用户发贴数显示用户发贴信息
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="template"></param>
    /// <param name="alternatingTemplate"></param>
    /// <param name="count"></param>
    private void OutPut1(DataTable dt, string template, string alternatingTemplate, int count)
    {
        string result = "";
        string[] _img = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow user = dt.Rows[i];
            if (i < count)
            {
                result += "document.write('<li><img src=\"Richie/images/c_" + _img[i] + ".gif\" align=\"absmiddle\" width=\"11\" height=\"11\">"
                    + "&nbsp;<a href=userinfo.aspx?userid=" + user["uid"].ToString() + ">"
                    + user["username"].ToString().Trim() + "</a>&nbsp;<font color = \"red\">" + user["posts"].ToString().Trim() + "</font></li>');";
            }
            else
            {
                break;
            }
        }
        Response.Write(result);
    }

    /// <summary>
    /// 基本的输出信息
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="template"></param>
    /// <param name="alternatingTemplate"></param>
    private void OutPut(DataTable dt, string template, string alternatingTemplate)
    {
        string result = "";
        int length = DNTRequest.GetQueryInt("length", -1);
        int contentType = DNTRequest.GetQueryInt("type", 0);
        int imgMaxSize = DNTRequest.GetQueryInt("imgsize", 80);
        bool onlyimg = DNTRequest.GetQueryInt("onlyimg", 0) == 1;

        string[] _img = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        //在此修改了官方原先用的foreach语句，听说for比foreach更快速，也不知道是真是假
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];

            ForumInfo forum = Forums.GetForumInfo(Convert.ToInt32(dr["fid"]));
            string title = dr["title"].ToString().Trim();
            string thumbnail = "";
            if (contentType == 1 || contentType == 2 || onlyimg)
            {
                thumbnail = "cache/thumbnail/t_10_200_1.jpg";
            }

            //如果标题字符数超过了一定字数，则截取一定的字符显示，后面则以……显示,template.Replace("$", _img[i])显示不同的序号图片
            result += string.Format((i % 2 == 0 ? template.Replace("$", _img[i]) : alternatingTemplate.Replace("$", _img[i])), dr["tid"].ToString(),
                ((title.Length  < length) ? title : Utils.GetSubString(title, length, "") + "…"), forum.Fid, forum.Name, title, thumbnail, i + 1);
        }
        switch (DNTRequest.GetQueryInt("template", 0))
        {
            case (int)4: //取得图片对应的贴子标题
                Response.Write("var texts=\"" + result.Replace("'", "\\'") + "\";");
                break;
            default:
                Response.Write("document.write('" + result.Replace("'", "\\'") + "');");
                break;
                
            //case (int)3: //取得图片地址
            //    Response.Write("var pics=\"" + result.Replace("'", "\\'") + "\";");
            //    break;
           
            //case (int)5: //取得图片对应贴子的URL地址
            //    //result = result.Substring(1);             // 这句代码 是用来去掉 ‘/’的，如果不加上 链接地址会有问题
            //    result = result.Replace("/", "");
            //    Response.Write("var links=\"" + result.Replace("'", "\\'") + "\";");
            //    break;
                
            
        }
    }

    private TopicTimeType ConvertTimeType(int t)
    {
        switch (t)
        {
            case (int)TopicTimeType.Day:
                return TopicTimeType.Day;
            case (int)TopicTimeType.Week:
                return TopicTimeType.Week;
            case (int)TopicTimeType.Month:
                return TopicTimeType.Month;
            default: return TopicTimeType.All;
        }
    }

    private TopicOrderType ConvertOrderType(int t)
    {
        switch (t)
        {
            case (int)TopicOrderType.Views:
                return TopicOrderType.Views;
            case (int)TopicOrderType.LastPost:
                return TopicOrderType.LastPost;
            default: return TopicOrderType.ID;
        }
    }

    private ThumbnailType ConvertThumbnailType(int t)
    {
        switch (t)
        {
            case (int)ThumbnailType.Square:
                return ThumbnailType.Square;
            case (int)ThumbnailType.Thumbnail:
                return ThumbnailType.Thumbnail;
            default: return ThumbnailType.Square;
        }
    }

</script>

