using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TOP.Applications.PicWatermark.V03
{
    public partial class CtrlConfigurationV03 : CtrlWatermarkConfiguration
    {
        public CtrlConfigurationV03()
        {
            InitializeComponent();

            Parameters.Clear();
            Parameters.Add("Orientation", Orientation.Horizontal);
            Parameters.Add("Color", Color.Red);
            Parameters.Add("Width", 60);
            Parameters.Add("Align", HorizontalAlignment.Right);
            Parameters.Add("Distance", 30);
            Parameters.Add("OffsetStart", 0);
            Parameters.Add("OffsetEnd", 0);
            Parameters.Add("Transparency", 50);

            canWatermark = true;
        }

        private void rbtnOrientation_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnX.Checked)
            {
                rbtnTop.Text = "居上";
                rbtnBottom.Text = "居下";
                Parameters["Orientation"] = Orientation.Horizontal;
            }
            else
            {
                rbtnTop.Text = "居左";
                rbtnBottom.Text = "居右";
                Parameters["Orientation"] = Orientation.Vertical;
            }
            DoChangeEvent();
        }

        private void rbtnAlign_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTop.Checked)
            {
                Parameters["Align"] = HorizontalAlignment.Left;
            }
            else if (rbtnMiddle.Checked)
            {
                Parameters["Align"] = HorizontalAlignment.Center;
            }
            else
            {
                Parameters["Align"] = HorizontalAlignment.Right;
            }
            DoChangeEvent();
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Color color = ColorTranslator.FromHtml(txtColor.Text);
                Parameters["Color"] = color;

                canWatermark = true;
                DoChangeEvent();
            }
            catch
            {
                canWatermark = false;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            try
            {
                Color color = ColorTranslator.FromHtml(txtColor.Text);
                colorDialog1.Color = color;
            }
            catch
            {
            }
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                txtColor.Text = ColorTranslator.ToHtml(color);
            }
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            int width;
            if (int.TryParse(txtWidth.Text, out width))
            {
                Parameters["Width"] = width;

                canWatermark = true;
                DoChangeEvent();
            }
            else
            {
                canWatermark = false;
            }
        }

        private void txtDistance_TextChanged(object sender, EventArgs e)
        {
            int distance;
            if (int.TryParse(txtDistance.Text, out distance))
            {
                Parameters["Distance"] = distance;

                canWatermark = true;
                DoChangeEvent();
            }
            else
            {
                canWatermark = false;
            }
        }

        private void txtOffsetStart_TextChanged(object sender, EventArgs e)
        {
            int offsetStart;
            if (int.TryParse(txtOffsetStart.Text, out offsetStart))
            {
                Parameters["OffsetStart"] = offsetStart;

                canWatermark = true;
                DoChangeEvent();
            }
            else
            {
                canWatermark = false;
            }
        }

        private void txtOffsetEnd_TextChanged(object sender, EventArgs e)
        {
            int offsetEnd;
            if (int.TryParse(txtOffsetEnd.Text, out offsetEnd))
            {
                Parameters["OffsetEnd"] = offsetEnd;

                canWatermark = true;
                DoChangeEvent();
            }
            else
            {
                canWatermark = false;
            }
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
