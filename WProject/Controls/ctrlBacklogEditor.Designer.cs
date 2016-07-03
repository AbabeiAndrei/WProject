using WProject.WebApiClasses.Classes;

namespace WProject.Controls
{
    partial class ctrlBacklogEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlBacklogEditor));
            this.pnlTop = new WProject.UiLibrary.Controls.WpPanel();
            this.btnCopy = new WProject.UiLibrary.Controls.WpButton();
            this.ddState = new WProject.UiLibrary.Controls.WpDropDown<DictItem>();
            this.ddUser = new WProject.UiLibrary.Controls.WpDropDown<User>();
            this.btnMaximize = new WProject.UiLibrary.Controls.WpButton();
            this.btnClose = new WProject.UiLibrary.Controls.WpButton();
            this.txtName = new WProject.UiLibrary.Controls.WpTextBox();
            this.lblBacklogId = new WProject.UiLibrary.Controls.WpLabel();
            this.wpPanel1 = new WProject.UiLibrary.Controls.WpPanel();
            this.btnFavorite = new WProject.UiLibrary.Controls.WpButton();
            this.btnSave = new WProject.UiLibrary.Controls.WpButton();
            this.pnlActions = new WProject.UiLibrary.Controls.WpPanel();
            this.btnUndo = new WProject.UiLibrary.Controls.WpButton();
            this.btnRefresh = new WProject.UiLibrary.Controls.WpButton();
            this.btnPrint = new WProject.UiLibrary.Controls.WpButton();
            this.tthMessages = new WProject.UiLibrary.Controls.WpTextThread();
            this.txtDesc = new WProject.UiLibrary.Controls.WpTextEditor();
            this.pnlTop.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.btnCopy);
            this.pnlTop.Controls.Add(this.ddState);
            this.pnlTop.Controls.Add(this.ddUser);
            this.pnlTop.Controls.Add(this.btnMaximize);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.txtName);
            this.pnlTop.Controls.Add(this.lblBacklogId);
            this.pnlTop.Controls.Add(this.wpPanel1);
            this.pnlTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DoubleBuffered = true;
            this.pnlTop.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlTop.ForeColor = System.Drawing.Color.Black;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.OwnStyle = false;
            this.pnlTop.Size = new System.Drawing.Size(874, 73);
            this.pnlTop.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Image = global::WProject.Properties.Resources.clipboard_s;
            this.btnCopy.Location = new System.Drawing.Point(765, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Selected = false;
            this.btnCopy.Size = new System.Drawing.Size(32, 32);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // ddState
            // 
            this.ddState.BackColor = System.Drawing.Color.White;
            this.ddState.Cursor = System.Windows.Forms.Cursors.Default;
            this.ddState.CustomControl = null;
            this.ddState.DisplayMember = null;
            this.ddState.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ddState.ForeColor = System.Drawing.Color.Black;
            this.ddState.ImageMember = null;
            this.ddState.ItemStyle = ((WProject.UiLibrary.Style.UiStyle)(resources.GetObject("ddState.ItemStyle")));
            this.ddState.Location = new System.Drawing.Point(23, 39);
            this.ddState.Name = "ddState";
            this.ddState.SelectedIndex = 0;
            this.ddState.ShowImage = false;
            this.ddState.Size = new System.Drawing.Size(150, 22);
            this.ddState.SortMember = null;
            this.ddState.TabIndex = 6;
            this.ddState.ValueMember = null;
            // 
            // ddUser
            // 
            this.ddUser.BackColor = System.Drawing.Color.White;
            this.ddUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.ddUser.CustomControl = null;
            this.ddUser.DisplayMember = null;
            this.ddUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ddUser.ForeColor = System.Drawing.Color.Black;
            this.ddUser.ImageMember = null;
            this.ddUser.ItemStyle = ((WProject.UiLibrary.Style.UiStyle)(resources.GetObject("ddUser.ItemStyle")));
            this.ddUser.Location = new System.Drawing.Point(200, 39);
            this.ddUser.Name = "ddUser";
            this.ddUser.SelectedIndex = 0;
            this.ddUser.ShowImage = false;
            this.ddUser.Size = new System.Drawing.Size(150, 22);
            this.ddUser.SortMember = null;
            this.ddUser.TabIndex = 5;
            this.ddUser.ValueMember = null;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.DarkGray;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Image = global::WProject.Properties.Resources.fullscreen_s;
            this.btnMaximize.Location = new System.Drawing.Point(803, 3);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Selected = false;
            this.btnMaximize.Size = new System.Drawing.Size(32, 32);
            this.btnMaximize.TabIndex = 4;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::WProject.Properties.Resources.close_s;
            this.btnClose.Location = new System.Drawing.Point(839, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Selected = false;
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.LeftButton = null;
            this.txtName.Location = new System.Drawing.Point(165, 4);
            this.txtName.Name = "txtName";
            this.txtName.ShowClear = false;
            this.txtName.Size = new System.Drawing.Size(632, 29);
            this.txtName.TabIndex = 2;
            // 
            // lblBacklogId
            // 
            this.lblBacklogId.Location = new System.Drawing.Point(23, 7);
            this.lblBacklogId.Name = "lblBacklogId";
            this.lblBacklogId.Selected = false;
            this.lblBacklogId.Size = new System.Drawing.Size(136, 24);
            this.lblBacklogId.Style = null;
            this.lblBacklogId.StyleType = WProject.UiLibrary.Style.StyleType.Normal;
            this.lblBacklogId.TabIndex = 1;
            this.lblBacklogId.Text = "0";
            // 
            // wpPanel1
            // 
            this.wpPanel1.BackColor = System.Drawing.Color.Transparent;
            this.wpPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wpPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.wpPanel1.DoubleBuffered = true;
            this.wpPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.wpPanel1.ForeColor = System.Drawing.Color.Black;
            this.wpPanel1.Location = new System.Drawing.Point(0, 0);
            this.wpPanel1.Name = "wpPanel1";
            this.wpPanel1.OwnStyle = false;
            this.wpPanel1.Size = new System.Drawing.Size(17, 73);
            this.wpPanel1.TabIndex = 0;
            // 
            // btnFavorite
            // 
            this.btnFavorite.BackColor = System.Drawing.Color.DarkGray;
            this.btnFavorite.FlatAppearance.BorderSize = 0;
            this.btnFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorite.Image = global::WProject.Properties.Resources.heart_empty_w_s;
            this.btnFavorite.Location = new System.Drawing.Point(36, 3);
            this.btnFavorite.Name = "btnFavorite";
            this.btnFavorite.Selected = false;
            this.btnFavorite.Size = new System.Drawing.Size(32, 32);
            this.btnFavorite.TabIndex = 7;
            this.btnFavorite.UseVisualStyleBackColor = false;
            this.btnFavorite.Click += new System.EventHandler(this.btnFavorite_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::WProject.Properties.Resources.save_s;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(138, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Selected = false;
            this.btnSave.Size = new System.Drawing.Size(120, 32);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlActions.Controls.Add(this.btnUndo);
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Controls.Add(this.btnSave);
            this.pnlActions.Controls.Add(this.btnFavorite);
            this.pnlActions.Controls.Add(this.btnPrint);
            this.pnlActions.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.DoubleBuffered = true;
            this.pnlActions.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlActions.ForeColor = System.Drawing.Color.Black;
            this.pnlActions.Location = new System.Drawing.Point(0, 393);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.OwnStyle = false;
            this.pnlActions.Size = new System.Drawing.Size(874, 39);
            this.pnlActions.TabIndex = 2;
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.DarkGray;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Image = global::WProject.Properties.Resources.undo_s;
            this.btnUndo.Location = new System.Drawing.Point(103, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Selected = false;
            this.btnUndo.Size = new System.Drawing.Size(32, 32);
            this.btnUndo.TabIndex = 10;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::WProject.Properties.Resources.refresh_s;
            this.btnRefresh.Location = new System.Drawing.Point(69, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Selected = false;
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.DarkGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::WProject.Properties.Resources.print_w_s;
            this.btnPrint.Location = new System.Drawing.Point(3, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Selected = false;
            this.btnPrint.Size = new System.Drawing.Size(32, 32);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tthMessages
            // 
            this.tthMessages.BackColor = System.Drawing.Color.Transparent;
            this.tthMessages.Cursor = System.Windows.Forms.Cursors.Default;
            this.tthMessages.Dock = System.Windows.Forms.DockStyle.Right;
            this.tthMessages.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tthMessages.ForeColor = System.Drawing.Color.Black;
            this.tthMessages.Location = new System.Drawing.Point(511, 73);
            this.tthMessages.Name = "tthMessages";
            this.tthMessages.OwnStyle = false;
            this.tthMessages.ReciveMessageColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.tthMessages.ReciveMessageForeColor = System.Drawing.Color.Empty;
            this.tthMessages.SendMessageColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.tthMessages.SendMessageForeColor = System.Drawing.Color.Empty;
            this.tthMessages.Size = new System.Drawing.Size(363, 320);
            this.tthMessages.TabIndex = 3;
            // 
            // txtDesc
            // 
            this.txtDesc.AllowImageBiggerThanClient = false;
            this.txtDesc.BackColor = System.Drawing.Color.Transparent;
            this.txtDesc.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.ForeColor = System.Drawing.Color.Black;
            this.txtDesc.Location = new System.Drawing.Point(0, 73);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.OwnStyle = false;
            this.txtDesc.Size = new System.Drawing.Size(511, 320);
            this.txtDesc.TabIndex = 4;
            // 
            // ctrlBacklogEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.tthMessages);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlTop);
            this.Name = "ctrlBacklogEditor";
            this.Size = new System.Drawing.Size(874, 432);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UiLibrary.Controls.WpPanel pnlTop;
        private UiLibrary.Controls.WpPanel wpPanel1;
        private UiLibrary.Controls.WpLabel lblBacklogId;
        private UiLibrary.Controls.WpTextBox txtName;
        private UiLibrary.Controls.WpButton btnClose;
        private UiLibrary.Controls.WpButton btnMaximize;
        private UiLibrary.Controls.WpDropDown<User> ddUser;
        private UiLibrary.Controls.WpButton btnFavorite;
        private UiLibrary.Controls.WpButton btnSave;
        private UiLibrary.Controls.WpButton btnPrint;
        private UiLibrary.Controls.WpPanel pnlActions;
        private UiLibrary.Controls.WpButton btnRefresh;
        private UiLibrary.Controls.WpButton btnUndo;
        private UiLibrary.Controls.WpTextThread tthMessages;
        private UiLibrary.Controls.WpTextEditor txtDesc;
        private UiLibrary.Controls.WpDropDown<DictItem> ddState;
        private UiLibrary.Controls.WpButton btnCopy;
    }
}
