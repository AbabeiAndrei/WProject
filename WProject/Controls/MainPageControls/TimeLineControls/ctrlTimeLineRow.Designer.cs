namespace WProject.Controls.MainPageControls.TimeLineControls
{
    partial class ctrlTimeLineRow
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
            this.pnlTasks = new WProject.UiLibrary.Controls.WpPanel();
            this.pnlInfo = new WProject.UiLibrary.Controls.WpPanel();
            this.SuspendLayout();
            // 
            // pnlTasks
            // 
            this.pnlTasks.BackColor = System.Drawing.Color.Transparent;
            this.pnlTasks.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTasks.DoubleBuffered = true;
            this.pnlTasks.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlTasks.ForeColor = System.Drawing.Color.Black;
            this.pnlTasks.Location = new System.Drawing.Point(0, 26);
            this.pnlTasks.Name = "pnlTasks";
            this.pnlTasks.OwnStyle = false;
            this.pnlTasks.Size = new System.Drawing.Size(597, 124);
            this.pnlTasks.TabIndex = 1;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.DoubleBuffered = true;
            this.pnlInfo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlInfo.ForeColor = System.Drawing.Color.Black;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.OwnStyle = false;
            this.pnlInfo.Size = new System.Drawing.Size(597, 26);
            this.pnlInfo.TabIndex = 0;
            this.pnlInfo.Visible = false;
            this.pnlInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInfo_Paint);
            // 
            // ctrlTimeLineRows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTasks);
            this.Controls.Add(this.pnlInfo);
            this.Name = "ctrlTimeLineRow";
            this.Size = new System.Drawing.Size(597, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpPanel pnlTasks;
        private UiLibrary.Controls.WpPanel pnlInfo;
    }
}
