namespace TOP.Applications.PicWatermark
{
    partial class frmWatermark
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
            this.components = new System.ComponentModel.Container();
            this.grpIn = new System.Windows.Forms.GroupBox();
            this.cbSub = new System.Windows.Forms.CheckBox();
            this.btnFolderIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIn = new System.Windows.Forms.TextBox();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.listOptions = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.miMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cbOption = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.grpOut = new System.Windows.Forms.GroupBox();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.btnFolderOut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grpOperate = new System.Windows.Forms.GroupBox();
            this.progressBarEvent = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialogIn = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogOut = new System.Windows.Forms.FolderBrowserDialog();
            this.lblMsg = new System.Windows.Forms.Label();
            this.grpIn.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.grpOut.SuspendLayout();
            this.grpOperate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpIn
            // 
            this.grpIn.Controls.Add(this.cbSub);
            this.grpIn.Controls.Add(this.btnFolderIn);
            this.grpIn.Controls.Add(this.label1);
            this.grpIn.Controls.Add(this.txtIn);
            this.grpIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpIn.Location = new System.Drawing.Point(0, 0);
            this.grpIn.Name = "grpIn";
            this.grpIn.Size = new System.Drawing.Size(990, 69);
            this.grpIn.TabIndex = 0;
            this.grpIn.TabStop = false;
            this.grpIn.Text = "图片定位";
            // 
            // cbSub
            // 
            this.cbSub.AutoSize = true;
            this.cbSub.Checked = true;
            this.cbSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSub.Location = new System.Drawing.Point(85, 45);
            this.cbSub.Name = "cbSub";
            this.cbSub.Size = new System.Drawing.Size(122, 17);
            this.cbSub.TabIndex = 3;
            this.cbSub.Text = "包含所有子文件夹";
            this.cbSub.UseVisualStyleBackColor = true;
            // 
            // btnFolderIn
            // 
            this.btnFolderIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderIn.Location = new System.Drawing.Point(909, 18);
            this.btnFolderIn.Name = "btnFolderIn";
            this.btnFolderIn.Size = new System.Drawing.Size(75, 20);
            this.btnFolderIn.TabIndex = 2;
            this.btnFolderIn.Text = "选择";
            this.btnFolderIn.UseVisualStyleBackColor = true;
            this.btnFolderIn.Click += new System.EventHandler(this.btnFolderIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择文件夹";
            // 
            // txtIn
            // 
            this.txtIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIn.Location = new System.Drawing.Point(85, 19);
            this.txtIn.Name = "txtIn";
            this.txtIn.ReadOnly = true;
            this.txtIn.Size = new System.Drawing.Size(818, 20);
            this.txtIn.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.pnlConfig);
            this.grpOption.Controls.Add(this.listOptions);
            this.grpOption.Controls.Add(this.cbOption);
            this.grpOption.Controls.Add(this.btnSave);
            this.grpOption.Controls.Add(this.btnView);
            this.grpOption.Controls.Add(this.picImg);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.Location = new System.Drawing.Point(0, 69);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(990, 498);
            this.grpOption.TabIndex = 1;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "水印选项";
            // 
            // pnlConfig
            // 
            this.pnlConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlConfig.Location = new System.Drawing.Point(6, 185);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(400, 307);
            this.pnlConfig.TabIndex = 8;
            // 
            // listOptions
            // 
            this.listOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listOptions.ContextMenuStrip = this.contextMenuStrip;
            this.listOptions.FormattingEnabled = true;
            this.listOptions.IntegralHeight = false;
            this.listOptions.Location = new System.Drawing.Point(6, 46);
            this.listOptions.Name = "listOptions";
            this.listOptions.ScrollAlwaysVisible = true;
            this.listOptions.Size = new System.Drawing.Size(400, 133);
            this.listOptions.TabIndex = 7;
            this.listOptions.SelectedIndexChanged += new System.EventHandler(this.listOptions_SelectedIndexChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMoveUp,
            this.miMoveDown,
            this.toolStripSeparator1,
            this.miDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(138, 76);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // miMoveUp
            // 
            this.miMoveUp.Name = "miMoveUp";
            this.miMoveUp.Size = new System.Drawing.Size(137, 22);
            this.miMoveUp.Text = "向上移动(&U)";
            this.miMoveUp.Click += new System.EventHandler(this.miMoveUp_Click);
            // 
            // miMoveDown
            // 
            this.miMoveDown.Name = "miMoveDown";
            this.miMoveDown.Size = new System.Drawing.Size(137, 22);
            this.miMoveDown.Text = "向下移动(&D)";
            this.miMoveDown.Click += new System.EventHandler(this.miMoveDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(137, 22);
            this.miDelete.Text = "删除水印(&R)";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // cbOption
            // 
            this.cbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOption.FormattingEnabled = true;
            this.cbOption.Items.AddRange(new object[] {
            "--添加水印--",
            "文本水印",
            "图片水印"});
            this.cbOption.Location = new System.Drawing.Point(6, 19);
            this.cbOption.Name = "cbOption";
            this.cbOption.Size = new System.Drawing.Size(150, 21);
            this.cbOption.TabIndex = 6;
            this.cbOption.SelectedIndexChanged += new System.EventHandler(this.cbOption_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(288, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 21);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存图片";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(162, 19);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(120, 21);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "选择图片";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // picImg
            // 
            this.picImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImg.Location = new System.Drawing.Point(412, 46);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(572, 446);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImg.TabIndex = 0;
            this.picImg.TabStop = false;
            // 
            // grpOut
            // 
            this.grpOut.Controls.Add(this.txtOut);
            this.grpOut.Controls.Add(this.btnFolderOut);
            this.grpOut.Controls.Add(this.label2);
            this.grpOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpOut.Location = new System.Drawing.Point(0, 567);
            this.grpOut.Name = "grpOut";
            this.grpOut.Size = new System.Drawing.Size(990, 51);
            this.grpOut.TabIndex = 2;
            this.grpOut.TabStop = false;
            this.grpOut.Text = "图片输出";
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOut.Location = new System.Drawing.Point(85, 19);
            this.txtOut.Name = "txtOut";
            this.txtOut.ReadOnly = true;
            this.txtOut.Size = new System.Drawing.Size(818, 20);
            this.txtOut.TabIndex = 0;
            // 
            // btnFolderOut
            // 
            this.btnFolderOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderOut.Location = new System.Drawing.Point(909, 18);
            this.btnFolderOut.Name = "btnFolderOut";
            this.btnFolderOut.Size = new System.Drawing.Size(75, 21);
            this.btnFolderOut.TabIndex = 2;
            this.btnFolderOut.Text = "选择";
            this.btnFolderOut.UseVisualStyleBackColor = true;
            this.btnFolderOut.Click += new System.EventHandler(this.btnFolderOut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "选择文件夹";
            // 
            // grpOperate
            // 
            this.grpOperate.Controls.Add(this.progressBarEvent);
            this.grpOperate.Controls.Add(this.btnCancel);
            this.grpOperate.Controls.Add(this.lblMsg);
            this.grpOperate.Controls.Add(this.btnExport);
            this.grpOperate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpOperate.Location = new System.Drawing.Point(0, 618);
            this.grpOperate.Name = "grpOperate";
            this.grpOperate.Size = new System.Drawing.Size(990, 78);
            this.grpOperate.TabIndex = 3;
            this.grpOperate.TabStop = false;
            this.grpOperate.Text = "操作";
            // 
            // progressBarEvent
            // 
            this.progressBarEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarEvent.Location = new System.Drawing.Point(6, 48);
            this.progressBarEvent.Name = "progressBarEvent";
            this.progressBarEvent.Size = new System.Drawing.Size(897, 23);
            this.progressBarEvent.TabIndex = 1;
            this.progressBarEvent.Value = 50;
            this.progressBarEvent.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(909, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(6, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "执行批量添加水印";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // openImage
            // 
            this.openImage.Filter = "图片文件|*.jpg";
            this.openImage.Title = "请选择图片";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "图片文件|*.jpg";
            // 
            // folderBrowserDialogIn
            // 
            this.folderBrowserDialogIn.ShowNewFolderButton = false;
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.AutoEllipsis = true;
            this.lblMsg.Location = new System.Drawing.Point(162, 19);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(822, 23);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsg.Visible = false;
            // 
            // frmWatermark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 696);
            this.Controls.Add(this.grpOption);
            this.Controls.Add(this.grpOut);
            this.Controls.Add(this.grpIn);
            this.Controls.Add(this.grpOperate);
            this.Name = "frmWatermark";
            this.Text = "水印处理工具";
            this.Load += new System.EventHandler(this.frmWatermark_Load);
            this.grpIn.ResumeLayout(false);
            this.grpIn.PerformLayout();
            this.grpOption.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.grpOut.ResumeLayout(false);
            this.grpOut.PerformLayout();
            this.grpOperate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpIn;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.GroupBox grpOut;
        private System.Windows.Forms.GroupBox grpOperate;
        private System.Windows.Forms.CheckBox cbSub;
        private System.Windows.Forms.Button btnFolderIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIn;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Button btnFolderOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOption;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.OpenFileDialog openImage;
        private System.Windows.Forms.ListBox listOptions;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem miMoveUp;
        private System.Windows.Forms.ToolStripMenuItem miMoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogIn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOut;
        private System.Windows.Forms.ProgressBar progressBarEvent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMsg;
    }
}

