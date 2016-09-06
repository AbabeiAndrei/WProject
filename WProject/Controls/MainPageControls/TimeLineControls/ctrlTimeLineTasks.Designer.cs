namespace WProject.Controls.MainPageControls.TimeLineControls
{
    partial class ctrlTimeLineTasks
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
            this.pnlMain = new WProject.UiLibrary.Controls.WpPanel();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlMain.DoubleBuffered = true;
            this.pnlMain.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlMain.ForeColor = System.Drawing.Color.Black;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.OwnStyle = false;
            this.pnlMain.Size = new System.Drawing.Size(150, 150);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // ctrlTimeLineTasks
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlMain);
            this.Name = "ctrlTimeLineTasks";
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpPanel pnlMain;
    }
}
