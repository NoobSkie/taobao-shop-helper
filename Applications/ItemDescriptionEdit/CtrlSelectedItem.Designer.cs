namespace TOP.Applications.ItemDescriptionEdit
{
    partial class CtrlSelectedItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgView = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lnkRemove = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imgView)).BeginInit();
            this.SuspendLayout();
            // 
            // imgView
            // 
            this.imgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgView.Location = new System.Drawing.Point(3, 3);
            this.imgView.Name = "imgView";
            this.imgView.Size = new System.Drawing.Size(100, 100);
            this.imgView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgView.TabIndex = 2;
            this.imgView.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(3, 106);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 70);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "名称";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkRemove
            // 
            this.lnkRemove.AutoSize = true;
            this.lnkRemove.Location = new System.Drawing.Point(30, 184);
            this.lnkRemove.Name = "lnkRemove";
            this.lnkRemove.Size = new System.Drawing.Size(31, 13);
            this.lnkRemove.TabIndex = 4;
            this.lnkRemove.TabStop = true;
            this.lnkRemove.Text = "移除";
            this.lnkRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemove_LinkClicked);
            // 
            // CtrlSelectedItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkRemove);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.imgView);
            this.Name = "CtrlSelectedItem";
            this.Size = new System.Drawing.Size(106, 200);
            ((System.ComponentModel.ISupportInitialize)(this.imgView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgView;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.LinkLabel lnkRemove;
    }
}
