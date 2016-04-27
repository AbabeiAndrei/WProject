using WProject.UiLibrary.Classes;

namespace WProject.DesktopTests
{
    partial class Form1
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
            this.wpFileLoader1 = new WProject.UiLibrary.Controls.SpecificControls.WpFileLoader();
            this.SuspendLayout();
            // 
            // wpFileLoader1
            // 
            this.wpFileLoader1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wpFileLoader1.BackColor = System.Drawing.Color.Transparent;
            this.wpFileLoader1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wpFileLoader1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.wpFileLoader1.ForeColor = System.Drawing.Color.Black;
            this.wpFileLoader1.Location = new System.Drawing.Point(42, 12);
            this.wpFileLoader1.Name = "wpFileLoader1";
            this.wpFileLoader1.OwnStyle = false;
            this.wpFileLoader1.Size = new System.Drawing.Size(593, 391);
            this.wpFileLoader1.TabIndex = 0;
            this.wpFileLoader1.OnFileUploaded += new FileItemEventHandler(this.wpFileLoader1_OnFileUploaded);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 465);
            this.Controls.Add(this.wpFileLoader1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.SpecificControls.WpFileLoader wpFileLoader1;
    }
}

