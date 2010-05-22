namespace Shove._Web
{
    using Shove._Security;
    using System;
    using System.Text.RegularExpressions;
    using System.Web;

    public class Utility
    {
        public static string BuildUrlParamtersAndSignature(string[] Paramters, string Key, string SignatureParamteName)
        {
            string[] strArray = OrderStringArray(Paramters, '=');
            string str = "";
            string str2 = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (i > 0)
                {
                    str2 = str2 + "&";
                }
                str = str + strArray[i].Split(new char[] { '=' })[0] + HttpUtility.UrlDecode(strArray[i].Split(new char[] { '=' })[1]);
                str2 = str2 + strArray[i].Split(new char[] { '=' })[0] + "=" + strArray[i].Split(new char[] { '=' })[1];
            }
            if (str2 != "")
            {
                str2 = str2 + "&";
            }
            return (str2 + SignatureParamteName + "=" + Encrypt.MD5(Key + str));
        }

        public static string FilteSqlInfusion(string input)
        {
            if ((input == null) || (input.Trim() == ""))
            {
                return "";
            }
            Random random = new Random(DateTime.Now.Millisecond);
            input = input.Replace("'", "");
            Regex regex = new Regex("(update)|(drop)|(delete)|(exec)|(create)|(execute)|(where)|(truncate)|(insert)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < 10; i++)
            {
                input = regex.Replace(input, random.Next(0, 10).ToString());
            }
            regex = new Regex(@"char[\s]*?[(][^)]*?[)]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int j = 0; j < 10; j++)
            {
                input = regex.Replace(input, random.Next(0, 10).ToString());
            }
            return input;
        }

        public static string GetPageFileName()
        {
            return GetPageFileName(HttpContext.Current);
        }

        public static string GetPageFileName(HttpContext context)
        {
            return context.Request.ServerVariables["PATH_INFO"].Substring(context.Request.ServerVariables["PATH_INFO"].LastIndexOf("/") + 1);
        }

        public static string GetRequest(string Key)
        {
            return GetRequest(HttpContext.Current, Key);
        }

        public static string GetRequest(HttpContext context, string Key)
        {
            string str = context.Request[Key];
            if (str == null)
            {
                return "";
            }
            return FilteSqlInfusion(HttpUtility.UrlDecode(str).Trim());
        }

        public static string[] GetRequestKeyAndSort()
        {
            HttpContext current = HttpContext.Current;
            if (current.Request.QueryString.Count < 1)
            {
                return null;
            }
            string[] array = new string[current.Request.QueryString.Count];
            HttpContext.Current.Request.QueryString.AllKeys.CopyTo(array, 0);
            return OrderStringArray(array, ' ');
        }

        public static string GetUrl()
        {
            return GetUrl(HttpContext.Current);
        }

        public static string GetUrl(HttpContext context)
        {
            string str = context.Request.Url.AbsoluteUri.Replace(context.Request.Url.PathAndQuery, "") + context.Request.ApplicationPath;
            if (str.EndsWith("/"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        public static string[] GetUrlParamtersAndVasidSignature(string Key, string SignatureParamteName, ref string ErrorDescription)
        {
            ErrorDescription = "";
            string[] requestKeyAndSort = GetRequestKeyAndSort();
            if (requestKeyAndSort == null)
            {
                ErrorDescription = "没有找到参数";
                return null;
            }
            string request = GetRequest(SignatureParamteName);
            if (string.IsNullOrEmpty(request))
            {
                ErrorDescription = "没有提供签名";
                return null;
            }
            string sourceString = Key;
            string[] strArray2 = new string[requestKeyAndSort.Length - 1];
            int num = 0;
            foreach (string str3 in requestKeyAndSort)
            {
                if (!(str3.Trim().ToLower() == SignatureParamteName.ToLower()))
                {
                    string str = GetRequest(str3);
                    sourceString = sourceString + str3 + str;
                    strArray2[num++] = str3 + "=" + HttpUtility.UrlEncode(str);
                }
            }
            if (string.Compare(Encrypt.MD5(sourceString), request, StringComparison.OrdinalIgnoreCase) != 0)
            {
                ErrorDescription = "签名无效";
                return null;
            }
            return strArray2;
        }

        public static string GetUrlWithoutHttp()
        {
            return GetUrlWithoutHttp(HttpContext.Current);
        }

        public static string GetUrlWithoutHttp(HttpContext context)
        {
            string url = GetUrl(context);
            if (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                url = url.Substring(7, url.Length - 7);
            }
            if (url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = url.Substring(8, url.Length - 8);
            }
            return url;
        }

        private static string[] OrderStringArray(string[] arr, char separatorChar)
        {
            if ((arr == null) || (arr.Length < 2))
            {
                return arr;
            }
            string[] array = new string[arr.Length];
            arr.CopyTo(array, 0);
            for (int i = 0; i < array.Length; i++)
            {
                bool flag = false;
                for (int j = array.Length - 2; j >= i; j--)
                {
                    if (separatorChar == ' ')
                    {
                        if (string.CompareOrdinal(array[j + 1], array[j]) < 0)
                        {
                            flag = true;
                        }
                    }
                    else if (string.CompareOrdinal(array[j + 1].Split(new char[] { separatorChar })[0], array[j].Split(new char[] { separatorChar })[0]) < 0)
                    {
                        flag = true;
                    }
                    if (flag)
                    {
                        string str = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = str;
                    }
                }
                if (!flag)
                {
                    return array;
                }
            }
            return array;
        }
    }
}

