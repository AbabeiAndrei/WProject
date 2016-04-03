namespace WProject.Controls
{
    partial class ctrlLoginControl
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
            this.components = new System.ComponentModel.Container();
            WProject.UiLibrary.Style.UiStyle uiStyle1 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style1 = new WProject.UiLibrary.Style.Style();
            this.lblUser = new WProject.UiLibrary.Controls.WpLabel();
            this.txtUser = new WProject.UiLibrary.Controls.WpTextBox();
            this.txtPass = new WProject.UiLibrary.Controls.WpTextBox();
            this.lblPass = new WProject.UiLibrary.Controls.WpLabel();
            this.chkRemeber = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tmrLoadAnimation = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(424, 192);
            this.lblUser.Name = "lblUser";
            this.lblUser.Selected = false;
            this.lblUser.Size = new System.Drawing.Size(51, 28);
            this.lblUser.Style = null;
            this.lblUser.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(516, 192);
            this.txtUser.MaxLength = 128;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(223, 34);
            this.txtUser.TabIndex = 1;
            this.txtUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // txtPass
            // 
            this.txtPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(516, 248);
            this.txtPass.MaxLength = 128;
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(223, 34);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // lblPass
            // 
            this.lblPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(424, 248);
            this.lblPass.Name = "lblPass";
            this.lblPass.Selected = false;
            this.lblPass.Size = new System.Drawing.Size(49, 28);
            this.lblPass.Style = null;
            this.lblPass.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Pass";
            // 
            // chkRemeber
            // 
            this.chkRemeber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkRemeber.AutoSize = true;
            this.chkRemeber.BackColor = System.Drawing.Color.Transparent;
            this.chkRemeber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemeber.Location = new System.Drawing.Point(429, 299);
            this.chkRemeber.Name = "chkRemeber";
            this.chkRemeber.Size = new System.Drawing.Size(144, 32);
            this.chkRemeber.TabIndex = 3;
            this.chkRemeber.Text = "Remeber me";
            this.chkRemeber.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Enabled = false;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(589, 344);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(150, 50);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tmrLoadAnimation
            // 
            this.tmrLoadAnimation.Interval = 150;
            this.tmrLoadAnimation.Tick += new System.EventHandler(this.tmrLoadAnimation_Tick);
            // 
            // ctrlLoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WProject.Properties.Resources.LoginBlurBk;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkRemeber);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Name = "ctrlLoginControl";
            this.Size = new System.Drawing.Size(1162, 678);
            uiStyle1.ClickStyle = null;
            uiStyle1.HoverStyle = null;
            style1.BackColor = System.Drawing.Color.Transparent;
            style1.BorderColor = null;
            style1.BorderWidth = null;
            style1.Cursor = System.Windows.Forms.Cursors.Default;
            style1.Font = new System.Drawing.Font("Segoe UI", 14F);
            style1.ForeColor = System.Drawing.Color.Black;
            style1.Margin = new System.Windows.Forms.Padding(3);
            style1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            uiStyle1.NormalStyle = style1;
            uiStyle1.SelectedStyle = null;
            this.Style = uiStyle1;
            this.Load += new System.EventHandler(this.ctrlLoginControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ctrlLoginControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UiLibrary.Controls.WpLabel lblUser;
        private UiLibrary.Controls.WpTextBox txtUser;
        private UiLibrary.Controls.WpTextBox txtPass;
        private UiLibrary.Controls.WpLabel lblPass;
        private System.Windows.Forms.CheckBox chkRemeber;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Timer tmrLoadAnimation;
    }
}
