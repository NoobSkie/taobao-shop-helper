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
    public delegate void CancelProgress(CtrlProgress ctrl);

    public partial class CtrlProgress : UserControl
    {
        public CtrlProgress()
        {
            InitializeComponent();
        }

        public CancelProgress OnCancelProgress { get; set; }

        public string Title { get; set; }
        public string Summary { get; set; }
        public int Total { get; set; }
        public int Value { get; set; }
        public int ProgressTotal { get; set; }
        public int ProgressValue { get; set; }

        public void DisplayProgress()
        {
            progressBar.Maximum = ProgressTotal;
            progressBar.Value = ProgressValue;
            if (Total != -1 && Value != -1)
            {
                lblSummary.Text = string.Format("{0}({1}/{2})\n{3}", Title, Value, Total, Summary);
            }
            else
            {
                lblSummary.Text = string.Format("{0}\n{1}", Title, Summary);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (OnCancelProgress != null)
            {
                OnCancelProgress(this);
            }
        }
    }
}
