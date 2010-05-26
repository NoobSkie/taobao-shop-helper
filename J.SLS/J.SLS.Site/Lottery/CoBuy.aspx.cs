using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Shove;
using Shove._Web;
using System.Data;
using Shove.Database;
using Shove.Web.UI;

public partial class Lottery_CoBuy : BasePage
{
    protected StringBuilder script = new StringBuilder();
    private void BindDataForType()
    {
    }

    private void BindPersonages()
    {
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindDataForType();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindDataForType();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindDataForType();
    }

    protected override void OnInit(EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.HidIsuseID.Value = Utility.GetRequest("IsuseID");
            this.HidLotteryID.Value = Utility.GetRequest("LotteryID");
            this.HidNumber.Value = Utility.GetRequest("Number");
            this.BindPersonages();
            this.script.AppendLine("__doPostBack('btnSearch', '');");
        }
        else
        {
            this.script.AppendLine("document.getElementById(\"g\").setAttribute(\"border\", \"1\");").AppendLine("document.getElementById(\"g\").removeAttribute(\"style\");").AppendLine("document.getElementById(\"g\").setAttribute(\"width\", \"100%\");");
        }
    }
}
