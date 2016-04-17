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
            this.wpCheckBox1 = new WProject.UiLibrary.Controls.WpCheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // wpCheckBox1
            // 
            this.wpCheckBox1.AutoSize = true;
            this.wpCheckBox1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wpCheckBox1.Location = new System.Drawing.Point(113, 129);
            this.wpCheckBox1.Name = "wpCheckBox1";
            this.wpCheckBox1.Padding = new System.Windows.Forms.Padding(58, 0, 0, 0);
            this.wpCheckBox1.Selected = false;
            this.wpCheckBox1.Size = new System.Drawing.Size(327, 54);
            this.wpCheckBox1.Style = null;
            this.wpCheckBox1.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.wpCheckBox1.TabIndex = 0;
            this.wpCheckBox1.Text = "wpCheckBox1";
            this.wpCheckBox1.OnCheckChanged += new System.EventHandler(this.wpCheckBox1_OnCheckChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(410, 62);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 21);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 465);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.wpCheckBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UiLibrary.Controls.WpCheckBox wpCheckBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

