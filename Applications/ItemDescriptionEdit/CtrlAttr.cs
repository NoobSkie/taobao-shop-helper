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
    public partial class CtrlAttr : UserControl
    {
        public RemoveItem OnRemoveItem { get; set; }

        public CtrlAttr()
        {
            InitializeComponent();
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OnRemoveItem != null)
            {
                OnRemoveItem(this);
            }
        }

        public string AttrName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public string AttrValue
        {
            get
            {
                return txtValue.Text;
            }
            set
            {
                txtValue.Text = value;
            }
        }
    }
}
