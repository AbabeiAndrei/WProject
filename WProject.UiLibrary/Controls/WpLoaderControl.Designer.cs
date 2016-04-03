namespace WProject.UiLibrary.Controls
{
    partial class WpLoaderControl
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
            WProject.UiLibrary.Style.UiStyle uiStyle1 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style1 = new WProject.UiLibrary.Style.Style();
            this.pbLoader = new System.Windows.Forms.PictureBox();
            this.lblText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLoader
            // 
            this.pbLoader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbLoader.Image = global::WProject.UiLibrary.Properties.Resources.loader;
            this.pbLoader.Location = new System.Drawing.Point(380, 172);
            this.pbLoader.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pbLoader.Name = "pbLoader";
            this.pbLoader.Size = new System.Drawing.Size(244, 291);
            this.pbLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLoader.TabIndex = 0;
            this.pbLoader.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(20, 469);
            this.lblText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(967, 186);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Loading...";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WpLoaderControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.pbLoader);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "WpLoaderControl";
            this.Size = new System.Drawing.Size(1006, 847);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbLoader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLoader;
        private System.Windows.Forms.Label lblText;
    }
}