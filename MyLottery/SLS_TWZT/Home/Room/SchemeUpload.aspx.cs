using ASP;
using Shove;
using Shove._IO;
using Shove._Web;
using Shove.Web.UI;
using SLS;
using System;
using System.IO;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_SchemeUpload : RoomPageBase, IRequiresSessionState
{
    public string strIsuse;
    public string strLotteryID;
    public string strLotteryName;
    public string strLotteryNumber;
    public string strPanelNum;
    public string strPlayType;
    public string strPlayTypeName;
    public string strSchemeFileName;

    protected void btnfileUp_Click(object sender, EventArgs e)
    {
        string str = this.btnfile.Value;
        if (string.IsNullOrEmpty(str))
        {
            JavaScript.Alert(this.Page, "请先选择一个文件再上传。");
        }
        else if (!str.Trim().ToLower().EndsWith(".txt"))
        {
            JavaScript.Alert(this.Page, "只能上传 .txt 文本类型的文件。");
        }
        else
        {
            this.tbSchemeFileName.Value = "null";
            this.tbLotteryNumber.Value = "null";
            this.strSchemeFileName = "null";
            this.strLotteryNumber = "null";
            this.strPlayTypeName = new Lottery().GetPlayTypeName(int.Parse(this.tbPlayType.Value));
            this.strLotteryName = new Lottery()[int.Parse(this.tbLotteryID.Value)].name;
            string newFileName = "";
            if (Shove._IO.File.UploadFile(this.Page, this.btnfile, "../../Temp/", ref newFileName, "text") != 0)
            {
                JavaScript.Alert(this.Page, "方案上传失败。");
            }
            else
            {
                string path = base.Server.MapPath("../../Temp/" + newFileName);
                string content = _Convert.ToDBC(System.IO.File.ReadAllText(path, Encoding.Default)).Trim();
                if (content == "")
                {
                    System.IO.File.Delete(path);
                    JavaScript.Alert(this.Page, "方案文件没有任何内容，请重新选择。");
                }
                else
                {
                    this.tbSchemeFileName.Value = newFileName;
                    this.strSchemeFileName = newFileName;
                    int lotteryID = _Convert.StrToInt(this.tbLotteryID.Value, -1);
                    if (!new Lottery().ValidID(lotteryID))
                    {
                        System.IO.File.Delete(path);
                        this.tbSchemeFileName.Value = "null";
                        this.strSchemeFileName = "null";
                        JavaScript.Alert(this.Page, "方案上传失败。");
                    }
                    else
                    {
                        int playType = int.Parse(this.tbPlayType.Value);
                        if (lotteryID == 0x3d)
                        {
                            content = this.FmtContent(content);
                        }
                        this.tbLotteryNumber.Value = new Lottery()[lotteryID].AnalyseScheme(content, playType);
                        this.strLotteryNumber = this.tbLotteryNumber.Value.Trim();
                        string[] strArray2 = this.strLotteryNumber.Split(new string[] { "\n" }, StringSplitOptions.None);
                        this.strLotteryNumber = "";
                        foreach (string str5 in strArray2)
                        {
                            if (str5.Split(new char[] { '|' }).Length > 2)
                            {
                                this.strLotteryNumber = this.strLotteryNumber + str5.Substring(0, str5.LastIndexOf("|")).Trim();
                            }
                            else
                            {
                                this.strLotteryNumber = this.strLotteryNumber + str5.Split(new char[] { '|' })[0];
                            }
                        }
                        if (this.strLotteryNumber == "")
                        {
                            System.IO.File.Delete(path);
                            this.tbLotteryNumber.Value = "null";
                            this.strLotteryNumber = "null";
                            this.tbSchemeFileName.Value = "null";
                            this.strSchemeFileName = "null";
                            JavaScript.Alert(this.Page, "从方案文件中没有提取到符合书写规则的投注内容。");
                        }
                        else
                        {
                            System.IO.File.Delete(path);
                            if (this.strLotteryNumber.Replace(" ", "").Replace("\n", "") != content.Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\r\n", ""))
                            {
                                JavaScript.Alert(this.Page, "过滤掉了您上传方案中不符合格式的投注方案，请核对！");
                            }
                        }
                    }
                }
            }
        }
    }

    private string FmtContent(string content)
    {
        string str = "";
        content.Replace("-", "");
        string[] strArray2 = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        for (int i = 0; i < strArray2.Length; i++)
        {
            if ((strArray2[i].IndexOf("(") >= 0) && (strArray2[i].IndexOf(")") >= 0))
            {
                int index = strArray2[i].IndexOf(")");
                int num3 = strArray2[i].IndexOf("(");
                if (((strArray2[i].Length - ((index - num3) + 1)) + 1) == 5)
                {
                    str = str + strArray2[i] + "\r\n";
                }
                else
                {
                    str = str + this.GetFmtString(5 - ((strArray2[i].Length - ((index - num3) + 1)) + 1)) + strArray2[i] + "\r\n";
                }
            }
            else
            {
                str = str + this.GetFmtString(5 - strArray2[i].Length) + strArray2[i] + "\r\n";
            }
        }
        return str.Substring(0, str.LastIndexOf("\r\n"));
    }

    private string GetFmtString(int charCount)
    {
        string str = "";
        for (int i = 0; i < charCount; i++)
        {
            str = str + "-";
        }
        return str;
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            Lottery lottery = new Lottery();
            int lotteryID = _Convert.StrToInt(Utility.GetRequest("id"), -1);
            if (lottery.ValidID(lotteryID))
            {
                this.tbLotteryID.Value = lotteryID.ToString();
                this.strLotteryID = lotteryID.ToString();
                this.strIsuse = "";
                try
                {
                    this.strIsuse = Utility.GetRequest("Isuse");
                }
                catch
                {
                }
                this.tbIsuse.Value = this.strIsuse;
                int num2 = _Convert.StrToInt(Utility.GetRequest("PlayType"), -1);
                if (num2 >= 0)
                {
                    this.strLotteryName = lottery[lotteryID].name;
                    if (lottery[lotteryID].CheckPlayType(num2))
                    {
                        this.tbPlayType.Value = num2.ToString();
                        this.strPlayType = num2.ToString();
                        this.tbSchemeFileName.Value = "null";
                        this.tbLotteryNumber.Value = "null";
                        this.strSchemeFileName = "null";
                        this.strLotteryNumber = "null";
                    }
                }
            }
        }
    }
}

