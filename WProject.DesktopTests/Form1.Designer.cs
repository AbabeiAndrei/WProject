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
            this.wpTextThread1 = new WProject.UiLibrary.Controls.WpTextThread();
            this.SuspendLayout();
            // 
            // wpTextThread1
            // 
            this.wpTextThread1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.wpTextThread1.Location = new System.Drawing.Point(169, 49);
            this.wpTextThread1.Name = "wpTextThread1";
            this.wpTextThread1.Size = new System.Drawing.Size(363, 347);
            this.wpTextThread1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 465);
            this.Controls.Add(this.wpTextThread1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpTextThread wpTextThread1;
    }
}

