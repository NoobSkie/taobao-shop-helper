using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TOP.Applications.ItemDescriptionEdit
{
    public partial class CtrlImage : UserControl
    {
        public RemoveItem OnRemoveItem { get; set; }

        public CtrlImage()
        {
            InitializeComponent();

            txtPath.LostFocus += new EventHandler(txtPath_LostFocus);
        }

        void txtPath_LostFocus(object sender, EventArgs e)
        {
            Value = txtPath.Text;
        }

        public string Value
        {
            get { return txtPath.Text; }
            set
            {
                txtPath.Text = value;
                try
                {
                    imgView.ImageLocation = value;
                }
                catch { }
            }
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnRemoveItem != null)
            {
                OnRemoveItem(this);
            }
        }
    }
}
