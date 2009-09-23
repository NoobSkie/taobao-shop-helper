using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TOP.Applications.PicWatermark
{
    public abstract class WatermarkBase : IWatermark
    {
        #region IWatermark Members

        public abstract string Description { get; }

        public abstract CtrlWatermarkConfiguration ConfigurationControl { get; }

        public abstract Image Watermark(Image img);

        public override string ToString()
        {
            return Description;
        }

        #endregion

        protected void CaculateLocation(Size sizeParent, Size sizeChild, ContentAlignment align, int offsetX, int offsetY, out int x, out int y)
        {
            x = offsetX;
            y = offsetY;

            switch (align)
            {
                case ContentAlignment.TopLeft:
                    break;
                case ContentAlignment.TopCenter:
                    x = (int)((sizeParent.Width - sizeChild.Width) / 2) + offsetX;
                    break;
                case ContentAlignment.TopRight:
                    x = (int)(sizeParent.Width - sizeChild.Width) + offsetX;
                    break;
                case ContentAlignment.MiddleLeft:
                    y = (int)((sizeParent.Height - sizeChild.Height) / 2) + offsetY;
                    break;
                case ContentAlignment.MiddleCenter:
                    x = (int)((sizeParent.Width - sizeChild.Width) / 2) + offsetX;
                    y = (int)((sizeParent.Height - sizeChild.Height) / 2) + offsetY;
                    break;
                case ContentAlignment.MiddleRight:
                    x = (int)(sizeParent.Width - sizeChild.Width) + offsetX;
                    y = (int)((sizeParent.Height - sizeChild.Height) / 2) + offsetY;
                    break;
                case ContentAlignment.BottomLeft:
                    y = (int)(sizeParent.Height - sizeChild.Height) + offsetY;
                    break;
                case ContentAlignment.BottomCenter:
                    x = (int)((sizeParent.Width - sizeChild.Width) / 2) + offsetX;
                    y = (int)(sizeParent.Height - sizeChild.Height) + offsetY;
                    break;
                case ContentAlignment.BottomRight:
                    x = (int)(sizeParent.Width - sizeChild.Width) + offsetX;
                    y = (int)(sizeParent.Height - sizeChild.Height) + offsetY;
                    break;
            }
        }
    }
}
