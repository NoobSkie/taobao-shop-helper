namespace TOP.Applications.ItemDescriptionEdit
{
    partial class FrmSelectItems
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
            this.fpnlList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbForce = new System.Windows.Forms.CheckBox();
            this.ucProgress = new TOP.Applications.ItemDescriptionEdit.CtrlProgress();
            this.SuspendLayout();
            // 
            // fpnlList
            // 
            this.fpnlList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlList.AutoScroll = true;
            this.fpnlList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fpnlList.Location = new System.Drawing.Point(12, 41);
            this.fpnlList.Name = "fpnlList";
            this.fpnlList.Size = new System.Drawing.Size(768, 384);
            this.fpnlList.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(12, 431);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(150, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(156, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "更新店铺商品数据";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(112, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "当前商品总数: 45 个";
            // 
            // cbForce
            // 
            this.cbForce.AutoSize = true;
            this.cbForce.Location = new System.Drawing.Point(312, 18);
            this.cbForce.Name = "cbForce";
            this.cbForce.Size = new System.Drawing.Size(74, 17);
            this.cbForce.TabIndex = 5;
            this.cbForce.Text = "强制更新";
            this.cbForce.UseVisualStyleBackColor = true;
            // 
            // ucProgress
            // 
            this.ucProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucProgress.Location = new System.Drawing.Point(150, 180);
            this.ucProgress.Name = "ucProgress";
            this.ucProgress.OnCancelProgress = null;
            this.ucProgress.ProgressTotal = 0;
            this.ucProgress.ProgressValue = 0;
            this.ucProgress.Size = new System.Drawing.Size(500, 80);
            this.ucProgress.Summary = null;
            this.ucProgress.TabIndex = 4;
            this.ucProgress.Title = null;
            this.ucProgress.Total = 0;
            this.ucProgress.Value = 0;
            this.ucProgress.Visible = false;
            // 
            // FrmSelectItems
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.Controls.Add(this.cbForce);
            this.Controls.Add(this.ucProgress);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.fpnlList);
            this.Name = "FrmSelectItems";
            this.Text = "选择类似商品";
            this.Load += new System.EventHandler(this.FrmSelectItems_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fpnlList;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTitle;
        private CtrlProgress ucProgress;
        private System.Windows.Forms.CheckBox cbForce;
    }
}