namespace Shove.HTML
{
    using Shove.HTML.HtmlParse;
    using Shove.HTML.SgmlReader;
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.XPath;

    public class HTML
    {
        public static string ClearCommentary(string html)
        {
            return Regex.Replace(html, @"<!--[\S\s]*?-->", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public static string ClearReplace(string s)
        {
            s = Regex.Replace(s, @"&(\s*\w+;)+", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            s = Regex.Replace(s, @"[\t\r\n]+", " ", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            s = Regex.Replace(s, @"\s+", " ", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return s;
        }

        public static string ClearScript(string html)
        {
            return Regex.Replace(html, @"<script[\S\s]*?>[\S\s]*?</script>", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public static string ClearStyle(string html)
        {
            return Regex.Replace(html, @"<style[\S\s]*?>[\S\s]*?</style>", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public static string GetBody(string html, bool WithBodyTag)
        {
            Regex regex;
            if (WithBodyTag)
            {
                regex = new Regex(@"(?<body><Body[\S\s]*?>[\S\s]*?</Body>)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            }
            else
            {
                regex = new Regex(@"<Body[\S\s]*?>[\s\t\r\n]*(?<body>[\S\s]*?)[\s\t\r\n]*</Body>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            }
            return regex.Match(html).Groups["body"].Value;
        }

        public static string GetDescription(string html, int MaxLen)
        {
            if (html.Trim() == "")
            {
                return "";
            }
            MatchCollection matchs = new Regex("<meta[\\s\\t\\r\\n]+([^>]*?content[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*(?:\"(?<content>[^\"]*)\"|'(?<content>[^']*)'|(?<content>[^\\s\\t\\r\\n>]*)))?[^>]*?name[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*[\"']?description[\"']?([^>]*?content[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*(?:\"(?<content>[^\"]*)\"|'(?<content>[^']*)'|(?<content>[^\\s\\t\\r\\n>]*)))?[^>]*>", RegexOptions.Compiled | RegexOptions.IgnoreCase).Matches(html);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < matchs.Count; i++)
            {
                builder.Append(ClearReplace(matchs[i].Groups["content"].Value) + " ");
            }
            if ((MaxLen >= 1) && (builder.Length > MaxLen))
            {
                return builder.ToString().Substring(0, MaxLen);
            }
            return builder.ToString().Trim();
        }

        public static string GetHTML(string Url)
        {
            int type = -1;
            DateTime now = DateTime.Now;
            string hostAbsolutePath = "";
            return GetHTML(Url, ref type, ref now, ref hostAbsolutePath);
        }

        public static string GetHTML(string Url, ref int Type, ref DateTime LastModifiedTime, ref string HostAbsolutePath)
        {
            Type = -1;
            LastModifiedTime = DateTime.Now;
            HostAbsolutePath = "";
            HttpWebResponse response = null;
            StreamReader reader = null;
            try
            {
                WebRequest request = WebRequest.Create(Url);
                request.Timeout = 0x1388;
                response = (HttpWebResponse) request.GetResponse();
                LastModifiedTime = response.LastModified;
                HostAbsolutePath = response.ResponseUri.AbsoluteUri;
                string absolutePath = response.ResponseUri.AbsolutePath;
                int startIndex = absolutePath.LastIndexOf("/");
                if (startIndex > 0)
                {
                    absolutePath = absolutePath.Substring(startIndex, absolutePath.Length - startIndex);
                }
                HostAbsolutePath = HostAbsolutePath.Substring(0, HostAbsolutePath.Length - absolutePath.Length).ToLower();
                if (response.ContentType.ToLower().StartsWith("image/"))
                {
                    Type = 2;
                    return "";
                }
                if (response.ContentType.ToLower().StartsWith("audio/"))
                {
                    Type = 3;
                    return "";
                }
                if (!response.ContentType.ToLower().StartsWith("text/"))
                {
                    Type = -1;
                    return "";
                }
                reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            }
            catch
            {
                Type = -1;
                return "";
            }
            string str2 = "";
            string str3 = "";
            try
            {
                while (str3 != null)
                {
                    str3 = reader.ReadLine();
                    if (str3 != null)
                    {
                        str2 = str2 + str3;
                    }
                }
                Type = 1;
                return str2;
            }
            catch
            {
                Type = -1;
                return "";
            }
        }

        public static string[] GetHTMLUrls(string Page, string HostAbsolutePath, int MaxLen, int FindUrlLevel)
        {
            ArrayList list = new ArrayList();
            ParseHTML ehtml = new ParseHTML();
            ehtml.Source = Page;
            while (!ehtml.Eof())
            {
                if (ehtml.Parse() == '\0')
                {
                    Shove.HTML.HtmlParse.Attribute attribute = ehtml.GetTag()["HREF"];
                    if (attribute != null)
                    {
                        string str = attribute.Value.Trim().ToLower();
                        if ((((str != "") && !str.StartsWith("mailto")) && !str.StartsWith("#")) && (((FindUrlLevel == 2) || str.StartsWith("http://")) || str.StartsWith("https://")))
                        {
                            str = GetPath(str, HostAbsolutePath);
                            if ((MaxLen < 1) || (str.Length <= MaxLen))
                            {
                                list.Add(str);
                            }
                        }
                    }
                    attribute = ehtml.GetTag()["SRC"];
                    if (attribute != null)
                    {
                        string str2 = attribute.Value.Trim().ToLower();
                        if ((str2 != "") && (((FindUrlLevel == 2) || str2.StartsWith("http://")) || str2.StartsWith("https://")))
                        {
                            str2 = GetPath(str2, HostAbsolutePath);
                            if ((MaxLen < 1) || (str2.Length <= MaxLen))
                            {
                                list.Add(str2);
                            }
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        public static string[,] GetHTMLUrlsWithDescription(string Page, string HostAbsolutePath, int HrefMaxLen, int DescriptionMaxLen, int FindUrlLevel)
        {
            int num;
            string title = GetTitle(Page, DescriptionMaxLen);
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            MatchCollection matchs = new Regex("<a[\\s\\t\\r\\n]+[\\S\\s]*?href[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*(?:\"(?<href>[^\"]*)\"|'(?<href>[^']*)'|(?<href>[^\\s\\t\\r\\n>]*))[^>]*>(?<title>[\\S\\s]*?)</a[\\s\\t\\r\\n]*>", RegexOptions.Compiled | RegexOptions.IgnoreCase).Matches(Page);
            for (num = 0; num < matchs.Count; num++)
            {
                string str2 = matchs[num].Groups["href"].Value.Trim().ToLower();
                string str3 = ClearReplace(matchs[num].Groups["title"].Value);
                if (str2.StartsWith("mailto") || str2.StartsWith("#"))
                {
                    str2 = "";
                }
                bool flag = false;
                if (str3 == "")
                {
                    str3 = title;
                    flag = true;
                }
                else if ((DescriptionMaxLen > 0) && (str3.Length > DescriptionMaxLen))
                {
                    str3 = str3.Substring(0, DescriptionMaxLen);
                }
                if (str2 != "")
                {
                    if (((FindUrlLevel != 2) && !str2.StartsWith("http://")) && !str2.StartsWith("https://"))
                    {
                        continue;
                    }
                    str2 = GetPath(str2, HostAbsolutePath);
                    if ((HrefMaxLen > 0) && (str2.Length > HrefMaxLen))
                    {
                        str2 = "";
                    }
                }
                if (str2 != "")
                {
                    if (((str3 == "") || flag) || ((str3.IndexOf("<") < 0) && (str3.IndexOf(">") < 0)))
                    {
                        list.Add(str2);
                        list2.Add(str3);
                        continue;
                    }
                    string s = StandardizationHTML(str3, true, true, true);
                    if (s == "")
                    {
                        list.Add(str2);
                        list2.Add(title);
                        continue;
                    }
                    XmlDocument document = new XmlDocument();
                    document.Load(new StringReader(s));
                    str3 = "";
                    XmlNodeList elementsByTagName = document.GetElementsByTagName("*");
                    if (elementsByTagName == null)
                    {
                        list.Add(str2);
                        list2.Add(title);
                        continue;
                    }
                    for (int i = 0; i < elementsByTagName.Count; i++)
                    {
                        if (elementsByTagName[i].Name.ToUpper() == "IMG")
                        {
                            try
                            {
                                str3 = str3 + elementsByTagName[i].Attributes["ALT"].Value + " ";
                            }
                            catch
                            {
                            }
                            break;
                        }
                    }
                    if (str3.Trim() == "")
                    {
                        XPathNodeIterator iterator = document.CreateNavigator().Select("*");
                        while (iterator.MoveNext())
                        {
                            str3 = str3 + iterator.Current.Value + " ";
                        }
                    }
                    if (str3.Trim() == "")
                    {
                        str3 = title;
                    }
                    else if ((DescriptionMaxLen > 0) && (str3.Length > DescriptionMaxLen))
                    {
                        str3 = str3.Substring(0, DescriptionMaxLen);
                    }
                    list.Add(str2);
                    list2.Add(str3.Trim());
                }
            }
            matchs = new Regex("<img[\\s\\t\\r\\n]+([^>]*?alt[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*(?:\"(?<alt>[^\"]*)\"|'(?<alt>[^']*)'|(?<alt>[^\\s\\t\\r\\n>]*)))?[^>]*?src[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*(?:\"(?<src>[^\"]*)\"|'(?<src>[^']*)'|(?<src>[^\\s\\t\\r\\n>]*))([^>]*?alt[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*(?:\"(?<alt>[^\"]*)\"|'(?<alt>[^']*)'|(?<alt>[^\\s\\t\\r\\n>]*)))?[^>]*>", RegexOptions.Compiled | RegexOptions.IgnoreCase).Matches(Page);
            for (num = 0; num < matchs.Count; num++)
            {
                string str5 = matchs[num].Groups["src"].Value.Trim().ToLower();
                string str6 = matchs[num].Groups["alt"].Value.Trim();
                if (str6 == "")
                {
                    str6 = title;
                }
                else if ((DescriptionMaxLen > 0) && (str6.Length > DescriptionMaxLen))
                {
                    str6 = str6.Substring(0, DescriptionMaxLen);
                }
                if (str5 != "")
                {
                    if (((FindUrlLevel == 2) || str5.StartsWith("http://")) || str5.StartsWith("https://"))
                    {
                        str5 = GetPath(str5, HostAbsolutePath);
                    }
                    if ((HrefMaxLen > 0) && (str5.Length > HrefMaxLen))
                    {
                        str5 = "";
                    }
                }
                if (str5 != "")
                {
                    list.Add(str5);
                    list2.Add(str6);
                }
            }
            string[,] strArray = new string[2, list.Count];
            for (num = 0; num < list.Count; num++)
            {
                strArray[0, num] = list[num].ToString();
                strArray[1, num] = list2[num].ToString();
            }
            return strArray;
        }

        public static string GetKeywords(string html, int MaxLen)
        {
            if (html.Trim() == "")
            {
                return "";
            }
            MatchCollection matchs = new Regex("<meta[\\s\\t\\r\\n]+([^>]*?content[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*(?:\"(?<content>[^\"]*)\"|'(?<content>[^']*)'|(?<content>[^\\s\\t\\r\\n>]*)))?[^>]*?name[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*[\"']?keywords[\"']?([^>]*?content[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*(?:\"(?<content>[^\"]*)\"|'(?<content>[^']*)'|(?<content>[^\\s\\t\\r\\n>]*)))?[^>]*>", RegexOptions.Compiled | RegexOptions.IgnoreCase).Matches(html);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < matchs.Count; i++)
            {
                builder.Append(ClearReplace(matchs[i].Groups["content"].Value) + " ");
            }
            if ((MaxLen >= 1) && (builder.Length > MaxLen))
            {
                return builder.ToString().Substring(0, MaxLen);
            }
            return builder.ToString().Trim();
        }

        public static string GetText(string html, int MaxLen)
        {
            string str = GetElementContentByPath(html, "HTML/BODY");
            if (str == "")
            {
                int index = html.IndexOf("<BODY");
                if (index < 0)
                {
                    return "";
                }
                int length = html.LastIndexOf("</BODY");
                if (length < 0)
                {
                    length = html.Length;
                }
                if (length <= index)
                {
                    return "";
                }
                html = "<HTML>" + html.Substring(index, length - index) + "</BODY></HTML>";
                str = GetElementContentByPath(html, "HTML/BODY");
                if ((MaxLen > 0) && (str.Length > MaxLen))
                {
                    return str.Substring(0, MaxLen);
                }
                return str;
            }
            if ((MaxLen > 0) && (str.Length > MaxLen))
            {
                return str.Substring(0, MaxLen);
            }
            return str;
        }

        public static string GetTitle(string html, int MaxLen)
        {
            html = html.Trim();
            if (html == "")
            {
                return "";
            }
            MatchCollection matchs = new Regex(@"<title[^>]*?>(?<title>[^<]*?)</title[\s\t\r\n]*>", RegexOptions.Compiled | RegexOptions.IgnoreCase).Matches(html);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < matchs.Count; i++)
            {
                builder.Append(ClearReplace(matchs[i].Groups["title"].Value) + " ");
            }
            if ((MaxLen >= 1) && (builder.Length > MaxLen))
            {
                return builder.ToString().Substring(0, MaxLen);
            }
            return builder.ToString().Trim();
        }

        public static string SetTextKeywordsHighLight(string Text, string[] Keywords, string Color)
        {
            if (Text.Trim() == "")
            {
                return "";
            }
            int length = Keywords.Length;
            if (length == 0)
            {
                return Text;
            }
            string str2 = Color.Trim().ToLower();
            if (str2 != null)
            {
                if (!(str2 == "red"))
                {
                    if (str2 == "green")
                    {
                        Color = "00FF00";
                    }
                    else if (str2 == "blue")
                    {
                        Color = "0000FF";
                    }
                }
                else
                {
                    Color = "FF0000";
                }
            }
            string pattern = "(?:";
            for (int i = 0; i < length; i++)
            {
                pattern = pattern + "(?<Keywords>" + Keywords[i] + ")";
                if (i < (length - 1))
                {
                    pattern = pattern + "|";
                }
            }
            pattern = pattern + ")";
            return Regex.Replace(Text, pattern, "<FONT COLOR = \"#" + Color + "\">${Keywords}</FONT>", RegexOptions.IgnoreCase);
        }

        public static string StandardizationHTML(string html, bool isClearCommentary, bool isClearScript, bool isClearStyle)
        {
            return StandardizationHTML(html, isClearCommentary, isClearScript, isClearStyle, true);
        }

        public static string StandardizationHTML(string html, bool isClearCommentary, bool isClearScript, bool isClearStyle, bool isReplenishHtmlTag)
        {
            if (html.Trim() == "")
            {
                return "";
            }
            if (isReplenishHtmlTag)
            {
                string str = html.ToUpper();
                if (!str.StartsWith("<HTML"))
                {
                    int index = str.IndexOf("<HTML");
                    if (index > 0)
                    {
                        html = html.Substring(index, str.Length - index);
                    }
                    else
                    {
                        html = "<HTML>" + html;
                    }
                }
                str = html.ToUpper();
                if (!str.EndsWith("</HTML>"))
                {
                    int length = str.LastIndexOf("</HTML>");
                    if (length > 0)
                    {
                        html = html.Substring(0, length) + "</HTML>";
                    }
                    else
                    {
                        html = html + "</HTML>";
                    }
                }
            }
            Shove.HTML.SgmlReader.SgmlReader reader = new Shove.HTML.SgmlReader.SgmlReader();
            reader.DocType = "HTML";
            reader.InputStream = new StringReader(html);
            reader.CaseFolding = CaseFolding.ToUpper;
            reader.WhitespaceHandling = WhitespaceHandling.None;
            StringWriter w = new StringWriter();
            XmlTextWriter writer2 = new XmlTextWriter(w);
            writer2.Formatting = Formatting.Indented;
            string str2 = "";
            try
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Whitespace)
                    {
                        writer2.WriteNode(reader, true);
                    }
                }
            }
            catch
            {
            }
            str2 = w.ToString();
            if (isClearCommentary && (str2 != ""))
            {
                str2 = ClearCommentary(str2);
            }
            if (isClearScript && (str2 != ""))
            {
                str2 = ClearScript(str2);
            }
            if (isClearStyle && (str2 != ""))
            {
                str2 = ClearStyle(str2);
            }
            if ((!isClearCommentary && !isClearScript) && !isClearStyle)
            {
                return str2;
            }
            return StandardizationHTML(str2, false, false, false, isReplenishHtmlTag);
        }

        private static string GetPath(string path, string parentPath)
        {
            path = path.Trim().ToLower();
            if (path.EndsWith("/"))
            {
                path = path.Substring(0, path.Length - 1);
            }
            if (!path.StartsWith("http://") && !path.StartsWith("https://"))
            {
                if (path.StartsWith("../") || path.StartsWith(@"..\"))
                {
                    path = path.Substring(3, path.Length - 3);
                }
                if (path.Length > 0)
                {
                    if (path.StartsWith("/") || path.StartsWith(@"\"))
                    {
                        path = parentPath + path;
                        return path;
                    }
                    path = parentPath + "/" + path;
                    return path;
                }
                path = parentPath;
            }
            return path;
        }

        private static string GetElementContentByPath(string html, string path)
        {
            if (html.Trim() == "")
            {
                return "";
            }
            string str = "";
            try
            {
                XPathDocument document = new XPathDocument(new StringReader(html));
                XPathNodeIterator iterator = document.CreateNavigator().Select(path);
                while (iterator.MoveNext())
                {
                    str = str + ClearReplace(iterator.Current.Value);
                }
            }
            catch
            {
                return "对该文档的解析失败，原因是该文档的格式错误或没有遵循 HTML 规范。";
            }
            return str;
        }
    }
}

