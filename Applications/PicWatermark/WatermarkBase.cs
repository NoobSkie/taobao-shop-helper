using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

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

        protected Rectangle CaculateRectangle(Size sizeParent, Orientation orientation, HorizontalAlignment align, int width, int destance, int offsetStart, int offsetEnd)
        {
            Rectangle rect = new Rectangle();
            if (orientation == Orientation.Horizontal)
            {
                rect.Height = width;
                rect.Width = sizeParent.Width - offsetStart - offsetEnd;
                if (align == HorizontalAlignment.Left)
                {
                    rect.Location = new Point(offsetStart, destance);
                }
                else if (align == HorizontalAlignment.Center)
                {
                    rect.Location = new Point(offsetStart, (sizeParent.Height - width) / 2);
                }
                else
                {
                    rect.Location = new Point(offsetStart, sizeParent.Height - width - destance);
                }
            }
            else
            {
                rect.Height = sizeParent.Height - offsetStart - offsetEnd;
                rect.Width = width;
                if (align == HorizontalAlignment.Left)
                {
                    rect.Location = new Point(destance, offsetStart);
                }
                else if (align == HorizontalAlignment.Center)
                {
                    rect.Location = new Point((sizeParent.Width - width) / 2, offsetStart);
                }
                else
                {
                    rect.Location = new Point(sizeParent.Width - width - destance, offsetStart);
                }
            }
            return rect;
        }

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
