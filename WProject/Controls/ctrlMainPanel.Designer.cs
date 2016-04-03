namespace WProject.Controls
{
    partial class ctrlMainPanel
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
            WProject.UiLibrary.Style.UiStyle uiStyle1 = new WProject.UiLibrary.Style.UiStyle();
            WProject.UiLibrary.Style.Style style1 = new WProject.UiLibrary.Style.Style();
            this.SuspendLayout();
            // 
            // ctrlMainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Name = "ctrlMainPanel";
            this.Size = new System.Drawing.Size(878, 383);
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
            this.ResumeLayout(false);

        }

        #endregion
    }
}
