using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace TOP.Applications.PicWatermark.V01
{
    public partial class CtrlConfigurationV01 : CtrlWatermarkConfiguration
    {
        public CtrlConfigurationV01()
        {
            InitializeComponent();

            Parameters.Clear();
            Parameters.Add("Text", "");
            Parameters.Add("Font", this.Font);
            Parameters.Add("Color", Color.Black);
            Parameters.Add("Align", ContentAlignment.MiddleLeft);
            Parameters.Add("OffsetX", 10);
            Parameters.Add("OffsetY", 10);
            Parameters.Add("Transparency", 50);
        }

        private void CtrlConfigurationV01_Load(object sender, EventArgs e)
        {
            lblFont.Text = string.Format("{0} {1} {2}", this.Font.Name, this.Font.Size.ToString() + this.Font.Unit, Color.Black);
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            Parameters["Text"] = txtText.Text;
            if (!string.IsNullOrEmpty(txtText.Text))
            {
                canWatermark = true;

                DoChangeEvent();
            }
            else
            {
                canWatermark = false;
            }
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

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                lblFont.Text = string.Format("{0} {1} {2}", fontDialog.Font.Name, fontDialog.Font.Size.ToString() + fontDialog.Font.Unit, fontDialog.Color);

                Parameters["Font"] = fontDialog.Font;
                Parameters["Color"] = fontDialog.Color;

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

        private void trackTransparency_Scroll(object sender, EventArgs e)
        {
            numTransparencyValue.ValueChanged -= new EventHandler(numTransparencyValue_ValueChanged);
            numTransparencyValue.Value = trackTransparency.Value;
            numTransparencyValue.ValueChanged += new EventHandler(numTransparencyValue_ValueChanged);

            Parameters["Transparency"] = trackTransparency.Value;

            DoChangeEvent();
        }

        private void numTransparencyValue_ValueChanged(object sender, EventArgs e)
        {
            trackTransparency.Value = (int)numTransparencyValue.Value;
            Parameters["Transparency"] = trackTransparency.Value;

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
