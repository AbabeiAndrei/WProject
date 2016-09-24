namespace WProject.Controls
{
    partial class ctrlConfirmAction
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
            this.lblTitle = new WProject.UiLibrary.Controls.WpLabel();
            this.lblInfo = new WProject.UiLibrary.Controls.WpLabel();
            this.lblConfirm = new WProject.UiLibrary.Controls.WpLabel();
            this.txtConfirm = new WProject.UiLibrary.Controls.WpTextBox();
            this.btnCancel = new WProject.UiLibrary.Controls.WpButton();
            this.btnConfirm = new WProject.UiLibrary.Controls.WpButton();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Selected = false;
            this.lblTitle.Size = new System.Drawing.Size(319, 70);
            this.lblTitle.Style = null;
            this.lblTitle.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblTitle.TabIndex = 0;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(15, 113);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Selected = false;
            this.lblInfo.Size = new System.Drawing.Size(319, 34);
            this.lblInfo.Style = null;
            this.lblInfo.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "The action that you will do is ireversible!";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConfirm
            // 
            this.lblConfirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirm.Location = new System.Drawing.Point(17, 166);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Selected = false;
            this.lblConfirm.Size = new System.Drawing.Size(319, 34);
            this.lblConfirm.Style = null;
            this.lblConfirm.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblConfirm.TabIndex = 2;
            this.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirm.LeftButton = null;
            this.txtConfirm.Location = new System.Drawing.Point(21, 220);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.ShowClear = false;
            this.txtConfirm.Size = new System.Drawing.Size(313, 29);
            this.txtConfirm.TabIndex = 3;
            this.txtConfirm.TextChanged += new System.EventHandler(this.txtConfirm_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(20, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Selected = false;
            this.btnCancel.Size = new System.Drawing.Size(138, 49);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(196, 281);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Selected = false;
            this.btnConfirm.Size = new System.Drawing.Size(138, 49);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // ctrlConfirmAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.Name = "ctrlConfirmAction";
            this.Size = new System.Drawing.Size(352, 333);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UiLibrary.Controls.WpLabel lblTitle;
        private UiLibrary.Controls.WpLabel lblInfo;
        private UiLibrary.Controls.WpLabel lblConfirm;
        private UiLibrary.Controls.WpTextBox txtConfirm;
        private UiLibrary.Controls.WpButton btnCancel;
        private UiLibrary.Controls.WpButton btnConfirm;
    }
}
