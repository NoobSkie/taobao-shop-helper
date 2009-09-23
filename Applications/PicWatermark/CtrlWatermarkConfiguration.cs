using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace TOP.Applications.PicWatermark
{
    public delegate void AfterConfigChanged(CtrlWatermarkConfiguration configuration);

    public partial class CtrlWatermarkConfiguration : UserControl
    {
        public CtrlWatermarkConfiguration()
        {
            InitializeComponent();
        }

        protected bool canWatermark = false;
        public bool CanWatermark
        {
            get { return canWatermark; }
        }

        public AfterConfigChanged OnAfterConfigChanged { get; set; }

        private ListDictionary parameters = new ListDictionary();
        public ListDictionary Parameters
        {
            get { return parameters; }
        }
    }
}
