using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TOP.Applications.PicWatermark.V01;
using TOP.Applications.PicWatermark.V02;
using System.IO;
using System.Threading;
using TOP.Applications.PicWatermark.V03;

namespace TOP.Applications.PicWatermark
{
    public delegate void HandleFile(FileInfo file, int total);

    public partial class frmWatermark : Form
    {
        private Image CurrentImage = null;
        private IList<IWatermark> CurrentWatermarks = new List<IWatermark>();

        int count = 0;
        private void OnHandleImageFile(FileInfo file, int total)
        {
            if (isExited) return;
            Image img = (Image)Image.FromFile(file.FullName).Clone();
            foreach (IWatermark watermark in CurrentWatermarks)
            {
                if (watermark.ConfigurationControl.CanWatermark)
                {
                    img = watermark.Watermark(img);
                }
            }
            string fileName = file.FullName.Substring(folderBrowserDialogIn.SelectedPath.Length);
            fileName = folderBrowserDialogOut.SelectedPath + fileName;
            FileInfo f = new FileInfo(fileName);
            if (!f.Directory.Exists)
            {
                f.Directory.Create();
            }
            img.Save(fileName);

            count++;
            lblMsg.Text = string.Format("({0}/{1}) {2}", count, total, file.FullName);
            progressBarEvent.Value++;
            Application.DoEvents();
        }

        public frmWatermark()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                CurrentImage = Image.FromFile(openImage.FileName);
                DisplayImage();
            }
        }

        private void DisplayImage()
        {
            if (CurrentImage != null)
            {
                Image img = (Image)CurrentImage.Clone();
                foreach (IWatermark watermark in CurrentWatermarks)
                {
                    if (watermark.ConfigurationControl.CanWatermark)
                    {
                        img = watermark.Watermark(img);
                    }
                }
                picImg.Image = img;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (picImg.Image != null)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picImg.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void frmWatermark_Load(object sender, EventArgs e)
        {
            cbOption.SelectedIndex = 0;
        }

        private void cbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            IWatermark w = null;
            if (cbOption.SelectedIndex == 1)
            {
                w = new WatermarkV01();
            }
            else if (cbOption.SelectedIndex == 2)
            {
                w = new WatermarkV02();
            }
            else if (cbOption.SelectedIndex == 3)
            {
                w = new WatermarkV03();
            }

            if (w != null && w.ConfigurationControl != null)
            {
                pnlConfig.Controls.Clear();
                w.ConfigurationControl.Dock = DockStyle.Fill;
                w.ConfigurationControl.OnAfterConfigChanged = config_OnAfterConfigChanged;
                pnlConfig.Controls.Add(w.ConfigurationControl);

                CurrentWatermarks.Add(w);
                listOptions.Items.Add(w);
                listOptions.SelectedItem = w;

                cbOption.SelectedIndex = 0;
            }
        }

        private void config_OnAfterConfigChanged(CtrlWatermarkConfiguration configuration)
        {
            if (CurrentImage != null)
            {
                DisplayImage();
            }
        }

        private void listOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOptions.SelectedIndex != -1)
            {
                IWatermark w = (IWatermark)listOptions.SelectedItem;

                pnlConfig.Controls.Clear();
                w.ConfigurationControl.Dock = DockStyle.Fill;
                w.ConfigurationControl.OnAfterConfigChanged = config_OnAfterConfigChanged;
                pnlConfig.Controls.Add(w.ConfigurationControl);
            }
        }

        private void miMoveUp_Click(object sender, EventArgs e)
        {
            int index = listOptions.SelectedIndex;
            object item = listOptions.SelectedItem;

            IWatermark w = CurrentWatermarks[index];
            CurrentWatermarks.Remove(w);
            CurrentWatermarks.Insert(index - 1, w);

            listOptions.Items.Remove(item);
            listOptions.Items.Insert(index - 1, item);

            listOptions.SelectedItem = item;

            DisplayImage();
        }

        private void miMoveDown_Click(object sender, EventArgs e)
        {
            int index = listOptions.SelectedIndex;
            object item = listOptions.SelectedItem;

            IWatermark w = CurrentWatermarks[index];
            CurrentWatermarks.Remove(w);
            CurrentWatermarks.Insert(index + 1, w);

            listOptions.Items.Remove(item);
            listOptions.Items.Insert(index + 1, item);

            listOptions.SelectedItem = item;

            DisplayImage();
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            int index = listOptions.SelectedIndex;
            CurrentWatermarks.RemoveAt(index);
            listOptions.Items.RemoveAt(index);
            pnlConfig.Controls.Clear();
            if (listOptions.Items.Count > 0)
            {
                if (listOptions.Items.Count > index + 1)
                {
                    listOptions.SelectedIndex = index;
                }
                else
                {
                    listOptions.SelectedIndex = index - 1;
                }
            }

            DisplayImage();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (listOptions.SelectedIndex == -1)
            {
                miMoveUp.Enabled = false;
                miMoveDown.Enabled = false;
                miDelete.Enabled = false;
            }
            else
            {
                miMoveUp.Enabled = true;
                miMoveDown.Enabled = true;
                miDelete.Enabled = true;
                if (listOptions.SelectedIndex == 0)
                {
                    miMoveUp.Enabled = false;
                }
                if (listOptions.SelectedIndex == listOptions.Items.Count - 1)
                {
                    miMoveDown.Enabled = false;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(folderBrowserDialogIn.SelectedPath) && !string.IsNullOrEmpty(folderBrowserDialogOut.SelectedPath))
            {
                try
                {
                    grpIn.Enabled = false;
                    grpOut.Enabled = false;
                    grpOption.Enabled = false;
                    btnExport.Enabled = false;
                    progressBarEvent.Visible = true;
                    btnCancel.Visible = true;
                    lblMsg.Visible = true;
                    progressBarEvent.Value = 0;
                    Application.DoEvents();

                    DirectoryInfo dir = new DirectoryInfo(folderBrowserDialogIn.SelectedPath);
                    lblMsg.Text = "正在计算要添加水印的文件...";
                    Application.DoEvents();
                    int total = GetFilesCount(dir, cbSub.Checked);
                    progressBarEvent.Maximum = total + 1;
                    progressBarEvent.Value = 1;
                    Application.DoEvents();

                    count = 0; 
                    isExited = false;
                    DoEventFiles(dir, cbSub.Checked, OnHandleImageFile, total);

                    MessageBox.Show(string.Format("操作完成, 共添加水印 {0} 个文件.", count), "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grpIn.Enabled = true;
                    grpOut.Enabled = true;
                    grpOption.Enabled = true;
                    btnExport.Enabled = true;
                    progressBarEvent.Visible = false;
                    btnCancel.Visible = false;
                    lblMsg.Visible = false;
                }
                catch
                {
                    MessageBox.Show("系统执行过程发生错误", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grpIn.Enabled = true;
                    grpOut.Enabled = true;
                    grpOption.Enabled = true;
                    btnExport.Enabled = true;
                    progressBarEvent.Visible = false;
                    btnCancel.Visible = false;
                    lblMsg.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("请选择正确的输入路径和输出路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DoEventFiles(DirectoryInfo dir, bool hasSub, HandleFile handle, int total)
        {
            if (isExited) return;
            if (hasSub)
            {
                foreach (DirectoryInfo sub in dir.GetDirectories())
                {
                    DoEventFiles(sub, hasSub, handle, total);
                }
            }
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    if (handle != null)
                    {
                        handle(file, total);
                    }
                }
            }
        }

        private int GetFilesCount(DirectoryInfo dir, bool hasSub)
        {
            int total = 0;
            if (hasSub)
            {
                foreach (DirectoryInfo sub in dir.GetDirectories())
                {
                    total += GetFilesCount(sub, hasSub);
                }
            }
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    total++;
                }
            }
            return total;
        }

        private void btnFolderIn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogIn.ShowDialog() == DialogResult.OK)
            {
                txtIn.Text = folderBrowserDialogIn.SelectedPath;
            }
        }

        private void btnFolderOut_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogOut.ShowDialog() == DialogResult.OK)
            {
                txtOut.Text = folderBrowserDialogOut.SelectedPath;
            }
        }

        private bool isExited = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            isExited = true;
        }
    }
}
