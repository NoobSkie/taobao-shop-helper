using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using TOP.Core.Facade;
using TOP.Core.Domain;

namespace TOP.Applications.ItemDescriptionEdit
{
    public partial class FrmSelectItems : Form
    {
        private string defaultAppKey = "12006575";
        private string defaultAppSecret = "9d0a6fb5453e9b51877f9ed28b5569a9";
        private string nick = "zhongjy001";
        private int pageSize = 40;
        private int currentPageIndex = 1;

        public FrmSelectItems()
        {
            InitializeComponent();

            ucProgress.OnCancelProgress = OnCancelHandleProgress;
        }

        private List<SampleListItem> selectedIidList = null;
        public List<SampleListItem> SelectedIidList
        {
            get
            {
                return selectedIidList;
            }
        }

        private void FrmSelectItems_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void OnCancelHandleProgress(CtrlProgress ctrl)
        {
            isCanceled = true;
        }

        private void LoadItems()
        {
            fpnlList.Controls.Clear();
            string currentPath = Assembly.GetExecutingAssembly().Location;
            string dir = new FileInfo(currentPath).DirectoryName;
            dir = dir + "\\ShopItems";
            if (Directory.Exists(dir))
            {
                foreach (string path in Directory.GetFiles(dir, "*.info", SearchOption.TopDirectoryOnly))
                {
                    string iid, name, price, imgPath, imgUrl;
                    GetItem(path, out iid, out name, out price, out imgPath, out imgUrl);
                    CtrlItem item = new CtrlItem();
                    item.LoadItem(iid, name, price, imgPath, imgUrl);
                    fpnlList.Controls.Add(item);
                }
            }
            lblTitle.Text = string.Format("当前商品总数: {0} 个", fpnlList.Controls.Count);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            selectedIidList = new List<SampleListItem>();
            foreach (CtrlItem ctrl in fpnlList.Controls)
            {
                if (ctrl.Checked)
                {
                    SampleListItem item = new SampleListItem();
                    item.Id = ctrl.Iid;
                    item.Title = ctrl.ItemName;
                    item.Price = ctrl.Price;
                    item.PicPath = ctrl.ImagePath;
                    item.Location = ctrl.ImageUrl;
                    selectedIidList.Add(item);
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetEnable(bool enable)
        {
            btnUpdate.Enabled = enable;
            btnOk.Enabled = enable;
            btnCancel.Enabled = enable;
            fpnlList.Enabled = enable;
            cbForce.Enabled = enable;

            ucProgress.Visible = !enable;
        }

        private bool isCanceled = false;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetEnable(false);

            UpdateItems();

            SetEnable(true);

            LoadItems();
        }

        private void UpdateItems()
        {
            ucProgress.Title = "正在更新商品...";
            ucProgress.Summary = "正在从服务器获取需要更新的商品信息...";
            ucProgress.ProgressTotal = 100;
            ucProgress.ProgressValue = 1;
            ucProgress.Total = -1;
            ucProgress.Value = -1;
            ucProgress.DisplayProgress();
            Application.DoEvents();

            string currentPath = Assembly.GetExecutingAssembly().Location;
            string dir = new FileInfo(currentPath).DirectoryName;
            dir = dir + "\\ShopItems";
            if (cbForce.Checked)
            {
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                }
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);
            TOPDataList<SampleListItem> list = facade.QuerySampleListByNick(currentPageIndex++, pageSize, nick);
            while (true)
            {
                TOPDataList<SampleListItem> tmp = facade.QuerySampleListByNick(currentPageIndex++, pageSize, nick);
                list.AddRange(tmp);
                if (tmp.Count < pageSize)
                {
                    break;
                }
            }

            ucProgress.ProgressValue = 100;
            ucProgress.DisplayProgress();
            Application.DoEvents();

            ucProgress.Total = list.Count;
            ucProgress.ProgressTotal = list.Count;

            isCanceled = false;
            using (WebClient client = new WebClient())
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (isCanceled) break;
                    SampleListItem item = list[i];
                    ucProgress.Summary = item.Title;
                    ucProgress.Value = i + 1;
                    ucProgress.ProgressValue = i + 1;
                    ucProgress.DisplayProgress();
                    Application.DoEvents();
                    SaveItem(item, dir, client);
                }
            }
            ucProgress.Summary = "更新完毕";
            ucProgress.DisplayProgress();
            Application.DoEvents();
        }

        public void GetItem(string path, out string iid, out string title, out string price, out string imgPath, out string imgUrl)
        {
            iid = string.Empty;
            title = string.Empty;
            price = string.Empty;
            imgPath = string.Empty;
            imgUrl = string.Empty;

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string info = reader.ReadLine();
                    while (!string.IsNullOrEmpty(info))
                    {
                        if (info.StartsWith("ItemId:", StringComparison.OrdinalIgnoreCase))
                        {
                            iid = info.Substring("ItemId:".Length);
                        }
                        if (info.StartsWith("ItemTitle:", StringComparison.OrdinalIgnoreCase))
                        {
                            title = info.Substring("ItemTitle:".Length);
                        }
                        if (info.StartsWith("ItemPrice:", StringComparison.OrdinalIgnoreCase))
                        {
                            price = info.Substring("ItemPrice:".Length);
                        }
                        if (info.StartsWith("ImageLocalPath:", StringComparison.OrdinalIgnoreCase))
                        {
                            imgPath = info.Substring("ImageLocalPath:".Length);
                        }
                        if (info.StartsWith("ImageUrl:", StringComparison.OrdinalIgnoreCase))
                        {
                            imgUrl = info.Substring("ImageUrl:".Length);
                        }

                        info = reader.ReadLine();
                    }
                }
            }
        }

        private void SaveItem(SampleListItem item, string dirPath, WebClient client)
        {
            string fileUrl = item.PicPath;
            fileUrl = fileUrl.Substring(fileUrl.LastIndexOf('/')).TrimStart('/');
            string imgName = fileUrl.Substring(0, fileUrl.LastIndexOf('.'));

            string ext = fileUrl.Substring(fileUrl.LastIndexOf('.'));
            string fileName = item.Id + "_" + imgName + ext;
            string infoName = fileName + ".info";

            if (Directory.GetFiles(dirPath, infoName, SearchOption.TopDirectoryOnly).Length == 0)
            {
                string filePath = string.Format(@"{0}\{1}", dirPath, fileName);
                string infoPath = string.Format(@"{0}\{1}", dirPath, infoName);
                client.DownloadFile(item.PicPath, filePath);

                using (StreamWriter writer = new StreamWriter(infoPath, false, Encoding.UTF8))
                {
                    writer.WriteLine(string.Format("ItemId:{0}", item.Id));
                    writer.WriteLine(string.Format("ItemTitle:{0}", item.Title));
                    writer.WriteLine(string.Format("ItemPrice:{0}", item.Price));
                    writer.WriteLine(string.Format("ImageLocalPath:{0}", filePath));
                    writer.WriteLine(string.Format("ImageUrl:{0}", item.PicPath));
                    writer.Flush();
                }
            }
        }
    }
}
