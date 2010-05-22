using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Site : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.labName.Text = base._Site.Name;
        this.labLevel.Text = SiteLevels.GetSiteLevelName(base._Site.Level);
        this.imgON.ImageUrl = base._Site.ON ? "../Images/Admin/Run.gif" : "../Images/Admin/Stop.gif";
        this.imgON.ToolTip = base._Site.ON ? "正在运行" : "已停止";
        this.tbCompany.Text = base._Site.Company;
        this.tbAddress.Text = base._Site.Address;
        this.tbPostCode.Text = base._Site.PostCode;
        this.tbResponsiblePerson.Text = base._Site.ResponsiblePerson;
        this.tbContactPerson.Text = base._Site.ContactPerson;
        this.tbTelephone.Text = base._Site.Telephone;
        this.tbFax.Text = base._Site.Fax;
        this.tbMobile.Text = base._Site.Mobile;
        this.tbEmail.Text = base._Site.Email;
        this.tbQQ.Text = base._Site.QQ;
        this.tbServiceTelephone.Text = base._Site.ServiceTelephone;
        this.tbICPCert.Text = base._Site.ICPCert;
        this.tbBonusScale.Text = base._Site.BonusScale.ToString();
        this.tbMaxSubSites.Text = base._Site.MaxSubSites.ToString();
        this.tbUrls.Text = base._Site.Urls;
        this.BindDataForLottery();
        this.BindDataForLotteryQuickBuy();
        if (base._Site.Level == 1)
        {
            this.tbCompany.Enabled = true;
            this.tbResponsiblePerson.Enabled = true;
        }
    }

    private void BindDataForLottery()
    {
        DataTable table = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            this.g.DataSource = table;
            this.g.DataBind();
            this.g.Columns[2].Visible = false;
            for (int i = 0; i < this.g.Rows.Count; i++)
            {
                CheckBox box = (CheckBox)this.g.Rows[i].Cells[1].FindControl("cbisUsed");
                if (base._Site.UseLotteryListRestrictions == "")
                {
                    box.Checked = false;
                }
                else
                {
                    int num2 = _Convert.StrToInt(this.g.Rows[i].Cells[2].Text, -1);
                    if (num2 >= 1)
                    {
                        box.Checked = ("," + base._Site.UseLotteryList + ",").IndexOf("," + num2.ToString() + ",") >= 0;
                    }
                }
            }
        }
    }

    private void BindDataForLotteryQuickBuy()
    {
        DataTable table = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            this.g2.DataSource = table;
            this.g2.DataBind();
            this.g2.Columns[2].Visible = false;
            for (int i = 0; i < this.g2.Rows.Count; i++)
            {
                CheckBox box = (CheckBox)this.g2.Rows[i].Cells[1].FindControl("cbisUsed");
                if (base._Site.UseLotteryListRestrictions == "")
                {
                    box.Checked = false;
                }
                else
                {
                    int num2 = _Convert.StrToInt(this.g2.Rows[i].Cells[2].Text, -1);
                    if (num2 >= 1)
                    {
                        box.Checked = ("," + base._Site.UseLotteryListQuickBuy + ",").IndexOf("," + num2.ToString() + ",") >= 0;
                    }
                }
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.tbCompany.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入公司名称。");
        }
        else if (this.tbAddress.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入公司地址。");
        }
        else if (this.tbPostCode.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入邮政编码。");
        }
        else if (this.tbResponsiblePerson.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入负责人姓名。");
        }
        else if (this.tbContactPerson.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入联系人姓名。");
        }
        else if (this.tbTelephone.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入电话号码。");
        }
        else if (this.tbMobile.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入手机号码。");
        }
        else if (this.tbEmail.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入有效的 Email。");
        }
        else if (this.tbServiceTelephone.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入技术服务电话号码。");
        }
        else if (this.tbUrls.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入站点域名列表。");
        }
        else
        {
            Sites site = new Sites();
            base._Site.Clone(site);
            base._Site.Company = this.tbCompany.Text.Trim();
            base._Site.ResponsiblePerson = this.tbResponsiblePerson.Text.Trim();
            base._Site.Address = this.tbAddress.Text.Trim();
            base._Site.PostCode = _Convert.ToDBC(this.tbPostCode.Text.Trim()).Trim();
            base._Site.ContactPerson = this.tbContactPerson.Text.Trim();
            base._Site.Telephone = _Convert.ToDBC(this.tbTelephone.Text.Trim()).Trim();
            base._Site.Fax = _Convert.ToDBC(this.tbFax.Text.Trim()).Trim();
            base._Site.Mobile = _Convert.ToDBC(this.tbMobile.Text.Trim()).Trim();
            base._Site.Email = this.tbEmail.Text.Trim();
            base._Site.QQ = _Convert.ToDBC(this.tbQQ.Text.Trim()).Trim();
            base._Site.ServiceTelephone = _Convert.ToDBC(this.tbServiceTelephone.Text.Trim()).Trim();
            base._Site.ICPCert = this.tbICPCert.Text.Trim();
            base._Site.Urls = _Convert.ToDBC(this.tbUrls.Text).Trim();
            base._Site.UseLotteryList = "";
            for (int i = 0; i < this.g.Rows.Count; i++)
            {
                if (((CheckBox)this.g.Rows[i].Cells[1].FindControl("cbisUsed")).Checked)
                {
                    string text = this.g.Rows[i].Cells[2].Text;
                    base._Site.UseLotteryList = base._Site.UseLotteryList + ((base._Site.UseLotteryList == "") ? "" : ",") + text;
                }
            }
            base._Site.UseLotteryListQuickBuy = "";
            for (int j = 0; j < this.g2.Rows.Count; j++)
            {
                if (((CheckBox)this.g2.Rows[j].Cells[1].FindControl("cbisUsed")).Checked)
                {
                    string str2 = this.g2.Rows[j].Cells[2].Text;
                    base._Site.UseLotteryListQuickBuy = base._Site.UseLotteryListQuickBuy + ((base._Site.UseLotteryListQuickBuy == "") ? "" : ",") + str2;
                }
            }
            string returnDescription = "";
            if (base._Site.EditByID(ref returnDescription) < 0)
            {
                site.Clone(base._Site);
                JavaScript.Alert(this.Page, returnDescription);
            }
            else
            {
                Shove._Web.Cache.ClearCache(base._Site.ID.ToString() + "Lotteries");
                Shove._Web.Cache.ClearCache("Site_UseLotteryList" + base._Site.ID);
                JavaScript.Alert(this.Page, "站点资料已经保存成功。");
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Options", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.btnOK.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Options" }));
        }
    }


}

