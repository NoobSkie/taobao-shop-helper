using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TOP.Applications.PicWatermark
{
    public partial class FrmTest : Form
    {
        private Image CurrentImage = null;
        private IWatermark CurrentWatermark = null;

        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            IList<IWatermark> list = Helper.GetWatermarkList();
            foreach (IWatermark w in list)
            {
                cbWatermark.Items.Add(w);
            }
            if (cbWatermark.Items.Count > 0)
            {
                cbWatermark.SelectedIndex = 0;
            }
        }

        private void cbWatermark_SelectedIndexChanged(object sender, EventArgs e)
        {
            IWatermark w = (IWatermark)cbWatermark.SelectedItem;
            CurrentWatermark = w;
            if (w.ConfigurationControl != null)
            {
                pnlConfiguration.Controls.Clear();
                w.ConfigurationControl.Dock = DockStyle.Fill;
                w.ConfigurationControl.OnAfterConfigChanged = config_OnAfterConfigChanged;
                pnlConfiguration.Controls.Add(w.ConfigurationControl);
            }
        }

        private void config_OnAfterConfigChanged(CtrlWatermarkConfiguration configuration)
        {
            if (CurrentImage != null)
            {
                picImg.Image = (Image)CurrentWatermark.Watermark(CurrentImage).Clone();
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                CurrentImage = Image.FromFile(openImage.FileName);

                if (CurrentWatermark.ConfigurationControl.CanWatermark)
                {
                    picImg.Image = (Image)CurrentWatermark.Watermark(CurrentImage).Clone();
                }
                else
                {
                    picImg.Image = (Image)CurrentImage.Clone();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (picImg.Image != null)
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picImg.Image.Save(saveFileDialog.FileName);
                }
            }
        }
    }
}
