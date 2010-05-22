using ASP;
using DAL;
using Shove;
using Shove._IO;
using Shove._Web;
using Shove.Alipay;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_UserDistillWaitPay : AdminPageBase, IRequiresSessionState
{
    protected string _input_charset = "";
    protected string agentID = "";
    protected string biz_type = "";
    protected string bptb_pay_file = "";
    protected string digest_bptb_pay_file = "";
    protected string file_digest_type = "";
    protected string gateway = "";
    protected string key = "";
    protected string partner = "";
    protected string service = "";
    protected string sign = "";
    protected string sign_type = "";
    protected string Url = "";

    private void BindBankType()
    {
        string key = "Admin_UserDistillWaitPay_BankType";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Banks().Open("", "", "[Name]");
        }
        this.ddlAccountType.DataSource = cacheAsDataTable;
        this.ddlAccountType.DataTextField = "Name";
        this.ddlAccountType.DataValueField = "Name";
        this.ddlAccountType.DataBind();
        this.ddlAccountType.Items.Insert(0, "");
        this.ddlAccountType.Items.Add("支付宝");
    }

    private void BindData(bool IsReload)
    {
        string key = "Admin_UserDistillWaitPay_" + this.tbBeginTime.Text + "_" + this.tbEndTime.Text;
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if ((cacheAsDataTable == null) || IsReload)
        {
            cacheAsDataTable = new Views.V_UserDistills().Open("", "Result=10 and SiteID = " + base._Site.ID.ToString(), "[DateTime] desc");
            Shove._Web.Cache.SetCache(key, cacheAsDataTable);
        }
        if (cacheAsDataTable == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_FinanceDistill");
        }
        else
        {
            string filterCondition = this.GetFilterCondition();
            DataView dv = new DataView(cacheAsDataTable, filterCondition, "[DateTime] desc", DataViewRowState.OriginalRows);
            PF.DataGridBindData(this.g, dv, this.gPager);
            for (int i = 0; i < this.g.Columns.Count; i++)
            {
                if ((((this.g.Columns[i].HeaderText == "提款银行卡帐号") || (this.g.Columns[i].HeaderText == "开户银行")) || ((this.g.Columns[i].HeaderText == "支行名称") || (this.g.Columns[i].HeaderText == "所在省"))) || ((this.g.Columns[i].HeaderText == "所在市") || (this.g.Columns[i].HeaderText == "持卡人姓名")))
                {
                    this.g.Columns[i].Visible = (this.hfCurPayType.Value == "所有") || (this.hfCurPayType.Value == "银行卡");
                }
                else if (this.g.Columns[i].HeaderText == "支付宝账号")
                {
                    this.g.Columns[i].Visible = true;
                    this.g.Columns[i].Visible = (this.hfCurPayType.Value == "所有") || (this.hfCurPayType.Value == "支付宝");
                }
            }
        }
    }

    protected void btnAlipayToAlipayAdd_Click(object sender, EventArgs e)
    {
        int count = 0;
        double sumMoney = 0.0;
        string body = "";
        int itemIndex = 0;
        string str2 = "";
        string str3 = "";
        string str4 = "";
        double num4 = 0.0;
        string str5 = "";
        string userDistillIDs = "";
        for (itemIndex = 0; itemIndex < this.g.Items.Count; itemIndex++)
        {
            CheckBox box = (CheckBox)this.g.Items[itemIndex].FindControl("chkSelect");
            if ((box != null) && box.Checked)
            {
                str2 = this.GetDataGridCellValue(this.g, itemIndex, "ID");
                str3 = this.GetDataGridCellValue(this.g, itemIndex, "AlipayName");
                str4 = this.GetDataGridCellValue(this.g, itemIndex, "RealityName");
                num4 = Convert.ToDouble(this.GetDataGridCellValue(this.g, itemIndex, "Money")) - _Convert.StrToDouble(this.GetDataGridCellValue(this.g, itemIndex, "FormalitiesFees"), 0.0);
                str5 = "会员提款";
                if (body != "")
                {
                    object obj2 = body;
                    body = string.Concat(new object[] { obj2, "|", str2, "^", str3, "^", str4, "^", num4, "^", str5 });
                }
                else
                {
                    object obj3 = body;
                    body = string.Concat(new object[] { obj3, str2, "^", str3, "^", str4, "^", num4, "^", str5 });
                }
                if (userDistillIDs == "")
                {
                    userDistillIDs = str2;
                }
                else
                {
                    userDistillIDs = userDistillIDs + "," + str2;
                }
                sumMoney += num4;
                count++;
            }
        }
        if (count > 0)
        {
            this.OnlinePaymentAlipayToAlipay(count, sumMoney, body, userDistillIDs);
        }
        else
        {
            JavaScript.Alert(this, "您没有选中任何选项。");
        }
    }

    protected void btnAlipayToBank_Click(object sender, EventArgs e)
    {
        int count = 0;
        double sumMoney = 0.0;
        string body = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        string str5 = "";
        string str6 = "";
        string str7 = "";
        string str8 = "";
        double num3 = 0.0;
        string userDistillIDs = "";
        for (int i = 0; i < this.g.Items.Count; i++)
        {
            CheckBox box = (CheckBox)this.g.Items[i].FindControl("chkSelect");
            if ((box != null) && box.Checked)
            {
                this.GetDataGridCellValue(this.g, i, "UserID");
                str2 = this.GetDataGridCellValue(this.g, i, "ID");
                str3 = this.GetDataGridCellValue(this.g, i, "BankUserName");
                str4 = this.GetDataGridCellValue(this.g, i, "BankCardNumber");
                str5 = this.GetDataGridCellValue(this.g, i, "BankTypeName");
                str6 = this.GetDataGridCellValue(this.g, i, "BankInProvince");
                str7 = this.GetDataGridCellValue(this.g, i, "BankInCity");
                str8 = this.GetDataGridCellValue(this.g, i, "BankName");
                num3 = Convert.ToDouble(this.GetDataGridCellValue(this.g, i, "Money")) - _Convert.StrToDouble(this.GetDataGridCellValue(this.g, i, "FormalitiesFees"), 0.0);
                string str10 = body;
                body = str10 + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + num3.ToString() + ",2,会员提款\r\n";
                if (userDistillIDs == "")
                {
                    userDistillIDs = str2;
                }
                else
                {
                    userDistillIDs = userDistillIDs + "," + str2;
                }
                sumMoney += num3;
                count++;
            }
        }
        if (((body != "") && (count > 0)) && (sumMoney > 0.0))
        {
            this.OnlinePaymentAlipayToBank(count, sumMoney, body, userDistillIDs);
        }
        else
        {
            JavaScript.Alert(this, "您没有选中任何选项。");
        }
    }

    protected void btnOKAll_Click(object sender, EventArgs e)
    {
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if ((this.tbBeginTime.Text.Trim() != "") && (this.tbEndTime.Text.Trim() != ""))
        {
            DateTime now = DateTime.Now;
            DateTime result = DateTime.Now;
            if (!DateTime.TryParse(this.tbBeginTime.Text, out now) && !DateTime.TryParse(this.tbEndTime.Text, out result))
            {
                JavaScript.Alert(this.Page, "请输入正确的日期格式:2008-8-8");
                return;
            }
        }
        this.BindData(false);
    }

    protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData(false);
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        long distillID = _Convert.StrToLong(this.g.DataKeys[e.Item.ItemIndex].ToString(), -1L);
        long userID = _Convert.StrToLong(e.Item.Cells[1].Text, -1L);
        if (e.CommandName == "Pay")
        {
            int returnValue = 0;
            string returnDescription = "";
            if (Procedures.P_DistillPaySuccess(base._Site.ID, userID, distillID, "付款成功", base._User.ID, ref returnValue, ref returnDescription) < 0)
            {
                JavaScript.Alert(this.Page, "出错!请联技术人员!");
            }
            else if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, "出错!请联技术人员:" + returnDescription);
            }
            else
            {
                this.BindData(true);
                JavaScript.Alert(this.Page, "操作成功.");
            }
        }
        else if (e.CommandName == "DistillNoAccept")
        {
            string memo = ((TextBox)e.Item.FindControl("tbMemo")).Text.Trim();
            if ((memo == "") || (memo.IndexOf("接受提款") > 0))
            {
                memo = "提款资料不完整";
            }
            int num6 = 0;
            string str3 = "";
            if (Procedures.P_DistillNoAccept(base._Site.ID, userID, distillID, memo, base._User.ID, ref num6, ref str3) < 0)
            {
                JavaScript.Alert(this.Page, "出错!请联技术人员!");
            }
            else if (num6 < 0)
            {
                JavaScript.Alert(this.Page, "出错!请联技术人员:" + str3);
            }
            else
            {
                this.BindData(true);
                JavaScript.Alert(this.Page, "操作成功!该笔提款已拒绝提款.");
            }
        }
        else if (e.CommandName == "EditMemo")
        {
            string str4 = Utility.FilteSqlInfusion(((TextBox)e.Item.FindControl("tbMemo")).Text.Trim());
            if ((str4 == "") || (str4.IndexOf("接受提款") > 0))
            {
                str4 = "提款资料不完整";
            }
            MSSQL.ExecuteNonQuery(" update T_UserDistills set [Memo] ='" + str4.Replace("'", "\"") + "' where [ID] = " + distillID.ToString(), new MSSQL.Parameter[0]);
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            TextBox box = (TextBox)e.Item.FindControl("tbMemo");
            box.Text = dataItem["Memo"].ToString();
        }
    }

    private string GetDataGridCellValue(DataGrid g, int ItemIndex, string dataField)
    {
        bool flag = false;
        string text = "";
        for (int i = 0; i < g.Columns.Count; i++)
        {
            BoundColumn column = g.Columns[i] as BoundColumn;
            if ((column != null) && (column.DataField.ToLower() == dataField.ToLower()))
            {
                flag = true;
                text = g.Items[ItemIndex].Cells[i].Text;
                break;
            }
        }
        if (!flag)
        {
            PF.GoError(-111, "找不到指定的列值,请联系技术员", base.GetType().Name);
        }
        return text;
    }

    private string GetFilterCondition()
    {
        string str = " Result=10 ";
        if ((this.tbBeginTime.Text.Trim() != "") && (this.tbEndTime.Text.Trim() != ""))
        {
            DateTime now = DateTime.Now;
            DateTime result = DateTime.Now;
            if (DateTime.TryParse(this.tbBeginTime.Text, out now) && DateTime.TryParse(this.tbEndTime.Text, out result))
            {
                string str2 = str;
                str = str2 + " and ( DateTime >= '" + now.ToString("yyyy-MM-dd") + "' and DateTime <= '" + result.ToString("yyyy-MM-dd") + " 23:59:59' )";
            }
            else
            {
                JavaScript.Alert(this.Page, "请输入正确的日期格式:2008-8-8");
            }
        }
        if (this.hfCurPayType.Value == "银行卡")
        {
            str = str + " and DistillType =2 ";
        }
        else if (this.hfCurPayType.Value == "支付宝")
        {
            str = str + " and DistillType =1 ";
        }
        if (this.tbUserName.Text.Trim() != "")
        {
            str = str + " and Name='" + Utility.FilteSqlInfusion(this.tbUserName.Text.Trim()) + "' ";
        }
        if (!(this.ddlAccountType.Text.Trim() != ""))
        {
            return str;
        }
        if (this.ddlAccountType.Text != "支付宝")
        {
            return (str + " and BankName like '%" + this.ddlAccountType.Text + "%'");
        }
        return (str + " and BankName ='' ");
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData(false);
    }

    protected void lbtnAllPay_Click(object sender, EventArgs e)
    {
        this.hfCurPayType.Value = "所有";
        this.btnAlipayToAlipayAdd.Visible = true;
        this.btnAlipayToBank.Visible = true;
        this.BindData(false);
        this.PayByAlipay.Attributes["class"] = "NotSelectedTab";
        this.PayByBank.Attributes["class"] = "NotSelectedTab";
        this.AllPay.Attributes["class"] = "SelectedTab";
    }

    protected void lbtnPayByAlipay_Click(object sender, EventArgs e)
    {
        this.hfCurPayType.Value = "支付宝";
        this.btnAlipayToAlipayAdd.Visible = true;
        this.btnAlipayToBank.Visible = false;
        this.BindData(false);
        this.PayByAlipay.Attributes["class"] = "SelectedTab";
        this.PayByBank.Attributes["class"] = "NotSelectedTab";
        this.AllPay.Attributes["class"] = "NotSelectedTab";
    }

    protected void lbtnPayByBank_Click(object sender, EventArgs e)
    {
        this.hfCurPayType.Value = "银行卡";
        this.btnAlipayToAlipayAdd.Visible = false;
        this.btnAlipayToBank.Visible = true;
        this.BindData(false);
        this.PayByAlipay.Attributes["class"] = "NotSelectedTab";
        this.PayByBank.Attributes["class"] = "SelectedTab";
        this.AllPay.Attributes["class"] = "NotSelectedTab";
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Finance" });
        base.OnInit(e);
    }

    protected void OnlinePaymentAlipayToAlipay(int Count, double SumMoney, string Body, string UserDistillIDs)
    {
        SystemOptions options = new SystemOptions();
        this.partner = options["OnlinePay_Alipay_ForUserDistill_UserNumber"].ToString("");
        this.key = options["OnlinePay_Alipay_ForUserDistill_MD5Key_ForPayOut"].ToString("");
        string email = options["OnlinePay_Alipay_ForUserDistill_UserName"].ToString("");
        string str2 = "深圳天维掌通技术有限公司";
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";
        string str4 = "utf-8";
        string service = "batch_trans_notify";
        string str6 = "MD5";
        DateTime now = DateTime.Now;
        string str7 = now.ToString("yyyyMMdd");
        Random random = new Random();
        string str8 = random.Next(1, 0x63).ToString().PadLeft(2, '0');
        string fileName = now.ToString("yyyyMMddhhmmss") + str8;
        string str10 = SumMoney.ToString();
        string str11 = Count.ToString();
        string str12 = Body;
        string str13 = Utility.GetUrl() + "/Admin/OnlinePayment/Alipay/AlipayNotify.aspx";
        int returnValue = 0;
        string returnDescription = "";
        if (Procedures.P_UserDistillPayByAlipay(base._User.ID, fileName, UserDistillIDs, 1, ref returnValue, ref returnDescription) < 0)
        {
            Procedures.P_UserDistillPayByAlipayWriteLog("提款ID:" + UserDistillIDs + "写入数据库（FileName）和更新状态失败。");
        }
        if (returnDescription != "")
        {
            JavaScript.Alert(this.Page, "数据更新错误:" + returnDescription);
        }
        string url = new Shove.Alipay.Alipay().CreatUrl(gateway, service, this.partner, str6, fileName, str2, str10, str11, email, str7, str12, this.key, str13, str4);
        base.Response.Redirect(url, true);
    }

    protected void OnlinePaymentAlipayToBank(int Count, double SumMoney, string Body, string UserDistillIDs)
    {
        SystemOptions options = new SystemOptions();
        this.partner = options["OnlinePay_Alipay_ForUserDistill_UserNumber"].ToString("");
        this.key = options["OnlinePay_Alipay_ForUserDistill_MD5Key"].ToString("");
        this.gateway = options["MemberSharing_Alipay_Gateway"].ToString("");
        this.service = "bptb_pay_file";
        this.sign_type = "MD5";
        this._input_charset = "GB2312";
        this.file_digest_type = "MD5";
        this.biz_type = "d_sale";
        this.agentID = options["OnlinePay_Alipay_ForUserDistill_UserNumber"].ToString("");
        Shove.Alipay.Alipay alipay = new Shove.Alipay.Alipay();
        DateTime now = DateTime.Now;
        string str = "";
        string path = "";
        string fileName = "";
        string str4 = "";
        int index = 0;
        if (((Body != "") && (Count > 0)) && (SumMoney > 0.0))
        {
            string str5 = now.ToString("yyyyMMdd");
            string str7 = "日期,总金额,总笔数,支付宝帐号(Email)\r\n";
            Body = (str7 + str5 + "," + SumMoney.ToString() + "," + Count.ToString() + "," + this.partner + "\r\n") + "商户流水号,收款银行户名,收款银行帐号,收款开户银行,收款银行所在省份,收款银行所在市,收款支行名称,金额,对公对私标志,备注\r\n" + Body;
            Random random = new Random();
            string str8 = (random.Next(1, 0x3e7).ToString() + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString()).PadLeft(9, '0');
            str = "PAPX_" + str5 + "_P" + str8 + ".csv".ToLower();
            path = base.MapPath("../App_Log/Admin/AlipayPayment/PABX/" + str).ToLower();
            fileName = "PAPX_" + str5 + "_P" + str8 + ".Zip".ToLower();
            str4 = base.MapPath("../App_Log/Admin/AlipayPayment/PABX/" + fileName).ToLower();
            if (!System.IO.File.Exists(path))
            {
                try
                {
                    if (!Shove._IO.File.WriteFile(path, Body))
                    {
                        Procedures.P_UserDistillPayByAlipayWriteLog("CSV文件写入失败:" + path);
                        JavaScript.Alert(this.Page, "CSV文件写入失败");
                        return;
                    }
                    if (System.IO.File.Exists(path))
                    {
                        if (System.IO.File.Exists(str4))
                        {
                            goto Label_0388;
                        }
                        try
                        {
                            Shove._IO.File.Compress(path, str4);
                            goto Label_0388;
                        }
                        catch
                        {
                            Procedures.P_UserDistillPayByAlipayWriteLog("文件压缩出现异常:" + path);
                            JavaScript.Alert(this.Page, "文件压缩出现异常");
                            return;
                        }
                    }
                    Procedures.P_UserDistillPayByAlipayWriteLog("CSV文件不存在(1):" + path);
                    JavaScript.Alert(this.Page, "CSV文件不存在");
                    return;
                }
                catch
                {
                    Procedures.P_UserDistillPayByAlipayWriteLog("CSV文件写入异常:" + path);
                    JavaScript.Alert(this.Page, "CSV文件写入异常");
                    return;
                }
            }
            JavaScript.Alert(this.Page, "文件写已存在");
            return;
        }
    Label_0388:
        if (!System.IO.File.Exists(str4))
        {
            Procedures.P_UserDistillPayByAlipayWriteLog("ZIP文件不存在(2):" + path);
            JavaScript.Alert(this.Page, "ZIP文件不存在");
        }
        else
        {
            byte[] buffer4;
            byte[] date = System.IO.File.ReadAllBytes(str4);
            this.digest_bptb_pay_file = Shove.Alipay.Alipay.GetMD5(date, this._input_charset);
            string[] strArray4 = alipay.GetUploadParams(this.service, this._input_charset, this.partner, this.file_digest_type, this.biz_type, this.agentID);
            FileStream stream = new FileStream(str4, FileMode.Open, FileAccess.Read, FileShare.Read);
            string contentType = "application/octet-stream";
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            stream.Close();
            CreateBytes bytes = new CreateBytes();
            ArrayList byteArrays = new ArrayList();
            string[] fields = new string[strArray4.Length + 1];
            char[] separator = new char[] { '=' };
            index = 0;
            while (index < strArray4.Length)
            {
                string fieldName = strArray4[index].Split(separator)[0];
                string fieldValue = strArray4[index].Split(separator)[1];
                byteArrays.Add(bytes.CreateFieldData(fieldName, fieldValue));
                fields[index] = fieldName + "=" + fieldValue;
                index++;
            }
            byteArrays.Add(bytes.CreateFieldData("digest_bptb_pay_file", this.digest_bptb_pay_file));
            fields[index] = "digest_bptb_pay_file=" + this.digest_bptb_pay_file;
            this.sign = AlipayCommon.GetSign(fields, this.key).Trim();
            byteArrays.Add(bytes.CreateFieldData("sign", this.sign));
            byteArrays.Add(bytes.CreateFieldData("sign_type", "MD5"));
            byteArrays.Add(bytes.CreateFieldData("bptb_pay_file", str4, contentType, buffer));
            byte[] buffer3 = bytes.JoinBytes(byteArrays);
            if (!bytes.UploadData(this.gateway, buffer3, out buffer4))
            {
                Procedures.P_UserDistillPayByAlipayWriteLog("上传到指定Url失败:" + path);
                try
                {
                    System.IO.File.Delete(path);
                    System.IO.File.Delete(str4);
                }
                catch
                {
                }
                JavaScript.Alert(this.Page, "上传支付数据到指定Url失败!");
            }
            else
            {
                string str12 = Encoding.Default.GetString(buffer4);
                if (str12.IndexOf("上传成功") >= 0)
                {
                    int returnValue = 0;
                    string returnDescription = "";
                    if (Procedures.P_UserDistillPayByAlipay(base._User.ID, fileName, UserDistillIDs, 2, ref returnValue, ref returnDescription) < 0)
                    {
                        Procedures.P_UserDistillPayByAlipayWriteLog("提款ID:" + UserDistillIDs + "写入数据库（FileName）和更新状态失败。");
                    }
                    if (returnDescription != "")
                    {
                        Procedures.P_UserDistillPayByAlipayWriteLog("把上传的支付明细写入数据库（FileName）和更新状态出错:" + returnDescription);
                        JavaScript.Alert(this.Page, "出错:" + returnDescription);
                        this.BindData(true);
                    }
                    else
                    {
                        JavaScript.Alert(this.Page, str12 + "银行处理需要到明天才有结果,请耐心等待处理结果！");
                        this.BindData(true);
                    }
                }
                else
                {
                    Procedures.P_UserDistillPayByAlipayWriteLog("上传支付到银行明细失败:" + str12);
                    JavaScript.Alert(this.Page, str12.Replace("\n", "").Replace("\r", ""));
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindBankType();
            this.hfCurPayType.Value = "支付宝";
            this.btnAlipayToAlipayAdd.Visible = true;
            this.btnAlipayToBank.Visible = false;
            this.PayByAlipay.Attributes["class"] = "SelectedTab";
            this.PayByBank.Attributes["class"] = "NotSelectedTab";
            this.AllPay.Attributes["class"] = "NotSelectedTab";
            this.BindData(true);
        }
    }


}

