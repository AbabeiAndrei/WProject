namespace WProject.Controls.MainPageControls.TimeLineControls
{
    partial class ctrlTimeLineRowHeaderUser
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
            this.pnlTop = new WProject.UiLibrary.Controls.WpPanel();
            this.lblName = new WProject.UiLibrary.Controls.WpLabel();
            this.pbAvatar = new WProject.UiLibrary.Controls.WpPictureBox();
            this.pbExpand = new WProject.UiLibrary.Controls.WpPictureBox();
            this.pnlBacklogs = new WProject.UiLibrary.Controls.WpPanel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.lblName);
            this.pnlTop.Controls.Add(this.pbAvatar);
            this.pnlTop.Controls.Add(this.pbExpand);
            this.pnlTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DoubleBuffered = true;
            this.pnlTop.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlTop.ForeColor = System.Drawing.Color.Black;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.OwnStyle = false;
            this.pnlTop.Size = new System.Drawing.Size(250, 40);
            this.pnlTop.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(80, 0);
            this.lblName.Name = "lblName";
            this.lblName.Selected = false;
            this.lblName.Size = new System.Drawing.Size(170, 40);
            this.lblName.Style = null;
            this.lblName.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Click += new System.EventHandler(this.pbExpand_Click);
            // 
            // pbAvatar
            // 
            this.pbAvatar.BackColor = System.Drawing.Color.Transparent;
            this.pbAvatar.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbAvatar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbAvatar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pbAvatar.ForeColor = System.Drawing.Color.White;
            this.pbAvatar.Image = null;
            this.pbAvatar.Location = new System.Drawing.Point(40, 0);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.OwnStyle = false;
            this.pbAvatar.Size = new System.Drawing.Size(40, 40);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAvatar.TabIndex = 1;
            this.pbAvatar.Click += new System.EventHandler(this.pbExpand_Click);
            // 
            // pbExpand
            // 
            this.pbExpand.BackColor = System.Drawing.Color.Transparent;
            this.pbExpand.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbExpand.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbExpand.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pbExpand.ForeColor = System.Drawing.Color.White;
            this.pbExpand.Image = global::WProject.Properties.Resources.expand_s;
            this.pbExpand.Location = new System.Drawing.Point(0, 0);
            this.pbExpand.Name = "pbExpand";
            this.pbExpand.OwnStyle = false;
            this.pbExpand.Size = new System.Drawing.Size(40, 40);
            this.pbExpand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbExpand.TabIndex = 0;
            this.pbExpand.Click += new System.EventHandler(this.pbExpand_Click);
            // 
            // pnlBacklogs
            // 
            this.pnlBacklogs.AutoSize = true;
            this.pnlBacklogs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBacklogs.BackColor = System.Drawing.Color.Transparent;
            this.pnlBacklogs.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlBacklogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBacklogs.DoubleBuffered = true;
            this.pnlBacklogs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlBacklogs.ForeColor = System.Drawing.Color.Black;
            this.pnlBacklogs.Location = new System.Drawing.Point(0, 40);
            this.pnlBacklogs.Name = "pnlBacklogs";
            this.pnlBacklogs.OwnStyle = false;
            this.pnlBacklogs.Size = new System.Drawing.Size(250, 0);
            this.pnlBacklogs.TabIndex = 1;
            this.pnlBacklogs.Visible = false;
            // 
            // ctrlTimeLineRowHeaderUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlBacklogs);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(250, 0);
            this.Name = "ctrlTimeLineRowHeaderUser";
            this.Size = new System.Drawing.Size(250, 40);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UiLibrary.Controls.WpPanel pnlTop;
        private UiLibrary.Controls.WpPictureBox pbExpand;
        private UiLibrary.Controls.WpPanel pnlBacklogs;
        private UiLibrary.Controls.WpPictureBox pbAvatar;
        private UiLibrary.Controls.WpLabel lblName;
    }
}
