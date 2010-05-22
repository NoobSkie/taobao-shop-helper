using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Data;
using System.Web;

public class CardPasswordAgentUsers
{
    public string Company = "";
    public int ID = -1;
    public string Name = "";
    public string Password = "";
    public short State = 0;
    public string Url = "";

    public void Clone(CardPasswordAgentUsers cardPasswordUsers)
    {
        cardPasswordUsers.ID = this.ID;
        cardPasswordUsers.Company = this.Company;
        cardPasswordUsers.Password = this.Password;
        cardPasswordUsers.Name = this.Name;
        cardPasswordUsers.State = this.State;
        cardPasswordUsers.Url = this.Url;
    }

    public int EditByID(ref string ReturnDescription)
    {
        if (this.ID < 0)
        {
            throw new Exception("CardPassword 尚未初始化到具体的数据实例上，请先使用 GetInformation 等获取数据信息");
        }
        DataTable table = new Tables.T_CardPasswordAgents().Open("", "[ID] = " + this.ID, "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            ReturnDescription = "数据库读写错误";
            return -1;
        }
        new Tables.T_CardPasswordAgents { Company = { Value = this.Company }, Password = { Value = this.Password }, Name = { Value = this.Name }, State = { Value = this.State }, Url = { Value = this.Url } }.Update("[ID] = " + this.ID.ToString());
        return 0;
    }

    public static CardPasswordAgentUsers GetCurrentUser()
    {
        // This item is obfuscated and can not be translated.
        if (HttpContext.Current.Session.SessionID == null)
        {
            return null;
        }
        string str = HttpContext.Current.Session.SessionID.ToLower() + "_CardPasswordAgentUsers";
        HttpCookie cookie = HttpContext.Current.Request.Cookies[str];
        if ((cookie == null) || string.IsNullOrEmpty(cookie.Value))
        {
            return null;
        }
        string input = cookie.Value;
        try
        {
            input = Encrypt.UnEncryptString(PF.GetCallCert(), Encrypt.Decrypt3DES(PF.GetCallCert(), input, PF.DesKey));
        }
        catch
        {
            input = "";
        }
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }
        int num = _Convert.StrToInt(input, -1);
        if (num < 1)
        {
            return null;
        }
        CardPasswordAgentUsers users = new CardPasswordAgentUsers
        {
            ID = num
        };
        string returnDescription = "";
        if (users.GetInformationByID(ref returnDescription) < 0)
        {
            return null;
        }
        return users;
    }

    public int GetInformationByID(ref string ReturnDescription)
    {
        if (this.ID < 0)
        {
            throw new Exception("CardPassword 尚未初始化到具体的数据实例上，请先使用 GetInformation 等获取数据信息");
        }
        DataTable table = new Tables.T_CardPasswordAgents().Open("", "[ID] = " + this.ID, "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            ReturnDescription = "数据库读写错误";
            return -1;
        }
        this.Name = table.Rows[0]["Name"].ToString();
        this.Password = table.Rows[0]["Password"].ToString();
        this.Company = table.Rows[0]["Company"].ToString();
        this.Url = table.Rows[0]["Url"].ToString();
        this.State = _Convert.StrToShort(table.Rows[0]["State"].ToString(), 0);
        return 0;
    }

    public int GetInformationByName(ref string ReturnDescription)
    {
        if (this.Name == "")
        {
            throw new Exception("CardPassword 尚未初始化到具体的数据实例上，请先使用 GetInformation 等获取数据信息");
        }
        DataTable table = new Tables.T_CardPasswordAgents().Open("", "[Name] = " + Utility.FilteSqlInfusion(this.Name), "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            ReturnDescription = "数据库读写错误";
            return -1;
        }
        this.ID = _Convert.StrToInt(table.Rows[0]["ID"].ToString(), 0);
        this.Password = table.Rows[0]["Password"].ToString();
        this.Company = table.Rows[0]["Company"].ToString();
        this.Url = table.Rows[0]["Url"].ToString();
        this.State = _Convert.StrToShort(table.Rows[0]["State"].ToString(), 0);
        return 0;
    }

    public int Login(ref string ReturnDescription)
    {
        DataTable table = new Tables.T_CardPasswordAgents().Open("", "ID=" + this.ID, "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            ReturnDescription = "用户不存在";
            return -1;
        }
        if (table.Rows[0]["Password"].ToString() != PF.EncryptPassword(this.Password))
        {
            ReturnDescription = "密码错误";
            return -2;
        }
        if (table.Rows[0]["State"].ToString() != "1")
        {
            ReturnDescription = "代理商帐号已经过期";
            return -2;
        }
        this.Name = table.Rows[0]["Name"].ToString();
        this.Password = table.Rows[0]["Password"].ToString();
        this.Company = table.Rows[0]["Company"].ToString();
        this.Url = table.Rows[0]["Url"].ToString();
        this.State = _Convert.StrToShort(table.Rows[0]["State"].ToString(), 0);
        this.SaveUserIDToCookie();
        return 0;
    }

    public int Logout(ref string ReturnDescription)
    {
        ReturnDescription = "";
        this.RemoveUserIDFromCookie();
        return 0;
    }

    private void RemoveUserIDFromCookie()
    {
        // This item is obfuscated and can not be translated.
        if (HttpContext.Current.Session.SessionID == null)
        {
            return;
        }
        HttpCookie cookie = new HttpCookie(HttpContext.Current.Session.SessionID.ToLower() + "_CardPasswordAgentUsers")
        {
            Value = "",
            Expires = DateTime.Now.AddYears(-20)
        };
        try
        {
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        catch
        {
        }
    }

    private void SaveUserIDToCookie()
    {
        // This item is obfuscated and can not be translated.
        if (HttpContext.Current.Session.SessionID != null)
        {
            return;
        }
        HttpCookie cookie = new HttpCookie("".ToLower() + "_CardPasswordAgentUsers", Encrypt.Encrypt3DES(PF.GetCallCert(), Encrypt.EncryptString(PF.GetCallCert(), this.ID.ToString()), PF.DesKey));
        try
        {
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        catch
        {
        }
    }
}

