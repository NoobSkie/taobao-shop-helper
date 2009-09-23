using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TOP.Applications.PicWatermark
{
    public delegate void AfterDeleteWatermarkItem(ctrlWatermarkItem ctrl);

    public partial class ctrlWatermarkItem : UserControl
    {
        public ctrlWatermarkItem()
        {
            InitializeComponent();
        }

        public AfterDeleteWatermarkItem OnAfterDeleteWatermarkItem { get; set; }

        public virtual Image Watermark(Image img)
        {
            throw new NotImplementedException("其子类必须实现此方法。");
        }
    }
}
