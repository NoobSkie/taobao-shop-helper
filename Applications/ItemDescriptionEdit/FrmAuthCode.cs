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
    public partial class FrmAuthCode : Form
    {
        public FrmAuthCode()
        {
            InitializeComponent();
        }

        private void FrmAuthCode_Load(object sender, EventArgs e)
        {
            webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(string.Format("http://auth.open.taobao.com/authorize/?appkey={0}", "12003014"));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            MessageBox.Show(webBrowser1.DocumentText);
        }
    }
}
