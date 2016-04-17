namespace WProject.UiLibrary.Controls.SpecificControls.InnerControls
{
    partial class WpFileItem
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
            this.pbIcon = new WProject.UiLibrary.Controls.WpPictureBox();
            this.lnlName = new WProject.UiLibrary.Controls.WpLabel();
            this.wpLabel1 = new WProject.UiLibrary.Controls.WpLabel();
            this.lblSize = new WProject.UiLibrary.Controls.WpLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnInfo = new WProject.UiLibrary.Controls.WpButton();
            this.btnDelete = new WProject.UiLibrary.Controls.WpButton();
            this.btnSave = new WProject.UiLibrary.Controls.WpButton();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pbIcon.ForeColor = System.Drawing.Color.White;
            this.pbIcon.Image = null;
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.OwnStyle = false;
            this.pbIcon.Size = new System.Drawing.Size(73, 85);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.pbIcon.TabIndex = 0;
            // 
            // lnlName
            // 
            this.lnlName.AutoSize = true;
            this.lnlName.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlName.Location = new System.Drawing.Point(79, 4);
            this.lnlName.Name = "lnlName";
            this.lnlName.Selected = false;
            this.lnlName.Size = new System.Drawing.Size(138, 32);
            this.lnlName.Style = null;
            this.lnlName.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lnlName.TabIndex = 1;
            this.lnlName.Text = "FileName.txt";
            // 
            // wpLabel1
            // 
            this.wpLabel1.AutoSize = true;
            this.wpLabel1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wpLabel1.Location = new System.Drawing.Point(82, 38);
            this.wpLabel1.Name = "wpLabel1";
            this.wpLabel1.Selected = false;
            this.wpLabel1.Size = new System.Drawing.Size(107, 21);
            this.wpLabel1.Style = null;
            this.wpLabel1.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.wpLabel1.TabIndex = 2;
            this.wpLabel1.Text = "Uploaded by : ";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(83, 70);
            this.lblSize.Name = "lblSize";
            this.lblSize.Selected = false;
            this.lblSize.Size = new System.Drawing.Size(28, 15);
            this.lblSize.Style = null;
            this.lblSize.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "0 kb";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(478, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Image = global::WProject.UiLibrary.Properties.Resources.info_s;
            this.btnInfo.Location = new System.Drawing.Point(415, 46);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Selected = false;
            this.btnInfo.Size = new System.Drawing.Size(36, 36);
            this.btnInfo.TabIndex = 6;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::WProject.UiLibrary.Properties.Resources.close_s;
            this.btnDelete.Location = new System.Drawing.Point(457, 46);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Selected = false;
            this.btnDelete.Size = new System.Drawing.Size(36, 36);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::WProject.UiLibrary.Properties.Resources.download_s;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(334, 46);
            this.btnSave.Name = "btnSave";
            this.btnSave.Selected = false;
            this.btnSave.Size = new System.Drawing.Size(75, 36);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // WpFileItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.wpLabel1);
            this.Controls.Add(this.lnlName);
            this.Controls.Add(this.pbIcon);
            this.Name = "WpFileItem";
            this.Size = new System.Drawing.Size(496, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WpPictureBox pbIcon;
        private WpLabel lnlName;
        private WpLabel wpLabel1;
        private WpButton btnSave;
        private WpLabel lblSize;
        private WpButton btnDelete;
        private WpButton btnInfo;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
