namespace TOP.Applications.ItemDescriptionEdit
{
    partial class CtrlItem
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
            this.cb = new System.Windows.Forms.CheckBox();
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
            this.imgView.TabIndex = 0;
            this.imgView.TabStop = false;
            // 
            // cb
            // 
            this.cb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb.Location = new System.Drawing.Point(3, 109);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(100, 88);
            this.cb.TabIndex = 1;
            this.cb.Text = "选择";
            this.cb.UseVisualStyleBackColor = true;
            // 
            // CtrlItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.cb);
            this.Controls.Add(this.imgView);
            this.Name = "CtrlItem";
            this.Size = new System.Drawing.Size(106, 200);
            ((System.ComponentModel.ISupportInitialize)(this.imgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgView;
        private System.Windows.Forms.CheckBox cb;


    }
}
