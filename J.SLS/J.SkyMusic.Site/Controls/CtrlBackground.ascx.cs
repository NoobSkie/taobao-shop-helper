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
        if (!IsPostBack)
        {
            if (IsShowMusicPlayer && AutoPlayMusic == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PlayMusic", "setTimeout(\"play();\", 1000);", true);
            }
        }
    }

    public bool IsShowMusicPlayer { get; set; }
}
