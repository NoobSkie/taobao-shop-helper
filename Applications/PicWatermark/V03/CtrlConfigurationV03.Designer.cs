namespace TOP.Applications.PicWatermark.V03
{
    partial class CtrlConfigurationV03
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnTop = new System.Windows.Forms.RadioButton();
            this.rbtnBottom = new System.Windows.Forms.RadioButton();
            this.rbtnMiddle = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnX = new System.Windows.Forms.RadioButton();
            this.rbtnY = new System.Windows.Forms.RadioButton();
            this.txtOffsetEnd = new System.Windows.Forms.TextBox();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtOffsetStart = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpTransparency = new System.Windows.Forms.GroupBox();
            this.numTransparencyValue = new System.Windows.Forms.NumericUpDown();
            this.lblRate = new System.Windows.Forms.Label();
            this.trackTransparency = new System.Windows.Forms.TrackBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpTransparency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTransparencyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTransparency)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnColor);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txtOffsetEnd);
            this.groupBox1.Controls.Add(this.txtDistance);
            this.groupBox1.Controls.Add(this.txtOffsetStart);
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基础设置";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(216, 44);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "选择";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnTop);
            this.panel2.Controls.Add(this.rbtnBottom);
            this.panel2.Controls.Add(this.rbtnMiddle);
            this.panel2.Location = new System.Drawing.Point(91, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 21);
            this.panel2.TabIndex = 3;
            // 
            // rbtnTop
            // 
            this.rbtnTop.AutoSize = true;
            this.rbtnTop.Location = new System.Drawing.Point(3, 3);
            this.rbtnTop.Name = "rbtnTop";
            this.rbtnTop.Size = new System.Drawing.Size(49, 17);
            this.rbtnTop.TabIndex = 0;
            this.rbtnTop.Tag = "Left";
            this.rbtnTop.Text = "居上";
            this.rbtnTop.UseVisualStyleBackColor = true;
            this.rbtnTop.CheckedChanged += new System.EventHandler(this.rbtnAlign_CheckedChanged);
            // 
            // rbtnBottom
            // 
            this.rbtnBottom.AutoSize = true;
            this.rbtnBottom.Checked = true;
            this.rbtnBottom.Location = new System.Drawing.Point(113, 3);
            this.rbtnBottom.Name = "rbtnBottom";
            this.rbtnBottom.Size = new System.Drawing.Size(49, 17);
            this.rbtnBottom.TabIndex = 0;
            this.rbtnBottom.TabStop = true;
            this.rbtnBottom.Tag = "Right";
            this.rbtnBottom.Text = "居下";
            this.rbtnBottom.UseVisualStyleBackColor = true;
            this.rbtnBottom.CheckedChanged += new System.EventHandler(this.rbtnAlign_CheckedChanged);
            // 
            // rbtnMiddle
            // 
            this.rbtnMiddle.AutoSize = true;
            this.rbtnMiddle.Location = new System.Drawing.Point(58, 3);
            this.rbtnMiddle.Name = "rbtnMiddle";
            this.rbtnMiddle.Size = new System.Drawing.Size(49, 17);
            this.rbtnMiddle.TabIndex = 0;
            this.rbtnMiddle.Tag = "Center";
            this.rbtnMiddle.Text = "居中";
            this.rbtnMiddle.UseVisualStyleBackColor = true;
            this.rbtnMiddle.CheckedChanged += new System.EventHandler(this.rbtnAlign_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnX);
            this.panel1.Controls.Add(this.rbtnY);
            this.panel1.Location = new System.Drawing.Point(91, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 21);
            this.panel1.TabIndex = 3;
            // 
            // rbtnX
            // 
            this.rbtnX.AutoSize = true;
            this.rbtnX.Checked = true;
            this.rbtnX.Location = new System.Drawing.Point(3, 3);
            this.rbtnX.Name = "rbtnX";
            this.rbtnX.Size = new System.Drawing.Size(49, 17);
            this.rbtnX.TabIndex = 0;
            this.rbtnX.TabStop = true;
            this.rbtnX.Tag = "Horizontal";
            this.rbtnX.Text = "横向";
            this.rbtnX.UseVisualStyleBackColor = true;
            this.rbtnX.CheckedChanged += new System.EventHandler(this.rbtnOrientation_CheckedChanged);
            // 
            // rbtnY
            // 
            this.rbtnY.AutoSize = true;
            this.rbtnY.Location = new System.Drawing.Point(58, 3);
            this.rbtnY.Name = "rbtnY";
            this.rbtnY.Size = new System.Drawing.Size(49, 17);
            this.rbtnY.TabIndex = 0;
            this.rbtnY.Tag = "Vertical";
            this.rbtnY.Text = "纵向";
            this.rbtnY.UseVisualStyleBackColor = true;
            this.rbtnY.CheckedChanged += new System.EventHandler(this.rbtnOrientation_CheckedChanged);
            // 
            // txtOffsetEnd
            // 
            this.txtOffsetEnd.Location = new System.Drawing.Point(91, 177);
            this.txtOffsetEnd.Name = "txtOffsetEnd";
            this.txtOffsetEnd.Size = new System.Drawing.Size(200, 20);
            this.txtOffsetEnd.TabIndex = 2;
            this.txtOffsetEnd.Text = "0";
            this.txtOffsetEnd.TextChanged += new System.EventHandler(this.txtOffsetEnd_TextChanged);
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(91, 125);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(200, 20);
            this.txtDistance.TabIndex = 2;
            this.txtDistance.Text = "30";
            this.txtDistance.TextChanged += new System.EventHandler(this.txtDistance_TextChanged);
            // 
            // txtOffsetStart
            // 
            this.txtOffsetStart.Location = new System.Drawing.Point(91, 151);
            this.txtOffsetStart.Name = "txtOffsetStart";
            this.txtOffsetStart.Size = new System.Drawing.Size(200, 20);
            this.txtOffsetStart.TabIndex = 2;
            this.txtOffsetStart.Text = "0";
            this.txtOffsetStart.TextChanged += new System.EventHandler(this.txtOffsetStart_TextChanged);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(91, 46);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(119, 20);
            this.txtColor.TabIndex = 2;
            this.txtColor.Text = "Red";
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(91, 72);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(200, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "60";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "离库边距离：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "结束端偏差：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "起始端偏差：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "颜色：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "位置：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "宽度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "方向：";
            // 
            // grpTransparency
            // 
            this.grpTransparency.Controls.Add(this.numTransparencyValue);
            this.grpTransparency.Controls.Add(this.lblRate);
            this.grpTransparency.Controls.Add(this.trackTransparency);
            this.grpTransparency.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTransparency.Location = new System.Drawing.Point(0, 210);
            this.grpTransparency.Name = "grpTransparency";
            this.grpTransparency.Size = new System.Drawing.Size(335, 72);
            this.grpTransparency.TabIndex = 4;
            this.grpTransparency.TabStop = false;
            this.grpTransparency.Text = "透明度";
            // 
            // numTransparencyValue
            // 
            this.numTransparencyValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTransparencyValue.Location = new System.Drawing.Point(248, 30);
            this.numTransparencyValue.Name = "numTransparencyValue";
            this.numTransparencyValue.Size = new System.Drawing.Size(60, 20);
            this.numTransparencyValue.TabIndex = 15;
            this.numTransparencyValue.Tag = "Y";
            this.numTransparencyValue.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTransparencyValue.ValueChanged += new System.EventHandler(this.numTransparencyValue_ValueChanged);
            // 
            // lblRate
            // 
            this.lblRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(314, 32);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(15, 13);
            this.lblRate.TabIndex = 13;
            this.lblRate.Text = "%";
            // 
            // trackTransparency
            // 
            this.trackTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackTransparency.Location = new System.Drawing.Point(6, 19);
            this.trackTransparency.Maximum = 100;
            this.trackTransparency.Name = "trackTransparency";
            this.trackTransparency.Size = new System.Drawing.Size(236, 45);
            this.trackTransparency.TabIndex = 11;
            this.trackTransparency.TickFrequency = 5;
            this.trackTransparency.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackTransparency.Value = 50;
            this.trackTransparency.Scroll += new System.EventHandler(this.trackTransparency_Scroll);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // CtrlConfigurationV03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpTransparency);
            this.Controls.Add(this.groupBox1);
            this.Name = "CtrlConfigurationV03";
            this.Size = new System.Drawing.Size(335, 312);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpTransparency.ResumeLayout(false);
            this.grpTransparency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTransparencyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTransparency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnY;
        private System.Windows.Forms.RadioButton rbtnX;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTransparency;
        private System.Windows.Forms.NumericUpDown numTransparencyValue;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.TrackBar trackTransparency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnTop;
        private System.Windows.Forms.RadioButton rbtnMiddle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnBottom;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox txtOffsetEnd;
        private System.Windows.Forms.TextBox txtOffsetStart;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label4;
    }
}
