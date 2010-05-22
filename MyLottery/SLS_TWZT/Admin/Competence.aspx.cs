using ASP;
using DAL;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Competence : AdminPageBase, IRequiresSessionState
{

    private CheckBox[] cbCompetence = new CheckBox[0x13];

  
    private CheckBox[] cbGroup = new CheckBox[10];


    private void BindCheckBox()
    {
        for (int i = 0; i < 10; i++)
        {
            int num2 = i + 1;
            this.cbGroup[i] = (CheckBox)this.FindControl("cbGroup" + num2.ToString());
        }
        for (int j = 0; j < 0x13; j++)
        {
            int num4 = j + 1;
            this.cbCompetence[j] = (CheckBox)this.FindControl("cbCompetence" + num4.ToString());
        }
    }

    private void BindData()
    {
        DataTable table = Functions.F_GetManagers(base._Site.ID);
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_Competence");
        }
        else
        {
            this.lbUser.DataSource = table;
            this.lbUser.DataTextField = "Name";
            this.lbUser.DataValueField = "ID";
            this.lbUser.DataBind();
            if (this.lbUser.Items.Count > 0)
            {
                this.lbUser.SelectedIndex = 0;
                this.lbUser_SelectedIndexChanged(this.lbUser, new EventArgs());
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.tbUserName.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "用户名不能为空！");
        }
        else if (this.lbUser.Items.FindByText(this.tbUserName.Text.Trim()) != null)
        {
            JavaScript.Alert(this.Page, "用户名已经存在！");
        }
        else
        {
            Users users = new Users(base._Site.ID)[base._Site.ID, this.tbUserName.Text.Trim()];
            if (users == null)
            {
                JavaScript.Alert(this.Page, "用户名不存在！");
            }
            else
            {
                this.lbUser.Items.Add(new ListItem(users.Name, users.ID.ToString()));
                this.lbUser.SelectedIndex = this.lbUser.Items.Count - 1;
                this.lbUser_SelectedIndexChanged(this.lbUser, new EventArgs());
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.lbUser.Items.Count >= 1)
        {
            this.BindCheckBox();
            long userID = long.Parse(this.lbUser.SelectedValue);
            string groupsList = "";
            for (int i = 0; i < 10; i++)
            {
                if (this.cbGroup[i].Checked)
                {
                    groupsList = groupsList + "[" + ((i + 1)).ToString() + "]";
                }
            }
            string competencesList = "";
            for (int j = 0; j < 0x13; j++)
            {
                if (this.cbCompetence[j].Checked)
                {
                    competencesList = competencesList + "[" + ((j + 1)).ToString() + "]";
                }
            }
            int returnValue = -1;
            string returnDescription = "";
            if (Procedures.P_SetUserCompetences(base._Site.ID, userID, competencesList, groupsList, ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_Competence");
            }
            else if (returnValue < 0)
            {
                PF.GoError(1, returnDescription, "Admin_Competence");
            }
            else
            {
                JavaScript.Alert(this.Page, "权限已经保存。");
            }
        }
    }

    protected void lbUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.lbUser.Items.Count >= 1)
        {
            this.BindCheckBox();
            this.SetCheckBoxChecked(false);
            DataTable table = new Tables.T_UserInGroups().Open("distinct GroupID", "UserID=" + Utility.FilteSqlInfusion(this.lbUser.SelectedValue), "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_Competence");
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {
                    this.cbGroup[int.Parse(row["GroupID"].ToString()) - 1].Checked = true;
                }
                table = new Tables.T_CompetencesOfUsers().Open("distinct CompetenceID", "UserID=" + Utility.FilteSqlInfusion(this.lbUser.SelectedValue), "");
                if (table == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", "Admin_Competence");
                }
                else
                {
                    foreach (DataRow row2 in table.Rows)
                    {
                        this.cbCompetence[int.Parse(row2["CompetenceID"].ToString()) - 1].Checked = true;
                    }
                    if (base._Site.AdministratorID == long.Parse(this.lbUser.SelectedValue))
                    {
                        this.btnSave.Enabled = false;
                        this.SetCheckBoxEnabled(false);
                    }
                    else
                    {
                        this.btnSave.Enabled = true;
                        this.SetCheckBoxEnabled(true);
                    }
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Competence", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            if (base._Site.Level != 1)
            {
                this.cbGroup3.Enabled = false;
                this.cbGroup8.Enabled = false;
                this.cbCompetence6.Enabled = false;
                this.cbCompetence7.Enabled = false;
                this.cbCompetence11.Enabled = false;
                this.cbCompetence12.Enabled = false;
                this.cbCompetence13.Enabled = false;
                this.cbCompetence17.Enabled = false;
            }
            this.btnSave.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Competence" }));
            this.btnAdd.Visible = this.btnSave.Visible;
        }
    }

    private void SetCheckBoxChecked(bool Value)
    {
        if ((this.cbGroup[0] == null) || (this.cbCompetence[0] == null))
        {
            this.BindCheckBox();
        }
        for (int i = 0; i < 10; i++)
        {
            this.cbGroup[i].Checked = Value;
        }
        for (int j = 0; j < 0x13; j++)
        {
            this.cbCompetence[j].Checked = Value;
        }
    }

    private void SetCheckBoxEnabled(bool Value)
    {
        if ((this.cbGroup[0] == null) || (this.cbCompetence[0] == null))
        {
            this.BindCheckBox();
        }
        for (int i = 0; i < 10; i++)
        {
            this.cbGroup[i].Enabled = Value;
        }
        for (int j = 0; j < 0x13; j++)
        {
            this.cbCompetence[j].Enabled = Value;
        }
        if (Value && (base._Site.Level != 1))
        {
            this.cbGroup3.Enabled = false;
            this.cbGroup8.Enabled = false;
            this.cbCompetence6.Enabled = false;
            this.cbCompetence7.Enabled = false;
            this.cbCompetence11.Enabled = false;
            this.cbCompetence12.Enabled = false;
            this.cbCompetence13.Enabled = false;
            this.cbCompetence17.Enabled = false;
        }
    }


}

