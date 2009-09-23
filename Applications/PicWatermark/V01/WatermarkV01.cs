using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace TOP.Applications.PicWatermark.V01
{
    public class WatermarkV01 : WatermarkBase
    {
        #region IWatermark Members

        public override string Description
        {
            get { return "文字水印"; }
        }

        private CtrlWatermarkConfiguration configurationControl = null;
        public override CtrlWatermarkConfiguration ConfigurationControl
        {
            get
            {
                if (configurationControl == null)
                {
                    configurationControl = new CtrlConfigurationV01();
                }
                return configurationControl;
            }
        }

        public override Image Watermark(Image img)
        {
            img = (Image)img.Clone();
            string text = (string)ConfigurationControl.Parameters["Text"];
            Font font = (Font)ConfigurationControl.Parameters["Font"];
            Color color = (Color)ConfigurationControl.Parameters["Color"];
            ContentAlignment align = (ContentAlignment)ConfigurationControl.Parameters["Align"];
            int offsetX = (int)ConfigurationControl.Parameters["OffsetX"];
            int offsetY = (int)ConfigurationControl.Parameters["OffsetY"];
            int trans = (int)ConfigurationControl.Parameters["Transparency"];

            using (Graphics g = Graphics.FromImage(img))
            {
                int x, y;
                Size size = g.MeasureString(text, font).ToSize();
                // 计算文本位置
                CaculateLocation(img.Size, size, align, offsetX, offsetY, out x, out y);
                // 计算透明度 0 - 255 之间
                int o = (int)((trans / 100.00) * 255);
                // 创建具有透明度的画刷
                Brush b = new SolidBrush(Color.FromArgb(o, color));
                // 写水印文字
                g.DrawString(text, font, b, new PointF(x, y));
                return img;
            }
        }

        #endregion
    }
}
