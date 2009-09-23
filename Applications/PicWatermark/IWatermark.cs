using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TOP.Applications.PicWatermark
{
    public interface IWatermark
    {
        string Description { get; }

        CtrlWatermarkConfiguration ConfigurationControl { get; }

        Image Watermark(Image img);
    }
}
