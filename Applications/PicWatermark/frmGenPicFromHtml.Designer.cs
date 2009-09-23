namespace TOP.Applications.PicWatermark
{
    partial class frmGenPicFromHtml
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnGenPic = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 81);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1002, 423);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // btnGenPic
            // 
            this.btnGenPic.Location = new System.Drawing.Point(12, 12);
            this.btnGenPic.Name = "btnGenPic";
            this.btnGenPic.Size = new System.Drawing.Size(221, 23);
            this.btnGenPic.TabIndex = 0;
            this.btnGenPic.Text = "生成";
            this.btnGenPic.UseVisualStyleBackColor = true;
            this.btnGenPic.Click += new System.EventHandler(this.btnGenPic_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(239, 12);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(211, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "下移";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(856, 20);
            this.textBox1.TabIndex = 3;
            // 
            // frmGenPicFromHtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 516);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnGenPic);
            this.Name = "frmGenPicFromHtml";
            this.Text = "frmGenPicFromHtml";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnGenPic;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.TextBox textBox1;
    }
}