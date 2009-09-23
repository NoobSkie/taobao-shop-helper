using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace TOP.Applications.PicWatermark
{
    // ms-help://MS.VSCC.v90/MS.MSDNQTR.v90.chs/dv_fxmclignrl/html/a27121e6-f7e9-4c09-84e2-f05aa9d2a1bb.htm
    public partial class ctrlWatermarkItem_Text : ctrlWatermarkItem
    {
        private Font currentFont = null;
        private Font CurrentFont
        {
            get
            {
                return currentFont;
            }
            set
            {
                currentFont = value;
                lblFont.Font = currentFont;
            }
        }

        private Color currentColor = Color.Black;
        public Color CurrentColor
        {
            get
            {
                return currentColor;
            }
            set
            {
                currentColor = value;
                lblFont.ForeColor = currentColor;
            }
        }

        public ctrlWatermarkItem_Text()
        {
            InitializeComponent();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = currentFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentColor = fontDialog.Color;
                CurrentFont = fontDialog.Font;
            }
        }

        private void ctrlWatermarkItem_Text_Load(object sender, EventArgs e)
        {
            cbLocation.DataSource = Enum.GetNames(typeof(ContentAlignment));
            CurrentFont = this.Font;
        }

        private void trackTransparency_Scroll(object sender, EventArgs e)
        {
            txtTransparencyValue.Text = trackTransparency.Value.ToString();
        }

        private void txtTransparencyValue_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(txtTransparencyValue.Text, out i))
            {
                if (i < 0)
                {
                    txtTransparencyValue.Text = "0";
                }
                else if (i > 100)
                {
                    txtTransparencyValue.Text = "100";
                }
                else
                {
                    trackTransparency.Value = i;
                }
            }
            else
            {
                txtTransparencyValue.Text = "50";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OnAfterDeleteWatermarkItem != null)
            {
                OnAfterDeleteWatermarkItem(this);
            }
        }

        public override Image Watermark(Image img)
        {
            string text = txtText.Text;
            ContentAlignment align = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), cbLocation.SelectedValue.ToString());
            int x = (int)numX.Value;
            int y = (int)numY.Value;
            int tran = trackTransparency.Value;
            Brush brush = Brushes.Transparent;
            Graphics g = Graphics.FromImage(img);
            g.DrawString("Test", this.Font, new SolidBrush(Color.White), new PointF(10, 10));
            return DrawWatermark(img, text, CurrentFont, new SolidBrush(CurrentColor), 10, 10, 0.5);
        }

        /// <summary>
        /// 给一个位图绘制水印文字
        /// </summary>
        /// <param name="text">水印文本</param>
        /// <param name="x">起始点</param>
        /// <param name="y">起始点</param>
        /// <param name="opacity">不透明度，0~1</param>
        private Bitmap DrawWatermark(Image image, string text, Font font, Brush brush, int x, int y, double opacity)
        {
            Bitmap bm1 = new Bitmap(image);
            Graphics g1 = Graphics.FromImage(bm1);
            //测量水印文字的大小，然后申请一个新的位图
            SizeF sizef = g1.MeasureString(text, font);
            Bitmap bm2 = new Bitmap((int)sizef.Width, (int)sizef.Height);
            Graphics g2 = Graphics.FromImage(bm2);
            g2.DrawImage(bm1, 0, 0, new Rectangle(x, y, bm2.Width, bm2.Height), GraphicsUnit.Pixel);
            g2.DrawString(text, font, brush, 0, 0);
            BitmapData data1 = bm1.LockBits(new Rectangle(0, 0, bm1.Width, bm1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData data2 = bm2.LockBits(new Rectangle(0, 0, bm2.Width, bm2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p1 = (byte*)(void*)data1.Scan0;
                byte* p2 = (byte*)(void*)data2.Scan0;
                for (int j = 0; j < bm2.Height; j++)
                {
                    for (int i = 0; i < bm2.Width; i++)
                    {
                        p1[(y + j) * data1.Stride + (x + i) * 3] = (byte)(p1[(y + j) * data1.Stride + (x + i) * 3] * (1 - opacity) + opacity * p2[j * data2.Stride + i * 3]);
                        p1[(y + j) * data1.Stride + (x + i) * 3 + 1] = (byte)(p1[(y + j) * data1.Stride + (x + i) * 3 + 1] * (1 - opacity) + opacity * p2[j * data2.Stride + i * 3 + 1]);
                        p1[(y + j) * data1.Stride + (x + i) * 3 + 2] = (byte)(p1[(y + j) * data1.Stride + (x + i) * 3 + 2] * (1 - opacity) + opacity * p2[j * data2.Stride + i * 3 + 2]);
                    }
                }
                bm1.UnlockBits(data1);
                bm2.UnlockBits(data2);
            }
            return bm1;
        }

        private void cbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            numX.Enabled = true;
            numY.Enabled = true;
            ContentAlignment align = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), cbLocation.SelectedValue.ToString());
            switch (align)
            {
                case ContentAlignment.TopCenter:
                case ContentAlignment.BottomCenter:
                    numX.Enabled = false;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    numY.Enabled = false;
                    break;
                case ContentAlignment.MiddleCenter:
                    numX.Enabled = false;
                    numY.Enabled = false;
                    break;
            }
        }
    }
}
