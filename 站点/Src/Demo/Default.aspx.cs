using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PageBlockFacade facade = new PageBlockFacade();

        IList<PageBlockInfo> blockListLeft = facade.GetColumnBlockList(0);
        rptLeftBlocks.DataSource = blockListLeft;
        rptLeftBlocks.DataBind();

        IList<PageBlockInfo> blockListMiddle = facade.GetColumnBlockList(1);
        rptMiddleBlocks.DataSource = blockListMiddle;
        rptMiddleBlocks.DataBind();

        IList<PageBlockInfo> blockListRight = facade.GetColumnBlockList(2);
        rptRightBlocks.DataSource = blockListRight;
        rptRightBlocks.DataBind();
    }
}
