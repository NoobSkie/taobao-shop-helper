using ASP;
using Shove._Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

public partial class Home_Room_TencentLogin : Page, IRequiresSessionState
{
    public string attach = "";
    public string chnid = "";
    public string chtype = "";
    public string input_charset = "";
    private string key = "";
    public string redirect_url = "";
    public string requestUrl = "";
    public string service = "";
    public string sign = "";
    public string sign_encrypt_keyid = "";
    public string sign_type = "";
    public uint tmstamp;

    private string GetMD5(string encypStr, string charset)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.GetEncoding(charset).GetBytes(encypStr);
        return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "").ToLower();
    }

    public string GetSign(string key, string input_charset, Dictionary<string, string> dict)
    {
        StringBuilder builder = new StringBuilder();
        ArrayList list = new ArrayList(dict.Keys);
        list.Sort();
        foreach (string str in list)
        {
            string strB = dict[str];
            if (((strB != null) && ("".CompareTo(strB) != 0)) && (("sign".CompareTo(str) != 0) && ("key".CompareTo(str) != 0)))
            {
                builder.Append(str + "=" + strB + "&");
            }
        }
        builder.Append("key=" + key);
        return this.GetMD5(builder.ToString(), input_charset).ToLower();
    }

    public uint GetTmstamp()
    {
        TimeSpan span = (TimeSpan)(DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(0x7b2, 1, 1)));
        return Convert.ToUInt32(span.TotalSeconds);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SettingParams();
    }

    public void SettingParams()
    {
        SystemOptions options = new SystemOptions();
        this.requestUrl = options["MemberSharing_Tencent_Gateway"].ToString("").Trim();
        this.sign_type = "md5";
        this.key = options["MemberSharing_Tencent_MD5"].ToString("").Trim();
        this.sign_encrypt_keyid = "0";
        this.input_charset = "GBK";
        this.service = "login";
        this.chnid = options["MemberSharing_Tencent_UserNumber"].ToString("").Trim();
        this.chtype = "0";
        this.redirect_url = Utility.GetUrl() + "/Home/Room/TencentReceive.aspx";
        this.attach = this.redirect_url;
        this.tmstamp = this.GetTmstamp();
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("sign_type", this.sign_type);
        dict.Add("sign_encrypt_keyid", this.sign_encrypt_keyid);
        dict.Add("input_charset", this.input_charset);
        dict.Add("service", this.service);
        dict.Add("chnid", this.chnid);
        dict.Add("chtype", this.chtype);
        dict.Add("redirect_url", this.redirect_url);
        dict.Add("attach", this.attach);
        dict.Add("tmstamp", this.tmstamp.ToString());
        this.sign = this.GetSign(this.key, this.input_charset, dict);
    }
}

