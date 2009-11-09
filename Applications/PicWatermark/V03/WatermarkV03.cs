using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TOP.Applications.PicWatermark.V03
{
    public class WatermarkV03 : WatermarkBase
    {
        public override string Description
        {
            get { return "色带水印"; }
        }

        private CtrlWatermarkConfiguration configurationControl = null;
        public override CtrlWatermarkConfiguration ConfigurationControl
        {
            get
            {
                if (configurationControl == null)
                {
                    configurationControl = new CtrlConfigurationV03();
                }
                return configurationControl;
            }
        }

        public override System.Drawing.Image Watermark(System.Drawing.Image img)
        {
            img = (Image)img.Clone();

            Orientation orientation = (Orientation)ConfigurationControl.Parameters["Orientation"];
            Color color = (Color)ConfigurationControl.Parameters["Color"];
            int width = (int)ConfigurationControl.Parameters["Width"];
            HorizontalAlignment align = (HorizontalAlignment)ConfigurationControl.Parameters["Align"];
            int destance = (int)ConfigurationControl.Parameters["Distance"];
            int offsetStart = (int)ConfigurationControl.Parameters["OffsetStart"];
            int offsetEnd = (int)ConfigurationControl.Parameters["OffsetEnd"];
            int trans = (int)ConfigurationControl.Parameters["Transparency"];

            using (Graphics g = Graphics.FromImage(img))
            {
                // 计算透明度 0 - 255 之间
                int o = (int)((trans / 100.00) * 255);
                // 创建具有透明度的画刷
                Brush brush = new SolidBrush(Color.FromArgb(o, color));
                Rectangle rect = CaculateRectangle(img.Size, orientation, align, width, destance, offsetStart, offsetEnd);
                g.FillRectangle(brush, rect);
                return img;
            }
        }
    }
}
