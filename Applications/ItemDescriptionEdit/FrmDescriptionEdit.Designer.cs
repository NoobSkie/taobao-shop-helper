namespace TOP.Applications.ItemDescriptionEdit
{
    partial class FrmDescriptionEdit
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fpnlImageList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnAddAttr = new System.Windows.Forms.Button();
            this.fpnlAttrList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelectItems = new System.Windows.Forms.Button();
            this.fpnlItemList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCode = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // fpnlImageList
            // 
            this.fpnlImageList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlImageList.AutoScroll = true;
            this.fpnlImageList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fpnlImageList.Location = new System.Drawing.Point(12, 41);
            this.fpnlImageList.Name = "fpnlImageList";
            this.fpnlImageList.Size = new System.Drawing.Size(500, 438);
            this.fpnlImageList.TabIndex = 1;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(12, 12);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(75, 23);
            this.btnAddImage.TabIndex = 2;
            this.btnAddImage.Text = "添加图片";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnAddAttr
            // 
            this.btnAddAttr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAttr.Location = new System.Drawing.Point(518, 12);
            this.btnAddAttr.Name = "btnAddAttr";
            this.btnAddAttr.Size = new System.Drawing.Size(75, 23);
            this.btnAddAttr.TabIndex = 2;
            this.btnAddAttr.Text = "添加属性";
            this.btnAddAttr.UseVisualStyleBackColor = true;
            this.btnAddAttr.Click += new System.EventHandler(this.btnAddAttr_Click);
            // 
            // fpnlAttrList
            // 
            this.fpnlAttrList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlAttrList.AutoScroll = true;
            this.fpnlAttrList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fpnlAttrList.Location = new System.Drawing.Point(518, 41);
            this.fpnlAttrList.Name = "fpnlAttrList";
            this.fpnlAttrList.Size = new System.Drawing.Size(484, 205);
            this.fpnlAttrList.TabIndex = 3;
            // 
            // btnSelectItems
            // 
            this.btnSelectItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectItems.Location = new System.Drawing.Point(518, 252);
            this.btnSelectItems.Name = "btnSelectItems";
            this.btnSelectItems.Size = new System.Drawing.Size(112, 23);
            this.btnSelectItems.TabIndex = 2;
            this.btnSelectItems.Text = "选择类似商品";
            this.btnSelectItems.UseVisualStyleBackColor = true;
            this.btnSelectItems.Click += new System.EventHandler(this.btnSelectItems_Click);
            // 
            // fpnlItemList
            // 
            this.fpnlItemList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlItemList.AutoScroll = true;
            this.fpnlItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fpnlItemList.Location = new System.Drawing.Point(518, 281);
            this.fpnlItemList.Name = "fpnlItemList";
            this.fpnlItemList.Size = new System.Drawing.Size(484, 244);
            this.fpnlItemList.TabIndex = 3;
            // 
            // btnCode
            // 
            this.btnCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCode.Location = new System.Drawing.Point(12, 485);
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(200, 40);
            this.btnCode.TabIndex = 2;
            this.btnCode.Text = "生成代码并复制";
            this.btnCode.UseVisualStyleBackColor = true;
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(218, 499);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(100, 23);
            this.lblMsg.TabIndex = 4;
            this.lblMsg.Text = "完成";
            this.lblMsg.Visible = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(362, 485);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 40);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmDescriptionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 537);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.fpnlItemList);
            this.Controls.Add(this.fpnlAttrList);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCode);
            this.Controls.Add(this.btnSelectItems);
            this.Controls.Add(this.btnAddAttr);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.fpnlImageList);
            this.Name = "FrmDescriptionEdit";
            this.Text = "模板描述";
            this.Load += new System.EventHandler(this.FrmDescriptionEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FlowLayoutPanel fpnlImageList;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnAddAttr;
        private System.Windows.Forms.FlowLayoutPanel fpnlAttrList;
        private System.Windows.Forms.Button btnSelectItems;
        private System.Windows.Forms.FlowLayoutPanel fpnlItemList;
        private System.Windows.Forms.Button btnCode;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnClear;
    }
}

