namespace WProject.Controls.MainPageControls.Admin_controls
{
    partial class ctrlUserEdit
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
            this.txtName = new WProject.UiLibrary.Controls.WpTextBox();
            this.lblName = new WProject.UiLibrary.Controls.WpLabel();
            this.lblMail = new WProject.UiLibrary.Controls.WpLabel();
            this.txtMail = new WProject.UiLibrary.Controls.WpTextBox();
            this.lblPass = new WProject.UiLibrary.Controls.WpLabel();
            this.txtPass = new WProject.UiLibrary.Controls.WpTextBox();
            this.chkAdvanceSettings = new WProject.UiLibrary.Controls.WpCheckBox();
            this.btnDelete = new WProject.UiLibrary.Controls.WpButton();
            this.chkSuspended = new WProject.UiLibrary.Controls.WpCheckBox();
            this.btnSave = new WProject.UiLibrary.Controls.WpButton();
            this.btnCancel = new WProject.UiLibrary.Controls.WpButton();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.LeftButton = null;
            this.txtName.Location = new System.Drawing.Point(114, 9);
            this.txtName.Name = "txtName";
            this.txtName.ShowClear = false;
            this.txtName.Size = new System.Drawing.Size(271, 29);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 13);
            this.lblName.Name = "lblName";
            this.lblName.Selected = false;
            this.lblName.Size = new System.Drawing.Size(52, 21);
            this.lblName.Style = null;
            this.lblName.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(12, 61);
            this.lblMail.Name = "lblMail";
            this.lblMail.Selected = false;
            this.lblMail.Size = new System.Drawing.Size(40, 21);
            this.lblMail.Style = null;
            this.lblMail.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "Mail";
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.LeftButton = null;
            this.txtMail.Location = new System.Drawing.Point(114, 57);
            this.txtMail.Name = "txtMail";
            this.txtMail.ShowClear = false;
            this.txtMail.Size = new System.Drawing.Size(271, 29);
            this.txtMail.TabIndex = 2;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(12, 108);
            this.lblPass.Name = "lblPass";
            this.lblPass.Selected = false;
            this.lblPass.Size = new System.Drawing.Size(41, 21);
            this.lblPass.Style = null;
            this.lblPass.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Pass";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.LeftButton = null;
            this.txtPass.Location = new System.Drawing.Point(114, 104);
            this.txtPass.Name = "txtPass";
            this.txtPass.ShowClear = false;
            this.txtPass.Size = new System.Drawing.Size(271, 29);
            this.txtPass.TabIndex = 4;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // chkAdvanceSettings
            // 
            this.chkAdvanceSettings.AutoSize = true;
            this.chkAdvanceSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdvanceSettings.Location = new System.Drawing.Point(224, 147);
            this.chkAdvanceSettings.Name = "chkAdvanceSettings";
            this.chkAdvanceSettings.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.chkAdvanceSettings.Selected = false;
            this.chkAdvanceSettings.Size = new System.Drawing.Size(161, 21);
            this.chkAdvanceSettings.Style = null;
            this.chkAdvanceSettings.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.chkAdvanceSettings.TabIndex = 6;
            this.chkAdvanceSettings.Text = "Advanced settings";
            this.chkAdvanceSettings.OnCheckChanged += new System.EventHandler(this.chkAdvanceSettings_OnCheckChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(227, 171);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Selected = false;
            this.btnDelete.Size = new System.Drawing.Size(158, 40);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete user";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkSuspended
            // 
            this.chkSuspended.AutoSize = true;
            this.chkSuspended.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSuspended.Location = new System.Drawing.Point(12, 147);
            this.chkSuspended.Name = "chkSuspended";
            this.chkSuspended.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.chkSuspended.Selected = false;
            this.chkSuspended.Size = new System.Drawing.Size(112, 21);
            this.chkSuspended.Style = null;
            this.chkSuspended.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.chkSuspended.TabIndex = 8;
            this.chkSuspended.Text = "Suspended";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(227, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Selected = false;
            this.btnSave.Size = new System.Drawing.Size(158, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(3, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Selected = false;
            this.btnCancel.Size = new System.Drawing.Size(158, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctrlUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkSuspended);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.chkAdvanceSettings);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Name = "ctrlUserEdit";
            this.Size = new System.Drawing.Size(397, 288);
            this.Load += new System.EventHandler(this.ctrlUserEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UiLibrary.Controls.WpTextBox txtName;
        private UiLibrary.Controls.WpLabel lblName;
        private UiLibrary.Controls.WpLabel lblMail;
        private UiLibrary.Controls.WpTextBox txtMail;
        private UiLibrary.Controls.WpLabel lblPass;
        private UiLibrary.Controls.WpTextBox txtPass;
        private UiLibrary.Controls.WpCheckBox chkAdvanceSettings;
        private UiLibrary.Controls.WpButton btnDelete;
        private UiLibrary.Controls.WpCheckBox chkSuspended;
        private UiLibrary.Controls.WpButton btnSave;
        private UiLibrary.Controls.WpButton btnCancel;
    }
}
