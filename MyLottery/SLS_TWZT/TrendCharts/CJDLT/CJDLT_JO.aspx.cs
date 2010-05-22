using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CJDLT_CJDLT_JO : Page, IRequiresSessionState
{

    protected void ColorBind()
    {
        for (int i = 3; i < 8; i++)
        {
            for (int j = 0; j < this.GridView1.Rows.Count; j++)
            {
                if (this.GridView1.Rows[j].Cells[i].Text == "奇")
                {
                    this.GridView1.Rows[j].Cells[i].ForeColor = Color.FromArgb(0xff, 0, 0);
                }
                if (this.GridView1.Rows[j].Cells[i].Text == "偶")
                {
                    this.GridView1.Rows[j].Cells[i].ForeColor = Color.FromArgb(0, 0, 0xff);
                }
            }
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2' align='center' valign='middle'>期数</td>");
        output.Write("<td colspan='2' align='center' valign='middle'>开奖号码</td>");
        output.Write("<td colspan='5' align='center' valign='middle'>前区号码区</td>");
        output.Write("<td rowspan='2' align='center' valign='middle'>奇数个数</td>");
        output.Write("<td rowspan='2' align='center' valign='middle'>偶数个数</td>");
        output.Write("<td rowspan='2' align='center' valign='middle'>奇偶比</td>");
        output.Write("<td rowspan='2' align='center' valign='middle'>奇偶差值</td>");
        output.Write("<td colspan='2' align='center' valign='middle'>后区奇偶</td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td>前区</td>");
        output.Write("<td>后区</td>");
        output.Write("<td><font color='#FF0000'>第一位</font></td>");
        output.Write("<td><font color='#FF0000'>第二位</font></td>");
        output.Write("<td><font color='#FF0000'>第三位</font></td>");
        output.Write("<td><font color='#FF0000'>第四位</font></td>");
        output.Write("<td><font color='#FF0000'>第五位</font></td>");
        output.Write("<td>奇</td>");
        output.Write("<td>偶</td>");
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridHeader));
        }
    }

    protected void GridViewBind()
    {
        DataTable table = new DataTable();
        table = BLL.CJDLT_JO_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GridViewBind();
            this.ColorBind();
            this.GridView1.Style["border-collapse"] = "";
        }
    }

    protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JO_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JO_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JO_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JO_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JO_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

