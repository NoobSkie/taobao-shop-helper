using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shove.Web.UI;

public partial class Users_ValidateCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //All = 0,
        //OnlyNumeric = 1,
        //OnlyLetterUpper = 2,
        //OnlyLetterLower = 3,
        //OnlyLetter = 4,
        string t = Request["Type"] ?? "0";
        int tCode = 0;
        int.TryParse(t, out tCode);
        ShoveCheckCode1.Charset = (ShoveCheckCode.CharSet)tCode;
    }
}
