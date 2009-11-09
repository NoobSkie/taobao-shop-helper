namespace TOP.Applications.PicWatermark.V02
{
    partial class CtrlConfigurationV02
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
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.lblY = new System.Windows.Forms.Label();
            this.lblOffset = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.rbtnBottomRight = new System.Windows.Forms.RadioButton();
            this.rbtnBottomCenter = new System.Windows.Forms.RadioButton();
            this.grpLocation = new System.Windows.Forms.GroupBox();
            this.rbtnBottomLeft = new System.Windows.Forms.RadioButton();
            this.rbtnMiddleRight = new System.Windows.Forms.RadioButton();
            this.rbtnMiddleCenter = new System.Windows.Forms.RadioButton();
            this.rbtnMiddleLeft = new System.Windows.Forms.RadioButton();
            this.rbtnTopRight = new System.Windows.Forms.RadioButton();
            this.rbtnTopCenter = new System.Windows.Forms.RadioButton();
            this.rbtnTopLeft = new System.Windows.Forms.RadioButton();
            this.grpFont = new System.Windows.Forms.GroupBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.btnImg = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.grpLocation.SuspendLayout();
            this.grpFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();
            // 
            // numY
            // 
            this.numY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numY.Location = new System.Drawing.Point(296, 83);
            this.numY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(48, 20);
            this.numY.TabIndex = 15;
            this.numY.Tag = "Y";
            this.numY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numY.ValueChanged += new System.EventHandler(this.Watermark_OffsetChanged);
            // 
            // numX
            // 
            this.numX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numX.Location = new System.Drawing.Point(296, 53);
            this.numX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(48, 20);
            this.numX.TabIndex = 16;
            this.numX.Tag = "X";
            this.numX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numX.ValueChanged += new System.EventHandler(this.Watermark_OffsetChanged);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(228, 84);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(62, 13);
            this.lblY.TabIndex = 13;
            this.lblY.Text = "Y（纵向）";
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(228, 25);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(91, 13);
            this.lblOffset.TabIndex = 14;
            this.lblOffset.Text = "位移偏差量设置";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(228, 55);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(62, 13);
            this.lblX.TabIndex = 14;
            this.lblX.Text = "X（横向）";
            // 
            // rbtnBottomRight
            // 
            this.rbtnBottomRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnBottomRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnBottomRight.Location = new System.Drawing.Point(148, 79);
            this.rbtnBottomRight.Name = "rbtnBottomRight";
            this.rbtnBottomRight.Size = new System.Drawing.Size(50, 24);
            this.rbtnBottomRight.TabIndex = 0;
            this.rbtnBottomRight.Tag = "BottomRight";
            this.rbtnBottomRight.Text = "右下";
            this.rbtnBottomRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBottomRight.UseVisualStyleBackColor = true;
            this.rbtnBottomRight.CheckedChanged += new System.EventHandler(this.Watermark_LocationChanged);
            // 
            // rbtnBottomCenter
            // 
            this.rbtnBottomCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnBottomCenter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnBottomCenter.Location = new System.Drawing.Point(62, 79);
            this.rbtnBottomCenter.Name = "rbtnBottomCenter";
            this.rbtnBottomCenter.Size = new System.Drawing.Size(80, 24);
            this.rbtnBottomCenter.TabIndex = 0;
            this.rbtnBottomCenter.Tag = "BottomCenter";
            this.rbtnBottomCenter.Text = "中下";
            this.rbtnBottomCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBottomCenter.UseVisualStyleBackColor = true;
            this.rbtnBottomCenter.CheckedChanged += new System.EventHandler(this.Watermark_LocationChanged);
            // 
            // grpLocation
            // 
            this.grpLocation.Controls.Add(this.numY);
            this.grpLocation.Controls.Add(this.numX);
            this.grpLocation.Controls.Add(this.lblY);
            this.grpLocation.Controls.Add(this.lblOffset);
            this.grpLocation.Controls.Add(this.lblX);
            this.grpLocation.Controls.Add(this.rbtnBottomRight);
            this.grpLocation.Controls.Add(this.rbtnBottomCenter);
            this.grpLocation.Controls.Add(this.rbtnBottomLeft);
            this.grpLocation.Controls.Add(this.rbtnMiddleRight);
            this.grpLocation.Controls.Add(this.rbtnMiddleCenter);
            this.grpLocation.Controls.Add(this.rbtnMiddleLeft);
            this.grpLocation.Controls.Add(this.rbtnTopRight);
            this.grpLocation.Controls.Add(this.rbtnTopCenter);
            this.grpLocation.Controls.Add(this.rbtnTopLeft);
            this.grpLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLocation.Location = new System.Drawing.Point(0, 106);
            this.grpLocation.Name = "grpLocation";
            this.grpLocation.Size = new System.Drawing.Size(350, 115);
            this.grpLocation.TabIndex = 6;
            this.grpLocation.TabStop = false;
            this.grpLocation.Text = "定位";
            // 
            // rbtnBottomLeft
            // 
            this.rbtnBottomLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnBottomLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnBottomLeft.Location = new System.Drawing.Point(6, 79);
            this.rbtnBottomLeft.Name = "rbtnBottomLeft";
            this.rbtnBottomLeft.Size = new System.Drawing.Size(50, 24);
            this.rbtnBottomLeft.TabIndex = 0;
            this.rbtnBottomLeft.Tag = "BottomLeft";
            this.rbtnBottomLeft.Text = "左下";
            this.rbtnBottomLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBottomLeft.UseVisualStyleBackColor = true;
            this.rbtnBottomLeft.CheckedChanged += new System.EventHandler(this.Watermark_LocationChanged);
            // 
            // rbtnMiddleRight
            // 
            this.rbtnMiddleRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnMiddleRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnMiddleRight.Location = new System.Drawing.Point(148, 49);
            this.rbtnMiddleRight.Name = "rbtnMiddleRight";
            this.rbtnMiddleRight.Size = new System.Drawing.Size(50, 24);
            this.rbtnMiddleRight.TabIndex = 0;
            this.rbtnMiddleRight.Tag = "MiddleRight";
            this.rbtnMiddleRight.Text = "右中";
            this.rbtnMiddleRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnMiddleRight.UseVisualStyleBackColor = true;
            this.rbtnMiddleRight.CheckedChanged += new System.EventHandler(this.Watermark_LocationChanged);
            // 
            // rbtnMiddleCenter
            // 
            this.rbtnMiddleCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnMiddleCenter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnMiddleCenter.Location = new System.Drawing.Point(62, 49);
            this.rbtnMiddleCenter.Name = "rbtnMiddleCenter";
            this.rbtnMiddleCenter.Size = new System.Drawing.Size(80, 24);
            this.rbtnMiddleCenter.TabIndex = 0;
            this.rbtnMiddleCenter.Tag = "MiddleCenter";
            this.rbtnMiddleCenter.Text = "正中";
            this.rbtnMiddleCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnMiddleCenter.UseVisualStyleBackColor = true;
            this.rbtnMiddleCenter.CheckedChanged += new System.EventHandler(this.Watermark_LocationChanged);
            // 
            // rbtnMiddleLeft
            // 
            this.rbtnMiddleLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnMiddleLeft.Checked = true;
            this.rbtnMiddleLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnMiddleLeft.Location = new System.Drawing.Point(6, 49);
            this.rbtnMiddleLeft.Name = "rbtnMiddleLeft";
            this.rbtnMiddleLeft.Size = new System.Drawing.Size(50, 24);
            this.rbtnMiddleLeft.TabIndex = 0;
            this.rbtnMiddleLeft.TabStop = true;
            this.rbtnMiddleLeft.Tag = "MiddleLeft";
            this.rbtnMiddleLeft.Text = "左中";
            this.rbtnMiddleLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnMiddleLeft.UseVisualStyleBackColor = true;
            this.rbtnMiddleLeft.CheckedChanged += new System.EventHandler(this.Watermark_LocationChanged);
            // 
            // rbtnTopRight
            // 
            this.rbtnTopRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnTopRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnTopRight.Location = new System.Drawing.Point(148, 19);
            this.rbtnTopRight.Name = "rbtnTopRight";
            this.rbtnTopRight.Size = new System.Drawing.Size(50, 24);
            this.rbtnTopRight.TabIndex = 0;
            this.rbtnTopRight.Tag = "TopRight";
            this.rbtnTopRight.Text = "右上";
            this.rbtnTopRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnTopRight.UseVisualStyleBackColor = true;
            this.rbtnTopRight.CheckedChanged += new System.EventHandler(this.Watermark_LocationChanged);
            // 
            // rbtnTopCenter
            // 
            this.rbtnTopCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnTopCenter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnTopCenter.Location = new System.Drawing.Point(62, 19);
            this.rbtnTopCenter.Name = "rbtnTopCenter";
            this.rbtnTopCenter.Size = new System.Drawing.Size(80, 24);
            this.rbtnTopCenter.TabIndex = 0;
            this.rbtnTopCenter.Tag = "TopCenter";
            this.rbtnTopCenter.Text = "中上";
            this.rbtnTopCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnTopCenter.UseVisualStyleBackColor = true;
            this.rbtnTopCenter.CheckedChanged += new System.EventHandler(this.Watermark_LocationChanged);
            // 
            // rbtnTopLeft
            // 
            this.rbtnTopLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnTopLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnTopLeft.Location = new System.Drawing.Point(6, 19);
            this.rbtnTopLeft.Name = "rbtnTopLeft";
            this.rbtnTopLeft.Size = new System.Drawing.Size(50, 24);
            this.rbtnTopLeft.TabIndex = 0;
            this.rbtnTopLeft.Tag = "TopLeft";
            this.rbtnTopLeft.Text = "左上";
            this.rbtnTopLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnTopLeft.UseVisualStyleBackColor = true;
            this.rbtnTopLeft.CheckedChanged += new System.EventHandler(this.Watermark_LocationChanged);
            // 
            // grpFont
            // 
            this.grpFont.Controls.Add(this.txtPath);
            this.grpFont.Controls.Add(this.picImg);
            this.grpFont.Controls.Add(this.btnImg);
            this.grpFont.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFont.Location = new System.Drawing.Point(0, 0);
            this.grpFont.Name = "grpFont";
            this.grpFont.Size = new System.Drawing.Size(350, 106);
            this.grpFont.TabIndex = 5;
            this.grpFont.TabStop = false;
            this.grpFont.Text = "字体";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(6, 48);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(254, 52);
            this.txtPath.TabIndex = 2;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // picImg
            // 
            this.picImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImg.Location = new System.Drawing.Point(266, 19);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(78, 81);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImg.TabIndex = 1;
            this.picImg.TabStop = false;
            // 
            // btnImg
            // 
            this.btnImg.Location = new System.Drawing.Point(6, 19);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(100, 23);
            this.btnImg.TabIndex = 0;
            this.btnImg.Text = "选择图片";
            this.btnImg.UseVisualStyleBackColor = true;
            this.btnImg.Click += new System.EventHandler(this.btnImg_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "图片文件|*.jpg";
            // 
            // CtrlConfigurationV02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpLocation);
            this.Controls.Add(this.grpFont);
            this.MinimumSize = new System.Drawing.Size(350, 224);
            this.Name = "CtrlConfigurationV02";
            this.Size = new System.Drawing.Size(350, 224);
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.grpLocation.ResumeLayout(false);
            this.grpLocation.PerformLayout();
            this.grpFont.ResumeLayout(false);
            this.grpFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.RadioButton rbtnBottomRight;
        private System.Windows.Forms.RadioButton rbtnBottomCenter;
        private System.Windows.Forms.GroupBox grpLocation;
        private System.Windows.Forms.RadioButton rbtnBottomLeft;
        private System.Windows.Forms.RadioButton rbtnMiddleRight;
        private System.Windows.Forms.RadioButton rbtnMiddleCenter;
        private System.Windows.Forms.RadioButton rbtnMiddleLeft;
        private System.Windows.Forms.RadioButton rbtnTopRight;
        private System.Windows.Forms.RadioButton rbtnTopCenter;
        private System.Windows.Forms.RadioButton rbtnTopLeft;
        private System.Windows.Forms.GroupBox grpFont;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}
