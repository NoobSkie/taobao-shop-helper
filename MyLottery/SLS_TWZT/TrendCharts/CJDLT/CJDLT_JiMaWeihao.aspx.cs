using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CJDLT_CJDLT_JiMaWeihao : Page, IRequiresSessionState
{
    private int[] num = new int[0x23];
    private int[] sum = new int[0x23];

    private void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td align='center' vlign='middle' height='50px' bgcolor='#F0F0F0'>出现次数</td>");
        for (int i = 0; i < 0x23; i++)
        {
            output.Write("<td align='center' valign='bottom' bgcolor='#F0F0F0'>");
            output.Write(this.num[i].ToString() + "<br><img src='../../images/01[1].gif' height='" + this.sum[i].ToString() + "px' title = '" + this.num[i].ToString() + "' width= '8px'></td>");
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td align='center' vlign='middle' bgcolor='#F0F0F0'>数字序号</td>");
        output.Write("<td ><font color='#0000FF'>01</font></td>");
        output.Write("<td ><font color='#0000FF'>11</font></td>");
        output.Write("<td ><font color='#0000FF'>21</font></td>");
        output.Write("<td ><font color='#0000FF'>31</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>02</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>12</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>22</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>32</font></td>");
        output.Write("<td ><font color='#0000FF'>03</font></td>");
        output.Write("<td ><font color='#0000FF'>13</font></td>");
        output.Write("<td ><font color='#0000FF'>23</font></td>");
        output.Write("<td ><font color='#0000FF'>33</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>04</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>14</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>24</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>34</font></td>");
        output.Write("<td ><font color='#0000FF'>05</font></td>");
        output.Write("<td ><font color='#0000FF'>15</font></td>");
        output.Write("<td ><font color='#0000FF'>25</font></td>");
        output.Write("<td ><font color='#0000FF'>35</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>06</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>16</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>26</font></td>");
        output.Write("<td ><font color='#0000FF'>07</font></td>");
        output.Write("<td ><font color='#0000FF'>17</font></td>");
        output.Write("<td ><font color='#0000FF'>27</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>08</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>18</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>28</font></td>");
        output.Write("<td ><font color='#0000FF'>09</font></td>");
        output.Write("<td ><font color='#0000FF'>19</font></td>");
        output.Write("<td ><font color='#0000FF'>29</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>10</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>20</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>30</font></td>");
    }

    private void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2'align ='center' vlign='middle' bgcolor='#F0F0F0'>期数</td>");
        output.Write("<td colspan ='4'align ='center' vlign='middle' bgcolor='#F0F0F0' ><font color='#0000FF'>1 &nbsp;</font>区</td>");
        output.Write("<td colspan ='4'align ='center' vlign='middle' bgcolor='#F0F0F0'><font color='#FF0000'>2 &nbsp;</font>区</td>");
        output.Write("<td colspan ='4'align ='center' vlign='middle' bgcolor='#F0F0F0'><font color='#0000FF'>3 &nbsp;</font>区</td>");
        output.Write("<td colspan ='4'align ='center' vlign='middle' bgcolor='#F0F0F0'><font color='#FF0000'>4 &nbsp;</font>区</td>");
        output.Write("<td colspan ='4'align ='center' vlign='middle' bgcolor='#F0F0F0'><font color='#0000FF'>5 &nbsp;</font>区</td>");
        output.Write("<td colspan ='3'align ='center' vlign='middle' bgcolor='#F0F0F0'><font color='#FF0000'>6 &nbsp;</font>区</td>");
        output.Write("<td colspan ='3'align ='center' vlign='middle' bgcolor='#F0F0F0'><font color='#0000FF'>7 &nbsp;</font>区</td>");
        output.Write("<td colspan ='3'align ='center' vlign='middle' bgcolor='#F0F0F0'><font color='#FF0000'>8 &nbsp;</font>区</td>");
        output.Write("<td colspan ='3'align ='center' vlign='middle' bgcolor='#F0F0F0'><font color='#0000FF'>9 &nbsp;</font>区</td>");
        output.Write("<td colspan ='3'align ='center' vlign='middle' bgcolor='#F0F0F0'><font color='#FF0000'>0 &nbsp;</font>区</td>");
        output.Write("<tr align ='center' vlign='middle'>");
        output.Write("<td ><font color='#0000FF'>01</font></td>");
        output.Write("<td ><font color='#0000FF'>11</font></td>");
        output.Write("<td ><font color='#0000FF'>21</font></td>");
        output.Write("<td ><font color='#0000FF'>31</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>02</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>12</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>22</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>32</font></td>");
        output.Write("<td ><font color='#0000FF'>03</font></td>");
        output.Write("<td ><font color='#0000FF'>13</font></td>");
        output.Write("<td ><font color='#0000FF'>23</font></td>");
        output.Write("<td ><font color='#0000FF'>33</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>04</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>14</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>24</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>34</font></td>");
        output.Write("<td ><font color='#0000FF'>05</font></td>");
        output.Write("<td ><font color='#0000FF'>15</font></td>");
        output.Write("<td ><font color='#0000FF'>25</font></td>");
        output.Write("<td ><font color='#0000FF'>35</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>06</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>16</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>26</font></td>");
        output.Write("<td ><font color='#0000FF'>07</font></td>");
        output.Write("<td ><font color='#0000FF'>17</font></td>");
        output.Write("<td ><font color='#0000FF'>27</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>08</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>18</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>28</font></td>");
        output.Write("<td ><font color='#0000FF'>09</font></td>");
        output.Write("<td ><font color='#0000FF'>19</font></td>");
        output.Write("<td ><font color='#0000FF'>29</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>10</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>20</font></td>");
        output.Write("<td  bgcolor='#E7FEEB'><font color='#FF0000'>30</font></td>");
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridFooter));
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridHeader));
        }
    }

    private void GridViewbind()
    {
        this.GridView1.DataSource = BLL.CJDLT_JiMaWeihao_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    private void GridViewbindColor()
    {
        for (int i = 1; i < 0x24; i++)
        {
            int num2 = 0;
            for (int j = 0; j < this.GridView1.Rows.Count; j++)
            {
                if (this.GridView1.Rows[j].Cells[i].Text != "0")
                {
                    num2++;
                }
                if (this.GridView1.Rows[j].Cells[i].Text == "0")
                {
                    this.GridView1.Rows[j].Cells[i].Text = "&nbsp;";
                }
            }
            this.num[i - 1] = num2;
            int num4 = this.RadioSelete();
            this.sum[i - 1] = (50 * num2) / num4;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GridViewbind();
            this.GridViewbindColor();
            this.GridView1.Style["border-collapse"] = "";
        }
    }

    protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMaWeihao_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMaWeihao_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMaWeihao_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMaWeihao_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMaWeihao_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    private int RadioSelete()
    {
        int num = 1;
        if (this.RadioButton1.Checked)
        {
            num = 80;
        }
        if (this.RadioButton2.Checked)
        {
            num = 40;
        }
        if (this.RadioButton3.Checked)
        {
            num = 0x19;
        }
        if (this.RadioButton4.Checked)
        {
            num = 15;
        }
        if (this.RadioButton5.Checked)
        {
            num = 8;
        }
        return num;
    }
}

