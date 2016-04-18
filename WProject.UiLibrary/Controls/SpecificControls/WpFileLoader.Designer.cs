namespace WProject.UiLibrary.Controls.SpecificControls
{
    partial class WpFileLoader
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
            this.pnlActions = new WProject.UiLibrary.Controls.WpPanel();
            this.btnSelectAll = new WProject.UiLibrary.Controls.WpButton();
            this.btnDeleteAll = new WProject.UiLibrary.Controls.WpButton();
            this.btnSaveAll = new WProject.UiLibrary.Controls.WpButton();
            this.lblCount = new WProject.UiLibrary.Controls.WpLabel();
            this.btnUpload = new WProject.UiLibrary.Controls.WpButton();
            this.pnlFiles = new WProject.UiLibrary.Controls.WpPanel();
            this.fdUpload = new System.Windows.Forms.OpenFileDialog();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlActions.Controls.Add(this.btnSelectAll);
            this.pnlActions.Controls.Add(this.btnDeleteAll);
            this.pnlActions.Controls.Add(this.btnSaveAll);
            this.pnlActions.Controls.Add(this.lblCount);
            this.pnlActions.Controls.Add(this.btnUpload);
            this.pnlActions.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.DoubleBuffered = true;
            this.pnlActions.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlActions.ForeColor = System.Drawing.Color.Black;
            this.pnlActions.Location = new System.Drawing.Point(0, 408);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.OwnStyle = false;
            this.pnlActions.Size = new System.Drawing.Size(800, 42);
            this.pnlActions.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSelectAll.FlatAppearance.BorderSize = 0;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Image = global::WProject.UiLibrary.Properties.Resources.done_all_s;
            this.btnSelectAll.Location = new System.Drawing.Point(489, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Selected = false;
            this.btnSelectAll.Size = new System.Drawing.Size(36, 36);
            this.btnSelectAll.TabIndex = 7;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAll.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDeleteAll.FlatAppearance.BorderSize = 0;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Image = global::WProject.UiLibrary.Properties.Resources.close_s;
            this.btnDeleteAll.Location = new System.Drawing.Point(529, 3);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Selected = false;
            this.btnDeleteAll.Size = new System.Drawing.Size(36, 36);
            this.btnDeleteAll.TabIndex = 6;
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAll.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSaveAll.FlatAppearance.BorderSize = 0;
            this.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAll.Image = global::WProject.UiLibrary.Properties.Resources.download_s;
            this.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveAll.Location = new System.Drawing.Point(571, 3);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Selected = false;
            this.btnSaveAll.Size = new System.Drawing.Size(113, 36);
            this.btnSaveAll.TabIndex = 4;
            this.btnSaveAll.Text = "Save all";
            this.btnSaveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveAll.UseVisualStyleBackColor = false;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(3, 7);
            this.lblCount.Name = "lblCount";
            this.lblCount.Selected = false;
            this.lblCount.Size = new System.Drawing.Size(107, 28);
            this.lblCount.Style = null;
            this.lblCount.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "0 files (0 b)";
            this.lblCount.VisibleChanged += new System.EventHandler(this.lblCount_VisibleChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Image = global::WProject.UiLibrary.Properties.Resources.upload_s;
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(690, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Selected = false;
            this.btnUpload.Size = new System.Drawing.Size(107, 36);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pnlFiles
            // 
            this.pnlFiles.AutoScroll = true;
            this.pnlFiles.BackColor = System.Drawing.Color.Transparent;
            this.pnlFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiles.DoubleBuffered = true;
            this.pnlFiles.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlFiles.ForeColor = System.Drawing.Color.Black;
            this.pnlFiles.Location = new System.Drawing.Point(0, 0);
            this.pnlFiles.Name = "pnlFiles";
            this.pnlFiles.OwnStyle = false;
            this.pnlFiles.Size = new System.Drawing.Size(800, 408);
            this.pnlFiles.TabIndex = 1;
            // 
            // fdUpload
            // 
            this.fdUpload.FileOk += new System.ComponentModel.CancelEventHandler(this.fdUpload_FileOk);
            // 
            // WpFileLoader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlFiles);
            this.Controls.Add(this.pnlActions);
            this.Name = "WpFileLoader";
            this.Size = new System.Drawing.Size(800, 450);
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WpPanel pnlActions;
        private WpButton btnUpload;
        private WpLabel lblCount;
        private WpButton btnSaveAll;
        private WpButton btnDeleteAll;
        private WpButton btnSelectAll;
        private WpPanel pnlFiles;
        private System.Windows.Forms.OpenFileDialog fdUpload;
    }
}
