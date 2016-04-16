namespace WProject.UiLibrary.Controls
{
    partial class WpTextThread
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
            this.pnlThread = new WProject.UiLibrary.Controls.WpPanel();
            this.pnlBottom = new WProject.UiLibrary.Controls.WpPanel();
            this.btnSend = new WProject.UiLibrary.Controls.WpButton();
            this.txtMessage = new WProject.UiLibrary.Controls.WpTextBox();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.pnlThread);
            this.pnlMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.DoubleBuffered = true;
            this.pnlMain.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlMain.ForeColor = System.Drawing.Color.Black;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.OwnStyle = false;
            this.pnlMain.Size = new System.Drawing.Size(363, 307);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlThread
            // 
            this.pnlThread.AutoScroll = true;
            this.pnlThread.BackColor = System.Drawing.Color.Transparent;
            this.pnlThread.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlThread.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThread.DoubleBuffered = true;
            this.pnlThread.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlThread.ForeColor = System.Drawing.Color.Black;
            this.pnlThread.Location = new System.Drawing.Point(0, 0);
            this.pnlThread.Name = "pnlThread";
            this.pnlThread.OwnStyle = false;
            this.pnlThread.Size = new System.Drawing.Size(363, 10);
            this.pnlThread.TabIndex = 0;
            this.pnlThread.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlThread_Paint);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.btnSend);
            this.pnlBottom.Controls.Add(this.txtMessage);
            this.pnlBottom.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DoubleBuffered = true;
            this.pnlBottom.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlBottom.ForeColor = System.Drawing.Color.Black;
            this.pnlBottom.Location = new System.Drawing.Point(0, 307);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.OwnStyle = false;
            this.pnlBottom.Size = new System.Drawing.Size(363, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Image = global::WProject.UiLibrary.Properties.Resources.send_s;
            this.btnSend.Location = new System.Drawing.Point(310, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Selected = false;
            this.btnSend.Size = new System.Drawing.Size(49, 37);
            this.btnSend.TabIndex = 1;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.LeftButton = null;
            this.txtMessage.Location = new System.Drawing.Point(3, 5);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ShowClear = false;
            this.txtMessage.Size = new System.Drawing.Size(356, 29);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // WpTextThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Name = "WpTextThread";
            this.Size = new System.Drawing.Size(363, 347);
            this.pnlMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WpTextBox txtMessage;
        private WpPanel pnlBottom;
        private WpButton btnSend;
        private WpPanel pnlMain;
        private WpPanel pnlThread;
    }
}
