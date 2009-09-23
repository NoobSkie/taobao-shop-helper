using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TOP.Applications.ItemDescriptionEdit
{
    public partial class FrmCodeView : Form
    {
        public FrmCodeView()
        {
            InitializeComponent();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtCode.Text);
        }
    }
}
