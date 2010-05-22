using Shove._Security;
using System;
using System.Web;
using System.Web.UI;

public class SynchronizeSessionID
{
    private Page page;

    public SynchronizeSessionID(Page _page)
    {
        if (_page == null)
        {
            throw new Exception("SynchronizeSessionID 类需要一个实例化的 System.Web.UI.Page 类型参数。");
        }
        this.page = _page;
    }

    public string GenSign(params string[] inputs)
    {
        string str = "";
        foreach (string str2 in inputs)
        {
            str = str + str2;
        }
        return Encrypt.MD5(str + PF.CenterMD5Key);
    }

    public bool ValidSign(HttpRequest request)
    {
        string str = "";
        string strA = "";
        foreach (string str3 in request.QueryString.AllKeys)
        {
            if (string.Compare(str3, "Sign", StringComparison.OrdinalIgnoreCase) == 0)
            {
                strA = HttpUtility.UrlDecode(request[str3]);
            }
            else
            {
                str = str + HttpUtility.UrlDecode(request[str3]);
            }
        }
        return (string.Compare(strA, Encrypt.MD5(str + PF.CenterMD5Key), StringComparison.OrdinalIgnoreCase) == 0);
    }
}

