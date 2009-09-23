using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TOP.Applications.PicWatermark.V02
{
    public partial class CtrlConfigurationV02 : CtrlWatermarkConfiguration
    {
        public CtrlConfigurationV02()
        {
            InitializeComponent();

            Parameters.Clear();
            Parameters.Add("Image", "");
            Parameters.Add("Align", ContentAlignment.MiddleLeft);
            Parameters.Add("OffsetX", 10);
            Parameters.Add("OffsetY", 10);
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(txtPath.Text))
            {
                FileInfo file = new FileInfo(txtPath.Text);
                if (file.Extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    canWatermark = true;
                    openFileDialog.FileName = txtPath.Text;

                    Image img = Image.FromFile(txtPath.Text);
                    picImg.Image = img;
                    Parameters["Image"] = img;

                    DoChangeEvent();
                    return;
                }
            }
            canWatermark = false;
            picImg.Image = null;
        }

        private void Watermark_LocationChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = (RadioButton)sender;
            if (rbtn.Checked)
            {
                ContentAlignment align = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), rbtn.Tag.ToString());
                Parameters["Align"] = align;

                DoChangeEvent();
            }
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                canWatermark = true;
                txtPath.TextChanged -= new EventHandler(txtPath_TextChanged);
                txtPath.Text = openFileDialog.FileName;
                txtPath.TextChanged += new EventHandler(txtPath_TextChanged);

                Image img = Image.FromFile(openFileDialog.FileName);
                picImg.Image = img;
                Parameters["Image"] = img;

                DoChangeEvent();
            }
        }

        private void Watermark_OffsetChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            if (num.Tag.ToString() == "X")
            {
                Parameters["OffsetX"] = (int)num.Value;
            }
            else
            {
                Parameters["OffsetY"] = (int)num.Value;
            }

            DoChangeEvent();
        }

        private void DoChangeEvent()
        {
            if (canWatermark && OnAfterConfigChanged != null)
            {
                OnAfterConfigChanged(this);
            }
        }
    }
}
