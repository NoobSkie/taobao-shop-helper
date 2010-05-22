using ASP;
using Shove;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CJDLT_CJDLT_JimaLengRe : Page, IRequiresSessionState
{
    private int[] a = new int[0x23];
    private int[] b = new int[0x23];
    private int[] num = new int[0x23];
    private int[] sum = new int[0x23];

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        for (int i = 1; i < 0x24; i++)
        {
            int index = i - 1;
            this.num[index] = _Convert.StrToInt(this.GridView1.Rows[0].Cells[i].Text, 0);
            int num3 = this.RadioSelete();
            this.sum[index] = (this.num[index] * 140) / num3;
        }
        output.Write("<td bgcolor='#F7F7F7' height='140px' width='60px'><br><font color='#5A5A5A'>75%</font><br><br><font color='#5A5A5A'>50%</font><br><br><font color='#5A5A5A'>25%</font><br><br></td>");
        for (int j = 0; j < 0x23; j++)
        {
            output.Write("<td align='center' valign='bottom' background='../../Images/line[1].gif'>");
            output.Write("<img src='../../Images/01[1].gif' height='" + this.sum[j].ToString() + "'' title='" + this.num[j].ToString() + "' width='8px'></td>");
        }
        output.Write("<tr align='center'>");
        output.Write("<td bgcolor='#F7F7F7'>号码</td>");
        for (int k = 1; k < 10; k++)
        {
            output.Write("<td align='center' >");
            output.Write(0 + k.ToString() + "</td>");
        }
        for (int m = 10; m < 0x24; m++)
        {
            output.Write("<td align='center'>");
            output.Write(m.ToString() + "</td>");
        }
    }

    private void DrawGridRow(HtmlTextWriter output, Control ctl)
    {
        int num = this.RadioSelete();
        int[] numArray = new int[0x23];
        for (int i = 0; i < 0x23; i++)
        {
            numArray[i] = (this.a[i] * 140) / num;
        }
        output.Write("<td bgcolor='#F7F7F7' width='60px'> 出现次数</td>");
        for (int j = 0; j < 0x23; j++)
        {
            output.Write("<td width='19px' bgcolor='#FFFFFF'>");
            output.Write(this.a[j].ToString() + "</td>");
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td bgcolor='#F7F7F7' height='140px' width='60px'><br><font color='#5A5A5A'>75%</font><br><br><font color='#5A5A5A'>50%</font><br><br><font color='#5A5A5A'>25%</font><br><br></td>");
        for (int k = 0; k < 0x23; k++)
        {
            output.Write("<td align='center' valign='bottom' background='../../Images/line[1].gif' width='19px' bgcolor='#FFFFFF'>");
            output.Write("<Img src='../../Images/01[1].gif ' height='" + numArray[k].ToString() + "' width='8' title='" + this.a[k].ToString() + "'></td>");
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td bgcolor='F7F7F7' width='60px' align='center'> 号码</td>");
        for (int m = 0; m < 0x23; m++)
        {
            output.Write("<td bgcolor='#FFFFFF'>");
            output.Write(this.b[m].ToString() + "</td>");
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridFooter));
        }
    }

    protected void GridView2_RowCreate(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridRow));
        }
    }

    protected void GridView2Bind()
    {
        DataTable table = new DataTable();
        table = BLL.CJDLT_JiMa_lengrejj_SeleteByNum(30);
        DataTable table2 = new DataTable();
        table2.Columns.Add("11", typeof(string));
        DataRow row = table2.NewRow();
        row[0] = "aa";
        table2.Rows.Add(row);
        this.GridView2.DataSource = table2;
        this.GridView2.DataBind();
        for (int i = 0; i < 0x23; i++)
        {
            this.a[i] = _Convert.StrToInt(table.Rows[i]["id"].ToString(), 0);
            this.b[i] = _Convert.StrToInt(table.Rows[i]["num"].ToString(), 0);
        }
    }

    protected void GridViewBind()
    {
        DataTable table = new DataTable();
        table = BLL.CJDLT_JiMa_lengre_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GridViewBind();
            this.GridView2Bind();
            this.GridView2.Style["border-collapse"] = "";
            this.GridView1.Style["border-collapse"] = "";
        }
    }

    protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMa_lengre_SeleteByNum(100);
        DataTable table2 = BLL.CJDLT_JiMa_lengrejj_SeleteByNum(100);
        DataTable table3 = new DataTable();
        table3.Columns.Add("aa", typeof(string));
        DataRow row = table3.NewRow();
        row[0] = "11";
        table3.Rows.Add(row);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridView2.DataSource = table3;
        this.GridView2.DataBind();
        for (int i = 0; i < 0x23; i++)
        {
            this.a[i] = _Convert.StrToInt(table2.Rows[i]["id"].ToString(), 0);
            this.b[i] = _Convert.StrToInt(table2.Rows[i]["num"].ToString(), 0);
        }
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMa_lengre_SeleteByNum(50);
        DataTable table2 = new DataTable();
        table2 = BLL.CJDLT_JiMa_lengrejj_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        DataTable table3 = new DataTable();
        table3.Columns.Add("num", typeof(string));
        DataRow row = table3.NewRow();
        row[0] = "12";
        table3.Rows.Add(row);
        this.GridView2.DataSource = table3;
        this.GridView2.DataBind();
        for (int i = 0; i < 0x23; i++)
        {
            this.a[i] = _Convert.StrToInt(table2.Rows[i]["id"].ToString(), 0);
            this.b[i] = _Convert.StrToInt(table2.Rows[i]["num"].ToString(), 0);
        }
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMa_lengre_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        DataTable table2 = new DataTable();
        table2 = BLL.CJDLT_JiMa_lengrejj_SeleteByNum(30);
        DataTable table3 = new DataTable();
        table3.Columns.Add("num", typeof(string));
        DataRow row = table3.NewRow();
        row[0] = "12";
        table3.Rows.Add(row);
        this.GridView2.DataSource = table3;
        this.GridView2.DataBind();
        for (int i = 0; i < 0x23; i++)
        {
            this.a[i] = _Convert.StrToInt(table2.Rows[i]["id"].ToString(), 0);
            this.b[i] = _Convert.StrToInt(table2.Rows[i]["num"].ToString(), 0);
        }
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMa_lengre_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        DataTable table2 = new DataTable();
        table2 = BLL.CJDLT_JiMa_lengrejj_SeleteByNum(20);
        DataTable table3 = new DataTable();
        table3.Columns.Add("num", typeof(string));
        DataRow row = table3.NewRow();
        row[0] = "12";
        table3.Rows.Add(row);
        this.GridView2.DataSource = table3;
        this.GridView2.DataBind();
        for (int i = 0; i < 0x23; i++)
        {
            this.a[i] = _Convert.StrToInt(table2.Rows[i]["id"].ToString(), 0);
            this.b[i] = _Convert.StrToInt(table2.Rows[i]["num"].ToString(), 0);
        }
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_JiMa_lengre_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        DataTable table2 = new DataTable();
        table2 = BLL.CJDLT_JiMa_lengrejj_SeleteByNum(10);
        DataTable table3 = new DataTable();
        table3.Columns.Add("num", typeof(string));
        DataRow row = table3.NewRow();
        row[0] = "12";
        table3.Rows.Add(row);
        this.GridView2.DataSource = table3;
        this.GridView2.DataBind();
        for (int i = 0; i < 0x23; i++)
        {
            this.a[i] = _Convert.StrToInt(table2.Rows[i]["id"].ToString(), 0);
            this.b[i] = _Convert.StrToInt(table2.Rows[i]["num"].ToString(), 0);
        }
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

