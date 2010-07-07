using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_CtrlBackground : BaseControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (IsShowMusicPlayer && AutoPlayMusic == "1")
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "PlayMusic", "<script type=\"text/javascript\" defer>setTimeout(\"play();\", 1000);</script>", false);
        //    }
        //}
    }

    public string AutoPlayScript
    {
        get
        {
            if (IsShowMusicPlayer && AutoPlayMusic == "1")
            {
                return "setTimeout(\"play();\", 1000);";
            }
            return "";
        }
    }

    public bool IsShowMusicPlayer { get; set; }
}
