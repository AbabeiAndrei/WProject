﻿namespace WProject.Controls.MainPageControls.TimeLineControls
{
    partial class ctrlTimeLineRowHeader
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
            this.pnlPadding = new WProject.UiLibrary.Controls.WpPanel();
            this.SuspendLayout();
            // 
            // pnlPadding
            // 
            this.pnlPadding.BackColor = System.Drawing.Color.Transparent;
            this.pnlPadding.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlPadding.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPadding.DoubleBuffered = true;
            this.pnlPadding.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlPadding.ForeColor = System.Drawing.Color.Black;
            this.pnlPadding.Location = new System.Drawing.Point(0, 0);
            this.pnlPadding.Name = "pnlPadding";
            this.pnlPadding.OwnStyle = false;
            this.pnlPadding.Size = new System.Drawing.Size(150, 20);
            this.pnlPadding.TabIndex = 0;
            // 
            // ctrlTimeLineRowHeader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlPadding);
            this.Name = "ctrlTimeLineRowHeader";
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpPanel pnlPadding;
    }
}
