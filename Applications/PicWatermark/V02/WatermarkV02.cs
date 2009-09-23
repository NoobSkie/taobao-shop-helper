using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TOP.Applications.PicWatermark.V02
{
    public class WatermarkV02 : WatermarkBase
    {
        #region IWatermark Members

        public override string Description
        {
            get { return "图片水印"; }
        }

        private CtrlWatermarkConfiguration configurationControl = null;
        public override CtrlWatermarkConfiguration ConfigurationControl
        {
            get
            {
                if (configurationControl == null)
                {
                    configurationControl = new CtrlConfigurationV02();
                }
                return configurationControl;
            }
        }

        public override Image Watermark(Image img)
        {
            img = (Image)img.Clone();

            Image src = (Image)ConfigurationControl.Parameters["Image"];
            ContentAlignment align = (ContentAlignment)ConfigurationControl.Parameters["Align"];
            int offsetX = (int)ConfigurationControl.Parameters["OffsetX"];
            int offsetY = (int)ConfigurationControl.Parameters["OffsetY"];

            using (Graphics g = Graphics.FromImage(img))
            {
                int x, y;
                // 计算文本位置
                CaculateLocation(img.Size, src.Size, align, offsetX, offsetY, out x, out y);
                // 画图片水印
                g.DrawImageUnscaled(src, x, y);
                return img;
            }
        }

        #endregion
    }
}
